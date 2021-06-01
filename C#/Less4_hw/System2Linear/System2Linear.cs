using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System2Linear
{
    class System2Linear
    {
        public static void Calculate(float a1, float b1, float a2, float b2, out float x, out float y)
        {
            if (a1/a2==b1/b2)
            {
                throw new Exception("This system has infinitely many solution");
            }
            else
            {
                x = 0 / (a2 - b2 * a1 / b1);
                y = -a1 * x / b1;
            }
        }
    }
}
