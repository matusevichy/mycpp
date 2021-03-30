using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Lighthouse
    {
        public string Name { get; set; } = "Александрийский маяк";
        public string Age { get; set; } = "Александрия, III век до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
