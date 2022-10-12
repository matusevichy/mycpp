using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Radency.DAL.Models
{
    public class Rate:BaseModel
    {
        public int BookId { get; set; }
        public byte Score { get; set; }
    }
}
