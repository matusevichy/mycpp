using Microsoft.Win32;
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
    /// Логика взаимодействия для AuthForm.xaml
    /// </summary>
    public partial class AuthForm : Window
    {
        MainWindowViewModel viewModel;
        public UserDTO User { get; set; }
        public AuthForm(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
            InitializeComponent();
            var currentUserKey = Registry.CurrentUser;
            var militregKey = currentUserKey.CreateSubKey("militreg");
            if (militregKey.GetValue("Login") != null)
            {
                tbLogin.Text = militregKey.GetValue("Login").ToString();
            }
            if (militregKey.GetValue("Password") != null)
            {
                tbPassword.Password = militregKey.GetValue("Password").ToString();
                cbRememberPass.IsChecked = true;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            var user = viewModel.Users.FirstOrDefault(u => u.Login == tbLogin.Text);
            if (user != null)
            {
                if (user.Password == tbPassword.Password)
                {
                    var currentUserKey = Registry.CurrentUser;
                    var militregKey = currentUserKey.CreateSubKey("militreg");
                    militregKey.SetValue("login",tbLogin.Text);
                    if (cbRememberPass.IsChecked == true)
                    {
                        militregKey.SetValue("Password", tbPassword.Password);
                    }
                    else
                    {
                        if (militregKey.GetValue("Password") != null) militregKey.DeleteValue("Password");
                    }
                    User = user;
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Wrong password!");
                }
            }
            else
            {
                MessageBox.Show("Wrong login!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnOk_Click(sender, e);
            }
            if (e.Key == Key.Escape)
            {
                DialogResult = false;
            }
        }
    }
}
