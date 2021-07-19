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
    public class AuthorRepository : IRepository<Author>
    {
        public void Create(Author entity)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "insert into Authors values(@firstname, @lastname, @birth)"
                };
                command.Parameters.AddWithValue("@firstname", entity.FirstName);
                command.Parameters.AddWithValue("@lastname", entity.LastName);
                command.Parameters.AddWithValue("@birth", entity.Birth);
                command.ExecuteNonQuery();
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
                    CommandText = "delete from Authors where id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "delete from Author2Book where id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public Author Get(int id)
        {
            Author author = null;
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Authors where id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                if(reader.HasRows && reader.Read())
                {
                    author = new Author();
                    author.Id = reader.GetInt32(0);
                    author.FirstName = reader.GetString(1);
                    author.LastName = reader.GetString(2);
                    author.Birth = reader.GetDateTime(3);
                }
                reader.Close();
                //command = new SqlCommand
                //{
                //    Connection = connection,
                //    CommandText = "select * from Author2Book where authorid = @id"
                //};
                //command.Parameters.AddWithValue("@id", id);
                //reader = command.ExecuteReader();
                //List<Author2Book> author2Books = new List<Author2Book>();
                //if (reader.HasRows)
                //{
                //    while (reader.Read())
                //    {
                //        author2Books.Add(new Author2Book
                //        {
                //            AuthorId = reader.GetInt32(0),
                //            //Author= author,
                //            BookId = reader.GetInt32(1),
                //            //Book=new BookRepository().Get(reader.GetInt32(1))
                //        });
                //    }
                //}
                //author.Author2Books = author2Books;
            }
            return author;
        }

        public List<Author> GetAll()
        {
            List<Author> authors = new List<Author>();
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Authors"
                };
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var authorId = reader.GetInt32(0);
                        //command = new SqlCommand
                        //{
                        //    Connection = connection,
                        //    CommandText = "select * from Author2Book where authorid = @authorid"
                        //};
                        //command.Parameters.AddWithValue("@id", authorId);
                        //reader = command.ExecuteReader();
                        //List<Author2Book> author2Books = new List<Author2Book>();
                        //if (reader.HasRows)
                        //{
                        //    while (reader.Read())
                        //    {
                        //        author2Books.Add(new Author2Book
                        //        {
                        //            AuthorId = reader.GetInt32(0),
                        //            //Author = new AuthorRepository().Get(reader.GetInt32(0)),
                        //            BookId = reader.GetInt32(1),
                        //            //Book = new BookRepository().Get(reader.GetInt32(1))
                        //        });
                        //    }
                        //}
                        authors.Add(new Author
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Birth = reader.GetDateTime(3),
                            //Author2Books=author2Books
                        });
                    }
                }
                return authors;
            }
        }

        public void Update(Author entity)
        {
            using (var connection = DbConnectionFactory.Factory.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "update Authors set firstname = @firstname, lastname = @lastname, birth = @birth where id = @id)"
                };
                command.Parameters.AddWithValue("@firstname", entity.FirstName);
                command.Parameters.AddWithValue("@lastname", entity.LastName);
                command.Parameters.AddWithValue("@birth", entity.Birth);
                command.Parameters.AddWithValue("@id", entity.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
