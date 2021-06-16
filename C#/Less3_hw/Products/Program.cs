using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Разработать архитектуру классов иерархии товаров
при разработке системы управления потоками товаров для
дистрибьюторской компании. Прописать члены классов.
Создать диаграммы взаимоотношений классов.
Должны быть предусмотрены разные типы товаров,
в том числе:
• бытовая химия;
• продукты питания.
Предусмотреть классы управления потоком товаров
(пришло, реализовано, списано, передано).*/

namespace Products
{
    class Program
    {
        static void Main(string[] args)
        {
            Recived recived = new Recived();
            recived.Add(new Food("Apple", 10.5m, 10m, "USA"));
            recived.Print();

            Console.ReadKey();
        }
    }
}
