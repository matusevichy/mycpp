using militreg_lite.BLL.DTO;
using militreg_lite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        MainWindowViewModel viewModel;
        public UserDTO user;

        public AddUserWindow(MainWindowViewModel viewModel, UserDTO user)
        {
            this.viewModel = viewModel;
            this.user = user;
            InitializeComponent();
            DataContext = user;
            cbRtck.ItemsSource = viewModel.Rtcks;
        }

        private void tbRole_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^1-3]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {

            if (user.Login == null || user.Password == null || user.Role == 0 || user.Rtck == null)
            {
                MessageBox.Show("Всі поля обов'язкові для заповнення!!!", "Помилка заповнення", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                user.RtckId = user.Rtck.Id;
                DialogResult = true;
            }
        }
    }
}
