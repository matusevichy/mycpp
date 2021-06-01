using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Разработать абстрактный класс «Геометрическая Фигу-
ра» с методами «Площадь Фигуры» и «Периметр Фигуры».
Разработать классы-наследники: Треугольник, Квадрат,
Ромб, Прямоугольник, Параллелограмм, Трапеция, Круг,
Эллипс. Реализовать конструкторы, которые однозначно
определяют объекты данных классов.
Реализовать класс «Составная Фигура», который
может состоять из любого количества «Геометрических
Фигур». Для данного класса определить метод нахождения
площади фигуры. Создать диаграмму взаимоотношений
классов.*/

namespace Figure
{
    class Program
    {
        static void Main(string[] args)
        {
            Compound arr = new Compound();
            arr.Add(new Triangle(10, 10, 10, 5));
            Console.WriteLine(arr.Area());
            Console.ReadKey();
        }
    }
}
