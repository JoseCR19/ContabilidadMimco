using ContaDTO;
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


namespace ContaDAO
{
    public class DocumentoDAO
    {
        public List<DocumentoCab> listarDocCabAsientos(String tipodocu, String codent)
        {
            Conexion _Conexion = new Conexion("Contabilidad");
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_buscarDocumentoAsiento",
                   new object[] {  tipodocu, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["Cli_RazonSocial"].ToString().Trim();
                    obj.DocumentoCabSerie = dataReader["DOCcab_Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["DOCcab_Codigo"].ToString();
                    obj.DocumentoCabMoneda = dataReader["Mon_Descripcion"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["Cli_NDocumento"].ToString().Trim();
                    obj.DocumentoCabUsuAdd = dataReader["DOCcab_UsuAdd"].ToString();
                    obj.DocumentoCabDetraccionPorcentaje = convertToDouble(dataReader["DOCcab_DetraccionPorcentaje"].ToString());
                    obj.DocumentoCabDetraccion = convertToDouble(dataReader["DOCcab_Detraccion"].ToString());
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
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoCab> listarCompraAsientos(String codent)
        {
            Conexion _Conexion = new Conexion("Contabilidad");
            List<DocumentoCab> objLista = new List<DocumentoCab>();
            DocumentoCab obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_GetComprasAsiento",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoCab();
                    obj.DocumentoCabCliente = dataReader["RazonSocial"].ToString().Trim();
                    obj.DocumentoCabSerie = dataReader["Serie"].ToString().Trim();
                    obj.DocumentoCabNro = dataReader["Numero"].ToString();
                    obj.DocumentoCabMoneda = dataReader["MonedaDesc"].ToString();
                    obj.DocumentoCabClienteDocumento = dataReader["RUC"].ToString().Trim();
                    string aux = dataReader["Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.DocumentoCabFecha = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFecha = new DateTime(2000, 1, 1);
                    }

                    string aux2 = dataReader["FechaVcto"].ToString();
                    if (!String.IsNullOrEmpty(aux2))
                    {
                        obj.DocumentoCabFechaVcto = Convert.ToDateTime(Convert.ToDateTime(aux2).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoCabIGV = convertToDouble(dataReader["igv"].ToString());
                    obj.DocumentoCabTotalSinIGV = convertToDouble(dataReader["subtotal"].ToString());
                    obj.DocumentoCabTotal = convertToDouble(dataReader["total"].ToString());
                    obj.DocumentoCabTipoMoneda = dataReader["monedacod"].ToString();
                    obj.DocumentoCabPago = dataReader["TipoPago"].ToString();
                    obj.DocumentoCabTipoPago = Convert.ToInt32(dataReader["TipoPagoCod"].ToString());
                    obj.DocumentoCabTipoDocRef = dataReader["tipDocRef"].ToString();
                    obj.DocumentoCabSerieRef = dataReader["SerieRef"].ToString().Trim();
                    obj.DocumentoCabNroRef = dataReader["NumeroRef"].ToString().Trim();
                    obj.NumeroRegistro = dataReader["numReg"].ToString().Trim();
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


    }
}
