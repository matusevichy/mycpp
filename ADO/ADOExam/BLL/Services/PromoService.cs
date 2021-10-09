using BLL.DTO;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PromoService : BaseService, IService<PromoDTO>
    {
        PromoRepository repository = new PromoRepository();
        public void Create(PromoDTO dto)
        {
            repository.Create(mapper.Map<Promo>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<PromoDTO> GetAll()
        {
            List<Promo> promos = (List<Promo>)repository.GetAll();
            return mapper.Map<List<PromoDTO>>(promos);
        }

        public PromoDTO GetById(int id)
        {
            Promo promo = repository.GetById(id);
            return mapper.Map<PromoDTO>(promo);
        }

        public List<PromoDTO> GetOnDate(DateTime date)
        {
            List<Promo> promos = (List<Promo>)repository.GetOnDate(date);
            return mapper.Map<List<PromoDTO>>(promos);
        }

        public void Update(PromoDTO dto)
        {
            repository.Update(mapper.Map<Promo>(dto));
        }
    }
}
