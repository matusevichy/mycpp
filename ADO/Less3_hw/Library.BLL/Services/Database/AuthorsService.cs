using AutoMapper;
using Library.BLL.DTO.Database;
using Library.BLL.Interfaces;
using Library.BLL.ModelAutoMapper;
using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services.Database
{
    public class AuthorsService:BaseService, IService<AuthorDTO>
    {
        AuthorRepository authorRepository = new AuthorRepository();

        public void Create(AuthorDTO dto)
        {
            authorRepository.Create(mapper.Map<Author>(dto));
        }

        public void Delete(int id)
        {
            authorRepository.Delete(id);
        }

        public AuthorDTO FindById(int id)
        {
            var srcAuthor = authorRepository.Get(id);
            return mapper.Map<AuthorDTO>(srcAuthor);
        }

        public List<AuthorDTO> GetAll()
        {
            List<Author> authors = authorRepository.GetAll();
            return mapper.Map<List<AuthorDTO>>(authors);
        }
    }
}
