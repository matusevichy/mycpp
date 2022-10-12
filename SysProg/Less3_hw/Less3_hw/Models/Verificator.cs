using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Less3_hw.Models
{
    public class Verificator
    {
        ObservableCollection<string> dict;
        string pathForMove;
        public Report report = new Report();
        public ObservableCollection<string> wrongDirectories { get; private set; } = new ObservableCollection<string>();
        public ObservableCollection<string> wrongFiles { get; private set; } = new ObservableCollection<string>();

        public ObservableCollection<string> currentDirs { get; private set; } = new ObservableCollection<string>();
        public ObservableCollection<string> currentFiles { get; private set; } = new ObservableCollection<string>();
        public Verificator(ObservableCollection<string> dict, string pathForMove)
        {
            this.dict = dict;
            this.pathForMove = pathForMove;
            DirectoryInfo directory = new DirectoryInfo(pathForMove);
            if (!directory.Exists) Directory.CreateDirectory(pathForMove);
        }

        bool CheckFile(string path)
        {
            string text, newText;
            int replaceCount = 0;
            Dictionary<string, int> replacedWord = new Dictionary<string, int>();
            try
            {
                using (StreamReader reader = new StreamReader(path, Encoding.Default)) 
                {
                    text = newText = reader.ReadToEnd();
                }
                foreach (var item in dict)
                {
                    int count = 0;
                    Regex regex = new Regex(item);
                    newText = regex.Replace(newText, t => { count++; return "*******"; });
                    if (count>0)
                    {
                        replacedWord.Add(item, count);
                    }
                    replaceCount += count;
                }
                if (replaceCount > 0)
                {
                    FileInfo fileInfo = new FileInfo(path);
                    //Закомментировано сознательно, что бы файли не переносились при отладке и тестовых запусках!!!
                    //var tmpIRO = fileInfo.IsReadOnly;
                    //fileInfo.IsReadOnly = false;
                    //File.Move(path, pathForMove + "\\" + Path.GetFileName(path));
                    //using (StreamWriter writer1 = new StreamWriter(path, false, Encoding.Default))
                    //{
                    //    writer1.WriteLine(newText);
                    //}
                    //fileInfo.IsReadOnly = tmpIRO;
                    report.AddItem(new ReportItem() { Name = Path.GetFileName(path), Path = path, ReplaceCount = replaceCount, ReplacedWord = replacedWord, Size = fileInfo.Length });
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                wrongFiles.Add(path);
                return false;
            }
        }
        List<string> GetDevices()
        {
            List<string> devices = new List<string>();
            var driveInfo = DriveInfo.GetDrives();
            foreach(var drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
                {
                    devices.Add(drive.Name);
                }
            }
            return devices;
        }
        async Task FindFiles(string path, CancellationToken cancellationToken, AsyncManualResetEvent asyncManualResetEvent)
        {
            var directories = Directory.EnumerateDirectories(path);
            if (!asyncManualResetEvent.IsSet) await asyncManualResetEvent.WaitAsync();
            foreach (var dir in directories)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                try
                {
                    if(dir != pathForMove)
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() => currentDirs.Add(dir)), null);
                        await FindFiles(dir, cancellationToken, asyncManualResetEvent);
                    }
                }
                catch
                {
                    wrongDirectories.Add(dir);
                }
                finally
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => currentDirs.Remove(dir)) ,null);
                }
            }
            var files = Directory.EnumerateFiles(path, "*.txt");
            foreach (var file in files)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    break;
                }
                try
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => currentFiles.Add(file)), null);
                    Trace.WriteLine(file);
                    CheckFile(file);
                }
                catch
                {
                    wrongFiles.Add(file);
                }
                finally
                {
                    Application.Current.Dispatcher.BeginInvoke(new Action(() => currentFiles.Remove(file)), null);
                }
            }
        }
        public async Task Start(CancellationTokenSource cancellationTokenSource, AsyncManualResetEvent asyncManualResetEvent)
        {
            var devices = GetDevices();
            foreach (var device in devices)
            {
                await FindFiles(device, cancellationTokenSource.Token, asyncManualResetEvent);
            }
            report.Save();
            ;
        }
    }
}
