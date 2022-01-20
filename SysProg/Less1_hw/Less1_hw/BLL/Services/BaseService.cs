using AutoMapper;
using Less1_hw.DAL.Repositories;
using Less1_hw.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.BLL.Services
{
    public class BaseService
    {
        protected UnitOfWork unitOfWork;
        protected IMapper mapper;

        public BaseService(UnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
    }
}
