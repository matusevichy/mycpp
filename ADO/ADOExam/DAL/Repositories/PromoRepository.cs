using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class PromoRepository: BaseRepository<int, Promo>
    {
        public void Update(Promo promo)
        {
            var entity = Table.FirstOrDefault(e => e.Id == promo.Id);
            entity.DateBegin = promo.DateBegin;
            entity.DateEnd = promo.DateEnd;
            entity.Books = promo.Books;
            entity.Name = promo.Name;
            Save();
        }
        public override IEnumerable<Promo> GetAll()
        {
            var promos = Table.Include(p => p.Books).ToList();
            return promos;
        }
        public override Promo GetById(int id)
        {
            var promo = Table.Include(p => p.Books).FirstOrDefault(p => p.Id == id);
            return promo;
        }
        public IEnumerable<Promo> GetOnDate(DateTime date)
        {
            var promos = Table.Include(p => p.Books).Where(p => (date >= p.DateBegin && date <p.DateEnd)).ToList();
            return promos;
        }

    }
}
