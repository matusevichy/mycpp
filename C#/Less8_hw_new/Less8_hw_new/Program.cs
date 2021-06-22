using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Less8_hw_new
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App(10);
            app.Start();
            Console.ReadKey();
        }

    }
}
