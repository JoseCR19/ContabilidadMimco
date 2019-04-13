using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaDAO
{
    public class Conexion
    {
        private SqlConnection cn = null;
        private SqlCommand cmd = null;

        public Conexion(string strBD)
        {
            try
            {
                this.cn = new SqlConnection(ConfigurationManager.ConnectionStrings[strBD].ConnectionString);
                this.cmd = new SqlCommand("", cn);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
