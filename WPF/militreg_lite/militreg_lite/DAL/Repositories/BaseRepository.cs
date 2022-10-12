using Microsoft.EntityFrameworkCore;
using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Repositories
{
    public class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        DatabaseContext context;
        protected DbSet<TValue> Table => context.Set<TValue>();

        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public virtual List<TValue> GetAll()
        {
            return Table.ToList();
        }
        public virtual void Add(TValue value)
        {
            Table.Add(value);
            Save();
        }

        private void Save()
        {
            context.SaveChanges();
        }

        public void Update(TValue value)
        {
            Table.Attach(value);
            context.Entry(value).State=EntityState.Modified;
            Save();
        }

        public void Remove(int id)
        {
            var entity = Table.FirstOrDefault(e => e.Id==id);
            Table.Remove(entity);
            Save();
        }
    }
}
