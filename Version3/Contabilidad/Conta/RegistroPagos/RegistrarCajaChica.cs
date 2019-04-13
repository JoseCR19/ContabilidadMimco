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
    public partial class RegistrarCajaChica : Form
    {
        public static List<CajaDet> objListaCajaDet = new List<CajaDet>();
        public static RegistrarCajaChica AsientoCajaForm;
        CajaDet objCajaDet = new CajaDet();
        AsientoDAO objAsientoDAO;
        public static List<UnidadNegocio> objListUnidadNegocio = new List<UnidadNegocio>();
        UnidadNegocio objUnidadNegocio;
        MonedaDAO objMonedaDao;
        public RegistrarCajaChica()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Asientos Contables";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            AsientoCajaForm = this;
            objAsientoDAO = new AsientoDAO();
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            cargarcmb();
            gridParams();
            objListaCajaDet = objAsientoDAO.getGenerarCaja(cmb_UnidadNegocio.SelectedValue.ToString());
            grd_Facturas.DataSource = objListaCajaDet;
            grd_Facturas.Refresh();
            cmb_UnidadNegocio.SelectedIndexChanged += Cmb_UnidadNegocio_SelectedIndexChanged;
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
            grd_Facturas.DoubleClick += Grd_Facturas_DoubleClick;
        }

        private void Grd_Facturas_DoubleClick(object sender, EventArgs e)
        {
            AsientoCCajaChica form = new AsientoCCajaChica(objCajaDet);

            form.Show();
            this.Close();
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;
            objCajaDet = objListaCajaDet[index];
            objCajaDet.CodEnt = cmb_UnidadNegocio.SelectedValue.ToString();
        }

        private void Cmb_UnidadNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            objListaCajaDet = objAsientoDAO.getGenerarCaja(cmb_UnidadNegocio.SelectedValue.ToString());
            grd_Facturas.DataSource = null;
            grd_Facturas.DataSource = objListaCajaDet;
            grd_Facturas.Refresh();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            ContabilidadMenu.formContabilidad.setEnabledItems("CC");
            this.Close();
        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N° OT";
            idColumn2.DataPropertyName = "NroOt";
            idColumn2.Width = 70;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Referencia";
            idColumn3.DataPropertyName = "CentroLabor";
            idColumn3.Width = 180;
            //idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.DataPropertyName = "Ruc";
            idColumn1.Width = 90;
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Proveedor";
            idColumn4.DataPropertyName = "Proveedor";
            idColumn4.Width = 215;
            //idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Dcto";
            idColumn5.DataPropertyName = "TipoDocCorta";
            //idColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            idColumn5.Width = 40;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "N° Doc";
            idColumn6.DataPropertyName = "NroDocumento";
            idColumn6.Width = 80;
            //idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Fecha";
            idColumn7.DataPropertyName = "FechaEmision";
            idColumn7.Width = 70;
            //idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Importe";
            idColumn8.DataPropertyName = "Total";
            idColumn8.Width = 50;
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn8);
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
    }
}
