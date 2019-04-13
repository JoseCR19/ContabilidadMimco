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
    public class TipoCuentaContableDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");

        public List<TipoCuentaContable> getComboTipoCuentaContable()
        {
            List<TipoCuentaContable> objList = new List<TipoCuentaContable>();
            TipoCuentaContable obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getTipoCuenta");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoCuentaContable();
                    obj.Codigo = dataReader["CodCuenta"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }


    }


}
