using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class TipoImpuesto
    {

        public String Codigo { get; set; }
        public String Descripcion { get; set; }
        public Double Pago { get; set; }
        public Boolean chkSelc { get;set;}
    }
}
