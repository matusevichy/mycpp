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
    public class UserRepository : IRepository<User>
    {
        public void Create(User entity)
        {
            using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "INSERT INTO Users VALUES (@login, @password, @email)"
                };
                command.Parameters.AddWithValue("@Login", entity.Login);
                command.Parameters.AddWithValue("@password", entity.Password);
                command.Parameters.AddWithValue("@email", entity.Email);
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "DELETE FROM Users WHERE id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "delete from BooksOnHands WHERE userid = @userid"
                };
                command.Parameters.AddWithValue("@userid", id);
                command.ExecuteNonQuery();
            }
        }

        public User Get(int id)
        {
            User user = null;
            using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "SELECT * FROM Users WHERE id = @id"
                };
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();

                if (reader.HasRows && reader.Read())
                {
                    user = new User();
                    user.Id = reader.GetInt32(0);
                    user.Login = reader.GetString(1);
                    user.Password = reader.GetString(2);
                    user.Email = reader.GetString(3);
                }
            }
            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "SELECT * FROM Users"
                };
                var reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            Login = reader.GetString(1),
                            Password = reader.GetString(2),
                            Email = reader.GetString(3)
                        });
                    }
                }
            }
            return users;
        }

        public void Update(User entity)
        {
            using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            {
                connection.Open();
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "UPDATE Users SET login = @login, password = @password, email = @email WHERE id = @id"
                };
                command.Parameters.AddWithValue("@Login", entity.Login);
                command.Parameters.AddWithValue("@password", entity.Password);
                command.Parameters.AddWithValue("@email", entity.Email);
                command.Parameters.AddWithValue("@id", entity.Id);
                command.ExecuteNonQuery();
            }
        }
    }
}
