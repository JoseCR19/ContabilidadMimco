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
using System.Globalization;

namespace Contabilidad.Caja
{
    public partial class EmisionVoucher : Form
    {
        public static EmisionVoucher formEmision;
        public static String RUC;
        public static String moneda;
        public static String RegCompra;
        String correlativo = "";

        List<Proveedor> objListaProveedor = new List<Proveedor>();
        List<Proveedor> objListaProveedorBusqueda = new List<Proveedor>();
        List<Moneda> objListMoneda = new List<Moneda>();
        List<TipoSolicitante> objListaTipoSolicitante = new List<TipoSolicitante>();
        List<TipoDocumentoEmision> objListTipoDocEmision = new List<TipoDocumentoEmision>();
        List<VoucherDet> objListaVoucherDet = new List<VoucherDet>();
        List<Proveedor> objListProveedor = new List<Proveedor>();
        List<Proveedor> objListProveedorBusqueda = new List<Proveedor>();
        List<Personal> objListPersonal = new List<Personal>();
        List<Personal> objListPersonalBusqueda = new List<Personal>();
        List<Cliente> objListaCliente = new List<Cliente>();
        List<Cliente> objListaClienteBusqueda = new List<Cliente>();
        List<CuentaBanco> objListaBanco = new List<CuentaBanco>();
        List<CuentaBanco> objListaBancoBusqueda = new List<CuentaBanco>();
        List<OtDTO> objListOt = new List<OtDTO>();
        List<EstadoVoucher> objListaEstado = new List<EstadoVoucher>();
        List<OtDTO> objListOtBusqueda = new List<OtDTO>();
        List<TipoPagoVoucher> objListTipoPagoVoucher = new List<TipoPagoVoucher>();
        List<TipoPagoVoucher> objListTipoPagoVoucherBusqueda = new List<TipoPagoVoucher>();
        List<OperacionBanco> objListaOperacionBanco = new List<OperacionBanco>();
        List<Ejercicio> objListaEjercicio = new List<Ejercicio>();
        List<Periodo> objListaPeriodo = new List<Periodo>();
        List<OperacionesBancarias> objlistaoperacionesbancarias = new List<OperacionesBancarias>();
        List<PrestamoBancario> objListPrestamoBancario = new List<PrestamoBancario>();
        public static List<VoucherReporte> objListaVoucherReporte = new List<VoucherReporte>();

        MonedaDAO objMonedaDao;
        VoucherDAO objVoucherDao;
        LoVDAO objLoVDao;
        CajaDAO objCajaDAO;
        PagoVoucherDAO objPagoVoucherDao;
        ChequeDAO objChequeDAO;
        DocumentoDAO objDocumentoDAO;
        OperacionesBancarias objOpeBan;

        TipoDocumentoEmision objTipoDocumentoEmision;
        Voucher objVoucher;
        VoucherDet objVoucherDet;
        VoucherDet objvou = new VoucherDet();
        OperacionBanco objOperacionBanco;
        Ejercicio objEjercicio;
        Periodo objPeriodo;

        int index = 0;
        int contador = 1;
        public bool editar = false;
        public bool insertarpago = false;
        String OperacionGuardar = "Q";
        String Operacion = "Q";
        String change = "Q";
        public static String TipoOperacionBanco = "Q";
        String TipoMovimiento = "Q";
        String estado;
        String xperiodo, xejercicio;
        public EmisionVoucher()
        {
            InitializeComponent();
            formEmision = this;
            rb_Metales.Checked = true;
            this.ControlBox = false;
            this.Text = "CAJA BANCO";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 10);
            objMonedaDao = new MonedaDAO();
            objLoVDao = new LoVDAO();
            objVoucherDao = new VoucherDAO();
            objCajaDAO = new CajaDAO();
            objPagoVoucherDao = new PagoVoucherDAO();
            objDocumentoDAO = new DocumentoDAO();
            objTipoDocumentoEmision = new TipoDocumentoEmision();
            objVoucher = new Voucher();
            objVoucherDet = new VoucherDet();
            objOperacionBanco = new OperacionBanco();
            objEjercicio = new Ejercicio();
            objPeriodo = new Periodo();
            objChequeDAO = new ChequeDAO();
            objOpeBan = new OperacionesBancarias();
            RUC = txt_SolicitanteCod.Text;
            cmbopebank();
            cmbMoneda();
            cmbejercicio();
            cmbperiodo();
            cmbSolicitante();
            txt_CuentaContable.Visible = false;
            cmbOpreacion();

            // gridParams();
            txt_SolicitanteCod.TextChanged += Txt_SolicitanteCod_TextChanged;
            dpick_FechaPago.ValueChanged += Dpick_FechaPago_ValueChanged;

            xperiodo = dpick_FechaPago.Value.Month.ToString();
            cmb_periodo.SelectedValue = xperiodo;
            xejercicio = dpick_FechaPago.Value.Year.ToString();
            cmb_ejercicio2.SelectedValue = xejercicio;
            rb_Metales.CheckedChanged += Rb_Metales_CheckedChanged;
            cargarListas();
            if (ListaEmisionVoucher.operacionVoucher == "V")

            {

                btn_imprimir.Enabled = true;
                objVoucher = ListaEmisionVoucher.objVoucher;
                llenarCabecera(objVoucher);
                /*condicion por siacaso rick */
                if (change == "C")
                {

                }
                else
                {

                    objListaVoucherDet = objVoucherDao.listarVoucherDet(objVoucher.NumeroVoucher, Ventas.UNIDADNEGOCIO);
                    llenarDetalle(objListaVoucherDet);
                }
                if (objListaVoucherDet.Count > 0)
                {
                    sumatoria();
                }
                btn_SaveData.Enabled = false;
                btn_Modificar.Visible = true;

                if (String.IsNullOrEmpty(txt_NroCheque.Text))
                {
                    cmb_Operacion.SelectedValue = "02";
                    txt_NroCheque.Visible = true;
                }
                else
                {
                    cmb_Operacion.SelectedValue = "03";
                    txt_NroCheque.Visible = true;
                    dpick_FechaEmision.Enabled = true;
                }
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "05")
                {
                    cmb_Operacion.SelectedValue = "01";
                }
            }

