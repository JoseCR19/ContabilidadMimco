using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class DocumentoPagoCab
    {
        public String DocumentoPagoCabRuc { get; set; }
        public String DocumentoPagoCabNroVoucher { get; set; }
        public DateTime DocumentoPagoCabFechaPago { get; set; }
        public DateTime DocumentoPagoCabFechaEmision { get; set; }
        public String DocumentoPagoCabNroCheque { get; set; }
        public String DocumentoPagoCabNroCuenta { get; set; }
        public String DocumentoPagoCabCodMoneda { get; set; }
        public String DocumentoPagoCabMoneda { get; set; }
        public String DocumentoPagoCabCtaContable { get; set; }
        public Double DocumentoPagoCabMontoPago { get; set; }
        public String DocuementoPagoCabDescripcion { get; set; }
    }
}
