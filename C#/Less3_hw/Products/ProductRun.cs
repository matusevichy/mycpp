using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products
{
    public abstract class ProductRun
    {
        ProductType[] array;
        int count;
        public ProductRun()
        {
            array = new ProductType[10];
            count = 0;
        }
        public void Add(ProductType obj)
        {
            if (count==array.Length)
            {

                Array.Resize(ref array, array.Length + 10);
            }
            array[count] = obj;
            count++;
        }
        public virtual void Print()
        {
            foreach (var item in array)
            {
                item?.Print();
            }
        }
    }
    public class Recived : ProductRun
    {
        public override void Print()
        {
            Console.WriteLine("Recived:");
            base.Print();
        }
    }
    public class Sold : ProductRun
    {
        public override void Print()
        {
            Console.WriteLine("Sold:");
            base.Print();
        }
    }
    public class WrittenOff : ProductRun
    {
        public override void Print()
        {
            Console.WriteLine("Written off:");
            base.Print();
        }
    }
    public class Transferred : ProductRun
    {
        public override void Print()
        {
            Console.WriteLine("Transfered:");
            base.Print();
        }
    }

}
