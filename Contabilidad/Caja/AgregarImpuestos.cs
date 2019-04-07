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

namespace Contabilidad.Caja
{
    public partial class AgregarImpuestos : Form
    {
        EmisionVoucher formEmision;
        public static List<TipoImpuesto> objListImpuestos = new List<TipoImpuesto>();
        public static List<TipoImpuesto> objListBusquedaCodigo = new List<TipoImpuesto>();
        public static List<TipoImpuesto> objListBusquedaNombre = new List<TipoImpuesto>();
        public static List<TipoImpuesto> objListBusquedaTotal = new List<TipoImpuesto>();

        TipoImpuesto objImpuestos;
        VoucherDAO objVoucherDao;
        public AgregarImpuestos()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            objListImpuestos = objVoucherDao.getImpuestosVoucher();
            grdDocumento.DataSource = objListImpuestos;
            objListBusquedaTotal = objListImpuestos;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            grdDocumento.Refresh();
        }
        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();
            objListBusquedaNombre = objListImpuestos.Where(x => x.Descripcion.Contains(busqueda)).ToList();
            objListBusquedaCodigo = objListImpuestos.Where(x => x.Codigo.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaNombre.Union(objListBusquedaCodigo).ToList();
            grdDocumento.DataSource = null;
            grdDocumento.DataSource = objListBusquedaTotal;
            grdDocumento.Refresh();
        }
        public void gridParams()
        {

            grdDocumento.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Selec";
            chkColumn.Width = 50;
            chkColumn.DataPropertyName = "chkSelc";
            grdDocumento.Columns.Add(chkColumn);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();

            idColumn0.Name = "Código";
            idColumn0.DataPropertyName = "Codigo";
            idColumn0.Width = 70;
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Impuesto";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 300;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Monto";
            idColumn4.DataPropertyName = "Pago";
            idColumn4.Width = 100;
            grdDocumento.Columns.Add(idColumn4);
 
            
            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;




        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            formEmision.setDatosImpuestos(objListBusquedaTotal);
            this.Close();
        }
    }
}
