using Less4_hw.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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

namespace Less4_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Abonent> Abonents { get; set; } = new ObservableCollection<Abonent>
        {
            new Abonent
            {
                Id=1,
                FirstName="Name 1",
                MiddleName="N1",
                LastName="Lastname 1",
                Phone="11111111",
                Address="Address 1"
            },
                        new Abonent
            {
                Id=2,
                FirstName="Name 2",
                MiddleName="N2",
                LastName="Lastname 2",
                Phone="22222222",
                Address="Address 2"
            }

        };
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
