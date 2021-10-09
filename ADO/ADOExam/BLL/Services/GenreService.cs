using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class GenreService : BaseService, IService<GenreDTO>
    {
        GenreRepository repository = new GenreRepository();
        public void Create(GenreDTO dto)
        {
            repository.Create(mapper.Map<Genre>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<GenreDTO> GetAll()
        {
            List<Genre> genres = (List<Genre>)repository.GetAll();
            return mapper.Map<List<GenreDTO>>(genres);
        }

        public GenreDTO GetById(int id)
        {
            Genre genre = repository.GetById(id);
            return mapper.Map<GenreDTO>(genre);
        }

        public void Update(GenreDTO dto)
        {
            repository.Update(mapper.Map<Genre>(dto));
        }
    }
}
