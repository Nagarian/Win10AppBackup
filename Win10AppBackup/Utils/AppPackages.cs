using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Win10AppBackup.Utils
{
    public class AppPackages
    {
        public static IEnumerable<AppPackage> GetPackages()
        {
            Windows.Management.Deployment.PackageManager packageManager = new Windows.Management.Deployment.PackageManager();
            var appDataFolderPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages");
            var appDataFolders = Directory.EnumerateDirectories(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages"));
            var register = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Classes\Extensions\ContractId\Windows.Launch\PackageId");

            //TestingCode();

            return from package in packageManager.FindPackagesForUser(System.Security.Principal.WindowsIdentity.GetCurrent().User.Value)
                   let name = Extract(register, package.Id.FullName)
                   let image = Extract(register, package.Id.FullName, "Icon")
                   let description = Extract(register, package.Id.FullName, "Description")
                   let vendor = Extract(register, package.Id.FullName, "Vendor")
                   let appDataPath = System.IO.Path.Combine(appDataFolderPath, package.Id.FamilyName)
                   let appDataExists = Directory.Exists(appDataPath)
                   let installedLocation = SafeDirectory(package)?.Path
                   orderby name
                   select new AppPackage
                   {
                       AppDataFolderExists = appDataExists,
                       AppDataFolderPath = appDataPath,
                       Architecture = package.Id.Architecture.ToString(),
                       DisplayName = name,
                       Icon = image,
                       Id = new AppId
                       {
                           FamilyName = package.Id.FamilyName,
                           FullName = package.Id.FullName,
                           Name = package.Id.Name,
                           PublisherId = package.Id.PublisherId,
                           PublisherName = package.Id.Publisher
                       },
                       InstalledDate = package.InstalledDate.DateTime,
                       InstalledLocation = installedLocation,
                       Version = new Version(package.Id.Version.Major, package.Id.Version.Minor, package.Id.Version.Build, package.Id.Version.Revision)
                   };
        }

        private static StorageFolder SafeDirectory(Windows.ApplicationModel.Package package)
        {
            try
            {
                return package.InstalledLocation;
            }
            catch (Exception)
            {
                return null;
            }
        }

        [DllImport("shlwapi.dll", BestFitMapping = false, CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false, ThrowOnUnmappableChar = true)]
        private static extern int SHLoadIndirectString(string pszSource, StringBuilder pszOutBuf, int cchOutBuf, IntPtr ppvReserved);

        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern int GetSysColor(int nIndex);

        private static string ExtractStringFromPRIFile(string resourceKey)
        {
            var outBuff = new StringBuilder(1024);
            int result = SHLoadIndirectString(resourceKey, outBuff, outBuff.Capacity, IntPtr.Zero);
            return outBuff.ToString();
        }

        private static string Extract(RegistryKey key, string name, string value = "DisplayName")
        {
            var subKey = key.OpenSubKey($@"{name}\ActivatableClassId");
            string regName = subKey?.OpenSubKey(subKey.GetSubKeyNames().FirstOrDefault())?.GetValue(value, "").ToString() ?? string.Empty;
            return regName.StartsWith("@") ? ExtractStringFromPRIFile(regName) : regName;
        }

        private static void TestingCode()
        {
            var str = ExtractStringFromPRIFile("@{Microsoft.BioEnrollment_10.0.10240.16384_neutral__cw5n1h2txyewy?ms-resource://Microsoft.BioEnrollment/Resources/AppDisplayName}");
            var str2 = ExtractStringFromPRIFile("@{M6Web.M6_3.1.0.138_x64__ewak77gqn492e?ms-resource://M6Web.M6/resources/manifestAppDescription}");

            var str3 = str + str2;


            Windows.Management.Deployment.PackageManager manager = new Windows.Management.Deployment.PackageManager();
            var list = manager.FindPackagesForUser("");
            var installedPackage = list.ToList();
            var lala = list.Select(package => package.Id.Name).ToList();
            var userAppsFullNames = (from j in installedPackage
                                     let id = j.Id.FullName
                                     orderby id
                                     select id).ToList();

            var userAppsGrouped = (from j in installedPackage
                                   let id = j.Id.Name
                                   orderby id
                                   select id).Distinct().ToList();
            var appDatalist = (from directory in Directory.EnumerateDirectories(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Packages"))
                               let dirName = System.IO.Path.GetFileName(directory)
                               orderby dirName
                               select dirName).ToList();

            var appDataListFullName = (from directoryName in appDatalist
                                       let fullName = (from installedPackageName in installedPackage
                                                       where installedPackageName.Id.FamilyName == directoryName
                                                       select installedPackageName.Id.FullName).FirstOrDefault()
                                       where fullName != null
                                       select fullName).ToList();

            var to = installedPackage.Select(x => x.Id.FamilyName).Distinct().ToList();

            var packageGrouped = (from package in installedPackage
                                  group package by package.Id.FamilyName into packageGroup
                                  where packageGroup.Count() > 1
                                  select packageGroup).ToList();


            var appDataListFullNameEmptied = (from package in installedPackage // inversé les deux listes
                                              where appDatalist.Contains(package.Id.FamilyName)
                                              select package).ToList();

            var register = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Classes\Extensions\ContractId\Windows.Launch\PackageId");
            var tables = register.GetSubKeyNames();
            //@{Microsoft.BioEnrollment_10.0.10240.16384_neutral__cw5n1h2txyewy?ms-resource://Microsoft.BioEnrollment/Resources/AppDisplayName}

            var displayNameListFromRegister = (from appName in tables
                                               let realname = Extract(register, appName)
                                               orderby realname
                                               select realname).ToList();

            var displayNameListFromRegisterFilterByUserAppsCode = (from appName in tables
                                                                   where userAppsFullNames.Contains(appName)
                                                                   let realname = Extract(register, appName)
                                                                   orderby realname
                                                                   select realname).ToList();

            var displayNameListFromRegisterFilterByAppDataFolder = (from appName in tables
                                                                    where appDataListFullName.Contains(appName)
                                                                    let realname = Extract(register, appName)
                                                                    orderby realname
                                                                    select realname).ToList();

            var compared = (from id in displayNameListFromRegisterFilterByUserAppsCode
                            where !displayNameListFromRegisterFilterByAppDataFolder.Contains(id)
                            select id).ToList();

            var compared2 = (from id in displayNameListFromRegisterFilterByUserAppsCode
                             where !displayNameListFromRegisterFilterByAppDataFolder.Contains(id)
                             select id).ToList();

            var tato = register.OpenSubKey(@"10769UpdatePixels.CloudMangaReader_5.4.0.128_x64__jhqpz6nvs8dwt\ActivatableClassId\App.wwa").GetValue("Icon").ToString();
            ////using (Bitmap bmp = new System.Drawing.Icon(tato).ToBitmap())
            ////{
            ////    var stream = new MemoryStream();
            ////    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            ////    imageBox.Source = BitmapFrame.Create(stream);
            ////}

            ExtractStringFromPRIFile(tato);
            Windows.ApplicationModel.Resources.ResourceLoader.GetForViewIndependentUse().GetString("@{Microsoft.BioEnrollment_10.0.10240.16384_neutral__cw5n1h2txyewy?ms-resource://Microsoft.BioEnrollment/Resources/AppDisplayName}");
        }
    }
}
