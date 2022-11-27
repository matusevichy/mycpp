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
    public class RtckService : BaseService, IService<RtckDTO>
    {
        public RtckService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(RtckDTO dto)
        {
            unitOfWork.RtckRepository.Add(mapper.Map<Rtck>(dto));
        }

        public List<RtckDTO> GetAll()
        {
            var rtcks = unitOfWork.RtckRepository.GetAll();
            return mapper.Map<List<RtckDTO>>(rtcks);
        }

        public void Remove(int id)
        {
            unitOfWork.RtckRepository.Remove(id);
        }

        public void Update(RtckDTO dto)
        {
            unitOfWork.RtckRepository.Update(mapper.Map<Rtck>(dto));
        }
    }
}
