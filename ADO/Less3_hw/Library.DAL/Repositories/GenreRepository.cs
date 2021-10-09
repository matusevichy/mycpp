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
    public class GenreRepository : IRepository<Genre>
    {
        public void Create(Genre entity)
        {
            //using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            //{
            //    connection.Open();
            //    var command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = "INSERT INTO Genres VALUES (@name)"
            //    };
            //    command.Parameters.AddWithValue("@name", entity.Name);
            //    command.ExecuteNonQuery();
            //}
        }

        public void Delete(int id)
        {
            //using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            //{
            //    connection.Open();
            //    var command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = "DELETE FROM Genres WHERE id = @id"
            //    };
            //    command.Parameters.AddWithValue("@id", id);
            //    command.ExecuteNonQuery();
            //    command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = "UPDATE Books SET genreid=null WHERE id = @id"
            //    };
            //    command.Parameters.AddWithValue("@id", id);
            //    command.ExecuteNonQuery();
            //}
        }

        public Genre Get(int id)
        {
            Genre genre = null;
            //using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            //{
            //    connection.Open();
            //    var command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = "SELECT * FROM Genres WHERE id = @id"
            //    };
            //    command.Parameters.AddWithValue("@id", id);
            //    var reader = command.ExecuteReader();

            //    if (reader.HasRows && reader.Read())
            //    {
            //        genre = new Genre();
            //        genre.Id = reader.GetInt32(0);
            //        genre.Name = reader.GetString(1);
            //    }

            //}
            return genre;
        }

        public List<Genre> GetAll()
        {
            List<Genre> genres = new List<Genre>();
            //using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            //{
            //    connection.Open();
            //    var command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = "SELECT * FROM Genres"
            //    };
            //    var reader = command.ExecuteReader();

            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            genres.Add(new Genre
            //            {
            //                Id = reader.GetInt32(0),
            //                Name = reader.GetString(1)
            //            });
            //        }
            //    }
            //}
            using (var ctx = DbConnectionFactory.Factory.GetLibraryContextConnection())
            {
                genres = ctx.GetTable<Genre>().ToList();
            }
            return genres;
        }

        public void Update(Genre entity)
        {
            //using (var connection = DbConnectionFactory.Factory.GetSQLConnection())
            //{
            //    connection.Open();
            //    var command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandText = "UPDATE Genres SET name = @name WHERE id = @id"
            //    };
            //    command.Parameters.AddWithValue("@name", entity.Name);
            //    command.Parameters.AddWithValue("@id", entity.Id);
            //    command.ExecuteNonQuery();
            //}
        }
    }
}
