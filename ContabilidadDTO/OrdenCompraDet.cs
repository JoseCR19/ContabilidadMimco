using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class OrdenCompraDet
    {
        public int OCdetId { get; set; }
        public String OCcabCod { get; set; }
        public String ProductoCod { get; set; }
        public String OCdetProducto { get; set; }
        public Double OCdetCantidad { get; set; }
        public DateTime OCdetFechaAdd { get; set; }
        public String OCdetUsuAdd { get; set; }
        public DateTime OCdetFechaMod { get; set; }
        public String OCdetUsuMod { get; set; }
    }
}
