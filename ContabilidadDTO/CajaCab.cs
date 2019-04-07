using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class CajaCab
    {
        public String NumeroCaja { get; set; }
        public DateTime FechaApertura { get; set; }
        public String CodEnt { get; set; }
        public Double Saldo { get; set; }
        public Double Reembolso { get; set; }
        public Double Monto { get; set; }
        public Double Gasto { get; set; }
        public Double Disponible { get; set; }
        public String Estado { get; set; }
        public DateTime FechaCierre { get; set; }
        public String Periodo { get; set; }
        
        public String Usuario { get; set; }

    }
}
