using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNum
{
    class Program
    {
        static void Main(string[] args)
        {
            uint a, b;
            Console.WriteLine("Enter min number:");
            a = uint.Parse(Console.ReadLine());
            Console.WriteLine("Enter max number:");
            b = uint.Parse(Console.ReadLine());
            Console.Clear();
            if (a>=b)
            {
                Console.WriteLine("Incorrect values");
                return;
            }
            else
            {
                for (uint i = a; i <= b; i++)
                {
                    for (uint j = 0; j < i; j++)
                    {
                        Console.Write("{0} ", i);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
