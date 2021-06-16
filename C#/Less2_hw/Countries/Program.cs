using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ukraine;
using Belarus;
using Poland;
/*10.Разработать приложение, в котором бы сравнивалось
население трёх столиц из разных стран. Причём стра-
на бы обозначалась пространством имён, а город —
классом в данном пространстве.*/

namespace Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            Kiev kiev = new Kiev
            {
                PeopleCount = 2884000
            };
            Varshava varshava = new Varshava
            {
                PeopleCount = 1765000
            };
            Minsk minsk = new Minsk
            {
                PeopleCount = 1975000
            };
            string lagestCity;
            if (kiev.PeopleCount>minsk.PeopleCount&& kiev.PeopleCount>varshava.PeopleCount)
            {
                lagestCity = kiev.ToString();
            }
            else if(minsk.PeopleCount>kiev.PeopleCount&&minsk.PeopleCount>varshava.PeopleCount)
            {
                lagestCity = minsk.ToString();
            }
            else
            {
                lagestCity = varshava.ToString();
            }
            Console.WriteLine($"{lagestCity} is a lagest city!");

            Console.ReadKey();
        }
    }
}
