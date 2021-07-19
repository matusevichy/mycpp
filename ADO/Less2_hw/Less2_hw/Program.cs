using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            VandFService service = new VandFService();
            //List<VandF> vandFs = new List<VandF>();
            service.GetAll().ForEach(v => Console.WriteLine(v));
            service.GetNames().ForEach(v => Console.WriteLine(v));
            service.GetColors().ForEach(v => Console.WriteLine(v));
            service.PrintCaloriesInfo();
            Console.WriteLine(service.GetCountOfType("овощ"));
            Console.WriteLine(service.GetCountOfColor("желтый"));
            foreach (var item in service.GetCountOfColors())
            {
                Console.WriteLine($"{item.Key}\t{item.Value}");
            }
            service.GetOfCaloriesInRange(10,20).ForEach(v => Console.WriteLine(v));
            service.GetOfColorList(new List<string> { "желтый", "красный" }).ForEach(v => Console.WriteLine(v));
            ;
            Console.Read();
        }
    }
}
