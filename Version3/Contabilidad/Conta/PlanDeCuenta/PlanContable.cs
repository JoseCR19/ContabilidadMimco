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
    public partial class PlanContable : Form
    {
        String TipoVista;
        String Operacion = "Q";
        TipoCuentaContable objTipoCC;
        CuentaContable objCuentaContable;

        MonedaDAO objMonedaDao;
        TipoCuentaContableDAO objTipoCCDAO;
        AnexoContableDAO objAnexoContableDAO;
        NivelContableDAO objNivelContableDAO;
        CuentaContableDAO objCuentaContableDAO;

        List<TipoCuentaContable> objListTipoCC = new List<TipoCuentaContable>();
        List<AnexoContable> objListAnexoContable = new List<AnexoContable>();
        List<NivelContable> objListNivelContable = new List<NivelContable>();
        List<Moneda> objListMoneda = new List<Moneda>();

        public PlanContable(String Vista)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Plan Contable";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objTipoCCDAO = new TipoCuentaContableDAO();
            objTipoCC = new TipoCuentaContable();
            objCuentaContable = new CuentaContable();
            objMonedaDao = new MonedaDAO();
            objNivelContableDAO = new NivelContableDAO();
            objAnexoContableDAO = new AnexoContableDAO();
            objCuentaContableDAO = new CuentaContableDAO();
            TipoVista = Vista;
            cmbTipoCuentaContable();
            comboMoneda();
            cmbAnexo();
            cmbNivel();
            cmb_TipoCuenta.SelectedIndexChanged += Cmb_TipoCuenta_SelectedIndexChanged;
            cmb_Moneda.SelectedIndexChanged += Cmb_Moneda_SelectedIndexChanged;
            cmb_NivelSaldo.SelectedIndexChanged += Cmb_NivelSaldo_SelectedIndexChanged;
            cmb_TipoAnexo.SelectedIndexChanged += Cmb_TipoAnexo_SelectedIndexChanged;
            if (TipoVista == "V")
            {
                btn_Editar.Visible = true;
                habilitarCampos(false, false);
                setDatosVista(MantenimientoPlanContable.objCuentaContable);
            }
            else
            {
                btn_Editar.Visible = false;
                habilitarCampos(true, true);
                Operacion = "N";

            }
            txt_Tipo.Text = cmb_TipoCuenta.SelectedValue.ToString();

            if (cmb_Moneda.SelectedValue == null)
            {
                txt_MonedaCod.Text = "";
            }
            else
            {
                txt_MonedaCod.Text = cmb_Moneda.SelectedValue.ToString();
            }
            if (cmb_NivelSaldo.SelectedValue == null)
            {
                txt_Nivel.Text = "";
            }
            else
            {
                txt_Nivel.Text = cmb_NivelSaldo.SelectedValue.ToString();
            }
            if (cmb_TipoAnexo.SelectedValue == null)
            {
                txt_Anexo.Text = "";
            }
            else
            {
                txt_Anexo.Text = cmb_TipoAnexo.SelectedValue.ToString();
            }
        }
        void setDatosVista(CuentaContable obj)
        {
            txt_Cuenta.Text = obj.Cuenta;
            txt_Descripcion.Text = obj.Descripcion;
            cmb_Moneda.SelectedValue = obj.MonedaCod;
            cmb_NivelSaldo.SelectedValue = obj.Nivel;
            cmb_TipoAnexo.SelectedValue = obj.Anexo;
            cmb_TipoCuenta.SelectedValue = obj.TipoCuentaCod;
        }

        private void Cmb_TipoAnexo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_TipoAnexo.SelectedValue == null)
            {
                txt_Anexo.Text = "";
            }
            else
            {
                txt_Anexo.Text = cmb_TipoAnexo.SelectedValue.ToString();
            }
        }

        private void Cmb_NivelSaldo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_NivelSaldo.SelectedValue == null)
            {
                txt_Nivel.Text = "";
            }
            else
            {
                txt_Nivel.Text = cmb_NivelSaldo.SelectedValue.ToString();
            }
        }

        private void Cmb_Moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Moneda.SelectedValue == null)
            {
                txt_MonedaCod.Text = "";
            }
            else
            {
                txt_MonedaCod.Text = cmb_Moneda.SelectedValue.ToString();
            }
        }

        private void Cmb_TipoCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            objTipoCC = (TipoCuentaContable)cmb_TipoCuenta.SelectedItem;
            txt_Tipo.Text = objTipoCC.Codigo;
        }
        void cmbAnexo()
        {
            objListAnexoContable =  objAnexoContableDAO.getComboAnexo();
            cmb_TipoAnexo.DataSource = objListAnexoContable;
            cmb_TipoAnexo.ValueMember = "Codigo";
            cmb_TipoAnexo.DisplayMember = "Descripcion";
            cmb_TipoAnexo.Refresh();
        }
        void cmbNivel()
        {
            objListNivelContable = objNivelContableDAO.getComboNivel();
            cmb_NivelSaldo.DataSource = objListNivelContable;
            cmb_NivelSaldo.ValueMember = "Codigo";
            cmb_NivelSaldo.DisplayMember = "Descripcion";
            cmb_NivelSaldo.Refresh();
        }
        void cmbTipoCuentaContable()
        {
            objListTipoCC = objTipoCCDAO.getComboTipoCuentaContable();
            cmb_TipoCuenta.DataSource = objListTipoCC;
            cmb_TipoCuenta.ValueMember = "Codigo";
            cmb_TipoCuenta.DisplayMember = "Descripcion";
            cmb_TipoCuenta.Refresh();
        }
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            MantenimientoPlanContable check = new MantenimientoPlanContable();
            check.Show();
            this.Close();
        }
        public void comboMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            String msg = "";
            objCuentaContable = new CuentaContable();
            objCuentaContable.Anexo = txt_Anexo.Text;
            objCuentaContable.Cuenta = txt_Cuenta.Text;
            objCuentaContable.Descripcion = txt_Descripcion.Text;
            objCuentaContable.MonedaCod = txt_MonedaCod.Text;
            objCuentaContable.Nivel = txt_Nivel.Text;
            objCuentaContable.TipoCuentaCod = txt_Tipo.Text;
            
            if (Operacion =="N")
            {
                msg=objCuentaContableDAO.insertarCuentaTable(objCuentaContable,"CPURE");
            }else if (Operacion == "M")
            {
                msg = objCuentaContableDAO.updateCuentaTable(objCuentaContable, "CPURE");
            }
            if (msg=="true")
            {
                MessageBox.Show("Guardado Correctamente");
            }else
            {
                MessageBox.Show("Error: " + msg);
            }
            Operacion = "Q";
        }
        void habilitarCampos(bool bhabilita, bool bhabilita2)
        {
            cmb_Moneda.Enabled = bhabilita;
            cmb_NivelSaldo.Enabled = bhabilita;
            cmb_TipoAnexo.Enabled = bhabilita;
            cmb_TipoCuenta.Enabled = bhabilita;
            txt_Cuenta.Enabled = bhabilita2;
            txt_Descripcion.Enabled = bhabilita;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";

            habilitarCampos(true, false);
        }
    }
}
