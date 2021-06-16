using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            float p,s = 10000f;
            Console.WriteLine("Input the percentage:");
            p = Convert.ToSingle(Console.ReadLine());
            int k = 0;
            while(s <= 11000)
            {
                s += s * p / 100;
                k++;
            }
            Console.WriteLine("After {0} month sum will be {1}", k, s);
            Console.ReadKey();
        }
    }
}
