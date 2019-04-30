using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class VoucherDet
    {
        public String NumeroVoucher { get; set; }
        public String CodEnt { get; set; }
        public int Item { get; set; }
        public Double Importe { get; set; }
        public Double ImporteReporte { get; set; }
        public String Descripcion { get; set; }
        public String SerieDocRef { get; set; }
        public String NumeroDocRef { get; set; }
        public String TipDocRef { get; set; }
        public String CodOt { get; set; }
        public String CodOtReal { get; set; }

        public String NroOt { get; set; }
        public String NroOtReal { get; set; }
        public String TipoPagoCod { get; set; }
        public String TipoPago { get; set; }
        public String DirOt { get; set; }
        public String DirOtReal { get; set; }

        public String NroDocumento { get; set; }
        public Double TotalDocumento { get; set; }
        public String numeroRegistro { get; set; }
        public String RazonSocial { get; set; }
        public String Documento { get; set; }

        public String xret { get; set; }
        public String xper { get; set; }
        public String xbue { get; set; }
        public String xdetra { get; set; }

        public String FechaEmiRef { get; set; }

        public Double TC { get; set; }
        public String Moneda { get; set; }
        public String TAOB { get; set; }
        public Double SaldoDetraccion { get; set; }

    }
}
