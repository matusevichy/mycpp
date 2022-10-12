using AutoMapper;
using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Entities;
using militreg_lite.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.Services.Services
{
    public class ZvanService : BaseService, IService<ZvanDTO>
    {
        public ZvanService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(ZvanDTO dto)
        {
            unitOfWork.ZvanRepository.Add(mapper.Map<Zvan>(dto));
        }

        public List<ZvanDTO> GetAll()
        {
            var zvans = unitOfWork.ZvanRepository.GetAll();
            return mapper.Map<List<ZvanDTO>>(zvans);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ZvanDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
