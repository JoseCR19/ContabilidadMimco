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
    public class PagoDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<DocumentoPagoCab> buscarPago(String ruc, String codent)
        {
            String aux = "";
            List<DocumentoPagoCab> objLista = new List<DocumentoPagoCab>();
            DocumentoPagoCab obj;
             Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_buscarVoucher",
                   new object[] { ruc, codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoPagoCab();
                    obj.DocumentoPagoCabNroVoucher =  dataReader["Número Voucher"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }
        public List<DocumentoPagoDet> buscarDocus(String voucher)
        {
            String aux = "";
            String auxMoneda = "";
            Double tcambio = 0;
            List<DocumentoPagoDet> objLista = new List<DocumentoPagoDet>();
            DocumentoPagoDet obj;
            MonedaDAO objdao = new MonedaDAO();
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_buscarPago",
                   new object[] { voucher });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new DocumentoPagoDet();
                    obj.DocumentoPagoDetSerieRef = dataReader["seriedocref"].ToString();
                    obj.DocumentoPagoDetNroDocRef = dataReader["nrodocref"].ToString();
                    string aux3 = dataReader["FecRep"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.DocumentoPagoDetFecha = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.DocumentoPagoDetFecha = new DateTime(2000, 1, 1);
                    }
                    obj.DocumentoPagoDetTipoDocumentoCod = dataReader["tipodocref"].ToString();
                    switch (obj.DocumentoPagoDetTipoDocumentoCod)
                    {
                        case "BL":
                            obj.DocumentoPagoDetTipoDocumento = "Boleta Electrónica";
                            obj.DocumentoPagoDetTipoDocumentoCod = "03";
                            break;
                        case "FV":
                            obj.DocumentoPagoDetTipoDocumento = "Factura Electrónica";
                            obj.DocumentoPagoDetTipoDocumentoCod = "01";
                            break;
                        case "LT":
                            obj.DocumentoPagoDetTipoDocumento = "Letra de Cambio";
                        
                            break;
                        case "NC":
                            obj.DocumentoPagoDetTipoDocumento = "Nota de Crédito";
                            obj.DocumentoPagoDetTipoDocumentoCod = "07";
                            break;

                    }
                    auxMoneda = dataReader["MO"].ToString();
                    if (auxMoneda == "3")
                    {
                        obj.DocumentoPagoDetCodMoneda = "USD";

                    }else if(auxMoneda == "2")
                    {
                        obj.DocumentoPagoDetCodMoneda = "PEN";
                    }
                  
                    obj.DocumentoPagoDetNroVoucher = dataReader["NroVoucher"].ToString();
                    obj.DocumentoPagoDetId = Convert.ToInt32(dataReader["item"].ToString());
                    obj.DocumentoPagoDetDescripcion = dataReader["Despago"].ToString();
                    obj.DocumentoPagoDetRuc = dataReader["Nea"].ToString();
                    obj.DocumentoPagoDetCodOT = dataReader["codot"].ToString();
                    tcambio = objdao.getTipoCambioVenta(DateTime.Now.ToShortDateString());
                    if (obj.DocumentoPagoDetCodMoneda == "USD")
                    {
                        obj.DocumentoPagoDetPagoDolar = convertToDouble(dataReader["impPdet"].ToString());
                        obj.DocumentoPagoDetPago = Math.Round(tcambio * obj.DocumentoPagoDetPagoDolar,2);
                        obj.DocumentoPagoDetRetencion = Math.Round( obj.DocumentoPagoDetPago * 0.03,2);
                        obj.DocumentoPagoDetRetencionDolar = Math.Round(obj.DocumentoPagoDetPagoDolar * 0.03, 2);
                    }else if (obj.DocumentoPagoDetCodMoneda == "PEN")
                    {
                        obj.DocumentoPagoDetPago = convertToDouble(dataReader["impPdet"].ToString());
                        obj.DocumentoPagoDetPagoDolar = Math.Round(obj.DocumentoPagoDetPago/tcambio, 2);
                        obj.DocumentoPagoDetRetencion = Math.Round(obj.DocumentoPagoDetPago * 0.03, 2);
                        obj.DocumentoPagoDetRetencionDolar = Math.Round(obj.DocumentoPagoDetPagoDolar * 0.03, 2);
                    }
                   
                    
                    
                    
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
