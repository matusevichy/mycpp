using Less4_hw.Models;
using Microsoft.EntityFrameworkCore;

namespace Less4_hw.DB
{
    public class BlogContext: DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public BlogContext(DbContextOptions options) : base(options)
        {
        }
    }
}
