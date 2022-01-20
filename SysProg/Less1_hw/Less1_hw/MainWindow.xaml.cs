using AutoMapper;
using Less1_hw.BLL.Services;
using Less1_hw.DAL.Repositories;
using Less1_hw.Mapper;
using Less1_hw.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Less1_hw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       MainWindowViewModel viewModel;
       public MainWindow()
        {
            InitializeComponent();
            Task task = Task.Run(() =>
            {
                viewModel = new MainWindowViewModel();
            });
            task.Wait();
            DataContext = viewModel;
        }
    }
}
