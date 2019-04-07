using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class CargoBancario
    {
        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public Double Monto { get; set; }
        public Boolean chkSelc { get; set; }
    }
}
