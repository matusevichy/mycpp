using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AuthorRepository:BaseRepository<int, Author>
    {
        public void Update (Author author)
        {
            var entity = Table.FirstOrDefault(e => e.Id == author.Id);
            entity.FirstName = author.FirstName;
            entity.LastName = author.LastName;
            entity.MiddleName = author.MiddleName;
            entity.Birth = author.Birth;
            Save();
        }
    }
}
