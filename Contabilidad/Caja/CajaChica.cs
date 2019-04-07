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
    public partial class CajaChica : Form
    {
        public static CajaChica formCajachica;
        public List<CajaDet> objListCajaDet = new List<CajaDet>();
        List<Moneda> objListMoneda = new List<Moneda>();
        List<TipoDocumentoEmision> objListTipoDocEmision = new List<TipoDocumentoEmision>();

        List<CentroLabor> objListCentroLabor = new List<CentroLabor>();
        List<TipoGastos> objListaTipoGastos = new List<TipoGastos>();
        List<TipoGastos> objListaTipoGastosBusqueda = new List<TipoGastos>();
        List<OtDTO> objListaOT = new List<OtDTO>();
        List<OtDTO> objListaOTBusqueda = new List<OtDTO>();
        List<Proveedor> objListaProveedor = new List<Proveedor>();
        List<Proveedor> objListaProveedorBusqueda = new List<Proveedor>();


        MonedaDAO objMonedaDao;
        CajaDAO objCajaDAO;
        CajaCab objCajaCab;
        CajaDet objCajaDet;
        LoVDAO objLoVDao;

        int index = 0;
        String Operacion = "Q";

        public CajaChica(CajaCab obj)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Caja Chica";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            formCajachica = this;
            objCajaCab = new CajaCab();
            objCajaDAO = new CajaDAO();
            objMonedaDao = new MonedaDAO();
            objCajaDet = new CajaDet();
            objLoVDao = new LoVDAO();
            objCajaCab = obj;
            txt_Disponible.Text = obj.Disponible.ToString();
            txt_FechaIni.Text = obj.FechaApertura.ToString("dd/MM/yyyy");
            txt_Monto.Text = obj.Monto.ToString();
            txt_NroCaja.Text = obj.NumeroCaja;
            gridParams();
            cmbMoneda();
            cmbTipoDocu();
            cmbCentroLabor();
            txt_SerieDoc.MaxLength = 4;
            objListCajaDet = objCajaDAO.getCajaDet(objCajaCab.NumeroCaja, Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListCajaDet;
            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
            txt_TipoGastoCod.KeyDown += Txt_TipoGastoCod_KeyDown;
            
            
            txt_ProvRuc.KeyDown += Txt_ProvRuc_KeyDown;
            txt_NroOt.KeyDown += Txt_NroOt_KeyDown;
            txt_NroOt.TextChanged += Txt_NroOt_TextChanged;
            txt_TipoGastoCod.TextChanged += Txt_TipoGastoCod_TextChanged;
            txt_ProvRuc.TextChanged += Txt_ProvRuc_TextChanged;
            cargarListas();
            dpick_FechaOperacion.ValueChanged += Dpick_FechaOperacion_ValueChanged;
            tipoCambio(dpick_FechaOperacion.Value.ToShortDateString());
        }

        private void Dpick_FechaOperacion_ValueChanged(object sender, EventArgs e)
        {
            tipoCambio(dpick_FechaOperacion.Value.ToShortDateString());
        }

        public void tipoCambio(String date)
        {
            txt_TipoCambio.Text = objMonedaDao.getTipoCambioCompra(date).ToString().PadRight(5, '0');
        }
        private void Txt_ProvRuc_TextChanged(object sender, EventArgs e)
        {

            objListaProveedorBusqueda = objListaProveedor;
            objListaProveedorBusqueda = objListaProveedorBusqueda.Where(x => x.ProveedorNDoc.Trim().Equals(txt_ProvRuc.Text.Trim())).ToList();
            try
            {
                txt_ProvNombre.Text = objListaProveedorBusqueda[0].ProveedorRazonSocial;
                txt_TipoPersona.Text = objListaProveedorBusqueda[0].ProveedorTipo;
            }
            catch
            {
                txt_ProvNombre.Text = "";
                txt_TipoPersona.Text = "";
            }
        }
        public void setDatosDoc(String serie, String num, Double monto)
        {
            txt_SerieDoc.Text = serie;
            txt_NroDoc.Text = num;
            txt_Monto.Text = monto.ToString();
        }
        private void Txt_ProvRuc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoV.LoVProveedor check = new LoV.LoVProveedor();
                check.Show();
            }
        }
        public void setProveedor(String Ruc, String Razon,String tipoPer)
        {
            txt_ProvRuc.Text = Ruc;
            txt_ProvNombre.Text = Razon;
            txt_TipoPersona.Text = tipoPer;
        }

        void cargarListas()
        {
            objListaTipoGastos = objLoVDao.getLovTipoGastos();
            objListaOT = objLoVDao.getLovOt(Ventas.UNIDADNEGOCIO);
            objListaProveedor = objLoVDao.getLovProveedorTotal(Ventas.UNIDADNEGOCIO);

        }
        private void Txt_NroOt_TextChanged(object sender, EventArgs e)
        {
            objListaOTBusqueda = objListaOT;
            objListaOTBusqueda = objListaOTBusqueda.Where(x => x.NumeroOt.Trim().Equals(txt_NroOt.Text.Trim())).ToList();
            try
            {
                txt_NomOt.Text = objListaOTBusqueda[0].Descripcion;
                txt_codot.Text = objListaOTBusqueda[0].CodigoOt;
            }
            catch
            {

            }
        }

        private void Txt_NroOt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoV.LoVOt check = new LoV.LoVOt();
                check.Show();
            }
        }

        private void Txt_TipoGastoCod_TextChanged(object sender, EventArgs e)
        {
            objListaTipoGastosBusqueda = objListaTipoGastos;
            objListaTipoGastosBusqueda= objListaTipoGastosBusqueda.Where(x => x.Codigo.Trim().Equals(txt_TipoGastoCod.Text.Trim())).ToList();
            try
            {
                txt_TipoGasto.Text = objListaTipoGastosBusqueda[0].Descripcion;
                txt_CuentaContable.Text = objListaTipoGastosBusqueda[0].CuentaContable;
            }
            catch
            {

            }
         }

        private void Txt_TipoGastoCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoV.grd_Gastos check = new LoV.grd_Gastos();
                check.Show();
            }
        }

        public void setGasto(String cod, String gasto, String CuentaContable)
        {
            txt_TipoGastoCod.Text = cod;
            txt_TipoGasto.Text = gasto;
            txt_CuentaContable.Text = CuentaContable;
        }
        public void setOt(String nro, String descripcion, String cod)
        {
            txt_NroOt.Text = nro;
            txt_NomOt.Text = descripcion;
            txt_codot.Text = cod;
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                objCajaDet = new CajaDet();
                index = grd_Facturas.SelectedCells[0].RowIndex;
                objCajaDet = objListCajaDet[index];
                txt_Detalle.Text = objCajaDet.DescripcionOperacion;
                txt_Direccion.Text = objCajaDet.Distrito;
                dpick_FechaDoc.Value = objCajaDet.FechaEmision;
                txt_Importe.Text = objCajaDet.Total.ToString();
                txt_Motivo.Text = objCajaDet.Motivo;
                txt_NroOt.Text = objCajaDet.NroOt;
                txt_NroDoc.Text = objCajaDet.NroDocRef;
                txt_TipoGastoCod.Text = objCajaDet.CodGas;
                dpick_FechaOperacion.Value = objCajaDet.FechaOperacion;
                txt_ProvRuc.Text = objCajaDet.Ruc;
                txt_SerieDoc.Text = objCajaDet.SerieDocRef;
                cmb_CentroLabor.SelectedValue = objCajaDet.Pedido;
                cmb_Moneda.SelectedValue = objCajaDet.MonedaCod;
                cmb_TipoDoc.SelectedValue = objCajaDet.TipoDocRef;
                txt_CuentaContable.Text = objCajaDet.CuentaContable;
                txt_codot.Text = objCajaDet.CodOt;
                txt_TipoPersona.Text = objCajaDet.Tper;
                txt_nroOperacion.Text = objCajaDet.NumeroOperacion.ToString();
            }
          

        }
        void cmbCentroLabor()
        {
            objListCentroLabor = objCajaDAO.getComboCentroLabor();
            cmb_CentroLabor.DataSource = objListCentroLabor;
            cmb_CentroLabor.ValueMember = "Codigo";
            cmb_CentroLabor.DisplayMember = "Descripcion";
            cmb_CentroLabor.Refresh();
        }
        void cmbTipoDocu()
        {
            objListTipoDocEmision = objCajaDAO.getComboTipoDocEmision();
            cmb_TipoDoc.DataSource = objListTipoDocEmision;
            cmb_TipoDoc.ValueMember = "Codigo";
            cmb_TipoDoc.DisplayMember = "Descripcion";
            cmb_TipoDoc.Refresh();
        }
        void cmbMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Item";
            idColumn1.DataPropertyName = "NumeroOperacion";
            idColumn1.Width = 40;
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N° OT";
            idColumn2.DataPropertyName = "NroOt";
            idColumn2.Width = 70;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Referencia";
            idColumn3.DataPropertyName = "CentroLabor";
            idColumn3.Width = 180;
            //idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Proveedor";
            idColumn4.DataPropertyName = "Proveedor";
            idColumn4.Width = 215;
            //idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Dcto";
            idColumn5.DataPropertyName = "TipoDocCorta";
            //idColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            idColumn5.Width = 40;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "N° Doc";
            idColumn6.DataPropertyName = "NroDocumento";
            idColumn6.Width = 80;
            //idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Fecha";
            idColumn7.DataPropertyName = "FechaEmision";
            idColumn7.Width = 70;
            //idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Importe";
            idColumn8.DataPropertyName = "Total";
            idColumn8.Width = 50;
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn8);
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            ListaCajaChica Check = new ListaCajaChica();
            Check.Show();
            this.Hide();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            habilitarBotones(false,true);
            habilitaCampos(true);
            Operacion = "N";

            limpiarCampos();
        }


        private void btn_Editar_Click(object sender, EventArgs e)
        {
            habilitarBotones(false, true);
            habilitaCampos(true);
            Operacion = "M";
        }


        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            
            habilitarBotones(true, false);
            bool insert;
            TipoDocumentoEmision objTipoDoc = new TipoDocumentoEmision();
            objTipoDoc = (TipoDocumentoEmision)cmb_TipoDoc.SelectedItem;
            objCajaDet = new CajaDet();
          
            objCajaDet.CentroLabor = cmb_CentroLabor.Text.Trim();
            objCajaDet.CodConcepto = "";
            objCajaDet.CodEnt = Ventas.UNIDADNEGOCIO;
            objCajaDet.CodentOt = Ventas.UNIDADNEGOCIO;
            objCajaDet.CodGas = txt_TipoGastoCod.Text;
            objCajaDet.CodOt = txt_codot.Text;
            objCajaDet.CuentaContable = txt_CuentaContable.Text;
            objCajaDet.DescripcionOperacion = txt_Detalle.Text;
            objCajaDet.Distrito = txt_Direccion.Text;
            objCajaDet.FechaEmision = dpick_FechaDoc.Value;
            objCajaDet.FechaOperacion = dpick_FechaOperacion.Value;
            objCajaDet.Total = convertToDouble(txt_Importe.Text);
            objCajaDet.SubTotal = Math.Round(convertToDouble(txt_Importe.Text) / 1.18, 2);
            objCajaDet.IGV = Math.Round(objCajaDet.Total - objCajaDet.SubTotal, 2);
            objCajaDet.Lote = 0;
            objCajaDet.MonedaCod = cmb_Moneda.SelectedValue.ToString();
            objCajaDet.Motivo = txt_Motivo.Text;
            objCajaDet.NroDocRef = txt_NroDoc.Text;
          
            objCajaDet.NroOt = txt_NroOt.Text;
            objCajaDet.NumeroCaja = txt_NroCaja.Text;
            
            objCajaDet.Origen = "0001";
            objCajaDet.Pedido = cmb_CentroLabor.SelectedValue.ToString();
            objCajaDet.Proveedor = txt_ProvNombre.Text;
            objCajaDet.Ruc = txt_ProvRuc.Text;
            objCajaDet.SerieDocRef = txt_SerieDoc.Text;
            objCajaDet.TipoDocRef = cmb_TipoDoc.SelectedValue.ToString();
            objCajaDet.TipoDocCorta = objTipoDoc.CodigoCorto;
            objCajaDet.Tper = txt_TipoPersona.Text;
            objCajaDet.Usuario = Ventas.UsuarioSession;
            objCajaDet.NroDocumento = objCajaDet.SerieDocRef+"-"+objCajaDet.NroDocRef;
            if (Operacion=="N")
            {
                try
                {
                    var id = objListCajaDet.Max(x => x.NumeroOperacion);
                    objCajaDet.NumeroOperacion = id + 1;
                }
                catch
                {
                    objCajaDet.NumeroOperacion =  1;
                }
               
                insert = objCajaDAO.insertarCajaDet(objCajaDet);
                if (insert)
                {
                    objListCajaDet.Add(objCajaDet);
                    grd_Facturas.DataSource = null;
                    grd_Facturas.DataSource = objListCajaDet;
                    grd_Facturas.Refresh();
                    MessageBox.Show("Se guardó con éxito");
                }else
                {
                    MessageBox.Show("Hubo un problema al guardar");
                }

            }
            else
            {
                var id = Convert.ToInt32(txt_nroOperacion.Text);
                objCajaDet.NumeroOperacion = id;
                insert = objCajaDAO.updateCajaDet(objCajaDet);
                if (insert)
                {

                    index= objListCajaDet.FindIndex(x =>x.NumeroOperacion  == objCajaDet.NumeroOperacion);
                    objListCajaDet[index] = objCajaDet;
                    grd_Facturas.DataSource = null;
                    grd_Facturas.DataSource = objListCajaDet;
                    grd_Facturas.Refresh();
                    MessageBox.Show("Se modificó con éxito");
                }
                else
                {
                    MessageBox.Show("Hubo un problema al modificar");
                }


            }

            double suma = objListCajaDet.Sum(x => x.Total);
            txt_Disponible.Text =Math.Round( convertToDouble(txt_Monto.Text) - suma ,2).ToString();
            habilitaCampos(false);
            limpiarCampos();
            
        }
        void habilitarBotones(bool bhabilita1, bool bhabilita2)
        {
            btn_Add.Enabled = bhabilita1;
            btn_Editar.Enabled = bhabilita1;
            btn_Guardar.Enabled = bhabilita2;
            btn_BuscarDocumentos.Enabled = bhabilita2;
        }
        void habilitaCampos(bool bhabilita)
        {
            txt_NroOt.Enabled = bhabilita;
            txt_TipoGastoCod.Enabled = bhabilita;
            txt_Motivo.Enabled = bhabilita;
            txt_Direccion.Enabled = bhabilita;
            txt_ProvRuc.Enabled = bhabilita;
            cmb_TipoDoc.Enabled = bhabilita;
            cmb_Moneda.Enabled = bhabilita;
            cmb_CentroLabor.Enabled = bhabilita;
            txt_Detalle.Enabled = bhabilita;
            txt_Importe.Enabled = bhabilita;
            txt_SerieDoc.Enabled = bhabilita;
            txt_NroDoc.Enabled = bhabilita;
            dpick_FechaDoc.Enabled = bhabilita;
            dpick_FechaOperacion.Enabled = bhabilita;
        }
        void limpiarCampos()
        {
            txt_NroOt.Text = "";
            txt_TipoGastoCod.Text = "";
            txt_Motivo.Text = "";
            txt_Direccion.Text = "";
            txt_ProvRuc.Text = "";
            cmb_TipoDoc.Text = "";
            cmb_Moneda.SelectedIndex = 0;
            cmb_CentroLabor.SelectedIndex = 0;
            txt_Detalle.Text = "";
            txt_Importe.Text = "";
            txt_SerieDoc.Text = "";
            txt_NroDoc.Text = "";
            txt_ProvNombre.Text = "";
            txt_NomOt.Text = "";
            txt_TipoGasto.Text = "";
            txt_CuentaContable.Text = "";
            txt_codot.Text = "";
            txt_TipoPersona.Text = "";
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

        private void btn_BuscarDocumentos_Click(object sender, EventArgs e)
        {
            String Ruc = "NN";
            Busqueda.BuscarDocVoucher check = new Busqueda.BuscarDocVoucher(Ruc, "C");
            check.Show();
        }
    }
}
