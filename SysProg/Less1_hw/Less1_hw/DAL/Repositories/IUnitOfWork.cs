using Less1_hw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.DAL.Repositories
{
    public interface IUnitOfWork
    {
        IRepository<int, Worker> WorkerRepository { get; }
    }
}
