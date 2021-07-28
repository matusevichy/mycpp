using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Less2_hw
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(new Dictionary<string, double> { 
                { "Аи-95", 30.50 },
                {"Аи-92", 28.90 }, 
                {"Дт", 29.70 },
                {"Газ", 17.38}
            }, new double[4] { 3, 4, 5, 6 }));
        }
    }
}
