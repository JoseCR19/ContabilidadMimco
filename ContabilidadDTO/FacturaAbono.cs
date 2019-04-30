using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class FacturaAbono
    {
        public String Serie { get; set; }
        public String Numero { get; set; }
        public Double Total { get; set; }
        public Double TipoCambio { get; set; }
        public Double TotalSoles { get; set; }
        public Double Saldo { get; set; }
        public String Fecha { get; set; }
        public String FechaVcto { get; set; }
        public String Tabla { get; set; }
        public String CuentaContable { get; set; }
        public Double ImporteSoles { get; set; }
        public Double ImporteDolares { get; set; }
        public String MonedaCod { get; set; }
        public Boolean chkSelc { get; set; }
        public String Ruc { get; set; }
        public String RazonSocial { get; set; }
        public String TipoDoc { get; set; }
        public Double Pago { get; set; }
        public String NroOt { get; set; }

        public Double Total_soles { get; set; }
        public Double Total_dolares { get; set; }
        public Double Cambio { get; set; }
        public Double ImporteDetraccion { get; set; }
        public Double SaldoDetraccion { get; set; }
        public Double Total_Detraccion{ get; set;}
      
    }
}
