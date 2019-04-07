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
    public partial class LoVOt : Form
    {
        Caja.CajaChica cajaChicaForm;
        public static List<OtDTO> objListOt = new List<OtDTO>();
        public static List<OtDTO> objListOtNro = new List<OtDTO>();
        public static List<OtDTO> objListDescripcion = new List<OtDTO>();
        public static List<OtDTO> objListTotal = new List<OtDTO>();
        OtDTO obj;
        LoVDAO objLoVDao;
        int index = 0;
        public LoVOt()
        {
            InitializeComponent();
            this.Text = "OT/ CENTRO DE COSTO";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            obj = new OtDTO();
            objLoVDao = new LoVDAO();

            objListOt = objLoVDao.getLovOt(Ventas.UNIDADNEGOCIO);
            gridParams();
            grdOt.DataSource = objListOt;
            cajaChicaForm = Caja.CajaChica.formCajachica;
            grdOt.DoubleClick += GrdOt_DoubleClick;
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            objListTotal = objListOt;
        }
        public void gridParams()
        {
            grdOt.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° OT";
            idColumn1.DataPropertyName = "NumeroOt";
            idColumn1.Width = 100;
            grdOt.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Descripción";
            idColumn2.DataPropertyName = "Descripcion";
            idColumn2.Width = 260;
            grdOt.Columns.Add(idColumn2);


        }
        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();

            objListOtNro = objListOt.Where(t => t.NumeroOt.Contains(busqueda)).ToList();
            objListDescripcion = objListOt.Where(t => t.Descripcion.Contains(busqueda)).ToList();
            objListTotal = objListOtNro.Union(objListDescripcion).ToList().OrderBy(x => x.NumeroOt).ToList();
            listGrid(objListTotal);
        }

        private void GrdOt_DoubleClick(object sender, EventArgs e)
        {
            index = grdOt.SelectedCells[0].RowIndex;
            obj = objListTotal[index];
            cajaChicaForm.setOt (obj.NumeroOt, obj.Descripcion, obj.CodigoOt);
            this.Close();
        }
        public void listGrid(List<OtDTO> lista)
        {
            grdOt.DataSource = null;
            grdOt.DataSource = lista;
            grdOt.Refresh();
        }
    }
}
