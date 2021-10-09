using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<TKey, TValue> :IDisposable
        where TKey:struct
        where TValue:BaseEntity<TKey>
    {
        IEnumerable<TValue> GetAll();
        TValue GetById(int id);
        void Remove(int id);
        void Save();
    }
}
