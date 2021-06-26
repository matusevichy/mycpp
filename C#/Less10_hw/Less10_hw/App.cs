using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less10_hw
{

    class App
    {
        const string cashRequestUrl = "pubinfo?json&exchange&coursid=5";
        const string cashlessRequestUrl = "pubinfo?exchange&json&coursid=11";
        const string archiveRequestUrl = "exchange_rates?json&date=";
        const string departmentRequestUrl = "pboffice?json";

        Privat privat;
        public App()
        {
            privat = new Privat(departmentRequestUrl);
        }
        public void Start()
        {
            int act;
            while (true)
            {
                Menu();
                int.TryParse(Console.ReadLine(), out act);
                switch (act)
                {
                    case 9:
                        return;
                    case 1:
                        privat.GetExchangeRate(cashRequestUrl);
                        Console.ReadKey();
                        break;
                    case 2:
                        privat.GetExchangeRate(cashlessRequestUrl);
                        Console.ReadKey();
                        break;
                    case 3:
                        privat.GetCashRateOnDate(archiveRequestUrl);
                        Console.ReadKey();
                        break;
                    case 4:
                        DepartmentsMenu();
                        break;
                    case 5:
                        privat.LoadDepartments(departmentRequestUrl);
                        break;
                    default:
                        break;
                }
            }
        }
        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Select action:");
            Console.WriteLine("[1] - Get current cash exchange rate;");
            Console.WriteLine("[2] - Get current cashless exchange rate;");
            Console.WriteLine("[3] - Get exchange rate on some date;");
            Console.WriteLine("[4] - Find departments;");
            Console.WriteLine("[5] - Reload departments list;");
            Console.WriteLine("[9] - Exit.");
        }

        private void DepartmentsMenu()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine("Press 1 for get cities list, " +
                    "2 for find department by city, " +
                    "3 for find department by city and address, " +
                    "0 for exit to previos menu.");
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        privat.ShowCityList();
                        break;
                    case ConsoleKey.D2:
                        privat.GetDepartmentsByCity();
                        break;
                    case ConsoleKey.D3:
                        privat.GetDepartmentsByAddress();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D0:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
