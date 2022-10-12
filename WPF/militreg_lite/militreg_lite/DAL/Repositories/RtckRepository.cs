using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Repositories
{
    public class RtckRepository : BaseRepository<int, Rtck>
    {
        public RtckRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
