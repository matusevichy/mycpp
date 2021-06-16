using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowFigures
{
    class Program
    {
        static void Main(string[] args)
        {
            App newApp = new App();
            newApp.Start();
//            Triangle triangle = new Triangle();// { StartPoint = new Point { X = 5, Y = 5 }, FigureColor = ConsoleColor.Red, SideSize = 6 };
//            Rectangle rectangle = new Rectangle();// { StartPoint = new Point { X = 20, Y = 5 }, FigureColor = ConsoleColor.Blue, A = 5, B = 10 };
//            triangle.Set();
//            rectangle.Set();
//            triangle.Show();
//            rectangle.Show();
////            rectangle.Show();
            Console.ReadKey();
        }
    }
}