            else if (ListaEmisionVoucher.operacionVoucher == "A")
            {
                btn_imprimir.Enabled = true;
                objVoucher = ListaEmisionVoucher.objVoucher;
                llenarCabecera(objVoucher);

                objListaVoucherDet = objVoucherDao.listarVoucherDet(objVoucher.NumeroVoucher, Ventas.UNIDADNEGOCIO);

                llenarDetalle(objListaVoucherDet);
                sumatoria();
                btn_Modificar.Visible = false;
                btn_SaveData.Visible = false;
                txt_MontoTotal.Enabled = false;

                if (String.IsNullOrEmpty(txt_NroCheque.Text))
                {
                    cmb_Operacion.SelectedValue = "02";
                    txt_NroCheque.Visible = true;
                }
                else
                {
                    cmb_Operacion.SelectedValue = "03";
                    txt_NroCheque.Visible = true;
                }
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "05")
                {
                    cmb_Operacion.SelectedValue = "01";
                }
            }

            else
            {
                btn_imprimir.Enabled = false;
                habilitaCampos(false, true);

                habilitarBotones(true, false);
                txt_NroVoucher.Text = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                btn_Modificar.Visible = false;
                OperacionGuardar = "G";
            }
            if (cmb_Operacion.SelectedValue.ToString() == "01")
            {
                lbl_Cheque.Visible = false;
                txt_NroCheque.Visible = false;
            }
            /*esta es la opcion que se colocaba 03 ahora sera 02*/
            else if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03")
            {
                lbl_Cheque.Visible = true;
                txt_NroCheque.Visible = true;
            }
            else
            {
                lbl_Cheque.Visible = false;
                txt_NroCheque.Visible = false;
            }
            if (cmb_Operacion.SelectedValue.ToString() == "01" || cmb_Operacion.SelectedValue.ToString() == "02")
            {
                dpick_FechaEmision.Enabled = true;
            }


            tipoCambio(dpick_FechaPago.Value.ToShortDateString());

            txt_SolicitanteCod.KeyDown += Txt_SolicitanteCod_KeyDown;

            txt_BancoCod.KeyDown += Txt_BancoCod_KeyDown;

            txt_MovCod.KeyDown += Txt_MovCod_KeyDown;

            txt_MovCod.TextChanged += Txt_MovCod_TextChanged;

            grd_VoucherDet.CellClick += Grd_VoucherDet_CellClick;

            cmb_Operacion.SelectedIndexChanged += Cmb_Operacion_SelectedIndexChanged;

        }

        private void Rb_Metales_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Metales.Checked)
            {
                Ventas.UNIDADNEGOCIO = "01";
            }
            else
            {
                Ventas.UNIDADNEGOCIO = "02";
            }
            if (ListaEmisionVoucher.operacionVoucher != "V")
            {
                txt_NroVoucher.Text = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
            }
        }

        private void Cmb_Operacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Operacion.SelectedValue.ToString() == "01")
            {
                lbl_Cheque.Visible = false;
                txt_NroCheque.Visible = false;
            }
            else if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03")
            {
                lbl_Cheque.Visible = true;
                txt_NroCheque.Visible = true;

            }
            else
            {
                lbl_Cheque.Visible = false;
                txt_NroCheque.Visible = false;
            }
            if (cmb_Operacion.SelectedValue.ToString() == "01" || cmb_Operacion.SelectedValue.ToString() == "02")
            {
                dpick_FechaEmision.Enabled = true;
            }
            else
            {
                dpick_FechaEmision.Enabled = false;

            }

        }
        void sumatoriaver()
        {

            txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
            txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
            double d = Convert.ToDouble(txt_MontoTotal.Text);
            txt_MontoTotal.Text = d.ToString("0.00");
            double d1 = Convert.ToDouble(txt_Total.Text);
            txt_Total.Text = d1.ToString("0.00");
        }
        void sumatoriacheque()
        {
            txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
            double d1 = Convert.ToDouble(txt_Total.Text);
            txt_Total.Text = d1.ToString("0.00");
        }
        void sumatoria()
        {
            double treinta = 0;
            double Total = 0;

            if (estado == "c")
            {
                if (objListaVoucherDet[index].xret == "TRET" && objListaVoucherDet[index].xdetra == "no" && objListaVoucherDet[index].xbue == "TBUE")
                {
                    txt_30.Text = "00.00";
                    txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                    txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                    double d = Convert.ToDouble(txt_MontoTotal.Text);
                    txt_MontoTotal.Text = d.ToString("0.00");
                    double d1 = Convert.ToDouble(txt_Total.Text);
                    txt_Total.Text = d1.ToString("0.00");
                }
                else if (objListaVoucherDet[index].xret == "TRET" && objListaVoucherDet[index].xdetra == "no")
                {
                    if (Convert.ToInt32(objListaVoucherDet.Sum(x => x.Importe)) <= 700.00)
                    {
                        txt_30.Text = "00.00";
                        txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                        txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                        double d = Convert.ToDouble(txt_MontoTotal.Text);
                        txt_MontoTotal.Text = d.ToString("0.00");
                        double d1 = Convert.ToDouble(txt_Total.Text);
                        txt_Total.Text = d1.ToString("0.00");
                    }
                    else
                    {
                        treinta = Convert.ToInt32(objListaVoucherDet.Sum(x => x.Importe)) * 0.03;
                        Total = objListaVoucherDet.Sum(x => x.Importe) + treinta;
                        txt_30.Text = treinta.ToString("G");
                        txt_Total.Text = Total.ToString("G");
                        txt_MontoTotal.Text = Total.ToString("G");
                        double d = Convert.ToDouble(txt_MontoTotal.Text);
                        txt_MontoTotal.Text = d.ToString(".00");
                        double d1 = Convert.ToDouble(txt_Total.Text);
                        txt_Total.Text = d1.ToString("0.00");
                    }
                }
                else if (objListaVoucherDet[index].xbue == "TBUE" && objListaVoucherDet[index].xdetra == "no")
                {
                    if (Convert.ToInt32(objListaVoucherDet.Sum(x => x.Importe)) <= 700.00)
                    {
                        txt_30.Text = "00.00";
                        txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                        txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                        double d = Convert.ToDouble(txt_MontoTotal.Text);
                        txt_MontoTotal.Text = d.ToString("0.00");
                        double d1 = Convert.ToDouble(txt_Total.Text);
                        txt_Total.Text = d1.ToString("0.00");
                    }
                    else
                    {
                        treinta = Convert.ToInt32(objListaVoucherDet.Sum(x => x.Importe)) * 0.03;
                        Total = objListaVoucherDet.Sum(x => x.Importe) + treinta;
                        txt_30.Text = treinta.ToString("G");
                        txt_Total.Text = Total.ToString("G");
                        txt_MontoTotal.Text = Total.ToString("G");
                        double d = Convert.ToDouble(txt_MontoTotal.Text);
                        txt_MontoTotal.Text = d.ToString(".00");
                        double d1 = Convert.ToDouble(txt_Total.Text);
                        txt_Total.Text = d1.ToString("0.00");
                    }
                }
                else
                {
                    txt_30.Text = "00.00";
                    txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                    txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                    double d = Convert.ToDouble(txt_MontoTotal.Text);
                    txt_MontoTotal.Text = d.ToString("0.00");
                    double d1 = Convert.ToDouble(txt_Total.Text);
                    txt_Total.Text = d1.ToString("0.00");
                }

            }
            else
            {
                txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                double d = Convert.ToDouble(txt_MontoTotal.Text);
                txt_MontoTotal.Text = d.ToString("0.00");
                double d1 = Convert.ToDouble(txt_Total.Text);
                txt_Total.Text = d1.ToString("0.00");

            }


        }
        void sumatoria30()
        {
            double treinta = 0;
            double Total = 0;
            if (Convert.ToInt32(objListaVoucherDet.Sum(x => x.Importe)) >= 700.00)
            {
                treinta = Convert.ToInt32(objListaVoucherDet.Sum(x => x.Importe)) * 0.03;
                Total = objListaVoucherDet.Sum(x => x.Importe) + treinta;
                txt_30.Text = treinta.ToString("G");
                txt_Total.Text = Total.ToString("G");
                txt_MontoTotal.Text = objVoucherDao.convertToDouble(Total.ToString()).ToString();
                double d = Convert.ToDouble(txt_MontoTotal.Text);
                txt_MontoTotal.Text = d.ToString("0.00");
                double d1 = Convert.ToDouble(txt_Total.Text);
                txt_Total.Text = d1.ToString("0.00");

            }
            else
            {
                txt_30.Text = "00.00";
                txt_Total.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                txt_MontoTotal.Text = objListaVoucherDet.Sum(x => x.Importe).ToString("G");
                double d = Convert.ToDouble(txt_MontoTotal.Text);
                txt_MontoTotal.Text = d.ToString("0.00");
                double d1 = Convert.ToDouble(txt_Total.Text);
                txt_Total.Text = d1.ToString("0.00");
            }
        }


        private void Grd_VoucherDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {


                index = grd_VoucherDet.SelectedCells[0].RowIndex;
                objVoucherDet = objListaVoucherDet[index];
                txt_NroOt.Text = objVoucherDet.NroOt;
                txt_Descripcion.Text = objVoucherDet.Descripcion;
                txt_NroDoc.Text = objVoucherDet.Documento;
                txt_RazonSocial.Text = objVoucherDet.RazonSocial;
                double d1 = Convert.ToDouble(txt_Total.Text);
                txt_Importe.Text = objVoucherDet.Importe.ToString("#0.00");

            }
            catch
            {

            }
        }

        private void Txt_MovCod_TextChanged(object sender, EventArgs e)
        {
            TipoMovimiento = txt_MovCod.Text;
            objListTipoPagoVoucherBusqueda = objListTipoPagoVoucher;
            objListTipoPagoVoucherBusqueda = objListTipoPagoVoucher.Where(x => x.Codigo.Trim().Equals(txt_MovCod.Text.Trim())).ToList();
            try
            {
                txt_Movimiento.Text = objListTipoPagoVoucherBusqueda[0].Descripcion;

            }
            catch
            {

            }
            if (TipoMovimiento == "07" || TipoMovimiento == "01" || TipoMovimiento == "09" || TipoMovimiento == "10" || TipoMovimiento == "02")
            {

                lbl_orden.Visible = true;
                cmb_TipoSolicitante.Visible = true;
                txt_Solicitante.Visible = true;
                txt_SolicitanteCod.Visible = true;
            }
            else
            {

                lbl_orden.Visible = false;
                cmb_TipoSolicitante.Visible = false;
                txt_Solicitante.Visible = false;
                txt_SolicitanteCod.Visible = false;
            }
        }




        private void Txt_MovCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoV.LoVTipoPagoVoucher check = new LoV.LoVTipoPagoVoucher();
                check.Show();
            }
        }





        void cargarListas()
        {
            objListPersonal = objLoVDao.getLovPersonal();
            objListProveedor = objLoVDao.getLovProveedor(Ventas.UNIDADNEGOCIO);
            objListaCliente = objLoVDao.getLovCliente(Ventas.UNIDADNEGOCIO);
            objListaBanco = objLoVDao.getLovBancoSolicita(Ventas.UNIDADNEGOCIO);
            objListOt = objLoVDao.getLovOtSite(Ventas.UNIDADNEGOCIO);
            objListTipoPagoVoucher = objLoVDao.getLovTipoPagoVoucher();
        }
        private void Txt_SolicitanteCod_TextChanged(object sender, EventArgs e)

        {
            String SolicitaCod = cmb_TipoSolicitante.SelectedValue.ToString();
            switch (SolicitaCod)
            {
                case "02":
                    objListaProveedorBusqueda = objListProveedor;
                    objListaProveedorBusqueda = objListaProveedorBusqueda.Where(x => x.ProveedorNDoc.Trim().Equals(txt_SolicitanteCod.Text.Trim())).ToList();
                    try
                    {
                        txt_Solicitante.Text = objListaProveedorBusqueda[0].ProveedorRazonSocial;
                    }
                    catch
                    {

                    }

                    break;
                case "03":
                    objListPersonalBusqueda = objListPersonal;
                    objListPersonalBusqueda = objListPersonalBusqueda.Where(x => x.NroDocumento.Trim().Equals(txt_SolicitanteCod.Text.Trim())).ToList();

                    try
                    {
                        txt_Solicitante.Text = objListPersonalBusqueda[0].Nombre;
                        txt_NroDoc.Text = objListPersonalBusqueda[0].NroDocumento;
                        txt_RazonSocial.Text = objListPersonalBusqueda[0].Nombre;
                    }
                    catch
                    {

                    }
                    break;
                case "04":
                    objListaBancoBusqueda = objListaBanco;
                    objListaBancoBusqueda = objListaBancoBusqueda.Where(x => x.Codigo.Trim().Equals(txt_SolicitanteCod.Text.Trim())).ToList();
                    try
                    {
                        txt_Solicitante.Text = objListaBancoBusqueda[0].Descripcion;
                    }
                    catch
                    {

                    }
                    break;
                case "05":
                    objListaClienteBusqueda = objListaCliente;
                    objListaClienteBusqueda = objListaClienteBusqueda.Where(x => x.ClienteNDoc.Trim().Equals(txt_SolicitanteCod.Text.Trim())).ToList();
                    try
                    {
                        txt_Solicitante.Text = objListaClienteBusqueda[0].ClienteRazonSocial;
                    }
                    catch
                    {

                    }
                    break;
            }

        }

        private void Txt_BancoCod_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                LoV.LoVBanco check = new LoV.LoVBanco("voucher");
                check.Show();
            }
        }
        private void Txt_SolicitanteCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoV.LoVSolicita check = new LoV.LoVSolicita(cmb_TipoSolicitante.SelectedValue.ToString());
                check.Show();
            }
        }
        public void setTipoPagoVoucher(String codigo, String descripcion)
        {
            txt_MovCod.Text = codigo;
            txt_Movimiento.Text = descripcion;
        }
        public void setOt(String NroOt, String site, String Codot)
        {

            txt_codot.Text = Codot;
        }
        public void setSolicitaProveedor(String ruc, String razon)
        {
            txt_SolicitanteCod.Text = ruc;
            txt_Solicitante.Text = razon;
        }
        public void setSolicitaPersonal(String dni, String nombre)
        {
            txt_SolicitanteCod.Text = dni;
            txt_Solicitante.Text = nombre;
        }
        public void setSolicitaBanco(String codigo, String nombre)
        {
            txt_SolicitanteCod.Text = codigo;
            txt_Solicitante.Text = nombre;
        }
        public void setBanco(String codigo, String nombre, String Cuenta, String CuentaContable, String moneda)
        {
            txt_BancoCod.Text = codigo;
            txt_Banco.Text = nombre;
            txt_NroCuenta.Text = Cuenta;
            txt_CuentaContable.Text = CuentaContable;
            cmb_Moneda.SelectedValue = moneda;
            txt_NroCheque.Text = objChequeDAO.getNroActualCheque(Ventas.UNIDADNEGOCIO, codigo, moneda);
        }
        public void setSolicitaCliente(String ruc, String razon)
        {
            txt_SolicitanteCod.Text = ruc;
            txt_Solicitante.Text = razon;
        }


        public void gridParams()
        {
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Id";
            idColumn1.DataPropertyName = "Item";
            idColumn1.Width = 30;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Tipo Movimiento";
            idColumn2.DataPropertyName = "TipoPago";
            idColumn2.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Site";
            idColumn3.DataPropertyName = "DirOt";
            idColumn3.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Descripcion";
            idColumn5.DataPropertyName = "Descripcion";
            idColumn5.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "N° Documentos";
            idColumn6.DataPropertyName = "NroDocumento";
            idColumn6.Width = 120;
            grd_VoucherDet.Columns.Add(idColumn6);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe";
            idColumn4.DataPropertyName = "Importe";
            idColumn4.DefaultCellStyle.Format = ".00";
            idColumn4.Width = 90;
            //idColumn4.HeaderCell.
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_VoucherDet.Columns.Add(idColumn4);


            foreach (DataGridViewColumn col in grd_VoucherDet.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

        }

        void llenarCabecera(Voucher objV)
        {
            cmb_TipoSolicitante.SelectedValue = objV.TpersonaCod;
            txt_NroVoucher.Text = objV.NumeroVoucher;
            txt_BancoCod.Text = objV.BancoCod;
            txt_Banco.Text = objV.Banco;
            txt_NroCheque.Text = objV.NumeroCheque;
            txt_NroCuenta.Text = objV.NumeroCuenta;
            txt_Solicitante.Text = objV.Solicitante;
            txt_SolicitanteCod.Text = objV.SolicitaCod;
            txt_Observacion.Text = objV.Observacion;
            dpick_FechaEmision.Value = objV.FechaEmision;
            dpick_FechaPago.Value = objV.FechaPago;
            xperiodo = dpick_FechaPago.Value.Month.ToString();
            cmb_periodo.SelectedValue = xperiodo;
            xejercicio = dpick_FechaPago.Value.Year.ToString();
            cmb_ejercicio2.SelectedValue = xejercicio;
            txt_MontoTotal.Text = objV.Monto.ToString("G");

            double d = Convert.ToDouble(txt_MontoTotal.Text);
            txt_MontoTotal.Text = d.ToString(".00");
            cmb_Moneda.SelectedValue = objV.MonedaCod;
            txt_Movimiento.Text = objV.TipoMovimiento;
            if (txt_Movimiento.Text == "PROVEEDOR")
            {
                txt_MovCod.Text = "01";
            }
            else if (txt_Movimiento.Text == "DETRACCIONES")
            {
                txt_MovCod.Text = "02";
            }
            else if (txt_Movimiento.Text == "PLANILLA")
            {
                txt_MovCod.Text = "03";
            }
            else if (txt_Movimiento.Text == "PLANILLA")
            {
                txt_MovCod.Text = "04";
            }
            else if (txt_Movimiento.Text == "AFP")
            {
                txt_MovCod.Text = "05";
            }
            else if (txt_Movimiento.Text == "CARGOS BANCARIOS")
            {
                txt_MovCod.Text = "06";
            }
            else if (txt_Movimiento.Text == "CAJA CHICA")
            {
                txt_MovCod.Text = "07";
            }
            else if (txt_Movimiento.Text == "COBRANZA")
            {
                txt_MovCod.Text = "08";
            }
            else if (txt_Movimiento.Text == "DEVOLUCION")
            {
                txt_MovCod.Text = "09";
            }

            if (rb_Metales.Checked)
            {
                Ventas.UNIDADNEGOCIO = "01";
            }
            else
            {
                Ventas.UNIDADNEGOCIO = "02";
            }

        }
        private void Dpick_FechaPago_ValueChanged(object sender, EventArgs e)
        {
            tipoCambio(dpick_FechaPago.Value.ToShortDateString());
        }

        void cmbMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }
        void cmbOpreacion()
        {
            objOperacionBanco = new OperacionBanco();
            objOperacionBanco.Id = "01";
            objOperacionBanco.Descripcion = "ABONO";
            objListaOperacionBanco.Add(objOperacionBanco);
            objOperacionBanco = new OperacionBanco();
            objOperacionBanco.Id = "02";
            objOperacionBanco.Descripcion = "CARGO";
            objListaOperacionBanco.Add(objOperacionBanco);
            objOperacionBanco = new OperacionBanco();
            objOperacionBanco.Id = "03";
            objOperacionBanco.Descripcion = "CHEQUE";
            objListaOperacionBanco.Add(objOperacionBanco);
            cmb_Operacion.DataSource = objListaOperacionBanco;
            cmb_Operacion.ValueMember = "Id";
            cmb_Operacion.DisplayMember = "Descripcion";
            cmb_Operacion.Refresh();
        }
        void cmbejercicio()
        {
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2018";
            objEjercicio.Descripcion = "2018";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2019";
            objEjercicio.Descripcion = "2019";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2020";
            objEjercicio.Descripcion = "2020";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2021";
            objEjercicio.Descripcion = "2021";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2022";
            objEjercicio.Descripcion = "2022";
            objListaEjercicio.Add(objEjercicio);
            cmb_ejercicio2.DataSource = objListaEjercicio;
            cmb_ejercicio2.ValueMember = "Id";
            cmb_ejercicio2.DisplayMember = "Descripcion";
            cmb_ejercicio2.Refresh();
        }
        void cmbopebank()
        {
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "01";
            objOpeBan.Descripcion = " ";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "02";
            objOpeBan.Descripcion = "COMISIONES";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "03";
            objOpeBan.Descripcion = "PORTES";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "04";
            objOpeBan.Descripcion = "COMISION POR EMISION DE CARTA FIANZA";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "05";
            objOpeBan.Descripcion = "INTERESES DE PAGARES";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "06";
            objOpeBan.Descripcion = "COMISIONES POR DESEMBOLSO";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "07";
            objOpeBan.Descripcion = "INTERESES DE FACTORING";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "08";
            objOpeBan.Descripcion = "INTERESES DESCUENTO DE LETRAS";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "09";
            objOpeBan.Descripcion = "GASTOS ADMINISTRATIVOS";
            objlistaoperacionesbancarias.Add(objOpeBan);
            objOpeBan = new OperacionesBancarias();
            objOpeBan.Id = "10";
            objOpeBan.Descripcion = "DIFERENCIA TIPO CAMBIO";
            objlistaoperacionesbancarias.Add(objOpeBan);
            cmb_OperacionesBanc.DataSource = objlistaoperacionesbancarias;
            cmb_OperacionesBanc.Refresh();
        }
        void cmbperiodo()
        {
            objPeriodo = new Periodo();
            objPeriodo.Id = "1";
            objPeriodo.Descripcion = "01";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "2";
            objPeriodo.Descripcion = "02";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "3";
            objPeriodo.Descripcion = "03";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "4";
            objPeriodo.Descripcion = "04";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "5";
            objPeriodo.Descripcion = "05";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "6";
            objPeriodo.Descripcion = "06";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "7";
            objPeriodo.Descripcion = "07";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "8";
            objPeriodo.Descripcion = "08";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "9";
            objPeriodo.Descripcion = "09";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "10";
            objPeriodo.Descripcion = "10";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "11";
            objPeriodo.Descripcion = "11";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "12";
            objPeriodo.Descripcion = "12";
            objListaPeriodo.Add(objPeriodo);
            cmb_periodo.DataSource = objListaPeriodo;
            cmb_periodo.ValueMember = "Id";
            cmb_periodo.DisplayMember = "Descripcion";
            cmb_periodo.Refresh();

        }


        void cmbSolicitante()
        {
            objListaTipoSolicitante = objVoucherDao.cmbSolicitante();
            cmb_TipoSolicitante.DataSource = objListaTipoSolicitante;
            cmb_TipoSolicitante.ValueMember = "Codigo";
            cmb_TipoSolicitante.DisplayMember = "Descripcion";
            cmb_TipoSolicitante.Refresh();
        }



        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaEmisionVoucher.operacionVoucher = "Q";
            if (rb_Metales.Checked)
            {
                Ventas.UNIDADNEGOCIO = "01";
            }
            else
            {
                Ventas.UNIDADNEGOCIO = "02";
            }
            ListaEmisionVoucher Check = new ListaEmisionVoucher();
            Check.Show();
            btn_SaveData.Enabled = true;

        }
        public void tipoCambio(String date)
        {
            txt_TipoCambio.Text = objMonedaDao.getTipoCambioCompra(date).ToString().PadRight(5, '0');
        }
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            editar = true;
            habilitarBotones(false, true);
            // habilitaCampos(true, false);
            txt_Importe.Enabled = true;
            Operacion = "M";
        }
        void habilitarBotones(bool bhabilita1, bool bhabilita2)
        {
            btn_Add.Enabled = bhabilita1;
            btn_Editar.Enabled = bhabilita1;
            btn_Guardar.Enabled = bhabilita2;
            btn_Rest.Enabled = bhabilita1;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = false;
            //habilitarBotones(false, true);
            habilitaCampos(true, false);
            Operacion = "N";
            change = "C";

            //limpiarCampos();
            /*if ( txt_BancoCod.Text !="")
            {*/
            /*condicon para los pagos para las cuentas por pagar*/
            /*condicion para mostrar formulario de caja chica*/
            if (TipoMovimiento == "01")
            {
                string ruc = "NN";

                string moneda = "";
                string monedadoc = "";
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "02")
                {
                    ruc = txt_SolicitanteCod.Text;
                    /*moneda = cmb_Moneda.SelectedValue.ToString();
                    if (cmb_Moneda.SelectedValue.ToString() == "PEN")
                    {
                        monedadoc = "1";
                    }
                    else
                    {
                        monedadoc = "2";
                    }*/

                }
                estado = "c";
                RegCompra = "CARGO";
                AgregarCajaChica Check = new AgregarCajaChica(ruc, RegCompra/*,moneda,monedadoc*/);
                Check.Show();

            }

            /*condicion para seleccionar el formulario de agregardetracciones*/
            else if (TipoMovimiento == "02")
            {
                string ruc = "NN";
                bool detraccion = false;
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "05")
                {
                    ruc = txt_SolicitanteCod.Text;
                    moneda = cmb_Moneda.SelectedValue.ToString();
                    detraccion = true;

                }


                if (detraccion == true)
                {
                    AgregarDetracionFactura Check = new AgregarDetracionFactura(ruc);
                    Check.Show();
                }
                else
                {


                    AgregarDetracciones Check1 = new AgregarDetracciones();
                    Check1.Show();
                }

            }

            else if (TipoMovimiento == "03")
            {
                AgregarPlanilla Check = new AgregarPlanilla();
                Check.Show();
            }
            else if (TipoMovimiento == "04")
            {
                AgregarAFP Check = new AgregarAFP();
                Check.Show();
            }
            else if (TipoMovimiento == "05")
            {
                AgregarImpuestos Check = new AgregarImpuestos();
                Check.Show();
            }
            else if (TipoMovimiento == "06")
            {
                AgregarCargoBancario Check = new AgregarCargoBancario();
                Check.Show();
            }
            else if (cmb_Operacion.SelectedValue.ToString() == "01" && TipoMovimiento == "08")
            {
                InsertarPrestamoBancario Check = new InsertarPrestamoBancario();
                Check.Show();
            }
            else if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03" && TipoMovimiento == "08")
            {
                AgregarPrestamoBancario Check = new AgregarPrestamoBancario(txt_BancoCod.Text, cmb_Moneda.SelectedValue.ToString());
                Check.Show();
            }
            /*condicion para las cuentas por cobrar*/
            else if (cmb_Operacion.SelectedValue.ToString() == "01" && TipoMovimiento == "09")
            {
                string ruc = "NN";
                string moneda = "";
                string monedadoc = "";
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "05")
                {
                    ruc = txt_SolicitanteCod.Text;
                    moneda = cmb_Moneda.SelectedValue.ToString();
                    if (cmb_Moneda.SelectedValue.ToString() == "USD")
                    {
                        monedadoc = "03";
                    }
                    else if (cmb_Moneda.SelectedValue.ToString() == "PEN")
                    {
                        monedadoc = "01";
                    }
                    else
                    {
                        monedadoc = "02";
                    }
                }
                AgregarAbonoFactura Check = new AgregarAbonoFactura(ruc/*,moneda,monedadoc*/);
                Check.Show();
            }
            else if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03" && TipoMovimiento.ToString() == "07" && cmb_TipoSolicitante.SelectedValue.ToString() == "03")
            {
                txt_NroOt.Enabled = true;
                txt_Descripcion.Enabled = true;
                txt_NroDoc.Enabled = false;
                txt_RazonSocial.Enabled = false;
                txt_Importe.Enabled = true;
                btn_Add.Enabled = false;
                gridCheke();
                btn_Guardar.Enabled = true;

                /*} else
                {
                    MessageBox.Show("Debe colocar el Monto y el Banco");
                    habilitaCamposAgregar(true,false);
                }*/
            }
            else if (cmb_Operacion.SelectedValue.ToString() == "03" || cmb_Operacion.SelectedValue.ToString() == "02" && TipoMovimiento.ToString() == "10" && cmb_TipoSolicitante.SelectedValue.ToString() == "03")
            {
                txt_NroOt.Enabled = true;
                txt_Descripcion.Enabled = true;
                txt_NroDoc.Enabled = false;
                txt_RazonSocial.Enabled = false;
                txt_Importe.Enabled = true;
                btn_Add.Enabled = false;
                gridCheke();
                btn_Guardar.Enabled = true;

                /*} else
                {
                    MessageBox.Show("Debe colocar el Monto y el Banco");
                    habilitaCamposAgregar(true,false);
                }*/
            }
            btn_Add.Enabled = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            int count = 0;
            if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03" && TipoMovimiento == "07" && cmb_TipoSolicitante.SelectedValue.ToString() == "03")
            {
                if (editar == true)
                {
                    objListaVoucherDet[index].Importe = Convert.ToDouble(txt_Importe.Text.ToString());
                    grd_VoucherDet.DataSource = null;
                    grd_VoucherDet.DataSource = objListaVoucherDet;
                    grd_VoucherDet.Refresh();
                    //habilitaCampos(false, false);
                    // limpiarCampos();
                    sumatoria();
                    editar = false;
                }
                else
                {
                    objvou = new VoucherDet();
                    objvou.Importe = Math.Round(convertToDouble(txt_Importe.Text), 2, MidpointRounding.AwayFromZero);
                    objvou.NroOt = txt_NroOt.Text;
                    objvou.Descripcion = txt_Descripcion.Text;
                    objvou.Documento = txt_NroDoc.Text;
                    objvou.RazonSocial = txt_RazonSocial.Text;
                    objvou.NumeroVoucher = txt_NroVoucher.Text;
                    if (rb_Metales.Checked)
                    {
                        objvou.CodEnt = "01";
                    }
                    else
                    {
                        objvou.CodEnt = "02";
                    }
                    objvou.Item = objListaVoucherDet.Count + 1;
                    objListaVoucherDet.Add(objvou);
                    txt_Importe.Text = " ";
                    txt_RazonSocial.Text = " ";
                    txt_NroDoc.Text = " ";
                    txt_NroOt.Text = " ";
                    txt_Descripcion.Text = " ";
                    habilitarBotones(false, true);
                    sumatoria();
                    editar = false;
                    grd_VoucherDet.DataSource = null;
                    grd_VoucherDet.DataSource = objListaVoucherDet;
                    grd_VoucherDet.Refresh();
                }
                count++;
            }
            else if (cmb_Operacion.SelectedValue.ToString() == "02" && TipoMovimiento == "10" && cmb_TipoSolicitante.SelectedValue.ToString() == "03")
            {
                if (editar == true)
                {
                    objvou = new VoucherDet();
                    objvou.Importe = Math.Round(convertToDouble(txt_Importe.Text), 2, MidpointRounding.AwayFromZero);
                    objvou.NroOt = txt_NroOt.Text;
                    objvou.Descripcion = txt_Descripcion.Text;
                    objvou.Documento = txt_NroDoc.Text;
                    objvou.RazonSocial = txt_RazonSocial.Text;
                    objvou.NumeroVoucher = txt_NroVoucher.Text;
                    if (rb_Metales.Checked)
                    {
                        objvou.CodEnt = "01";
                    }
                    else
                    {
                        objvou.CodEnt = "02";
                    }
                    objvou.Item = objListaVoucherDet.Count + 1;
                    objListaVoucherDet.Add(objvou);
                    grd_VoucherDet.DataSource = null;
                    grd_VoucherDet.DataSource = objListaVoucherDet;
                    grd_VoucherDet.Refresh();
                    txt_Importe.Text = " ";
                    txt_RazonSocial.Text = " ";
                    txt_NroDoc.Text = " ";
                    txt_NroOt.Text = " ";
                    txt_Descripcion.Text = " ";
                    habilitarBotones(false, true);
                    sumatoria();
                }
                else
                {
                    objListaVoucherDet[index].Importe = Convert.ToInt32(txt_Importe.Text.ToString());
                    grd_VoucherDet.DataSource = null;
                    grd_VoucherDet.DataSource = objListaVoucherDet;
                    grd_VoucherDet.Refresh();
                    //habilitaCampos(false, false);
                    // limpiarCampos();
                    sumatoria();
                }
                count++;
            }
            else
            {
                objListaVoucherDet[index].Importe = Convert.ToDouble(txt_Importe.Text.ToString());
                
                /*objListaVoucherDet[index].TAOB = cmb_OperacionesBanc.SelectedValue.ToString();*/
                objListaVoucherDet[index].TAOB = cmb_OperacionesBanc.Text;
                grd_VoucherDet.DataSource = null;
                grd_VoucherDet.DataSource = objListaVoucherDet;
                grd_VoucherDet.Refresh();
                //habilitaCampos(false, false);
                // limpiarCampos();
                txt_Importe.Enabled = false;
                sumatoria();
            }


        }
        void habilitaCampos(bool bhabilita, bool bhabilita2)
        {
            txt_BancoCod.Enabled = bhabilita2;

            txt_SolicitanteCod.Enabled = bhabilita2;
            txt_Observacion.Enabled = bhabilita2;
            dpick_FechaPago.Enabled = bhabilita2;
            //cmb_Moneda.Enabled = bhabilita2;
            cmb_TipoSolicitante.Enabled = bhabilita2;
            cmb_Operacion.Enabled = bhabilita2;
            txt_MovCod.Enabled = bhabilita2;
            rb_Metales.Enabled = bhabilita2;
            rb_Galvanizado.Enabled = bhabilita2;
        }
        void habilitaCamposAgregar(bool bhabilita, bool bhabilita2)
        {

            txt_SolicitanteCod.Enabled = bhabilita;
            txt_Observacion.Enabled = bhabilita;
            dpick_FechaPago.Enabled = bhabilita;
            /*cmb_Moneda.Enabled = bhabilita;*/
            txt_BancoCod.Enabled = bhabilita;
            cmb_TipoSolicitante.Enabled = bhabilita;
            cmb_Operacion.Enabled = bhabilita;
            txt_MovCod.Enabled = bhabilita;
            rb_Metales.Enabled = bhabilita;
            rb_Galvanizado.Enabled = bhabilita;
        }
        void limpiarCampos()
        {
            txt_MovCod.Text = "";
            txt_Movimiento.Text = "";
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {

            string msg = "";
            correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
            btn_SaveData.Enabled = false;
            /*if( objVoucherDao.convertToDouble(txt_Total.Text.Replace(",","")) != objVoucherDao.convertToDouble(txt_MontoTotal.Text.Replace(",", "")))
             {
                 MessageBox.Show("El Monto Total no es igual a la sumatoria de items");
                 btn_SaveData.Enabled = true;
                 return;
             }*/

            objVoucher = new Voucher();
            objVoucher.BancoCod = txt_BancoCod.Text;
            objVoucher.CodEnt = Ventas.UNIDADNEGOCIO;
            objVoucher.CuentaContable = txt_CuentaContable.Text;
            objVoucher.FechaEmision = dpick_FechaEmision.Value;
            objVoucher.FechaPago = dpick_FechaPago.Value;
            objVoucher.MonedaCod = cmb_Moneda.SelectedValue.ToString();
            objVoucher.TipoMovimiento = txt_Movimiento.Text;
            // objVoucher.Monto =  objListaVoucherDet.Sum(x => x.Importe);
            objVoucher.Monto = objVoucherDao.convertToDouble(txt_MontoTotal.Text);
            if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03")
            {
                objVoucher.NumeroCheque = txt_NroCheque.Text;
            }
            objVoucher.NumeroCuenta = txt_NroCuenta.Text;
            objVoucher.Observacion = txt_Observacion.Text;
            objVoucher.SolicitaCod = txt_SolicitanteCod.Text;
            objVoucher.TpersonaCod = cmb_TipoSolicitante.SelectedValue.ToString();
            if (OperacionGuardar == "M")
            {
                objVoucher.NumeroVoucher = txt_NroVoucher.Text;
            }
            else
            {
                objVoucher.NumeroVoucher = correlativo;
            }
            objVoucher.Ejercicio = cmb_ejercicio2.SelectedValue.ToString();
            objVoucher.Periodo = cmb_periodo.SelectedValue.ToString();
            bool insert;
            /*if (txt_Movimiento.Text != "")
            {*/
            if (OperacionGuardar == "M")
            {

                insert = objVoucherDao.updateVoucherCab(objVoucher, Ventas.UsuarioSession);
                if (insert)
                {
                }
                else
                {
                    msg = "Hubo un problema al modificar";
                    MessageBox.Show(msg);
                    btn_SaveData.Enabled = true;
                    return;
                }
                objVoucherDao.deleteVoucherDet(objVoucher.NumeroVoucher, Ventas.UNIDADNEGOCIO);

                for (int i = 0; i < objListaVoucherDet.Count; i++)
                {
                    objListaVoucherDet[i].CodEnt = "01";
                    insert = objVoucherDao.insertarVoucherDet(objListaVoucherDet[i]);
                    if (insert == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                    else
                    {
                        if (TipoMovimiento == "01" || TipoMovimiento == "07")
                        {
                            objPagoVoucherDao.ActualizarPago(objListaVoucherDet[i].numeroRegistro, objListaVoucherDet[i].TotalDocumento, objListaVoucherDet[i].Importe);
                        }
                        else if (TipoMovimiento == "09")
                        {

                            objPagoVoucherDao.ActualizarAbono(objListaVoucherDet[i].SerieDocRef, objListaVoucherDet[i].NumeroDocRef, objListaVoucherDet[i].Importe);

                        }
                    }
                }
                if (insert)
                {
                    MessageBox.Show("Voucher Guardado exitosamente");
                    btn_SaveData.Enabled = true;
                    string MessageBoxTitle = "Voucher";
                    string MessageBoxContent = "Voucher Guardado exitosamente,¿Desea Imprimir?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            String reportetipo = "";
                            btn_Reporte.Enabled = false;
                            objListaVoucherReporte = new List<VoucherReporte>();

                            formatearVoucher2();
                            if (objVoucher.MonedaCod == "USD")
                            {
                                reportetipo = "VOD";
                            }
                            else
                            {
                                reportetipo = "VO";
                            }
                            ReporteView Check1 = new ReporteView(reportetipo); // listar factura
                            Check1.Show();
                            btn_Reporte.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR :" + ex.Message);
                            btn_Reporte.Enabled = true;
                        }

                    }
                    else
                    {
                        this.Close();
                        ListaEmisionVoucher check2 = new ListaEmisionVoucher();
                        check2.Show();
                    }
                }
            }
            else
            {   /*se inserta la cabecera del voucher*/

                insert = objVoucherDao.insertarVoucherCab(objVoucher, Ventas.UsuarioSession);
                if (insert)
                {



                }
                else
                {
                    msg = "Hubo un problema al guardar";
                    MessageBox.Show(msg);
                    btn_SaveData.Enabled = true;
                    return;
                }
                /*se recorre todo el formulario para poder insertar en las tablas*/
                for (int i = 0; i < objListaVoucherDet.Count; i++)
                {
                    objListaVoucherDet[i].CodEnt = "01";

                    /*se genera el detalle del voucher*/
                    if(txt_MovCod.Text.ToString()=="02")
                    {
                        if (objListaVoucherDet[i].TAOB.ToString() == "01")
                        {
                            objListaVoucherDet[i].TAOB = txt_Movimiento.Text;
                        }
                        else
                        {
                            objListaVoucherDet[i].TAOB = cmb_OperacionesBanc.Text.ToString();
                            objListaVoucherDet[i].Item = i + 1;
                        }
                    }
                    objListaVoucherDet[i].TAOB = txt_Movimiento.Text;
                    if (txt_MovCod.Text.ToString() == "08")
                    {
                        objListaVoucherDet[i].FechaEmiRef = dpick_FechaEmision.Value.ToString();
                    }

                    insert = objVoucherDao.insertarVoucherDet(objListaVoucherDet[i]);
                    /*se inserta el Prestamo Bancario*/
                    if(txt_MovCod.Text.ToString()=="08")
                    {
                        objListaVoucherDet[i].FechaEmiRef = dpick_FechaEmision.Value.ToString();
                        objVoucherDao.insertarPrestamoBancario(objListPrestamoBancario[i], Ventas.UsuarioSession);
                    }

                    if (insert == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                    else
                    {
                        if (TipoMovimiento == "01" || TipoMovimiento == "07")
                        {
                            objPagoVoucherDao.registrarPago(objListaVoucherDet[i].numeroRegistro, objListaVoucherDet[i].TotalDocumento, objListaVoucherDet[i].Importe);

                        }
                        else if (TipoMovimiento == "09")
                        {
                            objPagoVoucherDao.registrarAbono(objListaVoucherDet[i].SerieDocRef, objListaVoucherDet[i].NumeroDocRef, objListaVoucherDet[i].Importe);

                        }
                        else if (TipoMovimiento == "02" && cmb_TipoSolicitante.SelectedValue.ToString() == "05")
                        {
                            bool tp;
                            double total = 0;
                            double cambio = 0;
                            if (objListaVoucherDet[i].Moneda == "USD")
                            {
                                total = objListaVoucherDet[i].Importe;
                                cambio = objListaVoucherDet[i].TC;
                                objListaVoucherDet[i].Importe = total / cambio;
                                objListaVoucherDet[i].ImporteReporte = total;
                                objPagoVoucherDao.registrarDetraccionFactura(objListaVoucherDet[i].SerieDocRef, objListaVoucherDet[i].NumeroDocRef, objListaVoucherDet[i].Importe);
                            }
                            else
                            {
                                objPagoVoucherDao.registrarDetraccionFactura(objListaVoucherDet[i].SerieDocRef, objListaVoucherDet[i].NumeroDocRef, objListaVoucherDet[i].Importe);
                            }
                        }
                        else if (TipoMovimiento == "02")
                        {
                            objPagoVoucherDao.registrarDetraccionPago(objListaVoucherDet[i].numeroRegistro, objListaVoucherDet[i].Importe);
                        }


                    }
                }
                if (insert)
                {
                   if(cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03")
                    {
                        objChequeDAO.updateNroChequeActual(objVoucher.CodEnt, objVoucher.BancoCod, objVoucher.MonedaCod, txt_NroCheque.Text);
                    }
                    /*MessageBox.Show("Voucher Guardado exitosamente");*/
                    btn_SaveData.Enabled = true;

                    string MessageBoxTitle = "Voucher";
                    string MessageBoxContent = "Voucher Guardado exitosamente,¿Desea Imprimir?";

                    DialogResult dialogResult = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            String reportetipo = "";
                            btn_Reporte.Enabled = false;
                            objListaVoucherReporte = new List<VoucherReporte>();

                            formatearVoucher2();
                            if (objVoucher.MonedaCod == "USD")
                            {
                                reportetipo = "VO";
                            }
                            else if(objVoucher.MonedaCod == "PEN")
                            {
                                reportetipo = "VO";
                            }
                            else if( objVoucher.MonedaCod == "EUR")
                            {
                                reportetipo = "VO";
                            }
                            ReporteView Check1 = new ReporteView(reportetipo); // listar factura
                            Check1.Show();
                            btn_Reporte.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("ERROR :" + ex.Message);
                            btn_Reporte.Enabled = true;
                        }

                    }
                    else
                    {
                        this.Close();
                        ListaEmisionVoucher check2 = new ListaEmisionVoucher();
                        check2.Show();
                    }
                }

            }
            this.Close();
            ListaEmisionVoucher check = new ListaEmisionVoucher();
            check.Show();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            OperacionGuardar = "M";
            change = "C";
            //contador = objListaVoucherDet.Max(x => x.Item) +1;
            habilitaCampos(false, true);
            if (cmb_Operacion.SelectedValue.ToString() == "01" || cmb_Operacion.SelectedValue.ToString() == "02")
            {
                dpick_FechaEmision.Enabled = true;
            }
            else
            {
                dpick_FechaEmision.Enabled = false;
            }

            habilitarBotones(true, false);
            btn_SaveData.Enabled = true;
        }

        private void btn_BuscarDocumentos_Click(object sender, EventArgs e)
        {
            String Ruc = "";
            if (cmb_Operacion.SelectedValue.ToString() == "02" || cmb_Operacion.SelectedValue.ToString() == "03")
            {
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "02")
                {
                    Ruc = txt_SolicitanteCod.Text;
                }
                else if (cmb_TipoSolicitante.SelectedValue.ToString() == "03")
                {
                    Ruc = "NN";
                }
                TipoOperacionBanco = "C";
                Busqueda.BuscarDocVoucher check = new Busqueda.BuscarDocVoucher(Ruc, "V");
                check.Show();
            }
            else
            {
                TipoOperacionBanco = "A";
                if (cmb_TipoSolicitante.SelectedValue.ToString() == "02")
                {
                    Ruc = txt_SolicitanteCod.Text;
                }
                else if (cmb_TipoSolicitante.SelectedValue.ToString() == "03")
                {
                    Ruc = "NN";
                }
                Busqueda.BuscarDocVoucher check = new Busqueda.BuscarDocVoucher(Ruc, "V");
                check.Show();
            }

        }
        public void setDatosDoc(String serie, String num, Double monto, String numreg, Double total)
        {

            txt_TotalDocumento.Text = total.ToString();

            txt_NumReg.Text = numreg;
        }
        public void setDatosAbono(String serie, String num, Double monto, Double total)
        {

            txt_TotalDocumento.Text = total.ToString();
        }

        void formatearVoucher2()
        {
            if (objListaVoucherDet.Count >= 1)
            {
                for (int i = 0; i < objListaVoucherDet.Count; i++)
                {
                    VoucherReporte objVoucherReporte;
                    objVoucherReporte = new VoucherReporte();
                    objVoucherReporte.Banco = txt_Banco.Text.ToString();
                    objVoucherReporte.Fecha = objVoucher.FechaPago.ToString("dd/MM/yyyy");
                    objVoucherReporte.Monto = txt_Total.Text /*.Substring(3)*/;
                    if (cmb_Moneda.SelectedValue.ToString() == "PEN")
                    {
                        objVoucher.Moneda = "SOLES";
                    }
                    else if(cmb_Moneda.SelectedValue.ToString() == "USD")
                    {
                        objVoucher.Moneda = "DOLARES AMERICANOS";
                    }
                    else if(cmb_Moneda.SelectedValue.ToString() == "EUR")
                    {
                        objVoucher.Moneda = "EUROS";
                    }
                    objVoucherReporte.MontoLetras = objDocumentoDAO.numeroALetras(objVoucher.Monto) + " " + objVoucher.Moneda;
                    /*objVoucherReporte.NroCheque = txt_NroDoc.Text;*/

                    correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                    if (OperacionGuardar == "M" || ListaEmisionVoucher.operacionVoucher == "V")
                    {
                        objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                    }
                    else
                    {
                        objVoucherDet.NumeroVoucher = correlativo;
                    }
                    objVoucherReporte.NroVoucher = objVoucher.NumeroVoucher;
                    objVoucherReporte.Observacion = objVoucher.Observacion;
                    objVoucherReporte.Persona = txt_Solicitante.Text;
                    objVoucherReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objVoucher.FechaPago.ToShortDateString()).ToString().PadRight(5, '0');
                    objVoucherReporte.Usuario = Ventas.UsuarioSession;
                    if (objVoucher.TpersonaCod == "04")
                    {
                        objVoucherReporte.PersonaDocumento = "";
                    }
                    else
                    {
                        objVoucherReporte.PersonaDocumento = objVoucher.SolicitaCod;
                    }
                    if (objVoucher.Estado == "A")
                    {
                        objVoucherReporte.Anulado = "A N U L A D O";
                    }
                    objVoucherReporte.Descripcion = objListaVoucherDet[i].TAOB.ToString();
                    objVoucherReporte.FechaEmision = objListaVoucherDet[i].FechaEmiRef.ToString();
                    if (OperacionGuardar == "M")
                    {
                        objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00");
                    }
                    else if (OperacionGuardar == "A")
                    {
                        objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00");
                    }
                    else
                    {
                        objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00");
                    }
                    objVoucherReporte.NroDocumento = objListaVoucherDet[i].Descripcion;

                    objVoucherReporte.Ruc = objListaVoucherDet[i].NroOt + " " + "-" + " " + objListaVoucherDet[i].DirOt;

                    objListaVoucherReporte.Add(objVoucherReporte);
                }
            }
            else
            {
                VoucherReporte objVoucherReporte;
                // for (int i = 0; i < objListaVoucherDet.Count; i++)
                // {
                objVoucherReporte = new VoucherReporte();
                objVoucherReporte.Banco = objVoucher.Banco;
                //objVoucherReporte.Descripcion = objListaVoucherDet[i].Descripcion;
                objVoucherReporte.Fecha = objVoucher.FechaPago.ToString("dd/MM/yyyy");
                //objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("C").Substring(3);
                objVoucherReporte.Monto = objVoucher.Monto.ToString("G")/*.Substring(3)*/;
                objVoucherReporte.MontoLetras = objDocumentoDAO.numeroALetras(objVoucher.Monto) + " " + objVoucher.Moneda.TrimEnd();
                objVoucherReporte.NroCheque = objVoucher.NumeroCheque;
                //objVoucherReporte.NroDocumento = objListaVoucherDet[i].NroDocumento;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }
                objVoucherReporte.NroVoucher = objVoucher.NumeroVoucher;
                objVoucherReporte.Observacion = objVoucher.Observacion;
                objVoucherReporte.Persona = objVoucher.Solicitante;
                if (objVoucher.TpersonaCod == "04")
                {
                    objVoucherReporte.PersonaDocumento = "";
                }
                else
                {
                    objVoucherReporte.PersonaDocumento = objVoucher.SolicitaCod;
                }
                if (objVoucher.Estado == "A")
                {
                    objVoucherReporte.Anulado = "A N U L A D O";
                }

                //objVoucherReporte.RazonSocial = objListaVoucherDet[i].
                //objVoucherReporte.Ruc = objListaVoucherDet[i].
                objVoucherReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objVoucher.FechaPago.ToShortDateString()).ToString().PadRight(5, '0');
                objVoucherReporte.Usuario = Ventas.UsuarioSession;
                objListaVoucherReporte.Add(objVoucherReporte);
                // }
            }
        }
        void formatearVoucher()
        {
            if (objListaVoucherDet.Count >= 1)
            {
                for (int i = 0; i < objListaVoucherDet.Count; i++)
                {
                    VoucherReporte objVoucherReporte;
                    objVoucherReporte = new VoucherReporte();
                    objVoucherReporte.Banco = objVoucher.Banco;
                    objVoucherReporte.Fecha = objVoucher.FechaPago.ToString("dd/MM/yyyy");
                    objVoucherReporte.Monto = txt_Total.Text /*.Substring(3)*/;
                    if (cmb_Moneda.SelectedValue.ToString() == "PEN")
                    {
                        objVoucher.Moneda = "SOLES";
                    }
                    else if (cmb_Moneda.SelectedValue.ToString() == "USD")
                    {
                        objVoucher.Moneda = "DOLARES AMERICANOS";
                    }
                    else if (cmb_Moneda.SelectedValue.ToString() == "EUR")
                    {
                        objVoucher.Moneda = "EUROS";
                    }

                    objVoucherReporte.MontoLetras = objDocumentoDAO.numeroALetras(objVoucher.Monto) + " " + objVoucher.Moneda;
                    /*objVoucherReporte.NroCheque = txt_NroDoc.Text;*/

                    correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                    if (OperacionGuardar == "M" || ListaEmisionVoucher.operacionVoucher == "V")
                    {
                        objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                    }
                    else
                    {
                        objVoucherDet.NumeroVoucher = correlativo;
                    }
                    objVoucherReporte.NroVoucher = objVoucher.NumeroVoucher;
                    objVoucherReporte.Observacion = objVoucher.Observacion;
                    objVoucherReporte.Persona = txt_Solicitante.Text;
                    objVoucherReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objVoucher.FechaPago.ToShortDateString()).ToString().PadRight(5, '0');
                    objVoucherReporte.Usuario = Ventas.UsuarioSession;
                    if (objVoucher.TpersonaCod == "04")
                    {
                        objVoucherReporte.PersonaDocumento = "";
                    }
                    else
                    {
                        objVoucherReporte.PersonaDocumento = objVoucher.SolicitaCod;
                    }
                    if (objVoucher.Estado == "A")
                    {
                        objVoucherReporte.Anulado = "A N U L A D O";
                    }
                    objVoucherReporte.Descripcion = objListaVoucherDet[i].TAOB.ToString();
                    objVoucherReporte.FechaEmision = objListaVoucherDet[i].FechaEmiRef.ToString();
                    if(OperacionGuardar=="M")
                    {
                        objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00");
                    }
                    else if(OperacionGuardar == "A")
                    {
                        objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00");
                    }
                    else
                    {
                        objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00");
                    }
                    objVoucherReporte.NroDocumento = objListaVoucherDet[i].NroDocumento;

                    objVoucherReporte.Ruc = objListaVoucherDet[i].NroOt + " " + "-" + " " + objListaVoucherDet[i].DirOt;

                    objListaVoucherReporte.Add(objVoucherReporte);
                }
            }
            else
            {
                VoucherReporte objVoucherReporte;
                // for (int i = 0; i < objListaVoucherDet.Count; i++)
                // {
                objVoucherReporte = new VoucherReporte();
                objVoucherReporte.Banco = objVoucher.Banco;
                //objVoucherReporte.Descripcion = objListaVoucherDet[i].Descripcion;
                objVoucherReporte.Fecha = objVoucher.FechaPago.ToString("dd/MM/yyyy");
                //objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("C").Substring(3);
                objVoucherReporte.Monto = objVoucher.Monto.ToString("G")/*.Substring(3)*/;
                objVoucherReporte.MontoLetras = objDocumentoDAO.numeroALetras(objVoucher.Monto) + " " + objVoucher.Moneda.TrimEnd();
                objVoucherReporte.NroCheque = objVoucher.NumeroCheque;
                //objVoucherReporte.NroDocumento = objListaVoucherDet[i].NroDocumento;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }
                objVoucherReporte.NroVoucher = objVoucher.NumeroVoucher;
                objVoucherReporte.Observacion = objVoucher.Observacion;
                objVoucherReporte.Persona = objVoucher.Solicitante;
                if (objVoucher.TpersonaCod == "04")
                {
                    objVoucherReporte.PersonaDocumento = "";
                }
                else
                {
                    objVoucherReporte.PersonaDocumento = objVoucher.SolicitaCod;
                }
                if (objVoucher.Estado == "A")
                {
                    objVoucherReporte.Anulado = "A N U L A D O";
                }

                //objVoucherReporte.RazonSocial = objListaVoucherDet[i].
                //objVoucherReporte.Ruc = objListaVoucherDet[i].
                objVoucherReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objVoucher.FechaPago.ToShortDateString()).ToString().PadRight(5, '0');
                objVoucherReporte.Usuario = Ventas.UsuarioSession;
                objListaVoucherReporte.Add(objVoucherReporte);
                // }
            }
        }
        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            String root = @"N:\VOUCHER";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                btn_imprimir.Enabled = false;
                objListaVoucherReporte = new List<VoucherReporte>();


                String nombreArchivo = "Voucher-" + objVoucher.NumeroVoucher;
                formatearVoucher();
                if (objVoucher.MonedaCod == "USD")
                {
                    VoucherRptDolar cr = new VoucherRptDolar();
                    string rut = @"N:\VOUCHER\" + nombreArchivo + ".pdf";
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    if (File.Exists(rut))
                    {
                        File.Delete(rut);
                    }


                    cr.SetDataSource(objListaVoucherReporte);
                    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rut);
                    using (PrintDialog Dialog = new PrintDialog())
                    {
                        Dialog.ShowDialog();

                        ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                        {
                            Verb = "print",
                            CreateNoWindow = true,
                            FileName = rut,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                        Process printProcess = new Process();
                        printProcess.StartInfo = printProcessInfo;
                        printProcess.Start();

                        printProcess.WaitForInputIdle();

                        Thread.Sleep(3000);

                        if (false == printProcess.CloseMainWindow())
                        {
                            printProcess.Kill();
                        }
                    }
                }
                else
                {
                    VoucherRpt cr = new VoucherRpt();
                    string rut = @"N:\VOUCHER\" + nombreArchivo + ".pdf";
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    if (File.Exists(rut))
                    {
                        File.Delete(rut);
                    }


                    cr.SetDataSource(objListaVoucherReporte);
                    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rut);
                    using (PrintDialog Dialog = new PrintDialog())
                    {
                        Dialog.ShowDialog();

                        ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                        {
                            Verb = "print",
                            CreateNoWindow = true,
                            FileName = rut,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };

                        Process printProcess = new Process();
                        printProcess.StartInfo = printProcessInfo;
                        printProcess.Start();

                        printProcess.WaitForInputIdle();

                        Thread.Sleep(3000);

                        if (false == printProcess.CloseMainWindow())
                        {
                            printProcess.Kill();
                        }
                    }

                }







            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btn_imprimir.Enabled = true;
            }
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                String reportetipo = "";
                btn_Reporte.Enabled = false;
                objListaVoucherReporte = new List<VoucherReporte>();

                formatearVoucher();
                if (objVoucher.MonedaCod == "USD")
                {
                    reportetipo = "VO";
                }
                else if (objVoucher.MonedaCod == "PEN")
                {
                    reportetipo = "VO";
                }
                else if (objVoucher.MonedaCod == "EUR")
                {
                    reportetipo = "VO";
                }
                ReporteView Check = new ReporteView(reportetipo); // listar factura
                Check.Show();
                btn_Reporte.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_Reporte.Enabled = true;
            }

        }

        public void gridCheke()
        {
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);
            objVoucherDet = new VoucherDet();

            objVoucherDet.NroOt = txt_NroOt.Text;


        }
        //set de datos para la tabla
        public void setDatosInsertarPrestamo(PrestamoBancario obj)
        {
            objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);


            objVoucherDet = new VoucherDet();

            objVoucherDet.NroOt = "";
            objVoucherDet.Descripcion = "Préstamo Bancario-" + obj.Banco;
            objVoucherDet.Documento = obj.CodigoPrestamo;
            objVoucherDet.RazonSocial = obj.Banco;
            objVoucherDet.Importe = obj.Monto;
            objVoucherDet.numeroRegistro = obj.CodigoPrestamo;
            correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
            if (OperacionGuardar == "M")
            {
                objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
            }
            else
            {
                objVoucherDet.NumeroVoucher = correlativo;
            }
            objVoucherDet.Item = 1;
            objListaVoucherDet.Add(objVoucherDet);



            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();//refrescar los valores
            sumatoria();//suma el tot
            objListPrestamoBancario.Add(obj);

        }


        public void setDatosPrestamoBancario(List<PrestamoBancario> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();
                objVoucherDet.NroOt = "";
                objVoucherDet.Descripcion = "Pago Préstamo Bancario-" + objList[i].Banco;
                objVoucherDet.Documento = objList[i].CodigoPrestamo;
                objVoucherDet.RazonSocial = objList[i].Banco;
                objVoucherDet.Importe = objList[i].Monto;
                objVoucherDet.numeroRegistro = objList[i].CodigoPrestamo;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }
                objVoucherDet.Item = i + 1;

                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
        }
        public void setDatosDetraccionCajaChica(List<ContabilidadDTO.Ventas> objList)
        {
            if (grd_VoucherDet.Columns.Count > 1)
            {
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }
            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "F.E";
            idColumn7.DataPropertyName = "FechaEmision";
            idColumn7.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = "0.00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "CodOt";
            idColumn4.DataPropertyName = "CodOt";
            idColumn4.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn4);

            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "DirOt";
            idColumn5.DataPropertyName = "DirOt";
            idColumn5.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn5);

            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "TipoDoc";
            idColumn6.DataPropertyName = "TipDocRef";
            idColumn6.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn6);


            grd_VoucherDet.Columns.Add(idColumn6);
            grd_VoucherDet.Columns[4].Visible = false;
            grd_VoucherDet.Columns[5].Visible = false;
            grd_VoucherDet.Columns[6].Visible = false;

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();
                objVoucherDet.CodOt = objList[i].CodOt;
                objVoucherDet.NroOt = objList[i].NroOt;
                objVoucherDet.DirOt = objList[i].DirOt;
                objVoucherDet.TipDocRef = objList[i].TipoDocumento;
                objVoucherDet.Descripcion = objList[i].Serie.Trim() + "-" + objList[i].Numero.Trim();
                objVoucherDet.Documento = objList[i].Ruc;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                objVoucherDet.Importe = objList[i].TotalSoles;
                objVoucherDet.numeroRegistro = objList[i].VentasId;
                objVoucherDet.FechaEmiRef = objList[i].FechaEmision;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }


                objVoucherDet.Item = i + 1;
                objVoucherDet.TotalDocumento = objList[i].Total;
                if (rb_Metales.Checked)
                {
                    objVoucherDet.CodEnt = "01";
                }
                else
                {
                    objVoucherDet.CodEnt = "02";
                }

                objListaVoucherDet.Add(objVoucherDet);
            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();

        }
        public void llenarDetalle(List<VoucherDet> ObjLista)
        {
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 150;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "FechaEmiRef";
            idColumn4.DefaultCellStyle.ToString();
            idColumn4.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            grd_VoucherDet.DataSource = ObjLista;
            grd_VoucherDet.Refresh();
        }
        public void setDatosCajaChica(List<ContabilidadDTO.Ventas> objList)
        {
            bool porcentaje = false;
            int cont = 0;
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Fecha Emision";
            idColumn2.DataPropertyName = "FechaEmision";
            idColumn2.Width = 100;
            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "N°Doc";
            idColumn11.DataPropertyName = "Documento";
            idColumn11.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn11);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Retención";
            idColumn4.DataPropertyName = "xret";
            idColumn4.Width = 60;
            grd_VoucherDet.Columns.Add(idColumn4);

            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Percección";
            idColumn6.DataPropertyName = "xper";
            idColumn6.Width = 60;
            grd_VoucherDet.Columns.Add(idColumn6);

            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Buen ";
            idColumn7.DataPropertyName = "xbue";
            idColumn7.Width = 60;
            grd_VoucherDet.Columns.Add(idColumn7);

            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Detracción";
            idColumn8.DataPropertyName = "xdetra";
            idColumn8.Width = 60;
            grd_VoucherDet.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Direccion ot";
            idColumn9.DataPropertyName = "DirOt";
            idColumn9.Width = 60;
            grd_VoucherDet.Columns.Add(idColumn9);

            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Documento";
            idColumn10.DataPropertyName = "TipDocRef";
            idColumn10.Width = 60;
            grd_VoucherDet.Columns.Add(idColumn10);

            grd_VoucherDet.Columns[6].Visible = false;
            grd_VoucherDet.Columns[7].Visible = false;
            grd_VoucherDet.Columns[8].Visible = false;
            grd_VoucherDet.Columns[9].Visible = false;
            grd_VoucherDet.Columns[10].Visible = false;
            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();
                objVoucherDet.CodOt = objList[i].CodOt;
                objVoucherDet.CodOtReal = objList[i].CodOtReal;
                objVoucherDet.NroOt = objList[i].NroOt;
                objVoucherDet.NroOtReal = objList[i].NroOtReal;
                objVoucherDet.Descripcion = objList[i].Serie.Trim() + "-" + objList[i].Numero.Trim();
                objVoucherDet.Documento = objList[i].Ruc;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                objVoucherDet.Importe = objList[i].Pago;
                objVoucherDet.numeroRegistro = objList[i].VentasId;
                objVoucherDet.FechaEmiRef = objList[i].FechaEmision;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucher.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }
                objVoucherDet.Item = i + 1;
                objVoucherDet.xret = objList[i].xret;
                objVoucherDet.xper = objList[i].xper;
                objVoucherDet.xbue = objList[i].xbue;
                objVoucherDet.xdetra = objList[i].xdetra;
                objVoucherDet.DirOt = objList[i].DirOt;
                objVoucherDet.DirOtReal = objList[i].DirOtReal;
                objVoucherDet.TipDocRef = objList[i].TipoDocumento;

                if (objList[i].xret.ToString() == "TRET" && objList[i].xbue.ToString() == "TBUE" && objList[i].xdetra.ToString() == "no")
                {
                    porcentaje = true;
                }
                else if (objList[i].xret.ToString() == "TRET" && objList[i].xdetra.ToString() == "no")
                {
                    cont++;
                }
                else if (objList[i].xbue.ToString() == "TBUE" && objList[i].xdetra.ToString() == "no")
                {
                    cont++;
                }
                objVoucherDet.TotalDocumento = objList[i].Total;
                if (rb_Metales.Checked)
                {
                    objVoucherDet.CodEnt = "01";
                }
                else
                {
                    objVoucherDet.CodEnt = "02";
                }

                objListaVoucherDet.Add(objVoucherDet);
            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();

            if (objList.Count == cont)
            {

                sumatoria30();
            }
            else
            {
                sumatoria();
            }


        }

        /*datos para listar la factura abono que seran para las cuentas por cobrar*/
        public void setDatosAbonoFactura(List<FacturaAbono> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = "0.00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();

                objVoucherDet.NroOt = objList[i].NroOt;
                objVoucherDet.Descripcion = objList[i].Serie + "-" + objList[i].Numero;
                objVoucherDet.Documento = objList[i].Ruc;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                objVoucherDet.Importe = objList[i].Pago;
                //objVoucherDet.numeroRegistro = objList[i].VentasId;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }

                objVoucherDet.Item = i + 1;
                objVoucherDet.TotalDocumento = objList[i].Total;
                objVoucherDet.SerieDocRef = objList[i].Serie;
                objVoucherDet.NumeroDocRef = objList[i].Numero;
                if (rb_Metales.Checked)
                {
                    objVoucherDet.CodEnt = "01";
                }
                else
                {
                    objVoucherDet.CodEnt = "02";
                }

                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
        }

        public void setDatosDetraccionFactura(List<FacturaAbono> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {
                grd_VoucherDet.Columns.Remove("N° OT");
                grd_VoucherDet.Columns.Remove("Descripcion/N°Comprobante");
                grd_VoucherDet.Columns.Remove("F.E");
                grd_VoucherDet.Columns.Remove("N°Doc");
                grd_VoucherDet.Columns.Remove("Razon Social");
                grd_VoucherDet.Columns.Remove("Importe");
                grd_VoucherDet.Columns.Remove("Tipo Cambio");
                grd_VoucherDet.Columns.Remove("Moneda");
                grd_VoucherDet.Columns.Remove("TAOB");
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "N° OT";
            idColumn0.DataPropertyName = "NroOt";
            idColumn0.Width = 70;
            grd_VoucherDet.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 140;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "F.E";
            idColumn2.DataPropertyName = "FechaEmiRef";
            idColumn2.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "N°Doc";
            idColumn3.DataPropertyName = "Documento";
            idColumn3.Width = 90;
            grd_VoucherDet.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Razon Social";
            idColumn4.DataPropertyName = "RazonSocial";
            idColumn4.Width = 300;
            grd_VoucherDet.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Importe";
            idColumn5.DataPropertyName = "Importe";
            idColumn5.DefaultCellStyle.Format = ".00";
            idColumn5.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Tipo Cambio";
            idColumn6.DataPropertyName = "TC";
            idColumn6.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Moneda";
            idColumn7.DataPropertyName = "Moneda";
            idColumn7.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "TAOB";
            idColumn8.DataPropertyName = "TAOB";
            idColumn8.Width = 80;
            grd_VoucherDet.Columns.Add(idColumn8);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();

                objVoucherDet.NroOt = objList[i].NroOt;
                objVoucherDet.Descripcion = objList[i].Serie + "-" + objList[i].Numero;
                objVoucherDet.Documento = objList[i].Ruc;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                objVoucherDet.FechaEmiRef = objList[i].Fecha;
                objVoucherDet.Importe = objList[i].TotalSoles;
                objVoucherDet.TC = objList[i].TipoCambio;
                objVoucherDet.Moneda = objList[i].MonedaCod;
                objVoucherDet.TAOB = cmb_OperacionesBanc.SelectedValue.ToString();
                //objVoucherDet.numeroRegistro = objList[i].VentasId;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }

                objVoucherDet.Item = i + 1;
                objVoucherDet.TotalDocumento = objList[i].Total;
                objVoucherDet.SerieDocRef = objList[i].Serie;
                objVoucherDet.NumeroDocRef = objList[i].Numero;
                if (rb_Metales.Checked)
                {
                    objVoucherDet.CodEnt = "01";
                }
                else
                {
                    objVoucherDet.CodEnt = "02";
                }

                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
        }



        public void setDatosCargoBancario(List<CargoBancario> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();

                objVoucherDet.NroOt = "";
                objVoucherDet.Descripcion = objList[i].Descripcion;
                objVoucherDet.Documento = "";
                objVoucherDet.RazonSocial = "";
                objVoucherDet.Importe = objList[i].Monto;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }

                objVoucherDet.Item = i + 1;
                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
        }


        public void setDatosImpuestos(List<TipoImpuesto> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();

                objVoucherDet.NroOt = "";
                objVoucherDet.Descripcion = objList[i].Descripcion;
                objVoucherDet.Documento = "";
                objVoucherDet.RazonSocial = "";
                objVoucherDet.Importe = objList[i].Pago;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;

                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }

                objVoucherDet.Item = i + 1;
                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
        }
        public void setDatosPlanilla(List<Personal> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();

                objVoucherDet.NroOt = objList[i].CentroCosto;
                objVoucherDet.Descripcion = objList[i].Descripcion;
                objVoucherDet.Documento = objList[i].NroDocumento;
                objVoucherDet.RazonSocial = objList[i].Nombre;
                objVoucherDet.Importe = objList[i].Pago;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }

                objVoucherDet.Item = i + 1;
                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
        }
        public void setDatosAFP(List<Personal> objList)
        {
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_VoucherDet.Columns.Count > 1)
            {

                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
                grd_VoucherDet.Columns.RemoveAt(0);
            }

            //  objListaFacturaAbono = objList;
            grd_VoucherDet.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumnOT = new DataGridViewTextBoxColumn();
            idColumnOT.Name = "N° OT";
            idColumnOT.DataPropertyName = "NroOt";
            idColumnOT.Width = 100;
            grd_VoucherDet.Columns.Add(idColumnOT);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Descripcion/N°Comprobante";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 180;
            grd_VoucherDet.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Doc";
            idColumn2.DataPropertyName = "Documento";
            idColumn2.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumnR = new DataGridViewTextBoxColumn();
            idColumnR.Name = "Razon Social";
            idColumnR.DataPropertyName = "RazonSocial";
            idColumnR.Width = 300;
            grd_VoucherDet.Columns.Add(idColumnR);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.DefaultCellStyle.Format = ".00";
            idColumn3.Width = 100;
            grd_VoucherDet.Columns.Add(idColumn3);

            for (int i = 0; i < objList.Count; i++)
            {
                objVoucherDet = new VoucherDet();

                objVoucherDet.NroOt = objList[i].CentroCosto;
                objVoucherDet.Descripcion = objList[i].Afp;
                objVoucherDet.Documento = objList[i].NroDocumento;
                objVoucherDet.RazonSocial = objList[i].Nombre;
                objVoucherDet.Importe = objList[i].Pago;
                correlativo = correlativo = objVoucherDao.getCorrelativoVoucher(Ventas.UNIDADNEGOCIO, DateTime.Now.Year.ToString().Substring(2));
                if (OperacionGuardar == "M")
                {
                    objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                }
                else
                {
                    objVoucherDet.NumeroVoucher = correlativo;
                }

                objVoucherDet.Item = i + 1;
                objListaVoucherDet.Add(objVoucherDet);

            }
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();

        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            objListaVoucherDet = null;
            objListaVoucherDet = new List<VoucherDet>();
            objVoucher = null;
            objVoucher = new Voucher();
            habilitaCampos(true, true);
            habilitarBotones(true, false);
        }

        private void btn_Rest_Click(object sender, EventArgs e)
        {
            objListaVoucherDet.RemoveAt(index);
            grd_VoucherDet.DataSource = null;
            grd_VoucherDet.DataSource = objListaVoucherDet;
            grd_VoucherDet.Refresh();
            sumatoria();
            sumatoria30();
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
        private void txt_NroVoucher_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_SolicitanteCod_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cmb_TipoSolicitante_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_Solicitante_TextChanged(object sender, EventArgs e)
        {

        }

        private void rb_Galvanizado_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EmisionVoucher_Load(object sender, EventArgs e)
        {

        }

        private void txt_MovCod_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txt_MontoTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Total_TextChanged(object sender, EventArgs e)
        {

        }

        private void grd_VoucherDet_Click(object sender, EventArgs e)
        {
            index = grd_VoucherDet.SelectedCells[0].RowIndex;
            DataGridViewRow dtg = grd_VoucherDet.Rows[index];
            if (dtg.Cells[4].Value.ToString() != "")
            {
                btn_Editar.Enabled = true;
                btn_Limpiar.Enabled = true;
            }
            else
            {
                btn_Editar.Enabled = true;
                btn_Limpiar.Enabled = true;
            }

        }

        private void txt_MontoTotal_Leave(object sender, EventArgs e)
        {

        }

        private void grd_VoucherDet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grd_VoucherDet_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grd_VoucherDet_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dpick_FechaEmision_ValueChanged(object sender, EventArgs e)
        {
            dpick_FechaPago.Value = dpick_FechaEmision.Value;
            xperiodo = dpick_FechaPago.Value.Month.ToString();
            cmb_periodo.SelectedValue = xperiodo;
            xejercicio = dpick_FechaPago.Value.Year.ToString();
            cmb_ejercicio2.SelectedValue = xejercicio;

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
