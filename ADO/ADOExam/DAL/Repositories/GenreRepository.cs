using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GenreRepository:BaseRepository<int, Genre>
    {
        public void Update (Genre genre)
        {
            var entity = Table.FirstOrDefault(e => e.Id == genre.Id);
            entity.Name = genre.Name;
            Save();
        }
    }
}
