using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class AsientoDetalle
    {
        public String TipoAsiento { get; set; }
        public String Correlativo { get; set; }
        public String Cuenta { get; set; }
        public String TipoImporte { get; set; }
        public Double Importe { get; set; }
        public String Fecha { get; set; }
        public String FechaDoc { get; set; }
        public String FechaVcto { get; set; }
        public String TipoDoc { get; set; }
        public String Anexo { get; set; }
        public String Documento { get; set; }
        public String TipDocCodigo { get; set; }
        public String NumReg { get; set; }
    }
}
