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
    public class ChequeDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public bool insertChequera(Cheque obj, String usu )
        {


            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertCheque",
                   new object[] { obj.BancoCod, obj.CodEnt, obj.MonedaCod, obj.CuentaBanco,
                       obj.NroChequeInicio, obj.NroChequeFin , usu});
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
        public bool updateChequera(Cheque obj, String usu)
        {


            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateCheque",
                   new object[] { obj.BancoCod, obj.CodEnt, obj.MonedaCod,
                       obj.NroChequeInicio, obj.NroChequeFin , usu, obj.Correlativo});
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
        public String getNroActualCheque(String codent, String Banco, String Moneda)
        {

            String msg = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getNroChequeActual",
                   new object[] { codent, Banco, Moneda });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    msg = dataReader["Correlativo"].ToString();

                }
            }
            return msg;
        }
        public bool updateNroChequeActual(String codent, String Banco, String Moneda, String nroactual)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateChequeNroACtual",
                   new object[] { Banco, codent, Moneda,
                       nroactual });
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
       


        public List<Cheque> getChequera(String codent)
        {
            List<Cheque> objList= new List<Cheque>();
            Cheque obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getChequera",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Cheque();
                    obj.BancoCod = dataReader["BancoCod"].ToString();
                    obj.Banco = dataReader["Banco"].ToString();
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.CuentaBanco = dataReader["CuentaBanco"].ToString();
                    obj.MonedaCod = dataReader["Moneda"].ToString();
                    obj.NroChequeInicio = dataReader["NroChequeInicio"].ToString();
                    obj.NroChequeFin = dataReader["NroChequeFin"].ToString();
                    obj.Correlativo = Convert.ToInt32( dataReader["Correlativo"].ToString());
                    String s= dataReader["NroChequeActual"].ToString();
                    if (!String.IsNullOrEmpty(s))
                    {
                        obj.NroChequeActual = s;
                    }else
                    {
                        obj.NroChequeActual = "--";
                    }
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public String getNroActualCheque(Cheque obj)
        {
           
            String msg="";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getNroChequeActual",
                   new object[] { obj.CodEnt, obj.BancoCod, obj.MonedaCod });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    msg= dataReader["Correlativo"].ToString();
                }
            }
            return msg;
        }
    }
}
