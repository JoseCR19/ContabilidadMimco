using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContaDTO;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Threading;


namespace ContaDAO
{
    public class AsientoDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public String getCorrelativoAsientoVenta(String Fecha, String Tipo)
        {
            String aux="";
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
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
        /*procedimiento para poder listar las facturas que posteriormente se ejecutaran como asientos*/
        public List<AsientoDetalle> getGenerarDetalle(String serie, String numero)
        {
            List<AsientoDetalle> objList = new List<AsientoDetalle>();
            AsientoDetalle obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            /*procedimiento almacenado*/
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GenerarAsientoVenta",
                   new object[] { serie, numero });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new AsientoDetalle();
                    obj.Cuenta = dataReader["Cuenta"].ToString();
                    obj.TipoImporte = dataReader["TipoImporte"].ToString();
                    obj.Importe = convertToDouble(dataReader["Importe"].ToString());
                    obj.TipoDoc = dataReader["TipDoc"].ToString();
                    obj.Fecha = dataReader["Fecha"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipDocCodigo = dataReader["DocCod"].ToString();
                    obj.TipoAsiento = "05";
                    obj.Anexo = "";
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<AsientoDetalle> getGenerarDetalleCompra(String numeroRegistro)
        {
            List<AsientoDetalle> objList = new List<AsientoDetalle>();
            AsientoDetalle obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GenerarCompraAsiento",
                   new object[] { numeroRegistro });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new AsientoDetalle();
                    obj.Cuenta = dataReader["Cuenta"].ToString();
                    obj.TipoImporte = dataReader["TipoImporte"].ToString();
                    obj.Importe = convertToDouble(dataReader["Importe"].ToString());
                    obj.TipoDoc = dataReader["TipDoc"].ToString();
                    obj.Fecha = dataReader["Fecha"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipDocCodigo = dataReader["DocCod"].ToString();
                    obj.TipoAsiento = "11";
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<AsientoDetalle> getGenerarDetalleCaja(String nrocaja, int nrooperacion,String codent)
        {
            List<AsientoDetalle> objList = new List<AsientoDetalle>();
            AsientoDetalle obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_DetalleCajaAsiento",
                   new object[] { nrocaja, nrooperacion, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new AsientoDetalle();
                    obj.Cuenta = dataReader["Cuenta"].ToString();
                    obj.TipoImporte = dataReader["TipoImporte"].ToString();
                    obj.Importe = convertToDouble(dataReader["Importe"].ToString());
                    obj.TipoDoc = dataReader["TipDoc"].ToString();
                    obj.Fecha = dataReader["Fecha"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipDocCodigo = dataReader["DocCod"].ToString();
                    obj.TipoAsiento = "01";
                    obj.Anexo = "";
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<AsientoDetalle> getGenerarDetalleVoucher(String nroVoucher, int item)
        {
            List<AsientoDetalle> objList = new List<AsientoDetalle>();
            AsientoDetalle obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_DetalleVoucherAsiento",
                   new object[] { nroVoucher, item});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new AsientoDetalle();
                    obj.Cuenta = dataReader["Cuenta"].ToString();
                    obj.TipoImporte = dataReader["TipoImporte"].ToString();
                    obj.Importe = convertToDouble(dataReader["Importe"].ToString());
                    obj.TipoDoc = dataReader["TipDoc"].ToString();
                    obj.Fecha = dataReader["Fecha"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipDocCodigo = dataReader["DocCod"].ToString();
                    obj.TipoAsiento = "01";
                    obj.Anexo = "";
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public bool insertarAsientoCab(Asiento obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
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
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertAsientoDet",
                   new object[] { obj.TipoAsiento, obj.Correlativo, obj.Fecha, obj.Cuenta,
                       obj.TipoImporte, obj.Importe,obj.TipDocCodigo, obj.Documento, obj.FechaDoc,
                       obj.FechaVcto,obj.NumReg });
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
        public bool updateEstadoAsientoVenta(String serie, String nro)
        {
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_estadoDocumentoAsiento",
                   new object[] { serie, nro });
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
        public bool updateEstadoAsientoCompra(String numReg)
        {
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_estadoCompraAsiento",
                   new object[] { numReg });
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

        public List<TipoAsiento> getComboTipoAsiento()
        {
            List<TipoAsiento> objList = new List<TipoAsiento>();
            TipoAsiento obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ComboAsiento");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoAsiento();
                    obj.Id = dataReader["Id"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                   
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<LibroDiario> getLibroDiario(String moneda, String subdiario1, String subdiario2, String mes)
        {
            List<LibroDiario> objList = new List<LibroDiario>();
            LibroDiario obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getLibroDiario",
                   new object[] { moneda, subdiario1, subdiario2, mes });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LibroDiario();
                    obj.TipoAsiento = dataReader["Tipo"].ToString();
                    obj.Correlativo = dataReader["Correlativo"].ToString();
                    obj.FechaOperacion = dataReader["Fecha"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    obj.TipoDocumento = dataReader["TipoDoc"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaDocumento= dataReader["FechaDocumento"].ToString();
                    obj.CuentaContable = dataReader["Cuenta"].ToString();
                    obj.CuentaDescripcion = dataReader["CC_Descripcion"].ToString();
                    if (String.IsNullOrEmpty(obj.CuentaDescripcion))
                    {
                        obj.CuentaDescripcion = "------";
                    }
                    obj.Ruc = dataReader["Ruc"].ToString();
                    if (String.IsNullOrEmpty(obj.Ruc))
                    {
                        obj.Ruc = "------";
                    }
                    obj.Haber = convertToDouble(dataReader["Haber"].ToString());
                    obj.Debe = convertToDouble(dataReader["Debe"].ToString());
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<LibroDiario> getLibroMayor(String moneda,String mes)
        {
            List<LibroDiario> objList = new List<LibroDiario>();
            LibroDiario obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getLibroMayor",
                   new object[] { moneda, mes });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LibroDiario();
                    obj.TipoAsiento = dataReader["Tipo"].ToString();
                    obj.Correlativo = dataReader["Correlativo"].ToString();
                    obj.FechaOperacion = dataReader["Fecha"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    obj.TipoDocumento = dataReader["TipoDoc"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaDocumento = dataReader["FechaDocumento"].ToString();
                    obj.CuentaContable = dataReader["Cuenta"].ToString();
                    obj.CuentaDescripcion = dataReader["CC_Descripcion"].ToString();
                    if (String.IsNullOrEmpty(obj.CuentaDescripcion))
                    {
                        obj.CuentaDescripcion = "------";
                    }
                    obj.Ruc = dataReader["Ruc"].ToString();
                    if (String.IsNullOrEmpty(obj.Ruc))
                    {
                        obj.Ruc = "------";
                    }
                    obj.Haber = convertToDouble(dataReader["Haber"].ToString());
                    obj.Debe = convertToDouble(dataReader["Debe"].ToString());
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<LibroDiario> getLibroMayorCajaBanco(String moneda, String mes, Double cuenta1, Double cuenta2)
        {
            List<LibroDiario> objList = new List<LibroDiario>();
            LibroDiario obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getLibroMayorCajaBanco",
                   new object[] { moneda, mes, cuenta1, cuenta2 });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LibroDiario();
                    obj.TipoAsiento = dataReader["Tipo"].ToString();
                    obj.Correlativo = dataReader["Correlativo"].ToString();
                    obj.FechaOperacion = dataReader["Fecha"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    obj.TipoDocumento = dataReader["TipoDoc"].ToString();
                    obj.Documento = dataReader["Documento"].ToString();
                    obj.FechaDocumento = dataReader["FechaDocumento"].ToString();
                    obj.CuentaContable = dataReader["Cuenta"].ToString();
                    obj.CuentaDescripcion = dataReader["CC_Descripcion"].ToString();
                    if (String.IsNullOrEmpty(obj.CuentaDescripcion))
                    {
                        obj.CuentaDescripcion = "------";
                    }
                    obj.Ruc = dataReader["Ruc"].ToString();
                    if (String.IsNullOrEmpty(obj.Ruc))
                    {
                        obj.Ruc = "------";
                    }
                    obj.Haber = convertToDouble(dataReader["Haber"].ToString());
                    obj.Debe = convertToDouble(dataReader["Debe"].ToString());
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<CajaDet> getGenerarCaja(String CodEnt)
        {
            List<CajaDet> objList = new List<CajaDet>();
            CajaDet obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GenerarCajaAsiento",
                   new object[] { CodEnt});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CajaDet();
                    obj.NumeroOperacion = Convert.ToInt32(dataReader["NroOperacion"].ToString());
                    obj.NumeroCaja = dataReader["NroCaja"].ToString();
                    obj.Ruc = dataReader["Ruc"].ToString();
                    obj.FechaOperacion = Convert.ToDateTime(dataReader["FechaOperacion"].ToString());
                 
                    obj.DescripcionOperacion = dataReader["DescripcionOperacion"].ToString();
                    obj.MonedaCod = dataReader["MonedaCod"].ToString();
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

                    obj.Pedido = dataReader["Pedido"].ToString();
                    
                 
                    obj.CentroLabor = dataReader["CentroLabor"].ToString().Trim();
                    obj.TipoDocCorta = dataReader["Codigo2"].ToString().Trim();
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

        public List<Voucher> getGenerarVoucher(String CodEnt)
        {
            List<Voucher> objList = new List<Voucher>();
            Voucher obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GenerarVoucherAsiento",
                   new object[] { CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Voucher();
                 //  obj.Item = Convert.ToInt32(dataReader["Item"].ToString());
                    obj.NroVoucher = dataReader["NroVoucher"].ToString();
                    obj.FechaPago = Convert.ToDateTime(dataReader["FechaPago"].ToString());
                    String aux = dataReader["FechaEmision"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.FechaEmision = Convert.ToDateTime(aux);
                    }
                    obj.NumeroCheque = dataReader["NroCheque"].ToString();
                    obj.NumeroCuenta   = dataReader["NroCuenta"].ToString();
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.TpersonaCod = dataReader["TPersona"].ToString();
                    obj.Tpersona = dataReader["Descripcion"].ToString();
                    obj.SolicitaCod = dataReader["CodSolicita"].ToString();
                    obj.CuentaContable = dataReader["CuentaContable"].ToString();
                    obj.BancoCod = dataReader["CodBanco"].ToString();
                    obj.Banco = dataReader["Banco"].ToString();
                    obj.Solicitante = dataReader["Solicitante"].ToString().ToUpper();
                    obj.Importe = convertToDouble(dataReader["Importe"].ToString());
                    obj.CodOt = dataReader["CodOt"].ToString();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.SerieDocRef = dataReader["SerieDocRef"].ToString();
                    obj.NumeroDocRef = dataReader["NroDocRef"].ToString();
                    obj.TipDocRef = dataReader["TipoDocRef"].ToString();
                    obj.TipDocCorta = dataReader["Codigo2"].ToString();
                    obj.TipoPagoCod = dataReader["TipoPagoCod"].ToString();
                    obj.TipoPago = dataReader["TipoPago"].ToString();
                    obj.Ruc = dataReader["rucprov"].ToString();
                    objList.Add(obj);


                }
            }
            return objList;
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
