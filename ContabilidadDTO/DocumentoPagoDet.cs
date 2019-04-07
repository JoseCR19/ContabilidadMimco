using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class DocumentoPagoDet
    {
        public String DocumentoPagoDetNroVoucher { get; set; }
        public int DocumentoPagoDetId { get; set; } 
        public double DocumentoPagoDetPago { get; set; }
        public double DocumentoPagoDetPagoDolar { get; set; }
        public double DocumentoPagoDetRetencion { get; set; }
        public double DocumentoPagoDetRetencionDolar { get; set; }
        public String DocumentoPagoDetDescripcion { get; set; }
        public String DocumentoPagoDetNroDocRef { get; set; }
        public String DocumentoPagoDetSerieRef { get; set; }
        public String DocumentoPagoDetTipoDocumentoCod { get; set; }
        public String DocumentoPagoDetTipoDocumento { get; set; }
        public String DocumentoPagoDetCodOT { get; set; }
        public String DocumentoPagoDetRuc { get; set; }
        public String DocumentoPagoDetCodMoneda { get; set; }

        public DateTime DocumentoPagoDetFecha { get; set; }
        
    }
}
