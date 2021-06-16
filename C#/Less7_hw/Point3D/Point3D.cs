﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point3D
{
    public class Point2D<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public Point2D(T x, T y)
        {
            X = x;
            Y = y;
        }
        public Point2D()
        {
            X = default(T);
            Y = default(T);
        }
    }
    public class Point3D:Point2D<int>
    {
        public int Z { get; set; }
        public Point3D(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
        public override string ToString()
        {
            return $"X={X}, Y={Y}, Z={Z}";
        }
    }
}
