using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class ListaCliente : Form

    {
        ClienteDAO objClienteDao;
        public static Cliente objCliente;
        public static String operacionCliente ="Q";

        public static List<Cliente> objListCliente = new List<Cliente>();
        public static List<Cliente> objListBusquedaRazon = new List<Cliente>();
        public static List<Cliente> objListBusquedaRuc = new List<Cliente>();
        public static List<Cliente> objListBusquedaTotal = new List<Cliente>();
        public ListaCliente()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Mantenimiento Cliente";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objCliente = new Cliente();
            gridParams();
            objClienteDao = new ClienteDAO();
            objListCliente = objClienteDao.listarCliente(Ventas.UNIDADNEGOCIO);
            listCliente(objListCliente);
            objListBusquedaTotal = objListCliente;
            txt_BuscarCliente.TextChanged += Txt_BuscarCliente_TextChanged;
        }

        private void Txt_BuscarCliente_TextChanged(object sender, EventArgs e)
        {

            String busqueda = txt_BuscarCliente.Text.ToUpper();

            objListBusquedaRazon = objListCliente.Where(t => t.ClienteRazonSocial.Contains(busqueda)).ToList();
            objListBusquedaRuc = objListCliente.Where(t => t.ClienteNDoc.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).ToList().OrderBy(x => x.ClienteRazonSocial).ToList();
            listCliente(objListBusquedaTotal);
        }

        public void gridParams()
        {
            grdCliente.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Código";
            idColumn3.DataPropertyName = "ClienteCod";
            idColumn3.Width = 110;
            grdCliente.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.Width = 110;
            idColumn1.DataPropertyName = "ClienteNDoc";
            grdCliente.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.DataPropertyName = "ClienteRazonSocial";
            idColumn2.Width = 360;
            grdCliente.Columns.Add(idColumn2);
           
        }
        public void listCliente(List<Cliente> lista)
        {
            grdCliente.DataSource = lista;
            grdCliente.Refresh();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
           // Ventas.formVentas.setEnabledItems("CL");
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            operacionCliente = "V";
            try
            {
                int index = grdCliente.SelectedCells[0].RowIndex;


                objCliente = objListBusquedaTotal[index];
                this.Hide();

                MantenimientoCliente Check = new MantenimientoCliente();
                Check.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.Hide();
            operacionCliente = "N";
            MantenimientoCliente Check = new MantenimientoCliente();
            Check.Show();
        }
    }
}
