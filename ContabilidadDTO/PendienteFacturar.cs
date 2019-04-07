using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class PendienteFacturar
    {
        public String NroOt { get; set; }
        public Double Importe { get; set; }
        public Double Facturado { get; set; }
        public String Documentos { get; set; }
        public String FechaOt { get; set; } 
        public Double Saldo { get; set; }
        public String Cliente { get; set; }
    }
}
