using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Radency.DAL.Models
{
    public class Review: BaseModel
    {
        public int BookId { get; set; }
        public string Message { get; set; }
        public string Reviewer { get; set; }
    }
}
