using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class SaleDTO: BaseDTO
    {
        public int? BookId { get; set; }
        public BookDTO Book { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int Count { get; set; }
    }
}
