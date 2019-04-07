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
    public partial class grd_Gastos : Form
    {
        Caja.CajaChica cajaChicaForm;
        public static List<TipoGastos> objListTipoGastos = new List<TipoGastos>();
        public static List<TipoGastos> objListTipoGastosDescripcion = new List<TipoGastos>();
        public static List<TipoGastos> objListTipoGastosCodigo = new List<TipoGastos>();
        public static List<TipoGastos> objListTipoGastosTotal = new List<TipoGastos>();
        TipoGastos objTipoGastos;
        LoVDAO objLoVDao;
        int index = 0;
        public grd_Gastos()
        {
            InitializeComponent();
            this.Text = "Tipo Gastos";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objTipoGastos = new TipoGastos();
            objLoVDao = new LoVDAO();

            objListTipoGastos = objLoVDao.getLovTipoGastos();
            gridParams();
            grdGasto.DataSource = objListTipoGastos;
            cajaChicaForm = Caja.CajaChica.formCajachica;
            grdGasto.DoubleClick += GrdGasto_DoubleClick;
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            objListTipoGastosTotal = objListTipoGastos;
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();

            objListTipoGastosCodigo = objListTipoGastos.Where(t => t.Codigo.Contains(busqueda)).ToList();
            objListTipoGastosDescripcion = objListTipoGastos.Where(t => t.Descripcion.Contains(busqueda)).ToList();
            objListTipoGastosTotal = objListTipoGastosDescripcion.Union(objListTipoGastosCodigo).ToList().OrderBy(x => x.Codigo).ToList();
            listGrid(objListTipoGastosTotal);
        }
        public void listGrid(List<TipoGastos> lista)
        {
            grdGasto.DataSource = null;
            grdGasto.DataSource = lista;
            grdGasto.Refresh();
        }
        private void GrdGasto_DoubleClick(object sender, EventArgs e)
        {
            index = grdGasto.SelectedCells[0].RowIndex;
            objTipoGastos = objListTipoGastosTotal[index];
            cajaChicaForm.setGasto(objTipoGastos.Codigo, objTipoGastos.Descripcion, objTipoGastos.CuentaContable);
            this.Close();
        }

        public void gridParams()
        {
            grdGasto.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Código";
            idColumn1.DataPropertyName = "Codigo";
            idColumn1.Width = 100;
            grdGasto.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Descripción";
            idColumn2.DataPropertyName = "Descripcion";
            idColumn2.Width = 260;
            grdGasto.Columns.Add(idColumn2);


        }
    }
}
