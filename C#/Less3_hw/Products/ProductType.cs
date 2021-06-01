using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public abstract class ProductType
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Count { get; set; }
        public ProductType(string name, decimal price, decimal count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
        public virtual void Print()
        {
            Console.WriteLine($"Name: {Name}\n" +
                $"Price: {Price}\n" +
                $"Count: {Count}");
        }
    }

    public class Food:ProductType
    {
        public string  Country { get; set; }
        public Food(string name,decimal price, decimal count, string country):base(name, price, count)
        {
            Country = country;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Food from country: {Country}");
        }
    }

    public class Chemicals:ProductType
    {
        public string Type { get; set; }
        public Chemicals(string name, decimal price, decimal count, string type):base(name,price, count)
        {
            Type = type; 
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"Chemicals type: {Type}");
        }
    }
}
