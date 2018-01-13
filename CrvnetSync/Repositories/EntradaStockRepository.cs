using CrvnetSync.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CrvnetSync.Repositories
{
    public class EntradaStrockRepository : BaseRepository
    {

        public IEnumerable<EntradaStock> Almacenadas()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<EntradaStock>("SELECT * FROM entradastock where ubicacion = 'Almacenada' and precio > 0 limit 10");
            }
        }
    }
}
