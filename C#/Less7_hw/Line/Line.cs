using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line
{
    class Line<T>
    {
        Point2D<T> point1;
        Point2D<T> point2;
        public Line(Point2D<T> pt1, Point2D<T> pt2)
        {
            point1 = pt1;
            point2 = pt2;
        }
        public Line(T x1, T y1, T x2, T y2)
        {
            point1 = new Point2D<T>(x1, y1);
            point2 = new Point2D<T>(x2, y2);
        }
        public override string ToString()
        {
            return $"Point 1: {point1}\n" +
                $"point 2: {point2}";
        }
    }
}
