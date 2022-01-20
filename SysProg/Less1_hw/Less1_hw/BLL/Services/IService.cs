using Less1_hw.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.BLL.Services
{
    public interface IService<T> where T:BaseDTO
    {
        T Get(int id);
        List<T> GetAll();
    }
}
