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

namespace Conta.PlanDeCuenta
{
    public partial class MantenimientoPlanContable : Form
    {
        List<CuentaContable> objListaCuentaContable = new List<CuentaContable>();
        List<CuentaContable> objListaBusquedaCuenta = new List<CuentaContable>();
        List<CuentaContable> objListaBusquedaDescripcion = new List<CuentaContable>();
        List<CuentaContable> objListaCuentaContableTotal = new List<CuentaContable>();
        public static CuentaContable objCuentaContable;
        CuentaContableDAO objCCuentaDAO = new CuentaContableDAO();
        public MantenimientoPlanContable()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Plan Contable";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objCuentaContable = new CuentaContable();
            gridParams();
            objListaCuentaContable= objCCuentaDAO.getListaCuentaContable();
            objListaCuentaContableTotal = objListaCuentaContable;
            grd_CuentaContable.DataSource = objListaCuentaContableTotal;
            grd_CuentaContable.Refresh();
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            grd_CuentaContable.CellDoubleClick += Grd_CuentaContable_CellDoubleClick;
        }

        private void Grd_CuentaContable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_CuentaContable.SelectedCells[0].RowIndex;
            objCuentaContable= objListaCuentaContableTotal[index];
            PlanContable check = new PlanContable("V");

            check.Show();
            this.Close();
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();
            objListaBusquedaCuenta = objListaCuentaContable.Where(t => t.Cuenta.Contains(busqueda)).ToList();
            objListaBusquedaDescripcion = objListaCuentaContable.Where(t => t.Descripcion.Contains(busqueda)).ToList();
            objListaCuentaContableTotal = objListaBusquedaCuenta.Union(objListaBusquedaDescripcion).ToList();
            grd_CuentaContable.DataSource = null;
            grd_CuentaContable.DataSource = objListaCuentaContableTotal;
            grd_CuentaContable.Refresh();
        }

        public void gridParams()
        {
            grd_CuentaContable.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "C.Contable";
            idColumn0.Width = 70;
            idColumn0.DataPropertyName = "Cuenta";
            grd_CuentaContable.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion";
            idColumn1.Width = 300;
            idColumn1.DataPropertyName = "Descripcion";
            grd_CuentaContable.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Tipo";
            idColumn2.Width = 170;
            idColumn2.DataPropertyName = "TipoCuentaConcatenado";
            grd_CuentaContable.Columns.Add(idColumn2);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Nivel";
            idColumn4.Width = 70;
            idColumn4.DataPropertyName = "Nivel";
            grd_CuentaContable.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Anexo";
            idColumn5.Width = 70;
            idColumn5.DataPropertyName = "Anexo";
            grd_CuentaContable.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "DocR";
            idColumn6.Width = 60;
            idColumn6.DataPropertyName = "DocR";
            grd_CuentaContable.Columns.Add(idColumn6);

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            ContabilidadMenu.formContabilidad.setEnabledItems("MP"); // Mantenimiento PLan COntable
            this.Close();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            PlanContable check = new PlanContable("N");
            check.Show();
            this.Close();
        }
    }
}
