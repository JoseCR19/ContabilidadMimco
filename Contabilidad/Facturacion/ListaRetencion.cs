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
    public partial class ListaRetencion : Form
    {
        public static String operacionRetencion = "Q";
        public static List<RetencionCab> objListaRetencionCab = new List<RetencionCab>();
        RetencionDAO objRetencionDao;
        public static RetencionCab objRetencionCab = new RetencionCab();
        public ListaRetencion()
        {
            InitializeComponent();
            gridParams();
            objRetencionDao = new RetencionDAO();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            objListaRetencionCab = objRetencionDao.listarRetencion(dpickerInicio.Value, dpickerFin.Value, "", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaRetencionCab;
            grd_Facturas.Refresh();

        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.Width = 60;
            idColumn1.DataPropertyName = "RetencionCab_Serie";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Número";
            idColumn2.DataPropertyName = "RetencionCab_Numero";
            idColumn2.Width = 90;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razón Social";
            idColumn3.DataPropertyName = "RetencionCab_Proveedor";
            idColumn3.Width = 320;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "RUC";
            idColumn4.DataPropertyName = "RetencionCab_RucProv";
            idColumn4.Width = 80;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "RetencionCab_CodMoneda";
            idColumn5.Width = 100;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Retencion";
            idColumn6.DataPropertyName = "RetencionCab_Retencion";
            idColumn6.Width = 120;
            grd_Facturas.Columns.Add(idColumn6);


        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_Nuevo.Enabled = false;
            this.Hide();
            operacionRetencion = "N";
            Retencion Check = new Retencion();
            Check.Show();
            btn_Nuevo.Enabled = true;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RT");
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            operacionRetencion = "V";
            try
            {
                int index = grd_Facturas.SelectedCells[0].RowIndex;

               
                objRetencionCab = objListaRetencionCab[index];
                this.Hide();

                Retencion Check = new Retencion();
                Check.Show();

            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            objListaRetencionCab = new List<RetencionCab>();
            grd_Facturas.DataSource = null;
            objListaRetencionCab = objRetencionDao.listarRetencion(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text, Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaRetencionCab;
            grd_Facturas.Refresh();
            btn_Buscar.Enabled = true;
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {

        }
    }
}
