using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class CuentaContable
    {
     
        public String CContableCuenta { get; set; }
        public String CContableDescripcion { get; set; }
        public DateTime CContableFechaAdd { get; set; }
        public String CContableUsuAdd { get; set; }
        public DateTime CContableFechaMod { get; set; }
        public String CContableUsuMod { get; set; }

    }
}
