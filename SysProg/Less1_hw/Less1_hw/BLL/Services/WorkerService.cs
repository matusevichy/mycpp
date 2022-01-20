using AutoMapper;
using Less1_hw.BLL.DTO;
using Less1_hw.DAL.Entities;
using Less1_hw.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.BLL.Services
{
    public class WorkerService : BaseService, IService<WorkerDTO>
    {
        public WorkerService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public WorkerDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<WorkerDTO> GetAll()
        {
            var workers = unitOfWork.WorkerRepository.GetAll();
            return mapper.Map<List<WorkerDTO>>(workers);
        }
    }
}
