using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class CajaDet
    {
        public int NumeroOperacion { get; set; }
        public String NumeroCaja { get; set; }
        public String CodEnt { get; set; }
        public String Ruc { get; set; }
        public DateTime FechaOperacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public String TipoDocRef { get; set; }
        public String SerieDocRef { get; set; }
        public String NroDocRef { get; set; }
        public String DescripcionOperacion { get; set; }
        public String MonedaCod { get; set; }
        public Double SubTotal { get; set; }
        public Double IGV { get; set; }
        public Double Total { get; set; }
        public String CodGas { get; set; }
        public String CuentaContable { get; set; }
        public String CodOt { get; set; }
        public String NroOt { get; set; }

        public String Motivo { get; set; }
        public String Tper { get; set; }
        public String Distrito { get; set; }
        public String CodConcepto { get; set; }
        public String Origen { get; set; }
        public String Pedido { get; set; }
        public int Lote { get; set; }
        public String CodentOt { get; set; }
        public String NroDocumento { get; set; }
        public String CentroLabor { get; set; }
        public String TipoDocCorta { get; set; }
        public String Proveedor { get; set; }
        
    }
}
