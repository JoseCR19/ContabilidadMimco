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
    public class UbigeoDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<Ubigeo> listarDepartamento()
        {
            List<Ubigeo> objList = new List<Ubigeo>();
            Ubigeo obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_comboDepartamento");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ubigeo();

                    obj.DepartamentoId = dataReader["departamentoid"].ToString();
                    obj.Departamento = dataReader["departamento"].ToString();
                   
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<Ubigeo> listarProvincia(String depaId)
        {
            List<Ubigeo> objList = new List<Ubigeo>();
            Ubigeo obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_comboProvincia",
                new object[] { depaId });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ubigeo();

                    obj.ProvinciaId = dataReader["provinciaid"].ToString();
                    obj.Provincia = dataReader["provincia"].ToString();

                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<Ubigeo> listarDistrito(String depaId, String provId)
        {
            List<Ubigeo> objList = new List<Ubigeo>();
            Ubigeo obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_comboDistrito",
                new object[] { depaId, provId });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ubigeo();

                    obj.DistritoId = dataReader["distritoid"].ToString();
                    obj.Distrito = dataReader["distrito"].ToString();

                    objList.Add(obj);


                }
            }
            return objList;
        }
    }
}
