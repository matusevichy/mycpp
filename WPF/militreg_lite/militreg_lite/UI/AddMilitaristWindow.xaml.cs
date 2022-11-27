using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Entities;
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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddMilitaristWindow : Window
    {
        MainWindowViewModel viewModel;
        UserDTO user;
        
        public MilitaristDTO militarist;
        public AddMilitaristWindow(MainWindowViewModel viewModel, MilitaristDTO militarist, UserDTO user)
        {
            if (militarist.Rtck == null)
            {
                militarist.Rtck = user.Rtck;
            }
            this.viewModel = viewModel;
            this.militarist = militarist;
            this.user = user;
            InitializeComponent();
            this.DataContext = this.militarist;
            //cbRtck.DataContext = cbPidrozdil.DataContext = cbPosada.DataContext = cbVos.DataContext = cbZvanFact.DataContext = cbZvanShtat.DataContext = cbUbd.DataContext = cbPrizivType.DataContext = cbGender.DataContext = this;
            cbRtck.ItemsSource = viewModel.Rtcks;
            //cbRtck.SelectedItem = militarist.Rtck;
            cbPidrozdil.ItemsSource = viewModel.Pidrozdils;
            //cbPidrozdil.SelectedItem = militarist.Pidrozdil;
            cbPosada.ItemsSource = viewModel.Posadas;
            //cbPosada.SelectedItem = militarist.Posada;
            cbVos.ItemsSource = viewModel.Voss;
            //cbVos.SelectedItem = militarist.Vos;
            cbZvanFact.ItemsSource = viewModel.Zvans;
            //cbZvanFact.SelectedItem = militarist.ZvanFact;
            cbZvanShtat.ItemsSource = viewModel.Zvans;
            //cbZvanShtat.SelectedItem = militarist.ZvanShtat;
            cbUbd.ItemsSource = viewModel.Ubds;
            //cbUbd.SelectedItem = militarist.Ubd;
            cbPrizivType.ItemsSource = viewModel.PrizivTypes;
            //cbPrizivType.SelectedItem = militarist.PrizivType;
            cbGender.ItemsSource = viewModel.Genders;
            ;
            //cbGender.SelectedItem = militarist.Gender;
            //cbGender.IsSynchronizedWithCurrentItem = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            if (militarist.Gender == null || militarist.Oklad == 0 || militarist.Osvita == null || militarist.Pib == null || militarist.Pidrozdil == null || militarist.Posada == null || militarist.PrizivType == null || militarist.Rtck == null || militarist.Ubd == null || militarist.Vos == null || militarist.ZvanFact == null || militarist.ZvanShtat == null)
            {
                MessageBox.Show("Всі поля обов'язкові для заповнення!!!", "Помилка заповнення", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                SetId();
                DialogResult = true;
            }
        }


        private void SetId()
        {
            militarist.GenderId = militarist.Gender.Id;
            militarist.PidrozdilId = militarist.Pidrozdil.Id;
            militarist.PosadaId = militarist.Posada.Id;
            militarist.PrizivTypeId = militarist.PrizivType.Id;
            militarist.RtckId = militarist.Rtck.Id;
            militarist.UbdId = militarist.Ubd.Id;
            militarist.VosId = militarist.Vos.Id;
            militarist.ZvanFactId = militarist.ZvanFact.Id;
            militarist.ZvanShtatId = militarist.ZvanShtat.Id;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
