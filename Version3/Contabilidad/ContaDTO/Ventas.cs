using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class Ventas
    {
        public String VentasId { get; set; }
        public String FechaEmision { get; set; }
        public String FechaVcto { get; set; }
        public String TipoDocumento { get; set; }
        public String Serie { get; set; }
        public String Numero { get; set; }
        public String TipoDocIdentidad { get; set; }
        public String Ruc { get; set; }
        public String RazonSocial { get; set; }
        public Double Exportacion { get; set; }
        public Double Gravado { get; set; }
        public Double Exonerado { get; set; }
        public Double Inafecta { get; set; }
        public Double ISC { get; set; }
        public Double IGV { get; set; }
        public Double OtrosTributos { get; set; }
        public Double Total { get; set; }
        public String FechaEmisionRef { get; set; }
        public String Moneda { get; set; }
        public Double TipoCambio { get; set; }
        public String TipoDocumentoRef { get; set; }
        public String SerieRef { get; set; }
        public String NumeroRef { get; set; }
        public Double TasaIGV { get; set; }
    }
}
