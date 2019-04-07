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
    public class LoVDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<TipoGastos> getLovTipoGastos()
        {
            List<TipoGastos> objList = new List<TipoGastos>();
            TipoGastos obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_lovTipoGastos");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoGastos();
                    obj.Codigo = dataReader["Codigo"].ToString().Trim();
                    obj.CuentaContable = dataReader["CuentaContable"].ToString().Trim();
                    obj.Descripcion = dataReader["Descripcion"].ToString().Trim().ToUpper();
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<OtDTO> getLovOt(String CodEnt)
        {
            List<OtDTO> objList = new List<OtDTO>();
            OtDTO obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_lovOt",
                   new object[] { CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new OtDTO();
                    obj.NumeroOt = dataReader["NroOt"].ToString().Trim();
                    obj.CodigoOt = dataReader["codot"].ToString().Trim();
                    obj.Descripcion = dataReader["desot"].ToString().Trim().ToUpper();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<OtDTO> getLovOtSite(String CodEnt)
        {
            List<OtDTO> objList = new List<OtDTO>();
            OtDTO obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_lovOtSite",
                   new object[] { CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new OtDTO();
                    obj.NumeroOt = dataReader["NroOt"].ToString().Trim();
                    obj.CodigoOt = dataReader["codot"].ToString().Trim();
                    obj.DirOt = dataReader["DesOt"].ToString().Trim().ToUpper();
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Cliente> getLovCliente(String UnidadNegocio)
        {
            List<Cliente> objList = new List<Cliente>();
            Cliente obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_listarCliente",
                   new object[] { UnidadNegocio });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Cliente();
                    obj.ClienteNDoc = dataReader["Cli_NDocumento"].ToString().TrimEnd();
                    obj.ClienteRazonSocial = dataReader["Cli_RazonSocial"].ToString().TrimEnd();
                    obj.ClienteRazonSocial = obj.ClienteRazonSocial.TrimStart();
                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<CuentaBanco> getLovBanco(String codent)
        {
            List<CuentaBanco> objLista = new List<CuentaBanco>();
            CuentaBanco objCuentaBanco;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_LovBanco",
                   new object[] { codent});
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    objCuentaBanco = new CuentaBanco();
                    objCuentaBanco.Codigo = dataReader["Codigo"].ToString();
                    objCuentaBanco.Cuenta = dataReader["NumCuenta"].ToString();
                    objCuentaBanco.CuentaContable = dataReader["CtaContable"].ToString();
                    objCuentaBanco.Descripcion = dataReader["Descripcion"].ToString();
                    objCuentaBanco.MonedaCod = dataReader["Moneda"].ToString();
                    if (objCuentaBanco.MonedaCod == "PEN")
                    {
                        objCuentaBanco.Moneda = "Soles";
                    }
                    else
                    {
                        objCuentaBanco.Moneda = "Dólares Americanos";
                    }
                    objLista.Add(objCuentaBanco);
                }
            }
            return objLista;
        }

        public List<CuentaBanco> getLovBancoSolicita(String codent)
        {
            List<CuentaBanco> objLista = new List<CuentaBanco>();
            CuentaBanco objCuentaBanco;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_LovBancoSolicita",
                   new object[] { codent });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    objCuentaBanco = new CuentaBanco();
                    objCuentaBanco.Codigo = dataReader["Codigo"].ToString();
                    objCuentaBanco.Descripcion = dataReader["Descripcion"].ToString();
                    objLista.Add(objCuentaBanco);
                }
            }
            return objLista;
        }
        public List<Proveedor> getLovProveedor(String CodEnt)
        {
            List<Proveedor> objList = new List<Proveedor>();
            Proveedor obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_lovProveedor",
                   new object[] { CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Proveedor();
                    obj.ProveedorRazonSocial = dataReader["nomprov"].ToString().Trim().ToUpper();
                    obj.ProveedorNDoc = dataReader["rucprov"].ToString().Trim();
           
                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Proveedor> getLovProveedorTotal(String CodEnt)
        {
            List<Proveedor> objList = new List<Proveedor>();
            Proveedor obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_lovProveedorTotal",
                   new object[] { CodEnt });
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Proveedor();
                    obj.ProveedorRazonSocial = dataReader["nomprov"].ToString().Trim();
                    obj.ProveedorNDoc = dataReader["rucprov"].ToString().Trim().ToUpper();
                    obj.ProveedorTipo = dataReader["tipo"].ToString().Trim();

                    objList.Add(obj);
                }
            }
            return objList;
        }
        public List<Personal> getLovPersonal()
        {
            List<Personal> objList = new List<Personal>();
            Personal obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_lovPersonal");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new Personal();
                    obj.NroDocumento = dataReader["DNI"].ToString().Trim();
                    obj.Nombre = dataReader["Nombres"].ToString().Trim().ToUpper();

                    objList.Add(obj);


                }
            }
            return objList;
        }
        public List<TipoPagoVoucher> getLovTipoPagoVoucher()
        {
            List<TipoPagoVoucher> objLista = new List<TipoPagoVoucher>();
            TipoPagoVoucher obj;
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_LovTipoPagoVoucher");
            using (IDataReader dataReader = db.ExecuteReader(dbCommand))
            {
                while (dataReader.Read())
                {
                    obj = new TipoPagoVoucher();
                    obj.Codigo = dataReader["Codigo"].ToString();
                    obj.Descripcion = dataReader["Descripcion"].ToString();
                    objLista.Add(obj);
                }
            }
            return objLista;
        }

    }
}
