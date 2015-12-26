using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
using Windows.ApplicationModel;
using Windows.Storage;

namespace Win10AppBackup
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RadioButton selectedButton;

        public MainWindow()
        {
            InitializeComponent();
            this.frame.Content = selectedButton?.Tag;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            selectedButton = sender as RadioButton;
            if (this.frame != null)
            {
                this.frame.Content = selectedButton?.Tag;
            }
        }
    }
}
