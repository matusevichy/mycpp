using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BookDTO:BaseDTO
    {
        public string Name { get; set; }
        public int Pages { get; set; }
        public int? AuthorId { get; set; }
        public AuthorDTO Author { get; set; }
        public int? GenreId { get; set; }
        public GenreDTO Genre { get; set; }
        public int? CreatorId { get; set; }
        public CreatorDTO Creator { get; set; }
        public DateTime DateCreate { get; set; } = DateTime.Now;
        public double BasePrice { get; set; }
        public double Price { get; set; }
        public int? PrevBookId { get; set; }
        public BookDTO PrevBook { get; set; }

        public override string ToString()
        {
            return $"{Name} Author: {Author}";
        }

        public override bool Equals(object obj)
        {
            return this.Id == (obj as BookDTO)?.Id;
        }
    }
}
