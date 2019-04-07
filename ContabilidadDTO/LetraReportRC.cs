using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDAO
{
    public class LetraReportRC
    {
        public String Serie { set; get; }
        public String NumeroLetra { set; get; }
        public DateTime FecRep { set; get; }
        public String Ruc { set; get; }
        public String Direccion { set; get; }
        public DateTime FechaReg { set; get; }
        public Double Monto { set; get; }
        public Double Abono { set; get; }
        public Double Saldo { set; get; }
        public DateTime FechaVen { set; get; }
        public String Moneda { set; get; }
        public String Estado_Doc { set; get; }
        public String RazonSocial { set; get; }
        public Double ImporteTotal { set; get; }
        public String NroRegistro { set; get; }
        public String Estados { set; get; }
        public String Anulado { set; get; }
        public int Item { set; get; }
        public String TipDoc { set; get; }
        public String NroDocDetalle { set; get; }
        public String MonedaDetalle { set; get; }
        public String TipoDocRef { set; get; }
        public String SerieDocRef { set; get; }
        public String NumDocRef { set; get; }
        public Double MontoDetalle { set; get; }
        public String FechaRegRef { set; get; }
        public String Fec_ven_ref { set; get; }
        public String EstRepDet { set; get; }
        public String RucProv { set; get; }
        public Double AbonoDetalle { get; set; }
        public Double SaldoDetalle { get; set; }
        public String NroRegistroDetalle { get; set; }
        public Double AbonoLetra { get; set; }
        public String NroRegistroLetra { get; set; }
        public String SerieNumeroLetra { get; set; }
        public Double ImporteDocRef { get; set; }
        public Double ImportePercpDocRef { get; set; }
        public Double AbonoDocRef { get; set; }
        public Double SaldoDocRef { get; set; }
        public String NumLetra { get; set; }
        public String EstadoDocumento { get; set; }

    }
}
