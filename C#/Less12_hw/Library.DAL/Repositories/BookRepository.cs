using Library.DAL.DbConnection;
using Library.DAL.Entities;
using Library.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        public void Create(Book entity)
        {
            using (var connection=DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "insert into Books values (@title, @genreid, @pages, @description, @instock); SELECT SCOPE_IDENTITY()"
                };
                command.Parameters.AddWithValue("@title", entity.Title);
                command.Parameters.AddWithValue("pages", entity.Pages);
                command.Parameters.AddWithValue("description", entity.Description);
                command.Parameters.AddWithValue("@genreid", entity.GenreId);
                command.Parameters.AddWithValue("@instock", entity.InStock);
                var id = command.ExecuteScalar();
                foreach (var item in entity.Author2Books)
                {
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "insert into Author2Book values (@authorid, @bookid)"
                    };
                    command.Parameters.AddWithValue("@authorid", item.AuthorId);
                    command.Parameters.AddWithValue("@bookid", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "delete from Books where id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "delete from Author2Book where bookid = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "delete from BooksOnHands where bookid = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public Book Get(int id)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                Book book = null;
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Books where id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    GenreRepository genreRepository = new GenreRepository();
                    var genre = genreRepository.Get(reader.GetInt32(2));
                    book = new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        GenreId = reader.GetInt32(2),
                        Pages = reader.GetInt32(3),
                        Description = reader.GetString(4),
                        InStock=reader.GetInt32(5),
                        Genre = genre
                    };
                    #region Author2Book
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select * from Author2Book where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", id);
                    var reader1 = command.ExecuteReader();
                    List<Author2Book> author2Books = new List<Author2Book>();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            author2Books.Add(new Author2Book
                            {
                                AuthorId = reader1.GetInt32(0),
                                //Author = new AuthorRepository().Get(reader.GetInt32(0)),
                                BookId = reader1.GetInt32(1),
                                //Book = book
                            });
                        }
                    }
                    book.Author2Books = author2Books;
                    reader1.Close();
                    #endregion
                    #region BookOnHands
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select * from BooksOnHands where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", id);
                    reader1 = command.ExecuteReader();
                    List<BookOnHands> booksOnHands = new List<BookOnHands>();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            booksOnHands.Add(new BookOnHands
                            {
                                BookId = reader1.GetInt32(0),
                                UserId = reader1.GetInt32(1)
                            });
                        }
                    }
                    book.BooksOnHands = booksOnHands;
                    #endregion
                }
                return book;
            }
        }

        public Book GetByTitle(string title)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                Book book = null;
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Books where title = @title"
                };
                command.Parameters.AddWithValue("@title", title);
                var reader = command.ExecuteReader();
                int id=0;
                if (reader.HasRows && reader.Read())
                {
                    GenreRepository genreRepository = new GenreRepository();
                    var genre = genreRepository.Get(reader.GetInt32(2));
                    id = reader.GetInt32(0);
                    book = new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        GenreId = reader.GetInt32(2),
                        Pages = reader.GetInt32(3),
                        Description = reader.GetString(4),
                        InStock = reader.GetInt32(5),
                        Genre = genre
                    };
                    #region Author2Book
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select * from Author2Book where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", id);
                    var reader1 = command.ExecuteReader();
                    List<Author2Book> author2Books = new List<Author2Book>();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            author2Books.Add(new Author2Book
                            {
                                AuthorId = reader1.GetInt32(0),
                                //Author = new AuthorRepository().Get(reader.GetInt32(0)),
                                BookId = reader1.GetInt32(1),
                                //Book = book
                            });
                        }
                    }
                    book.Author2Books = author2Books;
                    reader1.Close();
                    #endregion
                    #region BookOnHands
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select * from BooksOnHands where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", id);
                    reader1 = command.ExecuteReader();
                    List<BookOnHands> booksOnHands = new List<BookOnHands>();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            booksOnHands.Add(new BookOnHands
                            {
                                BookId = reader1.GetInt32(0),
                                UserId = reader1.GetInt32(1)
                            });
                        }
                    }
                    book.BooksOnHands = booksOnHands;
                    #endregion
                }
                return book;
            }
        }
        public Book GetByGenre(int genreId)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                Book book = null;
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Books where genreid = @genreid"
                };
                command.Parameters.AddWithValue("@genreid", genreId);
                var reader = command.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    GenreRepository genreRepository = new GenreRepository();
                    var genre = genreRepository.Get(genreId);
                    var id = reader.GetInt32(0);
                    book = new Book
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        GenreId = reader.GetInt32(2),
                        Pages = reader.GetInt32(3),
                        Description = reader.GetString(4),
                        InStock = reader.GetInt32(5),
                        Genre = genre
                    };
                    #region Author2Book
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select * from Author2Book where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", id);
                    var reader1 = command.ExecuteReader();
                    List<Author2Book> author2Books = new List<Author2Book>();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            author2Books.Add(new Author2Book
                            {
                                AuthorId = reader1.GetInt32(0),
                                //Author = new AuthorRepository().Get(reader.GetInt32(0)),
                                BookId = reader1.GetInt32(1),
                                //Book = book
                            });
                        }
                    }
                    book.Author2Books = author2Books;
                    reader1.Close();
                    #endregion
                    #region BookOnHands
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "select * from BooksOnHands where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", id);
                    reader1 = command.ExecuteReader();
                    List<BookOnHands> booksOnHands = new List<BookOnHands>();
                    if (reader1.HasRows)
                    {
                        while (reader1.Read())
                        {
                            booksOnHands.Add(new BookOnHands
                            {
                                BookId = reader1.GetInt32(0),
                                UserId = reader1.GetInt32(1)
                            });
                        }
                    }
                    book.BooksOnHands = booksOnHands;
                    #endregion
                }
                return book;
            }
        }
        public List<Book> GetByAuthor()
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                List<Book> books = null;
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select b.id, b.title, b.genreid, b.pages, b.description, b.instock from Books b " +
                    "join Author2Book a2b on b.id = a2b.bookid where a2b.authorid = 1"
                };
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GenreRepository genreRepository = new GenreRepository();
                        var genre = genreRepository.Get(reader.GetInt32(2));
                        var bookId = reader.GetInt32(0);
                        #region Author2Book
                        command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "select * from Author2Book where bookid = @bookid"
                        };
                        command.Parameters.AddWithValue("@id", bookId);
                        var reader1 = command.ExecuteReader();
                        List<Author2Book> author2Books = new List<Author2Book>();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                author2Books.Add(new Author2Book
                                {
                                    AuthorId = reader1.GetInt32(0),
                                    //Author = new AuthorRepository().Get(reader.GetInt32(0)),
                                    BookId = reader1.GetInt32(1),
                                    //Book = new BookRepository().Get(reader.GetInt32(1))
                                });
                            }
                        }
                        reader1.Close();
                        #endregion
                        #region BooksOnHands
                        command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "select * from BooksOnHands where bookid = @bookid"
                        };
                        command.Parameters.AddWithValue("@id", bookId);
                        reader1 = command.ExecuteReader();
                        List<BookOnHands> booksOnHands = new List<BookOnHands>();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                booksOnHands.Add(new BookOnHands
                                {
                                    BookId = reader1.GetInt32(0),
                                    UserId = reader1.GetInt32(1)
                                });
                            }
                        }
                        #endregion
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreId = reader.GetInt32(2),
                            Pages = reader.GetInt32(3),
                            Description = reader.GetString(4),
                            InStock = reader.GetInt32(5),
                            Genre = genre,
                            Author2Books = author2Books,
                            BooksOnHands = booksOnHands
                        });
                    }
                }
                return books;
            }
        }
        public List<Book> GetAll()
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                List<Book> books = null;
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Books"
                };
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        GenreRepository genreRepository = new GenreRepository();
                        var genre = genreRepository.Get(reader.GetInt32(2));
                        var bookId = reader.GetInt32(0);
                        #region Author2Book
                        command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "select * from Author2Book where bookid = @bookid"
                        };
                        command.Parameters.AddWithValue("@id", bookId);
                        var reader1 = command.ExecuteReader();
                        List<Author2Book> author2Books = new List<Author2Book>();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                author2Books.Add(new Author2Book
                                {
                                    AuthorId = reader1.GetInt32(0),
                                    //Author = new AuthorRepository().Get(reader.GetInt32(0)),
                                    BookId = reader1.GetInt32(1),
                                    //Book = new BookRepository().Get(reader.GetInt32(1))
                                });
                            }
                        }
                        reader1.Close();
                        #endregion
                        #region BooksOnHands
                        command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "select * from BooksOnHands where bookid = @bookid"
                        };
                        command.Parameters.AddWithValue("@id", bookId);
                        reader1 = command.ExecuteReader();
                        List<BookOnHands> booksOnHands = new List<BookOnHands>();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                booksOnHands.Add(new BookOnHands
                                {
                                    BookId = reader1.GetInt32(0),
                                    UserId=reader1.GetInt32(1)
                                });
                            }
                        }
                        #endregion
                        books.Add(new Book
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            GenreId = reader.GetInt32(2),
                            Pages = reader.GetInt32(3),
                            Description = reader.GetString(4),
                            InStock = reader.GetInt32(5),
                            Genre = genre,
                            Author2Books = author2Books,
                            BooksOnHands = booksOnHands
                        });
                    }
                }
                return books;
            }
        }

        public void Update(Book entity)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "update Books set title=@title, genreid=@genreid, pages=@pages, description=@description, instock=@instock where id=@id "
                };
                command.Parameters.AddWithValue("@title", entity.Title);
                command.Parameters.AddWithValue("pages", entity.Pages);
                command.Parameters.AddWithValue("description", entity.Description);
                command.Parameters.AddWithValue("@genreid", entity.GenreId);
                command.Parameters.AddWithValue("@instock", entity.InStock);
                command.Parameters.AddWithValue("@id", entity.Id);
                command.ExecuteNonQuery();
                #region Author2Book
                command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Author2Book where bookid = @bookid"
                };
                command.Parameters.AddWithValue("@id", entity.Id);
                var reader = command.ExecuteReader();
                List<Author2Book> author2Books = new List<Author2Book>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        author2Books.Add(new Author2Book
                        {
                            AuthorId = reader.GetInt32(0),
                            BookId = reader.GetInt32(1)
                        });
                    }
                }
                if(author2Books!=entity.Author2Books)
                {
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "delete from Author2Book where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                    foreach (var item in entity.Author2Books)
                    {
                        command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "insert into Author2Book values (@authorid, @bookid)"
                        };
                        command.Parameters.AddWithValue("@authorid", item.AuthorId);
                        command.Parameters.AddWithValue("@bookid", item.BookId);
                        command.ExecuteNonQuery();
                    }
                }
                reader.Close();
                #endregion
                #region BooksOnHands
                command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from BooksOnHands where bookid = @bookid"
                };
                command.Parameters.AddWithValue("@id", entity.Id);
                reader = command.ExecuteReader();
                List<BookOnHands> booksOnHands = new List<BookOnHands>();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        booksOnHands.Add(new BookOnHands
                        {
                            BookId = reader.GetInt32(0),
                            UserId = reader.GetInt32(1)
                        });
                    }
                }
                if (booksOnHands != entity.BooksOnHands)
                {
                    command = new SqlCommand
                    {
                        Connection = connection,
                        CommandText = "delete from BooksOnHands where bookid = @id"
                    };
                    command.Parameters.AddWithValue("@id", entity.Id);
                    command.ExecuteNonQuery();
                    foreach (var item in entity.BooksOnHands)
                    {
                        command = new SqlCommand
                        {
                            Connection = connection,
                            CommandText = "insert into BooksOnHands values (@bookid, @userid)"
                        };
                        command.Parameters.AddWithValue("@userid", item.UserId);
                        command.Parameters.AddWithValue("@bookid", item.BookId);
                        command.ExecuteNonQuery();
                    }
                }
                #endregion
            }
        }
    }
}
