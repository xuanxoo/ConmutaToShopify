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
    public class ReferenciaRepository : BaseRepository
    {
        public Referencia ReferenciaById(string referenciaId)
        {
            Referencia referencia = null;
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var refsDB = dbConnection.Query<Referencia>("SELECT * FROM referencias where referencia = '"+ referenciaId + "' limit 1");
                if (refsDB != null && refsDB.Count() > 0)
                    referencia = refsDB.First();

                dbConnection.Close();
            }
            return referencia;
        }
    }
}
