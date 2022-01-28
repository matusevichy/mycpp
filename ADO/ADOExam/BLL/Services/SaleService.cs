﻿using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class SaleService : BaseService, IService<SaleDTO>
    {
        SaleRepository repository = new SaleRepository();
        public void Create(SaleDTO dto)
        {
            repository.Create(mapper.Map<Sale>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<SaleDTO> GetAll()
        {
            List<Sale> sales = (List<Sale>)repository.GetAll();
            return mapper.Map<List<SaleDTO>>(sales);
        }

        public SaleDTO GetById(int id)
        {
            return mapper.Map<SaleDTO>(repository.GetById(id));
        }

        public void Update(SaleDTO dto)
        {
            throw new NotImplementedException();
        }
        public int GetMostPopularGenreId()
        {
            return repository.GetMostPopularGenreId();
        }
        public int GetMostPopularAuthorId()
        {
            return repository.GetMostPopularAuthorId();
        }
    }
}
