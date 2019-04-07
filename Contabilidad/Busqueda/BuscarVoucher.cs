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
    public partial class BuscarVoucher : Form
    {
        public Retencion formRetencion;
        public List<DocumentoPagoCab> objListaS = new List<DocumentoPagoCab>();
        PagoDAO objPagoDAO;
        public BuscarVoucher(String Ruc)
        {
            InitializeComponent();
            formRetencion = Retencion.retencionForm;
            objPagoDAO = new PagoDAO();
            objListaS = objPagoDAO.buscarPago(Ruc, Ventas.UNIDADNEGOCIO);
            gridParams();
            grdCliente.DataSource = objListaS;
            grdCliente.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grdCliente.SelectedCells[0].RowIndex;
                //  formRetencion.setVoucher(objListaS[index].DocumentoPagoCabNroVoucher);
                formRetencion.setVoucher("M1802008");
                this.Close();
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }
        public void gridParams()
        {
            grdCliente.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número Voucher";
            idColumn1.DataPropertyName = "DocumentoPagoCabNroVoucher";
            idColumn1.Width = 130;
            grdCliente.Columns.Add(idColumn1);
           

        }
    }
}
