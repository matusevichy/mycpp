using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*4.	Описать структуру Request содержащую поля: код
заказа; клиент; дата заказа; перечень заказанных товаров;
сумма заказа (реализовать вычисляемым свойством).
7.	Описать перечисление PayType определяющее форму
оплаты клиентом заказа, и добавить соответствующее
поле в структуру Request из задания №4.*/
namespace Request
{
    enum PayType
    {
        Card, Bank, Cash
    }
    struct Client
    {
        public string Fio { get; set; }
        public string  Address { get; set; }
    }
    struct Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
    }
    struct Request
    {
        public int Сode { get; set; }
        public Client Client { get; set; }
        public DateTime OrderDate { get; set; }
        public Product[] Products { get; set; }
        public PayType PayType { get; set; }
        public float Sum 
        { get
            {
                float sum = 0;
                foreach (var item in Products)
                {
                    sum += item.Price;
                }
                return sum;
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
