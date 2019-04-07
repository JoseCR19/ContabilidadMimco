using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
     public class DocumentoElectronicoDet
    {
        public String UnidadMedida { get; set; }
        public String ProductoCodigo { get; set; }
        public String ProductoDescripcion { get; set; }
        public String Cantidad { get; set; }
        public String ValorUnitario { get; set; }
        public String PrecioUnitario { get; set; }
        public String Subtotal { get; set; }
        public String TipoIgv { get; set; }
        public String TotalIgvLinea { get; set; }
        public String TotalLinea { get; set; }
        public String Anticipo { get; set; }
    }
}
