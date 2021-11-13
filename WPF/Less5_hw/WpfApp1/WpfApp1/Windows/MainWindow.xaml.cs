using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfApp1.Models;
using WpfApp1.Windows;
using WpfApp1.Windows.Book;
using WpfApp1.Extensions;

namespace WpfApp1
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _searchText = string.Empty;


        public List<BookModel> Books { get; set; } = new List<BookModel>
        {
            new BookModel
            {
                Id = 1,
                Title = "Title",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Price = 150.3m,
                Cover = "https://clipart-best.com/img/book/book-clip-art-56.png"
            },
            new BookModel
            {
                Id = 2,
                Title = "Title 2",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                Price = 100.3m,
                Cover = "https://clipart-best.com/img/book/book-clip-art-56.png"
            }
        };
        public ObservableCollection<BookModel> ViewBooks { get; set; } = new ObservableCollection<BookModel>();
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (!value.Equals(_searchText))
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                }
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            ViewBooks.AddRange(Books);
        }


        private void ButtonEditBook_Click(object sender, RoutedEventArgs e)
        {
            BookModel book = (sender as Button).DataContext as BookModel;
            EditWindow editWnd = new EditWindow(book);

            if (editWnd.ShowDialog() == true)
            {
                book.Copy(editWnd.Book);
            }
        }

        private void TextBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            string search = tb.Text;

            var filteredBooks = Books.Where(b => (b.Title + b.Description).Contains(search));

            ViewBooks.Clear();
            ViewBooks.AddRange(filteredBooks);
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editWnd = new EditWindow(new BookModel());

            if (editWnd.ShowDialog() == true)
            {
                Books.Add(editWnd.Book);
                ViewBooks.Clear();
                ViewBooks.AddRange(Books);
            }
        }

        private void ButtonDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Do you want delete this record?", "Delete???", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if(result==MessageBoxResult.OK)
            {
                BookModel book = (sender as Button).DataContext as BookModel;
                Books.Remove(book);
                ViewBooks.Clear();
                ViewBooks.AddRange(Books);
            }
        }
    }
}
