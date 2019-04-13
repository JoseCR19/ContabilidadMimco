using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class Compras
    {
        public String ComprasId { get; set; }
        public String FechaEmision { get; set; }
        public String FechaVcto { get; set; }
        public String TipoDocumento { get; set; }
        public String Serie { get; set; }
        public String Numero { get; set; }
        public String TipoDocIdentidad { get; set; }
        public String Ruc { get; set; }
        public String RazonSocial { get; set; }
        public Double Gravado { get; set; }
        public Double IGV { get; set; }
        public Double Gravado2 { get; set; }
        public Double Gravado2Igv { get; set; }
        public Double NoGravada { get; set; }
        public Double NoGravadaIgv { get; set; }
        public Double ISC { get; set; }
        
        public Double OtrosTributos { get; set; }
        public Double Total { get; set; }
        public String FechaEmisionRef { get; set; }
        public Double TipoCambio { get; set; }
        public String TipoDocumentoRef { get; set; }
        public String SerieRef { get; set; }
        public String NumeroRef { get; set; }
        public Double TasaIGV { get; set; }
        public String DSI { get; set; }
        public String ComprobanteNoDomiciliado { get; set; }
        public Double ValorNoGravadas { get; set; }
        public Double Reclasificacion { get; set; }
        public String DetraccionNum { get; set; }
        public String DetraccionFecha { get; set; }
        public String Moneda { get; set; }


    }
}
