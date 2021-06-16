using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*4.	Разработать класс Fraction, представляющий простую
дробь. в классе предусмотреть два поля: числитель
и знаменатель дроби. Выполнить перегрузку следу-
ющих операторов: +,-,*,/,==,!=,<,>, true и false.
Арифметические действия и сравнение выполняется
в соответствии с правилами работы с дробями. Опе-
ратор true возвращает true если дробь правильная
(числитель меньше знаменателя), оператор false
возвращает true если дробь неправильная (числитель
больше знаменателя).
Выполнить перегрузку операторов, необходимых для
успешной компиляции следующего фрагмента кода:*/

namespace Fraction
{
    class Fraction
    {
        public int Chisl { get; set; }
        public int Znam { get; set; }
        private static int NOK(int num1, int num2)
        {
            for (int i = Math.Max(num1,num2); i <= num1*num2; i++)
            {
                if (i%num1==0&&i%num2==0)
                {
                    return i;
                }
            }
            return 0;
        }
        private static void Convert(ref Fraction fraction1, ref Fraction fraction2)
        {
            if (fraction1.Znam != fraction2.Znam)
            {
                Fraction f1 = new Fraction(0, 0);
                Fraction f2 = new Fraction(0, 0);
                int znam = Fraction.NOK(fraction1.Znam, fraction2.Znam);
                f1.Znam = f2.Znam = znam;
                f1.Chisl = fraction1.Chisl * znam/fraction1.Znam;
                f2.Chisl = fraction2.Chisl * znam/fraction2.Znam;
                fraction1 = f1;
                fraction2 = f2;
            }
        }
        public Fraction(int chisl, int znam)
        {
            Chisl = chisl;
            Znam = znam;
        }
        public static Fraction operator+(Fraction fraction1,Fraction fraction2)
        {
            if (fraction1.Znam!=fraction2.Znam)
            {
                Fraction.Convert(ref fraction1, ref fraction2);
            }
            return new Fraction(fraction1.Chisl + fraction2.Chisl, fraction1.Znam);
        }
        public static Fraction operator+(Fraction fraction, double num)
        {
            Fraction tmp = new Fraction((int)((num-Math.Truncate(num)) * 10), 10);
            if (Math.Truncate(num)!=0)
            {
                Fraction tmpInt = new Fraction(fraction.Znam, fraction.Znam);
                return fraction + tmpInt + tmp;
            }
            else
            {
                return fraction+tmp;
            }
        }
        public static Fraction operator-(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.Znam != fraction2.Znam)
            {
                Fraction.Convert(ref fraction1, ref fraction2);
            }
            return new Fraction(fraction1.Chisl - fraction2.Chisl, fraction1.Znam);
        }
        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Chisl * fraction2.Chisl, fraction1.Znam * fraction2.Znam);
        }
        public static Fraction operator*(Fraction fraction, int num)
        {
            return new Fraction(fraction.Chisl * num, fraction.Znam);
        }
        public static Fraction operator *(int num, Fraction fraction)
        {
            return new Fraction(fraction.Chisl * num, fraction.Znam);
        }
        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.Chisl * fraction2.Znam, fraction1.Znam * fraction2.Chisl);
        }
        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            Fraction.Convert(ref fraction1, ref fraction2);
            return fraction1.Chisl==fraction2.Chisl;
         }
        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 == fraction2);
        }
        public static bool operator true(Fraction fraction)
        {
            return fraction.Chisl < fraction.Znam ? true : false;
        }
        public static bool operator false(Fraction fraction)
        {
            return fraction.Chisl>fraction.Znam?true:false;
        }
    }
}
