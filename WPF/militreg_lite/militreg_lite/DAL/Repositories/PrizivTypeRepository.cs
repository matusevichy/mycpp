using militreg_lite.DAL.Databases;
using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Repositories
{
    public class PrizivTypeRepository : BaseRepository<int, PrizivType>
    {
        public PrizivTypeRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
