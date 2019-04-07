using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class OrdenCompraCab
    {
        public String OCcabCod { get; set; }
        public String ClienteCod { get; set; }
        public String OCcabCliente { get; set; }
        public String OCcabClienteDocu { get; set; }
        public DateTime OCcabFecha { get; set; }
        public DateTime OCcabFechaAdd { get; set; }
        public String OCcabUsuAdd { get; set; }
        public DateTime OCcabFechaMod { get; set; }
        public String OCcabUsuMod { get; set; }

    }
}
