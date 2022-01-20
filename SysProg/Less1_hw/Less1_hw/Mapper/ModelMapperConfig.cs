using AutoMapper;
using Less1_hw.BLL.DTO;
using Less1_hw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.Mapper
{
    class ModelMapperConfig
    {
        private static ModelMapperConfig instanse;

        public ModelMapperConfig()
        {
        }

        public static ModelMapperConfig Instanse => instanse ??= (new ModelMapperConfig());


        public MapperConfiguration Config
        {
            get {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Worker,WorkerDTO>().ReverseMap());
                return config; 
            }
        }

    }
}
