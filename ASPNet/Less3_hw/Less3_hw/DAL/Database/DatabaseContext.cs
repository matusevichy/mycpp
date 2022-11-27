using Less3_hw.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Less3_hw.DAL.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}
