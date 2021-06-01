using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line
{
    class Program
    {
        static void Main(string[] args)
        {
            Line<int> lineI = new Line<int>(new Point2D<int>(1, 2), new Point2D<int>(3, 4));
            Line<double> lineD = new Line<double>(5, 6, 7, 8);
            Console.WriteLine(lineI);
            Console.WriteLine(lineD);
            Console.ReadKey();
        }
    }
}
