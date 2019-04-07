using ContabilidadDTO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContabilidadDAO
{
    public class ProveedorDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<Proveedor> listarProveedor()
        {
            List<Proveedor> objList = new List<Proveedor>();
            Proveedor obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarProveedor");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Proveedor();

                    obj.ProveedorCod = dataReader["codProv"].ToString();
                    obj.ProveedorContacto = dataReader["contacto"].ToString();
                    obj.ProveedorDireccion = dataReader["dirProv"].ToString();
                    obj.ProveedorNDoc = dataReader["rucprov"].ToString();
                    obj.ProveedorRazonSocial = dataReader["nomprov"].ToString();
                    obj.ProveedorTelefono = dataReader["telefono"].ToString();
                    obj.ProveedorDoc = dataReader["DescripDocu"].ToString();
                    obj.ProveedorTipoDoc = Convert.ToInt32(dataReader["tipodocu"].ToString());
                    objList.Add(obj);


                }
            }
            return objList;
        }
    }
}
