using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrvnetSync.Models
{
    public class Referencia : BaseEntity
    {
        public double referencia { get; set; } //entradastock id

        public string marca { get; set; }
        public string modelo { get; set; }
        public string version { get; set; }

        public string articulo { get; set; }

        public string familia { get; set; }

        public int inicio { get; set; }

        public int fin { get; set; }
    }
}
