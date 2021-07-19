using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less1_hw
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            List<Shipper> shippers = new List<Shipper>();
            int shippersCount;
            Shipper newShipper = new Shipper
            {
                CompanyName = "Some company",
                Phone = "(095)111 11 11"
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "select * from Shippers"
                };
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Shipper shipper = new Shipper
                            {
                                Id = reader.GetInt32(0),
                                CompanyName = reader.GetString(1),
                                Phone = reader.GetString(2)
                            };
                            shippers.Add(shipper);
                        }
                    }
                }
            }
            Console.WriteLine(String.Join("\n", shippers));

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "Select count(*) from Shippers"
                };
                shippersCount=(int)command.ExecuteScalar();
            }
            Console.WriteLine($"Count the records in Shippers = {shippersCount}");
            Console.Read();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = "insert into Shippers values (@name, @phone)"
                };
                command.Parameters.AddWithValue("@name", newShipper.CompanyName);
                command.Parameters.AddWithValue("@phone", newShipper.Phone);
                
                command.ExecuteNonQuery();
                Console.WriteLine("Success!");
            }
        }
    }
}
