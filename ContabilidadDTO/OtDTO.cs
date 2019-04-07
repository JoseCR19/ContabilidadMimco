using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class OtDTO
    {
        public int Item { get; set; }
        public String NumeroOt { get; set; }
        public String CodigoOt { get; set; }
        public String EstadoOt { get; set; }
        public String TipoDoc { get; set; }
        public String Documento { get; set; }
        public Double Porcentaje { get; set; }
        public Double Importe { get; set; }
        public String Tabla { get; set; }
        public String CuentaContable { get; set; }

        public String ProductoCodigo { get; set; }
        public String UnidadMedida { get; set; }
        public String ProductoDescripcion { get; set; }
        public String Descripcion { get; set; }
        public String DirOt { get; set; }

    }
}
