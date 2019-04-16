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
    public class DocumentoDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public String numeroALetras(double num)
        {
            String enLetras = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("numeroLetras", new object[] { num });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = dataReader["letras"].ToString();
                }
            }
            return enLetras;
        }
        public String correlativoFactura(string tipodocu, string codent, string serie)
        {
            String enLetras = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getCorrelativo",
                   new object[] { tipodocu, codent, serie });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = dataReader["correlativo"].ToString();
                }
            }
            return enLetras;
        }
        public String correlativoLetra(string codent)
        {
            String enLetras = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_correlativoLetra",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = dataReader["correlativo"].ToString();
                }
            }
            return enLetras;
        }

        public bool insertarCabecera(DocumentoCab obj, String codent)
        {
            bool bupdate;
            OtDAO otDao = new OtDAO();
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertCabDoc",
                   new object[] { obj.DocumentoCabSerie, obj.DocumentoCabNro, obj.DocumentoCabTipoDoc,
                       obj.DocumentoCabClienteCod, obj.DocumentoCabFecha, obj.DocumentoCabTipoMoneda, obj.DocumentoCabTotalSinIGV ,
                   obj.DocumentoCabIGV, obj.DocumentoCabTotal, obj.DocumentoCabTipoPago, obj.DocumentoCabUsuAdd, obj.DocumentoCabGlosa,
                   obj.DocumentoCabTipoNotaCredito, obj.DocumentoCabTipoNotaDebito,codent,obj.DocumentoCabFechaVcto,
                       obj.DocumentoCabSerieRef, obj.DocumentoCabNroRef , obj.DocumentoCabTipoDocRef,
                       obj.DocumentoCabDetraccion,obj.DocumentoCabDetraccionPorcentaje, obj.DocumentoCabGuia,
                       obj.DocumentoCabOrdenCompra , obj.DocumentoCabTabla, obj.DocumentoCabFechaDocRef,
                       obj.Intercorp
                   });
            try
            {
                db.ExecuteScalar(dbCommand);
                if (obj.DocumentoCabTabla == "A")
                {
                    bupdate = otDao.updateEstadoAntiguo(obj.DocumentoCabOtCod, obj.DocumentoCabItemOt, codent, obj.DocumentoCabSerie + obj.DocumentoCabNro.Substring(2));
                }
                else if (obj.DocumentoCabTabla == "N")
                {
                    bupdate = otDao.updateEstadoNuevo(obj.DocumentoCabOtCod, obj.DocumentoCabItemOt, codent);
                }
                else
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool insertDetalle(DocumentoDet obj)
        {
            OtDAO otDao = new OtDAO();
            bool bupdate;

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("insertDetalle",
                   new object[] { obj.DocumentoCabNro, obj.ProductoCod,obj.CCostosCod, obj.DocumentoDetCantidad,
                       obj.DocumentoDetPrecioSinIGV, obj.DocumentoDetIGV, obj.DocumentoDetSubTotal, obj.DocumentoDetUsuAdd,
                       obj.DocumentoDetGlosa, obj.DocumentoProdUMCod, obj.DocumentoCabSerie,obj.DocumentoDetTabla, obj.DocumentoDesProducto,
                       obj.DocumentoDetNroOt, obj.DocumentoDetCodEnt,obj.CuentaContable, obj.DocumentoDetItemOt
                   });
            try
            {
                db.ExecuteScalar(dbCommand);

                bupdate = otDao.updateEstadoAntiguo(obj.DocumentoDetNroOt, obj.DocumentoDetItemOt, obj.DocumentoDetCodEnt, obj.DocumentoCabSerie + obj.DocumentoCabNro);

                bupdate = otDao.updateEstadoNuevo(obj.DocumentoDetNroOt, obj.DocumentoDetItemOt, obj.DocumentoDetCodEnt);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool deleteDetDoc(String serie, String nro)
        {
           
            bool bupdate;

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_deleteDocdet",
                   new object[] {serie,nro
                   });
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
        public List<DocumentoCab> listarCabecera(DateTime d1, DateTime d2, String ruc, String tipodocu, String codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_buscarFacturas",
                   new object[] { d1, d2, ruc, tipodocu, codent});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();

                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString().Trim(); 
                    obj.DocumentoCabCliente = dataReader["Cli_RazonSocial"].ToString().Trim();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Mon_Descripcion"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Cli_NDocumento"].ToString().Trim();
                    obj.DocumentoCabUsuAdd = dataReader["DOCcab_UsuAdd"].ToString();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = Math.Round(convertToDouble(dataReader["DOCcab_Detraccion"].ToString()),2);
                    obj.DocumentoCabTabla = dataReader["tabla"].ToString();
                    string aux3 = dataReader["DOCcab_FechaAdd"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaAdd = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaAdd = new DateTime(2000, 1, 1);
                    }
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabTipoNotaCredito = dataReader["DOCcab_TipoNotaCredito"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["DOCcab_TipoNotaDebito"].ToString();
                    obj.DocumentoCabClienteDireccion = dataReader["Cli_Direccion"].ToString().Trim();
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();

                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString().Trim();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString().Trim();
                    string aux4 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux4))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux4).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoSunat = Convert.ToInt32(dataReader["EstadoSunat"].ToString());
                    if (obj.EstadoSunat == 0)
                    {
                        obj.EstadoS = "ANULADO";

                    }
                    else if (obj.EstadoSunat == 1)
                    {
                        obj.EstadoS = "NO ENVIADO";

                    }
                    else if (obj.EstadoSunat == 2)
                    {
                        obj.EstadoS = "ENVIADO";

                    }
                    else if (obj.EstadoSunat == 3)
                    {
                        obj.EstadoS = "ACEPTADO POR SUNAT";

                    }
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<DocumentoDet> listarDetalle(string numero, string serie, string codent)
        {
            List<DocumentoDet> objLista = new List<DocumentoDet>();
            DocumentoDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarDetalle",
                   new object[] { numero, serie, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoDet();
                    obj.DocumentoCabNro = dataReader["DOCdet_CabDocCod"].ToString();
                    obj.DocumentoDetId = Convert.ToInt32(dataReader["id"].ToString());
                    obj.ProductoCod = dataReader["DOCdet_ProductoCod"].ToString().Trim();
                    obj.DocumentoDesProducto = dataReader["Prod_Descripcion"].ToString().Trim();
                    obj.DocumentoDetPrecioSinIGV = convertToDouble(dataReader["DOCdet_PrecioSinIGV"].ToString());
                    obj.DocumentoDetIGV = convertToDouble(dataReader["DOCdet_IGV"].ToString());
                    obj.DocumentoDetPrecioTotal = convertToDouble(dataReader["DOCdet_PrecioTotal"].ToString());
                    obj.DocumentoDetGlosa = dataReader["DOCdet_Glosa"].ToString();
                    obj.DocumentoProdUMCod = dataReader["docdet_UM"].ToString();
                    obj.DocumentoProdUMcorta = dataReader["UM_Corta"].ToString();
                    obj.DocumentoDetCantidad = convertToDouble(dataReader["DOCdet_Cantidad"].ToString());
                    obj.DocumentoCabSerie = dataReader["DOCdet_CabDocSerie"].ToString();
                    obj.DocumentoDetTabla = dataReader["tabla"].ToString();
                    obj.otPorcentaje = convertToDouble(dataReader["otPorcentaje"].ToString());
                    obj.DocumentoDetSubTotal = Math.Round( obj.DocumentoDetPrecioSinIGV * obj.DocumentoDetCantidad,2);
                    string aux = dataReader["ItemOt"].ToString();
                    if (String.IsNullOrEmpty(aux) || aux == "0")
                    {
                        obj.DocumentoDetItemOt = 0;
                    }
                    else
                    {
                        obj.DocumentoDetItemOt = Convert.ToInt32(aux);
                    }
                    obj.DocumentoDetNroOt = dataReader["nroot"].ToString().Trim();
                    objLista.Add(obj);
                }
            }
            return objLista;
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

        public List<DocumentoCab> buscarDocumentosNotas(String tipodocu, String codent, String codclie)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_buscarDocumento",
                   new object[] { tipodocu, codent, codclie });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["Cli_RazonSocial"].ToString().Trim();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Cli_NDocumento"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["Cli_Direccion"].ToString().Trim();
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble( dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }
                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<DocumentoCab> documentoPorFechaG(String tipoDocu, DateTime d1, DateTime d2, String moneda, String codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorFechaG",
                   new object[] { tipoDocu, d1, d2, moneda, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabTipoDoc = dataReader["DOCcab_TipoDoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString().Trim();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    string aux3 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    if (obj.DocumentoCabTipoDoc == "LT")
                    {
                        obj.DocumentoCabTotal = obj.DocumentoCabAbono;
                    }
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabOtCod = dataReader["NroOt"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabDoc = dataReader["TipoDocu"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    obj.DocumentoCabDocRef = dataReader["TipoDocuRef"].ToString();
                    obj.DocumentoCabCliente = dataReader["RazCli"].ToString().TrimEnd();
                    obj.DocumentoCabClienteDocumento = dataReader["RucCli"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["DirCli"].ToString().Trim();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString().Trim();
                    obj.DocumentoCabTipoNotaCredito = dataReader["TipoNCredito"].ToString();
                    obj.DocumentoCabTipoNotaCreditoSunat = dataReader["TCredito_CodSunat"].ToString();
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["TipoNDebito"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebitoSunat = dataReader["TDebito_CodSunat"].ToString();
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString().Trim();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoS = dataReader["EstadoSunat"].ToString();
                    obj.Peso = convertToDouble(dataReader["Suma"].ToString());
                    if (obj.Peso == 0)
                    {
                        obj.Precio = 1;
                    }
                    else
                    {
                        obj.Precio = Math.Round(obj.DocumentoCabTotalSinIGV / obj.Peso, 2);
                    }
                    obj.TipoCambio = convertToDouble(dataReader["TCambio"].ToString());
                    obj.NumeroDocumento = obj.DocumentoCabSerie + "-" + obj.DocumentoCabNro;
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoCab> documentoPorFechaM(String tipoDocu, DateTime d1, DateTime d2, String moneda, String codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorFechaM",
                   new object[] { tipoDocu, d1, d2, moneda, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabTipoDoc = dataReader["DOCcab_TipoDoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString().Trim();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    string aux3 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    if (obj.DocumentoCabTipoDoc == "LT")
                    {
                        obj.DocumentoCabTotal = obj.DocumentoCabAbono;
                    }
                
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabOtCod = dataReader["NroOt"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabDoc = dataReader["TipoDocu"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    obj.DocumentoCabDocRef = dataReader["TipoDocuRef"].ToString();
                    obj.DocumentoCabCliente = dataReader["RazCli"].ToString().TrimEnd();
                    obj.DocumentoCabClienteDocumento = dataReader["RucCli"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["DirCli"].ToString().Trim();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString().Trim();
                    obj.DocumentoCabTipoNotaCredito = dataReader["TipoNCredito"].ToString();
                    obj.DocumentoCabTipoNotaCreditoSunat = dataReader["TCredito_CodSunat"].ToString();
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["TipoNDebito"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebitoSunat = dataReader["TDebito_CodSunat"].ToString();
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString().Trim();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoS = dataReader["EstadoSunat"].ToString();
                    obj.Peso = convertToDouble(dataReader["Suma"].ToString());
                    if (obj.Peso == 0)
                    {
                        obj.Precio = 1;
                    }
                    else
                    {
                        obj.Precio = Math.Round(obj.DocumentoCabTotalSinIGV / obj.Peso, 2);
                    }
                    obj.TipoCambio = convertToDouble(dataReader["TCambio"].ToString());
                    obj.NumeroDocumento = obj.DocumentoCabSerie + "-" + obj.DocumentoCabNro;
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        
        public List<DocumentoCab> documentoPorClienteGanio(String cliente, String d1, String d2, String moneda, String codent, String tipdoc)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorClienteGanio",
                   new object[] { cliente, d1, d2, moneda, codent, tipdoc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabTipoDoc = dataReader["DOCcab_TipoDoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString();
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    string aux3 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    if (obj.DocumentoCabTipoDoc == "LT")
                    {
                        obj.DocumentoCabTotal = obj.DocumentoCabAbono;
                    }
                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabOtCod = dataReader["NroOt"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabDoc = dataReader["TipoDocu"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    obj.DocumentoCabDocRef = dataReader["TipoDocuRef"].ToString();
                    obj.DocumentoCabCliente = dataReader["RazCli"].ToString().TrimEnd();
                    obj.DocumentoCabClienteDocumento = dataReader["RucCli"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["DirCli"].ToString().Trim();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaCredito = dataReader["TipoNCredito"].ToString();
                    obj.DocumentoCabTipoNotaCreditoSunat = dataReader["TCredito_CodSunat"].ToString();
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["TipoNDebito"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebitoSunat = dataReader["TDebito_CodSunat"].ToString();
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoS = dataReader["EstadoSunat"].ToString();
                    obj.Peso = convertToDouble(dataReader["Suma"].ToString());
                    if (obj.Peso == 0)
                    {
                        obj.Precio = 1;
                    }
                    else
                    {
                        obj.Precio = Math.Round(obj.DocumentoCabTotalSinIGV / obj.Peso, 2);
                    }
                    obj.TipoCambio = convertToDouble(dataReader["TCambio"].ToString());
                    obj.NumeroDocumento = obj.DocumentoCabSerie + "-" + obj.DocumentoCabNro;
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    objLista.Add(obj);

                }
            }
            return objLista;
        }
        public List<DocumentoCab> documentoPorClienteG(String cliente, String d1, String d2, String moneda, String codent, String tipdoc)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorClienteG",
                   new object[] { cliente, d1, d2, moneda, codent, tipdoc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabTipoDoc = dataReader["DOCcab_TipoDoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString();
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    string aux3 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    if (obj.DocumentoCabTipoDoc == "LT")
                    {
                        obj.DocumentoCabTotal = obj.DocumentoCabAbono;
                    }
                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabOtCod = dataReader["NroOt"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabDoc = dataReader["TipoDocu"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    obj.DocumentoCabDocRef = dataReader["TipoDocuRef"].ToString();
                    obj.DocumentoCabCliente = dataReader["RazCli"].ToString().TrimEnd();
                    obj.DocumentoCabClienteDocumento = dataReader["RucCli"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["DirCli"].ToString().Trim();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaCredito = dataReader["TipoNCredito"].ToString();
                    obj.DocumentoCabTipoNotaCreditoSunat = dataReader["TCredito_CodSunat"].ToString();
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["TipoNDebito"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebitoSunat = dataReader["TDebito_CodSunat"].ToString();
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoS = dataReader["EstadoSunat"].ToString();
                    obj.Peso = convertToDouble(dataReader["Suma"].ToString());
                    if (obj.Peso == 0)
                    {
                        obj.Precio = 1;
                    }
                    else
                    {
                        obj.Precio = Math.Round(obj.DocumentoCabTotalSinIGV / obj.Peso, 2);
                    }
                    obj.TipoCambio = convertToDouble(dataReader["TCambio"].ToString());
                    obj.NumeroDocumento = obj.DocumentoCabSerie + "-" + obj.DocumentoCabNro;
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    objLista.Add(obj);

                }
            }
            return objLista;
        }
        public List<DocumentoCab> documentoPorClienteManio(String cliente, String d1, String d2, String moneda, String codent, String tipdoc)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorClienteAnio",
                   new object[] { cliente, d1, d2, moneda, codent, tipdoc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabTipoDoc = dataReader["DOCcab_TipoDoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString();
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    string aux3 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabOtCod = dataReader["NroOt"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabDoc = dataReader["TipoDocu"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    if (obj.DocumentoCabTipoDoc == "LT")
                    {
                        obj.DocumentoCabTotal = obj.DocumentoCabAbono;
                    }
                    obj.DocumentoCabDocRef = dataReader["TipoDocuRef"].ToString();
                    obj.DocumentoCabCliente = dataReader["RazCli"].ToString().TrimEnd();
                    obj.DocumentoCabClienteDocumento = dataReader["RucCli"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["DirCli"].ToString().Trim();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaCredito = dataReader["TipoNCredito"].ToString();
                    obj.DocumentoCabTipoNotaCreditoSunat = dataReader["TCredito_CodSunat"].ToString();
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["TipoNDebito"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebitoSunat = dataReader["TDebito_CodSunat"].ToString();
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoS = dataReader["EstadoSunat"].ToString();
                    obj.Peso = convertToDouble(dataReader["Suma"].ToString());
                    if (obj.Peso == 0)
                    {
                        obj.Precio = 1;
                    }
                    else
                    {
                        obj.Precio = Math.Round(obj.DocumentoCabTotalSinIGV / obj.Peso, 2);
                    }
                    obj.TipoCambio = convertToDouble(dataReader["TCambio"].ToString());
                    obj.NumeroDocumento = obj.DocumentoCabSerie + "-" + obj.DocumentoCabNro;
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<Ventas> documentoPorProveedorAnio(String d1, String d2, String codent, String ruc)
        {
            List<Ventas> objLista = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reporteFacturaProveedorAnio",
                   new object[] { d1, d2, codent,ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.Ruc = dataReader["Ruc"].ToString().Trim();
                    obj.RazonSocial = dataReader["Proveedor"].ToString().Trim();
                    obj.FechaEmision = dataReader["Fecha"].ToString().Substring(0,10);
                    obj.Serie = dataReader["Serie"].ToString().Trim();
                    obj.Numero = dataReader["Documento"].ToString().Trim();
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.TipoCambio = convertToDouble(dataReader["TC"].ToString());
                    obj.total_soles = convertToDouble(dataReader["Total Soles"].ToString());
                    obj.total_dolares = convertToDouble(dataReader["Total Dolares"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<Ventas> documentoPorProveedor(String d1, String d2, String codent, String ruc)
        {
            List<Ventas> objLista = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reporteFacturaProveedor",
                   new object[] { d1, d2, codent,ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.Ruc = dataReader["Ruc"].ToString().Trim();
                    obj.RazonSocial = dataReader["Proveedor"].ToString().Trim();
                    obj.FechaEmision = dataReader["Fecha"].ToString().Substring(0,10);
                    obj.Serie = dataReader["Serie"].ToString().Trim();
                    obj.Numero = dataReader["Documento"].ToString().Trim();
                    obj.Total =convertToDouble(dataReader["Total"].ToString());
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.TipoCambio = convertToDouble(dataReader["TC"].ToString());
                    obj.total_soles = convertToDouble(dataReader["Total Soles"].ToString());
                    obj.total_dolares = convertToDouble(dataReader["Total Dolares"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<Ventas> documentoPorProveedorTotalziadoAnio(String d1, String d2, String codent, String ruc)
        {
            List<Ventas> objLista = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reporteFacturaProveedorTotalizadoAnio",
                   new object[] { d1, d2, codent, ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.Ruc = dataReader["Ruc"].ToString().Trim();
                    obj.RazonSocial = dataReader["Proveedor"].ToString().Trim();
                    obj.total_soles = convertToDouble(dataReader["Total Facturado Soles"].ToString());
                    obj.total_dolares = convertToDouble(dataReader["Total Facturado Dolares"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<Ventas> documentoPorProveedorTotalziado(String d1, String d2, String codent, String ruc)
        {
            List<Ventas> objLista = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reporteFacturaProveedorTotalizado",
                   new object[] { d1, d2, codent, ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();
                    obj.Ruc = dataReader["Ruc"].ToString().Trim();
                    obj.RazonSocial = dataReader["Proveedor"].ToString().Trim();
                    obj.total_soles = convertToDouble(dataReader["Total Facturado Soles"].ToString());
                    obj.total_dolares = convertToDouble(dataReader["Total Facturado Dolares"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoCab> reporteLetraCliente(String codent , DateTime d1, DateTime d2, String estado,String Ruc)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reporteletrasporvencimientocliente",
                   new object[] { codent, d1, d2, estado, Ruc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();

                    obj.DocumentoCabCliente = dataReader["RazonSocial"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["RUC"].ToString();
                    obj.DocumentoCabFechaVcto =Convert.ToDateTime( dataReader["FVen"]);
                    obj.DocumentoCabTipoDoc = dataReader["Tpdoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["Numero"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    obj.DocumentoCabTotal = convertToDouble(dataReader["Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["Abono"].ToString());
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["Saldo"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoCab> documentoPorClienteM(String cliente, String d1, String d2, String moneda, String codent, String tipdoc)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorClienteM",
                   new object[] { cliente, d1, d2, moneda, codent , tipdoc });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabTipoDoc = dataReader["DOCcab_TipoDoc"].ToString();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString();
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    string aux3 = dataReader["FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoCabFechaDocRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["DOCcab_TotalSinIGV"].ToString());
                    obj.DocumentoCabIGV = convertToDouble(dataReader["DOCcab_TotalIGV"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    obj.DocumentoCabTipoDocRef = dataReader["DOCcab_TipoDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabOtCod = dataReader["NroOt"].ToString();
                    obj.DocumentoCabGlosa = dataReader["DOCcab_Glosa"].ToString();
                    obj.DocumentoCabDoc = dataReader["TipoDocu"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Moneda"].ToString();
                    if (obj.DocumentoCabTipoDoc == "LT")
                    {
                        obj.DocumentoCabTotal = obj.DocumentoCabAbono;
                    }
                    obj.DocumentoCabDocRef = dataReader["TipoDocuRef"].ToString();
                    obj.DocumentoCabCliente = dataReader["RazCli"].ToString().TrimEnd();
                    obj.DocumentoCabClienteDocumento = dataReader["RucCli"].ToString().Trim();
                    obj.DocumentoCabClienteDireccion = dataReader["DirCli"].ToString().Trim();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaCredito = dataReader["TipoNCredito"].ToString();
                    obj.DocumentoCabTipoNotaCreditoSunat = dataReader["TCredito_CodSunat"].ToString();
                    obj.DocumentoCabNotaCredito = dataReader["TCredito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebito = dataReader["TipoNDebito"].ToString();
                    obj.DocumentoCabNotaDebito = dataReader["TDebito_Descripcion"].ToString();
                    obj.DocumentoCabTipoNotaDebitoSunat = dataReader["TDebito_CodSunat"].ToString();
                    obj.DocumentoCabOrdenCompra = dataReader["DOCcab_OrdenCompra"].ToString();
                    obj.DocumentoCabGuia = dataReader["DOCCAB_GUIA"].ToString();
                    obj.EstadoS = dataReader["EstadoSunat"].ToString();
                    obj.Peso = convertToDouble(dataReader["Suma"].ToString());
                    if (obj.Peso == 0)
                    {
                        obj.Precio = 1;
                    }
                    else
                    {
                        obj.Precio = Math.Round(obj.DocumentoCabTotalSinIGV / obj.Peso, 2);
                    }
                    obj.TipoCambio = convertToDouble(dataReader["TCambio"].ToString());
                    obj.NumeroDocumento = obj.DocumentoCabSerie + "-" + obj.DocumentoCabNro;
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoCab> documentoPorClienteTotalizado(String d1, String d2, String codent, String cliente)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorClienteTotalizado",
                   new object[] { d1, d2, codent, cliente });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["RazonSocial"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Ruc"].ToString();
                    obj.TotalSoles = convertToDouble(dataReader["Total Facturado Soles"].ToString());
                    obj.TotalDoalres = convertToDouble(dataReader["Total Facturado Dolares"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoCab> documentoPorClienteTotalizadoanio(String d1, String d2, String codent, String cliente)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_documentosPorClienteTotalizadoAnio",
                   new object[] { d1, d2, codent,cliente });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["RazonSocial"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Ruc"].ToString();
                    obj.TotalSoles = convertToDouble(dataReader["Total Facturado Soles"].ToString());
                    obj.TotalDoalres = convertToDouble(dataReader["Total Facturado Dolares"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoDet> detalleReporte(string serie, string numero, string codent)
        {
            List<DocumentoDet> objLista = new List<DocumentoDet>();
            DocumentoDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_detalleReporte",
                   new object[] { serie, numero, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoDet();
                    obj.DocumentoCabNro = dataReader["DOCdet_CabDocCod"].ToString();
                    obj.DocumentoDetId = Convert.ToInt32(dataReader["id"].ToString());
                    obj.ProductoCod = dataReader["DOCdet_ProductoCod"].ToString().Trim();
                    obj.DocumentoDesProducto = dataReader["Prod_Descripcion"].ToString();
                    obj.DocumentoDetPrecioSinIGV = convertToDouble(dataReader["DOCdet_PrecioSinIGV"].ToString());
                    obj.DocumentoDetPrecioTotal = convertToDouble(dataReader["DOCdet_PrecioTotal"].ToString());
                    obj.DocumentoDetGlosa = dataReader["DOCdet_Glosa"].ToString();
                    obj.DocumentoProdUMcorta = dataReader["UM_Corta"].ToString();
                    obj.DocumentoProdUM = dataReader["UM_Descr"].ToString();
                    obj.DocumentoDetCantidad = convertToDouble(dataReader["DOCdet_Cantidad"].ToString());
                    obj.DocumentoCabSerie = dataReader["DOCdet_CabDocSerie"].ToString();
                    obj.DocumentoDetSubTotal = obj.DocumentoDetPrecioSinIGV * obj.DocumentoDetCantidad;
                    obj.DocumentoDetNroOt = dataReader["nroot"].ToString();
                    obj.DocumentoDesProducto = obj.DocumentoDesProducto;
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        


        public List<DocumentoCab> listarLetraCab(DateTime d1, DateTime d2, String ruc, String codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_letraCab",
                   new object[] { codent, ruc, d1, d2 });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["Cli_RazonSocial"].ToString().Trim();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString().Trim();
                    obj.DocumentoCabMoneda = dataReader["Mon_Descripcion"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Cli_NDocumento"].ToString().Trim();
                    obj.EstadoSunat = Convert.ToInt32(dataReader["EstadoSunat"].ToString().Trim());
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = Math.Round(convertToDouble(dataReader["DOCcab_Detraccion"].ToString()), 2);
                    obj.DocumentoCabNroRef = dataReader["Doccab_NumeroRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["Doccab_SerieRef"].ToString();
                    obj.DocumentoCabFecha = Convert.ToDateTime(dataReader["DOCcab_Fecha"].ToString());
                   

                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTotal = Math.Round(convertToDouble(dataReader["DOCcab_Total"].ToString()),2);
                    obj.DocumentoCabSaldo = Math.Round(convertToDouble(dataReader["DOCcab_Saldo"].ToString()),2);
                    obj.DocumentoCabAbono = Math.Round(convertToDouble(dataReader["DOCcab_Abono"].ToString()), 2);
                    obj.DocumentoCabClienteAval = dataReader["RazSocAval"].ToString().Trim();
                    obj.DocumentoCabClienteCodAval = dataReader["DOCcab_CodClienteAVAL"].ToString().Trim();
                    obj.DocumentoCabClienteDireccionAval = dataReader["DirecAval"].ToString().Trim();
                    obj.DocumentoCabClienteTelefonoAval = dataReader["TelefAval"].ToString();
                    obj.DocumentoCabClienteRucAval = dataReader["DocuAval"].ToString().Trim();
                    obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();
                    obj.DocumentoCabPago = dataReader["TPago_Descripcion"].ToString();
                    obj.DocumentoCabClienteDireccion = dataReader["Cli_Direccion"].ToString().Trim();
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());
                    obj.DocumentoCabSerieRef = dataReader["DOCcab_SerieRef"].ToString();
                    obj.DocumentoCabDividir = Convert.ToInt32(dataReader["DOCcab_Divir"].ToString());
                    obj.DocumentoCabNroRef = dataReader["DOCcab_NumeroRef"].ToString();
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString(); 
                    if (obj.EstadoSunat == 3)
                    {
                        obj.EstadoS = "EMITIDA";
                    }
                    else if (obj.EstadoSunat == 0)
                    {
                        obj.EstadoS = "ANULADO";
                    }
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public bool insertarLetraCab(DocumentoCab obj, String codent)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertLetraCab",
                   new object[] { codent, obj.DocumentoCabSerie, obj.DocumentoCabNro, obj.DocumentoCabClienteCod.Trim(), obj.DocumentoCabTipoPago,
                       obj.DocumentoCabClienteCodAval.Trim(), obj.DocumentoCabTotal, obj.DocumentoCabAbono, obj.DocumentoCabDetraccionPorcentaje,
                       obj.DocumentoCabDetraccion, obj.DocumentoCabSaldo, obj.DocumentoCabDividir,  obj.DocumentoCabFecha,
                  obj.DocumentoCabFechaVcto  , obj.DocumentoCabTipoDoc , obj.DocumentoCabTipoMoneda,
                       obj.DocumentoCabSerieRef, obj.DocumentoCabNroRef, obj.DocumentoCabUsuAdd   });
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
        public bool updateLetraCab(DocumentoCab obj, String codent, String usuario)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateLetraCab",
                   new object[] { codent, obj.DocumentoCabSerie, obj.DocumentoCabNro, obj.DocumentoCabClienteCod.Trim(), obj.DocumentoCabTipoPago,
                       obj.DocumentoCabClienteCodAval.Trim(), obj.DocumentoCabTotal, obj.DocumentoCabAbono, obj.DocumentoCabDetraccionPorcentaje,
                       obj.DocumentoCabDetraccion, obj.DocumentoCabSaldo, obj.DocumentoCabDividir,  obj.DocumentoCabFecha,
                  obj.DocumentoCabFechaVcto  , obj.DocumentoCabTipoDoc , obj.DocumentoCabTipoMoneda,
                       obj.DocumentoCabSerieRef, obj.DocumentoCabNroRef,   usuario });
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
        public bool insertLetraDet(LetraDet obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertLetraDet",
                   new object[] {  obj.LetraDetSerie,obj.LetraDetNro, obj.LetraDetSerieRef, obj.LetraDetNroRef,
                       obj.LetraDetFechaEmisionRef, obj.LetraDetFechaVctoRef, obj.LetraDetTotal, obj.LetraDetAbono,
                       obj.LetraDetDetraccionPorcentaje, obj.LetraDetDetraccion, obj.LetraDetSaldo, obj.LetraDetCodMoneda
                   });
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

        public bool updateLetraDet(LetraDet obj)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateLetraDet",
                   new object[] { obj.LetraDetId, obj.LetraDetSerie,obj.LetraDetNro, obj.LetraDetSerieRef, obj.LetraDetNroRef,
                       obj.LetraDetFechaEmisionRef, obj.LetraDetFechaVctoRef, obj.LetraDetTotal, obj.LetraDetAbono,
                       obj.LetraDetDetraccionPorcentaje, obj.LetraDetDetraccion, obj.LetraDetSaldo, obj.LetraDetCodMoneda
                   });
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
        public List<LetraDet> listarLetraDet(String serie, String nro)
        {
            List<LetraDet> objLista = new List<LetraDet>();
            LetraDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_letraDet",
                   new object[] { serie, nro });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LetraDet();
                    obj.LetraDetId = Convert.ToInt32(dataReader["id"].ToString().Trim());
                    obj.LetraDetNro = dataReader["LetraNro"].ToString().Trim();
                    obj.LetraDetSerie = dataReader["LetraSerie"].ToString().Trim();
                    obj.LetraDetSerieRef = dataReader["LetraSerieRef"].ToString();
                    obj.LetraDetNroRef = dataReader["LetraNroRef"].ToString().Trim();
                    obj.LetraDetTotal = Math.Round( convertToDouble(dataReader["LetraTotal"].ToString()),2);
                    obj.LetraDetAbono = Math.Round(convertToDouble(dataReader["LetraAbono"].ToString()),2);
                    string aux = dataReader["LetraFechaEmisionRef"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.LetraDetFechaEmisionRef = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.LetraDetFechaEmisionRef = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["LetraFechaVctoRef"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.LetraDetFechaVctoRef = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.LetraDetFechaVctoRef = new DateTime(2000, 1, 1);
                    }
                    obj.LetraDetDetraccionPorcentaje = Math.Round(convertToDouble(dataReader["LetraDetraccionPorcentaje"].ToString()),2);
                    obj.LetraDetDetraccion = Math.Round(convertToDouble(dataReader["LetraDetraccion"].ToString()),2);
                    obj.LetraDetSaldo = Math.Round(convertToDouble(dataReader["LetraSaldo"].ToString()),2);


                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<LetraDet> listarLetraDetReporte(String serie, String nro, String cobranza, String codent)
        {
            List<LetraDet> objLista = new List<LetraDet>();
            LetraDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_letradetReporte",
                   new object[] { serie, nro, cobranza, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LetraDet();
                    obj.LetraDetId = Convert.ToInt32(dataReader["id"].ToString().Trim());
                    obj.LetraDetNro = dataReader["LetraNro"].ToString().Trim();
                    obj.LetraDetSerie = dataReader["LetraSerie"].ToString().Trim();
                    obj.LetraDetSerieRef = dataReader["LetraSerieRef"].ToString();
                    obj.LetraDetNroRef = dataReader["LetraNroRef"].ToString().Trim();
                    obj.LetraDetTotal = Math.Round(convertToDouble(dataReader["LetraTotal"].ToString()), 2);
                    obj.LetraDetAbono = Math.Round(convertToDouble(dataReader["LetraAbono"].ToString()), 2);
                    string aux = dataReader["LetraFechaEmisionRef"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.LetraDetFechaEmisionRef = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.LetraDetFechaEmisionRef = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["LetraFechaVctoRef"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.LetraDetFechaVctoRef = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.LetraDetFechaVctoRef = new DateTime(2000, 1, 1);
                    }
                    obj.LetraDetDetraccionPorcentaje = Math.Round(convertToDouble(dataReader["LetraDetraccionPorcentaje"].ToString()), 2);
                    obj.LetraDetDetraccion = Math.Round(convertToDouble(dataReader["LetraDetraccion"].ToString()), 2);
                    obj.LetraDetSaldo = Math.Round(convertToDouble(dataReader["LetraSaldo"].ToString()), 2);


                    objLista.Add(obj);
                }
            }
            return objLista;
        }



        public List<DocumentoCab> listarLetraCabRenovacion(string codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_letraCabRenovacion",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["Cli_RazonSocial"].ToString().Trim();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString().Trim();
                    //obj.DocumentoCabMoneda = dataReader["Mon_Descripcion"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Cli_NDocumento"].ToString().Trim();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = Math.Round( convertToDouble(dataReader["DOCcab_Detraccion"].ToString()),2);
                    obj.DocumentoCabClienteCod = dataReader["DOCcab_ClienteCod"].ToString().Trim();
                    string aux = dataReader["DOCcab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["DOCcab_FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabTotal = convertToDouble(dataReader["DOCcab_Total"].ToString());
                    obj.DocumentoCabSaldo = convertToDouble(dataReader["DOCcab_Saldo"].ToString());
                    obj.DocumentoCabAbono = convertToDouble(dataReader["DOCcab_Abono"].ToString());
                    obj.DocumentoCabClienteAval = dataReader["Aval"].ToString().Trim();
                    obj.DocumentoCabClienteCodAval = dataReader["DOCcab_CodClienteAVAL"].ToString().Trim();
                    obj.DocumentoCabClienteDireccionAval = dataReader["DireccionAval"].ToString().Trim();
                    obj.DocumentoCabClienteTelefonoAval = dataReader["TelefAval"].ToString();
                    obj.DocumentoCabClienteRucAval = dataReader["RUCaval"].ToString().Trim();
                    obj.DocumentoCabAbonoSuma = Math.Round(obj.DocumentoCabAbono + obj.DocumentoCabDetraccion,2);
                    //*obj.DocumentoCabTipoMoneda = dataReader["DOCcab_Moneda"].ToString();



                    obj.DocumentoCabClienteDireccion = dataReader["Cli_Direccion"].ToString().Trim();
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["DOCcab_TipoPago"].ToString());


                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<LetraDet> listarLetraDetRenovacion(String serie, String nro)
        {
            List<LetraDet> objLista = new List<LetraDet>();
            LetraDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_letraDetbRenovacion",
                   new object[] { serie, nro });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new LetraDet();
                    obj.LetraDetId = Convert.ToInt32(dataReader["id"].ToString().Trim());
                    obj.LetraDetNro = dataReader["LetraNro"].ToString().Trim();
                    obj.LetraDetSerie = dataReader["LetraSerie"].ToString().Trim();
                    obj.LetraDetSerieRef = dataReader["LetraSerieRef"].ToString();
                    obj.LetraDetNroRef = dataReader["LetraNroRef"].ToString().Trim();
                    obj.LetraDetTotal = Math.Round(convertToDouble(dataReader["LetraTotal"].ToString()),2);
                    obj.LetraDetAbono = Math.Round(convertToDouble(dataReader["LetraAbono"].ToString()),2);


                    string aux = dataReader["LetraFechaEmisionRef"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.LetraDetFechaEmisionRef = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.LetraDetFechaEmisionRef = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["LetraFechaVctoRef"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.LetraDetFechaVctoRef = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.LetraDetFechaVctoRef = new DateTime(2000, 1, 1);
                    }
                    obj.LetraDetDetraccionPorcentaje = convertToDouble(dataReader["LetraDetraccionPorcentaje"].ToString());
                    obj.LetraDetDetraccion = Math.Round(convertToDouble(dataReader["LetraDetraccion"].ToString()),2);
                    obj.LetraDetSaldo = Math.Round(convertToDouble(dataReader["LetraSaldo"].ToString()),2);
                    obj.LetraDetAbonoSuma = Math.Round(obj.LetraDetAbono + obj.LetraDetDetraccion,2);

                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public bool insertarRenovacionCab(DocumentoCab obj, String codent)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertRenovacionCab",
                   new object[] { codent, obj.DocumentoCabSerie, obj.DocumentoCabNro, obj.DocumentoCabClienteCod.Trim(), obj.DocumentoCabTipoPago,
                       obj.DocumentoCabClienteCodAval.Trim(), obj.DocumentoCabTotal, obj.DocumentoCabAbono, obj.DocumentoCabDetraccionPorcentaje,
                       obj.DocumentoCabDetraccion, obj.DocumentoCabSaldo, obj.DocumentoCabDividir,  obj.DocumentoCabFecha,
                  obj.DocumentoCabFechaVcto  , obj.DocumentoCabTipoDoc, obj.DocumentoCabNroRef, obj.DocumentoCabSerieRef , obj.DocumentoCabUsuAdd   });
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
        public bool deleteLetraDet(String Serie, String NroDoc)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_DeleteletraDet",
                   new object[] { Serie, NroDoc });
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

        public DocumentoElectronicoCab getDocumentoElectronicoCab(String serie, String numero, String codent)
        {
            DateTime daux, daux2;
            DocumentoElectronicoCab obj = new DocumentoElectronicoCab();
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentoElectronicoCab",
                   new object[] { serie, numero, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {

                    obj.TipoDocumento = dataReader["TipoDocumento"].ToString();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.NumeroString = dataReader["CodigoString"].ToString();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.Operacion = dataReader["operacion"].ToString();
                    obj.TipoDocumentoCliente = dataReader["TipoDocCliente"].ToString();
                    obj.NroDocCliente = dataReader["RUC"].ToString().Trim();
                    obj.RazonSocialCliente = dataReader["RazonSocial"].ToString().Trim();
                    obj.DireccionCliente = dataReader["Direccion"].ToString().Trim();
                    obj.EmailCliente = dataReader["email"].ToString().Trim();
                    string aux = dataReader["Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        daux = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        daux = new DateTime(2000, 1, 1);
                    }
                    obj.FechaEmision = daux.ToString("dd-MM-yyyy");
                    string aux2 = dataReader["FechaVencimiento"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        daux2 = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        daux2 = Convert.ToDateTime(obj.FechaEmision);
                    }
                    obj.FechaVencimiento = daux2.ToString("dd-MM-yyyy");
                    obj.Moneda = dataReader["Moneda"].ToString();
                    obj.TipoCambio = dataReader["TipoCambio"].ToString();
                    obj.Igv = dataReader["Igv"].ToString();
                    obj.TotalGravada = dataReader["TotalGravada"].ToString();
                    obj.TotalIgv = dataReader["TotalIgv"].ToString();
                    obj.Total = dataReader["Total"].ToString();
                    obj.DescuentoGlobal = dataReader["DescuentoGlobal"].ToString();
                    obj.TotalDescuento = dataReader["TotalDescuento"].ToString();
                    obj.TotalAnticipo = dataReader["TotalAnticipo"].ToString();
                    obj.TotalInafecta = dataReader["TotalInafecto"].ToString();
                    obj.TotalExonerada = dataReader["TotalExonerado"].ToString();
                    obj.TotalGratuita = dataReader["TotalGratuito"].ToString();
                    obj.TotalOtrosCargos = dataReader["TotalOtrosCargos"].ToString();
                    obj.TipoPercepcion = dataReader["PercepcionTipo"].ToString();
                    obj.BaseImponiblePercepcion = dataReader["PercepcionBaseImponible"].ToString();
                    obj.TotalPercepcion = dataReader["PercepcionTotal"].ToString();
                    obj.TotalIncluidoPercepcion = dataReader["TotalIncluidoPercepcion"].ToString();
                    obj.Detraccion = dataReader["Detraccion"].ToString();
                    obj.Observacion = dataReader["Observacion"].ToString();
                    obj.TipoDocumentoRef = dataReader["TipoDocRef"].ToString();
                    obj.SerieRef = dataReader["SerieRef"].ToString();
                    obj.NumeroRef = dataReader["NumeroRef"].ToString().Trim().PadLeft(8, '0');
                    if (obj.TipoDocumento=="3")
                    {
                        obj.TipoNotaCredito = "1";
                    }
                   
                    obj.TipoNotaDebito = dataReader["TipoNotaDebito"].ToString();
                    obj.FormaPago = dataReader["FormaPago"].ToString();
                    obj.MedioPago = dataReader["MedioPago"].ToString();
                    obj.PlacaVehiculo = dataReader["PlacaVehiculo"].ToString();
                    obj.OrdenServicio = dataReader["OrdenServicio"].ToString();
                }
            }

            return obj;
        }
        public List<DocumentoElectronicoDet> getDocumentoElectronicoDet(String serie, String numero, String codent)
        {
            DateTime daux, daux2;
            List<DocumentoElectronicoDet> objLista = new List<DocumentoElectronicoDet>();
            DocumentoElectronicoDet obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentoElectronicoDet",
                   new object[] { serie, numero, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoElectronicoDet();
                    obj.UnidadMedida = dataReader["UnidadMedida"].ToString();
                    obj.ProductoCodigo = dataReader["CodigoProducto"].ToString().Trim();
                    obj.ProductoDescripcion = dataReader["DescripcionProducto"].ToString().Trim();
                    obj.Cantidad = dataReader["Cantidad"].ToString();
                    obj.ValorUnitario = dataReader["ValorUnitario"].ToString();
                    obj.PrecioUnitario = dataReader["PrecioUnitario"].ToString();
                    obj.Subtotal = dataReader["SubTotal"].ToString();
                    obj.TipoIgv = dataReader["TipoIgv"].ToString();
                    obj.TotalIgvLinea = dataReader["TotalIgvLinea"].ToString();
                    obj.TotalLinea = dataReader["TotalLinea"].ToString();
                    obj.Anticipo = dataReader["Anticipo"].ToString();
                    objLista.Add(obj);
                }
            }

            return objLista;
        }

        public bool updateEstadoEnviado(String serie, String numero)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UpdateEnviado",
                   new object[] { serie, numero });
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
        public bool updateEstadoAceptado(String serie, String numero)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UpdateAceptado",
                   new object[] { serie, numero });
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
        public bool updateEstadoAnulado(String serie, String numero)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UpdateAnulado",
                   new object[] { serie, numero });
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

        public bool updateObservacionSunat(String serie, String numero, String obser)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertObservacionSunat",
                   new object[] { serie, numero, obser });
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
        public List<MotivoAnulacion> getMotivoAnulacion()
        {
            DateTime daux, daux2;
            List<MotivoAnulacion> objLista = new List<MotivoAnulacion>();
            MotivoAnulacion obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_motivoanulacion");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new MotivoAnulacion();
                    obj.Id = Convert.ToInt32(dataReader["id"].ToString());
                    obj.Descripcion = dataReader["Descripcion"].ToString().Trim();
                    objLista.Add(obj);
                }
            }

            return objLista;
        }

        public String referenciaGIrador(String serie, String num)
        {
            String enLetras = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getReferenciaGirador", new object[] { serie, num });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = dataReader["referencia"].ToString();
                }
            }
            return enLetras;
        }
        public String getSunatObs(String serie, String num)
        {
            String enLetras = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getSunatObservacion", new object[] { serie, num });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = dataReader["ObservacionSunat"].ToString();
                }
            }
            return enLetras;
        }
        public bool updateCabecera(DocumentoCab obj)
        {

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_UpdateCabDoc",
                   new object[] { obj.DocumentoCabSerie, obj.DocumentoCabNro, obj.DocumentoCabTipoDoc
                       , obj.DocumentoCabFecha, obj.DocumentoCabTipoMoneda, obj.DocumentoCabTotalSinIGV ,
                   obj.DocumentoCabIGV, obj.DocumentoCabTotal, obj.DocumentoCabTipoPago, obj.DocumentoCabUsuAdd, obj.DocumentoCabGlosa,
                   obj.DocumentoCabTipoNotaCredito, obj.DocumentoCabTipoNotaDebito,obj.DocumentoCabFechaVcto,
                       obj.DocumentoCabSerieRef, obj.DocumentoCabNroRef , obj.DocumentoCabTipoDocRef,
                       obj.DocumentoCabDetraccion,obj.DocumentoCabDetraccionPorcentaje, obj.DocumentoCabGuia, obj.DocumentoCabOrdenCompra
                   });
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
        public bool updateDetalle(DocumentoDet obj)
        {
            OtDAO otDao = new OtDAO();

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("updateDetalle",
                   new object[] { obj.DocumentoCabNro, obj.ProductoCod,obj.CCostosCod, obj.DocumentoDetCantidad,
                       obj.DocumentoDetPrecioSinIGV, obj.DocumentoDetIGV, obj.DocumentoDetSubTotal, obj.DocumentoDetUsuAdd,
                       obj.DocumentoDetGlosa, obj.DocumentoProdUMCod, obj.DocumentoCabSerie,obj.DocumentoDetId, obj.DocumentoDesProducto
                   });
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

        public List<PendienteFacturar> pendienteFacturarG(String anho)
        {
            DateTime daux;
            List<PendienteFacturar> objLista = new List<PendienteFacturar>();
            PendienteFacturar obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_pendienteFacturarG",
                   new object[] { anho });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new PendienteFacturar();
                    obj.Cliente = dataReader["Razon"].ToString().Trim();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.Importe = convertToDouble(dataReader["ImpOt"].ToString());
                    obj.Facturado = convertToDouble(dataReader["facturado"].ToString());
                    obj.Documentos = dataReader["Documentos"].ToString().Trim();
                    if (String.IsNullOrEmpty(obj.Documentos))
                    {
                        obj.Documentos = "-";
                    }
                    obj.Saldo = convertToDouble(dataReader["saldo"].ToString());
                    string aux2 = dataReader["FecOt"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        daux = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        daux = new DateTime(2000, 1, 1);
                    }
                    obj.FechaOt = daux.ToShortDateString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<PendienteFacturar> pendienteFacturarM(String anho)
        {
            DateTime daux;
            List<PendienteFacturar> objLista = new List<PendienteFacturar>();
            PendienteFacturar obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_pendienteFacturarM",
                   new object[] { anho });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new PendienteFacturar();
                    obj.Cliente = dataReader["Razon"].ToString().Trim();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.Importe = convertToDouble(dataReader["ImpOt"].ToString());
                    obj.Facturado = convertToDouble(dataReader["facturado"].ToString());
                    obj.Saldo = convertToDouble(dataReader["saldo"].ToString());
                    obj.Documentos = dataReader["Documentos"].ToString().Trim();
                    if (String.IsNullOrEmpty(obj.Documentos))
                    {
                        obj.Documentos = "-";
                    }
                    string aux2 = dataReader["FecOt"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        daux = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        daux = new DateTime(2000, 1, 1);
                    }
                    obj.FechaOt = daux.ToShortDateString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<PendienteFacturar> reportPorOtM(String anho)
        {
            DateTime daux;
            List<PendienteFacturar> objLista = new List<PendienteFacturar>();
            PendienteFacturar obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reportOtM",
                   new object[] { anho });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new PendienteFacturar();
                    obj.Cliente = dataReader["Razon"].ToString().Trim();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.Importe = convertToDouble(dataReader["ImpOt"].ToString());
                    obj.Facturado = convertToDouble(dataReader["facturado"].ToString());
                    obj.Saldo = convertToDouble(dataReader["saldo"].ToString());
                   // obj.Documentos = dataReader["Documentos"].ToString().Trim();
                    string aux2 = dataReader["FecOt"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        daux = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        daux = new DateTime(2000, 1, 1);
                    }
                    obj.FechaOt = daux.ToShortDateString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<PendienteFacturar> reportPorOtG(String anho)
        {
            DateTime daux;
            List<PendienteFacturar> objLista = new List<PendienteFacturar>();
            PendienteFacturar obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reportOtG",
                   new object[] { anho });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new PendienteFacturar();
                    obj.Cliente = dataReader["Razon"].ToString().Trim();
                    obj.NroOt = dataReader["NroOt"].ToString();
                    obj.Importe = convertToDouble(dataReader["ImpOt"].ToString());
                    obj.Facturado = convertToDouble(dataReader["facturado"].ToString());
                    obj.Saldo = convertToDouble(dataReader["saldo"].ToString());
                    string aux2 = dataReader["FecOt"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        daux = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        daux = new DateTime(2000, 1, 1);
                    }
                    //obj.Documentos = dataReader["Documentos"].ToString().Trim();
                    obj.FechaOt = daux.ToShortDateString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DetalleReporte> listarDetalleReportPorOtG(String anho)
        {
            List<DetalleReporte> objLista = new List<DetalleReporte>();
            DetalleReporte obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reportOtG_Detalle",
                   new object[] { anho });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DetalleReporte();

                    obj.Serie = dataReader["Serie"].ToString().Trim();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.Subtotal= convertToDouble(dataReader["Subtotal"].ToString());
                    obj.Igv = convertToDouble(dataReader["Igv"].ToString());
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    obj.NroOt = dataReader["NroOt"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DetalleReporte> listarDetalleReportPorOtM(String anho)
        {
            List<DetalleReporte> objLista = new List<DetalleReporte>();
            DetalleReporte obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_reportOtM_Detalle",
                   new object[] { anho });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DetalleReporte();

                    obj.Serie = dataReader["Serie"].ToString().Trim();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.Subtotal = convertToDouble(dataReader["Subtotal"].ToString());
                    obj.Igv = convertToDouble(dataReader["Igv"].ToString());
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    obj.NroOt = dataReader["NroOt"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<DocumentoCab> listarFacturasPorOt(String nroOt, String codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_facturasxOT",
                   new object[] { nroOt, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();

                    obj.DocumentoCabSerie = dataReader["Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["Numero"].ToString();
                    obj.DocumentoCabTotal = convertToDouble(dataReader["Total"].ToString());
                    obj.DocumentoCabTipoMoneda = dataReader["Moneda"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public bool anularLetra(String serie, String num)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_anularLetra",
                   new object[] { serie,num
                   });
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

        public List<DocumentoCab> listarDocumentosPorConsultar(String TipDoc, String codent)
        {
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getDocumentosNoConsultados",
                   new object[] { TipDoc, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabSerie = dataReader["Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["Numero"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
    }
}
