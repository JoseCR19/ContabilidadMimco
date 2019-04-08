using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
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
        public Double TotalSoles { get; set; }
        public String FechaEmisionRef { get; set; }
        public Double TipoCambio { get; set; }
        public String TipoDocumentoRef { get; set; }
        public String SerieRef { get; set; }
        public String NumeroRef { get; set; }
        public Double TasaIGV { get; set; }
        public String CodEnt { get; set; }
        public String CodOt { get; set; }
        public String CodOtReal { get; set; }

        public String TipoDocumentoCod { get; set; }
        public Boolean chkSelc { get; set; }
        public String NroOt { get; set; }
        public String NroOtReal { get; set;}

        public String DirOt { get; set; }
        public String DirOtReal { get; set; }

        public String Moneda { get; set; }
        public Double Pago { get; set; }
        public String xret { get; set; }
        public String xper { get; set; }
        public String xbue { get; set; }
        public String xdetra { get; set; }

        public Double total_soles { get; set; }
        public Double total_dolares { get; set; }
        public Double AbonoLetra { get; set; }

        public String Anio { get; set; }
        public String Mes { get; set; }





    }
}
