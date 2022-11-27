using AcademyWebApp.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyWebApp.Data;

public class AcademyContext: DbContext
{
    public AcademyContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
}