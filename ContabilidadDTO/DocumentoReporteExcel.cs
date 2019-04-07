using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class DocumentoReporteExcel
    {
        public String NroOt { get; set; }
        public String Documento { get; set; }
        public String Serie { get; set; }
        public String Numero { get; set; }
        public String Peso { get; set; }
        public String Precio { get; set; }
        public String Subtotal { get; set; }
        public String IGV { get; set; }
        public String Total { get; set; }
        public String Fecha { get; set; }
        public String FechaVcto { get; set; }
        public String Pago { get; set; }
        public String OrdenCompra { get; set; }
        public String RazonSocial { get; set; }
        public String RUC { get; set; }
        public String Moneda { get; set; }
        public String Estado { get; set; }
        public String TipoCambio { get; set; }
        public String Rango {get;set;}
        public String TotalSoles { get; set; }
        public String TotalDolares { get; set; }
        public String SubtotalSoles { get; set; }
        public String IGVSoles { get; set; }
        public String SubtotalDolares { get; set; }
        public String IGVDolares { get; set; }
    }
}
