using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle tr = new Triangle ( 5, 5, 5, 3 );
            Triangle triangle = new Triangle(10, 10, 10, 5);
            Compound compound = new Compound();
            tr.Area = 12.0;
            triangle.Area = 13;
            compound.Add(tr);
            compound.Add(triangle);
            double area = compound.Area();
            Console.ReadKey();
        }
    }
}
