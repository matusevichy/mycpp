using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Less5_cw.Models;

namespace Less5_cw.Data
{
    public class Less5_cwContext : DbContext
    {
        public Less5_cwContext (DbContextOptions<Less5_cwContext> options)
            : base(options)
        {
        }

        public DbSet<Less5_cw.Models.Student> Student { get; set; } = default!;
    }
}
