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
    public class CreatorService : BaseService, IService<CreatorDTO>
    {
        CreatorRepository repository = new CreatorRepository();
        public void Create(CreatorDTO dto)
        {
            repository.Create(mapper.Map<Creator>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<CreatorDTO> GetAll()
        {
            List<Creator> creators = (List<Creator>)repository.GetAll();
            return mapper.Map<List<CreatorDTO>>(creators);
        }

        public CreatorDTO GetById(int id)
        {
            Creator creator = repository.GetById(id);
            return mapper.Map<CreatorDTO>(creator);
        }

        public void Update(CreatorDTO dto)
        {
            repository.Update(mapper.Map<Creator>(dto));
        }
    }
}
