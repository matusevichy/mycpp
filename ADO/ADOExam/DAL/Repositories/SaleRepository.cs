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

        public int GetMostPopularGenreId()
        {
            var genre = Table.Include(s => s.Book).Select(s => new { Id = s.Book.GenreId, Count = s.Count}).GroupBy(s => s.Id).Select(s=>new {Id=s.Key, Sum = s.Sum(g=>g.Count) }).ToList();
            var max = genre.Select(g => g.Sum).Max();
            var result = genre.FirstOrDefault(g => g.Sum == max);
            return (int)result.Id;
        }
        public int GetMostPopularAuthorId()
        {
            var genre = Table.Include(s => s.Book).Select(s => new { Id = s.Book.AuthorId, Count = s.Count }).GroupBy(s => s.Id).Select(s => new { Id = s.Key, Sum = s.Sum(g => g.Count) }).ToList();
            var max = genre.Select(g => g.Sum).Max();
            var result = genre.FirstOrDefault(g => g.Sum == max);
            return (int)result.Id;
        }
    }
}
