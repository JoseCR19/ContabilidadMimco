using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class DocumentoCab
    {
        public String DocumentoCabNro { get; set; }
        public String DocumentoCabSerie { get; set; }
        public String DocumentoCabClienteDireccion { get; set; }
        public String DocumentoCabTipoDoc { get; set; }
        public String DocumentoCabDoc { get; set; }
        public int DocumentoCabTipoPago { get; set; }
        public String DocumentoCabPago { get; set; }
        public String DocumentoCabClienteCod { get; set; }
        public String DocumentoCabCliente { get; set; }
        public String DocumentoCabDocu { get; set; }
        public DateTime DocumentoCabFecha { get; set; }
        public DateTime DocumentoCabFechaVcto { get; set; }
        public String DocumentoCabTipoMoneda { get; set; }
        public String DocumentoCabMoneda { get; set; }
        public Double DocumentoCabTotalSinIGV { get; set; }
        public Double DocumentoCabIGV { get; set; }
        public Double DocumentoCabTotal { get; set; }
        public String DocumentoCabGlosa { get; set; }
        public DateTime DocumentoCabFechaAdd { get; set; }
        public String DocumentoCabUsuAdd { get; set; }
        public DateTime DocumentoCabFechaMod { get; set; }
        public String DocumentoCabUsuMod { get; set; }
        public String DocumentoCabClienteDocumento { get; set; }
        public String DocumentoCabTipoNotaCredito { get; set; }
        public String DocumentoCabNotaCredito { get; set; }
        public String DocumentoCabTipoNotaCreditoSunat { get; set; }
        public String DocumentoCabTipoNotaDebito { get; set; }
        public String DocumentoCabNotaDebito { get; set; }
        public String DocumentoCabTipoNotaDebitoSunat { get; set; }
        public String DocumentoCabNroRef { get; set; }
        public String DocumentoCabSerieRef { get; set; }
        public String DocumentoCabTipoDocRef { get; set; }
        public DateTime DocumentoCabFechaDocRef { get; set; }
        public String DocumentoCabDocRef { get; set; }
        public String DocumentoCabOtCod { get; set; }
        public Double DocumentoCabAbono { get; set; }
        public Double DocumentoCabAbonoSuma { get; set; }
        public Double DocumentoCabSaldo { get; set; }
        public Double DocumentoCabDetraccion { get; set; }
        public Double DocumentoCabDetraccionPorcentaje { get; set; }
        public String DocumentoCabOrdenCompra { get; set; }
        public String DocumentoCabGuia { get; set; }
        public DateTime DocumentoCabFechaVctoDocRef { get; set; }
        public String DocumentoCabClienteCodAval { get; set; }
        public String DocumentoCabClienteAval { get; set; }
        public String DocumentoCabClienteDireccionAval { get; set; }
        public String DocumentoCabClienteTelefono { get; set; }
        public String DocumentoCabClienteTelefonoAval { get; set; }
        public String DocumentoCabClienteRucAval { get; set; }
        public int DocumentoCabDividir { get; set; }
        public int EstadoSunat { get; set; }
        public String DocumentoCabTabla { get; set; }
        public int DocumentoCabItemOt { get; set; }
        public String NumeroRegistro { get; set; }
    }
}
