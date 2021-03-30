using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Mausoleum
    {
        public string Name { get; set; } = "Мавзолей в Галикарнасе ";
        public string Age { get; set; } = "Галикарнас, 351 г. до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
