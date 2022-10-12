using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Radency.BLL.DTO
{
    public class ReviewDTO:BaseDTO
    {
        public int BookId { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
    }
}
