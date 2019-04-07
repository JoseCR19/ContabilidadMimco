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
    public class CentroCostosDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<CentroCostos> listarCCostos(String Codent)
        {
            List<CentroCostos> objList = new List<CentroCostos>();
            CentroCostos obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CentroCosto",
                   new object[] { Codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CentroCostos();
                    obj.CCostosNro = dataReader["NroOt"].ToString();
                    obj.CCostosCod = dataReader["CodOt"].ToString();
                    obj.CCostosDescripcion = dataReader["DirOt"].ToString();
                    objList.Add(obj);


                }
            }
            return objList;
        }
    }
}
