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
    public class ClienteDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public List<Cliente> listarCliente(String UnidadNegocio)
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
                    
                    obj.ClienteCod = dataReader["Cli_Codigo"].ToString();
                    obj.ClienteContacto = dataReader["Cli_Contacto"].ToString();
                    obj.ClienteDireccion = dataReader["Cli_Direccion"].ToString().Trim();
                    string aux = dataReader["Cli_FechaAdd"].ToString();
                    if (!String.IsNullOrEmpty(aux))
                    {
                        obj.ClienteFechaAdd = Convert.ToDateTime(Convert.ToDateTime(aux).ToShortDateString());
                    }
                    else
                    {
                        obj.ClienteFechaAdd = new DateTime();
                    }
                   
                    obj.ClienteNDoc = dataReader["Cli_NDocumento"].ToString().TrimEnd();
                    obj.ClienteRazonSocial = dataReader["Cli_RazonSocial"].ToString().TrimEnd();
                    obj.ClienteRazonSocial= obj.ClienteRazonSocial.TrimStart();
                    obj.ClienteTelefono = dataReader["Cli_Telefono"].ToString().TrimEnd();
                    obj.ClienteDoc = dataReader["TDocIden_Descripcion"].ToString().TrimEnd();
                    obj.ClienteTipoDoc = Convert.ToInt32(dataReader["Cli_TipoDocumento"].ToString());
                    obj.ClienteUsuAdd = dataReader["Cli_UsuAdd"].ToString();
                    obj.ClienteUsuario = dataReader["UsuNombres"].ToString();
                    obj.ClienteNacion = dataReader["cli_Nacion"].ToString();
                    obj.ClienteUbigeo = dataReader["cli_Ubigeo"].ToString();
                    obj.ClienteDepartamentoId = dataReader["DepartamentoId"].ToString();
                    obj.ClienteDepartamento = dataReader["Departamento"].ToString();
                    obj.ClienteProvinciaId = dataReader["provinciaId"].ToString();
                    obj.ClienteProvincia = dataReader["provincia"].ToString();
                    obj.ClienteDistritoId = dataReader["distritoId"].ToString();
                    obj.ClienteDistrito = dataReader["distrito"].ToString();
                    obj.ClienteWeb = dataReader["Cli_web"].ToString();
                    obj.ClienteEmail = dataReader["cli_email"].ToString();
                    obj.ClienteObservacion = dataReader["cli_observacion"].ToString();
                    obj.ClienteDireccion = obj.ClienteDireccion + "-" + obj.ClienteDistrito;
                    obj.ClienteRetencion = Convert.ToBoolean( dataReader["Cli_Retencion"].ToString());
                    
                    objList.Add(obj);


                }
            }
            return objList;
        }

        public bool updateCliente(Cliente obj, String codent, String retencion)
        {

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_updateClienteAntiguo",
                   new object[] { obj.ClienteNDoc, obj.ClienteCod, obj.ClienteRazonSocial,
                   obj.ClienteDireccion, obj.ClienteTelefono, obj.ClienteWeb, obj.ClienteEmail, obj.ClienteContacto,
                   obj.ClienteUbigeo , obj.ClienteNacion,codent, retencion});

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

        public bool insertCliente(Cliente obj, String codent, String retencion)
        {

            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_insertClienteAntiguo",
                   new object[] { obj.ClienteNDoc, obj.ClienteRazonSocial,
                   obj.ClienteDireccion, obj.ClienteTelefono, obj.ClienteWeb, obj.ClienteEmail, obj.ClienteContacto,
                   obj.ClienteUbigeo , obj.ClienteNacion,codent, retencion});

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
