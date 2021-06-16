using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    interface IPolygon
    {
        double Height { get; set; }
        double Basis { get; set; }
        double Corner { get; set; }
        double SidesCount { get; set; }
        double[] SidesLength { get; set; }
        double Area { get; set; }
        double Perimeter { get; set; }
    }
    abstract class Figure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Triangle : Figure, IPolygon
    {
        public Triangle(double a, double b, double c, double h)
        {
            if (a<=0 || b<=0 || c<=0 || h<=0)
            {
                throw new Exception("Incorrect data! Sides and height should be >0");
            }
            else if(a+b<c||b+c<a||a+c<b)
            {
                throw new Exception("The sum of some two side should be biggest then the third side");
            }
            else
            {
                A = a;
                B = b;
                C = c;
                H = h;
            }
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double H { get; private set; }
        public double Height { get ; set ; }
        public double Basis { get ; set ; }
        public double Corner { get ; set ; }
        public double SidesCount { get ; set ; }
        public double[] SidesLength { get ; set ; }
        public double Area { get; set; }
        public double Perimeter { get ; set ; }

        public override double GetArea()
        {
            return A * H / 2;
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }
    }

    class Square : Figure
    {
        public Square(double a)
        {
            if (a <= 0)
            {
                throw new Exception("Incorrect data! Side should be >0");
            }
            else
            {
                A = a;
            }
        }

        public double A { get; private set; }
        public override double GetArea()
        {
            return Math.Pow(A, 2);
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }
    }

    class Rectangle : Figure
    {
        public Rectangle(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new Exception("Incorrect data! Sides should be >0");
            }
            else
            {
                A = a;
                B = b;
            }
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public override double GetArea()
        {
            return A * B;
        }

        public override double GetPerimeter()
        {
            return 2 * A + 2 * B;
        }
    }

    class Rhombus : Figure
    {
        public Rhombus(double a, double d1, double d2)
        {
            if (a <= 0 || d1 <= 0 || d2 <= 0)
            {
                throw new Exception("Incorrect data! Side and diagonals should be >0");
            }
            else
            {
                A = a;
                D1 = d1;
                D2 = d2;
            }
        }

        public double A { get; private set; }
        public double D1 { get; private set; }
        public double D2 { get; private set; }
        public override double GetArea()
        {
            return D1 * D2 / 2;
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }
    }

    class Parallelogram : Figure
    {
        public Parallelogram(double a, double b, double h)
        {
            if (a <= 0 || b <= 0 || h <= 0)
            {
                throw new Exception("Incorrect data! Sides and height should be >0");
            }
            else
            {
                A = a;
                B = b;
                H = h;
            }
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double H { get; private set; }
        public override double GetArea()
        {
            return A * H;
        }

        public override double GetPerimeter()
        {
            return 2 * A + 2 * B;
        }
    }

    class Trapezoid : Figure
    {
        public Trapezoid(double a, double b, double c, double d, double h)
        {
            if (a <= 0 || b <= 0 || c <= 0 || d <= 0 || h <= 0)
            {
                throw new Exception("Incorrect data! Sides and height should be >0");
            }
            else
            {
                A = a;
                B = b;
                C = c;
                D = d;
                H = h;
            }
        }

        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }
        public double D { get; private set; }
        public double H { get; private set; }
        public override double GetArea()
        {
            return (A + B) / 2 * H;
        }

        public override double GetPerimeter()
        {
            return A + B + C + D;
        }
    }

    class Circle : Figure
    {
        public Circle(double r)
        {
            if (r <= 0)
            {
                throw new Exception("Incorrect data! Radius should be >0");
            }
            else
            {
                R = r;
            }
        }

        public double R { get; private set; }
        public override double GetArea()
        {
            return Math.PI * Math.Pow(R, 2);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * R;
        }
    }

    class Ellipse : Figure
    {
        public Ellipse(double a, double b)
        {
            if (a <= 0 || b <= 0)
            {
                throw new Exception("Incorrect data! Sides should be >0");
            }
            else
            {
                A = a;
                B = b;
            }
        }
        public double A { get; private set; }
        public double B { get; private set; }
        public override double GetArea()
        {
            return Math.PI * A * B;
        }

        public override double GetPerimeter()
        {
            return 4 * (Math.PI * A * B + Math.Pow(A - B, 2)) / (A + B);
        }
    }
}
