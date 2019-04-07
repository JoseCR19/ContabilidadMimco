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
    public class ProductoDAO
    {
        Conexion _Conexion = new Conexion("Conta");

        public List<Producto> listarProducto(String UnidadNegocio)
        {
            List<Producto> objList = new List<Producto>();
            Producto obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_Producto",
                   new object[] { UnidadNegocio });
            char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];

            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Producto();
                    obj.ProductoCod = dataReader["Prod_Codigo"].ToString();
                    obj.ProductoDescripcion = dataReader["Prod_Descripcion"].ToString();
                    obj.ProductoCContableCuenta = dataReader["Prod_CuentaContableCuenta"].ToString();
                    try
                    {
                        String d = dataReader["Prod_Precio"].ToString();
                        if (!d.Contains(","))
                            obj.ProductoPrecio = double.Parse(d, CultureInfo.InvariantCulture);
                        else
                            obj.ProductoPrecio = Convert.ToDouble(d.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
                    }
                    catch (Exception ex1)
                    {
                        obj.ProductoPrecio = 0;
                    }
                    obj.ProductoUnidadMedida = dataReader["UM_Descr"].ToString();
                    string aux = dataReader["Prod_FechAdd"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.ProductoFechaAdd = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.ProductoFechaAdd = new DateTime();
                    }

                    obj.ProductoUnidadMedidaCod = dataReader["Prod_UniMedida"].ToString();
                    obj.ProductoUnidadMedidaCorta = dataReader["UM_Corta"].ToString();
                    obj.ProductoUnidadMedidaSunat = dataReader["UM_Sunat"].ToString();
                    objList.Add(obj);


                }
            }
            return objList;
        }
    }
}
