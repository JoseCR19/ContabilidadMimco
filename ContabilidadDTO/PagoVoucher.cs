using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class PagoVoucher
    {
        public String NroRegistro { get; set; }
        public int NroOperacion { get; set; }
        public Double Total { get; set; }
        public Double Abono { get; set; }
        public Double Saldo { get; set; }
        public int Estado { get; set; }
    }
}
