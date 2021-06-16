using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    abstract class Figure
    {
        public abstract double Area();
        public abstract double Perimeter();
    }

    class Triangle : Figure
    {
        private double a, b, c, h;
        public Triangle(double a, double b, double c, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.h = h;
        }
        public override double Area()
        {
            return a*h/2;
        }

        public override double Perimeter()
        {
            return a+b+c;
        }
    }

    class Square : Figure
    {
        private double a;
        public Square(double a, double b)
        {
            this.a = a;
        }
        public override double Area()
        {
            return Math.Pow(a, 2);
        }

        public override double Perimeter()
        {
            return 4*a;
        }
    }

    class Rectangle : Figure
    {
        private double a, b;
        public Rectangle(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double Area()
        {
            return a * b;
        }

        public override double Perimeter()
        {
            return 2 * a + 2 * b;
        }
    }

    class Rhombus : Figure
    {
        private double a, d1, d2;
        public Rhombus(double a, double d1, double d2)
        {
            this.a = a;
            this.d1 = d1;
            this.d2 = d2;
        }
        public override double Area()
        {
            return d1*d2/2;
        }

        public override double Perimeter()
        {
            return 4 * a;
        }
    }

    class Parallelogram : Figure
    {
        private double a, b, h;
        public Parallelogram(double a, double b, double h)
        {
            this.a = a;
            this.b = b;
            this.h = h;
        }
        public override double Area()
        {
            return a*h;
        }

        public override double Perimeter()
        {
            return 2 * a + 2 * b;
        }
    }

    class Trapezoid : Figure
    {
        private double a, b, c, d, h;
        public Trapezoid(double a, double b, double c, double d, double h)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.h = h;
        }
        public override double Area()
        {
            return (a+b)/2*h;
        }

        public override double Perimeter()
        {
            return a + b + c + d;
        }
    }

    class Circle : Figure
    {
        private double r;
        public Circle(double r)
        {
            this.r = r;
        }
        public override double Area()
        {
            return Math.PI*Math.Pow(r,2);
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * r;
        }
    }

    class Ellipse : Figure
    {
        private double a, b;
        public Ellipse(double a, double b)
        {
            this.a = a;
            this.b = b;
        }
        public override double Area()
        {
            return Math.PI*a*b;
        }

        public override double Perimeter()
        {
            return 4*(Math.PI*a*b+Math.Pow(a-b,2))/(a+b);
        }
    }
}
