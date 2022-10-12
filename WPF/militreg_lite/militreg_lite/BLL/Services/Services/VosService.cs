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
    public class VosService : BaseService, IService<VosDTO>
    {
        public VosService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(VosDTO dto)
        {
            unitOfWork.VosRepository.Add(mapper.Map<Vos>(dto));
        }

        public List<VosDTO> GetAll()
        {
            var voss = unitOfWork.VosRepository.GetAll();
            return mapper.Map<List<VosDTO>>(voss);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(VosDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
