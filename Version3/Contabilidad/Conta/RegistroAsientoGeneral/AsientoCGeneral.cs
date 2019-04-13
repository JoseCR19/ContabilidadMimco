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
    public partial class AsientoCGeneral : Form
    {
        static int index;
        public static List<AsientoDetalle> objListaAsientoDetalle = new List<AsientoDetalle>();
        AsientoDAO objAsientoDao;
        Asiento objAsiento;
        AsientoDetalle objAsientoDetalle;
        public AsientoCGeneral()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Asientos Contables";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objAsiento = new Asiento();
            objAsientoDao = new AsientoDAO();
            txt_TipoAsiento.Text = RegistrarAsientoGeneral.tipoAsiento;
           // txt_Debe.Text = RegistrarAsientoGeneral.totalComprobante.ToString();
            //txt_Haber.Text = RegistrarAsientoGeneral.totalComprobante.ToString();
            txt_Moneda.Text = RegistrarAsientoGeneral.moneda;
            txt_Fecha.Text = RegistrarAsientoGeneral.fechaComprobante;
            txt_Correlativo.Text = objAsientoDao.getCorrelativoAsientoVenta(txt_Fecha.Text, txt_TipoAsiento.Text);
            cmbCuenta();
            gridParams();

        }
        void cmbCuenta()
        {
            List<TipoCuenta> objListCuenta = new List<TipoCuenta>();
            TipoCuenta objCuenta = new TipoCuenta();
            objCuenta.Id = "D";
            objCuenta.Descripcion = "Debe";
            objListCuenta.Add(objCuenta);
            objCuenta = new TipoCuenta();
            objCuenta.Id = "H";
            objCuenta.Descripcion = "Haber";
            objListCuenta.Add(objCuenta);
            cmb_Cuenta.DataSource = objListCuenta;
            cmb_Cuenta.ValueMember = "Id";
            cmb_Cuenta.DisplayMember = "Descripcion";
            cmb_Cuenta.Refresh();

        }

        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Cuenta";
            idColumn0.Width = 120;
            idColumn0.DataPropertyName = "Cuenta";
            grd_Facturas.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Tipo";
            idColumn1.Width = 60;
            idColumn1.DataPropertyName = "TipoImporte";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Importe";
            idColumn2.Width = 100;
            idColumn2.DataPropertyName = "Importe";
            grd_Facturas.Columns.Add(idColumn2);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Documento";
            idColumn4.Width = 140;
            idColumn4.DataPropertyName = "Documento";
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Fecha";
            idColumn5.Width = 120;
            idColumn5.DataPropertyName = "Fecha";
            grd_Facturas.Columns.Add(idColumn5);

        }
        void generarDetalle()
        {
            objAsientoDetalle = new AsientoDetalle();
            objAsientoDetalle.Correlativo = txt_Correlativo.Text;
            objAsientoDetalle.Cuenta = "";
            objAsientoDetalle.Documento = "";
            objAsientoDetalle.Fecha = "";
            objAsientoDetalle.FechaDoc = txt_Fecha.Text;
            objAsientoDetalle.FechaVcto = "";
            objAsientoDetalle.Importe = RegistrarAsientoGeneral.totalComprobante;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_Cuenta.Text))
            {
                MessageBox.Show("Debe ingresar una Cuenta");
                return;
            }
            if (String.IsNullOrEmpty(txt_Importe.Text))
            {
                MessageBox.Show("Debe ingresar el Importe");
                return;
            }
            if (String.IsNullOrEmpty(txt_Documento.Text))
            {
                MessageBox.Show("Debe ingresar Documento");
                return;
            }
            objAsientoDetalle = new AsientoDetalle();
            objAsientoDetalle.Correlativo = txt_Correlativo.Text;
            objAsientoDetalle.Cuenta = txt_Cuenta.Text;
            objAsientoDetalle.Documento = txt_Documento.Text;
            objAsientoDetalle.Fecha = txt_Fecha.Text;
            objAsientoDetalle.TipoImporte = cmb_Cuenta.SelectedValue.ToString();
            objAsientoDetalle.TipoAsiento = txt_TipoAsiento.Text;
            objAsientoDetalle.Importe = objAsientoDao.convertToDouble(txt_Importe.Text);
            objListaAsientoDetalle.Add(objAsientoDetalle);
            grd_Facturas.DataSource = null;

            grd_Facturas.DataSource = objListaAsientoDetalle;
            grd_Facturas.Refresh();
            txt_Importe.Text = "";
            txt_Cuenta.Text = "";
            txt_Documento.Text = "";
            sumatorias();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            RegistrarAsientoGeneral formAsient = new RegistrarAsientoGeneral();
            
            formAsient.Show();
            this.Close();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            bool insert, bdetalle;
            objAsiento = new Asiento();
            objAsiento.Correlativo = txt_Correlativo.Text;
            objAsiento.Debe = objAsientoDao.convertToDouble(txt_Debe.Text);
            objAsiento.Haber = objAsientoDao.convertToDouble(txt_Haber.Text);
            objAsiento.TipoAsiento = txt_TipoAsiento.Text;
            objAsiento.Fecha = txt_Fecha.Text;
            objAsiento.MonedaCod = RegistrarAsientoGeneral.monedaCod;
            insert = objAsientoDao.insertarAsientoCab(objAsiento);
            if (insert)
            {

            }
            else
            {
                MessageBox.Show("Hubo un error al guardar");
                return;
            }
            for (int i = 0; i < objListaAsientoDetalle.Count; i++)
            {
                bdetalle= objAsientoDao.insertarAsientoDet(objListaAsientoDetalle[i]);
                if (bdetalle)
                {

                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar");
                    return;
                }
            }
            MessageBox.Show("Se guardó con éxito");

            ContabilidadMenu.formContabilidad.setEnabledItems("AG");
            this.Close();
        }
        void sumatorias()
        {
            List<AsientoDetalle> objListSumD = new List<AsientoDetalle>();
            List<AsientoDetalle> objListSumH = new List<AsientoDetalle>();
            objListSumD = objListaAsientoDetalle;
            objListSumH = objListaAsientoDetalle;
            txt_Debe.Text = objListSumD.Where(x => x.TipoImporte == "D").Sum(y => y.Importe).ToString();
            txt_Haber.Text = objListSumH.Where(x => x.TipoImporte == "H").Sum(y => y.Importe).ToString();
        }
    }
}
