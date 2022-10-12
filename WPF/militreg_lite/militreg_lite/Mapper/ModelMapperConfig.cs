using AutoMapper;
using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.Mapper
{
    public class ModelMapperConfig
    {
        private static ModelMapperConfig instanse;
        public ModelMapperConfig()
        {
        }
        public static ModelMapperConfig Instanse => instanse ??= (new ModelMapperConfig());
        public MapperConfiguration Config
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<Gender, GenderDTO>().ReverseMap();
                      cfg.CreateMap<Militarist, MilitaristDTO>().ReverseMap();
                      cfg.CreateMap<Pidrozdil, PidrozdilDTO>().ReverseMap();
                      cfg.CreateMap<Posada, PosadaDTO>().ReverseMap();
                      cfg.CreateMap<PrizivType, PrizivTypeDTO>().ReverseMap();
                      cfg.CreateMap<Rtck, RtckDTO>().ReverseMap();
                      cfg.CreateMap<Ubd, UbdDTO>().ReverseMap();
                      cfg.CreateMap<User, UserDTO>().ReverseMap();
                      cfg.CreateMap<Vos, VosDTO>().ReverseMap();
                      cfg.CreateMap<Zvan, ZvanDTO>().ReverseMap();
                  });
                return config;
            }
        }
    }
}
