using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2_Radency.BLL.DTO;
using Task2_Radency.DAL.Models;

namespace Task2_Radency.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Genre, GenreDTO>().ReverseMap();
            CreateMap<Rate, RateDTO>().ReverseMap();
            CreateMap<Review, ReviewDTO>().ReverseMap();
        }
    }
}
