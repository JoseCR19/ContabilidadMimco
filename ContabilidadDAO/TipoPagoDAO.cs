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
    public class TipoPagoDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<Pago> listarTipoPago()
        {
            List<Pago> objList = new List<Pago>();
            Pago obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CmbTipoPago");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Pago();
                    obj.PagoId = Convert.ToInt32(dataReader["id"].ToString());
                    obj.PagoDescripcion = dataReader["TPago_Descripcion"].ToString();
                    obj.PagoCod = dataReader["TPago_Cod"].ToString();
                    obj.Dias = Convert.ToInt32(dataReader["Dias"].ToString());
                    objList.Add(obj);

                }
            }
            return objList;
        }
    }
}
