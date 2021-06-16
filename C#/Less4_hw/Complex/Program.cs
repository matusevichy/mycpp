using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*3.	Реализовать класс для хранения комплексного чис-
ла. Выполнить в нем перегрузку всех необходимых
операторов для успешной компиляции следующего
фрагмента кода:
Complex z = new Complex(1,1);
Complex z1;
z1 = z - (z * z * z - 1) / (3 * z * z);
Console.WriteLine("z1 = {0}", z1);*/

namespace Complex
{
    class Program
    {
        static void Main(string[] args)
        {
            Complex z = new Complex(1, 1);
            Complex z1;
            z1 = z - (z * z * z - 1) / (3 * z * z);
            Console.WriteLine("z1 = {0}", z1);

            Console.ReadKey();
        }
    }
}
