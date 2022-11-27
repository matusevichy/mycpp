using Ionic.Zip;
using Microsoft.Win32;
using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using militreg_lite.DAL.Repositories;
using militreg_lite.ViewModels;
using Newtonsoft.Json;
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
using Path = System.IO.Path;

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
                SetUI();
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
            AddMilitaristWindow addWindow = new AddMilitaristWindow(viewModel, new MilitaristDTO(), user);
            var result = addWindow.ShowDialog();
            if (result == true)
            {
                var id = viewModel.Militarists.Max(m => m.Id);
                var militarist = addWindow.militarist;
                militarist.Id = id+1;
                viewModel.Militarists.Add(militarist);
            }
        }

        private void ButtonEd_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                AddMilitaristWindow addWindow = new AddMilitaristWindow(viewModel, new MilitaristDTO(DG.SelectedItem as MilitaristDTO), user);
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

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            var txtFile = "export.json";
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "export"; // Default file name
            dialog.DefaultExt = ".zip"; // Default file extension
            dialog.Filter = "Zip archive (.zip)|*.zip"; // Filter files by extension
            if (dialog.ShowDialog() == true)
            {
                using (var file = File.CreateText(txtFile))
                {
                    //foreach (var arr in viewModel.Militarists.ToList())
                    //{
                    //    file.WriteLine($"{arr.BirthDay}|{arr.DateBegin}|{arr.DateEnd}|{arr.GenderId}|{arr.Oklad}|{arr.Osvita}|{arr.Pib}|{arr.PidrozdilId}|{arr.PosadaId}|{arr.PrizivTypeId}|{arr.RtckId}|{arr.UbdId}|{arr.VosId}|{arr.ZvanFactId}|{arr.ZvanShtatId}");
                    //}
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, viewModel.Militarists);
                }
                using (ZipFile zipFile = new ZipFile())
                {
                    zipFile.Password = "pass";
                    zipFile.AddFile(txtFile);
                    zipFile.Save(dialog.FileName);
                }
                File.Delete(txtFile);
            }
            ;
        }

        private void Button_Refresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        void Refresh()
        {
            DataContext = null;
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;
        }
        private void SetUI()
        {
            if (new[] { 1, 2 }.Contains(user.Role))
            {
                btnImport.IsEnabled = true;
            }
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

        private void Button_Import_Click(object sender, RoutedEventArgs e)
        {
            List<MilitaristDTO> militarists;
            ImportWindow importWindow = new ImportWindow(viewModel);
            var result = importWindow.ShowDialog();
            if (result == true)
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.FileName = "export"; // Default file name
                dialog.DefaultExt = ".zip"; // Default file extension
                dialog.Filter = "Zip archive (.zip)|*.zip"; // Filter files by extension
                if (dialog.ShowDialog() == true)
                {
                    using (ZipFile zipfile = ZipFile.Read(dialog.FileName))
                    {
                        var target = @"c:\temp\militreg";
                        zipfile.Password = "pass";
                        var res = zipfile.ContainsEntry("export.json");
                        if (res)
                        {
                            zipfile.ExtractAll(target, ExtractExistingFileAction.OverwriteSilently);
                        }
                        var tmpFile = Path.Combine(target, "export.json");
                        using (var file = File.OpenText(tmpFile))
                        {
                            JsonSerializer serializer = new JsonSerializer();

                            militarists = (List<MilitaristDTO>)serializer.Deserialize(file, typeof(List<MilitaristDTO>));
                            militarists.ForEach(m => m.Id = 0);
                        }
                        if (militarists != null)
                        {
                            var listForDel = viewModel.Militarists.Where(m => m.RtckId == importWindow.Rtck.Id).ToList();
                            foreach (var item in listForDel)
                            {
                                viewModel.Militarists.Remove(item);
                            }
                            foreach (var item in militarists)
                            {
                                viewModel.Militarists.Add(item);
                            }
                        }
                        File.Delete(tmpFile);
                        Refresh();
                    }
                }
            }
        }
    }
}
