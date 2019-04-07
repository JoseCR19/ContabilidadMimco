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
    public partial class LoVTipoPagoVoucher : Form
    {
        Caja.EmisionVoucher emisionForm;

        public static List<TipoPagoVoucher> objListTipoPagoVoucher = new List<TipoPagoVoucher>();
        public static List<TipoPagoVoucher> objListTipoPagoVoucherCodigo = new List<TipoPagoVoucher>();
        public static List<TipoPagoVoucher> objListTipoPagoVoucherDescripcion = new List<TipoPagoVoucher>();
        public static List<TipoPagoVoucher> objListTipoPagoVoucherTotal = new List<TipoPagoVoucher>();

        TipoPagoVoucher obj;
        LoVDAO objLoVDao;
        int index = 0;
        public LoVTipoPagoVoucher()
        {
            InitializeComponent();
            this.Text = "OT/CC";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            emisionForm = Caja.EmisionVoucher.formEmision;
            objLoVDao = new LoVDAO();
            obj = new TipoPagoVoucher();
            this.ActiveControl = txt_Busqueda;
            gridParams();
            objListTipoPagoVoucher = objLoVDao.getLovTipoPagoVoucher();
            objListTipoPagoVoucherTotal = objListTipoPagoVoucher;
            grdSolicita.DataSource = objListTipoPagoVoucher;
            grdSolicita.Refresh();
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            grdSolicita.DoubleClick += GrdSolicita_DoubleClick;

        }
        private void GrdSolicita_DoubleClick(object sender, EventArgs e)
        {
            index = grdSolicita.SelectedCells[0].RowIndex;
            obj = objListTipoPagoVoucherTotal[index];
            emisionForm.setTipoPagoVoucher(obj.Codigo,  obj.Descripcion);
            this.Close();
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();

            objListTipoPagoVoucherCodigo = objListTipoPagoVoucher.Where(t => t.Codigo.Contains(busqueda)).ToList();
            objListTipoPagoVoucherDescripcion = objListTipoPagoVoucher.Where(t => t.Descripcion.Contains(busqueda)).ToList();
            objListTipoPagoVoucherTotal = objListTipoPagoVoucherDescripcion.Union(objListTipoPagoVoucherCodigo).ToList().OrderBy(x => x.Codigo).ToList();
            grdSolicita.DataSource = null;
            grdSolicita.DataSource = objListTipoPagoVoucherTotal;
            grdSolicita.Refresh();

        }


        public void gridParams()
        {
            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Código";
            idColumn1.DataPropertyName = "Codigo";
            idColumn1.Width = 120;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Descripción";
            idColumn2.DataPropertyName = "Descripcion";
            idColumn2.Width = 320;
            grdSolicita.Columns.Add(idColumn2);


        }
    }
}
