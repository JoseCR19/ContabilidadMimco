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
    public class VoucherDAO
    {
        Conexion _Conexion = new Conexion("Conta");

        public String getCorrelativoVoucher(String CodEnt, String Periodo)
        {
            String Correlativo = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getCorrelativoVoucher",
                new object[] { CodEnt, Periodo });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Correlativo = dataReader["Correlativo"].ToString();
                }
            }
            return Correlativo;
        }
        public String getCanjeLetra(String CodEnt)
        {
            String Correlativo = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getCorrelativoLetra",
                new object[] { CodEnt});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    Correlativo = dataReader["Correlativo"].ToString();
                }
            }
            return Correlativo;
        }

        public List<FacturaRC> FacturaCReporte(String CodEnt, DateTime d1, DateTime d2)
        {
            List<FacturaRC> objList = new List<FacturaRC>();
            FacturaRC obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ReporteFacturaC",
                   new object[] { CodEnt, d1, d2 });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new FacturaRC();
                    obj.FechaEmision = dataReader["FecDoc"].ToString().Substring(0,10);
                    obj.FechaVencimiento =dataReader["FecVen"].ToString().Substring(0, 10);
                    obj.TSD = dataReader["TipDoc"].ToString().Trim() + "/" + dataReader["SerDoc"].ToString().Trim() + "-" + dataReader["NumDoc"].ToString().Trim();
                    obj.Ruc = dataReader["Ruc"].ToString().Trim();
                    obj.RazonSocial = dataReader["Razon Social"].ToString().Trim();
                    obj.FechaEntrega = dataReader["FechaReg"].ToString();
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.TC = dataReader["TC"].ToString();
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    objList.Add(obj);

                }
            }
            return objList;
        }

        public List<Voucher> voucherReporte(String CodEnt, DateTime d1, DateTime d2,String ruc)
        {
            List<Voucher> objList = new List<Voucher>();
            Voucher obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_voucherReporte",
                   new object[] { CodEnt, d1, d2,ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Voucher();
                    obj.NumeroVoucher = dataReader["NroVoucher"].ToString();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaEmision"].ToString());
                    obj.NumeroCheque = dataReader["NroCheque"].ToString().Trim();
                    obj.NumeroCuenta = dataReader["NroCuenta"].ToString().Trim();
                    obj.Banco = dataReader["Banco"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.Solicitante = dataReader["Solicitante"].ToString().Trim();
                    obj.Monto = convertToDouble(dataReader["MontoPago"].ToString());
                    obj.Observacion = dataReader["Observacion"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }
        public List<Voucher> voucherReporteCliente(String CodEnt, DateTime d1, DateTime d2, String ruc)
        {
            List<Voucher> objList = new List<Voucher>();
            Voucher obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_voucherReporteCliente",
                   new object[] { CodEnt, d1, d2, ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Voucher();
                    obj.NumeroVoucher = dataReader["NroVoucher"].ToString();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaEmision"].ToString());
                    obj.NumeroCheque = dataReader["NroCheque"].ToString().Trim();
                    obj.NumeroCuenta = dataReader["NroCuenta"].ToString().Trim();
                    obj.Banco = dataReader["Banco"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.Solicitante = dataReader["Solicitante"].ToString().Trim();
                    obj.Monto = convertToDouble(dataReader["MontoPago"].ToString());
                    obj.Observacion = dataReader["Observacion"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }
        public List<Voucher> voucherReportePersonal(String CodEnt, DateTime d1, DateTime d2, String ruc)
        {
            List<Voucher> objList = new List<Voucher>();
            Voucher obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_voucherReportePersonal",
                   new object[] { CodEnt, d1, d2, ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Voucher();
                    obj.NumeroVoucher = dataReader["NroVoucher"].ToString();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaEmision"].ToString());
                    obj.NumeroCheque = dataReader["NroCheque"].ToString().Trim();
                    obj.NumeroCuenta = dataReader["NroCuenta"].ToString().Trim();
                    obj.Banco = dataReader["Banco"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.Solicitante = dataReader["Solicitante"].ToString().Trim();
                    obj.Monto = convertToDouble(dataReader["MontoPago"].ToString());
                    obj.Observacion = dataReader["Observacion"].ToString();
                    objList.Add(obj);

                }
            }
            return objList;
        }
        public List<LetraCab> listarLetra(String CodEnt, DateTime d1, DateTime d2,String Estado,String ruc)
        {

            List<LetraCab> objList = new List<LetraCab>();
            LetraCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ListarLetraFacturaCompra",
                   new object[] { CodEnt, d1,d2,Estado,ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LetraCab();
                    obj.TipoDoc = dataReader["TipoDoc"].ToString();
                    obj.SerieDoc = dataReader["SerieDoc"].ToString();
                    obj.NroDoc = dataReader["NroDoc"].ToString();
                    obj.FecRep = Convert.ToDateTime(dataReader["FecRep"].ToString());
                    obj.Ruc = dataReader["Ruc"].ToString();
                    obj.Usuario = dataReader["Usuario"].ToString().Trim();
                    obj.direccion = dataReader["Direccion"].ToString().Trim();
                    obj.EstRep = dataReader["Estado"].ToString();
                    obj.TipoCambio =convertToDouble( dataReader["TipoCambio"].ToString());
                    obj.Monto = convertToDouble( dataReader["Monto"].ToString());
                    obj.Abono =convertToDouble( dataReader["Abono"].ToString());
                    obj.Saldo =convertToDouble( dataReader["Saldo"].ToString().Trim());
                    obj.Temporal =convertToDouble( dataReader["Temporal"].ToString().Trim());
                    obj.Fec_Ven =Convert.ToDateTime( dataReader["FechaVen"].ToString());
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.Fec_Pago = dataReader["FechaPago"].ToString();
                    obj.Fec_Compromiso =Convert.ToDateTime( dataReader["FechaCompromiso"].ToString());
                    obj.Estado_Doc = dataReader["EstadoDoc"].ToString();
                    //obj.Fecha_hora_entrega =Convert.ToDateTime(dataReader["FechaEntrega"].ToString());
                    //obj.Hora_Entrega =Convert.ToDateTime( dataReader["HoraEntrega"].ToString().Trim());
                    obj.NomProv = dataReader["RazonSocial"].ToString();
                    obj.ImporteTotal = convertToDouble(dataReader["ImporteTotal"].ToString());
                    obj.NroRegistro = dataReader["NroRegistro"].ToString();
                    if (obj.EstRep == "A")
                    {
                        obj.Anulado = "ANULADO";
                    }
                    else
                    {
                        obj.Anulado = "PROCESADO";
                    }
                    objList.Add(obj);

                }
            }
            return objList;
        }
        public List<Voucher> listarVoucher(String CodEnt, DateTime d1, DateTime d2, String Estado)
        {
            
            List<Voucher> objList = new List<Voucher>();
            Voucher obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ListarVoucher",
                   new object[] { CodEnt, d1, d2, Estado });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Voucher();
                    obj.EstadoCheque = dataReader["EstadoCheque"].ToString();
                    obj.NumeroVoucher = dataReader["NroVoucher"].ToString();
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.FechaPago = Convert.ToDateTime(dataReader["FechaPago"].ToString());
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaPago"].ToString());
                    obj.NumeroCheque = dataReader["NroCheque"].ToString().Trim();
                    obj.NumeroCuenta = dataReader["NroCuenta"].ToString().Trim();
                    obj.MonedaCod = dataReader["MonedaCod"].ToString();
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.TpersonaCod = dataReader["Tpersona"].ToString();
                    obj.Tpersona = dataReader["Solicita"].ToString();
                    obj.SolicitaCod = dataReader["CodSolicita"].ToString().Trim();
                    obj.Solicitante = dataReader["Solicitante"].ToString().Trim();
                    obj.CuentaContable = dataReader["CuentaContable"].ToString();
                    obj.AccionPago = dataReader["AccionPago"].ToString();
                    obj.BancoCod = dataReader["CodBanco"].ToString();
                    obj.Banco = dataReader["Banco"].ToString();
                    obj.Monto = convertToDouble(dataReader["MontoPago"].ToString());
                    obj.TipVou = dataReader["TipVou"].ToString().Trim();
                    obj.Estado = dataReader["Estado"].ToString().Trim();
                    obj.EstadoVuelto = dataReader["EstadoVuelto"].ToString();
                    obj.Observacion = dataReader["Observacion"].ToString();
                    obj.TipoMovimiento = dataReader["TipoMovimiento"].ToString();
                    if (obj.TipVou =="C")
                    {
                        obj.EstadoS = "LIQUIDADO";
                    }else
                    {
                        obj.EstadoS = "PENDIENTE";
                    }
                    if (obj.Estado == "A")
                    {
                        obj.Anulado = "ANULADO";
                    }else
                    {
                        obj.Anulado = "PROCESADO";
                    }
                    String aux = dataReader["FechaEntrega"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.FechaEntrega = Convert.ToDateTime(aux);
                    }
                    objList.Add(obj);

                }
            }
            return objList;
        }

        public List<LetraDetalle> listarLetraDet(String NroRegistro, String CodEnt)
        {
            List<LetraDetalle> objList = new List<LetraDetalle>();
            LetraDetalle obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarLetraDetalle",
                   new object[] { NroRegistro, CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LetraDetalle();
                    obj.Item = Convert.ToInt32(dataReader["Item"].ToString());
                    obj.TipDoc = dataReader["TipoDoc"].ToString();
                    obj.NroDoc = dataReader["NroDoc"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString().Trim();
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.TipoDocRef = dataReader["TipoDocRef"].ToString();
                    obj.SerDocRef = dataReader["SerieDocRef"].ToString();
                    obj.NroDocRef = dataReader["NroDocRef"].ToString();
                    obj.Monto = convertToDouble(dataReader["Monto"].ToString().Trim());
                    obj.Fec_emi_ref =dataReader["FecEmiRef"].ToString().Trim();
                    obj.Fec_ven_ref = dataReader["FecVenRef"].ToString().Trim();
                    obj.EstRepDet = dataReader["EstadoRep"].ToString();
                    obj.RucProv = dataReader["Ruc"].ToString().Trim();
                    obj.NomProv = dataReader["RazonSocial"].ToString().Trim();
                    obj.Abono = convertToDouble(dataReader["Abono"].ToString().Trim());
                    obj.Saldo = convertToDouble(dataReader["Saldo"].ToString().Trim());
                    obj.NroRegistroLetra = dataReader["NroRegistro"].ToString();
                    obj.NroRegistro = dataReader["NroRegistroRef"].ToString().Trim();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<VoucherDet> listarVoucherDet(String NroVoucher, String CodEnt)
        {
            List<VoucherDet> objList = new List<VoucherDet>();
            VoucherDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarVoucherDetalle",
                   new object[] { NroVoucher, CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new VoucherDet();
                    obj.NumeroVoucher = dataReader["NroVoucher"].ToString();
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString().Trim();
                    obj.Item = Convert.ToInt32(dataReader["Item"].ToString().Trim());
                    obj.Importe = convertToDouble( dataReader["Importe"].ToString());
                    obj.CodOt = dataReader["CodOt"].ToString();
                    obj.Documento = dataReader["NroDoc"].ToString();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.NumeroDocRef = dataReader["NroDocRef"].ToString().Trim();
                    obj.SerieDocRef = dataReader["SerieDocRef"].ToString().Trim();
                    obj.TipoPagoCod = dataReader["TipPagoCod"].ToString().Trim();
                    obj.TipoPago = dataReader["TipPago"].ToString();
                    obj.DirOt = dataReader["DirOt"].ToString();
                    obj.TipDocRef = dataReader["TipoDocRef"].ToString().Trim();
                    obj.NroDocumento = dataReader["TdocEmiCorta"].ToString().Trim() + "-" + 
                        obj.SerieDocRef.Trim() + "-" + obj.NumeroDocRef.Trim();
                    obj.numeroRegistro = dataReader["NroRegistro"].ToString();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString();
                    //obj.FechaEmiRef =Convert.ToDateTime(dataReader["FechaRefe"].ToString());
                    obj.FechaEmiRef = dataReader["FechaRefe"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Ventas> listarDocumentosVentasDetalle(String NumReg)
        {
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosPagarVoucherDetalle",
                   new object[] { NumReg});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.CodOt = dataReader["CodOt"].ToString().Trim();
                    obj.VentasId = dataReader["NumReg"].ToString().Trim();
                    obj.NroOt = dataReader["NumeroOt"].ToString().Trim();
                    obj.DirOt = dataReader["DirOt"].ToString().Trim();
                    
                    
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Ventas> listarDocumentosVentas(String Ruc, String CodEnt/*,String moneda,String monedadoc*/)
        {
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosPagarVoucher",
                   new object[] { Ruc, CodEnt/*, moneda, monedadoc */});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.CodOt = dataReader["OT"].ToString();

                    obj.CodEnt = dataReader["Entidad"].ToString();
                    obj.VentasId = dataReader["NroRegistro"].ToString().Trim();
                    obj.TipoDocumentoCod = dataReader["TipDocCod"].ToString().Trim();
                    obj.TipoDocumento = dataReader["TipoDocumento"].ToString();
                    obj.Serie = dataReader["serDoc"].ToString();
                    obj.Numero = dataReader["Doc"].ToString();
                    obj.Total = convertToDouble( dataReader["total"].ToString().Trim());
                    obj.Ruc = dataReader["RUC"].ToString().Trim();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString().Trim();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaDoc"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString().Trim();
                    obj.xret = dataReader["xret"].ToString().Trim();
                    obj.xper = dataReader["xper"].ToString().Trim();
                    obj.xbue = dataReader["xbue"].ToString().Trim();
                    obj.xdetra = dataReader["xdet"].ToString().Trim();
                    obj.TipoCambio = convertToDouble(dataReader["Cambio"].ToString().Trim());
                    obj.DirOt = dataReader["DirOt"].ToString().Trim();
                    obj.CodOtReal = dataReader["OT"].ToString().Trim();
                    obj.NroOtReal = dataReader["NroOt"].ToString().Trim();
                    obj.DirOtReal = dataReader["DirOt"].ToString().Trim();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Ventas> listarDocumentosVentasForLeter(String Ruc, String CodEnt/*,String moneda,String monedadoc*/)
        {
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosPagarVoucherForLeter",
                   new object[] { Ruc, CodEnt/*, moneda, monedadoc */});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.CodOt = dataReader["OT"].ToString();

                    obj.CodEnt = dataReader["Entidad"].ToString();
                    obj.VentasId = dataReader["NroRegistro"].ToString().Trim();
                    obj.TipoDocumentoCod = dataReader["TipDocCod"].ToString().Trim();
                    obj.TipoDocumento = dataReader["TipoDocumento"].ToString();
                    obj.Serie = dataReader["serDoc"].ToString();
                    obj.Numero = dataReader["Doc"].ToString();
                    obj.Total = convertToDouble(dataReader["total"].ToString().Trim());
                    obj.Ruc = dataReader["RUC"].ToString().Trim();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString().Trim();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaDoc"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString().Trim();
                    obj.xret = dataReader["xret"].ToString().Trim();
                    obj.xper = dataReader["xper"].ToString().Trim();
                    obj.xbue = dataReader["xbue"].ToString().Trim();
                    obj.xdetra = dataReader["xdet"].ToString().Trim();
                    obj.TipoCambio = convertToDouble(dataReader["Cambio"].ToString().Trim());
                    obj.DirOt = dataReader["DirOt"].ToString().Trim();
                    obj.CodOtReal = dataReader["OT"].ToString().Trim();
                    obj.NroOtReal = dataReader["NroOt"].ToString().Trim();
                    obj.DirOtReal = dataReader["DirOt"].ToString().Trim();
                    obj.AbonoLetra = convertToDouble(dataReader["AbonoLetra"].ToString());
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<FacturaAbono> listarDocumentosAbonoVoucher(String Ruc, String CodEnt/*,String moneda,String monedadoc*/)
        {
            List<FacturaAbono> objList = new List<FacturaAbono>();
            FacturaAbono obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosAbonoVoucher",
                   new object[] { CodEnt , Ruc/*, moneda,monedadoc*/});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new FacturaAbono();
                    obj.Ruc = dataReader["Ruc"].ToString();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString();
                    obj.TipoDoc = dataReader["TipoDocumento"].ToString().Trim();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Nro"].ToString();
                    obj.Total = convertToDouble(dataReader["Total"].ToString().Trim());
                    obj.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.FechaVcto = Convert.ToDateTime(dataReader["FechaVcto"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.Saldo = convertToDouble(dataReader["Saldo"].ToString().Trim());
                    obj.Tabla = dataReader["Tabla"].ToString().Trim();
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.MonedaCod = dataReader["Moneda"].ToString().Trim();
                    obj.TipoCambio = convertToDouble(dataReader["Cambio"].ToString().Trim());
                    objList.Add(obj);
                }
            }
            return objList;
        }


        public List<Ventas> ListarCuentasPorPagar(String CodEnt, String d1, String d2,String d3, String d4)
        {
            /*LISTA PARA REPORTES*/
            List<Ventas> objList = new List<Ventas>();

            Ventas obj;
            

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_cuentasPorPagar",
                   new object[] {  CodEnt, d1, d2 , d3 ,d4 });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.CodEnt = dataReader["Entidad"].ToString();
                    obj.VentasId = dataReader["NroRegistro"].ToString().Trim();
                    obj.TipoDocumentoCod = dataReader["TipDocCod"].ToString().Trim();
                    obj.TipoDocumento = dataReader["TipoDocumento"].ToString();
                    obj.Serie = dataReader["serDoc"].ToString();
                    obj.Numero = dataReader["Doc"].ToString();
                    obj.Total = convertToDouble(dataReader["total"].ToString().Trim());
                    obj.Ruc = dataReader["RUC"].ToString().Trim();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString().Trim();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["FechaDoc"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString().Trim();
                    obj.total_soles = convertToDouble(dataReader["TotalSoles"].ToString().Trim());
                    obj.total_dolares = convertToDouble(dataReader["TotalDolares"].ToString().Trim());
                    obj.TipoCambio = convertToDouble(dataReader["Cambio"].ToString().Trim());
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<FacturaAbono> ListarCuentasPorCobrar (String CodEnt, String d1, String d2)
        {
            List<FacturaAbono> objList = new List<FacturaAbono>();

            FacturaAbono obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_cuentasPorCobrar",
                   new object[] { CodEnt, d1, d2 });

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new FacturaAbono();
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Nro"].ToString();
                    obj.TipoDoc = dataReader["TipDocCod"].ToString().Trim();
                    obj.Total = convertToDouble(dataReader["Total"].ToString().Trim());
                    obj.Ruc = dataReader["Ruc"].ToString().Trim();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString().Trim();
                    obj.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.FechaVcto = Convert.ToDateTime(dataReader["FechaVcto"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.MonedaCod = dataReader["Moneda"].ToString().Trim();
                    obj.Saldo = convertToDouble(dataReader["Saldo"].ToString().Trim());
                    obj.Total_soles = convertToDouble(dataReader["Total_soles"].ToString().Trim());
                    obj.Total_dolares = convertToDouble(dataReader["Total_dolares"].ToString().Trim());
                    obj.Cambio = convertToDouble(dataReader["Cambio"].ToString().Trim());
                    objList.Add(obj);
                }
            }
            


            return objList;
        }

        public List<FacturaAbono> listarDocumentosFacturaDetraccion(String Ruc, String CodEnt)
        {
            List<FacturaAbono> objList = new List<FacturaAbono>();
            FacturaAbono obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosCobrarVoucherDetraccion",
                   new object[] { CodEnt, Ruc/*, moneda,monedadoc*/});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new FacturaAbono();
                    obj.Ruc = dataReader["Ruc"].ToString();
                    obj.RazonSocial = dataReader["RazonSocial"].ToString();
                    obj.TipoDoc = dataReader["TipoDocumento"].ToString().Trim();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Nro"].ToString();
                    obj.Total = convertToDouble(dataReader["Total"].ToString().Trim());
                    obj.Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.FechaVcto = Convert.ToDateTime(dataReader["FechaVcto"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.Saldo = convertToDouble(dataReader["Total"].ToString().Trim());
                    obj.MonedaCod = dataReader["Moneda"].ToString().Trim();
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.TipoCambio = convertToDouble(dataReader["Cambio"].ToString().Trim());
                    obj.TotalSoles = convertToDouble(dataReader["Soles"].ToString().Trim());
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<Ventas> listarDocumentosVentasDetraccion(String Ruc, String CodEnt)
        {
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosPagarVoucherDetraccion",
                   new object[] { Ruc, CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.CodOt = dataReader["OT"].ToString();
                    obj.DirOt = dataReader["DirOt"].ToString();
                    obj.CodEnt = dataReader["CodEnt"].ToString();
                    obj.VentasId = dataReader["numReg"].ToString().Trim();
                    obj.TipoDocumentoCod = dataReader["TipDocCod"].ToString().Trim();
                    obj.TipoDocumento = dataReader["TipoDocumento"].ToString();
                    obj.Serie = dataReader["serDoc"].ToString();
                    obj.Numero = dataReader["numDoc"].ToString();
                    obj.Total = convertToDouble(dataReader["total"].ToString().Trim());
                    obj.Ruc = dataReader["rucprov"].ToString().Trim();
                    obj.RazonSocial = dataReader["nomprov"].ToString().Trim();
                    obj.FechaEmision = Convert.ToDateTime(dataReader["fecDoc"].ToString().Trim()).ToString("dd/MM/yyyy");
                    obj.NroOt = dataReader["NroOt"].ToString().Trim();
                    obj.Moneda = dataReader["Moneda"].ToString().Trim();
                    obj.TipoCambio = convertToDouble( dataReader["Cambio"].ToString().Trim());
                    obj.TotalSoles = convertToDouble(dataReader["Soles"].ToString().Trim());
                    objList.Add(obj);
                }
            }
            return objList;
        }


        public String getNroCuenta(String Banco, String Moneda)
        {
            String nroCuenta = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_nroCuenta",
                   new object[] { Banco, Moneda });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    nroCuenta = dataReader["NumCuenta"].ToString();
                   
                }
            }
            return nroCuenta;
        }

        public List<Personal> getPersonalVoucher()
        {
            List<Personal> objList = new List<Personal>();
            Personal obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getPersonalVoucher");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Personal();
                    obj.Nombre = dataReader["Nombres"].ToString().ToUpper();
                    obj.NroDocumento = dataReader["DNI"].ToString();
                    obj.CentroCosto = dataReader["ccosto"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<CuentaBanco> getBanco()
        {
            List<CuentaBanco> objList = new List<CuentaBanco>();
            CuentaBanco obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_bancos");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CuentaBanco();
                    obj.Codigo = dataReader["Codigo"].ToString().ToUpper();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Personal> getPersonalVoucherAFP()
        {
            List<Personal> objList = new List<Personal>();
            Personal obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getPersonalVoucherAFP");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Personal();
                    obj.Nombre = dataReader["Nombres"].ToString();
                    obj.NroDocumento = dataReader["DNI"].ToString();
                    obj.CentroCosto = dataReader["ccosto"].ToString();
                    obj.CodAfp = dataReader["Fondopens"].ToString();
                    obj.Afp = dataReader["AFP"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<CargoBancario> getCargoBancarioVoucher()
        {
            List<CargoBancario> objList = new List<CargoBancario>();
            CargoBancario obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_cargosBancariosVoucher");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new CargoBancario();
                    obj.Codigo = dataReader["codigo"].ToString();
                    obj.Descripcion = dataReader["descripcion"].ToString();
                   
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<PrestamoBancario> getPrestamoBancarioVoucher(String CodBanco, String Moneda)
        {
            List<PrestamoBancario> objList = new List<PrestamoBancario>();
            PrestamoBancario obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_PrestamoBancarioVoucher",
                   new object[] { CodBanco, Moneda });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new PrestamoBancario();
                    obj.CodigoPrestamo = dataReader["CodPrestamo"].ToString();
                    obj.CodBanco = dataReader["CodBanco"].ToString();
                    obj.Banco = dataReader["Banco"].ToString();
                    obj.Moneda = dataReader["CodMoneda"].ToString();
                    obj.Monto = convertToDouble( dataReader["Monto"].ToString());
                    obj.FechaEmision = Convert.ToDateTime( dataReader["FechaEmision"].ToString());
                    obj.FechaVcto = Convert.ToDateTime( dataReader["FechaVcto"].ToString());
                    objList.Add(obj);
                }
            }
            return objList;
        }

        public List<TipoImpuesto> getImpuestosVoucher()
        {
            List<TipoImpuesto> objList = new List<TipoImpuesto>();
            TipoImpuesto obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getImpuestosVoucher");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoImpuesto();
                    obj.Codigo = dataReader["Codigo"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objList.Add(obj);
                }
            }
            return objList;
        }


        public List<FacturaAbono> geetDocumentoVoucherAbono(String codent, String ruc)
        {
            List<FacturaAbono> objList = new List<FacturaAbono>();
            FacturaAbono obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosVoucherAbono",
                   new object[] { codent, ruc });
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
        public List<TipoSolicitante> cmbSolicitante()
        {
            List<TipoSolicitante> objList = new List<TipoSolicitante>();
            TipoSolicitante obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_TipoSolicitante");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoSolicitante();
                    obj.Codigo = dataReader["Codigo"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
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
                {
                    return double.Parse(conv, CultureInfo.InvariantCulture);
                }
                else
                {
                    return Convert.ToDouble(conv.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
                }
                   
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public bool insertarLetraCab(LetraCab obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertLetraCabRC",
                   new object[] {  obj.TipoDoc, obj.SerieDoc,  obj.NroDoc,
                       obj.FecRep, obj.Ruc, obj.CodEnt, Usuario,
                      obj.EstRep, obj.TipoCambio, obj.Fec_Reg, obj.ImporteTotal,
                       obj.Monto, obj.Saldo,obj.Fec_Ven,obj.Moneda,obj.Fec_Compromiso,
                        obj.Estado_Doc,obj.NroRegistro,obj.RazonSocial});
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
        public bool insertarVoucherCab(Voucher obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertVoucherCab",
                   new object[] {  obj.NumeroVoucher, obj.CodEnt,  obj.FechaPago,
                       obj.FechaEmision, obj.NumeroCheque, obj.NumeroCuenta, obj.MonedaCod,obj.TpersonaCod,
                      obj.SolicitaCod, obj.CuentaContable, obj.BancoCod, obj.Monto,Usuario, obj.Observacion,obj.Ejercicio,obj.Periodo,obj.TipoMovimiento});
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
        public bool insertarLetraRCDet(LetraDetalle obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertLetraRCDet",
                   new object[] {  obj.Item, obj.TipDoc,  obj.NroDoc,
                       obj.Moneda, obj.CodEnt, obj.TipoDocRef, obj.SerDocRef,obj.NroDocRef,
                      obj.Monto, obj.Fec_emi_ref, obj.Fec_ven_ref,obj.EstRepDet,
                       obj.RucProv,obj.NomProv,obj.Abono,obj.Saldo,obj.NroRegistroLetra,obj.NroRegistro});

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
        public bool ActualizarLetraRCDet(String NroRegistro, String CodEnt,Double AbonoLetra)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_actualizarRCaLetra",
                   new object[] {CodEnt,NroRegistro,AbonoLetra});

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
        public bool ActualizarAbonoLetraRCDet(String NroRegistro, String CodEnt, Double AbonoLetra)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ActualizarAbonoLetraRC",
                   new object[] { CodEnt, NroRegistro, AbonoLetra });

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
        public bool insertarVoucherDet(VoucherDet obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertVoucherDet",
                   new object[] {  obj.NumeroVoucher, obj.CodEnt,  obj.Item,
                       obj.Importe, obj.Descripcion, obj.SerieDocRef, obj.NumeroDocRef,obj.TipDocRef,
                      obj.CodOt, obj.TipoPagoCod, obj.numeroRegistro,obj.NroOt,obj.Documento,obj.DirOt,
                       obj.CodOtReal,obj.NroOtReal,obj.DirOtReal,obj.RazonSocial,obj.FechaEmiRef});


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
        public bool updateVoucherCab(Voucher obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateVoucherCab",
                   new object[] {  obj.NumeroVoucher, obj.CodEnt,  obj.FechaPago,
                       obj.FechaEmision, obj.NumeroCheque, obj.NumeroCuenta, obj.MonedaCod,obj.TpersonaCod,
                      obj.SolicitaCod, obj.CuentaContable, obj.BancoCod, obj.Monto,Usuario, obj.Observacion});
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
        public bool updateLetrarCab(LetraCab obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_actualizarCabLetraRC",
                   new object[] {  obj.TipoDoc,
                                   obj.SerieDoc,
                                   obj.NroDoc,
                                   obj.FecRep,
                                   obj.Ruc,
                                   obj.CodEnt,
                                   Usuario,
                                   obj.EstRep,
                                   obj.TipoCambio,
                                   obj.Fec_Reg,
                                   obj.ImporteTotal,
                                   obj.Monto,
                                   obj.Saldo,
                                   obj.Fec_Ven,
                                   obj.Moneda,
                                   obj.Fec_Compromiso,
                                   obj.Estado_Doc,
                                   obj.NroRegistro});
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
        public bool deleteVoucherDet(String nrovoucher, String CodEnt)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_deleteVoucherDet",
                   new object[] { nrovoucher, CodEnt });
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
        public bool deleteLetraDet(String nroregistro, String CodEnt)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_deleteLetraDetRC",
                   new object[] { nroregistro, CodEnt });
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
        public bool liquidarVoucher(String NroVoucher, String CodEnt, DateTime FechaEntrega, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_liquidarVoucher",
                   new object[] { NroVoucher, CodEnt, FechaEntrega, Usuario });
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
        public bool anularVoucher(String NroVoucher, String CodEnt, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_anularVoucher",
                   new object[] { NroVoucher, CodEnt, Usuario });
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
        public bool anularLetraFC(String NroRegistroLetra, String CodEnt)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_anularLetraFC",
                   new object[] { NroRegistroLetra, CodEnt});
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

        public bool anularLetraDetalleFC(String NroRegistro, String CodEnt, String NroRegistroLetra)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_anularLetraDetalleFC",
                   new object[] { NroRegistro, CodEnt ,NroRegistroLetra});
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
        public bool insertarPrestamoBancario(PrestamoBancario obj, String Usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertPrestamoBancario",
                   new object[] {  obj.CodBanco, obj.Moneda,  obj.Monto,
                       obj.FechaEmision, obj.FechaVcto, Usuario});
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
    }
}
