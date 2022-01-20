using AutoMapper;
using Less1_hw.BLL.DTO;
using Less1_hw.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.BLL.Services
{
    public class ServiceManager
    {
        Lazy<WorkerService> workerService;
        public WorkerService WorkerService => workerService.Value;

        public ServiceManager(UnitOfWork unitOfWork, IMapper mapper)
        {
            workerService = new Lazy<WorkerService>(() => new WorkerService(unitOfWork, mapper));
        }

    }
}
