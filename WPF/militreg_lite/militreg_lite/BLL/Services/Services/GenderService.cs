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
    public class GenderService : BaseService, IService<GenderDTO>
    {
        public GenderService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(GenderDTO dto)
        {
            unitOfWork.GenderRepository.Add(mapper.Map<Gender>(dto));
        }

        public List<GenderDTO> GetAll()
        {
            var genders = unitOfWork.GenderRepository.GetAll();
            return mapper.Map<List<GenderDTO>>(genders);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(GenderDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
