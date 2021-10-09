using Library.BLL.DTO.Database;
using Library.BLL.Interfaces;
using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services.Database
{
    public class UserService : BaseService, IService<UserDTO>
    {
        UserRepository userRepository = new UserRepository();
        public void Create(UserDTO dto)
        {
            userRepository.Create(mapper.Map<User>(dto));
        }

        public void Delete(int id)
        {
            userRepository.Delete(id);
        }

        public UserDTO FindById(int id)
        {
            var srcUser = userRepository.Get(id);
            return mapper.Map<UserDTO>(srcUser);
        }

        public List<UserDTO> GetAll()
        {
            List<User> users = userRepository.GetAll();
            return mapper.Map<List<UserDTO>>(users);
        }
    }
}
