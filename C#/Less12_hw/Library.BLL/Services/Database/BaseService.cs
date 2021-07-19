using AutoMapper;
using Library.BLL.ModelAutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services.Database
{
    public class BaseService
    {
        public IMapper mapper = ModelMapper.Instance.Mapper;
    }
}
