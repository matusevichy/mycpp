using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AuthorDTO:BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime Birth { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
