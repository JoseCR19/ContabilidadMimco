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
    public class ComprasDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public List<Compras> listarLibroCompras(String periodo, String ultDia)
        {
            DateTime d1;
            String dolar;
            List<Compras> objList = new List<Compras>();
            Compras obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroCompras",
                   new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Compras();

                    obj.ComprasId = dataReader["Correlativo"].ToString();
                    obj.FechaEmision = dataReader["FechaEmision"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipoDocumento = dataReader["Tipo"].ToString();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.TipoDocIdentidad = dataReader["TipoDoc"].ToString();
                    obj.Ruc = dataReader["RUC"].ToString().TrimEnd();
                    obj.RazonSocial = dataReader["Razon"].ToString().TrimEnd().TrimStart();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.Gravado2 = convertToDouble(dataReader["Gravada2"].ToString());
                    obj.Gravado = convertToDouble(dataReader["Gravada"].ToString());
                    obj.Gravado2Igv = convertToDouble(dataReader["Gravada2Igv"].ToString());
                    obj.NoGravada= convertToDouble(dataReader["NoGravada"].ToString());
                    obj.NoGravadaIgv = convertToDouble(dataReader["NoGravadaIgv"].ToString());
                    obj.ISC = convertToDouble(dataReader["ISC"].ToString());
                    obj.IGV = convertToDouble(dataReader["IGV"].ToString());
                    obj.OtrosTributos = convertToDouble(dataReader["OtrosTributos"].ToString());
                    obj.Total = convertToDouble(dataReader["Total"].ToString());
                    obj.TipoCambio = convertToDouble(dataReader["TipoCambio"].ToString());
                    obj.FechaEmisionRef = dataReader["FechaRef"].ToString();
                    if (String.IsNullOrEmpty(obj.FechaEmisionRef))
                    {
                        obj.FechaEmisionRef = "-";
                    }
                    obj.TipoDocumentoRef = dataReader["TipoRef"].ToString();
                    if (String.IsNullOrEmpty(obj.TipoDocumentoRef))
                    {
                        obj.TipoDocumentoRef = "-";
                    }
                    obj.SerieRef = dataReader["SerieRef"].ToString();
                    if (String.IsNullOrEmpty(obj.SerieRef))
                    {
                        obj.SerieRef = "-";
                    }
                    obj.NumeroRef = dataReader["NroRef"].ToString();
                    if (String.IsNullOrEmpty(obj.NumeroRef))
                    {
                        obj.NumeroRef = "-";
                    }
                    obj.TasaIGV = convertToDouble(dataReader["TasaIGV"].ToString());
                    obj.DSI = dataReader["DSI"].ToString();
                    obj.Reclasificacion = convertToDouble(dataReader["Reclasificacion"].ToString());
                    obj.ComprobanteNoDomiciliado = dataReader["ComprobanteNoDomiciliado"].ToString();
                    obj.ValorNoGravadas =convertToDouble( dataReader["ValorNoGravadas"].ToString());
                    obj.DetraccionNum = dataReader["DetraccionNum"].ToString();
                    obj.DetraccionFecha = dataReader["DetraccionFecha"].ToString();
                    obj.Moneda = dataReader["Moneda"].ToString();

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
        //
        public List<String> generarTxtCompras(String periodo, String ultDia)
        {
            String enLetras = "";
            List<String> txt = new List<String>();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroComprasTxT", new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = "";
                    enLetras = dataReader["Correlativo"].ToString();
                    txt.Add(enLetras);
                }
            }
            return txt;
        }
        //Funcion para generar el txt en soles para compra
        public List<String> generarTxtCompraSoles(String periodo, String ultDia)
        {
            String enLetras = "";
            List<String> txt = new List<String>();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroComprasTxTSoles", new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = "";
                    enLetras = dataReader["Correlativo"].ToString();
                    txt.Add(enLetras);
                }
            }
            return txt;
        }

        public List<String> generarTxtCompraDolares(String periodo, String ultDia)
        {
            String enLetras = "";
            List<String> txt = new List<String>();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroComprasTxTDolares", new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = "";
                    enLetras = dataReader["Correlativo"].ToString();
                    txt.Add(enLetras);
                }
            }
            return txt;
        }
    }
}
