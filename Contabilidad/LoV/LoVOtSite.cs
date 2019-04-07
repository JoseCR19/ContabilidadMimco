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
    public partial class LoVOtSite : Form
    {
        Caja.EmisionVoucher emisionForm;
        OtDTO obj;
        LoVDAO objLoVDao;
        int index = 0;
        public static List<OtDTO> objListOt = new List<OtDTO>();
        public static List<OtDTO> objListOtNro = new List<OtDTO>();
        public static List<OtDTO> objListDirOt = new List<OtDTO>();
        public static List<OtDTO> objListTotal = new List<OtDTO>();
        public LoVOtSite()
        {
            InitializeComponent();
            this.Text = "OT/CC";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            emisionForm = Caja.EmisionVoucher.formEmision;
            objLoVDao = new LoVDAO();
            obj = new OtDTO();
            this.ActiveControl = txt_Busqueda;
            gridParams();
            objListOt = objLoVDao.getLovOtSite(Ventas.UNIDADNEGOCIO);
            objListTotal = objListOt;
            grdSolicita.DataSource = objListOt;
            grdSolicita.Refresh();
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            grdSolicita.DoubleClick += GrdSolicita_DoubleClick;
        }

        private void GrdSolicita_DoubleClick(object sender, EventArgs e)
        {
            index = grdSolicita.SelectedCells[0].RowIndex;
            obj = objListTotal[index];
            emisionForm.setOt(obj.NumeroOt, obj.DirOt, obj.CodigoOt);
            this.Close();
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();

            objListOtNro = objListOt.Where(t => t.NumeroOt.Contains(busqueda)).ToList();
            objListDirOt = objListOt.Where(t => t.DirOt.Contains(busqueda)).ToList();
            objListTotal = objListOtNro.Union(objListDirOt).ToList().OrderBy(x => x.NumeroOt).ToList();
            grdSolicita.DataSource = null;
            grdSolicita.DataSource = objListTotal;
            grdSolicita.Refresh();

        }

        public void gridParams()
        {
            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° OT";
            idColumn1.DataPropertyName = "NumeroOt";
            idColumn1.Width = 120;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Site";
            idColumn2.DataPropertyName = "DirOt";
            idColumn2.Width = 320;
            grdSolicita.Columns.Add(idColumn2);


        }
    }
}
