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
    public partial class NotaDeDebito : Form
    {
        DocumentoDet objDocumentoDet;
        DocumentoCab objDocumentoCab;

        TipoPagoDAO objTipoPagoDao;
        MonedaDAO objMonedaDao;
        DocumentoDAO objDocumento;
        DocumentoContabilidadDAO objContabilidadDocuDAO;
        Proceso objProceso;
        public static int index;
        public static int ContadorItem = 0;
        public static String Operacion = "Q";
        public static String Modificar = "Q";
        public static NotaDeDebito debitoForm;
        public static List<Moneda> objListMoneda = new List<Moneda>();
        public static List<Pago> objListTipPago = new List<Pago>();
        public static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<DocumentoDet> objListDocumentoDetGuardar = new List<DocumentoDet>();
        public static List<DocumentoElectronicoDet> objListDocumentoElectronicoDet = new List<DocumentoElectronicoDet>();
        public static DocumentoElectronicoCab objDocumentoElectronicoCab = new DocumentoElectronicoCab();
        public NotaDeDebito()
        {
            InitializeComponent();
            
            this.ControlBox = false;
            this.Text = "NOTA DE DÉBITO";
            debitoForm = this;
            
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            objTipoPagoDao = new TipoPagoDAO();
            objDocumento = new DocumentoDAO();
            objProceso = new Proceso();

            objContabilidadDocuDAO = new DocumentoContabilidadDAO();
            comboMoneda();
            comboMotivo();
            comboDocumento();
            cmb_TipoDocumento.SelectedValueChanged += Cmb_TipoDocumento_SelectedValueChanged;
            grd_Detalle.CellValueChanged += Grd_Detalle_CellValueChanged;
            gridParams();
            if (ListaNotaDebito.operacionFactura == "V")
            {
                if (ListaNotaDebito.objDocumentoCab.EstadoSunat == 0)
                {
                    lbl_Anulado.Visible = true;
                }
                else if (ListaNotaDebito.objDocumentoCab.EstadoSunat == 1)
                {
                    btn_Modificar.Visible = true;
                }
                habilitarCampos(false);
                Modificar = "M";
                txt_GlosaCab.Enabled = false;
                btn_Add.Enabled = false;
                btn_Limpiar.Enabled = false;
                btn_SaveData.Enabled = false;
                btn_Buscar.Enabled = false;
                dpck_Fechadcto.Enabled = false;
                dpick_Fecha.Enabled = false;
                cmb_Moneda.Enabled = false;
                cmb_Motivo.Enabled = false;

                txt_Cliente.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabCliente;
                txt_Ruc.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Serie.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabNro;
                txt_GlosaCab.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabGlosa;
                cmb_Moneda.SelectedValue = ListaNotaDebito.objDocumentoCab.DocumentoCabTipoMoneda;
                cmb_Motivo.SelectedValue = ListaNotaDebito.objDocumentoCab.DocumentoCabTipoNotaCredito;
                txt_Direccion.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_SerieBuscar.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabSerieRef;
                txt_NumeroBuscar.Text = ListaNotaDebito.objDocumentoCab.DocumentoCabNroRef;
                dpck_Fechadcto.Value = ListaNotaDebito.objDocumentoCab.DocumentoCabFechaDocRef;
                objListDocumentoDet = objDocumento.listarDetalle(ListaNotaDebito.numeroDocumento, ListaNotaDebito.numeroSerie, Ventas.UNIDADNEGOCIO);
                /*objDocumentoDet = new DocumentoDet();
                objDocumentoDet.DocumentoCabNro = txt_Numero.Text;
                objDocumentoDet.DocumentoCabSerie = txt_Serie.Text;
                objDocumentoDet.DocumentoDesProducto = "ANULACIÓN FACTURA " + txt_Serie.Text + "-" + txt_Numero.Text;
                objDocumentoDet.DocumentoDetCantidad = 1;
                objDocumentoDet.DocumentoDetId = 1;
                objDocumentoDet.DocumentoDetCodEnt = Ventas.UNIDADNEGOCIO;
                objDocumentoDet.DocumentoDetIGV = ListaNotaCredito.objDocumentoCab.DocumentoCabIGV;
                objDocumentoDet.DocumentoDetPrecioTotal= ListaNotaCredito.objDocumentoCab.DocumentoCabTotalSinIGV;
                objDocumentoDet.DocumentoDetSubTotal = ListaNotaCredito.objDocumentoCab.DocumentoCabTotalSinIGV;
                objDocumentoDet.DocumentoDetPrecioSinIGV = ListaNotaCredito.objDocumentoCab.DocumentoCabTotalSinIGV;
                txt_ValorVenta.Text = ListaNotaCredito.objDocumentoCab.DocumentoCabTotalSinIGV.ToString();
                txt_TotalPagar.Text = ListaNotaCredito.objDocumentoCab.DocumentoCabTotal.ToString();
                txt_IGV.Text = ListaNotaCredito.objDocumentoCab.DocumentoCabIGV.ToString();
                if (Ventas.UNIDADNEGOCIO =="02")
                {
                    objDocumentoDet.DocumentoProdUMCod = "ZZ";
                    objDocumentoDet.DocumentoProdUMcorta = "040";
                    objDocumentoDet.ProductoCod = "000000000003";
                }
                else
                {
                    objDocumentoDet.DocumentoProdUMCod = "NIU";
                    objDocumentoDet.ProductoCod = "000000012343";
                    objDocumentoDet.DocumentoProdUMcorta = "039";
                }
                */
                //objListDocumentoDet.Add(objDocumentoDet);
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
                llenarSumatorias();
                dpick_Fecha.Value = ListaNotaDebito.objDocumentoCab.DocumentoCabFecha;
                tipoCambio(dpick_Fecha.Value.ToShortDateString());
                //btn_Rest.Enabled = false;
            }
            else
            {
                objListDocumentoDet = new List<DocumentoDet>();
                Modificar = "G";
                if (Ventas.UNIDADNEGOCIO=="01")
                {
                    txt_Serie.Text = "FD01";
                }else
                {
                    txt_Serie.Text = "FD05";
                }
          
                ContadorItem = 0;


                txt_Numero.Text = objDocumento.correlativoFactura("08", Ventas.UNIDADNEGOCIO, txt_Serie.Text);
                //habilitarCampos(true);
                tipoCambio(DateTime.Now.ToShortDateString());
                //btn_Rest.Enabled = true;
            }


            dpick_Fecha.TextChanged += Dpick_Fecha_TextChanged;



            txt_PrecioUnitario.TextChanged += Txt_PrecioUnitario_TextChanged;
            txt_Cantidad.TextChanged += Txt_Cantidad_TextChanged;
            cmb_Moneda.SelectedValueChanged += Cmb_Moneda_SelectedValueChanged;
            grd_Detalle.CellClick += Grd_Detalle_CellClick;
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
               
                habilitarCampos(false);
            }


        }
        private void Txt_Cantidad_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_PrecioUnitario.Text))
            {
                txt_Subtotal.Text = (convertToDouble(txt_PrecioUnitario.Text) * convertToDouble(txt_Cantidad.Text)).ToString();
            }
        }

        private void Txt_PrecioUnitario_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_Cantidad.Text))
            {
                txt_Subtotal.Text = (convertToDouble(txt_Cantidad.Text) * convertToDouble(txt_PrecioUnitario.Text)).ToString();
            }

        }


        private void Grd_Detalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            llenarSumatorias();
        }

        private void Cmb_TipoDocumento_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }
        public void setProductosDatos(string codigo, string descripcion, string um, string umcod)
        {
            txt_CodigoProd.Text = codigo;
            txt_ProdDescrip.Text = descripcion;
            txt_UM.Text = um;
            txt_umcod.Text = umcod;
        }
        void comboDocumento()
        {
            cmb_TipoDocumento.DataSource = objContabilidadDocuDAO.listarDocumentoContabilidad();
            cmb_TipoDocumento.ValueMember = "DocContabilidadCod";
            cmb_TipoDocumento.DisplayMember = "DocContabilidadDescripcion";
            cmb_TipoDocumento.Refresh();

        }
        void comboMotivo()
        {
            cmb_Motivo.DataSource = objContabilidadDocuDAO.listarMotivoNotaDebito();
            cmb_Motivo.ValueMember = "TNDebitoCod";
            cmb_Motivo.DisplayMember = "TNDebitoDescripcion";
            cmb_Motivo.Refresh();
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

        private void limpiarCampos()
        {
            txt_Cliente.Text = "";
            txt_Direccion.Text = "";
            txt_GlosaCab.Text = "";
            txt_NumeroBuscar.Text = "";
            txt_IGV.Text = "";
            txt_Ruc.Text = "";
            txt_SerieBuscar.Text = "";
            txt_Tcambio.Text = "";
            txt_TotalPagar.Text = "";
            txt_ValorVenta.Text = "";


        }
        private void habilitarCampos(bool bhabilitar)
        {


            txt_GlosaCab.Enabled = bhabilitar;
            cmb_Motivo.Enabled = bhabilitar;
            cmb_TipoDocumento.Enabled = bhabilitar;
            txt_Cantidad.Enabled = bhabilitar;
            txt_PrecioUnitario.Enabled = bhabilitar;
            txt_Cantidad.Enabled = bhabilitar;
            txt_ProdDescrip.Enabled = bhabilitar;
        }

        private void habilitarBotones(bool bhabilitar1)
        {
            //btn_Rest.Enabled = bhabilitar1;
            btn_Buscar.Enabled = bhabilitar1;
            btn_SaveData.Enabled = bhabilitar1;
            btn_Limpiar.Enabled = bhabilitar1;
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
        public void gridParams()
        {
            grd_Detalle.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "ITEM";
            idColumn1.DataPropertyName = "DocumentoDetId";
            idColumn1.Width = 47;
            grd_Detalle.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "CÓDIGO";
            idColumn2.DataPropertyName = "ProductoCod";
            idColumn2.Width = 100;
            grd_Detalle.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "CANTIDAD";
            idColumn3.DataPropertyName = "DocumentoDetCantidad";
            idColumn3.Width = 90;
            grd_Detalle.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "DESCRIPCION";
            idColumn4.DataPropertyName = "DocumentoDesProducto";
            idColumn4.Width = 325;
            grd_Detalle.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "PRECIO UNIT.";
            idColumn5.DataPropertyName = "DocumentoDetPrecioSinIGV";
            idColumn5.Width = 110;
            grd_Detalle.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "SUB TOTAL";
            idColumn6.DataPropertyName = "DocumentoDetSubTotal";
            idColumn6.Width = 110;
            grd_Detalle.Columns.Add(idColumn6);
        }
        public void listarDetalle(List<DocumentoDet> lista)
        {
            grd_Detalle.DataSource = null;
            grd_Detalle.DataSource = lista;

            grd_Detalle.Refresh();
        }
        public void llenarSumatorias()
        {
            txt_ValorVenta.Text = objListDocumentoDet.Sum(x => x.DocumentoDetSubTotal).ToString();
            txt_IGV.Text = (Math.Round(convertToDouble(txt_ValorVenta.Text) * 0.18, 2)).ToString();

            txt_TotalPagar.Text = (convertToDouble(txt_IGV.Text) + convertToDouble(txt_ValorVenta.Text)).ToString();
            lblTotal.Text = objDocumento.numeroALetras(convertToDouble(txt_TotalPagar.Text)) + " " + cmb_Moneda.SelectedText;

        }
        public void nuevoRegistro()
        {
            limpiarCampos();
            txt_Numero.Text = objDocumento.correlativoFactura("08", Ventas.UNIDADNEGOCIO, txt_Serie.Text);

            objListDocumentoDet = new List<DocumentoDet>();
            grd_Detalle.DataSource = objListDocumentoDet;
            txt_Cliente.Text = "";


        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            nuevoRegistro();
        }
        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaNotaDebito.operacionFactura = "Q";
            ListaNotaDebito Check = new ListaNotaDebito();
            Check.Show();
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

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (cmb_TipoDocumento.SelectedIndex == 0)
            {
                MessageBox.Show("Debe Seleccionar Un tipo De Documento");
            }
            else
            {


                using (var buscarDocumentoForm = new BuscarDocumento(cmb_TipoDocumento.SelectedValue.ToString(), "D"))
                {
                    buscarDocumentoForm.ShowDialog();
                }
                btn_Buscar.Enabled = false;
            }
        }

        public void setDatosDocumento(String serie, String numero, String razonSocial, String Direccion,
            DateTime fecha, String Ruc, String Moneda, String glosa, String ClienteCod,Double total, Double subtotal,
            Double Igv)
        {
            ContadorItem++;
            txt_SerieBuscar.Text = serie;
            txt_NumeroBuscar.Text = numero;
            txt_Cliente.Text = razonSocial;
            txt_Direccion.Text = Direccion;
            txt_Ruc.Text = Ruc;
            txt_GlosaCab.Text = glosa;
            dpck_Fechadcto.Value = fecha;
            txt_codcliente.Text = ClienteCod;
            cmb_Moneda.SelectedValue = Moneda;
            //objListDocumentoDet = objDocumento.listarDetalle(numero, serie, Ventas.UNIDADNEGOCIO);
            objDocumentoDet = new DocumentoDet();
            objDocumentoDet.DocumentoCabNro = numero;
            objDocumentoDet.DocumentoCabSerie = serie;
            objDocumentoDet.DocumentoDesProducto = "ANULACIÓN FACTURA " + serie + "-" + numero;
            objDocumentoDet.DocumentoDetCantidad = 1;
            objDocumentoDet.DocumentoDetId = ContadorItem;
            objDocumentoDet.DocumentoDetCodEnt = Ventas.UNIDADNEGOCIO;
            objDocumentoDet.DocumentoDetIGV = Igv;
            objDocumentoDet.DocumentoDetPrecioTotal = subtotal;
            objDocumentoDet.DocumentoDetSubTotal = subtotal;
            objDocumentoDet.DocumentoDetPrecioSinIGV = subtotal;
           // txt_ValorVenta.Text = ListaNotaCredito.objDocumentoCab.DocumentoCabTotalSinIGV.ToString();
           // txt_TotalPagar.Text = ListaNotaCredito.objDocumentoCab.DocumentoCabTotal.ToString();
           // txt_IGV.Text = ListaNotaCredito.objDocumentoCab.DocumentoCabIGV.ToString();
            if (Ventas.UNIDADNEGOCIO == "02")
            {
                objDocumentoDet.DocumentoProdUMCod = "040";
                objDocumentoDet.DocumentoProdUMcorta = "ZZ";
                objDocumentoDet.ProductoCod = "000000000003";
            }
            else
            {
                objDocumentoDet.DocumentoProdUMCod = "039";
                objDocumentoDet.ProductoCod = "000000012343";
                objDocumentoDet.DocumentoProdUMcorta = "NIU";
            }

            objListDocumentoDet.Add(objDocumentoDet);



            listarDetalle(objListDocumentoDet);

            llenarSumatorias();
            button1.Enabled = true;
        }

      

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            btn_SaveData.Enabled = false;
            for (int i = 0; i < objListDocumentoDet.Count; i++)
            {
                objListDocumentoDet[i].DocumentoCabSerie = txt_Serie.Text;
                objListDocumentoDet[i].DocumentoCabNro = txt_Numero.Text;
            }
            bool binsertar, bupdate, bdetalle = true;

            objDocumentoCab = new DocumentoCab();
            objDocumentoCab.DocumentoCabSerie = txt_Serie.Text;
            objDocumentoCab.DocumentoCabNro = txt_Numero.Text;
            objDocumentoCab.DocumentoCabClienteCod = txt_codcliente.Text;
            objDocumentoCab.DocumentoCabFecha = dpick_Fecha.Value;
            objDocumentoCab.DocumentoCabGlosa = txt_GlosaCab.Text;
            objDocumentoCab.DocumentoCabIGV = convertToDouble(txt_IGV.Text);
            objDocumentoCab.DocumentoCabTotalSinIGV = convertToDouble(txt_ValorVenta.Text);
            objDocumentoCab.DocumentoCabTotal = convertToDouble(txt_TotalPagar.Text);
            objDocumentoCab.DocumentoCabTipoDoc = "08";
            objDocumentoCab.DocumentoCabTipoPago = 1;
            objDocumentoCab.DocumentoCabTipoNotaDebito = cmb_Motivo.SelectedValue.ToString();
            objDocumentoCab.DocumentoCabTipoMoneda = cmb_Moneda.SelectedValue.ToString();

            objDocumentoCab.DocumentoCabNroRef = txt_NumeroBuscar.Text;
            objDocumentoCab.DocumentoCabSerieRef = txt_SerieBuscar.Text;
            objDocumentoCab.DocumentoCabTipoDocRef = "01";
            objDocumentoCab.DocumentoCabFechaDocRef = dpck_Fechadcto.Value;

            objDocumentoCab.DocumentoCabUsuAdd = Ventas.UsuarioSession;
            objDocumentoCab.DocumentoCabFechaVcto = new DateTime(2000, 1, 1);
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
                    MessageBox.Show("Nota de Crédito Guardada exitosamente");

                    btn_SaveData.Enabled = true;
                }
                DialogResult dialogResult = MessageBox.Show("Enviar a Sunat?", "ENVIAR DOCUMENTOS", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    objDocumentoElectronicoCab = objDocumento.getDocumentoElectronicoCab(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                    objListDocumentoElectronicoDet = objDocumento.getDocumentoElectronicoDet(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                    String rutatext = objProceso.generarText(objDocumentoElectronicoCab, objListDocumentoElectronicoDet);
                    String mess = objProceso.sendTxt(rutatext);
                    
                    String mensajeMostrar = "";
                    String[] array = mess.Split('|');

                    List<String> objListaString = array.ToList();
                    if (objListaString.Count < 10)
                    {
                        mensajeMostrar = objListaString[1];
                        objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                        //objDocumento.updateEstadoAnulado(txt_Serie.Text, txt_Numero.Text);

                    }
                    else
                    {
                        mensajeMostrar = objListaString[9];
                        if (mensajeMostrar == "true")
                        {
                            mensajeMostrar = "Documento Enviado";
                            objDocumento.updateObservacionSunat(txt_Serie.Text, txt_Numero.Text, mensajeMostrar);
                            //objDocumento.updateEstadoAceptado(txt_Serie.Text, txt_Numero.Text);
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
            }
            else
            {
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
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    bupdate = objDocumento.updateDetalle(objListDocumentoDet[i]);
                    if (bupdate == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                }
                if (bupdate)
                {
                    MessageBox.Show("Nota de Débito Guardada exitósamente");

                    btn_SaveData.Enabled = true;
                }

                btn_SaveData.Enabled = true;

            }
            // nuevoRegistro();
            this.Hide();
            ListaNotaDebito.operacionFactura = "Q";
            ListaNotaDebito Check = new ListaNotaDebito();
            Check.Show();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            txt_GlosaCab.Enabled = true;
            cmb_Motivo.Enabled = true;
            cmb_Moneda.Enabled = true;
            btn_SaveData.Enabled = true;
            btn_Add.Enabled = true;
            btn_Editar.Enabled = true;
            dpick_Fecha.Enabled = true;
            button1.Enabled = true;
            ContadorItem = objListDocumentoDet.Count;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            objDocumentoDet = new DocumentoDet();
            objListDocumentoDet.Add(objDocumentoDet);
            grd_Detalle.DataSource = null;
            grd_Detalle.DataSource = objListDocumentoDet;
            grd_Detalle.Refresh();
        }

        private void btn_BuscarProd_Click(object sender, EventArgs e)
        {
            using (var buscarProductoForm = new BuscarProducto("ND"))
            {
                buscarProductoForm.ShowDialog();
            }
        }

        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            ContadorItem++;
            Operacion = "S";
            //limpiarCampos();
            habilitarBotones(false, true);
            habilitarCampos(true);
            txt_ProdDescrip.Text = "";
            txt_Cantidad.Text = "";
            txt_CodigoProd.Text = "";
            txt_UM.Text = "";
            txt_umcod.Text = "";
            txt_PrecioUnitario.Text = "";
            txt_ItemN.Text = ContadorItem.ToString();
            btn_BuscarProd.Enabled = true;
            button1.Enabled = false;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";
            habilitarCampos(true);
            habilitarBotones(false, true);
        }
        private void habilitarBotones(bool bhabilitar1, bool bhabilitar2)
        {
            btn_Add.Enabled = bhabilitar1;
            btn_Editar.Enabled = bhabilitar1;
            btn_Guardar.Enabled = bhabilitar2;
           
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            objDocumentoDet = new DocumentoDet();
            objDocumentoDet.DocumentoCabNro = txt_Numero.Text;
            objDocumentoDet.DocumentoCabSerie = txt_Serie.Text;
            objDocumentoDet.DocumentoDesProducto = txt_ProdDescrip.Text;
            objDocumentoDet.DocumentoDetCantidad = convertToDouble( txt_Cantidad.Text);
            objDocumentoDet.DocumentoDetId = Convert.ToInt32( txt_ItemN.Text);
            objDocumentoDet.DocumentoDetCodEnt = Ventas.UNIDADNEGOCIO;
            objDocumentoDet.DocumentoDetSubTotal = convertToDouble(txt_Subtotal.Text);
            objDocumentoDet.DocumentoDetIGV = Math.Round( objDocumentoDet.DocumentoDetSubTotal * 0.18,2);
            objDocumentoDet.ProductoCod = txt_CodigoProd.Text;
            objDocumentoDet.DocumentoProdUMcorta = txt_UM.Text;
            objDocumentoDet.DocumentoDetUsuAdd = Ventas.UsuarioSession;
            objDocumentoDet.DocumentoProdUMCod = txt_umcod.Text;
            objDocumentoDet.DocumentoDetPrecioSinIGV = convertToDouble(txt_PrecioUnitario.Text); ;
            objDocumentoDet.DocumentoDetItemOt = 0;
            if (String.IsNullOrEmpty( txt_umcod.Text))
            {
                if (Ventas.UNIDADNEGOCIO == "02")
                {
                    objDocumentoDet.DocumentoProdUMCod = "040";
                    objDocumentoDet.DocumentoProdUMcorta = "ZZ";
                    objDocumentoDet.ProductoCod = "000000000003";
                }
                else
                {
                    objDocumentoDet.DocumentoProdUMCod = "039";
                    objDocumentoDet.ProductoCod = "000000012343";
                    objDocumentoDet.DocumentoProdUMcorta = "NIU";
                }
            }
            if (Operacion == "S")
            {
                objListDocumentoDet.Add(objDocumentoDet);

            }
            else if (Operacion == "M")
            {
                objListDocumentoDet[index] = objDocumentoDet;
            }

            listarDetalle(objListDocumentoDet);


            txt_ProdDescrip.Text = "";
            txt_Cantidad.Text = "";
            txt_CodigoProd.Text = "";
            txt_UM.Text = "";
            txt_umcod.Text = "";
            txt_PrecioUnitario.Text = "";
            btn_BuscarProd.Enabled = false;
            llenarSumatorias();
            habilitarBotones(true, false);
            habilitarCampos(false);
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = true;
        }

        private void NotaDeCredito_Load(object sender, EventArgs e)
        {

        }
    }
}
