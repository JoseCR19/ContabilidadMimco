using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class PrestamoBancario
    {
        public String CodigoPrestamo { get; set; }
        public String CodBanco { get; set; }
        public String Banco { get; set; }
        public String Moneda { get; set; }
        public Double Monto { get; set; }
        public String FechaEmision { get; set; }
        public String FechaVcto { get; set; }
        public Boolean chkSelc { get; set; }
        public String NroCuenta { get; set; }
        public Double Abono { get; set;}
        public Double Saldo { get; set;}
    }
}
