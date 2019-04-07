using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Pago
    {
        public int PagoId { get; set; }
        public String PagoDescripcion { get; set; }
        public String PagoCod { get; set; }
        public int Dias { get; set; }

    }
}
