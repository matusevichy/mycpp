using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less6_hw
{
    class App
    {
        enum MenuItem
        {
            Exit=0,
            Sum=1,
            Diff=2,
            Prod=3,
            Div=4,
            More=5,
            Less=6,
            Equal=7,
            Notequal=8,
            Inc=9,
            Dec=10
        }
        private void MainMenu()
        {
            Console.WriteLine("Select action:\n" +
                "1 - Sum;\n" +
                "2 - Diff;\n" +
                "3 - Production;\n" +
                "4 - Division;\n" +
                "5 - More;\n" +
                "6 - Less;\n" +
                "7 - Equal;\n" +
                "8 - Notequal;\n" +
                "9 - + 1 kop;\n" +
                "10 - -1 kop;\n" +
                "0 - Exit.");
        }

        public void Start()
        {
            while (true)
            {
                byte act;
                Console.Clear();
                MainMenu();
                Byte.TryParse(Console.ReadLine(), out act);
                switch (act)
                {
                    case (byte)MenuItem.Sum:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter Money 2");
                            Money money2 = NewMoney();
                            Console.WriteLine($"Money 1 = {money1}, Money 2 = {money2}\n" +
                                $"Sum = {money1+money2}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Diff:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter Money 2");
                            Money money2 = NewMoney();
                            Console.WriteLine($"Money 1 = {money1}, Money 2 = {money2}\n" +
                                $"Sum = {money1 - money2}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Prod:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter number");
                            int num;
                            Int32.TryParse(Console.ReadLine(), out num);
                            Console.WriteLine($"Money 1 = {money1}, number = {num}\n" +
                                $"Sum = {money1 * num}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Div:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter number");
                            int num;
                            Int32.TryParse(Console.ReadLine(), out num);
                            Console.WriteLine($"Money 1 = {money1}, number = {num}\n" +
                                $"Sum = {money1 / num}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.More:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter Money 2");
                            Money money2 = NewMoney();
                            Console.WriteLine($"Money 1 = {money1}, Money 2 = {money2}\n" +
                                $"Money 1 > Money 2 is {money1 > money2}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Less:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter Money 2");
                            Money money2 = NewMoney();
                            Console.WriteLine($"Money 1 = {money1}, Money 2 = {money2}\n" +
                                $"Money 1 < Money 2 is {money1 < money2}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Equal:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter Money 2");
                            Money money2 = NewMoney();
                            Console.WriteLine($"Money 1 = {money1}, Money 2 = {money2}\n" +
                                $"Money 1 = Money 2 is {money1 == money2}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Notequal:
                        {
                            Console.WriteLine("Enter Money 1");
                            Money money1 = NewMoney();
                            Console.WriteLine("Enter Money 2");
                            Money money2 = NewMoney();
                            Console.WriteLine($"Money 1 = {money1}, Money 2 = {money2}\n" +
                                $"Money 1 <> Money 2 is {money1 != money2}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Inc:
                        {
                            Console.WriteLine("Enter Money");
                            Money money1 = NewMoney();
                            Console.WriteLine($"Money = {money1}\n" +
                                $"Money 1 + 1 kop is {++money1}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Dec:
                        {
                            Console.WriteLine("Enter Money");
                            Money money1 = NewMoney();
                            Console.WriteLine($"Money = {money1}\n" +
                                $"Money 1 - 1 kop is {--money1}");
                            Console.ReadKey();
                            break;
                        }
                    case (byte)MenuItem.Exit:
                        return;
                    default:
                        break;
                }
            }
        }
        private Money NewMoney()
        {
            int hrn, kop;
            Console.WriteLine("Enter count of the hrn");
            Int32.TryParse(Console.ReadLine(), out hrn);
            Console.WriteLine("Enter count of the kop");
            Int32.TryParse(Console.ReadLine(), out kop);
            return new Money { Hrn = hrn, Kop = kop };
        }
    }
}
