using CrystalDiskInfoDotnet.CheckDiskInfos;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace DiskInfoAdvance.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            CrystalDiskInfoDotnetLoad.ExtractFullInfos(out var vals);

            foreach (var s in vals)
            {
                mylistview.Items.Add(Environment.NewLine);
                mylistview.Items.Add(s.Model);

                mylistview.Items.Add("Health " + s.Life);
                mylistview.Items.Add("Temp " + s.Temperature);
                mylistview.Items.Add("firmwareR " + s.FirmwareRev);
                mylistview.Items.Add("SerialNumber " + s.SerialNumber);
                mylistview.Items.Add("SerialNumberReverse " + s.SerialNumberReverse);
                mylistview.Items.Add("Major " + s.Major);
            }
        }
    }
}
