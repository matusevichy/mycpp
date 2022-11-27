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
    public class PrizivTypeService : BaseService, IService<PrizivTypeDTO>
    {
        public PrizivTypeService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(PrizivTypeDTO dto)
        {
            unitOfWork.PrizivTypeRepository.Add(mapper.Map<PrizivType>(dto));
        }

        public List<PrizivTypeDTO> GetAll()
        {
            var prizivTypes = unitOfWork.PrizivTypeRepository.GetAll();
            return mapper.Map<List<PrizivTypeDTO>>(prizivTypes);
        }

        public void Remove(int id)
        {
            unitOfWork.PrizivTypeRepository.Remove(id);
        }

        public void Update(PrizivTypeDTO dto)
        {
            unitOfWork.PrizivTypeRepository.Update(mapper.Map<PrizivType>(dto));
        }
    }
}
