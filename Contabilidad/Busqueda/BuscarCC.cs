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

namespace Contabilidad.Busqueda
{
    public partial class BuscarCC : Form
    {
        Factura facturaForm;
        CentroCostosDAO objCCDAO;
        public List<CentroCostos> objListCC = new List<CentroCostos>();
        CentroCostos objCC;
        public BuscarCC()
        {
            InitializeComponent();
            facturaForm = Factura.formFactura;
            objCCDAO = new CentroCostosDAO();
            objListCC = objCCDAO.listarCCostos(Ventas.UNIDADNEGOCIO);
            gridParams();
            grdOt.DataSource = objListCC;
            grdOt.Refresh();
        }
        public void gridParams()
        {
            grdOt.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "CentroCosto";
            idColumn1.Width = 150;
            idColumn1.DataPropertyName = "CCostosNro";
            grdOt.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Descripción";
            idColumn2.DataPropertyName = "CCostosDescripcion";
            idColumn2.Width = 300;
            grdOt.Columns.Add(idColumn2);

        }
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grdOt.SelectedCells[0].RowIndex;
                facturaForm.setCCDatos(objListCC[index].CCostosNro);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }
    }
}
