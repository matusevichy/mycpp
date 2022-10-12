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
    public class UbdService : BaseService, IService<UbdDTO>
    {
        public UbdService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(UbdDTO dto)
        {
            unitOfWork.UbdRepository.Add(mapper.Map<Ubd>(dto));
        }

        public List<UbdDTO> GetAll()
        {
            var ubds = unitOfWork.UbdRepository.GetAll();
            return mapper.Map<List<UbdDTO>>(ubds);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UbdDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
