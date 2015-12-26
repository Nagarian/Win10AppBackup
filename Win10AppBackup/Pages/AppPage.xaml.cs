using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Win10AppBackup.Utils;

namespace Win10AppBackup.Pages
{
    /// <summary>
    /// Logique d'interaction pour AppPage.xaml
    /// </summary>
    public partial class AppPage : UserControl
    {
        public AppPage()
        {
            InitializeComponent();
            this.Packages = AppPackages.GetPackages().Where(x => !string.IsNullOrEmpty(x.DisplayName)).ToList();

            this.DataContext = this;
        }

        public List<AppPackage> Packages { get; set; }

        private async void BackupClick(object sender, RoutedEventArgs e)
        {
            //Task.Factory.StartNew((appPackage) =>
            //{
            //    (appPackage as AppPackage)?.Backup(BackupMode.Smart);
            //}, (sender as FrameworkElement)?.DataContext).ContinueWith((ex) =>
            //{
            //    MessageBox.Show(ex.Exception.Flatten().InnerException.Message);
            //}, TaskContinuationOptions.OnlyOnFaulted);

            try
            {
                await ((sender as FrameworkElement)?.DataContext as AppPackage)?.Backup.BackupAsync(Win10AppBackup.Utils.SettingsExtension.Current.BackupMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RestoreClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((sender as FrameworkElement)?.DataContext as AppPackage)?.Backup.Restore();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    internal class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Packages = Deserialize();
        }

        public List<AppPackage> Packages { get; set; }

        private List<AppPackage> Deserialize()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<AppPackage>>(@"[{
	""DisplayName"": ""6play"",
    ""AppDataFolderExists"": true,
    ""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\M6Web.M6_ewak77gqn492e"",
    ""Icon"": ""C:\\Program Files\\WindowsApps\\M6Web.M6_3.1.0.138_x64__ewak77gqn492e\\Assets\\M6\\Logo.png"",
    ""Architecture"": ""X64"",
    ""Version"": {
                ""Major"": 3,
		""Minor"": 1,
		""Build"": 0,
		""Revision"": 138,
		""MajorRevision"": 0,
		""MinorRevision"": 138
    },
	""InstalledDate"": ""2015-08-23T10:53:15.0038737"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\M6Web.M6_3.1.0.138_x64__ewak77gqn492e"",
	""Id"": {
                ""FullName"": ""M6Web.M6_3.1.0.138_x64__ewak77gqn492e"",
		""Name"": ""M6Web.M6"",
		""FamilyName"": ""M6Web.M6_ewak77gqn492e"",
		""PublisherName"": ""CN=07F245D3-27BE-4025-8DB7-87B6AE193332"",
		""PublisherId"": ""ewak77gqn492e""
    }
        },
{
	""DisplayName"": ""Actualité"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.BingNews_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.BingNews_4.6.169.0_x86__8wekyb3d8bbwe\\Assets\\AppTiles\\News_TileMediumSquare.scale-100.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 4,
		""Minor"": 6,
		""Build"": 169,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-10T18:24:16.4071462"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.BingNews_4.6.169.0_x86__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.BingNews_4.6.169.0_x86__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.BingNews"",
		""FamilyName"": ""Microsoft.BingNews_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Alarmes et horloge"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsAlarms_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsAlarms_10.1510.14020.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\AlarmsMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 10,
		""Minor"": 1510,
		""Build"": 14020,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-22T15:09:41.3721703"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsAlarms_10.1510.14020.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsAlarms_10.1510.14020.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsAlarms"",
		""FamilyName"": ""Microsoft.WindowsAlarms_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""AlloCiné"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\AlloCin.AlloCin_rw1cw5z48aq2t"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\AlloCin.AlloCin_1.1.0.6_neutral__rw1cw5z48aq2t\\images\\logo.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1,
		""Minor"": 1,
		""Build"": 0,
		""Revision"": 6,
		""MajorRevision"": 0,
		""MinorRevision"": 6
	},
	""InstalledDate"": ""2015-08-23T10:53:29.8574314"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\AlloCin.AlloCin_1.1.0.6_neutral__rw1cw5z48aq2t"",
	""Id"": {
		""FullName"": ""AlloCin.AlloCin_1.1.0.6_neutral__rw1cw5z48aq2t"",
		""Name"": ""AlloCin.AlloCin"",
		""FamilyName"": ""AlloCin.AlloCin_rw1cw5z48aq2t"",
		""PublisherName"": ""CN=B35A6445-AED1-4E36-962B-4624D29CD4D6"",
		""PublisherId"": ""rw1cw5z48aq2t""
	}
},
{
	""DisplayName"": ""Appy Geek"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\MobilesRepublic.AppyGeek_n7gnan3nvj0by"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\MobilesRepublic.AppyGeek_4.3.1.0_neutral__n7gnan3nvj0by\\images\\logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 4,
		""Minor"": 3,
		""Build"": 1,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-23T10:49:59.2397041"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\MobilesRepublic.AppyGeek_4.3.1.0_neutral__n7gnan3nvj0by"",
	""Id"": {
		""FullName"": ""MobilesRepublic.AppyGeek_4.3.1.0_neutral__n7gnan3nvj0by"",
		""Name"": ""MobilesRepublic.AppyGeek"",
		""FamilyName"": ""MobilesRepublic.AppyGeek_n7gnan3nvj0by"",
		""PublisherName"": ""CN=08D9632F-C932-4E5A-8B2D-61900CCBC922"",
		""PublisherId"": ""n7gnan3nvj0by""
	}
},
{
	""DisplayName"": ""Assigned Access Lock app"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Windows.AssignedAccessLockApp_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.Windows.AssignedAccessLockApp_cw5n1h2txyewy\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1000,
		""Minor"": 10240,
		""Build"": 16384,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:39.4541086"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.Windows.AssignedAccessLockApp_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.Windows.AssignedAccessLockApp_1000.10240.16384.0_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.Windows.AssignedAccessLockApp"",
		""FamilyName"": ""Microsoft.Windows.AssignedAccessLockApp_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Assistant Mobile"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsPhone_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsPhone_10.1509.17010.0_x64__8wekyb3d8bbwe\\Assets\\CompanionAppMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 10,
		""Minor"": 1509,
		""Build"": 17010,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-09-23T00:59:11.6383662"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsPhone_10.1509.17010.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsPhone_10.1509.17010.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsPhone"",
		""FamilyName"": ""Microsoft.WindowsPhone_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Bureau à distance"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.RemoteDesktop_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.RemoteDesktop_6.3.9600.16419_neutral__8wekyb3d8bbwe\\Images\\Tile_Small.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 6,
		""Minor"": 3,
		""Build"": 9600,
		""Revision"": 16419,
		""MajorRevision"": 0,
		""MinorRevision"": 16419
	},
	""InstalledDate"": ""2015-08-23T10:49:28.3474818"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.RemoteDesktop_6.3.9600.16419_neutral__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.RemoteDesktop_6.3.9600.16419_neutral__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.RemoteDesktop"",
		""FamilyName"": ""Microsoft.RemoteDesktop_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Calculatrice"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsCalculator_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsCalculator_10.1510.13020.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\CalculatorMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 10,
		""Minor"": 1510,
		""Build"": 13020,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-23T02:06:35.1084133"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsCalculator_10.1510.13020.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsCalculator_10.1510.13020.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsCalculator"",
		""FamilyName"": ""Microsoft.WindowsCalculator_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Calendrier"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\microsoft.windowscommunicationsapps_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\microsoft.windowscommunicationsapps_17.6310.42251.0_x64__8wekyb3d8bbwe\\images\\HxCalendarMediumTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 17,
		""Minor"": 6310,
		""Build"": 42251,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-22T09:03:28.7539007"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\microsoft.windowscommunicationsapps_17.6310.42251.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""microsoft.windowscommunicationsapps_17.6310.42251.0_x64__8wekyb3d8bbwe"",
		""Name"": ""microsoft.windowscommunicationsapps"",
		""FamilyName"": ""microsoft.windowscommunicationsapps_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Caméra"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsCamera_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsCamera_2015.1078.40.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\WindowsIcons\\WindowsCameraMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 2015,
		""Minor"": 1078,
		""Build"": 40,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-30T17:03:12.4623952"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsCamera_2015.1078.40.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsCamera_2015.1078.40.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsCamera"",
		""FamilyName"": ""Microsoft.WindowsCamera_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Cartes"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsMaps_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsMaps_4.1510.3000.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\AppTiles\\MapsMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 4,
		""Minor"": 1510,
		""Build"": 3000,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-28T22:49:14.1220292"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsMaps_4.1510.3000.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsMaps_4.1510.3000.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsMaps"",
		""FamilyName"": ""Microsoft.WindowsMaps_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Code Writer"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\ActiproSoftwareLLC.562882FEEB491_24pqs290vpjk0"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\ActiproSoftwareLLC.562882FEEB491_2.4.15.15_neutral__24pqs290vpjk0\\Assets\\Square150x150Logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 2,
		""Minor"": 4,
		""Build"": 15,
		""Revision"": 15,
		""MajorRevision"": 0,
		""MinorRevision"": 15
	},
	""InstalledDate"": ""2015-08-23T10:50:10.8404412"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\ActiproSoftwareLLC.562882FEEB491_2.4.15.15_neutral__24pqs290vpjk0"",
	""Id"": {
		""FullName"": ""ActiproSoftwareLLC.562882FEEB491_2.4.15.15_neutral__24pqs290vpjk0"",
		""Name"": ""ActiproSoftwareLLC.562882FEEB491"",
		""FamilyName"": ""ActiproSoftwareLLC.562882FEEB491_24pqs290vpjk0"",
		""PublisherName"": ""CN=5E0BAC8C-0063-404C-8D8F-46BDD1EBD87A"",
		""PublisherId"": ""24pqs290vpjk0""
	}
},
{
	""DisplayName"": ""Commentaires sur Windows"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsFeedback_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\WindowsFeedback_cw5n1h2txyewy\\Assets\\FeedbackMedTile.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16393,
		""MajorRevision"": 0,
		""MinorRevision"": 16393
	},
	""InstalledDate"": ""2015-08-23T11:30:52.2987768"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\WindowsFeedback_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsFeedback_10.0.10240.16393_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.WindowsFeedback"",
		""FamilyName"": ""Microsoft.WindowsFeedback_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Compte Microsoft"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy\\images\\logo.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16384,
		""MajorRevision"": 0,
		""MinorRevision"": 16384
	},
	""InstalledDate"": ""2015-08-22T20:42:37.8759071"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.Windows.CloudExperienceHost_10.0.10240.16384_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.Windows.CloudExperienceHost"",
		""FamilyName"": ""Microsoft.Windows.CloudExperienceHost_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Compte professionnel ou scolaire"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1000,
		""Minor"": 10240,
		""Build"": 16384,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:37.500888"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.AAD.BrokerPlugin_1000.10240.16384.0_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.AAD.BrokerPlugin"",
		""FamilyName"": ""Microsoft.AAD.BrokerPlugin_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Connecteur d’applications"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Appconnector_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.Appconnector_1.3.3.0_neutral__8wekyb3d8bbwe\\images\\logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1,
		""Minor"": 3,
		""Build"": 3,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:52:00.9239944"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.Appconnector_1.3.3.0_neutral__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.Appconnector_1.3.3.0_neutral__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.Appconnector"",
		""FamilyName"": ""Microsoft.Appconnector_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Contacter le Support"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Windows.ContactSupport_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\ContactSupport_cw5n1h2txyewy\\Assets\\MediumTile.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16384,
		""MajorRevision"": 0,
		""MinorRevision"": 16384
	},
	""InstalledDate"": ""2015-08-22T20:42:41.2823231"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\ContactSupport_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Windows.ContactSupport_10.0.10240.16384_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Windows.ContactSupport"",
		""FamilyName"": ""Windows.ContactSupport_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Contacts"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.People_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.People_10.0.2840.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\PeopleMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 2840,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-22T09:01:16.1803478"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.People_10.0.2840.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.People_10.0.2840.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.People"",
		""FamilyName"": ""Microsoft.People_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Cortana"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Windows.Cortana_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.Windows.Cortana_cw5n1h2txyewy\\Assets\\Icons\\custom-Cortana\\MediumTile.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1,
		""Minor"": 4,
		""Build"": 8,
		""Revision"": 176,
		""MajorRevision"": 0,
		""MinorRevision"": 176
	},
	""InstalledDate"": ""2015-08-23T11:30:53.2988252"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.Windows.Cortana_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.Windows.Cortana_1.4.8.176_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.Windows.Cortana"",
		""FamilyName"": ""Microsoft.Windows.Cortana_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""DeviceSample"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\26a62aee-70f1-4257-9287-15a55f9f4417_86r3qr7hs9ttw"",
	""Icon"": ""D:\\OneDrive\\Documents\\Project\\C#\\iot-devices\\Samples\\DeviceSample\\bin\\x86\\Debug\\AppX\\Assets\\Square150x150Logo.scale-200.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 1,
		""Minor"": 0,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-09-26T20:53:02.9965594"",
	""InstalledLocation"": ""D:\\OneDrive\\Documents\\Project\\C#\\iot-devices\\Samples\\DeviceSample\\bin\\x86\\Debug\\AppX"",
	""Id"": {
		""FullName"": ""26a62aee-70f1-4257-9287-15a55f9f4417_1.0.0.0_x86__86r3qr7hs9ttw"",
		""Name"": ""26a62aee-70f1-4257-9287-15a55f9f4417"",
		""FamilyName"": ""26a62aee-70f1-4257-9287-15a55f9f4417_86r3qr7hs9ttw"",
		""PublisherName"": ""CN=onyx_"",
		""PublisherId"": ""86r3qr7hs9ttw""
	}
},
{
	""DisplayName"": ""Écran de verrouillage par défaut de Windows"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.LockApp_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.LockApp_cw5n1h2txyewy\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16384,
		""MajorRevision"": 0,
		""MinorRevision"": 16384
	},
	""InstalledDate"": ""2015-08-22T20:42:38.9072075"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.LockApp_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.LockApp_10.0.10240.16384_neutral__cw5n1h2txyewy"",
		""Name"": ""Microsoft.LockApp"",
		""FamilyName"": ""Microsoft.LockApp_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""E-mail et comptes"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.AccountsControl_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.AccountsControl_cw5n1h2txyewy\\assets\\Logo.Theme-Dark_Scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16384,
		""MajorRevision"": 0,
		""MinorRevision"": 16384
	},
	""InstalledDate"": ""2015-08-22T20:42:38.2821765"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.AccountsControl_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.AccountsControl_10.0.10240.16384_neutral__cw5n1h2txyewy"",
		""Name"": ""Microsoft.AccountsControl"",
		""FamilyName"": ""Microsoft.AccountsControl_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Enregistrement biométrique"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.BioEnrollment_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.BioEnrollment_cw5n1h2txyewy\\assets\\logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16384,
		""MajorRevision"": 0,
		""MinorRevision"": 16384
	},
	""InstalledDate"": ""2015-08-22T20:42:38.5790663"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.BioEnrollment_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.BioEnrollment_10.0.10240.16384_neutral__cw5n1h2txyewy"",
		""Name"": ""Microsoft.BioEnrollment"",
		""FamilyName"": ""Microsoft.BioEnrollment_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Enregistreur vocal"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsSoundRecorder_10.1510.13110.0_x64__8wekyb3d8bbwe\\Assets\\VoiceRecorderMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 10,
		""Minor"": 1510,
		""Build"": 13110,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-22T09:00:53.2937642"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsSoundRecorder_10.1510.13110.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsSoundRecorder_10.1510.13110.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsSoundRecorder"",
		""FamilyName"": ""Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Facebook"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Facebook.Facebook_8xx8rvfyw5nnt"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Facebook.Facebook_1.4.0.9_x64__8xx8rvfyw5nnt\\Assets\\Square150x150Logo.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 1,
		""Minor"": 4,
		""Build"": 0,
		""Revision"": 9,
		""MajorRevision"": 0,
		""MinorRevision"": 9
	},
	""InstalledDate"": ""2015-08-23T10:51:41.9774959"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Facebook.Facebook_1.4.0.9_x64__8xx8rvfyw5nnt"",
	""Id"": {
		""FullName"": ""Facebook.Facebook_1.4.0.9_x64__8xx8rvfyw5nnt"",
		""Name"": ""Facebook.Facebook"",
		""FamilyName"": ""Facebook.Facebook_8xx8rvfyw5nnt"",
		""PublisherName"": ""CN=6E08453F-9BA7-4311-999C-D22FBA2FB1B8"",
		""PublisherId"": ""8xx8rvfyw5nnt""
	}
},
{
	""DisplayName"": ""Films et TV"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.ZuneVideo_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.ZuneVideo_3.6.13821.0_x64__8wekyb3d8bbwe\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 3,
		""Minor"": 6,
		""Build"": 13821,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-22T15:14:13.3634195"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.ZuneVideo_3.6.13821.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.ZuneVideo_3.6.13821.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.ZuneVideo"",
		""FamilyName"": ""Microsoft.ZuneVideo_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Font Character Map"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\31335JonathanTiney.FontCharacterMap_mqsy45srtc6a6"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\31335JonathanTiney.FontCharacterMap_1.1.2.0_neutral_split.scale-100_mqsy45srtc6a6\\Assets\\Square150x150Logo.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 1,
		""Minor"": 1,
		""Build"": 2,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-06T23:38:06.1641695"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\31335JonathanTiney.FontCharacterMap_1.1.2.0_x64__mqsy45srtc6a6"",
	""Id"": {
		""FullName"": ""31335JonathanTiney.FontCharacterMap_1.1.2.0_x64__mqsy45srtc6a6"",
		""Name"": ""31335JonathanTiney.FontCharacterMap"",
		""FamilyName"": ""31335JonathanTiney.FontCharacterMap_mqsy45srtc6a6"",
		""PublisherName"": ""CN=51B2096B-8440-4018-B0B2-BD6CBAD312C6"",
		""PublisherId"": ""mqsy45srtc6a6""
	}
},
{
	""DisplayName"": ""Groove Musique"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.ZuneMusic_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.ZuneMusic_3.6.13281.0_x64__8wekyb3d8bbwe\\Images\\Tiles\\XBL_MUSIC_150x150_A.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 3,
		""Minor"": 6,
		""Build"": 13281,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-10T18:25:32.2295289"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.ZuneMusic_3.6.13281.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.ZuneMusic_3.6.13281.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.ZuneMusic"",
		""FamilyName"": ""Microsoft.ZuneMusic_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Hôte de l’expérience Windows Shell"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Windows.ShellExperienceHost_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\ShellExperienceHost_cw5n1h2txyewy\\Assets\\logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 10240,
		""Revision"": 16384,
		""MajorRevision"": 0,
		""MinorRevision"": 16384
	},
	""InstalledDate"": ""2015-08-22T20:42:40.4229063"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\ShellExperienceHost_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.Windows.ShellExperienceHost_10.0.10240.16384_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.Windows.ShellExperienceHost"",
		""FamilyName"": ""Microsoft.Windows.ShellExperienceHost_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Larousse illustré"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\LAROUSSE.Larousseillustr_jtdxq3tbdhmww"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\LAROUSSE.Larousseillustr_1.1.0.82_neutral__jtdxq3tbdhmww\\images\\logo150x150.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1,
		""Minor"": 1,
		""Build"": 0,
		""Revision"": 82,
		""MajorRevision"": 0,
		""MinorRevision"": 82
	},
	""InstalledDate"": ""2015-08-24T19:58:51.6941587"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\LAROUSSE.Larousseillustr_1.1.0.82_neutral__jtdxq3tbdhmww"",
	""Id"": {
		""FullName"": ""LAROUSSE.Larousseillustr_1.1.0.82_neutral__jtdxq3tbdhmww"",
		""Name"": ""LAROUSSE.Larousseillustr"",
		""FamilyName"": ""LAROUSSE.Larousseillustr_jtdxq3tbdhmww"",
		""PublisherName"": ""CN=7DF84004-E471-4D85-80C0-E60EB729A894"",
		""PublisherId"": ""jtdxq3tbdhmww""
	}
},
{
	""DisplayName"": ""Le Monde.fr"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\LeMonde.fr.LeMonde.fr_ygx8racfmy1da"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\LeMonde.fr.LeMonde.fr_3.3.1.0_neutral__ygx8racfmy1da\\images\\logos\\square150x150Tile.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 3,
		""Minor"": 3,
		""Build"": 1,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-23T10:53:59.1796439"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\LeMonde.fr.LeMonde.fr_3.3.1.0_neutral__ygx8racfmy1da"",
	""Id"": {
		""FullName"": ""LeMonde.fr.LeMonde.fr_3.3.1.0_neutral__ygx8racfmy1da"",
		""Name"": ""LeMonde.fr.LeMonde.fr"",
		""FamilyName"": ""LeMonde.fr.LeMonde.fr_ygx8racfmy1da"",
		""PublisherName"": ""CN=88343A3D-E8A6-485F-AFAF-B8890F7F078C"",
		""PublisherId"": ""ygx8racfmy1da""
	}
},
{
	""DisplayName"": ""Lecteur"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Reader_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.Reader_6.4.9926.17994_x64__8wekyb3d8bbwe\\Images\\ReaderTileLogo.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 6,
		""Minor"": 4,
		""Build"": 9926,
		""Revision"": 17994,
		""MajorRevision"": 0,
		""MinorRevision"": 17994
	},
	""InstalledDate"": ""2015-08-23T00:28:54.61078"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.Reader_6.4.9926.17994_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.Reader_6.4.9926.17994_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.Reader"",
		""FamilyName"": ""Microsoft.Reader_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Manga Bird"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\10769UpdatePixels.CloudMangaReader_jhqpz6nvs8dwt"",
	""Icon"": """",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 5,
		""Minor"": 4,
		""Build"": 0,
		""Revision"": 128,
		""MajorRevision"": 0,
		""MinorRevision"": 128
	},
	""InstalledDate"": ""2015-09-26T23:05:06.3378234"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\10769UpdatePixels.CloudMangaReader_5.4.0.128_x64__jhqpz6nvs8dwt"",
	""Id"": {
		""FullName"": ""10769UpdatePixels.CloudMangaReader_5.4.0.128_x64__jhqpz6nvs8dwt"",
		""Name"": ""10769UpdatePixels.CloudMangaReader"",
		""FamilyName"": ""10769UpdatePixels.CloudMangaReader_jhqpz6nvs8dwt"",
		""PublisherName"": ""CN=2A42E4D5-1C9E-4B86-8A6D-CD47894C29A9"",
		""PublisherId"": ""jhqpz6nvs8dwt""
	}
},
{
	""DisplayName"": ""Mes séries"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\50348RomainBeuque.Messries_rv1s9989qta2y"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\50348RomainBeuque.Messries_1.5.2.2_neutral__rv1s9989qta2y\\Assets\\150.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1,
		""Minor"": 5,
		""Build"": 2,
		""Revision"": 2,
		""MajorRevision"": 0,
		""MinorRevision"": 2
	},
	""InstalledDate"": ""2015-08-23T10:49:28.8318817"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\50348RomainBeuque.Messries_1.5.2.2_neutral__rv1s9989qta2y"",
	""Id"": {
		""FullName"": ""50348RomainBeuque.Messries_1.5.2.2_neutral__rv1s9989qta2y"",
		""Name"": ""50348RomainBeuque.Messries"",
		""FamilyName"": ""50348RomainBeuque.Messries_rv1s9989qta2y"",
		""PublisherName"": ""CN=035BBBF3-94FF-4359-BC5E-A8D29BEA86ED"",
		""PublisherId"": ""rv1s9989qta2y""
	}
},
{
	""DisplayName"": ""Météo"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.BingWeather_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.BingWeather_4.6.169.0_x86__8wekyb3d8bbwe\\Assets\\AppTiles\\Weather_TileMediumSquare.scale-100.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 4,
		""Minor"": 6,
		""Build"": 169,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-10T18:24:41.5422389"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.BingWeather_4.6.169.0_x86__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.BingWeather_4.6.169.0_x86__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.BingWeather"",
		""FamilyName"": ""Microsoft.BingWeather_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Microsoft Edge"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe\\Assets\\MicrosoftEdgeSquare150x150.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 20,
		""Minor"": 10240,
		""Build"": 16384,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:39.1884712"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.MicrosoftEdge_8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.MicrosoftEdge_20.10240.16384.0_neutral__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.MicrosoftEdge"",
		""FamilyName"": ""Microsoft.MicrosoftEdge_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""NoUIEntryPoints-DesignMode"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\c72aea99-db23-4f58-85a3-bced5c1a4e28_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Users\\onyx_\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\Designer\\ShadowCache\\2e4aedey.l43\\h3v3hixh.hfd\\Images\\XDesProc.Logo.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 1,
		""Minor"": 0,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-09-15T22:46:40.7817381"",
	""InstalledLocation"": null,
	""Id"": {
		""FullName"": ""c72aea99-db23-4f58-85a3-bced5c1a4e28_1.0.0.0_x86_NorthAmerica_8wekyb3d8bbwe"",
		""Name"": ""c72aea99-db23-4f58-85a3-bced5c1a4e28"",
		""FamilyName"": ""c72aea99-db23-4f58-85a3-bced5c1a4e28_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""NoUIEntryPoints-DesignMode"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\0599ed46-ea43-44bd-aa29-194966ba45a2_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Users\\onyx_\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\Designer\\ShadowCache\\2ucff0cr.val\\m5wwiete.kpd\\Images\\XDesProc.Logo.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 1,
		""Minor"": 0,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-09-16T00:43:24.4825123"",
	""InstalledLocation"": null,
	""Id"": {
		""FullName"": ""0599ed46-ea43-44bd-aa29-194966ba45a2_1.0.0.0_x86_NorthAmerica_8wekyb3d8bbwe"",
		""Name"": ""0599ed46-ea43-44bd-aa29-194966ba45a2"",
		""FamilyName"": ""0599ed46-ea43-44bd-aa29-194966ba45a2_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""NoUIEntryPoints-DesignMode"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\e250c0f5-86c7-4ddc-8f24-1dc2d720a894_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Users\\onyx_\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\Designer\\ShadowCache\\1be2kyyb.wfe\\imhwpu2r.vwy\\Images\\XDesProc.Logo.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 1,
		""Minor"": 0,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-09-26T20:13:59.9275296"",
	""InstalledLocation"": null,
	""Id"": {
		""FullName"": ""e250c0f5-86c7-4ddc-8f24-1dc2d720a894_1.0.0.0_x86_NorthAmerica_8wekyb3d8bbwe"",
		""Name"": ""e250c0f5-86c7-4ddc-8f24-1dc2d720a894"",
		""FamilyName"": ""e250c0f5-86c7-4ddc-8f24-1dc2d720a894_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""NoUIEntryPoints-DesignMode"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\80870252-a28e-43d1-9b68-a3a8d2e67e3f_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Users\\onyx_\\AppData\\Local\\Microsoft\\VisualStudio\\14.0\\Designer\\ShadowCache\\rbc2p3ii.by0\\y3rk515z.zup\\Images\\XDesProc.Logo.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 1,
		""Minor"": 0,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-12T21:34:34.8741782"",
	""InstalledLocation"": null,
	""Id"": {
		""FullName"": ""80870252-a28e-43d1-9b68-a3a8d2e67e3f_1.0.0.0_x86_NorthAmerica_8wekyb3d8bbwe"",
		""Name"": ""80870252-a28e-43d1-9b68-a3a8d2e67e3f"",
		""FamilyName"": ""80870252-a28e-43d1-9b68-a3a8d2e67e3f_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""OneNote"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Office.OneNote_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.Office.OneNote_17.6228.10071.0_x64__8wekyb3d8bbwe\\images\\OneNoteMediumTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 17,
		""Minor"": 6228,
		""Build"": 10071,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-28T22:49:19.6222932"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.Office.OneNote_17.6228.10071.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.Office.OneNote_17.6228.10071.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.Office.OneNote"",
		""FamilyName"": ""Microsoft.Office.OneNote_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Photos"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Windows.Photos_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.Windows.Photos_15.1026.13580.0_x64__8wekyb3d8bbwe\\Assets\\PhotosMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 15,
		""Minor"": 1026,
		""Build"": 13580,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-27T19:34:37.8398844"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.Windows.Photos_15.1026.13580.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.Windows.Photos_15.1026.13580.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.Windows.Photos"",
		""FamilyName"": ""Microsoft.Windows.Photos_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""PurchaseDialog"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Windows.PurchaseDialog_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\PurchaseDialog\\Assets\\splashscreen.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 6,
		""Minor"": 2,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:41.938606"",
	""InstalledLocation"": ""C:\\Windows\\PurchaseDialog"",
	""Id"": {
		""FullName"": ""Windows.PurchaseDialog_6.2.0.0_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Windows.PurchaseDialog"",
		""FamilyName"": ""Windows.PurchaseDialog_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Remote Desktop Preview"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.MicrosoftRemoteDesktopPreview_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.MicrosoftRemoteDesktopPreview_10.0.825.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\AppNameMedTile.scale-100.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 10,
		""Minor"": 0,
		""Build"": 825,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-28T22:49:10.6374897"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.MicrosoftRemoteDesktopPreview_10.0.825.0_x86__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.MicrosoftRemoteDesktopPreview_10.0.825.0_x86__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.MicrosoftRemoteDesktopPreview"",
		""FamilyName"": ""Microsoft.MicrosoftRemoteDesktopPreview_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Restrictions de famille Microsoft"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.Windows.ParentalControls_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\ParentalControls_cw5n1h2txyewy\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1000,
		""Minor"": 10240,
		""Build"": 16384,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:40.2197716"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\ParentalControls_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.Windows.ParentalControls_1000.10240.16384.0_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.Windows.ParentalControls"",
		""FamilyName"": ""Microsoft.Windows.ParentalControls_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Scanneur"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsScan_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsScan_6.3.9654.17133_x64__8wekyb3d8bbwe\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 6,
		""Minor"": 3,
		""Build"": 9654,
		""Revision"": 17133,
		""MajorRevision"": 0,
		""MinorRevision"": 17133
	},
	""InstalledDate"": ""2015-08-23T11:17:17.121418"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsScan_6.3.9654.17133_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsScan_6.3.9654.17133_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsScan"",
		""FamilyName"": ""Microsoft.WindowsScan_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Télé 7 Programme TV"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\LAGARDEREACTIVEDIGITALSAS.Tl7ProgrammeTV_ya1j1agkxsss6"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\LAGARDEREACTIVEDIGITALSAS.Tl7ProgrammeTV_1.6.0.0_x64__ya1j1agkxsss6\\images\\logo.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 1,
		""Minor"": 6,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-23T10:53:15.6703023"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\LAGARDEREACTIVEDIGITALSAS.Tl7ProgrammeTV_1.6.0.0_x64__ya1j1agkxsss6"",
	""Id"": {
		""FullName"": ""LAGARDEREACTIVEDIGITALSAS.Tl7ProgrammeTV_1.6.0.0_x64__ya1j1agkxsss6"",
		""Name"": ""LAGARDEREACTIVEDIGITALSAS.Tl7ProgrammeTV"",
		""FamilyName"": ""LAGARDEREACTIVEDIGITALSAS.Tl7ProgrammeTV_ya1j1agkxsss6"",
		""PublisherName"": ""CN=E4572883-B02B-4322-900B-396D696F43AD"",
		""PublisherId"": ""ya1j1agkxsss6""
	}
},
{
	""DisplayName"": ""Tubecast for YouTube"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Webrox.Tubecast_0dmhevbabqz82"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Webrox.Tubecast_1.5.0.8_neutral__0dmhevbabqz82\\Assets\\WinRT-Square150.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1,
		""Minor"": 5,
		""Build"": 0,
		""Revision"": 8,
		""MajorRevision"": 0,
		""MinorRevision"": 8
	},
	""InstalledDate"": ""2015-10-12T19:27:00.4839844"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Webrox.Tubecast_1.5.0.8_neutral__0dmhevbabqz82"",
	""Id"": {
		""FullName"": ""Webrox.Tubecast_1.5.0.8_neutral__0dmhevbabqz82"",
		""Name"": ""Webrox.Tubecast"",
		""FamilyName"": ""Webrox.Tubecast_0dmhevbabqz82"",
		""PublisherName"": ""CN=FF3725B6-D88A-43A0-9F6E-584F10D5C628"",
		""PublisherId"": ""0dmhevbabqz82""
	}
},
{
	""DisplayName"": ""TV d'Orange"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\OrangeFrance.TVdOrange_3nekra66ya1hy"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\OrangeFrance.TVdOrange_2.1.3.19410_x64__3nekra66ya1hy\\Resources\\Assets\\OTVPW8_Logo.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 2,
		""Minor"": 1,
		""Build"": 3,
		""Revision"": 19410,
		""MajorRevision"": 0,
		""MinorRevision"": 19410
	},
	""InstalledDate"": ""2015-08-23T10:52:44.4875999"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\OrangeFrance.TVdOrange_2.1.3.19410_x64__3nekra66ya1hy"",
	""Id"": {
		""FullName"": ""OrangeFrance.TVdOrange_2.1.3.19410_x64__3nekra66ya1hy"",
		""Name"": ""OrangeFrance.TVdOrange"",
		""FamilyName"": ""OrangeFrance.TVdOrange_3nekra66ya1hy"",
		""PublisherName"": ""CN=DEF9A6EA-F3C1-49BD-890F-599C432EB78B"",
		""PublisherId"": ""3nekra66ya1hy""
	}
},
{
	""DisplayName"": ""VLC for Windows Store"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\VideoLAN.VLCforWindows8_paz6r1rewnh0a"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\VideoLAN.VLCforWindows8_1.7.0.0_x86__paz6r1rewnh0a\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""X86"",
	""Version"": {
		""Major"": 1,
		""Minor"": 7,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-10T18:25:51.7395805"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\VideoLAN.VLCforWindows8_1.7.0.0_x86__paz6r1rewnh0a"",
	""Id"": {
		""FullName"": ""VideoLAN.VLCforWindows8_1.7.0.0_x86__paz6r1rewnh0a"",
		""Name"": ""VideoLAN.VLCforWindows8"",
		""FamilyName"": ""VideoLAN.VLCforWindows8_paz6r1rewnh0a"",
		""PublisherName"": ""CN=716F2E5E-A03A-486B-BC67-9B18474B9D51"",
		""PublisherId"": ""paz6r1rewnh0a""
	}
},
{
	""DisplayName"": ""Voyages-SNCF"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\www.voyages-sncf.com.Voyages-SNCF_ap45zm8wnz8w4"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\www.voyages-sncf.com.Voyages-SNCF_23.0.0.0_neutral__ap45zm8wnz8w4\\Assets\\Logo.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 23,
		""Minor"": 0,
		""Build"": 0,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-09-10T23:53:31.4897922"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\www.voyages-sncf.com.Voyages-SNCF_23.0.0.0_neutral__ap45zm8wnz8w4"",
	""Id"": {
		""FullName"": ""www.voyages-sncf.com.Voyages-SNCF_23.0.0.0_neutral__ap45zm8wnz8w4"",
		""Name"": ""www.voyages-sncf.com.Voyages-SNCF"",
		""FamilyName"": ""www.voyages-sncf.com.Voyages-SNCF_ap45zm8wnz8w4"",
		""PublisherName"": ""CN=05F5FF70-390F-4314-9D42-5567AFB089EF"",
		""PublisherId"": ""ap45zm8wnz8w4""
	}
},
{
	""DisplayName"": ""Windows Store"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.WindowsStore_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsStore_2015.10.5.0_neutral_split.scale-100_8wekyb3d8bbwe\\Assets\\StoreMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 2015,
		""Minor"": 10,
		""Build"": 5,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-10T18:24:17.4471683"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.WindowsStore_2015.10.5.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.WindowsStore_2015.10.5.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.WindowsStore"",
		""FamilyName"": ""Microsoft.WindowsStore_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Xbox"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.XboxApp_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.XboxApp_9.9.28033.0_x64__8wekyb3d8bbwe\\Assets\\GamesXboxHubMedTile.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 9,
		""Minor"": 9,
		""Build"": 28033,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-10-04T21:10:35.0736359"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.XboxApp_9.9.28033.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.XboxApp_9.9.28033.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.XboxApp"",
		""FamilyName"": ""Microsoft.XboxApp_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Xbox 360 SmartGlass"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.XboxCompanion_8wekyb3d8bbwe"",
	""Icon"": ""C:\\Program Files\\WindowsApps\\Microsoft.XboxCompanion_1.4.3.0_x64__8wekyb3d8bbwe\\Images\\Tiles\\XBL_COMP_150x150_A.scale-100.png"",
	""Architecture"": ""X64"",
	""Version"": {
		""Major"": 1,
		""Minor"": 4,
		""Build"": 3,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-23T10:53:57.3886322"",
	""InstalledLocation"": ""C:\\Program Files\\WindowsApps\\Microsoft.XboxCompanion_1.4.3.0_x64__8wekyb3d8bbwe"",
	""Id"": {
		""FullName"": ""Microsoft.XboxCompanion_1.4.3.0_x64__8wekyb3d8bbwe"",
		""Name"": ""Microsoft.XboxCompanion"",
		""FamilyName"": ""Microsoft.XboxCompanion_8wekyb3d8bbwe"",
		""PublisherName"": ""CN=Microsoft Corporation, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""8wekyb3d8bbwe""
	}
},
{
	""DisplayName"": ""Xbox Game UI"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.XboxGameCallableUI_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.XboxGameCallableUI_cw5n1h2txyewy\\Assets\\Logo.scale-100.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1000,
		""Minor"": 10240,
		""Build"": 16384,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:40.8604273"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.XboxGameCallableUI_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.XboxGameCallableUI_1000.10240.16384.0_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.XboxGameCallableUI"",
		""FamilyName"": ""Microsoft.XboxGameCallableUI_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
},
{
	""DisplayName"": ""Xbox Identity Provider"",
	""AppDataFolderExists"": true,
	""AppDataFolderPath"": ""C:\\Users\\onyx_\\AppData\\Local\\Packages\\Microsoft.XboxIdentityProvider_cw5n1h2txyewy"",
	""Icon"": ""C:\\Windows\\SystemApps\\Microsoft.XboxIdentityProvider_cw5n1h2txyewy\\Assets\\Logo.png"",
	""Architecture"": ""Neutral"",
	""Version"": {
		""Major"": 1000,
		""Minor"": 10240,
		""Build"": 16384,
		""Revision"": 0,
		""MajorRevision"": 0,
		""MinorRevision"": 0
	},
	""InstalledDate"": ""2015-08-22T20:42:41.079188"",
	""InstalledLocation"": ""C:\\Windows\\SystemApps\\Microsoft.XboxIdentityProvider_cw5n1h2txyewy"",
	""Id"": {
		""FullName"": ""Microsoft.XboxIdentityProvider_1000.10240.16384.0_neutral_neutral_cw5n1h2txyewy"",
		""Name"": ""Microsoft.XboxIdentityProvider"",
		""FamilyName"": ""Microsoft.XboxIdentityProvider_cw5n1h2txyewy"",
		""PublisherName"": ""CN=Microsoft Windows, O=Microsoft Corporation, L=Redmond, S=Washington, C=US"",
		""PublisherId"": ""cw5n1h2txyewy""
	}
}]");
        }
    }
}
