﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using GSPMemFixTools.ViewModels;

namespace GSPMemFixTools
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel _vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
            // Init using my local folders for convenience

       // Step 1 - Interfaces
            _vm.InterfacePath = @"C:\Source Control\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient.Contracts";
       // Step 2 - Imports 
            
            // 1. // _vm.RiaClientPath = @"C:\Source Control\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient";
            // 2. // _vm.RiaClientPath = @"C:\Source Control\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient.Framework"; 
            // 3. // _vm.RiaClientPath = @"C:\Source Control\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient.ViewModels"; 
            //_vm.RiaClientPath = @"C:\Source Control\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient.Services"; 
            //_vm.RiaClientPath = @"C:\Users\mandersson\Documents\GitHub\GSPMemFixTool\GSPMemFixTools\bin\Debug\TestExport"; 
        // Step 3 - Exports  
            //_vm.RiaClientPath = @"C:\Users\Mathias\Documents\Visual Studio 2013\Projects\GSPMemFixTools\GSPMemFixTools\bin\Debug\TestExport"; 
            //_vm.RiaClientPath = @"D:\Stratiteq\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient"; 
        // Step 4 - VM Exports
            //_vm.RiaClientPath = @"C:\Users\Mathias\Documents\Visual Studio 2013\Projects\GSPMemFixTools\GSPMemFixTools\bin\Debug\TestVmExport"; 
            _vm.RiaClientPath = @"D:\Stratiteq\TFS\Securitas GSP\MemLeak\Securitas.GSP.RiaClient"; 
            _vm.SimulateImport = true;
            _vm.SimulateExport = true;
            _vm.SimulateVmExport = true;
        }

        private void BrowseInterfaceFolderButton_Click(object sender, RoutedEventArgs e)
        {
            // Open folder browser
            _vm.InterfacePath = GetFolderFromDialog();
        }

        private void ReadServiceInterfacesButton_Click(object sender, RoutedEventArgs e)
        {
            // Scan folder and list all interfaces
            _vm.ScanInterfaceFolder();
        }

        private void BrowseRiaClientFolderButton_Click(object sender, RoutedEventArgs e)
        {
            // Open folder browser
            _vm.RiaClientPath = GetFolderFromDialog();
        }

        private void ReplaceImportButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.ReplaceImports();
        }

        #region Utilties
        private string GetFolderFromDialog()
        {
            var value = String.Empty;
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                value = dialog.SelectedPath;
            }
            return value;
        }
        #endregion Utilities

        private void ReplaceExportButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.ReplaceExports();    
        }

        private void ReplaceVmExportButton_Click(object sender, RoutedEventArgs e)
        {
            _vm.ReplaceVmExports(); 
        }
    }
}
