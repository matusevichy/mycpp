using AutoMapper;
using BLL.Mapper;

namespace BLL.Services
{
    public class BaseService
    {
        public IMapper mapper = ModelMapper.Instanse.Mapper;
    }
}
