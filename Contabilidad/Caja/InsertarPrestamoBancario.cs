using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Caja
{
    public partial class InsertarPrestamoBancario : Form
    {
        public static EmisionVoucher formEmision;
        List<Moneda> objListMoneda = new List<Moneda>();
        List<CuentaBanco> objListBanco = new List<CuentaBanco>();

        VoucherDAO objVoucherDao;
        MonedaDAO objMonedaDao;
        public InsertarPrestamoBancario()
        {
            InitializeComponent();
            this.Text = "Cargo Bancario";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 10);
            objVoucherDao = new VoucherDAO();
            objMonedaDao = new MonedaDAO();
            formEmision = EmisionVoucher.formEmision;
            cmbMoneda();
            cmbBanco();
            cmb_Banco.SelectedIndexChanged += Cmb_Banco_SelectedIndexChanged;
            cmb_Moneda.SelectedIndexChanged += Cmb_Moneda_SelectedIndexChanged;
            txt_NroCuenta.Text = objVoucherDao.getNroCuenta(cmb_Banco.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString());
        }

        private void Cmb_Moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_NroCuenta.Text = objVoucherDao.getNroCuenta(cmb_Banco.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString());
        }

        void cmbMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }
        void cmbBanco()
        {
            objListBanco = objVoucherDao.getBanco();
            cmb_Banco.DataSource = objListBanco;
            cmb_Banco.ValueMember = "Codigo";
            cmb_Banco.DisplayMember = "Descripcion";
            cmb_Banco.Refresh();
        }
        private void Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_NroCuenta.Text = objVoucherDao.getNroCuenta(cmb_Banco.SelectedValue.ToString(),cmb_Moneda.SelectedValue.ToString());
        }
        

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_Monto.Text))
            {
                MessageBox.Show("Ingrese un Monto");
                return;
            }
            PrestamoBancario obj = new PrestamoBancario();
            obj.Banco = cmb_Banco.Text;
            obj.CodBanco = cmb_Banco.SelectedValue.ToString();
            obj.FechaEmision = dpick_FechaEmision.Value;
            obj.FechaEmision = dpick_FechaVcto.Value;
            obj.Moneda = cmb_Moneda.SelectedValue.ToString();
            obj.Monto = objVoucherDao.convertToDouble(txt_Monto.Text);
            formEmision.setDatosInsertarPrestamo(obj);
            this.Hide();
        }

        

    }
}
