using AutoMapper;
using militreg_lite.BLL.DTO;
using militreg_lite.DAL.Entities;
using militreg_lite.DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.BLL.Services.Services
{
    public class UserService : BaseService, IService<UserDTO>
    {
        public UserService(UnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(UserDTO dto)
        {
            unitOfWork.UserRepository.Add(mapper.Map<User>(dto));
        }

        public List<UserDTO> GetAll()
        {
            var users = unitOfWork.UserRepository.GetAll();
            return mapper.Map<List<UserDTO>>(users);
        }

        public void Remove(int id)
        {
            unitOfWork.UserRepository.Remove(id);
        }

        public void Update(UserDTO dto)
        {
            unitOfWork.UserRepository.Update(mapper.Map<User>(dto));
        }
    }
}
