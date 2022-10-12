using militreg_lite.BLL.DTO;
using militreg_lite.ViewModels;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace militreg_lite.UI
{
    /// <summary>
    /// Логика взаимодействия для Dictionaries.xaml
    /// </summary>
    public partial class DictionariesWindow : Window
    {
        private MainWindowViewModel viewModel;
        private UserDTO user;

        public DictionariesWindow()
        {
            InitializeComponent();
        }

        public DictionariesWindow(MainWindowViewModel viewModel, UserDTO user):this()
        {
            this.viewModel = viewModel;
            this.user = user;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ;
        }
    }
}
