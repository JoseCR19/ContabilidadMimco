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
    /*dentro del procedimiento almacenada se encuentra la opción donde si se coloca 1 se muestran solo los asientos guardados
     pero si se coloca 0 se mostraran todas las facturas*/
    public class VentasDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public List<Ventas> listarLibroVentas( String periodo, String ultDia)
        {
            DateTime d1;
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroVentas",
                   new object[] {  periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();

                    obj.VentasId = dataReader["Correlativo"].ToString();
                    obj.FechaEmision = dataReader["FechaEmision"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipoDocumento = dataReader["Tipo"].ToString();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.TipoDocIdentidad = dataReader["TipoDoc"].ToString();
                    obj.Ruc = dataReader["RUC"].ToString().TrimEnd();
                    obj.RazonSocial = dataReader["Razon"].ToString().TrimEnd().TrimStart();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    String aux = dataReader["Exportacion"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Exportacion = 0;
                    }else
                    {
                        obj.Exportacion = convertToDouble(aux);
                    }
                    aux = dataReader["Gravada"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Gravado = 0;
                    }
                    else
                    {
                        obj.Gravado = convertToDouble(aux);
                    }
                    aux = dataReader["Exonerada"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Exonerado = 0;
                    }
                    else
                    {
                        obj.Exonerado = convertToDouble(aux);
                    }
                    aux = dataReader["Inafecta"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Inafecta = 0;
                    }
                    else
                    {
                        obj.Inafecta = convertToDouble(aux);
                    }
                    aux = dataReader["ISC"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.ISC = 0;
                    }
                    else
                    {
                        obj.ISC = convertToDouble(aux);
                    }
                    aux = dataReader["IGV"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.IGV = 0;
                    }
                    else
                    {
                        obj.IGV = convertToDouble(aux);
                    }
                    aux = dataReader["OtrosTributos"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.OtrosTributos = 0;
                    }
                    else
                    {
                        obj.OtrosTributos = convertToDouble(aux);
                    }
                    aux = dataReader["Total"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Total = 0;
                    }
                    else
                    {
                        obj.Total = convertToDouble(aux);
                    }

                    obj.Moneda = dataReader["Moneda"].ToString();

                    aux = dataReader["TipoCambio"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.TipoCambio = 0;
                    }
                    else
                    {
                        obj.TipoCambio = convertToDouble(aux);

                    }
                    obj.FechaEmisionRef = dataReader["FechaRef"].ToString();
                    if(String.IsNullOrEmpty(obj.FechaEmisionRef))
                    {
                        obj.FechaEmisionRef = " ";
                    }
                    obj.TipoDocumentoRef = dataReader["TipoRef"].ToString();
                    if (String.IsNullOrEmpty(obj.TipoDocumentoRef))
                    {
                        obj.TipoDocumentoRef = " ";
                    }
                    obj.SerieRef = dataReader["SerieRef"].ToString();
                    if (String.IsNullOrEmpty(obj.SerieRef))
                    {
                        obj.SerieRef = " ";
                    }
                    obj.NumeroRef = dataReader["NroRef"].ToString();
                    if (String.IsNullOrEmpty(obj.NumeroRef))
                    {
                        obj.NumeroRef = " ";
                    }
                    obj.TasaIGV = convertToDouble( dataReader["TasaIGV"].ToString());
                    objList.Add(obj);

                }
            }
            return objList;
        }

        public List<Ventas> listarLibroVentasxsoles(String periodo, String ultDia)
        {
            DateTime d1;
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroVentasxsoles",
                   new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();

                    obj.VentasId = dataReader["Correlativo"].ToString();
                    obj.FechaEmision = dataReader["FechaEmision"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipoDocumento = dataReader["Tipo"].ToString();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.TipoDocIdentidad = dataReader["TipoDoc"].ToString();
                    obj.Ruc = dataReader["RUC"].ToString().TrimEnd();
                    obj.RazonSocial = dataReader["Razon"].ToString().TrimEnd().TrimStart();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    String aux = dataReader["Exportacion"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Exportacion = 0;
                    }
                    else
                    {
                        obj.Exportacion = convertToDouble(aux);
                    }
                    aux = dataReader["Gravada"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Gravado = 0;
                    }
                    else
                    {
                        obj.Gravado = convertToDouble(aux);
                    }
                    aux = dataReader["Exonerada"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Exonerado = 0;
                    }
                    else
                    {
                        obj.Exonerado = convertToDouble(aux);
                    }
                    aux = dataReader["Inafecta"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Inafecta = 0;
                    }
                    else
                    {
                        obj.Inafecta = convertToDouble(aux);
                    }
                    aux = dataReader["ISC"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.ISC = 0;
                    }
                    else
                    {
                        obj.ISC = convertToDouble(aux);
                    }
                    aux = dataReader["IGV"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.IGV = 0;
                    }
                    else
                    {
                        obj.IGV = convertToDouble(aux);
                    }
                    aux = dataReader["OtrosTributos"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.OtrosTributos = 0;
                    }
                    else
                    {
                        obj.OtrosTributos = convertToDouble(aux);
                    }
                    aux = dataReader["Total"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Total = 0;
                    }
                    else
                    {
                        obj.Total = convertToDouble(aux);
                    }

                    obj.Moneda = dataReader["Moneda"].ToString();
                    aux = dataReader["TipoCambio"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.TipoCambio = 0;
                    }
                    else
                    {
                        obj.TipoCambio = convertToDouble(aux);
                    }
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
                    objList.Add(obj);

                }
            }
            return objList;
        }
        public List<Ventas> listarLibroVentasxdolares(String periodo, String ultDia)
        {
            DateTime d1;
            List<Ventas> objList = new List<Ventas>();
            Ventas obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroVentasxdolares",
                   new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Ventas();

                    obj.VentasId = dataReader["Correlativo"].ToString();
                    obj.FechaEmision = dataReader["FechaEmision"].ToString();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    obj.TipoDocumento = dataReader["Tipo"].ToString();
                    obj.Serie = dataReader["Serie"].ToString();
                    obj.Numero = dataReader["Numero"].ToString();
                    obj.TipoDocIdentidad = dataReader["TipoDoc"].ToString();
                    obj.Ruc = dataReader["RUC"].ToString().TrimEnd();
                    obj.RazonSocial = dataReader["Razon"].ToString().TrimEnd().TrimStart();
                    obj.FechaVcto = dataReader["FechaVcto"].ToString();
                    String aux = dataReader["Exportacion"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Exportacion = 0;
                    }
                    else
                    {
                        obj.Exportacion = convertToDouble(aux);
                    }
                    aux = dataReader["Gravada"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Gravado = 0;
                    }
                    else
                    {
                        obj.Gravado = convertToDouble(aux);
                    }
                    aux = dataReader["Exonerada"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Exonerado = 0;
                    }
                    else
                    {
                        obj.Exonerado = convertToDouble(aux);
                    }
                    aux = dataReader["Inafecta"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Inafecta = 0;
                    }
                    else
                    {
                        obj.Inafecta = convertToDouble(aux);
                    }
                    aux = dataReader["ISC"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.ISC = 0;
                    }
                    else
                    {
                        obj.ISC = convertToDouble(aux);
                    }
                    aux = dataReader["IGV"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.IGV = 0;
                    }
                    else
                    {
                        obj.IGV = convertToDouble(aux);
                    }
                    aux = dataReader["OtrosTributos"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.OtrosTributos = 0;
                    }
                    else
                    {
                        obj.OtrosTributos = convertToDouble(aux);
                    }
                    aux = dataReader["Total"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.Total = 0;
                    }
                    else
                    {
                        obj.Total = convertToDouble(aux);
                    }

                    obj.Moneda = dataReader["Moneda"].ToString();
                    aux = dataReader["TipoCambio"].ToString();
                    if (String.IsNullOrEmpty(aux))
                    {
                        obj.TipoCambio = 0;
                    }
                    else
                    {
                        obj.TipoCambio = convertToDouble(aux);
                    }
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
                    objList.Add(obj);

                }
            }
            return objList;
        }
        //primera funcion sin destinguir moneda 
        public List<String> generarTxtVentas( String periodo, String ultDia)
        {
            String enLetras = "";
            List<String> txt = new List<String>();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroVentasTxT", new object[] {  periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = "";
                    enLetras = dataReader["letras"].ToString();
                    txt.Add(enLetras);
                }
            }
            return txt;
        }
        //funcion para generar el txt solo con soles
        public List<String> generarTxtVentasSoles(String periodo, String ultDia)
        {
            String enLetras = "";
            List<String> txt = new List<String>();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroVentasTxTxSoles", new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = "";
                    enLetras = dataReader["letras"].ToString();
                    txt.Add(enLetras);
                }
            }
            return txt;
        }
        //funcion para generar el txt solo con dolares
        public List<String> generarTxtVentasDolares(String periodo, String ultDia)
        {
            String enLetras = "";
            List<String> txt = new List<String>();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getRegistroVentasTxTxDolares", new object[] { periodo, ultDia });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = "";
                    enLetras = dataReader["letras"].ToString();
                    txt.Add(enLetras);
                }
            }
            return txt;
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
