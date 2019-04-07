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
    public class OtDAO
       
    {
        Conexion _Conexion = new Conexion("Conta");
       public bool updateEstadoNuevo(String nroOt, int item, String codent)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateEstadoOtNuevo",
                   new object[] { nroOt,item,codent
                   });
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
        public bool updateEstadoAntiguo(String nroOt, int item, String codent, String documento)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateEstadoOt",
                   new object[] { nroOt,item,codent,documento
                   });
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

        public bool updateEstadoAnulacionNuevo(String nroOt, int item, String codent)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateEstadoAnulacionOtNuevo",
                   new object[] { nroOt,item,codent
                   });
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
        public bool updateEstadoAnulacionAntiguo(String nroOt, int item, String codent)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateEstadoAnulacionOt",
                   new object[] { nroOt.Trim(),item,codent
                   });
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

        public List<OtDTO> listarOtPago( String codent, String cliente)
        {
            List<OtDTO> objLista = new List<OtDTO>();
            OtDTO obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDatosOt",
                   new object[] {  codent, cliente });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new OtDTO();
                    obj.CodigoOt = dataReader["CodOt"].ToString();
                    obj.EstadoOt = dataReader["estado"].ToString().Trim();
                    obj.Importe = convertToDouble( dataReader["Impot"].ToString());
                    obj.Item = Convert.ToInt32(dataReader["item"].ToString());
                    obj.NumeroOt = dataReader["NroOt"].ToString();
                    obj.Porcentaje = convertToDouble(dataReader["PorOt"].ToString());
                    obj.Tabla = dataReader["Tabla"].ToString();
                    obj.CuentaContable = dataReader["CuentaContable"].ToString();
                    obj.ProductoCodigo = dataReader["CodProd"].ToString();
                    obj.UnidadMedida = dataReader["UMsunat"].ToString();
                    obj.ProductoDescripcion = dataReader["desProd"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public Double convertToDouble(String conv)
        {
            try
            {
                char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
                if (!conv.Contains(","))
                    return double.Parse(conv, CultureInfo.InvariantCulture);
                else
                    return Convert.ToDouble(conv.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
    }
}
