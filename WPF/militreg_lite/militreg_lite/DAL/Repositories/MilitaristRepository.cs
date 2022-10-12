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
    public class MilitaristRepository : BaseRepository<int, Militarist>
    {
        public MilitaristRepository(DatabaseContext context) : base(context)
        {
        }
        public override void Add(Militarist value)
        {
            value.Gender = null;
            value.Pidrozdil = null;
            value.Posada = null;
            value.PrizivType = null;
            value.Rtck = null;
            value.Ubd = null;
            value.Vos = null;
            value.ZvanFact = null;
            value.ZvanShtat = null;
            base.Add(value);
        }
        public override List<Militarist> GetAll()
        {
            var militarists = Table.Include(m=>m.Posada).Include(m=>m.Vos).Include(m=>m.ZvanShtat).Include(m=>m.ZvanFact).Include(m => m.Rtck).Include(m=>m.Gender).Include(m=>m.Pidrozdil).Include(m=>m.Ubd).Include(m=>m.PrizivType).ToList();
            return militarists;
        }
    }
}
