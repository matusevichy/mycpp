using Less1_hw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        DatabaseContext context = DatabaseContext.Create();
        private Lazy<IRepository<int, Worker>> workerRepository;
        public IRepository<int, Worker> WorkerRepository => workerRepository.Value;

        public UnitOfWork()
        {
            workerRepository = new Lazy<IRepository<int, Worker>>(() => new WorkerRepository(context));
        }

        public void Save()
        {
            context.SaveChanges();
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
    }
}
