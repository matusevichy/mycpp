using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*3.Описать структуру RequestItem содержащую поля:
товар; количество единиц товара.*/
namespace RequestItem
{
    struct RequestItem
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
