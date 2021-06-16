using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Compound
    {
        private IPolygon[] compound;
        public void Add(IPolygon obj)
        {
            if (compound == null)
            {
                compound = new IPolygon[1];
            }
            else
            {
                Array.Resize<IPolygon>(ref compound, compound.Length + 1);
            }
            compound[compound.Length - 1] = obj;
        }
        public double Area()
        {
            double area = 0;
            foreach (var item in compound)
            {
                area += item.Area;
            }
            return area;
        }
    }
}
