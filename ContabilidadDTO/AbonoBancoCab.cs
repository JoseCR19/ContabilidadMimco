using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class AbonoBancoCab
    {
        public int Id { get; set; }
        public String BancoCod { get; set; }
        public String CodEnt { get; set; }
        public String MonedaCod {get;set;}
        public String CuentaContable { get; set; }
        public String Fecha { get; set; }
        public String Observacion { get; set; }
        public String ClienteCod { get; set; }
    }
}
