using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContabilidadDAO;
using ContabilidadDTO;
using System.Globalization;
using System.Threading;
using Contabilidad.Busqueda;

namespace Contabilidad
{
    public partial class Factura : Form
    {

        DocumentoDet objDocumentoDet;
        DocumentoCab objDocumentoCab;

        TipoPagoDAO objTipoPagoDao;
        MonedaDAO objMonedaDao;
        DocumentoDAO objDocumento;
        Proceso objProceso;

        Ejercicio objEjercicio;

        List<Ejercicio> objListaEjercicio = new List<Ejercicio>();
        public static int index;
        public static int ContadorItem = 1;
        public static String Operacion = "Q";
        public static Factura formFactura;
        public static List<Moneda> objListMoneda = new List<Moneda>();
        public static List<Pago> objListTipPago = new List<Pago>();
        public static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<DocumentoElectronicoDet> objListDocumentoElectronicoDet = new List<DocumentoElectronicoDet>();
        public static DocumentoElectronicoCab objDocumentoElectronicoCab = new DocumentoElectronicoCab();
        public static String Modificar = "Q";
        public Factura()
        {
            InitializeComponent();
            Modificar = "G";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            this.ControlBox = false;
            this.Text = "FACTURAS";
            formFactura = this;
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            objEjercicio = new Ejercicio();
            objTipoPagoDao = new TipoPagoDAO();
            objDocumento = new DocumentoDAO();
            objProceso = new Proceso();
            comboMoneda();
            comboPago();
            cmbejercicio();
            chk_Detraccion.CheckedChanged += Chk_Detraccion_CheckedChanged;
            cmb_Pago.SelectedIndexChanged += Cmb_Pago_SelectedIndexChanged;
            gridParams();
            txt_Porcentaje.TextChanged += Txt_Porcentaje_TextChanged;
            txt_Porcentaje.Text = "0";
            if (ListaFactura.operacionFactura == "V")
            {
                if (ListaFactura.objDocumentoCab.EstadoSunat == 0)
                {
                    lbl_Anulado.Visible = true;
                }else if (ListaFactura.objDocumentoCab.EstadoSunat == 1)
                {
                    btn_Modificar.Visible = true;
                }
                habilitarBotones(false, false);
                habilitarCampos(false);
                txt_Guia.Enabled = false;
                txt_OT.Enabled = false;
                txt_Pedido.Enabled = false;
                txt_GlosaCab.Enabled = false;
                btn_BuscarOT.Enabled = false;
                btn_Limpiar.Enabled = false;
                btn_SaveData.Enabled = false;
                btn_Buscar.Enabled = false;
                dpck_Fechavcto.Enabled = false;
                dpick_Fecha.Enabled = false;
                cmb_Moneda.Enabled = false;
                cmb_Pago.Enabled = false;

                if (ListaFactura.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                {
                    lbl_Moneda.Text = "$";
                }
                else
                {
                    lbl_Moneda.Text = "S/";
                }
                objDocumentoDet = new DocumentoDet();

                if (objDocumentoDet.DocumentoProdUM == "NIU")
                {
                    txt_umcod.Text = "039";
                }
                else
                {
                    txt_umcod.Text = "040";
                }
                
                txt_Cliente.Text = ListaFactura.objDocumentoCab.DocumentoCabCliente;
                txt_Ruc.Text = ListaFactura.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Serie.Text = ListaFactura.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ListaFactura.objDocumentoCab.DocumentoCabNro;
                txt_GlosaCab.Text = ListaFactura.objDocumentoCab.DocumentoCabGlosa;
                txt_Direccion.Text = ListaFactura.objDocumentoCab.DocumentoCabClienteDireccion;
                cmb_Moneda.SelectedValue = ListaFactura.objDocumentoCab.DocumentoCabTipoMoneda;
                objListDocumentoDet = objDocumento.listarDetalle(ListaFactura.numeroDocumento, ListaFactura.numeroSerie, Ventas.UNIDADNEGOCIO);
                dpick_Fecha.Value = ListaFactura.objDocumentoCab.DocumentoCabFecha;
                tipoCambio(dpick_Fecha.Value.ToShortDateString());
                cmb_Pago.SelectedValue = ListaFactura.objDocumentoCab.DocumentoCabTipoPago;
                txt_Detraccion.Text =  ListaFactura.objDocumentoCab.DocumentoCabDetraccion.ToString();
                txt_Porcentaje.Text = ListaFactura.objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                txt_Guia.Text = ListaFactura.objDocumentoCab.DocumentoCabGuia;
                txt_intercorp.Text = ListaFactura.objDocumentoCab.Intercorp;
                txt_Pedido.Text = ListaFactura.objDocumentoCab.DocumentoCabOrdenCompra;
                txt_codcliente.Text = ListaFactura.objDocumentoCab.DocumentoCabClienteCod;
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
                llenarSumatorias();
            }
            else
            {
                if (Ventas.UNIDADNEGOCIO == "01")
                {
                    txt_Serie.Text = "F001";
                }
                else
                {
                    txt_Serie.Text = "F005";
                }

                txt_Numero.Text = objDocumento.correlativoFactura("01", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
                dpck_Fechavcto.Value = DateTime.Now.AddMonths(1);
                habilitarCampos(false);
                tipoCambio(DateTime.Now.ToShortDateString());
                objDocumentoCab = new DocumentoCab();
                objListDocumentoDet = new List<DocumentoDet>();
                ContadorItem = 1;
            }

            rb_OT.Select();




            dpick_Fecha.TextChanged += Dpick_Fecha_TextChanged;

            txt_PrecioUnitario.TextChanged += Txt_PrecioUnitario_TextChanged;
            txt_Cantidad.TextChanged += Txt_Cantidad_TextChanged;
            txt_Percepcion.Text = "0";
            grd_Detalle.CellClick += Grd_Detalle_CellClick;

            cmb_Moneda.SelectedValueChanged += Cmb_Moneda_SelectedValueChanged;


        }

        private void Txt_Porcentaje_TextChanged(object sender, EventArgs e)
        {
            if (Modificar == "M")
            {
                llenarSumatorias();
            }
        }

        private void Cmb_Pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpck_Fechavcto.Value = DateTime.Now;
            List<int> objInt = new List<int>();
            objInt = objListTipPago.Where(x => x.PagoId.ToString() == cmb_Pago.SelectedValue.ToString()).Select(x => x.Dias).ToList();
            dpck_Fechavcto.Value = dpck_Fechavcto.Value.AddDays(objInt[0]);
        }

        private void Chk_Detraccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Detraccion.Checked == true)
            {
                txt_Porcentaje.Enabled = true;
                txt_Porcentaje.Text = "";
               
            }
            else
            {
                txt_Porcentaje.Enabled = false;
                txt_Porcentaje.Text = "0";
            }

        }

