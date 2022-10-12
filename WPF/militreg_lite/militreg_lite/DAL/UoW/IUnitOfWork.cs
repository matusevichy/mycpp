using militreg_lite.DAL.Entities;
using militreg_lite.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.UoW
{
    public interface IUnitOfWork
    {
        IRepository<int, Gender> GenderRepository { get; }
        IRepository<int, Militarist> MilitaristRepository { get; }
        IRepository<int, Pidrozdil> PidrozdilRepository { get; }
        IRepository<int, Posada> PosadaRepository { get; }
        IRepository<int, PrizivType> PrizivTypeRepository { get; }
        IRepository<int, Rtck> RtckRepository { get; }
        IRepository<int, Ubd> UbdRepository { get; }
        IRepository<int, User> UserRepository { get; }
        IRepository<int, Vos> VosRepository { get; }
        IRepository<int, Zvan> ZvanRepository { get; }
    }
}
