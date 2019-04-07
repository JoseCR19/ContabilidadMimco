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
    public class BancoDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<CuentaBanco> getCmbBanco(String codent)
        {
            List<CuentaBanco> objListCuentaBanco = new List<CuentaBanco>();
            CuentaBanco objCuentaBanco;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ctaBancos",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    objCuentaBanco = new CuentaBanco();
                    objCuentaBanco.Codigo = dataReader["Codigo"].ToString();
                    objCuentaBanco.Descripcion = dataReader["Descripcion"].ToString();
                    objListCuentaBanco.Add(objCuentaBanco);


                }
            }
            return objListCuentaBanco;
        }
        public CuentaBanco listarBancoDatos(String codent, String codigo, String descripcion)
        {

            CuentaBanco objCuentaBanco = new CuentaBanco();
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_BancosDatos",
                   new object[] { codent, codigo, descripcion });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {

                    objCuentaBanco.Codigo = dataReader["Codigo"].ToString();
                    objCuentaBanco.Cuenta = dataReader["NumCuenta"].ToString();
                    objCuentaBanco.CuentaContable = dataReader["CtaContable"].ToString();
                    objCuentaBanco.Descripcion = dataReader["Descripcion"].ToString();
                    objCuentaBanco.MonedaCod = dataReader["Moneda"].ToString();
                    if (objCuentaBanco.MonedaCod == "PEN")
                    {
                        objCuentaBanco.Moneda = "Soles";
                    }
                    else
                    {
                        objCuentaBanco.Moneda = "Dólares Americanos";
                    }




                }
            }
            return objCuentaBanco;
        }

        public List<FacturaAbono> getFacturaAbono(String codent, String Cliente)
        {
            List<FacturaAbono> objList = new List<FacturaAbono>();
            FacturaAbono obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosBanco",
                   new object[] { codent, Cliente });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new FacturaAbono();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Nro"].ToString();
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    obj.Saldo = convertToDouble(dataReader["Saldo"].ToString());
                    obj.Fecha = dataReader["Fecha"].ToString();
                    obj.Tabla = dataReader["Tabla"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.CuentaContable = dataReader["Cuenta"].ToString();
                    obj.MonedaCod = dataReader["MonedaCod"].ToString();
                    objList.Add(obj);


                }
            }
            return objList;
        }


        public int insertAbonoCab(AbonoBancoCab obj)
        {
            int id = 0;

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertAbonoBancoCab",
                   new object[] { obj.BancoCod, obj.CodEnt,obj.MonedaCod, obj.CuentaContable,
                       obj.Fecha, obj.Observacion,obj.ClienteCod });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {

                    id = Convert.ToInt32(dataReader["id"].ToString());

                }
            }
            return id;
        }
        public String insertAbonoDet(AbonoBancoDet obj, int id)
        {


            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertAbonoDet",
                   new object[] { id, obj.Serie, obj.Numero, obj.Importe });
            try
            {
                db.ExecuteScalar(dbCommand);

                if (obj.Tabla =="A")
                {
                    updateSaldoAntiguo(obj.Serie, obj.Numero, Math.Round(obj.Importe, 2));
                }
                else
                {
                    updateSaldoNuevo(obj.Serie, obj.Numero, obj.Importe);
                }


                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public bool updateSaldoAntiguo(String serie, String num, Double importe)
        {


            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateSaldoAntiguo",
                   new object[] { serie,num, importe });
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
        public bool updateSaldoNuevo(String serie, String num, Double importe)
        {


            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateSaldoNuevo",
                   new object[] { serie, num, importe });
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

        public List<CuentaBanco> getListaBanco(String codent)
        {
            List<CuentaBanco> objListCuentaBanco = new List<CuentaBanco>();
            CuentaBanco objCuentaBanco;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getListaBanco",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    objCuentaBanco = new CuentaBanco();
                    objCuentaBanco.Codigo = dataReader["Codigo"].ToString();
                    objCuentaBanco.Descripcion = dataReader["Descripcion"].ToString();
                    objListCuentaBanco.Add(objCuentaBanco);


                }
            }
            return objListCuentaBanco;
        }

        public String getCuentaBanco(String codent, String banco, String moneda)
        {
            String rsp = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getNroCuentaBanco",
                   new object[] { codent , banco , moneda });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    
                    rsp = dataReader["NumCuenta"].ToString();

                }
            }
            return rsp;
        }



    }
}
