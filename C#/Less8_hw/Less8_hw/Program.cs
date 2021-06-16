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
//            System.Timers.Timer timer = new System.Timers.Timer { Interval = 1000 };
//            timer.Elapsed += Timer_Tick;
//            timer.Start();

            App app = new App(10);
            app.Start();
        }

        //private static void Timer_Tick(object sender, EventArgs e)
        //{
        //    // Timer timer = sender as Timer;
        //    Console.WriteLine("Tick");
        //}
    }
}
