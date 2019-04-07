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

namespace Contabilidad
{
    public partial class Boleta : Form
    {
        DocumentoDet objDocumentoDet;
        DocumentoCab objDocumentoCab;
        Proceso objProceso;
        TipoPagoDAO objTipoPagoDao;
        MonedaDAO objMonedaDao;
        DocumentoDAO objDocumento;

        public static int index;
        public static int ContadorItem = 1;
        public static String Operacion = "Q";
        public static Boleta boletaForm;
        public static List<Moneda> objListMoneda = new List<Moneda>();
        public static List<Pago> objListTipPago = new List<Pago>();
        public static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<DocumentoElectronicoDet> objListDocumentoElectronicoDet = new List<DocumentoElectronicoDet>();
        public static DocumentoElectronicoCab objDocumentoElectronicoCab = new DocumentoElectronicoCab();
        public Boleta()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "BOLETAS";
            boletaForm = this;
            objMonedaDao = new MonedaDAO();
            objTipoPagoDao = new TipoPagoDAO();
            objDocumento = new DocumentoDAO();
            objProceso = new Proceso();
            comboMoneda();
            comboPago();
            gridParams();
            if (ListaBoleta.operacionFactura == "V")
            {
                if (ListaFactura.objDocumentoCab.EstadoSunat == 0)
                {
                    lbl_Anulado.Visible = true;
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

                txt_Cliente.Text = ListaBoleta.objDocumentoCab.DocumentoCabCliente;
                txt_Ruc.Text = ListaBoleta.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Serie.Text = ListaBoleta.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ListaBoleta.objDocumentoCab.DocumentoCabNro;
                txt_GlosaCab.Text = ListaBoleta.objDocumentoCab.DocumentoCabGlosa;
                cmb_Moneda.SelectedValue = ListaBoleta.objDocumentoCab.DocumentoCabTipoMoneda;
                cmb_Pago.SelectedValue = ListaBoleta.objDocumentoCab.DocumentoCabTipoPago;
                txt_Direccion.Text = ListaBoleta.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_Guia.Text = ListaBoleta.objDocumentoCab.DocumentoCabGuia;
                txt_Pedido.Text = ListaBoleta.objDocumentoCab.DocumentoCabOrdenCompra;
                objListDocumentoDet = objDocumento.listarDetalle(ListaBoleta.numeroDocumento, ListaBoleta.numeroSerie, Ventas.UNIDADNEGOCIO);
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
                dpick_Fecha.Value = ListaBoleta.objDocumentoCab.DocumentoCabFecha;
                tipoCambio(dpick_Fecha.Value.ToShortDateString());
                llenarSumatorias();
            }
            else
            {
                
                if (Ventas.UNIDADNEGOCIO=="01")
                {
                    txt_Serie.Text = "B001";
                }else
                {
                    txt_Serie.Text = "B005";
                }
                txt_Numero.Text = objDocumento.correlativoFactura("03", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
                habilitarCampos(false);
                tipoCambio(DateTime.Now.ToShortDateString());
            }
 
            rb_OT.Select();




            dpick_Fecha.TextChanged += Dpick_Fecha_TextChanged;

            txt_PrecioUnitario.TextChanged += Txt_PrecioUnitario_TextChanged;
            txt_Cantidad.TextChanged += Txt_Cantidad_TextChanged;
            txt_Percepcion.Text = "0";
            grd_Detalle.CellClick += Grd_Detalle_CellClick;

            cmb_Moneda.SelectedValueChanged += Cmb_Moneda_SelectedValueChanged;
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
        }

        private void habilitarCampos(bool bhabilitar)
        {

            try
            {
                txt_ProdDescrip.Enabled = bhabilitar;

                txt_GlosaDet.Enabled = bhabilitar;

                btn_BuscarProd.Enabled = bhabilitar;
                txt_PrecioUnitario.Enabled = bhabilitar;
                txt_Cantidad.Enabled = bhabilitar;
            }
            catch (Exception ex)
            {

            }
        }

        private void habilitarBotones(bool bhabilitar1, bool bhabilitar2)
        {
            btn_Add.Enabled = bhabilitar1;
            btn_Editar.Enabled = bhabilitar1;
            btn_Guardar.Enabled = bhabilitar2;
        }

        private void Txt_Cantidad_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_PrecioUnitario.Text))
            {
                txt_Subtotal.Text = (convertToDouble(txt_Cantidad.Text) * convertToDouble(txt_PrecioUnitario.Text)).ToString();
            }
        }

        private void Txt_PrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_Cantidad.Text))
            {
                txt_Subtotal.Text = (convertToDouble(txt_Cantidad.Text) * convertToDouble(txt_PrecioUnitario.Text)).ToString();
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
            using (var buscarClienteForm = new BuscarCliente("B"))
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
            using (var buscarProductoForm = new BuscarProducto("B"))
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
            txt_ValorVenta.Text = objListDocumentoDet.Sum(x => x.DocumentoDetSubTotal).ToString();
            txt_IGV.Text = (convertToDouble(txt_ValorVenta.Text) * 0.18).ToString();
            txt_TotalsinPercep.Text = (convertToDouble(txt_IGV.Text) + convertToDouble(txt_ValorVenta.Text)).ToString();
            txt_TotalPagar.Text = txt_TotalsinPercep.Text;
            lblTotal.Text = objDocumento.numeroALetras(convertToDouble(txt_TotalPagar.Text)) + " " + cmb_Moneda.SelectedText;

        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";
            habilitarCampos(true);
            habilitarBotones(false, true);
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            objDocumentoDet = new DocumentoDet();
            objDocumentoDet.DocumentoDetId = Convert.ToInt32(txt_ItemN.Text);
            objDocumentoDet.DocumentoCabNro = txt_Numero.Text;
            objDocumentoDet.ProductoCod = txt_CodigoProd.Text;
            objDocumentoDet.DocumentoDetCantidad = convertToDouble(txt_Cantidad.Text);
            objDocumentoDet.DocumentoDesProducto = txt_ProdDescrip.Text;
            objDocumentoDet.DocumentoDetPrecioSinIGV = convertToDouble(txt_PrecioUnitario.Text);
            objDocumentoDet.DocumentoDetSubTotal = convertToDouble(txt_Subtotal.Text);
            objDocumentoDet.DocumentoProdUMcorta = txt_UM.Text;
            objDocumentoDet.DocumentoDetUsuAdd = Ventas.UsuarioSession;
            objDocumentoDet.DocumentoProdUMCod = txt_umcod.Text;
            objDocumentoDet.DocumentoDetGlosa = txt_GlosaDet.Text;
            objDocumentoDet.DocumentoDetIGV = objDocumentoDet.DocumentoDetSubTotal * 0.18;
            objDocumentoDet.DocumentoCabSerie = txt_Serie.Text;
            if (Operacion == "S")
            {
                objListDocumentoDet.Add(objDocumentoDet);

                // grd_Detalle.
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

        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            btn_SaveData.Enabled = false;
            bool binsertar, bdetalle = true;
            objDocumentoCab = new DocumentoCab();
            objDocumentoCab.DocumentoCabSerie = txt_Serie.Text;
            objDocumentoCab.DocumentoCabNro = txt_Numero.Text;
            objDocumentoCab.DocumentoCabClienteCod = txt_codcliente.Text;
            objDocumentoCab.DocumentoCabFecha = dpick_Fecha.Value;
            objDocumentoCab.DocumentoCabGlosa = txt_GlosaCab.Text;
            objDocumentoCab.DocumentoCabIGV = convertToDouble(txt_IGV.Text);
            objDocumentoCab.DocumentoCabTotalSinIGV = convertToDouble(txt_ValorVenta.Text);
            objDocumentoCab.DocumentoCabTotal = convertToDouble(txt_TotalPagar.Text);
            objDocumentoCab.DocumentoCabTipoDoc = "03";
            objDocumentoCab.DocumentoCabTipoPago = Convert.ToInt32(cmb_Pago.SelectedValue);
            objDocumentoCab.DocumentoCabTipoMoneda = cmb_Moneda.SelectedValue.ToString();
            objDocumentoCab.DocumentoCabUsuAdd = Ventas.UsuarioSession;
            objDocumentoCab.DocumentoCabFechaVcto = dpck_Fechavcto.Value;
            objDocumentoCab.DocumentoCabFechaDocRef = new DateTime(2000, 1, 1);
            objDocumentoCab.DocumentoCabGuia = txt_Guia.Text;
            objDocumentoCab.DocumentoCabOrdenCompra = txt_Pedido.Text;

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
                MessageBox.Show("Boleta Guardada exitosamente");
               
                btn_SaveData.Enabled = true;
            }
            DialogResult dialogResult = MessageBox.Show("Enviar a Sunat?", "ENVIAR DOCUMENTOS", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                objDocumentoElectronicoCab = objDocumento.getDocumentoElectronicoCab(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                objListDocumentoElectronicoDet = objDocumento.getDocumentoElectronicoDet(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                String rutatext = objProceso.generarText(objDocumentoElectronicoCab, objListDocumentoElectronicoDet);
                String mess = objProceso.sendTxt(rutatext);
                objDocumento.updateEstadoEnviado(txt_Serie.Text, txt_Numero.Text);
                String mensajeMostrar = "";
                String[] array = mess.Split('|');

                List<String> objListaString = array.ToList();
                if (objListaString.Count < 10)
                {
                    mensajeMostrar = objListaString[1];
                    objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                    objDocumento.updateEstadoAnulado(txt_Serie.Text, txt_Numero.Text);

                }
                else
                {
                    mensajeMostrar = objListaString[9];
                    if (mensajeMostrar == "true")
                    {
                        mensajeMostrar = "Documento Aceptado";
                        objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                        objDocumento.updateEstadoAceptado(txt_Serie.Text, txt_Numero.Text);

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
            //nuevoRegistro();
            this.Hide();
            ListaBoleta.operacionFactura = "Q";
            ListaBoleta Check = new ListaBoleta();
            Check.Show();
        }

        public void nuevoRegistro()
        {
            limpiarCampos();
            txt_Numero.Text = objDocumento.correlativoFactura("03", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
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
            txt_GlosaDet.Text = "";
            txt_TotalsinPercep.Text = "";
            txt_ValorVenta.Text = "";
            lblTotal.Text = "";
            txt_Pedido.Text = "";
            txt_ItemN.Text = ContadorItem.ToString();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            nuevoRegistro();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaBoleta.operacionFactura = "Q";
            ListaBoleta Check = new ListaBoleta();
            Check.Show();
        }


    }
}
