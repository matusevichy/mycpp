using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    class Compound
    {
        private Figure[] compound;
        public void Add(Figure obj)
        {
            if (compound==null)
            {
                compound = new Figure[1];
            }
            else
            {
                Array.Resize<Figure>(ref compound, compound.Length + 10);
            }
            compound[compound.Length - 1] = obj;
        }
        public double Area()
        {
            double area = 0;
            foreach (var item in compound)
            {
                area += item.Area();
            }
            return area;
        }
    }
}
