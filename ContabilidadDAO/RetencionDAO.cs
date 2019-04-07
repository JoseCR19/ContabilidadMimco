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
   public class RetencionDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public String correlativoRetencion(string codent, string serie)
        {
            String enLetras = "";
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_CorrelativoRetencion",
                   new object[] {  codent, serie });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    enLetras = dataReader["correlativo"].ToString();
                }
            }
            return enLetras;
        }

        public bool insertarCabecera(RetencionCab obj, String codent)
        {

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertRetencionCab",
                   new object[] { obj.RetencionCab_Serie, obj.RetencionCab_Numero, obj.RetencionCab_Fecha,
                       obj.RetencionCab_RucProv, codent, obj.RetencionCab_CodOt,obj.RetencionCab_Monto, obj.RetencionCab_Retencion ,
                   obj.RetencionCab_Observacion,obj.RetencionCab_MontoDolar,obj.RetencionCab_RetencionDolar, obj.RetencionCab_CodMoneda
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

        public bool insertarDetalle(RetencionDet obj)
        {

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertRetencionDet",
                   new object[] { obj.RetencionDet_Serie, obj.RetencionDet_Numero, obj.RetencionDet_MontoSoles,
                       obj.RetencionDet_MontoDolares,  obj.RetencionDet_RetencionSoles,obj.RetencionDet_RetencionDolares,
                       obj.RetencionDet_TipoDocRef , obj.RetencionDet_SerieRef, obj.RetencionDet_NumeroRef,obj.RetencionDet_Voucher,
                         obj.RetencionDet_FechaRef
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
        public List<RetencionCab> listarRetencion(DateTime d1, DateTime d2, String Ruc, String codent)
        {
            List<RetencionCab> objLista = new List<RetencionCab>();
            RetencionCab obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarRetencionCab",
                   new object[] { d1, d2, Ruc,  codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new RetencionCab();
                    obj.RetencionCab_CodOt= dataReader["RetencionCab_CodOt"].ToString();
                    string aux3 = dataReader["RetencionCab_Fecha"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.RetencionCab_Fecha = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.RetencionCab_Fecha = new DateTime(2000, 1, 1);
                    }
                    obj.RetencionCab_Monto = convertToDouble(dataReader["RetencionCab_Monto"].ToString());
                    obj.RetencionCab_Numero = dataReader["RetencionCab_Numero"].ToString();
                    obj.RetencionCab_Observacion = dataReader["RetencionCab_Observacion"].ToString();
                    obj.RetencionCab_Retencion = convertToDouble( dataReader["RetencionCab_Retencion"].ToString());
                    obj.RetencionCab_RucProv = dataReader["RetencionCab_RucProv"].ToString();
                    obj.RetencionCab_Serie = dataReader["RetencionCab_Serie"].ToString();
                    obj.RetencionCab_Proveedor = dataReader["nomprov"].ToString();
                    obj.RetencionCab_CodMoneda = dataReader["RetencionCab_Moneda"].ToString();
                    obj.RetencionCab_MontoDolar = convertToDouble(dataReader["RetencionCab_MontoDolar"].ToString());
                    obj.RetencionCab_RetencionDolar = convertToDouble(dataReader["RetencionCab_RetencionDolar"].ToString());
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

        public List<RetencionDet> listarRetencionDet( String serie, String nro)
        {
            List<RetencionDet> objLista = new List<RetencionDet>();
            RetencionDet obj;

            try { 
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarRetencionDet",
                   new object[] { serie, nro });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new RetencionDet();
                    obj.RetencionDet_Serie = dataReader["RetencionDet_Serie"].ToString();
                    obj.RetencionDet_Numero = dataReader["RetencionDet_Numero"].ToString();
                    obj.RetencionDet_Id = Convert.ToInt32( dataReader["RetencionDet_Numero"].ToString());

                    string aux3 = dataReader["RetencionDet_FechaRef"].ToString();
                    if (!String.IsNullOrEmpty(aux3))
                    {
                        obj.RetencionDet_FechaRef = Convert.ToDateTime(Convert.ToDateTime(aux3).ToShortDateString());
                    }
                    else
                    {
                        obj.RetencionDet_FechaRef = new DateTime(2000, 1, 1);
                    }
                    obj.RetencionDet_MontoDolares= convertToDouble(dataReader["RetencionDet_MontoDolares"].ToString());
                    obj.RetencionDet_MontoSoles = convertToDouble(dataReader["RetencionDet_MontoSoles"].ToString());
                    obj.RetencionDet_NumeroRef = dataReader["RetencionDet_NumeroRef"].ToString();
                    obj.RetencionDet_RetencionDolares = convertToDouble(dataReader["RetencionDet_RetencionDolares"].ToString());
                    obj.RetencionDet_RetencionSoles = convertToDouble(dataReader["RetencionDet_RetencionSoles"].ToString());
                    obj.RetencionDet_SerieRef = dataReader["RetencionDet_SerieRef"].ToString();
                    obj.RetencionDet_TipoDocRef = dataReader["RetencionDet_TipoDocRef"].ToString();
                    obj.RetencionDet_Voucher= dataReader["RetencionDet_Voucher"].ToString();

             
                    switch (obj.RetencionDet_TipoDocRef)
                    {
                        case "03":
                            obj.RetencionDet_TipoDocumentoRef = "Boleta Electrónica";
                            
                            break;
                        case "01":
                            obj.RetencionDet_TipoDocumentoRef = "Factura Electrónica";
                           
                            break;
                        case "LT":
                            obj.RetencionDet_TipoDocumentoRef = "Letra de Cambio";

                            break;
                        case "07":
                            obj.RetencionDet_TipoDocumentoRef = "Nota de Crédito";
                          
                            break;

                    }

                    objLista.Add(obj);
                }

            }
            }
            catch (Exception ex)
            {

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
