using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class EnvioMasivoContinentalCab
    {
        public int TipoRegistro { get; set; }
        public String CuentaCargo { get; set; }
        public String MonedaCargo { get; set; }
        public Double ImporteCargar { get; set; }
        public String TipoProceso { get; set; }
        public DateTime FechaProceso { get; set; }
        public String HoraProceso { get; set; }
        public String Referencia { get; set; }
        public int TotalRegistros { get; set; }
        public String ValidacionPertenecia { get; set; }
        public int ValorControl { get; set; }
        public int IndicadorProceso { get; set; }
        public String Descripcion { get; set; }
        public String Filler { get; set; }
    }
}
