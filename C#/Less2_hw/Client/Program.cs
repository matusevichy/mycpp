using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*2.	Описать структуру Client содержащую поля: код
клиента; ФИО; адрес; телефон; количество заказов
осуществленных клиентом; общая сумма заказов
клиента.
6.	Описать перечисление ClientType определяющее
важность клиента, и добавить соответствующее поле
в структуру Client из задания №2.*/

namespace Client
{
    enum ClientType
    {
        Normal, Regular, Important, Vip
    }
    struct Client
    {
        public int Code { get; set; }
        public string Fio { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ClientType Type { get; set; }
        public int CountOrder { get; set; }
        public float SumOrder { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
