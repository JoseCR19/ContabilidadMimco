using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Producto
    {
        public String ProductoCod { get; set; }
        public String ProductoDescripcion { get; set; }
        public Double ProductoPeso { get; set; }
        public Double ProductoLongitud { get; set; }
        public String ProductoCContableCuenta { get; set; }
        public Double ProductoPrecio { get; set; }
        public Double ProductoStockActual { get; set; }
        public String ProductoUnidadMedidaCod { get; set; }
        public String ProductoUnidadMedida { get; set; }
        public String ProductoUnidadMedidaCorta { get; set; }
        public String ProductoUnidadMedidaSunat { get; set; }
        public DateTime ProductoFechaAdd { get; set; }
        public String ProductoUsuAdd { get; set; }
        public DateTime ProductoFechaMod { get; set; }
        public String ProductoUsuMod { get; set; }

    }
}
