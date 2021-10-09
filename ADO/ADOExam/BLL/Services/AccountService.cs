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
    public class AccountService : BaseService, IService<AccountDTO>
    {
        AccountRepository repository = new AccountRepository();
        public void Create(AccountDTO dto)
        {
            repository.Create(mapper.Map<Account>(dto));
        }

        public void Delete(int id)
        {
            repository.Remove(id);
        }

        public List<AccountDTO> GetAll()
        {
            List<Account> accounts = (List<Account>)repository.GetAll();
            return mapper.Map<List<AccountDTO>>(accounts);
        }

        public AccountDTO GetById(int id)
        {
            var account = repository.GetById(id);
            return mapper.Map<AccountDTO>(account);
        }

        public AccountDTO Auth(string login, string password)
        {
            var account = repository.Auth(login, password);
            return mapper.Map<AccountDTO>(account);
        }

        public void Update(AccountDTO dto)
        {
            repository.Update(mapper.Map<Account>(dto));
        }
    }
}
