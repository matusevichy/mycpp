using militreg_lite.BLL.DTO;
using militreg_lite.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<object> currentDict;

        public DictionariesWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            DG.Columns.Add(new DataGridTextColumn()
            {
                Header = "Назва",
                Binding = new Binding("Name")
            }) ;
        }

        public DictionariesWindow(MainWindowViewModel viewModel, UserDTO user):this()
        {
            this.viewModel = viewModel;
            this.user = user;
            SetUI();
            lbDict.SelectedIndex = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e != null)
            {
                switch ((e.AddedItems[0] as ListBoxItem).Name)
                {
                    case "lbiPidrozdil":
                        DG.ItemsSource = viewModel.Pidrozdils;
                        break;
                    case "lbiPosada":
                        DG.ItemsSource = viewModel.Posadas;
                        break;
                    case "lbiPrizivType":
                        DG.ItemsSource = viewModel.PrizivTypes;
                        break;
                    case "lbiRtck":
                        DG.ItemsSource = viewModel.Rtcks;
                        break;
                    case "lbiUbd":
                        DG.ItemsSource = viewModel.Ubds;
                        break;
                    case "lbiVos":
                        DG.ItemsSource = viewModel.Voss;
                        break;
                    case "lbiZvan":
                        DG.ItemsSource = viewModel.Zvans;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                DG.ItemsSource = null;
                DG.ItemsSource = viewModel.Pidrozdils;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedIndex != -1)
            {
                AddToDict addToDict = new AddToDict(((IDict)DG.SelectedItem).Name);
                if (addToDict.ShowDialog() == true)
                {
                    var list = (IList)DG.ItemsSource;
                    var elementType = list.GetType().GetGenericArguments()[0];
                    var newElement = Activator.CreateInstance(elementType) as IDict;
                    newElement.Id = (DG.SelectedItem as IDict).Id;
                    newElement.Name = addToDict.tbName.Text;
                    var index = DG.SelectedIndex;
                    list[index] = newElement;
                    if (lbDict.SelectedIndex == 0)
                    {
                        ListBox_SelectionChanged(lbDict, null);
                    }
                    else
                    {
                        lbDict.SelectedIndex = 0;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddToDict addToDict = new AddToDict();
            if (addToDict.ShowDialog() == true)
            {
                var list = (IList)DG.ItemsSource;
                var elementType = list.GetType().GetGenericArguments()[0];
                var newElement = Activator.CreateInstance(elementType);
                var id = list.Cast<IDict>().Max(i => i.Id);
                (newElement as IDict).Id = id+1;
                (newElement as IDict).Name = addToDict.tbName.Text;
                list.Add(newElement as IDict);                
                
            }
        }
        void SetUI()
        {
            if (new[] { 1, 2 }.Contains(user.Role))
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
