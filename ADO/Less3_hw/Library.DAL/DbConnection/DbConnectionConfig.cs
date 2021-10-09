using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DAL.DbConnection
{
    public static class DbConnectionConfig
    {
        public static string ConnectionString
            => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}
