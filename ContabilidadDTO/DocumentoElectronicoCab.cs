using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class DocumentoElectronicoCab
    {
        public String TipoDocumento { get; set; }
        public String Serie { get; set; }
        public String NumeroString { get; set; }
        public String Numero { get; set; }
        public String Operacion { get; set; }
        public String TipoDocumentoCliente { get; set; }
        public String NroDocCliente { get; set; }
        public String RazonSocialCliente { get; set; }
        public String DireccionCliente { get; set; }
        public String EmailCliente { get; set; }
        public String FechaEmision { get; set; }
        public String FechaVencimiento { get; set; }
        public String Moneda { get; set; }
        public String TipoCambio { get; set; }
        public String Igv { get; set; }
        public String TotalGravada { get; set; }
        public String TotalIgv { get; set; }
        public String Total { get; set; }
        public String DescuentoGlobal { get; set; }
        public String TotalDescuento { get; set; }
        public String TotalAnticipo { get; set; }
        public String TotalInafecta { get; set; }
        public String TotalExonerada { get; set; }
        public String TotalGratuita { get; set; }
        public String TotalOtrosCargos { get; set; }
        public String TipoPercepcion { get; set; }
        public String TotalPercepcion { get; set; }
        public String BaseImponiblePercepcion { get; set; }
        public String TotalIncluidoPercepcion { get; set; }
        public String Detraccion { get; set; }
        public String Observacion { get; set; }
        public String FormaPago { get; set; }
        public String TipoDocumentoRef { get; set; }
        public String SerieRef { get; set; }
        public String NumeroRef { get; set; }
        public String TipoNotaCredito { get; set; }
        public String TipoNotaDebito { get; set; }
        public String MedioPago { get; set; }
        public String PlacaVehiculo { get; set; }
        public String OrdenServicio { get; set; }
        
    }
}
