using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Pyramid
    {
        public string Name { get; set; } = "Пирамида Хеопса ";
        public string Age { get; set; } = "Гиза, 2550 г. до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
