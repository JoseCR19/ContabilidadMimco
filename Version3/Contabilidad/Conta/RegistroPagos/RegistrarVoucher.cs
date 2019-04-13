using ContaDAO;
using ContaDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conta.RegistroPagos
{
    public partial class RegistrarVoucher : Form
    {
        public static List<Voucher> objListaVoucher = new List<Voucher>();
        Voucher objVoucher;
        public static RegistrarVoucher VoucherForm;
        DocumentoCab objDocumentoCab = new DocumentoCab();
        AsientoDAO objAsientoDAO;
        public static List<UnidadNegocio> objListUnidadNegocio = new List<UnidadNegocio>();
        UnidadNegocio objUnidadNegocio;
        MonedaDAO objMonedaDao;

        public static int index = 0;
        public RegistrarVoucher()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Asientos Contables";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            VoucherForm = this;
            objAsientoDAO = new AsientoDAO();
            objMonedaDao = new MonedaDAO();
            objVoucher = new Voucher();
            objMonedaDao.tipoCambio();
            cargarcmb();
            gridParams();
            objListaVoucher = objAsientoDAO.getGenerarVoucher(cmb_UnidadNegocio.SelectedValue.ToString());
            grd_Facturas.DataSource = objListaVoucher;
            grd_Facturas.Refresh();
            cmb_UnidadNegocio.SelectedIndexChanged += Cmb_UnidadNegocio_SelectedIndexChanged;
            grd_Facturas.DoubleClick += Grd_Facturas_DoubleClick;
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             index = grd_Facturas.SelectedCells[0].RowIndex;
             objVoucher = objListaVoucher[index];
             
        }

        private void Grd_Facturas_DoubleClick(object sender, EventArgs e)
        {
            AsientoCVoucher form = new AsientoCVoucher(objVoucher);

            form.Show();
            this.Close();
        }

        private void Cmb_UnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            objListaVoucher = objAsientoDAO.getGenerarVoucher(cmb_UnidadNegocio.SelectedValue.ToString());
            grd_Facturas.DataSource = null;
            grd_Facturas.DataSource = objListaVoucher;
            grd_Facturas.Refresh();
        }

        public void cargarcmb()
        {
            cmb_UnidadNegocio.DataSource = null;
            objListUnidadNegocio = null;
            objListUnidadNegocio = new List<UnidadNegocio>();
            objUnidadNegocio = new UnidadNegocio();
            objUnidadNegocio.Codigo = "01";
            objUnidadNegocio.Negocio = "METALES";
            objListUnidadNegocio.Add(objUnidadNegocio);
            objUnidadNegocio = null;
            objUnidadNegocio = new UnidadNegocio();
            objUnidadNegocio.Codigo = "02";
            objUnidadNegocio.Negocio = "GALVANIZADO";
            objListUnidadNegocio.Add(objUnidadNegocio);

            cmb_UnidadNegocio.DisplayMember = "Negocio";
            cmb_UnidadNegocio.ValueMember = "Codigo";
            cmb_UnidadNegocio.DataSource = objListUnidadNegocio;

        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N° Voucher";
            idColumn2.DataPropertyName = "NroVoucher";
            idColumn2.Width = 70;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha Pago";
            idColumn3.DataPropertyName = "FechaPago";
            idColumn3.Width = 90;
            //idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° Cheque";
            idColumn1.DataPropertyName = "NumeroCheque";
            idColumn1.Width = 85;
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "N° Cuenta";
            idColumn4.DataPropertyName = "NumeroCuenta";
            idColumn4.Width = 130;
            //idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Banco";
            idColumn0.DataPropertyName = "Banco";
            idColumn0.Width = 180;
            //idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "Moneda";
            //idColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            idColumn5.Width = 50;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "N° Doc";
            idColumn6.DataPropertyName = "SolicitaCod";
            idColumn6.Width = 70;
            //idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Nombre";
            idColumn7.DataPropertyName = "Solicitante";
            idColumn7.Width = 220;
            //idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Importe";
            idColumn8.DataPropertyName = "Importe";
            idColumn8.Width = 70;
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn8);
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            ContabilidadMenu.formContabilidad.setEnabledItems("VO");
            this.Close();
        }
    }
}
