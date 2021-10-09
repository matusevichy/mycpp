using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Entities
{
    [Table(Name = "Genres"), Serializable]
    public class Genre
    {
        public Genre()
        {
        }

        public Genre(Genre genre)
        {
            this.Id = genre.Id;
            this.Name = genre.Name;
        }

        [Column(IsPrimaryKey =true,IsDbGenerated =true)]
        public int Id { get; set; }
        [Column]
        public string Name { get; set; }
    }
}
