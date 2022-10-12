using AcademyApp.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AcademyApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AcademyContext Db { get; set; }
        ObservableCollection<Student> Students { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoadData()
        {
            await Task.Run(() => Db = new AcademyContext());
            Students = new ObservableCollection<Student>(Db.Students);
            StudentsGrid.ItemsSource = Students;
        }

        private void Load_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void Load_Executed(object sender, ExecutedRoutedEventArgs e) => LoadData();
    }

    public static class AppCommands
    {
        public static readonly RoutedUICommand Load = new RoutedUICommand
        (
            "Load",
            "Load",
            typeof(AppCommands),
            new InputGestureCollection()
            {
                        new KeyGesture(Key.L, ModifierKeys.Control)
            }
        );
    }
}