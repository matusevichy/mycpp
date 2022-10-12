using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class SaleRepository: BaseRepository<int, Sale>
    {
        public static DateTime PrevDate(string offset)
        {
            DateTime prevDate = DateTime.Now;
            switch (offset)
            {
                case "day":
                    prevDate = prevDate.AddDays(-1);
                    break;
                case "week":
                    prevDate = prevDate.AddDays(-7);
                    break;
                case "month":
                    prevDate = prevDate.AddMonths(-1);
                    break;
                case "year":
                    prevDate = prevDate.AddYears(-1);
                    break;
                default:
                    break;
            }
            return prevDate;
        }
        public override IEnumerable<Sale> GetAll()
        {
            var sales = Table.Include(s => s.Book).Include(s => s.User).ToList();
            return sales;
        }
        public IEnumerable<Sale> GetByBookId(int id)
        {
            var sales = Table.Include(s => s.Book).Include(s => s.User).Where(s => s.BookId == id).ToList();
            return sales;
        }
        public IEnumerable<Sale> GetByUserId(int id)
        {
            var sales = Table.Include(s => s.Book).Include(s => s.User).Where(s => s.UserId == id).ToList();
            return sales;
        }
        public IEnumerable<Sale> GetBySaleDate(DateTime saleDate)
        {
            var sales = Table.Include(s => s.Book).Include(s => s.User).Where(s => s.SaleDate == saleDate).ToList();
            return sales;
        }

        public int GetMostPopularGenreId(string offset)
        {
            int max = 0;
            var prevDate = SaleRepository.PrevDate(offset);
            var genre = Table.Include(s => s.Book).Where(s => s.SaleDate <= DateTime.Now && s.SaleDate > prevDate).Select(s => new { Id = s.Book.GenreId, Count = s.Count}).GroupBy(s => s.Id).Select(s=>new {Id=s.Key, Sum = s.Sum(g=>g.Count) }).ToList();
            if (genre.Count > 0)
            {
                max = genre.Select(g => g.Sum).Max();
                var result = genre.FirstOrDefault(g => g.Sum == max);
                return (int)result.Id;
            }
            else return 0;
        }
        public int GetMostPopularAuthorId(string offset)
        {
            int max = 0;
            var prevDate = SaleRepository.PrevDate(offset);
            var author = Table.Include(s => s.Book).Where(s => s.SaleDate <= DateTime.Now && s.SaleDate > prevDate).Select(s => new { Id = s.Book.AuthorId, Count = s.Count }).GroupBy(s => s.Id).Select(s => new { Id = s.Key, Sum = s.Sum(g => g.Count) }).ToList();
            if (author.Count > 0)
            {
                max = author.Select(g => g.Sum).Max();
                var result = author.FirstOrDefault(g => g.Sum == max);
                return (int)result.Id;
            }
            else return 0;
        }

        public IEnumerable<int> GetMostPopularBooks(string offset)
        {
            int max = 0;
            var prevDate = SaleRepository.PrevDate(offset);
            var books = Table.Include(s => s.Book).Where(s => s.SaleDate <= DateTime.Now && s.SaleDate > prevDate).Select(s => new { Book = s.Book, Count = s.Count }).GroupBy(s => s.Book).Select(s => new { Book = s.Key, Sum = s.Sum(b => b.Count) }).ToList();
            if(books.Count > 0) max = books.Select(b => b.Sum).Max();
            var result = books.FindAll(b => b.Sum == max).Select(b => b.Book.Id).ToList();
            return (IEnumerable<int>)result;
        }
    }
}