        private void Cmb_Moneda_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmb_Moneda.SelectedValue.ToString() == "USD")
            {
                lbl_Moneda.Text = "$";
            }
            else
            {
                lbl_Moneda.Text = "S/";
            }
        }

        private void Grd_Detalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objListDocumentoDet.Count != 0)
            {
                objDocumentoDet = new DocumentoDet();
                index = grd_Detalle.SelectedCells[0].RowIndex;
                objDocumentoDet = objListDocumentoDet[index];
                txt_ItemN.Text = objDocumentoDet.DocumentoDetId.ToString();
                txt_CodigoProd.Text = objDocumentoDet.ProductoCod;
                txt_ProdDescrip.Text = objDocumentoDet.DocumentoDesProducto;
                txt_UM.Text = objDocumentoDet.DocumentoProdUMcorta;
                txt_Subtotal.Text = objDocumentoDet.DocumentoDetSubTotal.ToString();
                txt_PrecioUnitario.Text = objDocumentoDet.DocumentoDetPrecioSinIGV.ToString();
                txt_Cantidad.Text = objDocumentoDet.DocumentoDetCantidad.ToString();
                txt_GlosaDet.Text = objDocumentoDet.DocumentoDetGlosa;
                txt_OT.Text = objDocumentoDet.DocumentoDetNroOt;
               
                habilitarCampos(false);
            }


        }
        private void limpiarCampos()
        {
            txt_ItemN.Text = "";
            txt_CodigoProd.Text = "";
            txt_ProdDescrip.Text = "";
            txt_UM.Text = "";
            txt_Subtotal.Text = "";
            txt_PrecioUnitario.Text = "";
            txt_Cantidad.Text = "";
            txt_GlosaDet.Text = "";
            txt_Tabla.Text = "";
            txt_OT.Text = "";

        }

        private void habilitarCampos(bool bhabilitar)
        {
            txt_ProdDescrip.Enabled = bhabilitar;
            txt_GlosaDet.Enabled = bhabilitar;
            btn_BuscarProd.Enabled = bhabilitar;
            txt_PrecioUnitario.Enabled = bhabilitar;
            txt_Cantidad.Enabled = bhabilitar;
            
        }

        private void habilitarBotones(bool bhabilitar1, bool bhabilitar2)
        {
            btn_Add.Enabled = bhabilitar1;
            btn_Editar.Enabled = bhabilitar1;
            btn_Guardar.Enabled = bhabilitar2;
            btn_BuscarOT.Enabled = bhabilitar2;
        }

        private void Txt_Cantidad_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_PrecioUnitario.Text))
            {
                txt_Subtotal.Text = (Math.Round(convertToDouble(txt_PrecioUnitario.Text),2,MidpointRounding.AwayFromZero)  *convertToDouble(txt_Cantidad.Text) ).ToString();
            }
        }

        private void Txt_PrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_Cantidad.Text))
            {
                txt_Subtotal.Text = (convertToDouble(txt_Cantidad.Text) * Math.Round(convertToDouble(txt_PrecioUnitario.Text),2,MidpointRounding.AwayFromZero)).ToString();
            }

        }

        private void Dpick_Fecha_TextChanged(object sender, EventArgs e)
        {
            tipoCambio(dpick_Fecha.Value.ToShortDateString());
        }

        public void tipoCambio(String date)
        {
            txt_Tcambio.Text = objMonedaDao.getTipoCambioVenta(date).ToString().PadRight(5, '0');
        }
        void cmbejercicio()
        {
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "";
            objEjercicio.Descripcion = " ";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "20";
            objEjercicio.Descripcion = "Factura Exportación";
            objListaEjercicio.Add(objEjercicio);
            cmb_tipoFac.DataSource = objListaEjercicio;
            cmb_tipoFac.ValueMember = "Id";
            cmb_tipoFac.DisplayMember = "Descripcion";
            cmb_tipoFac.Refresh();
        }
        public void comboMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }
        public void comboPago()
        {
            objListTipPago = objTipoPagoDao.listarTipoPago();
            cmb_Pago.DataSource = objListTipPago;
            cmb_Pago.DisplayMember = "PagoDescripcion";
            cmb_Pago.ValueMember = "PagoId";
            cmb_Pago.Refresh();

        }
        public void setClienteDatos(string cliente, string direccion, string ruc, string codigocliente)
        {
            txt_Cliente.Text = cliente;
            txt_Direccion.Text = direccion;
            txt_Ruc.Text = ruc;
            txt_codcliente.Text = codigocliente;
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            using (var buscarClienteForm = new BuscarCliente("F"))
            {
                buscarClienteForm.ShowDialog();
            }
        }
        public void gridParams()
        {
            grd_Detalle.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "ITEM";
            idColumn1.DataPropertyName = "DocumentoDetId";
            idColumn1.Width = 60;
            grd_Detalle.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "CÓDIGO";
            idColumn2.DataPropertyName = "ProductoCod";
            idColumn2.Width = 120;
            grd_Detalle.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "CANTIDAD";
            idColumn3.DataPropertyName = "DocumentoDetCantidad";
            idColumn3.Width = 100;
            grd_Detalle.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "DESCRIPCION";
            idColumn4.DataPropertyName = "DocumentoDesProducto";
            idColumn4.Width = 345;
            grd_Detalle.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "PRECIO UNITARIO";
            idColumn5.DataPropertyName = "DocumentoDetPrecioSinIGV";
            idColumn5.Width = 150;
            grd_Detalle.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "SUB TOTAL";
            idColumn6.DataPropertyName = "DocumentoDetSubTotal";
            idColumn6.Width = 120;
            grd_Detalle.Columns.Add(idColumn6);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Operacion = "S";
            limpiarCampos();
            habilitarBotones(false, true);
            habilitarCampos(true);
            txt_ItemN.Text = ContadorItem.ToString();
        }


        public void listCliente(List<DocumentoDet> lista)
        {
            grd_Detalle.DataSource = null;
            grd_Detalle.DataSource = lista;

            grd_Detalle.Refresh();
        }

        private void btn_BuscarProd_Click(object sender, EventArgs e)
        {
            using (var buscarProductoForm = new BuscarProducto("F"))
            {
                buscarProductoForm.ShowDialog();
            }
        }

        public void setProductosDatos(string codigo, string descripcion, string um, string umcod)
        {
            txt_CodigoProd.Text = codigo;
            txt_ProdDescrip.Text = descripcion;
            txt_UM.Text = um;
            txt_umcod.Text = umcod;
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

        public void llenarSumatorias()
        {
            if(cmb_tipoFac.SelectedValue.ToString()=="20" || ListaFactura.numeroSerie=="FX01")
            {
                txt_ValorVenta.Text = objListDocumentoDet.Sum(x => x.DocumentoDetSubTotal).ToString();
                txt_IGV.Text = "0.00";
                txt_TotalsinPercep.Text ="0.00";
                txt_TotalPagar.Text = txt_ValorVenta.Text;

                lblTotal.Text = objDocumento.numeroALetras(convertToDouble(txt_TotalPagar.Text)) + " " + cmb_Moneda.SelectedText;
                if (txt_Porcentaje.Text == "0")
                {
                    txt_Detraccion.Text = "0";
                }
                else
                {
                    if (cmb_Moneda.SelectedValue.ToString() == "PEN")
                    {
                        txt_Detraccion.Text = Math.Round((convertToDouble(txt_TotalPagar.Text) * convertToDouble(txt_Porcentaje.Text) / 100), 0).ToString();

                    }
                    else
                    {
                        txt_Detraccion.Text = Math.Round((convertToDouble(txt_TotalPagar.Text) * convertToDouble(txt_Porcentaje.Text) / 100), 2).ToString();
                    }
                }
            }
            else
            {
                txt_ValorVenta.Text = objListDocumentoDet.Sum(x => x.DocumentoDetSubTotal).ToString();
                txt_IGV.Text = (Math.Round(convertToDouble(txt_ValorVenta.Text) * 0.18, 2)).ToString();
                txt_TotalsinPercep.Text = (convertToDouble(txt_IGV.Text) + convertToDouble(txt_ValorVenta.Text)).ToString();
                txt_TotalPagar.Text = txt_TotalsinPercep.Text;
                lblTotal.Text = objDocumento.numeroALetras(convertToDouble(txt_TotalPagar.Text)) + " " + cmb_Moneda.SelectedText;
                if (txt_Porcentaje.Text == "0")
                {
                    txt_Detraccion.Text = "0";
                }
                else
                {
                    if (cmb_Moneda.SelectedValue.ToString() == "PEN")
                    {
                        txt_Detraccion.Text = Math.Round((convertToDouble(txt_TotalPagar.Text) * convertToDouble(txt_Porcentaje.Text) / 100), 0).ToString();

                    }
                    else
                    {
                        txt_Detraccion.Text = Math.Round((convertToDouble(txt_TotalPagar.Text) * convertToDouble(txt_Porcentaje.Text) / 100), 2).ToString();
                    }
                }
            }
            
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";
            habilitarCampos(true);
            habilitarBotones(false, true);
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_UM.Text))
            {
                MessageBox.Show("Escoja nuevamente el Producto");
                return;
            }
            objDocumentoDet = new DocumentoDet();
            objDocumentoDet.DocumentoDetId = Convert.ToInt32(txt_ItemN.Text);
            objDocumentoDet.DocumentoCabNro = txt_Numero.Text;
            objDocumentoDet.ProductoCod = txt_CodigoProd.Text;
            objDocumentoDet.DocumentoDetCantidad = convertToDouble(txt_Cantidad.Text);
            objDocumentoDet.DocumentoDesProducto = txt_ProdDescrip.Text;
            objDocumentoDet.DocumentoDetPrecioSinIGV =convertToDouble(txt_PrecioUnitario.Text);
            objDocumentoDet.DocumentoDetSubTotal = Math.Round( convertToDouble(txt_Subtotal.Text),2,MidpointRounding.AwayFromZero);
            objDocumentoDet.DocumentoProdUMcorta = txt_UM.Text;
            objDocumentoDet.DocumentoDetUsuAdd = Ventas.UsuarioSession;
            objDocumentoDet.DocumentoProdUMCod = txt_umcod.Text;
            objDocumentoDet.DocumentoDetGlosa = txt_GlosaDet.Text;
            objDocumentoDet.DocumentoCabSerie = txt_Serie.Text;

            objDocumentoDet.DocumentoDetIGV = Math.Round( objDocumentoDet.DocumentoDetSubTotal * 0.18,2);
            objDocumentoDet.DocumentoDetTabla = txt_Tabla.Text;
            objDocumentoDet.DocumentoDetNroOt = txt_OT.Text;
            objDocumentoDet.CuentaContable = txt_CuentaContable.Text;
            objDocumentoDet.DocumentoDetCodEnt = Ventas.UNIDADNEGOCIO;
           // objDocumentoDet.DocumentoDetCantidad = objDocumentoDet.DocumentoDetCantidad;
            if (!String.IsNullOrEmpty(txt_itemOt.Text))
            {
                objDocumentoDet.DocumentoDetItemOt = Convert.ToInt32(txt_itemOt.Text);
            }
            else
            {
                objDocumentoDet.DocumentoDetItemOt = 0;
            }

            if (Operacion == "S")
            {
                objListDocumentoDet.Add(objDocumentoDet);

                
                ContadorItem++;

            }
            else if (Operacion == "M")
            {
                objListDocumentoDet[index] = objDocumentoDet;
            }
            listCliente(objListDocumentoDet);
            llenarSumatorias();
            limpiarCampos();
            habilitarBotones(true, false);
            habilitarCampos(false);
            txt_Porcentaje.Enabled = false;
            chk_Detraccion.Enabled = false;

        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            btn_SaveData.Enabled = false;
            if (objListDocumentoDet.Count ==0)
            {
                MessageBox.Show("No puede guardar sin Detalle");
                return;
            }
            bool binsertar,bupdate, bdetalle = true;
            bool bupdatedet =true;
            objDocumentoCab = new DocumentoCab();
            objDocumentoCab.DocumentoCabSerie = txt_Serie.Text;
            objDocumentoCab.DocumentoCabNro = txt_Numero.Text;
            objDocumentoCab.DocumentoCabClienteCod = txt_codcliente.Text;
            objDocumentoCab.DocumentoCabFecha = dpick_Fecha.Value;
            objDocumentoCab.DocumentoCabGlosa = txt_GlosaCab.Text;
            objDocumentoCab.DocumentoCabIGV = convertToDouble(txt_IGV.Text);
            objDocumentoCab.DocumentoCabTotalSinIGV = convertToDouble(txt_ValorVenta.Text);
            objDocumentoCab.DocumentoCabTotal = convertToDouble(txt_TotalPagar.Text);
            objDocumentoCab.DocumentoCabTipoDoc = "01";
            objDocumentoCab.DocumentoCabTipoPago = Convert.ToInt32(cmb_Pago.SelectedValue);
            objDocumentoCab.DocumentoCabTipoMoneda = cmb_Moneda.SelectedValue.ToString();
            objDocumentoCab.DocumentoCabUsuAdd = Ventas.UsuarioSession;
            objDocumentoCab.DocumentoCabFechaVcto = dpck_Fechavcto.Value;
            objDocumentoCab.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
            objDocumentoCab.DocumentoCabDetraccion = convertToDouble(txt_Detraccion.Text);
            objDocumentoCab.DocumentoCabDetraccionPorcentaje = convertToDouble(txt_Porcentaje.Text);
            objDocumentoCab.DocumentoCabGuia = txt_Guia.Text;
            objDocumentoCab.DocumentoCabOrdenCompra = txt_Pedido.Text;
            objDocumentoCab.DocumentoCabTabla = txt_Tabla.Text;
            objDocumentoCab.DocumentoCabOtCod = txt_OT.Text;
            objDocumentoCab.Intercorp = txt_intercorp.Text;

            if (!String.IsNullOrEmpty(txt_itemOt.Text))
            {
                objDocumentoCab.DocumentoCabItemOt = Convert.ToInt32(txt_itemOt.Text);
            }
            else
            {
                objDocumentoCab.DocumentoCabItemOt = 0;
            }
            if (Modificar == "G")
            {
                binsertar = objDocumento.insertarCabecera(objDocumentoCab, Ventas.UNIDADNEGOCIO);

                string msg = "";
                if (binsertar)
                {



                }
                else
                {
                    msg = "Hubo un problema al guardar";
                    MessageBox.Show(msg);
                    btn_SaveData.Enabled = true;

                    return;
                }
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    bdetalle = objDocumento.insertDetalle(objListDocumentoDet[i]);
                    if (bdetalle == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                }
                if (bdetalle)
                {
                    MessageBox.Show("Factura Guardada exitosamente");

                    btn_SaveData.Enabled = true;
                }
                DialogResult dialogResult = MessageBox.Show("Enviar a Sunat?", "ENVIAR DOCUMENTOS", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    objDocumentoElectronicoCab = objDocumento.getDocumentoElectronicoCab(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                    String NroExtranjero = " ";
                    if(cmb_tipoFac.SelectedValue.ToString()=="20")
                    {
                        NroExtranjero = cmb_tipoFac.SelectedValue.ToString();
                        objListDocumentoElectronicoDet = objDocumento.getDocumentoElectronicoDet(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                    }
                    else
                    {
                        objListDocumentoElectronicoDet = objDocumento.getDocumentoElectronicoDet(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                    }
                    String rutatext = objProceso.generarText(objDocumentoElectronicoCab, objListDocumentoElectronicoDet);
                    String mess = objProceso.sendTxt(rutatext);
                   
                    String mensajeMostrar = "";
                    String[] array = mess.Split('|');

                    List<String> objListaString = array.ToList();
                    if (objListaString.Count < 10)
                    {
                        mensajeMostrar = objListaString[1];
                        objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                        // objDocumento.updateEstadoAnulado(txt_Serie.Text, txt_Numero.Text);
                    }
                    else
                    {
                        mensajeMostrar = objListaString[9];
                        if (mensajeMostrar == "true")
                        {
                            mensajeMostrar = "Documento Enviado";
                            objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                            // objDocumento.updateEstadoAceptado(txt_Serie.Text, txt_Numero.Text);
                            objDocumento.updateEstadoEnviado(txt_Serie.Text, txt_Numero.Text);
                        }
                        else
                        {
                            objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                        }
                    }


                    MessageBox.Show(mensajeMostrar);
                }
                else if (dialogResult == DialogResult.No)
                {
                    //do something else
                }
            }else
            /*cuando se actualiza cuple esta funcion */
            {
                /*procedure para actualizar la cabecera*/
                bupdate = objDocumento.updateCabecera(objDocumentoCab);
                string msg = "";
                if (bupdate)
                {



                }
                else
                {
                    msg = "Hubo un problema al guardar";
                    MessageBox.Show(msg);
                    btn_SaveData.Enabled = true;
                    return;
                }
                /// delete
                objDocumento.deleteDetDoc(objDocumentoCab.DocumentoCabSerie, objDocumentoCab.DocumentoCabNro);
                /*for para insertar el detalle*/
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                   
                    bupdatedet = objDocumento.insertDetalle(objListDocumentoDet[i]);
                    if (bupdatedet == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                }
                if (bupdatedet)
                {
                    MessageBox.Show("Factura Guardada exitosamente");

                    btn_SaveData.Enabled = true;
                }
            }
            //nuevoRegistro();
            this.Hide();
            ListaFactura.operacionFactura = "Q";
            ListaFactura Check = new ListaFactura();
            Check.Show();
        }

        public void nuevoRegistro()
        {
            limpiarCampos();
            txt_Numero.Text = objDocumento.correlativoFactura("01", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
            ContadorItem = 1;
            objListDocumentoDet = new List<DocumentoDet>();
            grd_Detalle.DataSource = objListDocumentoDet;
            txt_Cliente.Text = "";
            txt_codcliente.Text = "";
            txt_Direccion.Text = "";
            txt_Guia.Text = "";
            txt_IGV.Text = "";
            txt_OT.Text = "";
            txt_TotalPagar.Text = "";
            txt_Ruc.Text = "";
            txt_GlosaCab.Text = "";
            txt_TotalsinPercep.Text = "";
            txt_ValorVenta.Text = "";
            lblTotal.Text = "";
            txt_Pedido.Text = "";
            txt_ItemN.Text = ContadorItem.ToString();
            chk_Detraccion.Enabled = true;
            txt_Porcentaje.Text = "0";
            chk_Detraccion.Checked = false;
            txt_Detraccion.Text = "0";
            txt_Tabla.Text = "";
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            nuevoRegistro();

        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaFactura.operacionFactura = "Q";
            ListaFactura Check = new ListaFactura();
            Check.Show();
        }

        private void btn_BuscarOT_Click(object sender, EventArgs e)
        {
           /* if (String.IsNullOrEmpty(txt_codcliente.Text))
            {
                MessageBox.Show("Escoge un Cliente");
                return;
            }*/
            if (rb_OT.Checked)
            {
                using (var buscarOt = new BuscarOt(txt_codcliente.Text))
                {
                    buscarOt.ShowDialog();
                }
            }
            else if (rb_CC.Checked)
            {
                using (var buscarCC = new BuscarCC())
                {
                    buscarCC.ShowDialog();
                }
            }
           
        }
        public void setCCDatos(String centroc)
        {
            txt_OT.Text = centroc;
        }
        public void setOtDatos(string monto, string glosa, string tabla, int item, String CuentaContable, 
            String UnidadMed, String CodProd, String nroot, String productodescr)
        {
            txt_PrecioUnitario.Text = monto;
            txt_GlosaDet.Text = glosa;
            txt_Tabla.Text = tabla;
            txt_itemOt.Text = item.ToString();
            txt_CuentaContable.Text = CuentaContable;
            txt_UM.Text = UnidadMed;
            txt_CodigoProd.Text = CodProd;
            if (UnidadMed =="ZZ")
            {
                txt_umcod.Text = "040";
            }else 
            {
                txt_umcod.Text = "039";
            }
            txt_OT.Text = nroot;
            txt_ProdDescrip.Text = productodescr;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Modificar = "M";
            txt_GlosaCab.Enabled = true;
            habilitarBotones(true, false);
            btn_SaveData.Enabled = true;
            txt_Pedido.Enabled = true;
            cmb_Moneda.Enabled = true;
            cmb_Pago.Enabled = true;
        }

        private void Factura_Load(object sender, EventArgs e)
        {

        }

        private void cmb_tipoFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            int correlativoparse = 0;
            if(cmb_tipoFac.SelectedValue.ToString()=="20")
            {
                txt_Serie.Text = "FX01";
               
                correlativoparse =Convert.ToInt32(objDocumento.correlativoFactura("01", Ventas.UNIDADNEGOCIO, txt_Serie.Text));
                if(correlativoparse>4)
                {
                    txt_Numero.Text = objDocumento.correlativoFactura("01", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
                }
                else
                {
                    txt_Numero.Text = "00000004";
                }

                txt_intercorp.Visible = true;
            }
            else
            {
                if (Ventas.UNIDADNEGOCIO == "01")
                {
                    txt_Serie.Text = "F001";

                }
                else
                {
                    txt_Serie.Text = "F005";
                }
                txt_Numero.Text = objDocumento.correlativoFactura("01", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
            }
            
        }
    }
}
