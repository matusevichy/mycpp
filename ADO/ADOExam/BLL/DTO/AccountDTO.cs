using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class AccountDTO: BaseDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }
        public bool IsAdmin { get; set; }
    }
}
