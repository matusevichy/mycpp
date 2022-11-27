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
    /// Логика взаимодействия для UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
        MainWindowViewModel viewModel;
        UserDTO user;
        public UsersWindow(MainWindowViewModel viewModel, UserDTO user)
        {
            this.viewModel = viewModel;
            this.user = user;
            InitializeComponent();
            this.DataContext = viewModel;
            SetUI();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                AddUserWindow addUserWindow = new AddUserWindow(viewModel, new UserDTO(DG.SelectedItem as UserDTO));
                var result = addUserWindow.ShowDialog();
                if (result == true)
                {
                    var index = DG.SelectedIndex;
                    viewModel.Users.RemoveAt(index);
                    viewModel.Users.Insert(index, addUserWindow.user);
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUserWindow = new AddUserWindow(viewModel, new UserDTO());
            var result = addUserWindow.ShowDialog();
            if (result == true)
            {
                var id = viewModel.Users.Max(x => x.Id);
                var user = addUserWindow.user;
                user.Id = id+1;
                viewModel.Users.Add(user);
            }
        }
        void SetUI()
        {
            if (new[] { 1,2}.Contains(user.Role))
            {
                btnAdd.IsEnabled = btnEdit.IsEnabled = true;
            }
        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnEdit_Click(sender, e);
        }
    }
}
