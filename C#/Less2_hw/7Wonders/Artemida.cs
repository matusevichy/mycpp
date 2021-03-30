using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Artemida
    {
        public string Name { get; set; } = "Храм Артемиды Эфесской";
        public string Age { get; set; } = "Эфес, 550 г. до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
