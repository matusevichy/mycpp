using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*9.	Разработайте приложение «7 чудес света», где каждое
чудо будет представлено отдельным классом. Создай-
те дополнительный класс, содержащий точку входа.
Распределите приложение по файлам проекта и с по-
мощью пространства имён обеспечьте возможность
взаимодействия классов.*/
namespace _7Wonders
{
    class Program
    {
        static void Main(string[] args)
        {
            Gardens wonder1 = new Gardens();
            Zeus wonder2 = new Zeus();
            Artemida wonder3 = new Artemida();
            Koloss wonder4 = new Koloss();
            Mausoleum wonder5 = new Mausoleum();
            Lighthouse wonder6 = new Lighthouse();
            Pyramid wonder7 = new Pyramid();
            wonder1.Print();
            wonder2.Print();
            wonder3.Print();
            wonder4.Print();
            wonder5.Print();
            wonder6.Print();
            wonder7.Print();

            Console.ReadKey();
        }
    }
}
