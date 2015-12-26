using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Windows.ApplicationModel;
using Windows.Storage;

namespace Win10AppBackup.Utils
{
    [DebuggerDisplay("{Id.Name}")]
    public class AppPackage : INotifyPropertyChanged
    {
        public AppPackage()
        {
            Backup = new BackupPackage(this);
        }

        public string DisplayName { get; set; }

        public bool AppDataFolderExists { get; set; }

        public string AppDataFolderPath { get; set; }

        public string Icon { get; set; }

        public string Architecture { get; set; }

        public Version Version { get; set; }

        public DateTime InstalledDate { get; set; }

        public string InstalledLocation { get; set; }

        public AppId Id { get; set; }

        public BackupPackage Backup { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class AppId
    {
        public string FullName { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public string PublisherName { get; set; }

        public string PublisherId { get; set; }
    }

    public enum BackupMode
    {
        [Description("Smart backup files mode")]
        Smart = 0,
        [Description("Complete backup files mode")]
        Full = 1,
    }

    public enum BackupState
    {
        UnBackuped,
        OldBackuped,
        NotTheSamePlatform,
        Backuped
    }

    public class BackupPackage : INotifyPropertyChanged
    {
        private AppPackage package;
        private Version backupedVersion;
        private string lastBackupedPath;
        private bool isBusy;
        private object isBusyLock = new object();

        public BackupPackage(AppPackage package)
        {
            this.package = package;
        }

        public bool IsBackuped
        {
            get
            {
                return State == BackupState.Backuped;
            }
        }

        public string BackupPath
        {
            get
            {
                return Path.Combine(
                    SettingsExtension.Current.BackupPath,
                    "Win10AppBackup",
                    package.Id.FullName + ".zip");
            }
        }

        public string LastBackupPath
        {
            get
            {
                switch (State)
                {
                    case BackupState.UnBackuped:
                        return null;
                    case BackupState.OldBackuped:
                    case BackupState.NotTheSamePlatform:
                        return lastBackupedPath;
                    case BackupState.Backuped:
                    default:
                        return BackupPath;
                }
            }
        }

        public DateTime? BackupDate
        {
            get
            {
                return IsBackuped ? File.GetLastWriteTime(BackupPath) as DateTime? : null;
            }
        }

        public BackupState State
        {
            get
            {
                if (File.Exists(BackupPath))
                {
                    return BackupState.Backuped;
                }

                var availableVersion = from file in Directory.EnumerateFiles(Path.GetDirectoryName(BackupPath), $"{package.Id.Name}_*_*_{package.Id.PublisherId}.zip")
                                       let packageId = Path.GetFileNameWithoutExtension(file).Replace(package.Id.Name, string.Empty).Replace(package.Id.PublisherId, string.Empty)
                                       let Version = Version.Parse(packageId.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries)[0])
                                       let Architecture = packageId.Split('_')[1]
                                       orderby Version descending
                                       select new { Version, Architecture, file };
                var lastPackage = availableVersion.FirstOrDefault();

                if (lastPackage != null)
                {
                    Version = lastPackage.Version;
                    lastBackupedPath = lastPackage.file;
                    if (backupedVersion != package.Version)
                    {
                        return BackupState.OldBackuped;
                    }

                    if (lastPackage.Architecture != package.Architecture)
                    {
                        return BackupState.NotTheSamePlatform;
                    }
                }

                return BackupState.UnBackuped;
            }
        }


        public Version Version
        {
            get
            {
                if (State == BackupState.Backuped)
                {
                    return package.Version;
                }

                return backupedVersion;
            }

            private set
            {
                backupedVersion = value;
            }
        }

        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            private set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBusy)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task BackupAsync(BackupMode backupType)
        {
            return Task.Run(() => Backup(backupType));
        }

        public void Backup(BackupMode backupType)
        {
            if (!package.AppDataFolderExists)
            {
                return;
            }

            lock (isBusyLock)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(BackupPath));

                bool exceptionOccured = false;

                var fastZipEvents = new ICSharpCode.SharpZipLib.Zip.FastZipEvents();
                fastZipEvents.FileFailure = (sender, e) =>
                {
                    exceptionOccured = true;
                    e.ContinueRunning = false;
                };
                var zipFile = new ICSharpCode.SharpZipLib.Zip.FastZip(fastZipEvents) { CreateEmptyDirectories = true };

                string fileFilter = null;
                string folderFilter = null;

                switch (backupType)
                {
                    case BackupMode.Smart:
                        fileFilter = @";-Settings\\roaming\.lock$;-Settings\\settings\.dat\.LOG[0-9]*$;-ActivationStore\.dat\.LOG[0-9]*$";
                        folderFilter = @"-AC$;-LocalCache;-TempState";
                        break;
                    case BackupMode.Full:
                        break;
                }

                IsBusy = true;
                try
                {
                    zipFile.CreateZip(BackupPath, package.AppDataFolderPath, true, fileFilter, folderFilter);
                }
                finally
                {
                    if (exceptionOccured)
                    {
                        try
                        {
                            File.Delete(BackupPath);
                        }
                        finally
                        {
                            IsBusy = false;
                            throw new InvalidOperationException($"« {package.DisplayName} » must be closed before saving");
                        }
                    }

                    IsBusy = false;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsBackuped)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackupDate)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(State)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Version)));
                }
            }
        }

        public void Restore()
        {
            if (!package.AppDataFolderExists || State == BackupState.UnBackuped)
            {
                return;
            }

            lock (isBusyLock)
            {
                IsBusy = true;
                new ICSharpCode.SharpZipLib.Zip.FastZip() { CreateEmptyDirectories = true }.ExtractZip(LastBackupPath, package.AppDataFolderPath, null);
                IsBusy = false;
            }
        }
    }
}
