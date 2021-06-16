using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linear
{
    struct LinearData
    {
        public int A { get; set; }
        public int B { get; set; }
        public LinearData(int a, int b)
        {
            A = a;
            B = b;
        }
    }
    class LinearEquation
    {
        public static LinearData Parse(string input)
        {
            int a, b;
            string[] tmp = input.Split(' ', ',');
            if(tmp.Length==2 && Int32.TryParse(tmp[0],out a) && Int32.TryParse(tmp[1], out b))
            {
                return new LinearData(a, b);
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
