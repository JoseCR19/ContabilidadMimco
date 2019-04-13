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

namespace Conta.RegistroAsientoGeneral
{
    public partial class RegistrarAsientoGeneral : Form
    {
        List<TipoAsiento> objListTipoAsiento = new List<TipoAsiento>();
        List<Moneda> objListMoneda = new List<Moneda>();
        MonedaDAO objMonedaDao;
        AsientoDAO objAsientoDao;
        public static String tipoAsiento;
        public static String fechaComprobante;
        public static String monedaCod;
        public static String moneda;
        public static Double totalComprobante;
        public RegistrarAsientoGeneral()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            this.ControlBox = false;
            this.Text = "Asientos Generales";
            objAsientoDao = new AsientoDAO();
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            comboTipoAsiento();
            comboMoneda();
            cmb_tipoAsiento.SelectedIndexChanged += Cmb_tipoAsiento_SelectedIndexChanged;
            txt_TipoAsiento.Text = cmb_tipoAsiento.SelectedValue.ToString();
            tipoCambio(dpicker_Fecha.Value.ToShortDateString());
            dpicker_Fecha.ValueChanged += Dpicker_Fecha_ValueChanged;

        }

        private void Dpicker_Fecha_ValueChanged(object sender, EventArgs e)
        {
            tipoCambio(dpicker_Fecha.Value.ToShortDateString());
        }

        private void Cmb_tipoAsiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_TipoAsiento.Text = cmb_tipoAsiento.SelectedValue.ToString();
        }

        public void comboTipoAsiento()
        {
            objListTipoAsiento = objAsientoDao.getComboTipoAsiento();
            cmb_tipoAsiento.DataSource = objListTipoAsiento;
            cmb_tipoAsiento.DisplayMember = "Descripcion";
            cmb_tipoAsiento.ValueMember = "Id";
            cmb_tipoAsiento.Refresh();
        }

        public void comboMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }

        public void tipoCambio(String date)
        {
            txt_TipoCambio.Text = objMonedaDao.getTipoCambioVenta(date).ToString().PadRight(5, '0');
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            ContabilidadMenu.formContabilidad.setEnabledItems("AG");
            this.Close();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            tipoAsiento = txt_TipoAsiento.Text;
            fechaComprobante = dpicker_Fecha.Value.ToString("dd/MM/yyyy");
            monedaCod = cmb_Moneda.SelectedValue.ToString();
            moneda = cmb_Moneda.Text;
            try
            {
                totalComprobante = objMonedaDao.convertToDouble(txt_Total.Text);
                AsientoCGeneral Check = new AsientoCGeneral();
                Check.Show();
                this.Hide();
            }
            catch 
            {
                MessageBox.Show("Ingrese un número correcto");
            }
            

        }
    }
}
