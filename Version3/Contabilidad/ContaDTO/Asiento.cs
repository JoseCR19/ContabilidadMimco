using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDTO
{
    public class Asiento
    {
        public String TipoAsiento { get; set; }
        public String Correlativo { get; set; }
        public String Fecha { get; set; }
        public String MonedaCod { get; set; }
        public String Moneda { get; set; }
        public Double Debe { get; set; }
        public Double Haber { get; set; }
    }
}
