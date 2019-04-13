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


namespace Conta.RegistroPagos
{
    public partial class AsientoCCajaChica : Form
    {
        public static CajaDet objCajadet = new CajaDet();
       Asiento objAsiento;
        static int index;
        public static List<AsientoDetalle> objListaAsientoDetalle = new List<AsientoDetalle>();
        AsientoDAO objAsientoDao;
        AsientoDetalle objAsientoDetalle;
        String Operacion = "Q";
        public AsientoCCajaChica(CajaDet obj)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Asientos Contables";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objAsiento = new Asiento();
            objAsientoDao = new AsientoDAO();
            txt_TipoAsiento.Text = "01";
            objCajadet = obj;
            txt_Correlativo.Text = objAsientoDao.getCorrelativoAsientoVenta(objCajadet.FechaOperacion.ToString("dd/MM/yyyy"), txt_TipoAsiento.Text);
            gridParams();
            cmbCuenta();
            cmbDocumento();
            txt_Fecha.Text = objCajadet.FechaOperacion.ToString("dd/MM/yyyy");
            txt_Moneda.Text = objCajadet.MonedaCod;

            grd_Facturas.CellClick += Grd_Facturas_CellClick;
            objListaAsientoDetalle = objAsientoDao.getGenerarDetalleCaja(objCajadet.NumeroCaja, objCajadet.NumeroOperacion, objCajadet.CodEnt);
            grd_Facturas.DataSource = objListaAsientoDetalle;
            grd_Facturas.Refresh();

