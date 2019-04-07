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

namespace Contabilidad.Mantenimiento
{
    public partial class MantenimientoCheque : Form
    {
        List<CuentaBanco> objListaBanco = new List<CuentaBanco>();
        List<Moneda> objListMoneda = new List<Moneda>();
        List<Cheque> objListaChequera = new List<Cheque>();


        BancoDAO objBancoDao;
        MonedaDAO objMonedaDao;
        ChequeDAO objChequeraDao;


        Cheque objChequera;

        String operacion = "Q";
        int index = 0;

        public MantenimientoCheque()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "MANTENIMIENTO CHEQUE";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);

            objBancoDao = new BancoDAO();
            objMonedaDao = new MonedaDAO();
            objChequeraDao = new ChequeDAO();

            objChequera = new Cheque();

            cmbBanco();
            cmbMoneda(cmb_Banco.SelectedValue.ToString());
            gridParams();

            txt_NroCuenta.Text = cargarNroCuenta(cmb_Banco.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString());

            cmb_Banco.SelectedIndexChanged += Cmb_Banco_SelectedIndexChanged;
            cmb_Moneda.SelectedIndexChanged += Cmb_Moneda_SelectedIndexChanged;
            grd_Cheque.CellClick += Grd_Cheque_CellClick;


            objListaChequera = objChequeraDao.getChequera(Ventas.UNIDADNEGOCIO);
            grd_Cheque.DataSource = objListaChequera;
            grd_Cheque.Refresh();


        }

        private void Grd_Cheque_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = grd_Cheque.SelectedCells[0].RowIndex;
                objChequera = objListaChequera[index];
                txt_ChequeInicio.Text = objChequera.NroChequeInicio;
                txt_ChequeFin.Text = objChequera.NroChequeFin;
                txt_NroCuenta.Text = objChequera.CuentaBanco;
                txt_ChequeActual.Text = objChequera.NroChequeActual;
                cmb_Banco.SelectedValue = objChequera.BancoCod;
                cmb_Moneda.SelectedValue = objChequera.MonedaCod;
            }catch(Exception ex)
            {

            }
        }

        public void gridParams()
        {
            grd_Cheque.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Banco";
            idColumn1.DataPropertyName = "Banco";
            idColumn1.Width = 180;
            grd_Cheque.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Moneda";
            idColumn2.DataPropertyName = "MonedaCod";
            idColumn2.Width = 60;
            grd_Cheque.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "N° Cuenta";
            idColumn3.DataPropertyName = "CuentaBanco";
            idColumn3.Width = 180;
            grd_Cheque.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "N° Cheque Inicio";
            idColumn5.DataPropertyName = "NroChequeInicio";
            idColumn5.Width = 110;
            grd_Cheque.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "N° Cheque Fin";
            idColumn6.DataPropertyName = "NroChequeFin";
            idColumn6.Width = 110;
            grd_Cheque.Columns.Add(idColumn6);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "N° Cheque Actual";
            idColumn4.DataPropertyName = "NroChequeActual";
            idColumn4.Width = 120;
           
            
            grd_Cheque.Columns.Add(idColumn4);


            foreach (DataGridViewColumn col in grd_Cheque.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

        }

        private void Cmb_Moneda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txt_NroCuenta.Text = cargarNroCuenta(cmb_Banco.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                txt_NroCuenta.Text = "";
            }
        }

        String cargarNroCuenta(String codBanco, String moneda)
        {
           return objBancoDao.getCuentaBanco(Ventas.UNIDADNEGOCIO, codBanco,moneda);

        }

        private void Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMoneda(cmb_Banco.SelectedValue.ToString());
        }

        void cmbBanco()
        {
            objListaBanco = objBancoDao.getListaBanco(Ventas.UNIDADNEGOCIO);
            cmb_Banco.DataSource = objListaBanco;
            cmb_Banco.DisplayMember = "Descripcion";
            cmb_Banco.ValueMember = "Codigo";
            cmb_Banco.Refresh();
        }

        void cmbMoneda(String codbanco)
        {
            objListMoneda = objMonedaDao.listarMonedaBanco(Ventas.UNIDADNEGOCIO, codbanco);
            cmb_Moneda.DataSource = null;
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("MC");
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            btn_Guardar.Enabled = false;
            operacion = "G";
            bool binsertar;
            objChequera = new Cheque();
            objChequera.BancoCod = cmb_Banco.SelectedValue.ToString();
            objChequera.CodEnt = Ventas.UNIDADNEGOCIO;
            objChequera.CuentaBanco = txt_NroCuenta.Text;
            objChequera.MonedaCod = cmb_Moneda.SelectedValue.ToString();
            objChequera.NroChequeInicio = txt_ChequeInicio.Text;
            objChequera.NroChequeFin = txt_ChequeFin.Text;
            binsertar = objChequeraDao.insertChequera(objChequera, Ventas.UsuarioSession);
            if (binsertar)
            {
                MessageBox.Show("Se guardo parámetros de cheque");
                objListaChequera = objChequeraDao.getChequera(Ventas.UNIDADNEGOCIO);
                grd_Cheque.DataSource = null;
               grd_Cheque.DataSource = objListaChequera;
                grd_Cheque.Refresh();
            }
            else
            {
                MessageBox.Show("Hubo un problema al guardar");
            }
            btn_Guardar.Enabled = true;
            habilitarBotones(true, false);
            habilitaCampo(false);
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false, true);
            habilitaCampo(true); ;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            habilitarBotones(false, true);
            habilitaCampo(true);
        }

        void habilitarBotones(bool bhabilita1, bool bhabilita2)
        {
            btn_Add.Enabled = bhabilita1;
            btn_Editar.Enabled = bhabilita1;
            btn_Guardar.Enabled = bhabilita2;
        }
        void habilitaCampo(bool bhabilita1)
        {
            cmb_Banco.Enabled = bhabilita1;
            cmb_Moneda.Enabled = bhabilita1;
            txt_ChequeInicio.Enabled = bhabilita1;
            txt_ChequeFin.Enabled = bhabilita1;
        }
    }
}
