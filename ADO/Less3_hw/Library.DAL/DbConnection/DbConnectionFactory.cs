using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DbConnection
{
    public class DbConnectionFactory
    {
        private static DbConnectionFactory instance;
        public static DbConnectionFactory Factory
            => instance ?? (instance = new DbConnectionFactory());
        private DbConnectionFactory() { }
        public SqlConnection GetSQLConnection()
        {
            return new SqlConnection(DbConnectionConfig.ConnectionString);
        }

        public LibraryContext GetLibraryContextConnection()
        {
            return new LibraryContext(DbConnectionConfig.ConnectionString);
        }
    }
}