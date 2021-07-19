using Library.BLL.DTO.Database;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Interfaces
{
    public interface IService<T> where T:BaseDTO
    {
        T FindById(int id);

        List<T> GetAll();

        void Create(T dto);

        void Delete(int id);
    }
}

