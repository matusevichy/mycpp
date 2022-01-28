using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Less2_cw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            WorkedSomeTasks workedSomeTasks = new WorkedSomeTasks();
            Random random = new Random();
            int maxTasks = 30;

            InitializeComponent();
            DataContext = workedSomeTasks;
            Task.Run(() =>
            {
                while (maxTasks > 0)
                {
                    SomeTask someTask = new SomeTask();
                    workedSomeTasks.AddTask(someTask);
                    someTask.Start();
                    Thread.Sleep(random.Next(300, 500));
                    maxTasks--;
                }
            });
        }
    }
}
