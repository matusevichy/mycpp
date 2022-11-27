using militreg_lite.BLL.DTO;
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
    /// Логика взаимодействия для AddToDict.xaml
    /// </summary>
    public partial class AddToDict : Window
    {
        public AddToDict()
        {
            InitializeComponent();
        }
        public AddToDict(string name):this()
        {
            tbName.Text = name;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbName.Text))
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Поле обов'язкове для заповнення!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult=false;
        }
    }
}
