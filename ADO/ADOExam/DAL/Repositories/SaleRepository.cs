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
    }
}
