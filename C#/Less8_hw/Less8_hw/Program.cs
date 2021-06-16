using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less8_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer { Interval = 1000 };
            timer.Elapsed += Timer_Tick;
            timer.Start();

            //var result = MessageBox.Show("SOme text", "SOme title", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            //switch (result)
            //{
            //    case DialogResult.None:
            //        break;
            //    case DialogResult.OK:
            //        break;
            //    case DialogResult.Cancel:
            //        Console.WriteLine("Cancel");
            //        break;
            //    case DialogResult.Abort:
            //        break;
            //    case DialogResult.Retry:
            //        break;
            //    case DialogResult.Ignore:
            //        break;
            //    case DialogResult.Yes:
            //        Console.WriteLine("Yes");
            //        break;
            //    case DialogResult.No:
            //        Console.WriteLine("No");
            //        break;
            //}
            Console.Read();
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            // Timer timer = sender as Timer;
            Console.WriteLine("Tick");
        }
    }
}
