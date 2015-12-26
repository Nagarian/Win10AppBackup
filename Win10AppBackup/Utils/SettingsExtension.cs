using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win10AppBackup.Utils
{
    public class SettingsExtension : INotifyPropertyChanged
    {
        public static SettingsExtension Current { get; } = new SettingsExtension();

        public string BackupPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.BackupPath))
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                }

                return Properties.Settings.Default.BackupPath;
            }

            set
            {
                if (value != Properties.Settings.Default.BackupPath)
                {
                    Properties.Settings.Default.BackupPath = value;
                    Properties.Settings.Default.Save();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackupPath)));
                }
            }
        }

        public BackupMode BackupMode
        {
            get
            {
                return (BackupMode)Properties.Settings.Default.BackupMode;
            }

            set
            {
                if (value != (BackupMode)Properties.Settings.Default.BackupMode)
                {
                    Properties.Settings.Default.BackupMode = (int)value;
                    Properties.Settings.Default.Save();
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BackupMode)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
