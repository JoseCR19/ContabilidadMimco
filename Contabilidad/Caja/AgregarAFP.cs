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
    public partial class AgregarAFP : Form
    {
        EmisionVoucher formEmision;
        public static List<Personal> objListPersonal = new List<Personal>();
        public static List<Personal> objListBusquedaNdoc = new List<Personal>();
        public static List<Personal> objListBusquedaNombre = new List<Personal>();
        public static List<Personal> objListBusquedaTotal = new List<Personal>();

        Personal objPersonal;
        VoucherDAO objVoucherDao;
        public AgregarAFP()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            objListPersonal = objVoucherDao.getPersonalVoucherAFP();
            grdDocumento.DataSource = objListPersonal;
            objListBusquedaTotal = objListPersonal;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            grdDocumento.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.Pago > 0).ToList();
            formEmision.setDatosAFP(objListBusquedaTotal);
            this.Close();
        }
        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();
            objListBusquedaNombre = objListPersonal.Where(x => x.Nombre.Contains(busqueda)).ToList();
            objListBusquedaNdoc = objListPersonal.Where(x => x.NroDocumento.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaNdoc.Union(objListBusquedaNombre).ToList();
            grdDocumento.DataSource = null;
            grdDocumento.DataSource = objListBusquedaTotal;
            grdDocumento.Refresh();
        }

        public void gridParams()
        {

            grdDocumento.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();

            idColumn0.Name = "N° Doc";
            idColumn0.DataPropertyName = "NroDocumento";
            idColumn0.Width = 70;
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Nombres";
            idColumn1.DataPropertyName = "Nombre";
            idColumn1.Width = 330;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Centro Costo";
            idColumn4.DataPropertyName = "CentroCosto";
            idColumn4.Width = 100;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "AFP";
            idColumn5.DataPropertyName = "Afp";
            idColumn5.Width = 90;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Pago";
            idColumn6.DataPropertyName = "Pago";
            idColumn6.Width = 80;
            grdDocumento.Columns.Add(idColumn6);


            grdDocumento.Columns[0].ReadOnly = true;
            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;



        }
    }
}
