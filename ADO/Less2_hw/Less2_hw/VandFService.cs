using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less2_hw
{
    public class VandFService
    {
        string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

        public List<VandF> GetAll()
        {
            List<VandF> vandFs = new List<VandF>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select * from VandF"
                };
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            VandF vandF = new VandF
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                Color = reader.GetString(3),
                                Calories = reader.GetDecimal(4)
                            };
                            vandFs.Add(vandF);
                        }
                    }
                }
            }
            return vandFs;
        }

        public List<string> GetNames()
        {
            List<string> names = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select distinct name from VandF"
                };
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            names.Add(reader.GetString(0));
                        }
                    }
                }
            }

            return names; 
        }

        public List<string> GetColors()
        {
            List<string> colors = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select distinct color from VandF"
                };
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            colors.Add(reader.GetString(0));
                        }
                    }
                }
            }
            return colors;
        }

        public void PrintCaloriesInfo ()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "sp_CaloriesInfo",
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                SqlParameter min = new SqlParameter
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@min"
                };
                SqlParameter max = new SqlParameter
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@max"
                };
                SqlParameter avg = new SqlParameter
                {
                    SqlDbType = System.Data.SqlDbType.Int,
                    Direction = System.Data.ParameterDirection.Output,
                    ParameterName = "@avg"
                };
                command.Parameters.AddRange(new SqlParameter[]
                {
                    min,
                    max,
                    avg
                });
                command.ExecuteNonQuery();
                Console.WriteLine($"Min: {min.Value}\tMax: {max.Value}\tAvg: {avg.Value}");
            }

        }

        public int GetCountOfType(string type)
        {
            int count=0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select count(*) from VandF where type = @type"
                };
                command.Parameters.AddWithValue("@type", type);
                count = (int)command.ExecuteScalar();
            }
            return count;
        }

        public int GetCountOfColor(string color)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select count(*) from VandF where color = @color"
                };
                command.Parameters.AddWithValue("@color", color);
                count = (int)command.ExecuteScalar();
            }
            return count;
        }

        public Dictionary<string, int> GetCountOfColors()
        {
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select color, count(*) from VandF group by color"
                };
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            keyValuePairs.Add(reader.GetString(0), reader.GetInt32(1));
                        }
                    }
                }
            }
            return keyValuePairs;
        }

        public List<VandF> GetOfCaloriesInRange(int min, int max)
        {
            List<VandF> vandFs = new List<VandF>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select * from VandF where calories between @min and @max"
                };
                command.Parameters.AddWithValue("@min", min);
                command.Parameters.AddWithValue("@max", max);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            VandF vandF = new VandF
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                Color = reader.GetString(3),
                                Calories = reader.GetDecimal(4)
                            };
                            vandFs.Add(vandF);
                        }
                    }
                }
            }
            return vandFs;
        }

        public List<VandF> GetOfColorList(List<string> colors)
        {
            List<VandF> vandFs = new List<VandF>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Success connection");
                var newColors = colors.Select(c => $"\'{c}\'");
                string list = String.Join(",", newColors);
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from VandF where color in (@list)"
                };
                command.Parameters.AddWithValue("@list", list);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            VandF vandF = new VandF
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Type = reader.GetString(2),
                                Color = reader.GetString(3),
                                Calories = reader.GetDecimal(4)
                            };
                            vandFs.Add(vandF);
                        }
                    }
                }
            }
            return vandFs;
        }

    }
}
