using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirComp 
{
    internal class DirComparer : INotifyPropertyChanged
    {
        int countFact = 0;
        public int CreatedDirs { get; set; } = 0;
        public int CopiedFeles { get; set; } = 0;

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

        public async Task Start(string dirFrom, string dirTo, CancellationTokenSource cancellationTokenSource)
        {
            CountFact = 0;
            CreatedDirs = 0;
            CopiedFeles = 0;
            await Compare(dirFrom, dirTo, cancellationTokenSource.Token);
        }
        async Task Compare(string pathFrom, string pathTo, CancellationToken cancellationToken)
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
                        CreatedDirs++;
                        var newDir = Directory.CreateDirectory(newPath);
                        newDir.Attributes = directory.Attributes;
                    }
                    await Compare(dir, newPath, cancellationToken);
                }
                await CompareFiles(pathFrom, pathTo);
                ;
            }
            catch (Exception ex)
            {
            }
        }
        async Task CompareFiles(string pathFrom, string pathTo)
        {
            var files = Directory.GetFiles(pathFrom);
            foreach (var file in files)
            {
                context.Post(delegate { CountFact++; }, null);
                FileInfo fileInfo = new FileInfo(file);
                var newPath = Path.Combine(pathTo, fileInfo.Name);
                if (!File.Exists(newPath))
                {
                    CopiedFeles++;
                    using var readStream = new FileStream(file, FileMode.Open, FileAccess.Read);
                    using var writeStream = new FileStream(newPath, FileMode.Create, FileAccess.Write);
                    await readStream.CopyToAsync(writeStream);
                }

            }

        }
    }
}
