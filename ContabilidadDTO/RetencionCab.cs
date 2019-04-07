using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class RetencionCab
    {
        public String RetencionCab_Serie { get; set; }
        public String RetencionCab_Numero { get; set; }
        public DateTime RetencionCab_Fecha { get; set; }
        public String RetencionCab_RucProv { get; set; }
        public String RetencionCab_CodOt { get; set; }
        public Double RetencionCab_Monto { get; set; }
        public Double RetencionCab_Retencion { get; set; }
        public String RetencionCab_Observacion { get; set; }
        public String RetencionCab_Proveedor { get; set; }
        public String RetencionCab_CodMoneda { get; set; }
        public Double RetencionCab_MontoDolar { get; set; }
        public Double RetencionCab_RetencionDolar { get; set; }

    }
}
