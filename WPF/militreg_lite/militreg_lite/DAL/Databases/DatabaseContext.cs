using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using militreg_lite.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace militreg_lite.DAL.Databases
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Militarist> Militarists { get; set; }
        public DbSet<Pidrozdil> Pidrozdils { get; set; }
        public DbSet<Posada> Posadas { get; set; }
        public DbSet<PrizivType> PrizivTypes { get; set; }
        public DbSet<Rtck> Rtcks { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Ubd> Ubds { get; set; }
        public DbSet<Vos> Voss { get; set; }
        public DbSet<Zvan> Zvans { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=milit_lite.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rtck>().HasKey(m => m.Id);
            modelBuilder.Entity<Rtck>().Property(m => m.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Rtck>().HasData(new Rtck { Id = 1, Name = "Kam" },
                                                new Rtck { Id = 2, Name = "Sin" });

            modelBuilder.Entity<Posada>().HasKey(p => p.Id);
            modelBuilder.Entity<Posada>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Posada>().HasData(new Posada { Id = 1, Name = "Voenkom" },
                                                  new Posada { Id = 2, Name = "Nach" });

            modelBuilder.Entity<Vos>().HasKey(v => v.Id);
            modelBuilder.Entity<Vos>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Vos>().HasData(new Vos { Id = 1, Number = "100" },
                                               new Vos { Id = 2, Number = "101" });

            modelBuilder.Entity<Zvan>().HasKey(v => v.Id);
            modelBuilder.Entity<Zvan>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Zvan>().HasData(new Zvan { Id = 1, Name = "Podp" },
                                               new Zvan { Id = 2, Name = "Polk" });

            modelBuilder.Entity<Gender>().HasKey(v => v.Id);
            modelBuilder.Entity<Gender>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Gender>().HasData(new Gender { Id = 1, Name = "Чоловіча" },
                                               new Gender { Id = 2, Name = "Жіноча" });

            modelBuilder.Entity<Ubd>().HasKey(v => v.Id);
            modelBuilder.Entity<Ubd>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Ubd>().HasData(new Ubd { Id = 1, Name = "Afgan" },
                                               new Ubd { Id = 2, Name = "Other" });

            modelBuilder.Entity<PrizivType>().HasKey(v => v.Id);
            modelBuilder.Entity<PrizivType>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<PrizivType>().HasData(new PrizivType { Id = 1, Name = "Mob" },
                                               new PrizivType { Id = 2, Name = "Priz" });

            modelBuilder.Entity<Pidrozdil>().HasKey(v => v.Id);
            modelBuilder.Entity<Pidrozdil>().Property(v => v.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Pidrozdil>().HasData(new Pidrozdil { Id = 1, Name = "Mob" },
                                               new Pidrozdil { Id = 2, Name = "Vozik" });

            modelBuilder.Entity<Militarist>().HasKey(m => m.Id);
            modelBuilder.Entity<Militarist>().Property(m => m.Id).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Militarist>().Property(m => m.Pib).IsRequired();
            modelBuilder.Entity<Militarist>().HasOne(m => m.Rtck);
            modelBuilder.Entity<Militarist>().HasOne(m => m.ZvanShtat).WithMany();
            modelBuilder.Entity<Militarist>().HasOne(m => m.ZvanFact).WithMany();
            modelBuilder.Entity<Militarist>().HasOne(m => m.Gender);
            modelBuilder.Entity<Militarist>().HasOne(m => m.Pidrozdil);
            modelBuilder.Entity<Militarist>().HasOne(m => m.Posada);
            modelBuilder.Entity<Militarist>().HasOne(m => m.PrizivType);
            modelBuilder.Entity<Militarist>().HasOne(m => m.Ubd);
            modelBuilder.Entity<Militarist>().HasOne(m => m.Vos);
            modelBuilder.Entity<Militarist>().HasData(new Militarist { Id = 1, Pib = "Vasya Pupkin", BirthDay = DateTime.Parse("1978-02-23"), PosadaId=1, Oklad=100, VosId=1, ZvanShtatId=1, ZvanFactId=1,  DateBegin= DateTime.Parse("1978-02-23"), DateEnd= DateTime.Parse("1978-02-23"), RtckId = 1, GenderId=1, PidrozdilId=1, PrizivTypeId=1, UbdId=1, Osvita="NGU"},
                                                      new Militarist { Id = 2, Pib = "Vasya Pupkin", BirthDay = DateTime.Parse("1978-02-23"), PosadaId = 2, Oklad = 100, VosId = 1, ZvanShtatId = 1, ZvanFactId = 1, DateBegin= DateTime.Parse("1978-02-23"), DateEnd= DateTime.Parse("1978-02-23"), RtckId = 2, GenderId = 2, PidrozdilId = 2, PrizivTypeId = 2, UbdId = 2, Osvita="DGU" });
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasData(new User { Id = 1, Login = "admin", Password = "password", Role = 1 }, new User { Id = 2, Login = "owner", Password = "password", Role = 2 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
