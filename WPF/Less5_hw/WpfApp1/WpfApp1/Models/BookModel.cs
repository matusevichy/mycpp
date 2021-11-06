using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class BookModel : IPrototype<BookModel>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title = string.Empty;
        private string _description = string.Empty;
        private decimal _price = 0.0m;
        private string _cover = string.Empty;

        public int Id { get; set; }
        public string Title
        {
            get => _title;
            set
            {
                if (!value.Equals(_title))
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        public string Description
        {
            get => _description;
            set
            {
                if (!value.Equals(_description))
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }
        public decimal Price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPropertyChanged(nameof(Price));
                }
            }
        }
        public string Cover
        {
            get => _cover;
            set
            {
                if (!value.Equals(_cover))
                {
                    _cover = value;
                    OnPropertyChanged(nameof(Cover));
                }
            }
        }


        public BookModel Clone()
        {
            return new BookModel
            {
                Id = Id,
                Cover = Cover,
                Description = Description,
                Price = Price,
                Title = Title
            };
        }

        public void Copy(BookModel from)
        {
            Id = from.Id;
            Title = from.Title;
            Description = from.Description;
            Price = from.Price;
            Cover = from.Cover;
        }
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
