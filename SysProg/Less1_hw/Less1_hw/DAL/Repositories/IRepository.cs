using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Less1_hw.DAL.Entities;

namespace Less1_hw.DAL.Repositories
{
    public interface IRepository<TKey,TValue>
        where TKey:struct
        where TValue:BaseEntity<TKey>
    {
        TValue Get(TKey id);
        List<TValue> GetAll();
    }
}
