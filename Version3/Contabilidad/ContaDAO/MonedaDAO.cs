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
    public class MonedaDAO
    {
        Conexion _Conexion = new Conexion("Contabilidad");
        public List<Moneda> listarTipoMoneda()
        {
            List<Moneda> objList = new List<Moneda>();
            Moneda obj;
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_TipoMoneda");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Moneda();
                    obj.MonedaDescripcion = dataReader["Mon_Descripcion"].ToString().ToUpper();
                    obj.MonedaCod = dataReader["Mon_Cod"].ToString().ToUpper();
                    objList.Add(obj);


                }
            }
            return objList;
        }

        Boolean insertarTipoCambio(double valor1, double valor2)
        {
            String aux = "";
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_InsertTipoCambio",
                   new object[] { valor1, valor2 });
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

        public double getTipoCambio(String fecha)
        {
            double cambio = 0;
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getTipoCambio", new object[] { fecha });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    String d = dataReader["TCmonto"].ToString();

                    if (!d.Contains(","))
                        cambio = double.Parse(d, CultureInfo.InvariantCulture);
                    else
                        cambio = Convert.ToDouble(d.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));



                }
            }
            return cambio;
        }
        public double getTipoCambioVenta(String fecha)
        {
            double cambio = 0;    
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_getTipoCambioVenta", new object[] { fecha });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    String d = dataReader["TCmontoVenta"].ToString();

                    if (!d.Contains(","))
                        cambio = double.Parse(d, CultureInfo.InvariantCulture);
                    else
                        cambio = Convert.ToDouble(d.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));



                }
            }
            return cambio;
        }
        TipoCambio consultarMaestra()
        {
            TipoCambio objCambio = new TipoCambio();
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_consultarTC");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    objCambio.TCcompra = convertToDouble(dataReader["compra"].ToString());
                    objCambio.TCventa = convertToDouble(dataReader["venta"].ToString());


                }
            }
            return objCambio;
        }

        Boolean consultarTablaTcambio(String fecha)
        {
            String aux = "";
            Database db = DatabaseFactory.CreateDatabase("Contabilidad");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_VerificarTC", new object[] { fecha });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    aux = dataReader["TCmonto"].ToString();

                }
            }

            if (String.IsNullOrEmpty(aux))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void tipoCambio()
        {
            bool tabla = false;
            TipoCambio objTipoCambio = new TipoCambio();
            objTipoCambio = consultarMaestra();
            if (objTipoCambio.TCcompra == 0)
            {
                return;
            }
            else
            {
                tabla = consultarTablaTcambio(DateTime.Now.ToString("dd/MM/yyyy"));
                if (tabla)
                {
                    insertarTipoCambio(objTipoCambio.TCcompra, objTipoCambio.TCventa);
                }
                else
                {
                    return;
                }
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
