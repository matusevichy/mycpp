using AutoMapper;
using Library.BLL.DTO.Database;
using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Config
{
    public class ModelMapperConfig
    {
        private static ModelMapperConfig instance;
        public static ModelMapperConfig Instance => instance ?? (new ModelMapperConfig());
        public MapperConfiguration Config
        {
            get
            {
                AuthorRepository authorRepository = new AuthorRepository();
                BookRepository bookRepository = new BookRepository();
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Genre, GenreDTO>();
                    cfg.CreateMap<GenreDTO, Genre>();
                    cfg.CreateMap<AuthorDTO, Author>();
                    cfg.CreateMap<Author, AuthorDTO>();
                    //cfg.CreateMap<BookDTO, Book>();
                    cfg.CreateMap<BookDTO, Book>().ForMember(dto => dto.Author2Books, opt => opt.MapFrom(x => x.Authors.Select(a => new { authorId = a.Id, bookId = x.Id }).ToList()));
                    //cfg.CreateMap<Book, BookDTO>().ForMember(dto => dto.Authors, opt => opt.MapFrom(x => x.Author2Books.Select(a => authorRepository.Get(a.AuthorId)).ToList()));
                    cfg.CreateMap<User, UserDTO>();
                    cfg.CreateMap<UserDTO, User>();
                });
                return config;
            }
        }
        private ModelMapperConfig() { }
    }
}
