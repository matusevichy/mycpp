using Less1_hw.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw.DAL
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        private DatabaseContext() : base("Data Source=DESKTOP-BCU1QI7;Initial Catalog=matusevichexam;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }
    }
}
