using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class LetraDetalle
    {
        public int Item { set; get; }
        public String TipDoc { set; get; }
        public String NroDoc { set; get; }
        public String Moneda { set; get; }
        public String CodEnt { set; get; }
        public String TipoDocRef { set; get;}
        public String SerDocRef { set; get; }
        public String NroDocRef { set; get; }
        public Double Monto { set; get; }
        public String Fec_emi_ref { set; get; }
        public String Fec_ven_ref { set; get; }
        public String EstRepDet { set; get; }
        public String RucProv { set; get; }
        public String NomProv { get; set; }
        public Double Abono { get; set; }
        public Double Saldo { get; set; }
        public String NroRegistro { get; set; }
        public Double AbonoLetra { get; set; }
        public String NroRegistroLetra { get; set; }


    }
}
