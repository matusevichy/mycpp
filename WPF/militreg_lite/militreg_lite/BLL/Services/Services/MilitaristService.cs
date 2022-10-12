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
    public class MilitaristService : BaseService, IService<MilitaristDTO>
    {
        public MilitaristService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(MilitaristDTO dto)
        {
            unitOfWork.MilitaristRepository.Add(mapper.Map<Militarist>(dto));
        }

        public List<MilitaristDTO> GetAll()
        {
            var militarists = unitOfWork.MilitaristRepository.GetAll();
            return mapper.Map<List<MilitaristDTO>>(militarists);
        }

        public void Remove(int id)
        {
            unitOfWork.MilitaristRepository.Remove(id);
        }

        public void Update(MilitaristDTO dto)
        {
            unitOfWork.MilitaristRepository.Update(mapper.Map<Militarist>(dto));
        }
    }
}
