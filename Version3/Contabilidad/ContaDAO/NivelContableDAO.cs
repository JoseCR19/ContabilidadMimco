using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaDTO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Threading;

namespace ContaDAO
{
    public class NivelContableDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public List<NivelContable> getComboNivel()
        {
            List<NivelContable> objList = new List<NivelContable>();
            NivelContable obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getNivelContable");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new NivelContable();
                    obj.Codigo = dataReader["Codigo"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
    }
}
