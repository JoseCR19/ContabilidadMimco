using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class LetraDet
    {
        public int LetraDetId { get; set; }
        public String LetraDetSerie { get; set; }
        public String LetraDetNro { get; set; }
        public String LetraDetSerieRef { get; set; }
        public String LetraDetNroRef { get; set; }
        public DateTime LetraDetFechaEmisionRef { get; set; }
        public DateTime LetraDetFechaVctoRef { get; set; }
        public Double LetraDetTotal { get; set; }
        public Double LetraDetAbono { get; set; }
        public Double LetraDetAbonoSuma { get; set; }
        public Double LetraDetDetraccionPorcentaje { get; set; }
        public Double LetraDetDetraccion { get; set; }
        public Double LetraDetSaldo { get; set; }
        public String LetraDetCodMoneda { get; set; }
        public String LetraDetMoneda { get; set; }

    }
}
