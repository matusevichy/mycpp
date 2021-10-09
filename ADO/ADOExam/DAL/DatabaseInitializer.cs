using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    class DatabaseInitializer: DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

            var acc = new Account
            {
                Login = "vasya",
                Password = "123456",
                Email = "vasya@gmail.com",
                User = new User
                {
                    FirstName = "Vasya",
                    LastName = "Pupkin",
                    MiddleName = "Stepanovich",
                    Birth = new DateTime(1990, 10, 10)
                }
            };
            context.Accounts.Add(acc);
            context.SaveChanges();
            var acc1 = new Account
            {
                Login = "admin",
                Password = "123456",
                Email = "admin@gmail.com",
                User = new User
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    MiddleName = "",
                    Birth = new DateTime(1990, 01, 01)
                }
            };
            context.Accounts.Add(acc1);
            context.SaveChanges();
            var author = new Author
            {
                FirstName = "Anrey",
                LastName = "Belyanin",
                MiddleName = "H",
                Birth = DateTime.Parse("01.05.1970")
            };
            context.Authors.Add(author);
            context.SaveChanges();
            var creator = new Creator
            {
                Name = "Some Creator"
            };
            context.Creators.Add(creator);
            context.SaveChanges();
            var genre = new Genre
            {
                Name = "Fantastic"
            };
            context.Genres.Add(genre);
            context.SaveChanges();
            var book1 = new Book
            {
                Name = "My Wife is a witch",
                Pages = 320,
                Author = author,
                Genre = genre,
                Creator = creator,
                BasePrice = 101,
                Price = 200,
                DateCreate = DateTime.Parse("01.02.1990"),
                CountInStore = 100
            };
            var book2 = new Book
            {
                Name = "Sister fromvunderworld",
                Pages = 300,
                Author = author,
                Genre = genre,
                Creator = creator,
                BasePrice = 111,
                Price = 222,
                DateCreate = DateTime.Parse("01.02.1995"),
                PrevBook = book1,
                CountInStore = 200
            };
            var book3 = new Book
            {
                Name = "Cossack in the paradise",
                Pages = 220,
                Author = author,
                Genre = genre,
                Creator = creator,
                BasePrice = 300,
                Price = 400,
                DateCreate = DateTime.Parse("01.02.2000")
            };
            context.Books.Add(book1);
            context.Books.Add(book2);
            context.Books.Add(book3);
            context.SaveChanges();
            var promo = new Promo
            {
                Name = "Some promo",
                DateBegin = DateTime.Parse("01.08.2021"),
                DateEnd = DateTime.Parse("01.10.2021"),
                Books = new List<Book> { book1, book3 }
            };
            context.Promos.Add(promo);
            context.SaveChanges();
        }
    }
}
