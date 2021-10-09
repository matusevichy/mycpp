using AutoMapper;
using Library.BLL.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.ModelAutoMapper
{
    public class ModelMapper
    {
        private static ModelMapper instance;
        public static ModelMapper Instance 
            => instance ?? (instance = new ModelMapper());

        public IMapper Mapper => new AutoMapper.Mapper(ModelMapperConfig.Instance.Config);

        private ModelMapper() { }
    }
}
