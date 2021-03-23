using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a, b, c, count_h, count_w, s;
            Console.WriteLine("Input rectagle height:");
            a = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Input rectangle width:");
            b = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Input square size:");
            c = Convert.ToUInt32(Console.ReadLine());
            if (c>a || c>b)
            {
                Console.WriteLine("The size of the square larger then the size of the rectangle.");
                Console.ReadKey();
            }
            else
            {
                count_h = a / c;
                count_w = b / c;
                s = (a - count_h * c) * (count_w * c) + (b - count_w * c) * a;
                Console.WriteLine("In rectagle ... {0} squares", count_h * count_w);
                Console.WriteLine("Free space = {0}", s);
                Console.ReadKey();
            }
        }
    }
}
