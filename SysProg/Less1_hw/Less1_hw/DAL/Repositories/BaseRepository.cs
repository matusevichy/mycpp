using Less1_hw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.DAL.Repositories
{
    public abstract class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey:struct
        where TValue:BaseEntity<TKey>
    {
        protected DatabaseContext context;

        protected BaseRepository(DatabaseContext db)   
        {
            context = db;
        }

        protected DbSet<TValue> Table => context.Set<TValue>();

        public TValue Get(TKey id)
        {
            throw new NotImplementedException();
        }

        public List<TValue> GetAll()
        {
            return Table.ToList();
        }
    }
}
