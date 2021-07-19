using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; } = null;
        public int? GenreId { get; set; }
        public int InStock { get; set; }
        public List<Author2Book> Author2Books { get; set; }
        public List<BookOnHands> BooksOnHands { get; set; } = null;
    }
}
