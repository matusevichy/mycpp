using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompShop.Models
{
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Characteristics { get; set; }
        public override string ToString()
        {
            return $"{Name} Description: {Description} Characteristics: {Characteristics}";
        }
    }
}
