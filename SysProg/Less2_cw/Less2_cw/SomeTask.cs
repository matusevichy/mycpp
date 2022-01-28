using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Less2_cw
{
    public class SomeTask: INotifyPropertyChanged
    {
        public event Action<SomeTask> StartedWork;
        public event Action<SomeTask> StartedWait;
        public event Action<SomeTask> Finished;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        
        static Semaphore semaphore = new Semaphore(3,3);
        static Random random = new Random();
        Task task;
        private int progress;

        public int Progress
        {
            get { return progress; }
            set 
            { 
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public int? Id => task.Id;

        public SomeTask()
        {
            task = new Task(() =>
              {
                  StartedWait?.Invoke(this);
                  semaphore.WaitOne();
                  StartedWork?.Invoke(this);
                  while(Progress < 100)
                  {
                      Progress++;
                      Thread.Sleep(random.Next(30, 50));
                  }
                  semaphore.Release();
                  Finished?.Invoke(this);
              });
        }

        public void Start()
        {
            task.Start();
        }
    }
}
