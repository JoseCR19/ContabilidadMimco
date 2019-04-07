using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDTO
{
    public class Cliente
    {
        
        public String ClienteCod { get; set; }
        public String ClienteRazonSocial { get; set; }
        public int ClienteTipoDoc { get; set; }
        public String ClienteDoc { get; set; }
        public String ClienteNDoc { get; set; }
        public String ClienteDireccion { get; set; }
        public String ClienteTelefono { get; set; }
        public String ClienteContacto { get; set; }
        public DateTime ClienteFechaAdd { get; set; }
        public String ClienteUsuAdd { get; set; }
        public String ClienteUsuario { get; set; }
        public DateTime ClienteFechaMod { get; set; }
        public String ClienteUsuMod { get; set; }
        public String ClienteEmail { get; set; }
        public String ClienteWeb { get; set; }
        public String ClienteObservacion { get; set; }

        public String ClienteUbigeo { get; set; }
        public String ClienteDepartamentoId { get; set; }

        public String ClienteDepartamento { get; set; }
        public String ClienteProvinciaId { get; set; }

        public String ClienteProvincia { get; set; }
        public String ClienteDistritoId { get; set; }

        public String ClienteDistrito { get; set; }
        public String ClienteNacion { get; set; }
        public Boolean ClienteRetencion { get; set; }


    }
}
