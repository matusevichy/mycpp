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
    public class PidrozdilService : BaseService, IService<PidrozdilDTO>
    {
        public PidrozdilService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(PidrozdilDTO dto)
        {
            unitOfWork.PidrozdilRepository.Add(mapper.Map<Pidrozdil>(dto));
        }

        public List<PidrozdilDTO> GetAll()
        {
            var pidrozdils = unitOfWork.PidrozdilRepository.GetAll();
            return mapper.Map<List<PidrozdilDTO>>(pidrozdils);
        }

        public void Remove(int id)
        {
            unitOfWork.PidrozdilRepository.Remove(id);
        }

        public void Update(PidrozdilDTO dto)
        {
            unitOfWork.PidrozdilRepository.Update(mapper.Map<Pidrozdil>(dto));
        }
    }
}
