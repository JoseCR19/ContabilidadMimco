using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class EnvioMasivoContinental
    {
        public int TipoRegistro { get; set; }
        public String DOITipoDocumento { get; set; }
        public String DOINumeroDocumento { get; set; }
        public String TipoAbono { get; set; }
        public String NumeroCuenta { get; set; }
        public String NombreBeneficiario { get; set; }
        public Double ImporteAbonar { get; set; }
        public String TipoDocumento { get; set; }
        public String NumeroDocumento { get; set;}
        public String AbonoAgrupado { get; set; }
        public String Referencia { get; set; }
        public String IndicadorAviso { get; set;}
        public String MedioAviso { get; set; }
        public String PersonaContacto { get; set; }
        public String IndicadorProceso { get; set; }
        public String Descripcion { get; set; }
        public String Filler { get; set; }
    }
}
