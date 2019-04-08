using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class ReporteFacturaC
    {
        public String estado { set; get; }
        public String FechaEmision { set; get; }
        public String FechaVencimiento { set; get; }
        public String TSD { set; get; }
        public String Ruc { set; get; }
        public Boolean chkSelc { get; set; }
        public String RazonSocial { set; get; }
        public String Moneda { set; get; }
        public String TC { set; get; }
        public Double Total { set; get; }
        public Double Abono { set; get; }
        public Double Saldo { set; get; }
        public String FechaEntrega { set; get; }
        public String HoraEntrega { set; get; }
        public Double TotalSoles { get; set; }
        public Double TotalDolares { get; set; }
        public String Usuario { get; set; }
        public String Anio { get; set; }
        public String Mes { get; set; }

    }
}
