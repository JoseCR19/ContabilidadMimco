using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Compras
    {
        public int ComprasId { get; set; }
        public int DocumentoCabId { get; set; }
        public String DocumentoCabNro { get; set; }
        public int PagoId { get; set; }
        public int RubrosId { get; set; }
        public String RubrosCod { get; set; }
        public DateTime ComprasFechaAdd { get; set; }
        public int ComprasUsuAdd { get; set; }
        public DateTime ComprasFechaMod { get; set; }
        public int ComprasUsuMod { get; set; }
    }
}
