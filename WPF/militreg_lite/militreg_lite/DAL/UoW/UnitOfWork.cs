using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using militreg_lite.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        DatabaseContext context = new DatabaseContext();
        private Lazy<IRepository<int, Gender>> genderRepository;
        public IRepository<int, Gender> GenderRepository => genderRepository.Value;
        private Lazy<IRepository<int, Militarist>> militaristRepository;
        public IRepository<int, Militarist> MilitaristRepository => militaristRepository.Value;
        private Lazy<IRepository<int, Pidrozdil>> pidrozdilRepository;
        public IRepository<int, Pidrozdil> PidrozdilRepository => pidrozdilRepository.Value;
        private Lazy<IRepository<int, Posada>> posadaRepository;
        public IRepository<int, Posada> PosadaRepository => posadaRepository.Value;
        private Lazy<IRepository<int, PrizivType>> prizivTypeRepository;
        public IRepository<int, PrizivType> PrizivTypeRepository => prizivTypeRepository.Value;
        private Lazy<IRepository<int, Rtck>> rtckRepository;
        public IRepository<int, Rtck> RtckRepository => rtckRepository.Value;
        private Lazy<IRepository<int, Ubd>> ubdRepository;
        public IRepository<int, Ubd> UbdRepository => ubdRepository.Value;
        private Lazy<IRepository<int, Vos>> vosRepository;
        public IRepository<int, Vos> VosRepository => vosRepository.Value;
        private Lazy<IRepository<int, Zvan>> zvanRepository;
        public IRepository<int, Zvan> ZvanRepository => zvanRepository.Value;
        private Lazy<IRepository<int, User>> userRepository;
        public IRepository<int, User> UserRepository => userRepository.Value;

        public UnitOfWork()
        {
            context.Database.EnsureCreated();
            genderRepository = new Lazy<IRepository<int, Gender>>(() => new GenderRepository(context));
            militaristRepository = new Lazy<IRepository<int, Militarist>>(() => new MilitaristRepository(context));
            pidrozdilRepository = new Lazy<IRepository<int, Pidrozdil>>(() => new PidrozdilRepository(context));
            posadaRepository = new Lazy<IRepository<int, Posada>>(() => new PosadaRepository(context));
            prizivTypeRepository = new Lazy<IRepository<int, PrizivType>>(() => new PrizivTypeRepository(context));
            rtckRepository = new Lazy<IRepository<int, Rtck>>(() => new RtckRepository(context));
            ubdRepository = new Lazy<IRepository<int, Ubd>>(() => new UbdRepository(context));
            userRepository = new Lazy<IRepository<int, User>>(() => new UserRepository(context));
            vosRepository = new Lazy<IRepository<int, Vos>>(() => new VosRepository(context));
            zvanRepository = new Lazy<IRepository<int, Zvan>>(() => new ZvanRepository(context));
        }

        private bool disposed = false;

        public void Save()
        {
            context.SaveChanges();
        }
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
