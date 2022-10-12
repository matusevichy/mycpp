using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Radency.BLL.DTO
{
    public class BookDTO:BaseDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public int? GenreId { get; set; }
        public GenreDTO Genre { get; set; }
        public List<ReviewDTO> Reviews { get; set; }
    }
}
