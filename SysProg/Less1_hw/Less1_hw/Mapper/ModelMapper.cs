using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.Mapper
{
    class ModelMapper
    {
        private static ModelMapper instanse;

        public ModelMapper()
        {
        }

        public static ModelMapper Instanse => instanse ??= (new ModelMapper());
        public IMapper Mapper => new AutoMapper.Mapper(ModelMapperConfig.Instanse.Config);
    }
}
