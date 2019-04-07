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
    public class AsientoDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public String getCorrelativoAsientoVenta(String Fecha, String Tipo)
        {
            String aux = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getAsientoCorrelativo",
                   new object[] { Fecha, Tipo });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    aux = dataReader["correlativo"].ToString();
                }
            }
            return aux;
        }
        public bool insertarAsientoCab(Asiento obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertAsientoCab",
                   new object[] { obj.TipoAsiento, obj.Correlativo, obj.Fecha, obj.MonedaCod,
                       obj.Debe, obj.Haber });
            try
            {
                db.ExecuteScalar(dbCommand);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool insertarAsientoDet(AsientoDetalle obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertAsientoDet",
                   new object[] { obj.TipoAsiento, obj.Correlativo, obj.Fecha, obj.Cuenta,
                       obj.TipoImporte, obj.Importe,obj.TipDocCodigo, obj.Documento, obj.FechaDoc, obj.FechaVcto });
            try
            {
                db.ExecuteScalar(dbCommand);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
