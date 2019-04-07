using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class DetalleReporte
    {
        public String Serie { get; set; }
        public String Numero { get; set; }
        public Double Subtotal { get; set; }
        public Double Igv { get; set; }
        public Double Total { get; set; }
        public String NroOt { get; set; }
        
    }
}
