using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class RetencionDet
    {
        public int RetencionDet_Id { get; set; }
        public String RetencionDet_Serie { get; set; }
        public String RetencionDet_Numero { get; set; }
        public Double RetencionDet_MontoSoles { get; set; }
        public Double RetencionDet_MontoDolares { get; set; }
        public Double RetencionDet_RetencionSoles { get; set; }
        public Double RetencionDet_RetencionDolares { get; set; }
        public String RetencionDet_TipoDocRef { get; set; }
        public String RetencionDet_SerieRef { get; set; }
        public String RetencionDet_NumeroRef { get; set; }
        public String RetencionDet_Voucher { get; set; }
        public DateTime RetencionDet_FechaRef { get; set; }
        public String RetencionDet_TipoDocumentoRef { get; set; }

    }
}
