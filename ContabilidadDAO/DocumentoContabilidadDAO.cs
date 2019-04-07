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
    public class DocumentoContabilidadDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<DocumentoContabilidad> listarDocumentoContabilidad()
        {

            List<DocumentoContabilidad> objList = new List<DocumentoContabilidad>();
            DocumentoContabilidad obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CmbTipoDocConta");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoContabilidad();
                   
                    obj.DocContabilidadDescripcion = dataReader["TDocCon_Descripcion"].ToString();
                    obj.DocContabilidadCod = dataReader["TDocCon_CodDoc"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }

        public List<TipoNotaCredito> listarMotivoNotaCredito()
        {

            List<TipoNotaCredito> objList = new List<TipoNotaCredito>();
            TipoNotaCredito obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CmbTipoNotaCredito");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoNotaCredito();

                    obj.TNCreditoCod = dataReader["id"].ToString();
                    obj.TNCreditoDescripcion = dataReader["TCredito_Descripcion"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }

        public List<TipoNotaDebito> listarMotivoNotaDebito()
        {

            List<TipoNotaDebito> objList = new List<TipoNotaDebito>();
            TipoNotaDebito obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CmbTipoNotaDebito");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoNotaDebito();

                    obj.TNDebitoCod = dataReader["id"].ToString();
                    obj.TNDebitoDescripcion = dataReader["Tdebito_descripcion"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }
    }

}
