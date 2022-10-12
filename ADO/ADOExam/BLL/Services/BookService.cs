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
    public class BookService : BaseService, IService<BookDTO>
    {
        BookRepository repository = new BookRepository();
        public void Create(BookDTO dto)
        {
            repository.Create(mapper.Map<Book>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<BookDTO> GetAll()
        {
            List<Book> books = (List<Book>)repository.GetAll();
            return mapper.Map<List<BookDTO>>(books);
        }

        public BookDTO GetById(int id)
        {
            var book = repository.GetById(id);
            return mapper.Map<BookDTO>(book);
        }

        public void Update(BookDTO dto)
        {
            repository.Update(mapper.Map<Book>(dto));
        }
        public List<BookDTO> GetLatest(string offset)
        {
            List<Book> books = (List<Book>)repository.GetLatest(offset);
            return mapper.Map<List<BookDTO>>(books);
        }
        public IEnumerable<BookDTO> GetBooksOfListBookId(List<int> ids)
        {
            List<Book> books = (List<Book>)repository.GetBooksOfListBookId(ids);
            return mapper.Map<List<BookDTO>>(books);
        }
        public List<BookDTO> GetBooksByAuthorId(int id)
        {
            List<Book> books = (List<Book>)repository.GetByAuthorId(id);
            return mapper.Map<List<BookDTO>>(books);
        }
        public List<BookDTO> GetBooksByGenreId(int id)
        {
            List<Book> books = (List<Book>)repository.GetByGenreId(id);
            return mapper.Map<List<BookDTO>>(books);
        }
    }
}
