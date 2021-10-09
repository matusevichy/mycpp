using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; } 
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }
        static DatabaseContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        private DatabaseContext(): base("DefaultConnection")
        {

        }
        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
