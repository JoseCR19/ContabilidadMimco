using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Proveedor
    {
        public String ProveedorCod { get; set; }
        public String ProveedorRazonSocial { get; set; }
        public int ProveedorTipoDoc { get; set; }
        public String ProveedorDoc { get; set; }
        public String ProveedorNDoc { get; set; }
        public String ProveedorDireccion { get; set; }
        public String ProveedorTelefono { get; set; }
        public String ProveedorContacto { get; set; }
        public DateTime ProveedorFechaAdd { get; set; }
        public String ProveedorUsuAdd { get; set; }
        public DateTime ProveedorFechaMod { get; set; }
        public String ProveedorUsuMod { get; set; }
        public String ProveedorTipo { get; set; }
    }
}