            sumatorias();
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = grd_Facturas.SelectedCells[0].RowIndex;
            objAsientoDetalle = new AsientoDetalle();
            objAsientoDetalle = objListaAsientoDetalle[index];
            txt_Cuenta.Text = objAsientoDetalle.Cuenta;
            txt_Documento.Text = objAsientoDetalle.Documento;
            txt_Importe.Text = objAsientoDetalle.Importe.ToString();
            cmb_Cuenta.SelectedValue = objAsientoDetalle.TipoImporte;
            cmb_Documento.SelectedValue = objAsientoDetalle.TipDocCodigo;
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
        void cmbDocumento()
        {
            List<TipoDocumentoContabilidad> objListTipDocu = new List<TipoDocumentoContabilidad>();
            TipoDocumentoContabilidad obj = new TipoDocumentoContabilidad();
            obj.Codigo = "01";
            obj.Descripcion = "Factura";
            objListTipDocu.Add(obj);
            obj = new TipoDocumentoContabilidad();
            obj.Codigo = "03";
            obj.Descripcion = "Boleta";
            objListTipDocu.Add(obj);
            obj = new TipoDocumentoContabilidad();
            obj.Codigo = "07";
            obj.Descripcion = "Nota de Crédito";
            objListTipDocu.Add(obj);
            obj = new TipoDocumentoContabilidad();
            obj.Codigo = "08";
            obj.Descripcion = "Nota de Débito";
            objListTipDocu.Add(obj);

            cmb_Documento.DataSource = objListTipDocu;
            cmb_Documento.ValueMember = "Codigo";
            cmb_Documento.DisplayMember = "Descripcion";
            cmb_Documento.Refresh();

        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Cuenta";
            idColumn0.Width = 60;
            idColumn0.DataPropertyName = "Cuenta";
            grd_Facturas.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Tipo";
            idColumn1.Width = 40;
            idColumn1.DataPropertyName = "TipoImporte";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Importe";
            idColumn2.Width = 100;
            idColumn2.DataPropertyName = "Importe";
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Tipo Documento";
            idColumn3.Width = 120;
            idColumn3.DataPropertyName = "TipoDoc";
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Documento";
            idColumn4.Width = 120;
            idColumn4.DataPropertyName = "Documento";
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Fecha";
            idColumn5.Width = 80;
            idColumn5.DataPropertyName = "Fecha";
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Fecha Vcto";
            idColumn6.Width = 80;
            idColumn6.DataPropertyName = "FechaVcto";
            grd_Facturas.Columns.Add(idColumn6);
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            btn_SaveData.Enabled = false;
            bool insert, insertDet = false;
            objAsiento = new Asiento();
            objAsiento.Correlativo = txt_Correlativo.Text;
            objAsiento.Debe = objAsientoDao.convertToDouble( txt_Debe.Text);
            objAsiento.Fecha = txt_Fecha.Text;
            objAsiento.Haber = objAsientoDao.convertToDouble(txt_Haber.Text);
            objAsiento.MonedaCod = "PEN";


            objAsiento.TipoAsiento = txt_TipoAsiento.Text;

            insert = objAsientoDao.insertarAsientoCab(objAsiento);
            if (insert)
            {

            }
            else
            {
                MessageBox.Show("Hubo un error al Guardar");
                return;
            }
            for (int i = 0; i < objListaAsientoDetalle.Count; i++)
            {
                //objListaAsientoDetalle[i].NumReg = objDocumentoCab.NumeroRegistro;
                objListaAsientoDetalle[i].Correlativo = txt_Correlativo.Text;
                objListaAsientoDetalle[i].FechaDoc = objCajadet.FechaEmision.ToString("dd/MM/yyyy");
                objListaAsientoDetalle[i].Anexo = objCajadet.Ruc;
                insertDet = objAsientoDao.insertarAsientoDet(objListaAsientoDetalle[i]);
                if (insertDet)
                {

                    objAsientoDao.updateEstadoAsientoCompra(objListaAsientoDetalle[i].NumReg);
                }
                else
                {
                    MessageBox.Show("Hubo un error al Guardar");
                    return;
                }
            }
            if (insertDet)
            {
                MessageBox.Show("Se creó el Asiento Contable");
            }
            btn_SaveData.Enabled = true;
            RegistrarCajaChica formAsient = new RegistrarCajaChica();
            formAsient.Show();
            this.Close();
        }
        void habilitarCampos(bool bhabilita)
        {
            txt_Cuenta.Enabled = bhabilita;
            txt_Importe.Enabled = bhabilita;
            cmb_Cuenta.Enabled = bhabilita;
            cmb_Documento.Enabled = bhabilita;
            txt_Documento.Enabled = bhabilita;
        }
        void limpiaCampos()
        {
            txt_Cuenta.Text = "";
            txt_Importe.Text = "";

            txt_Documento.Text = "";
        }
        void habilitaBoton(bool bhabilita1, bool bhabilita2)
        {
            btn_Add.Enabled = bhabilita1;
            btn_Guardar.Enabled = bhabilita2;
            btn_Editar.Enabled = bhabilita1;
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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Operacion = "N";
            habilitarCampos(true);
            habilitaBoton(false, true);
            limpiaCampos();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";
            habilitarCampos(true);
            habilitaBoton(false, true);
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

            objAsientoDetalle = new AsientoDetalle();
            objAsientoDetalle.Anexo = objCajadet.Ruc;
            objAsientoDetalle.Correlativo = txt_Correlativo.Text;
            objAsientoDetalle.Cuenta = txt_Cuenta.Text;
            objAsientoDetalle.Documento = txt_Documento.Text;
            objAsientoDetalle.Fecha = txt_Fecha.Text;
            objAsientoDetalle.FechaDoc = objCajadet.FechaEmision.ToString("dd/MM/yyyy");
            objAsientoDetalle.FechaVcto = objCajadet.FechaEmision.ToString("dd/MM/yyyy");
            objAsientoDetalle.Importe = objAsientoDao.convertToDouble(txt_Importe.Text);
           // objAsientoDetalle.NumReg = objCajadet.NumeroRegistro;
            objAsientoDetalle.TipDocCodigo = cmb_Documento.SelectedValue.ToString();
            objAsientoDetalle.TipoImporte = cmb_Cuenta.SelectedValue.ToString();
            objAsientoDetalle.TipoDoc = cmb_Documento.Text;

            if (Operacion == "M")
            {
                objListaAsientoDetalle[index] = objAsientoDetalle;
            }
            else
            {
                objListaAsientoDetalle.Add(objAsientoDetalle);
            }
            limpiaCampos();
            grd_Facturas.DataSource = null;
            grd_Facturas.DataSource = objListaAsientoDetalle;
            grd_Facturas.Refresh();
            sumatorias();
            habilitaBoton(true, false);
            habilitarCampos(false);
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            RegistrarCajaChica formCaja = new RegistrarCajaChica();
            formCaja.Show();
            this.Close();
        }
    }
}
