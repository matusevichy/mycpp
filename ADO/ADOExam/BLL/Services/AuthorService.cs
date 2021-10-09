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
    public class AuthorService : BaseService, IService<AuthorDTO>
    {
        AuthorRepository repository = new AuthorRepository();
        public void Create(AuthorDTO dto)
        {
            repository.Create(mapper.Map<Author>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<AuthorDTO> GetAll()
        {
            List<Author> authors = (List<Author>)repository.GetAll();
            return mapper.Map<List<AuthorDTO>>(authors);
        }

        public AuthorDTO GetById(int id)
        {
            Author author = repository.GetById(id);
            return mapper.Map<AuthorDTO>(author);
        }

        public void Update(AuthorDTO dto)
        {
            repository.Update(mapper.Map<Author>(dto));
        }
    }
}
