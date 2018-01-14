using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrvnetSync.Models
{
    public class EntradaStock : BaseEntity
    {
        //entradastock
        public double refid { get; set; }
        public string referencia { get; set; }
        public string estado { get; set; }
        public string nota { get; set; }
        public string ubicacion { get; set; }
        public decimal precio { get; set; }
        public DateTime fechaentrada { get; set; }
        public DateTime fucambio { get; set; }
        public string metadatos { get; set; }
        public DateTime fechamod { get; set; }

        //referencia
        public string bastidor { get; set; }
        public string marca { get; set; }
        public string modelo { get; set; }
        public string version { get; set; }

        public string articulo { get; set; }

        public string familia { get; set; }

        public int inicio { get; set; }

        public int fin { get; set; }

        //vehiculo
        public string color { get; set; }
        public string fmatric { get; set; }
        public string tipocombutible { get; set; }
        public int puertas { get; set; }
        public string nombreversion { get; set; }

        //img
        

    }
}
