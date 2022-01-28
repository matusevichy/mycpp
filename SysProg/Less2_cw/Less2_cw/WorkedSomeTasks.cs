using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Less2_cw
{
    class WorkedSomeTasks
    {
        public ObservableCollection<SomeTask> Tasks { get; set; } = new ObservableCollection<SomeTask>();
        public ObservableCollection<SomeTask> WorkedTasks { get; set; } = new ObservableCollection<SomeTask>();
        public ObservableCollection<SomeTask> WaitingTasks { get; set; } = new ObservableCollection<SomeTask>();
        public ObservableCollection<SomeTask> FinishedTasks { get; set; } = new ObservableCollection<SomeTask>();

        public void AddTask(SomeTask task)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => Tasks.Add(task)), null);
            task.StartedWait += Task_StartedWait;
            task.StartedWork += Task_StartedWork;
            task.Finished += Task_Finished;
        }

        private void Task_Finished(SomeTask obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => WorkedTasks.Remove(obj)), null);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => FinishedTasks.Add(obj)), null);
        }

        private void Task_StartedWork(SomeTask obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => WaitingTasks.Remove(obj)), null);
            Application.Current.Dispatcher.BeginInvoke(new Action(() => WorkedTasks.Add(obj)), null);
        }

        private void Task_StartedWait(SomeTask obj)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => WaitingTasks.Add(obj)), null);
        }
    }
}
