using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Book:BaseEntity<int>
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public int? CreatorId { get; set; }
        public Creator Creator { get; set; }
        public DateTime DateCreate { get; set; }
        public double BasePrice { get; set; }
        public double Price { get; set; }
        public int? PrevBookId { get; set; }
        public Book PrevBook { get; set; }
        public int CountInStore { get; set; }
        public List<Promo> Promos { get; set; }
    }
}
