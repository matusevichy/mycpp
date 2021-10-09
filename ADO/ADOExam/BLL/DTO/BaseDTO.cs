using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime Cteated { get; set; } = DateTime.Now;
    }
}
