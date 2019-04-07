using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class AbonoBancoDet
    {
        public int Id { get; set; }
        public int IdAbonoCab { get; set; }
        public String Serie { get; set; }
        public String Numero { get; set; }
        public Double Importe { get; set; }
        public String Tabla { get; set; }

    }
}
