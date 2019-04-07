using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Caja
{
    public partial class ListaCajaChica : Form
    {
        public static List<CajaCab> objListCajaCab = new List<CajaCab>();
        CajaCab objCajaCab; 
        CajaDAO objCajaDAO;

        int index = 0; 
        public ListaCajaChica()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Caja Chica";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objCajaCab = new CajaCab();
            objCajaDAO = new CajaDAO();
            gridParams();
            objListCajaCab = objCajaDAO.getCaja(DateTime.Now.Year.ToString(), Ventas.UNIDADNEGOCIO );
            grd_Facturas.DataSource = objListCajaCab;
            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
            grd_Facturas.DoubleClick += Grd_Facturas_DoubleClick;
            txt_Monto.TextChanged += Txt_Monto_TextChanged;
            validarAbrirCaja();


        }

        void validarAbrirCaja()
        {
            int contador = 0;
            for (int i=0; i<objListCajaCab.Count; i++)
            {
                if (objListCajaCab[i].Estado =="A")
                {
                    contador++;
                }
            }
            if (contador==0)
            {
                btn_Abrir.Visible = true;
            }else
            {
                btn_Abrir.Visible = false;
            }
        }
        private void Txt_Monto_TextChanged(object sender, EventArgs e)
        {
            try
            {
               txt_Reembolso.Text =  (convertToDouble(txt_Monto.Text) - convertToDouble(txt_Saldo.Text)).ToString();
               
            }
            catch
            {

            }
        }

        private void Grd_Facturas_DoubleClick(object sender, EventArgs e)
        {
            objCajaCab = new CajaCab();
            index = grd_Facturas.SelectedCells[0].RowIndex;
            objCajaCab = objListCajaCab[index];
            CajaChica check = new CajaChica(objCajaCab);
            this.Hide();
            check.Show();
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objCajaCab = new CajaCab();
            index = grd_Facturas.SelectedCells[0].RowIndex;
            objCajaCab = objListCajaCab[index];
            txt_Gastos.Text = objCajaCab.Gasto.ToString();
            txt_Monto.Text = objCajaCab.Monto.ToString();
            txt_Reembolso.Text = objCajaCab.Reembolso.ToString();
            txt_Saldo.Text = objCajaCab.Reembolso.ToString();
            txt_NroCaja.Text = objCajaCab.NumeroCaja;
            txt_FechaIni.Text = objCajaCab.FechaApertura.ToString("dd/MM/yyyy");
            if (objCajaCab.FechaCierre > DateTime.Now.AddYears(-1))
            {
                txt_FechaFin.Text = objCajaCab.FechaCierre.ToString("dd/MM/yyyy");
            }
            if (objCajaCab.Estado =="A")
            {
                btn_Cerrar.Enabled = true;
            }else
            {
                btn_Cerrar.Enabled = false;
            }
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("LCC");
        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° Caja";
            idColumn1.DataPropertyName = "NumeroCaja";
            idColumn1.Width = 75;
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Fecha Inicio";
            idColumn2.DataPropertyName = "FechaApertura";
            idColumn2.Width = 100;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Reembolso";
            idColumn3.DataPropertyName = "Reembolso";
            idColumn3.Width = 80;
            idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Saldo Caja";
            idColumn4.DataPropertyName = "Saldo";
            idColumn4.Width = 100;
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Monto";
            idColumn5.DataPropertyName = "Monto";
            idColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            idColumn5.Width = 80;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Gastos";
            idColumn6.DataPropertyName = "Gasto";
            idColumn6.Width = 80;
            idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Disponible";
            idColumn7.DataPropertyName = "Disponible";
            idColumn7.Width = 80;
            idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Fecha Cierre";
            idColumn8.DataPropertyName = "FechaCierre";
           // idColumn8.DefaultCellStyle.Format = "dd/MM/yyyy";
            idColumn8.Width = 100;
            grd_Facturas.Columns.Add(idColumn8);
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            bool bupdate;
            objCajaCab = new CajaCab();
            index = grd_Facturas.SelectedCells[0].RowIndex;
            objCajaCab = objListCajaCab[index];
            DialogResult dialogResult = MessageBox.Show("Desea Cerrar la Caja?", "Cerrar Caja", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                objCajaCab.FechaCierre = Convert.ToDateTime( DateTime.Now.ToString("dd/MM/yyyy"));
                objCajaCab.Estado = "T";

                bupdate = objCajaDAO.cerrarCaja(objCajaCab.FechaCierre,objCajaCab.NumeroCaja, objCajaCab.CodEnt, Ventas.UsuarioSession);
                if (bupdate)
                {
                    MessageBox.Show("Se cerró la caja");
                    objListCajaCab[index] = objCajaCab;
                    grd_Facturas.DataSource = null;
                    grd_Facturas.DataSource = objListCajaCab;
                    grd_Facturas.Refresh();
                    limpiarCampos();
                    txt_Saldo.Text = objCajaCab.Disponible.ToString();
                    txt_FechaIni.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    txt_Monto.Enabled = true;
                    btn_Abrir.Visible = true;
                    txt_Gastos.Text = "0";
                    btn_Cerrar.Enabled = false;
                    txt_NroCaja.Text = objCajaDAO.getCorrelativoCaja(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString());

                }
                else
                {
                    MessageBox.Show("Hubo un problema al cerrar la caja");
                }

            }
            else if (dialogResult == DialogResult.No)
            {
      
            }
        }
        void limpiarCampos()
        {
            txt_Monto.Text = "";
            txt_NroCaja.Text = "";
            txt_FechaFin.Text = "";
            txt_FechaIni.Text = "";
            txt_Gastos.Text = "";
            txt_Saldo.Text = "";
            txt_Reembolso.Text = "";
        }
        public Double convertToDouble(String conv)
        {
            try
            {
                char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
                if (!conv.Contains(","))
                    return double.Parse(conv, CultureInfo.InvariantCulture);
                else
                    return Convert.ToDouble(conv.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        private void btn_Abrir_Click(object sender, EventArgs e)
        {
            bool insert;
            btn_Abrir.Visible = false;
            objCajaCab = new CajaCab();
            objCajaCab.CodEnt = Ventas.UNIDADNEGOCIO;
            objCajaCab.Estado = "A";
            objCajaCab.FechaApertura = Convert.ToDateTime(txt_FechaIni.Text);
            objCajaCab.Gasto = 0;
            objCajaCab.Monto =  convertToDouble(txt_Monto.Text);
            objCajaCab.NumeroCaja = txt_NroCaja.Text;
            objCajaCab.Periodo = DateTime.Now.Year.ToString();
            objCajaCab.Reembolso = convertToDouble(txt_Reembolso.Text);
            objCajaCab.Saldo = convertToDouble(txt_Saldo.Text);
            objCajaCab.Usuario = Ventas.UsuarioSession;
            objCajaCab.Disponible= objCajaCab.Monto- objCajaCab.Gasto;
            insert = objCajaDAO.insertarCaja(objCajaCab);
            if (insert)
            {
                MessageBox.Show("Se abrió una nueva Caja");
                objListCajaCab.Add(objCajaCab);
                grd_Facturas.DataSource = null;
                grd_Facturas.DataSource = objListCajaCab;
                grd_Facturas.Refresh();
                limpiarCampos();
                txt_Monto.Enabled = false;
                btn_Cerrar.Enabled = false;
            }else
            {
                MessageBox.Show("Ocurrió un problema al aperturar una nueva Caja");
            }
          

        }
    }
}
