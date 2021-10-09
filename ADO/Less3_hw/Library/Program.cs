using Library.BLL.DTO;
using Library.BLL.DTO.Database;
using Library.BLL.Services.API;
using Library.BLL.Services.Database;
using Library.DAL.Entities;
using Library.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            GenreRepository genreRepository = new GenreRepository();
            BookRepository bookRepository = new BookRepository();
            AuthorRepository authorRepository = new AuthorRepository();
            GenresService genresService = new GenresService();
            AuthorsService authorService = new AuthorsService();
            BooksService booksService = new BooksService();
            UserService userService = new UserService();

            List<Genre> genres = genreRepository.GetAll();
            var books = bookRepository.GetAll();
            var book = bookRepository.Get(1);
            var authors = authorRepository.GetAll();
            //var authors = new List<AuthorDTO>();
            //authors.Add(authorService.FindById(1));
            //authors.Add(authorService.FindById(2));
            //var book = new BookDTO
            //{
            //    Title = "Book1",
            //    Pages = 100,
            //    Description = "New Book 1",
            //    Genre = genresService.FindById(2),
            //    Authors = authors
            //};
            //var list = book.Authors.Select(a => new { authorId = a.Id, bookId = 1 }).ToList();
            //booksService.Create(new BookDTO
            //{
            //    Title = "Book1",
            //    Pages = 100,
            //    Description = "New Book 1",
            //    Genre = genresService.FindById(2),
            //    Authors = authors
            //});

            //authorService.Create(new AuthorDTO
            //{
            //    FirstName = "Petya",
            //    LastName = "Ivanov",
            //    Birth = DateTime.Parse("2010-01-01")
            //});

            //AuthorDTO author = authorService.FindById(1);
            //List<AuthorDTO> authors = authorService.GetAll();

            //userService.Create(new UserDTO
            //{
            //    Login = "admin",
            //    Password = "12345",
            //    Email = "admin@gmail.com"
            //});

            //UserDTO author = userService.FindById(1);
            //List<UserDTO> authors = userService.GetAll();


            //genresService.Delete(1);
            //GenreDTO genre = genresService.FindById(1);
            //List<GenreDTO> genres = genresService.GetAll();
            ;

            //WeatherAPIService weatherAPIService = new WeatherAPIService();
            //var weather = weatherAPIService.GetWeatherForCity("Dnepropetrovsk");

            //genresService.CreateGenre(new GenreDTO { Name = "Some genre" });
            //var genres = genresService.GetAllGenres();

            //genresService.CreateGenre(new GenreDTO { Name = "" });

            Console.Read();
        }
    }
}
