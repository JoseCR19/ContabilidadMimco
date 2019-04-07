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
    public class DocumentoIdentidadDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<DocumentoIdentidad> listarDocumentoIdentidad()
        {

            List<DocumentoIdentidad> objList = new List<DocumentoIdentidad>();
            DocumentoIdentidad obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CmbTipoDocIden");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoIdentidad();
                    obj.DocIdentidadId = Convert.ToInt32(dataReader["id"].ToString());
                    obj.DocIdentidadDescripcion = dataReader["TDocIden_Descripcion"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }
    }
}
