using Library.DAL.DbConnection;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public void Create(Book entity)
        {
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                ctx.GetTable<Book>().InsertOnSubmit(entity);
                ctx.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                var book = ctx.GetTable<Book>().FirstOrDefault(e => e.Id == id);
                ctx.GetTable<Book>().DeleteOnSubmit(book);
                ctx.SubmitChanges();
            }
        }

        public Book Get(int id)
        {
            Book newBook = new Book();
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                var book = ctx.GetTable<Book>().FirstOrDefault(e=>e.Id==id);
                newBook = book.Clone();
                return newBook;
            }
        }

        public Book GetByTitle(string title)
        {
            Book book=null;

            return book;
        }
        public Book GetByGenre(string genre)
        {
            Book book = null;

            return book;
        }
        public List<Book> GetByAuthor(int authorId)
        {
            List<Book> newBooks = new List<Book>();
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                var books = ctx.GetTable<Book>().ToList();
                newBooks.AddRange(books.Select(i => i.Clone()));
                return newBooks;
            }
        }
        public List<Book> GetAll()
        {
            List<Book> newBooks=new List<Book>();
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                var books = ctx.GetTable<Book>().ToList();
                newBooks.AddRange(books.Select(i=>i.Clone()));
               return newBooks;
            }
        }

        public void Update(Book entity)
        {
        }
    }
}
