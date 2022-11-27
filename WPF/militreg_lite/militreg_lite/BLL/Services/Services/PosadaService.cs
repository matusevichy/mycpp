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
    public class PosadaService : BaseService, IService<PosadaDTO>
    {
        public PosadaService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(PosadaDTO dto)
        {
            unitOfWork.PosadaRepository.Add(mapper.Map<Posada>(dto));
        }

        public List<PosadaDTO> GetAll()
        {
            var posadas = unitOfWork.PosadaRepository.GetAll();
            return mapper.Map<List<PosadaDTO>>(posadas);
        }

        public void Remove(int id)
        {
            unitOfWork.PosadaRepository.Remove(id);
        }

        public void Update(PosadaDTO dto)
        {
            unitOfWork.PosadaRepository.Update(mapper.Map<Posada>(dto));
        }
    }
}
