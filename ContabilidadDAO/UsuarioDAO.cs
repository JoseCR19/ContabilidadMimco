using ContabilidadDTO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContabilidadDAO
{
    public class UsuarioDAO
    {
        Conexion _Conexion = new Conexion("Conta");

        public Usuario login(String usu, String pass)
        {
            Usuario obj = new Usuario();
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ValidaIngreso", new object[] { usu, pass });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj.UsuAlias = dataReader["UsuAlias"].ToString();
                    obj.UsuEmail = dataReader["UsuEmail"].ToString();
                    obj.UsuNombres = dataReader["UsuNombres"].ToString();
                    obj.rol = Convert.ToInt32(dataReader["UsuRol"].ToString());
                

                }
            }
            return obj;
        }
    }
}
