using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Cheque
    {
        public int Correlativo { get; set; }
        public String BancoCod { get; set; }
        public String Banco { get; set; }
        public String CodEnt { get; set; }
        public String MonedaCod { get; set; }
        public String CuentaBanco { get; set; }
        public String NroChequeInicio { get; set; }
        public String NroChequeFin { get; set; }
        public String NroChequeActual { get; set; }
    }
}
