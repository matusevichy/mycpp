using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    class ModelMapperConfig
    {
        private static ModelMapperConfig instanse;

        public ModelMapperConfig()
        {
        }

        public static ModelMapperConfig Instanse => instanse ?? (new ModelMapperConfig());

        public MapperConfiguration Config
        {
            get 
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Account, AccountDTO>();
                    cfg.CreateMap<AccountDTO, Account>();
                    cfg.CreateMap<Author, AuthorDTO>();
                    cfg.CreateMap<AuthorDTO, Author>();
                    cfg.CreateMap<Book, BookDTO>();
                    cfg.CreateMap<BookDTO, Book>();
                    cfg.CreateMap<Creator, CreatorDTO>();
                    cfg.CreateMap<CreatorDTO, Creator>();
                    cfg.CreateMap<Genre, GenreDTO>();
                    cfg.CreateMap<GenreDTO, Genre>();
                    cfg.CreateMap<Promo, PromoDTO>();
                    cfg.CreateMap<PromoDTO, Promo>();
                    cfg.CreateMap<Sale, SaleDTO>();
                    cfg.CreateMap<SaleDTO, Sale>();
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<UserDTO, User>();
                });
                return config;
            }
        }

    }
}
