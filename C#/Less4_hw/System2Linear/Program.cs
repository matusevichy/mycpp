using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*2.	Разработать метод для решения системы 2 линейных
уравнений:
A1×X + B1×Y = 0
A2×X + B2×Y = 0
Метод с помощью выходных параметров должен
возвращать найденное решение или ошибку, если
решения не существует.*/

namespace System2Linear
{
    class Program
    {
        static void Main(string[] args)
        {
            float x=0, y=0;
            System2Linear.Calculate(-10, 7, -6, 7, out x, out y);
            Console.WriteLine($"X={x};Y={y}");
            Console.ReadKey();
        }
    }
}
