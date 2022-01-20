using Less1_hw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.DAL.Repositories
{
    public class WorkerRepository : BaseRepository<int, Worker>
    {
        public WorkerRepository(DatabaseContext db) : base(db)
        {
        }
    }
}
