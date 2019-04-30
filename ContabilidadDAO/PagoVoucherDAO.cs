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
    public class PagoVoucherDAO
    {
        Conexion _Conexion = new Conexion("Conta");
        public bool registrarPago(String NroRegistro, Double Total, Double Abono)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_registrarPago",
                   new object[] {  NroRegistro, Total, Abono});
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
        public bool registrarDetraccionPago(String NroRegistro, Double Abono)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_registrarDetraccionPago",
                   new object[] { NroRegistro, Abono });
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

        public bool ActualizarPago(String NroRegistro, Double Abono, Double Total)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_ActualizarPago",
                   new object[] { NroRegistro, Total, Abono });
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

        public bool anularPago(String NroRegistro)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_EjecutarAnulacionPago",
                   new object[] { NroRegistro });
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

        public bool registrarAbono(String Serie, String Nro, Double Abono)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_RegistrarAbonoFactura",
                   new object[] { Serie, Nro,  Abono });
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

        public bool registrarDetraccionFactura(String Serie, String Nro, Double Abono)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_RegistrarDetraccionFactura",
                   new object[] { Serie, Nro, Abono });
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
        public bool registrarAbonoDetraccionFactura(String Serie, String Nro, Double Abono)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_RegistrarAbonoDetraccionFactura",
                   new object[] { Serie, Nro, Abono });
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
        public bool ActualizarAbono(String Serie, String Nro, Double Abono)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_AcutiaizarCobro",
                   new object[] { Serie, Nro, Abono });
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
        public bool anularAbono(String Serie, String Nro,Double Importe)
        {
            Database db = DatabaseFactory.CreateDatabase("Conta");
            DbCommand dbCommand = db.GetStoredProcCommand("sp_AnularAbono",
                   new object[] { Serie, Nro, Importe });
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
