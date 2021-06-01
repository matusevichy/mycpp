using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D point3D = new Point3D(2, 3, 4);
            Console.WriteLine(point3D);

            Console.ReadKey();
        }
    }
}
