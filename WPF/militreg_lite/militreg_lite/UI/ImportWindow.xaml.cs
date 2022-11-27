using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Entities;
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
    /// Логика взаимодействия для ImportWindow.xaml
    /// </summary>
    public partial class ImportWindow : Window
    {
        MainWindowViewModel viewModel;
        public RtckDTO Rtck { get; set; }
        public ImportWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();
            this.viewModel = viewModel;
            DataContext = this.viewModel;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            if (cbRtck.SelectedIndex !=-1)
            {
                Rtck = (RtckDTO)cbRtck.SelectedItem;
                DialogResult = true;
            }
        }
    }
}
