using Less2_hw.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Less2_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool work = true;
        public MainWindow()
        {
            Sea sea = new Sea();
            InitializeComponent();
            DataContext = sea;
            Task.Run(() =>
            {
                while (work)
                {
                    Ship ship = new Ship();
                    sea.AddShip(ship);
                    ship.Start();
                    Thread.Sleep(1000);
                }
            });
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                work = false;
            }
        }
    }
}
