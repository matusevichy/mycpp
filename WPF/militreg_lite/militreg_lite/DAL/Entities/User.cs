using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Entities
{
    public class User:BaseEntity<int>
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
        public virtual Rtck Rtck { get; set; }
        public User(User user)
        {
            Login=user.Login;
            Password=user.Password;
            Role=user.Role;
            RtckId=user.RtckId;
            Rtck=user.Rtck;
        }

        public User()
        {
        }
    }
}
