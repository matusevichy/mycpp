using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CreatorRepository:BaseRepository<int, Creator>
    {
        public void Update (Creator creator)
        {
            var entity = Table.FirstOrDefault(e => e.Id == creator.Id);
            entity.Name = creator.Name;
            Save();
        }
    }
}
