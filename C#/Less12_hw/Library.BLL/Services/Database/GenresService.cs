using AutoMapper;
using Library.BLL.DTO.Database;
using Library.BLL.Exceptions;
using Library.BLL.Helpers.Validation;
using Library.BLL.Interfaces;
using Library.BLL.ModelAutoMapper;
using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services.Database
{
    public class GenresService: BaseService, IService<GenreDTO>
    {
        GenreRepository genresRepository = new GenreRepository();

        public GenreDTO FindById(int id)
        {
            var srchGenre = genresRepository.Get(id);
            // TODO: Genre to GenreDTO
            //var dto = new GenreDTO
            //{
            //    Id = srchGenre.Id,
            //    Name = srchGenre.Name
            //};
            return mapper.Map<GenreDTO>(srchGenre);
        }

        public List<GenreDTO> GetAll()
        {
            List<Genre> genres = genresRepository.GetAll();
            return mapper.Map<List<GenreDTO>>(genres);
        }

        public void Create(GenreDTO dto)
        {
            // TODO: Validation
            var validationResult = ModelValidationHelper.Validate(dto);

            if (!validationResult.Valid)
            {
                throw new ModelValidationException(String.Join(",", validationResult.Errors));
            }

            genresRepository.Create(mapper.Map<Genre>(dto));
        }

        public void Delete(int id)
        {
            genresRepository.Delete(id);
        }
    }
}
