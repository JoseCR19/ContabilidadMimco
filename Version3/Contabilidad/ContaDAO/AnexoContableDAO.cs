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
    public class AnexoContableDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public List<AnexoContable> getComboAnexo()
        {
            List<AnexoContable> objList = new List<AnexoContable>();
            AnexoContable obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getAnexoContable");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new AnexoContable();
                    obj.Codigo = dataReader["Codigo"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
    }
}
