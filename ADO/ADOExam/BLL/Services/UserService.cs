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
    public class UserService : BaseService, IService<UserDTO>
    {
        UserRepository repository = new UserRepository();
        public void Create(UserDTO dto)
        {
            repository.Create(mapper.Map<User>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<UserDTO> GetAll()
        {
            List<User> users = (List<User>)repository.GetAll();
            return mapper.Map<List<UserDTO>>(users);
        }

        public UserDTO GetById(int id)
        {
            User user = repository.GetById(id);
            return mapper.Map<UserDTO>(user);
        }

        public void Update(UserDTO dto)
        {
            repository.Update(mapper.Map<User>(dto));
        }
    }
}
