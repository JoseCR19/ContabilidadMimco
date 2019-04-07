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
    public class CajaDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public String getCorrelativoCaja(String CodEnt,String Periodo)
        {
            String Correlativo="";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getCorrelativoCaja", 
                new object[] { CodEnt, Periodo });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {

                    Correlativo = dataReader["Correlativo"].ToString();
                    Correlativo = Correlativo.PadLeft(7, '0');


                }
            }
            return Correlativo;
        }
        public List<CajaCab> getCaja(String año,String codent)
        {
            List<CajaCab> objList = new List<CajaCab>();
            CajaCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getCajaCab",
                   new object[] { año,codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CajaCab();
                    obj.NumeroCaja = dataReader["NroCaja"].ToString();
                    obj.FechaApertura = Convert.ToDateTime(dataReader["FechaApertura"].ToString());
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.Saldo = convertToDouble(dataReader["Saldo"].ToString());
                    obj.Reembolso = convertToDouble(dataReader["Reembolso"].ToString());
                    obj.Monto = convertToDouble(dataReader["Monto"].ToString());
                    obj.Gasto = convertToDouble(dataReader["Gasto"].ToString());
                    obj.Estado = dataReader["Estado"].ToString();
                    obj.Periodo = dataReader["Periodo"].ToString();
                    obj.Usuario = dataReader["Usuario"].ToString();
                    obj.Disponible = Math.Round(obj.Monto - obj.Gasto,2);
                    String aux = dataReader["FechaCierre"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.FechaCierre = Convert.ToDateTime(aux);
                    }
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<CajaDet> getCajaDet(String NroCaja, String codent)
        {
            List<CajaDet> objList = new List<CajaDet>();
            CajaDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getCajaDet",
                   new object[] { NroCaja, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CajaDet();
                    obj.NumeroCaja = dataReader["NroCaja"].ToString();
                    obj.NumeroOperacion = Convert.ToInt32(dataReader["NroOperacion"].ToString());
                    obj.Ruc = dataReader["Ruc"].ToString(); 
                    obj.FechaOperacion = Convert.ToDateTime(dataReader["FechaOperacion"].ToString());      
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.DescripcionOperacion = dataReader["DescripcionOperacion"].ToString();
                    obj.MonedaCod = dataReader["Moneda"].ToString();
                    obj.SubTotal = convertToDouble(dataReader["Subtotal"].ToString());
                    obj.IGV = convertToDouble(dataReader["IGV"].ToString());
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    obj.TipoDocRef = dataReader["TipDocRef"].ToString();
                    obj.SerieDocRef = dataReader["SerieDocRef"].ToString();
                    obj.NroDocRef = dataReader["NroDocRef"].ToString();
                    obj.CodGas = dataReader["CodGas"].ToString();
                    obj.CuentaContable = dataReader["CuentaContable"].ToString();
                    obj.CodOt = dataReader["CodOt"].ToString();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.Motivo = dataReader["Motivo"].ToString();
                    obj.Tper = dataReader["Tper"].ToString();
                    obj.Distrito = dataReader["Distrito"].ToString();
                    obj.CodConcepto = dataReader["CodConcepto"].ToString();
                    obj.Origen = dataReader["Origen"].ToString();
                    obj.Pedido = dataReader["Pedido"].ToString();
                    obj.Lote = Convert.ToInt32(dataReader["Lote"].ToString());
                    obj.CodentOt = dataReader["CodEntOt"].ToString();
                    obj.Usuario = dataReader["Usuario"].ToString();
                    obj.CentroLabor = dataReader["CentroLabor"].ToString().Trim();
                    obj.TipoDocCorta = dataReader["TipoDocCorta"].ToString().Trim();
                    obj.NroDocumento = dataReader["NroDocumento"].ToString();
                    obj.Proveedor = dataReader["Proveedor"].ToString().Trim().ToUpper();
                    String aux = dataReader["FechaEmision"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.FechaEmision = Convert.ToDateTime(aux);
                    }
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<TipoDocumentoEmision> getComboTipoDocEmision()
        {
            List<TipoDocumentoEmision> objList = new List<TipoDocumentoEmision>();
            TipoDocumentoEmision obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_comboTipoDocEmision");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoDocumentoEmision();
                    obj.Codigo = dataReader["Codigo"].ToString().Trim();
                    obj.CodigoCorto = dataReader["codigo2"].ToString().Trim();
                    obj.Descripcion = dataReader["Descripcion"].ToString().Trim();
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<CentroLabor> getComboCentroLabor()
        {
            List<CentroLabor> objList = new List<CentroLabor>();
            CentroLabor obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_comboCentroLabor");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CentroLabor();
                    obj.Codigo = dataReader["Codigo"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();

                    objList.Add(obj);


                }
            }
            return objList;
        }

        public bool insertarCajaDet(CajaDet obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertCajaDet",
                   new object[] {  obj.NumeroCaja, obj.NumeroOperacion, obj.CodEnt, obj.FechaOperacion,
                       obj.FechaEmision, obj.TipoDocRef, obj.SerieDocRef, obj.NroDocRef,obj.DescripcionOperacion,
                       obj.MonedaCod, obj.SubTotal,  obj.IGV, obj.Total, obj.CodGas , obj.CuentaContable, obj.CodOt,
                       obj.Motivo, obj.Tper, obj.Distrito, obj.CodConcepto,  obj.Origen, obj.Pedido, obj.Lote ,
                       obj.CodentOt, obj.Usuario,obj.Ruc  });
       
            try
            {
                db.ExecuteScalar(dbCommand);

                updateGastoCaja(obj.NumeroCaja, obj.CodEnt);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool updateCajaDet(CajaDet obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateCajaDet",
                   new object[] {  obj.NumeroCaja, obj.NumeroOperacion, obj.CodEnt, obj.FechaOperacion,
                       obj.FechaEmision, obj.TipoDocRef, obj.SerieDocRef, obj.NroDocRef,obj.DescripcionOperacion,
                       obj.MonedaCod, obj.SubTotal,  obj.IGV, obj.Total, obj.CodGas , obj.CuentaContable, obj.CodOt,
                       obj.Motivo, obj.Tper, obj.Distrito, obj.CodConcepto,  obj.Origen, obj.Pedido, obj.Lote ,
                       obj.CodentOt, obj.Usuario,obj.Ruc});

            try
            {
                db.ExecuteScalar(dbCommand);
                updateGastoCaja(obj.NumeroCaja, obj.CodEnt);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool updateGastoCaja( String nroCaja, String Codent)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateGastoCaja",
                   new object[] {  nroCaja, Codent });

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
        public bool cerrarCaja(DateTime fechacierre, String nroCaja, String Codent, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CerrarCaja",
                   new object[] { fechacierre,nroCaja, Codent, Usuario });

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
        public bool insertarCaja(CajaCab obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertCaja",
                   new object[] {obj.NumeroCaja, obj.FechaApertura, obj.CodEnt, obj.Saldo, obj.Reembolso,
                   obj.Monto, obj.Gasto, obj.Estado,obj.Periodo, obj.Usuario});
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
    }
}
