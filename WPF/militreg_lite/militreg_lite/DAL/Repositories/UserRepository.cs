using Microsoft.EntityFrameworkCore;
using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Repositories
{
    public class UserRepository : BaseRepository<int, User>
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
        public override void Add(User value)
        {
            value.Rtck = null;
            base.Add(value);
        }
        public override List<User> GetAll()
        {
            return Table.Include(u => u.Rtck).ToList();
        }
        public User GetByName(string name)
        {
            return Table.FirstOrDefault(u => u.Login==name);
        }
    }
}
