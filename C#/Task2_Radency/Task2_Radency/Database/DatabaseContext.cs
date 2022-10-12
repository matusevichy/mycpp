using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Task2_Radency.DAL.Models;
using Task2_Radency.BLL.DTO;

namespace Task2_Radency.DAL.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                 new Genre { Id = 1, Name = "Genre 1" },
                new Genre { Id = 2, Name = "Genre 2" }
                new Genre[]
                {
                });
            modelBuilder.Entity<Genre>().HasData(
                new Book[]
                {
                    new Book {Id=1, Author="Author 1", },
                    new Book {Id=2, Name = "Genre 2"}
                });

        }

    }
}
