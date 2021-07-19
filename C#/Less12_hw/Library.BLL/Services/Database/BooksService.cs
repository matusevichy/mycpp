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
    public class BooksService: BaseService, IService<BookDTO>
    {
        BookRepository bookRepository = new BookRepository();

        public void Create(BookDTO dto)
        {
            bookRepository.Create(mapper.Map<Book>(dto));
        }

        public void Delete(int id)
        {
            bookRepository.Delete(id);
        }

        public BookDTO FindById(int id)
        {
            var srcBook = bookRepository.Get(id);
            return mapper.Map<BookDTO>(srcBook);
        }

        public List<BookDTO> GetAll()
        {
            List<Book> books = bookRepository.GetAll();
            return mapper.Map<List<BookDTO>>(books);
        }
    }
}
