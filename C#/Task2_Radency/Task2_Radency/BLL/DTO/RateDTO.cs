using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2_Radency.BLL.DTO
{
    public class RateDTO:BaseDTO
    {
        public int BookId { get; set; }
        public byte Score { get; set; }
    }
}
