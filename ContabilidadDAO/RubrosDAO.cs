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
    public class RubrosDAO
    {

        Conexion _Conexion = new Conexion("Conta");
        public List<Rubros> listarCCostos()
        {
            List<Rubros> objList = new List<Rubros>();
            Rubros obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarRubros");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Rubros();
                 
                    obj.RubrosCod = dataReader["Rub_Codigo"].ToString();
                    obj.RubrosCContableCuenta = dataReader["CC_Cuenta"].ToString();
                    obj.RubrosDescripcion = dataReader["Rub_Descripcion"].ToString();
                    obj.RubrosTipoRubro = Convert.ToInt32(dataReader["Rub_TipoRubro"].ToString());
                    obj.RubrosTRubro = dataReader["TRubro_Descripcion"].ToString();
                    obj.RubrosTVenta = dataReader["Rub_Tipo"].ToString();
                    obj.RubrosVenta = dataReader["VENTA"].ToString();
                    objList.Add(obj);


                }
            }
            return objList;
        }
    }
}
