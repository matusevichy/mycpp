using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less6_hw
{
    class Money
    {
        public int Hrn { get; set; }
        public int Kop { get; set; }
        public static double ToDouble(Money money)
        {
            return money.Hrn + (double)money.Kop / 100;
        }
        public static Money FromDouble(double num)
        {
            return new Money { Hrn = (int)num, Kop = (int)((num - (int)num) * 100) };
        }
        public static Money operator +(Money money1, Money money2)
        {
            return Money.FromDouble(Money.ToDouble(money1)+ Money.ToDouble(money2));
        }
        public static Money operator -(Money money1, Money money2)
        {
            double tmp = Money.ToDouble(money1) - Money.ToDouble(money2);
            if (tmp >= 0)
            {
                return Money.FromDouble(tmp);
            }
            else
            {
                throw new BancrotException();
            }
        }

        public static Money operator * (Money money, int num)
        {
            return Money.FromDouble(Money.ToDouble(money) * num);
        }
        public static Money operator /(Money money, int num)
        {
            return Money.FromDouble(Money.ToDouble(money) / num);
        }
        public static Money operator ++ (Money money)
        {
            return Money.FromDouble(Money.ToDouble(money) + 0.01);
        }
        public static Money operator --(Money money)
        {
            return Money.FromDouble(Money.ToDouble(money) - 0.01);
        }
        public static bool operator >(Money money1, Money money2)
        {
            return Money.ToDouble(money1) > Money.ToDouble(money2);
        }
        public static bool operator<(Money money1, Money money2)
        {
            return Money.ToDouble(money1) < Money.ToDouble(money2);
        }
        public static bool operator==(Money money1, Money money2)
        {
            return money1.Hrn == money2.Hrn && money1.Kop == money2.Kop;
        }
        public static bool operator!=(Money money1,Money money2)
        {
            return !(money1 == money2);
        }
        public override string ToString()
        {
            return $"{Hrn} hrn {Kop} kop";
        }
    }
    public class BancrotException : ApplicationException
    {
        public DateTime TimeException { get; private set; }
        public BancrotException() : base("You are bankrot!") 
        {
            TimeException = DateTime.Now;
        }
       }
}
