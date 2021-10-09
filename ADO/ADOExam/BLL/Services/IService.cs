using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IService<T> where T:BaseDTO
    {
        T GetById(int id);

        List<T> GetAll();

        void Create(T dto);

        void Delete(int id);

        void Update(T dto);
    }
}
