 using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<TKey, TValue> : IRepository<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected DatabaseContext context;
        protected DbSet<TValue> Table => context.Set<TValue>();
        public BaseRepository()
        {
            context = DatabaseContext.Create();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public virtual IEnumerable<TValue> GetAll()
        {
            return Table.ToList();
        }

        public virtual TValue GetById(int id)
        {
            return Table.FirstOrDefault(t => t.Id == id);
        }

        public void Remove(int id)
        {
            var entity = Table.FirstOrDefault(e => e.Id == id);
            Table.Remove(entity);
            Save();
        }
        public void Create(TValue entity)
        {
            Table.Add(entity);
            Save();
        }
    }
}
