using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GenreDTO:BaseDTO
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
