using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Less3_hw
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            using (var sem = new Semaphore(1, 1, "Less3_hw"))
            {
                if (sem.WaitOne(0))
                {
                    MainWindow window = new MainWindow();
                    if (e.Args.Length > 0)
                    {
                        if (e.Args[0] == "/h")
                        {
                            if (e.Args.Length == 1) window.RunInConsole("", "");
                            else if (e.Args.Length == 2) window.RunInConsole(e.Args[1], "");
                            else window.RunInConsole(e.Args[1], e.Args[2]);
                        }
                    }
                    else
                    {
                        window.Show();
                    }
                }
                else
                {
                    Console.WriteLine("Application can be running in one instanse!");
                }
            }
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
        }
    }
}
