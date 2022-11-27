using HelloMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloMVC.Data;

public class AcademyContext: DbContext
{
    public DbSet<Student> Students { get; set; }
    public AcademyContext(DbContextOptions options) : base(options)
    {
    }
}