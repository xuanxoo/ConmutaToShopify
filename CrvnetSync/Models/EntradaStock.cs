using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrvnetSync.Models
{
    public class EntradaStock : BaseEntity
    {
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

        public string bastidor { get; set; }

    }
}
