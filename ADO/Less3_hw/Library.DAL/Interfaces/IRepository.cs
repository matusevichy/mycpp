using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        T Get(int id);
        List<T> GetAll();
        void Delete(int id);
    }
}
