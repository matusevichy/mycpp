using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Zeus
    {
        public string Name { get; set; } = "Статуя Зевса в Олимпии";
        public string Age { get; set; } = "Олимпия, 435 г. до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
