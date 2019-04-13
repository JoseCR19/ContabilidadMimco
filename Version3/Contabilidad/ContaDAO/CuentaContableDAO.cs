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
    public class CuentaContableDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public List<CuentaContable> getListaCuentaContable()
        {
            List<CuentaContable> objList = new List<CuentaContable>();
            CuentaContable obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getListaCuentaContable");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CuentaContable();
                    obj.Cuenta = dataReader["CC_Cuenta"].ToString();
                    obj.Anexo = dataReader["CC_Anexo"].ToString();
                    obj.Nivel = dataReader["CC_Nivel"].ToString();
                    obj.Descripcion = dataReader["CC_Descripcion"].ToString();
                    obj.DocR = dataReader["CC_DocR"].ToString();
                    obj.TipoCuenta = dataReader["TipoCuenta"].ToString();
                    obj.TipoCuentaCod = dataReader["TipoCuentaCod"].ToString();
                    obj.TipoCuentaConcatenado = obj.TipoCuentaCod + " - " + obj.TipoCuenta;
                    obj.MonedaCod = dataReader["MonedaCod"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public String insertarCuentaTable(CuentaContable obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertCtaContable",
                   new object[] { obj.Anexo, obj.Cuenta, obj.Descripcion, 
                       obj.MonedaCod, obj.Nivel, obj.TipoCuentaCod, Usuario });

            try
            {
                db.ExecuteScalar(dbCommand);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public String updateCuentaTable(CuentaContable obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UpdateCtaContable",
                   new object[] { obj.Anexo, obj.Cuenta, obj.Descripcion, 
                       obj.MonedaCod, obj.Nivel, obj.TipoCuentaCod, Usuario });

            try
            {
                db.ExecuteScalar(dbCommand);
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
