using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class AccountRepository: BaseRepository<int, Account>
    {
        public void Update (Account account)
        {
            var entity = Table.FirstOrDefault(e => e.Id == account.Id);
            entity.Password = account.Password;
            entity.Email = account.Email;
            Save();
        }
        public override IEnumerable<Account> GetAll()
        {
            var accounts = Table.Include(e => e.User).ToList();
            return accounts;
        }
        public override Account GetById(int id)
        {
            return Table.Include(e => e.User).FirstOrDefault(t => t.Id == id);
        }

        public Account Auth (string login, string password)
        {
            return Table.Include(e => e.User).FirstOrDefault(t => (t.Login == login && t.Password == password));
        }
    }
}
