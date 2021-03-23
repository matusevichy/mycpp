using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseNum
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n, dec=10, tmp=0;
            Console.WriteLine("Input number > 0:");
            n = uint.Parse(Console.ReadLine());
            while (n>=1)
            {
                tmp *= dec;
                tmp += n % 10;
                n /= 10;
            }
            Console.WriteLine("The reverse result is {0}", tmp);
            Console.ReadKey();
        }
    }
}
