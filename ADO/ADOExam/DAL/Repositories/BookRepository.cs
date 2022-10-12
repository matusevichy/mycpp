using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity
;
namespace DAL.Repositories
{
    public class BookRepository:BaseRepository<int, Book>
    {
        public void Update(Book book)
        {
            var entity = Table.FirstOrDefault(e => e.Id == book.Id);
            entity.Name = book.Name;
            entity.AuthorId = book.AuthorId;
            entity.BasePrice = book.BasePrice;
            entity.CreatorId = book.CreatorId;
            entity.DateCreate = book.DateCreate;
            entity.GenreId = book.GenreId;
            entity.Pages = book.Pages;
            entity.PrevBookId = book.PrevBookId;
            entity.Price = book.Price;
            Save();
        }
        public override IEnumerable<Book> GetAll()
        {
            var books = Table.
                Include(b => b.Author).
                Include(b => b.Creator).
                Include(b => b.Genre).
                Include(b => b.PrevBook).
                ToList();
            return books;
        }
        public override Book GetById(int id)
        {
            var book = Table.
                Include(b => b.Author).
                Include(b => b.Creator).
                Include(b => b.Genre).
                Include(b => b.PrevBook).
                FirstOrDefault(b => b.Id == id);
            return book;
        }
        public IEnumerable<Book> GetLatest(string offset)
        {
            var prevDate = SaleRepository.PrevDate(offset);
            var books = Table.
                Include(b => b.Author).
                Include(b => b.Creator).
                Include(b => b.Genre).
                Include(b => b.PrevBook).
                Where(b => b.Created <= DateTime.Now && b.Created > prevDate).
                ToList();
            return books;
        }

        public IEnumerable<Book> GetBooksOfListBookId(List<int> ids)
        {
            var books = Table.
            Include(b => b.Author).
            Include(b => b.Creator).
            Include(b => b.Genre).
            Include(b => b.PrevBook).
            Where(b => ids.Contains(b.Id)).
            ToList();
            return books;
        }

        public IEnumerable<Book> GetByAuthorId(int id)
        {
            var books = Table.
                Include(b => b.Author).
                Include(b => b.Creator).
                Include(b => b.Genre).
                Include(b => b.PrevBook).
                Where(b => b.AuthorId == id).
                ToList();
            return books;
        }

        public IEnumerable<Book> GetByGenreId(int id)
        {
            var books = Table.
                Include(b => b.Author).
                Include(b => b.Creator).
                Include(b => b.Genre).
                Include(b => b.PrevBook).
                Where(b => b.GenreId == id).
                ToList();
            return books;
        }
    }
}
