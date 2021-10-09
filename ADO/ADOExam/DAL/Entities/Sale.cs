using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Sale: BaseEntity<int>
    {
        public int? BookId { get; set; }
        public Book Book { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public int Count { get; set; }
    }
}
