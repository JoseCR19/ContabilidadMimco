using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class FacturaReporteDTO
    {
        public String Serie { get; set; }
        public String Numero { get; set; }
        public String RUC { get; set; }
        public String RazonSocial { get; set; }
        public String Direccion { get; set; }
        public String FechaEmision { get; set; }
        public String FechaVcto { get; set; }
        public String OrdenCompra { get; set; }
        public String TipoPago { get; set; }
        public String Moneda { get; set; }
        public String GuiaRemision { get; set; }
        public String ProdCod { get; set; }
        public String ProdDescrip { get; set; }
        public String Cantidad { get; set; }
        public String UM { get; set; }
        public String ValorUnitario { get; set; }
        public String Descuento { get; set; }
        public String PrecioUnitario { get; set; }
        public String ValorVenta { get; set; }
        public String TotalSinIGV { get; set; }
        public String IGV { get; set; }
        public String TOTAL { get; set; }
        public String Letras { get; set; }
        public String Simbolo { get; set; }
        public String TipoDocumento { get; set; }
        public String DatoDetraccion { get; set; }
        public String DetraccionMonto { get; set; }
        public String DetraccionPorcentaje { get; set; }
        public String Glosa { get; set; }
        public String QR { get; set; }
        public String Tipo { get; set; }
        public String TipoCambio { get; set; }


    }
}
