using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository: BaseRepository<int, User>
    {
        public void Update(User user)
        {
            var entity = Table.FirstOrDefault(e => e.Id == user.Id);
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.MiddleName = user.MiddleName;
            entity.Birth = user.Birth;
        }
    }
}
