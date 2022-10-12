using Less3_hw.Models;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;
using System.IO;
using Less3_hw.Extensions;
using System.Linq;
using Nito.AsyncEx;

namespace Less3_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Verificator verificator;
        public ObservableCollection<string> dict { get; set; } = new ObservableCollection<string>();
        CancellationTokenSource cancellationTokenSource;
        AsyncManualResetEvent asyncManualResetEvent = new AsyncManualResetEvent(false);
        string moveToFolder = "C:\\TMP";
        public MainWindow()
        {
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            dict.CollectionChanged += Dict_CollectionChanged;
            tbMoveTOFolder.Text = moveToFolder;
            spDict.DataContext = this;

        }

        private void Dict_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (dict.Count > 0)
            {
                btnStart.IsEnabled = true;
                btnClearDict.IsEnabled = true;
                btnDeleteFromDict.IsEnabled = true;
                btnSaveDict.IsEnabled = true;
            }
            else
            {
                btnStart.IsEnabled = false;
                btnClearDict.IsEnabled = false;
                btnDeleteFromDict.IsEnabled = false;
                btnSaveDict.IsEnabled = false;
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if (verificator != null)
            {
                verificator.report.Save();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog browserDialog = new VistaFolderBrowserDialog();
            browserDialog.Multiselect = false;
            if(browserDialog.ShowDialog() == true)
            {
                tbMoveTOFolder.Text = moveToFolder = browserDialog.SelectedPath;
            }
        }

        private void btnLoadDict_Click(object sender, RoutedEventArgs e)
        {
            VistaOpenFileDialog fileDialog = new VistaOpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Filter = "txt files (*.txt)|*.txt";
            if(fileDialog.ShowDialog() == true)
            {
                dict.Clear();
                using (StreamReader reader = new StreamReader(fileDialog.FileName))
                {
                    string line;
                    while ((line=reader.ReadLine()) != null)
                    {
                        dict.Add(line);
                    }
                }
                ;
            }
        }

        private void btnClearDict_Click(object sender, RoutedEventArgs e)
        {
            dict.Clear();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource = new CancellationTokenSource();
            verificator = new Verificator(dict, moveToFolder);
            spCurrentDirs.DataContext = verificator;
            spCurrentFiles.DataContext = verificator;
            btnStop.IsEnabled = true;
            btnPause.IsEnabled = true;
            btnStart.IsEnabled = false;
            asyncManualResetEvent.Set();
            Task.Run(() =>
            {
                verificator.Start(cancellationTokenSource, asyncManualResetEvent);
            });
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
            verificator.report.Save();
            spWrongDirs.DataContext = verificator;
            spWrongFiles.DataContext = verificator;
            spReportList.DataContext = verificator.report;
            spTopWords.DataContext = verificator.report;
            btnStop.IsEnabled = false;
            btnPause.IsEnabled = false;
            btnStart.IsEnabled = true;
            asyncManualResetEvent.Set();
            btnPause.Content = "Pause";
            ;
        }

        private void btnDeleteFromDict_Click(object sender, RoutedEventArgs e)
        {
            if (lbDict.SelectedIndex != -1)
            {
                dict.RemoveAt(lbDict.SelectedIndex);
            }
        }

        private void btnSaveDict_Click(object sender, RoutedEventArgs e)
        {
            VistaSaveFileDialog fileDialog = new VistaSaveFileDialog();
            fileDialog.DefaultExt = "txt";
            fileDialog.Filter = "Text files (*.txt)|*.txt";
            if (fileDialog.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(fileDialog.FileName, false, System.Text.Encoding.Default))
                {
                    foreach (var item in dict)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
        }

        private void btnAddToDict_Click(object sender, RoutedEventArgs e)
        {
            if (tbAddToDict.Text.Length > 0)
            {
                var words = tbAddToDict.Text.Split(',').Select(s => s.Trim()).ToList();
                dict.AddRange(words);
                tbAddToDict.Text = "";
            }
        }
        public void RunInConsole(string dictFile, string moveToPath)
        {
            using (StreamReader reader = new StreamReader((dictFile.Length >0)? dictFile : "dict.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    dict.Add(line);
                }
            }
            cancellationTokenSource = new CancellationTokenSource();
            verificator = new Verificator(dict, (moveToPath.Length >0)? moveToPath : moveToFolder);
            asyncManualResetEvent.Set();
            verificator.Start(cancellationTokenSource, asyncManualResetEvent);
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (btnPause.Content == "Pause")
            {
                btnPause.Content = "Continue";
                asyncManualResetEvent.Reset();
            }
            else
            {
                btnPause.Content = "Pause";
                asyncManualResetEvent.Set();
            }
        }
    }
}
