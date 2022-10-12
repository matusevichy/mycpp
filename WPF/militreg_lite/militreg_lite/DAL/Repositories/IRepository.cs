using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Repositories
{
    public interface IRepository<TKey, TValue>
        where TKey:struct
        where TValue:BaseEntity<TKey>
    {
        List<TValue> GetAll();
        void Add(TValue value);
        void Update(TValue value);
        void Remove(int id);
    }
}
