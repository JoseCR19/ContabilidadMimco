using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class Voucher
    {
        public int Item { get; set; }
        public String NroVoucher { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaEmision { get; set; }
        public String NumeroCheque { get; set; }
        public String NumeroCuenta { get; set; }
        public String Moneda { get; set; }
        public String TpersonaCod { get; set; }
        public String Tpersona { get; set; }
        public String SolicitaCod { get; set; }
        public String Solicitante { get; set; }
        public String CuentaContable { get; set; }
        public String BancoCod { get; set; }
        public String Banco { get; set; }
        public Double Importe { get; set; }
        public String SerieDocRef { get; set; }
        public String NumeroDocRef { get; set; }
        public String TipDocRef { get; set; }
        public String CodOt { get; set; }
        public String NroOt { get; set; }
        public String TipoPagoCod { get; set; }
        public String TipoPago { get; set; }
        public String TipDocCorta { get; set; }
        public String Ruc { get; set; }
    }
}
