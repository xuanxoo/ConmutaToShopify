using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrvnetSync.Repositories
{
    public class BaseRepository
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;


        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }
    }
}
