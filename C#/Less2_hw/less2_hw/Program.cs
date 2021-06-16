using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*1.Описать структуру Article, содержащую следующие
поля: код товара; название товара; цену товара.
5.	Описать перечисление ArticleType определяющее
типы товаров, и добавить соответствующее поле
в структуру Article из задания №1.*/
namespace less2_hw
{
    enum ArticleType
    {
        Books, Furniture, Food, Cars, Stationery, Dishes
    }
    struct Article
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public ArticleType Type { get; set; }
        public float Price { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
