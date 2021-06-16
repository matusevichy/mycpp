using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Koloss
    {
        public string Name { get; set; } = "Колосс Родосский";
        public string Age { get; set; } = "Родос, между 292 и 280 гг. до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
