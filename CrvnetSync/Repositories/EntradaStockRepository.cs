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
                var listado = dbConnection.Query<EntradaStock>(
                    "select es.refid, es.referencia, es.estado, es.nota, es.ubicacion, es.precio, es.fechaentrada, es.fucambio, es.metadatos, es.fechamod,"+
                    "v.color, v.fmatric, v.tipocombustible, v.puertas, v.nombreversion, " +
                    "r.marca, r.modelo, r.version, r.articulo, r.familia, r.inicio, r.fin from entradastock es " +   
                    "inner join referencias r on r.referencia = es.referencia "+
                    "inner  join stockvehiculo sv on sv.refid = es.refid "+
                    "inner join vehiculos v on v.idvehiculo = sv.idvehiculo "+
                    "where ubicacion = 'Almacenada' and precio > 0 limit 10");

                dbConnection.Close();
                return listado;
            }
        }

        public IEnumerable<AlbumPiezas> ImagenesPieza(double refId)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                var listado = dbConnection.Query<AlbumPiezas>(
                    "select idficherofoto from albumpiezas "+
                    "where refid = "+refId+"");

                dbConnection.Close();
                return listado;
            }
        }
    }
}
