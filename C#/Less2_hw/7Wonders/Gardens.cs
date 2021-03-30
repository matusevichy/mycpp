using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7Wonders
{
    class Gardens
    {
        public string Name { get; set; } = "Висячие сады Семирамиды";
        public string Age { get; set; } = "Вавилон, 600 г. до н. э.";
        public void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Age:{Age}");
        }
    }
}
