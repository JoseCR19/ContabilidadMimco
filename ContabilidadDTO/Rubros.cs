using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Rubros
    {
        
        public String RubrosCod { get; set; }
        public String RubrosDescripcion { get; set; }
        public int RubrosTipoRubro { get; set; }
        public String RubrosTRubro { get; set; }
        public String RubrosTVenta { get; set; }
      public String RubrosVenta { get; set; }
        
        public String RubrosCContableCuenta { get; set; }
        public DateTime RubrosFechaAdd { get; set; }
        public String RubrosUsuAdd { get; set; }
        public DateTime RubrosFechaMod { get; set; }
        public String RubrosUsuMod { get; set; }

    }
}
