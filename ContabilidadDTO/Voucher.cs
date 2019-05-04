using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Voucher
    {
        public String NumeroVoucher { get; set; }
        public String CodEnt { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaEmision { get; set; }
        public String NumeroCheque { get; set; }
        public String NumeroCuenta { get; set; }
        public String MonedaCod { get; set; }
        public String Moneda { get; set; }
        public String TpersonaCod { get; set; }
        public String Tpersona { get; set; }
        public String SolicitaCod { get; set; }
        public String Solicitante { get; set; }
        public String CuentaContable { get; set; }
        public String AccionPago { get; set; }
        public String BancoCod { get; set; }
        public String Banco { get; set; }
        public Double Monto { get; set; }
        public String TipVou { get; set; }
        public String Estado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public String EstadoVuelto { get; set; }
        public String Observacion { get; set; }
        public String EstadoS { get; set; }
        public String Anulado { get; set; }
        public String EstadoCheque {get;set;}
        public String Ejercicio { get; set; }
        public String Periodo { get; set; }
        public String TipoMovimiento { get; set; }
        public Boolean chkSelc { get; set; }

    }
}
