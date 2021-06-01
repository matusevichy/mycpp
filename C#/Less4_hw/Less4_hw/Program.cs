using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1.	Разработать собственный структурный тип данных
для хранения целочисленных коэффициентов A и B
линейного уравнения A×X + B×Y = 0. в классе реали-
зовать статический метод Parse(), которые принимает
строку со значениями коэффициентов, разделенных
запятой или пробелом.*/
namespace Linear
{
    class Program
    {
        static void Main(string[] args)
        {
            LinearData data;
            data = Linear.LinearEquation.Parse(Console.ReadLine());

            Console.ReadKey();
        }
    }
}
