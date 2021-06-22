using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Less9_hw
{
    class App
    {
        public List<Bill> bills;

        public App()
        {
            bills = new List<Bill>();
        }
        public void AddBill()
        {
            Console.WriteLine($"Add bill number {bills.Count+1}");
            Console.WriteLine("Enter sum pay of the day");
            double payOfDay, fineOfDay;
            int dayCount, delayDayCount;
            double.TryParse(Console.ReadLine(), out payOfDay);
            Console.WriteLine("Enter count day");
            int.TryParse(Console.ReadLine(), out dayCount);
            Console.WriteLine("Enter sum of the fine of the day");
            double.TryParse(Console.ReadLine(), out fineOfDay);
            Console.WriteLine("Enter count the day of the payment delay");
            int.TryParse(Console.ReadLine(), out delayDayCount);
            bills.Add(new Bill { DayCount = dayCount, DelayDayCount = delayDayCount, FineOfDay = fineOfDay, PayOfDay = payOfDay });
        }
        public void ReadBills()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using(FileStream fileStream=new FileStream("bills.dat", FileMode.Open, FileAccess.Read))
            {
                bills = binaryFormatter.Deserialize(fileStream) as List<Bill>;
                Console.WriteLine("Success!");
            }
        }
        public void WriteBills()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("bills.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, bills);
                Console.WriteLine("Success!");
            }
        }
        private void PrintBill(Bill bill)
        {
            Console.WriteLine(bill);
        }
        public void Print()
        {
            bills.ForEach(PrintBill);
            Console.ReadKey();
        }
        public void Start()
        {
            while (true)
            {
                int act;
                Menu();
                int.TryParse(Console.ReadLine(), out act);
                switch (act)
                {
                    case 1:
                        AddBill();
                        break;
                    case 2:
                        ReadBills();
                        break;
                    case 3:
                        WriteBills();
                        break;
                    case 4:
                        Bill.SerializeAll = !Bill.SerializeAll;
                        break;
                    case 5:
                        Print();
                        break;
                    case 6:
                        return;
                    default:
                        break;
                }
            }
        }
        private void Menu()
        {
            Console.Clear();
            Console.WriteLine($"SerializeAll={Bill.SerializeAll}");
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - Add bill;");
            Console.WriteLine("[2] - Read bills list;");
            Console.WriteLine("[3] - Save bills list;");
            Console.WriteLine("[4] - Change 'SerializeAll' option;");
            Console.WriteLine("[5] - Print all bills;");
            Console.WriteLine("[6] - Exit.");
        }
    }
}