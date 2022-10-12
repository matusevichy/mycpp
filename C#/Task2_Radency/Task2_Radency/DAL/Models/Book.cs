using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Radency.DAL.Models
{
    public class Book: BaseModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
