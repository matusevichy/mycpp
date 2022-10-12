using militreg_lite.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.Services.Services
{
    public interface IService<T> where T:BaseDTO
    {
        List<T> GetAll();
        void Add(T dto);
        void Update(T dto);
        void Remove(int id);
    }
}
