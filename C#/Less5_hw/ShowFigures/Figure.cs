using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowFigures
{
    struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    abstract class Figure
    {
        public Point StartPoint { get; set; }
        public ConsoleColor FigureColor { get; set; }
        abstract public void Show();
        virtual public void Set()
        {
            int x=0, y=0;
            string color;
            Console.Clear();
            Console.WriteLine("Input position for draw figure:");
            Console.Write("Left:");
            Int32.TryParse(Console.ReadLine(), out x);
            Console.Write("Top:");
            Int32.TryParse(Console.ReadLine(), out y);
            if (x>=0&&y>=0)
            {
                StartPoint = new Point { X = x, Y = y };
            }
            Console.WriteLine("Input color for draw figure:");
            foreach(var item in Enum.GetValues(typeof(ConsoleColor)))
            {
                Console.WriteLine(item);
            }
            color = Console.ReadLine();
            ConsoleColor tmp;
            Enum.TryParse(color, out tmp);
            FigureColor = tmp;
        }
    }

    class Triangle : Figure
    {
        public int SideSize { get; set; }

        public override void Set()
        {
            int size;
            base.Set();
            Console.WriteLine("Input size of the triangle`s side:");
            Int32.TryParse(Console.ReadLine(), out size);
            SideSize = size;
            Console.Clear();
        }

        public override void Show()
        {
            Console.ForegroundColor = FigureColor;
            for (int i = 0; i < SideSize; i++)
            {
               Console.SetCursorPosition(StartPoint.X, StartPoint.Y+i);
               for (int j = 0; j <=i; j++)
                {
                    Console.Write("*");
                }
            }
        }

    }
    class Rectangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public override void Set()
        {
            int a,b;
            base.Set();
            Console.WriteLine("Input the height of the rectangle:");
            Int32.TryParse(Console.ReadLine(), out a);
            A = a;
            Console.WriteLine("Input the width of the rectangle:");
            Int32.TryParse(Console.ReadLine(), out b);
            B = b;
            Console.Clear();
        }
        public override void Show()
        {
            Console.ForegroundColor = FigureColor;
            for (int i = 0; i < A; i++)
            {
                Console.SetCursorPosition(StartPoint.X, StartPoint.Y + i);
                for (int j = 0; j < B; j++)
                {
                    Console.Write("*");
                }
            }
        }
    }
}
