using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PromoDTO: BaseDTO
    {
        public string Name { get; set; }
        public DateTime DateBegin { get; set; } = DateTime.Now;
        public DateTime DateEnd { get; set; } = DateTime.Now;
        public List<BookDTO> Books { get; set; } = new List<BookDTO>();
    }
}
