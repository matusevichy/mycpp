using Library.DAL.DbConnection;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        public void Create(Author entity)
        {
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                ctx.GetTable<Author>().InsertOnSubmit(entity);
                ctx.SubmitChanges();
            }
        }

        public void Delete(int id)
        {
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                var author = ctx.GetTable<Author>().FirstOrDefault(e => e.Id == id);
                ctx.GetTable<Author>().DeleteOnSubmit(author);
                ctx.SubmitChanges();
            }
        }

        public Author Get(int id)
        {
            Author author = null;
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                author = ctx.GetTable<Author>().FirstOrDefault(e => e.Id == id);
            }
            return author;
        }

        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                authors = ctx.GetTable<Author>().ToList();
            }
            return authors;
        }

        public void Update(Author entity)
        {
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                var author = ctx.GetTable<Author>().FirstOrDefault(e => e.Id == entity.Id);
                author.FirstName = entity.FirstName;
                author.LastName = entity.LastName;
                author.Birth = entity.Birth;
                ctx.SubmitChanges();
            }
        }
    }
}
