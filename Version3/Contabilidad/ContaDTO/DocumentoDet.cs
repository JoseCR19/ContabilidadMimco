using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class DocumentoDet
    {
        public int DocumentoDetId { get; set; }

        public String DocumentoCabNro { get; set; }
        public String DocumentoCabSerie { get; set; }
        public String ProductoCod { get; set; }
        public String DocumentoDesProducto { get; set; }
        public String DocumentoProdUMcorta { get; set; }
        public String DocumentoProdUM { get; set; }
        public String DocumentoProdUMCod { get; set; }
        public String CCostosCod { get; set; }
        public String CuentaContable { get; set; }
        public String DocumentoDetCCosto { get; set; }
        public Double DocumentoDetCantidad { get; set; }
        public Double DocumentoDetPrecioSinIGV { get; set; }
        public Double DocumentoDetIGV { get; set; }
        public Double DocumentoDetSubTotal { get; set; }
        public Double DocumentoDetPrecioTotal { get; set; }
        public String DocumentoDetGlosa { get; set; }
        public DateTime DocumentoDetFechaAdd { get; set; }
        public String DocumentoDetUsuAdd { get; set; }
        public DateTime DocumentoDetFechaMod { get; set; }
        public String DocumentoDetUsuMod { get; set; }
        public String DocumentoDetTabla { get; set; }
        public String DocumentoDetNroOt { get; set; }
        public String DocumentoDetCodEnt { get; set; }
        public int DocumentoDetItemOt { get; set; }
    }
}
