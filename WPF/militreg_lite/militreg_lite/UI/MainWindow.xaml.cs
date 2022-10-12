using Ionic.Zip;
using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using militreg_lite.DAL.Repositories;
using militreg_lite.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace militreg_lite.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel viewModel;
        UserDTO user;
        public MainWindow()
        {
            viewModel = new MainWindowViewModel();
            AuthForm authForm = new AuthForm(viewModel);
            var authDialogResult = authForm.ShowDialog();
            if (authDialogResult == true)
            {
                InitializeComponent();
                user = authForm.User;
                DataContext = viewModel;
            }
            else
            {
                this.Loaded += MainWindow_Loaded;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            AddMilitaristWindow addWindow = new AddMilitaristWindow(viewModel, new MilitaristDTO());
            var result = addWindow.ShowDialog();
            if (result == true)
            {
                  viewModel.Militarists.Add(addWindow.militarist);
            }
        }

        private void ButtonEd_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                AddMilitaristWindow addWindow = new AddMilitaristWindow(viewModel, new MilitaristDTO(DG.SelectedItem as MilitaristDTO));
                var result = addWindow.ShowDialog();
                if (result == true)
                {
                    var index = DG.SelectedIndex;
                    viewModel.Militarists.RemoveAt(index);
                    viewModel.Militarists.Insert(index, addWindow.militarist);
                }
            }
        }

        private void ButtonRM_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedIndex != -1)
            {
                var result = MessageBox.Show("Ви дійсно бажаєте видалити цей запис?", "Видалення запису", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    viewModel.Militarists.RemoveAt(DG.SelectedIndex);
                }
            }
        }

        private void DG_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ButtonEd_Click(sender, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            var txtFile = "export.txt";
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "export"; // Default file name
            dialog.DefaultExt = ".zip"; // Default file extension
            dialog.Filter = "Zip archive (.zip)|*.zip"; // Filter files by extension
            if (dialog.ShowDialog() == true)
            {
                using (var file = File.CreateText(txtFile))
                {
                    foreach (var arr in viewModel.Militarists.ToList())
                    {
                        file.WriteLine($"{arr.BirthDay}|{ arr.DateBegin}|{arr.DateEnd}|{arr.GenderId}|{arr.Oklad}|{arr.Osvita}|{arr.Pib}|{arr.PidrozdilId}|{arr.PosadaId}|{arr.PrizivTypeId}|{arr.RtckId}|{arr.UbdId}|{arr.VosId}|{arr.ZvanFactId}|{arr.ZvanShtatId}");
                    }
                }
                using (ZipFile zipFile = new ZipFile())
                {
                    zipFile.Password = "pass";
                    zipFile.AddFile(txtFile);
                    zipFile.Save(dialog.FileName);
                }
                File.Delete(txtFile);
            }

        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            viewModel = new MainWindowViewModel();
        }

        private void SetUI()
        {
             
        }

        private void miUser_Click(object sender, RoutedEventArgs e)
        {
            UsersWindow usersWindow = new UsersWindow(viewModel, user);
            usersWindow.ShowDialog();
        }

        private void miDict_Click(object sender, RoutedEventArgs e)
        {
            DictionariesWindow dictionariesWindow = new DictionariesWindow(viewModel, user);
            var result = dictionariesWindow.ShowDialog();
        }
    }
}
