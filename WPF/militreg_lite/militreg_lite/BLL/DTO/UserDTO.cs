using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.DTO
{
    public class UserDTO:BaseDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
        int? rtckId;
        public int? RtckId
        {
            get
            {
                return rtckId;
            }
            set
            {
                rtckId = value;
                OnPropertyChanged(nameof(RtckId));
            }
        }
        public virtual RtckDTO Rtck { get; set; }
        public UserDTO(UserDTO user)
        {
            Id = user.Id;
            Login = user.Login;
            Password = user.Password;
            Role = user.Role;
            RtckId = user.RtckId;
            Rtck = user.Rtck;
        }

        public UserDTO()
        {
        }
    }
}
