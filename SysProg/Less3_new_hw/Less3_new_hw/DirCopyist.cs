using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyFile 
{
    internal class DirCopyist : INotifyPropertyChanged
    {
        int countFact = 0;

        private readonly SynchronizationContext context = SynchronizationContext.Current;
        public int CountFact
        {
            get { return countFact; }
            set
            {
                countFact = value;
                OnPropertyChanged("CountFact");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void Start(string dirFrom, string dirTo, CancellationTokenSource cancellationTokenSource)
        {
            CountFact = 0;
            Copy(dirFrom, dirTo, cancellationTokenSource.Token);
        }
        void Copy(string pathFrom, string pathTo, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            try
            {
                var dirs = Directory.GetDirectories(pathFrom);
                foreach (var dir in dirs)
                {
                    context.Post(delegate { CountFact++; } , null);
                    DirectoryInfo directory = new DirectoryInfo(dir);
                    var newPath = Path.Combine(pathTo, directory.Name);
                    if (!Directory.Exists(newPath))
                    {
                        var newDir = Directory.CreateDirectory(newPath);
                        newDir.Attributes = directory.Attributes;
                    }
                    Copy(dir, newPath, cancellationToken);
                }
                CopyFiles(pathFrom, pathTo);
                ;
            }
            catch (Exception ex)
            {
            }
        }
        void CopyFiles(string pathFrom, string pathTo)
        {
            var files = Directory.GetFiles(pathFrom);
            foreach (var file in files)
            {
                context.Post(delegate { CountFact++; }, null);
                FileInfo fileInfo = new FileInfo(file);
                var newPath = Path.Combine(pathTo, fileInfo.Name);
                var input = new FileStream(file, FileMode.Open, FileAccess.Read);
                var output = new FileStream(newPath, FileMode.Create, FileAccess.Write);
                Read();

                void Read()
                {
                    byte[] buffer = new byte[1024];
                    int count = 0;
                    input.BeginRead(buffer, 0, buffer.Length, ar =>
                    {
                        count = input.EndRead(ar);
                        Write(buffer, count);
                    }, null);
                }

                void Write(byte[] buffer, int count)
                {
                    if (count <= 0)
                    {
                        input.Close();
                        output.Close();
                        File.SetAttributes(newPath, File.GetAttributes(file));
                        return;
                    }
                    output.BeginWrite(buffer, 0, count, ar =>
                    {
                        output.EndWrite(ar);
                        Read();
                    }, null);
                }
            }

        }
    }
}
