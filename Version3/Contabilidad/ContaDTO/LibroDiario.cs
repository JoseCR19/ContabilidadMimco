using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class LibroDiario
    {
        public String TipoAsiento { get; set; }
        public String Correlativo { get; set; }
        public String FechaOperacion { get; set; }
        public String Descripcion { get; set; }
        public String TipoDocumento { get; set; }
        public String Documento { get; set; }
        public String FechaDocumento { get; set; }
        public String CuentaContable { get; set; }
        public String CuentaDescripcion { get; set; }
        public String Ruc { get; set; }
        public Double Haber { get; set; }
        public Double Debe { get; set; }

    }
}
