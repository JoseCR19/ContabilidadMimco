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


namespace Contabilidad.LoV
{
    public partial class LoVBanco : Form
    {
        Caja.EmisionVoucher emisionForm;
        public static List<CuentaBanco> objListaBanco = new List<CuentaBanco>();
        public static List<CuentaBanco> objListaBancoNombre = new List<CuentaBanco>();
        public static List<CuentaBanco> objListaBancoTotal = new List<CuentaBanco>();

        LoVDAO objLoVDao;

        CuentaBanco objBanco;

        int index = 0;

        public LoVBanco()
        {
            InitializeComponent();
            this.Text = "Solicitante";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            emisionForm = Caja.EmisionVoucher.formEmision;
            objLoVDao = new LoVDAO();
            objBanco = new CuentaBanco();
            gridParamsBanco();
            this.ActiveControl = txt_Busqueda;

            objListaBanco = objLoVDao.getLovBanco(Ventas.UNIDADNEGOCIO);
            objListaBancoTotal = objListaBanco;
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            grdSolicita.DoubleClick += GrdSolicita_DoubleClick;
            grdSolicita.DataSource = objListaBanco;
            grdSolicita.Refresh();

        }

        private void GrdSolicita_DoubleClick(object sender, EventArgs e)
        {
            index = grdSolicita.SelectedCells[0].RowIndex;
            objBanco = new CuentaBanco();
            objBanco = objListaBancoTotal[index];
            emisionForm.setBanco(objBanco.Codigo, objBanco.Descripcion,objBanco.Cuenta, objBanco.CuentaContable, objBanco.MonedaCod);
            this.Close();
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();
            objListaBancoNombre = objListaBanco.Where(t => t.Descripcion.Contains(busqueda)).ToList();
            objListaBancoTotal = objListaBancoNombre;
            grdSolicita.DataSource = objListaBancoTotal;
            grdSolicita.Refresh();
        }

        void gridParamsBanco()
        {

            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Banco";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 175;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Moneda";
            idColumn2.DataPropertyName = "Moneda";
            idColumn2.Width = 130;
            grdSolicita.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Cuenta";
            idColumn3.DataPropertyName = "Cuenta";
            idColumn3.Width = 140;
            grdSolicita.Columns.Add(idColumn3);
        }
    }
}
