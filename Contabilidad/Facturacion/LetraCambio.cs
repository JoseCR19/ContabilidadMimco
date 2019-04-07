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
    public partial class LetraCambio : Form
    {
        public static LetraCambio letraCambioForm;
        public static List<Pago> objListTipPago = new List<Pago>();
        public static List<DocumentoCab> objListaDocumentoCab = new List<DocumentoCab>();
        public static List<LetraDet> objListaLetraDet = new List<LetraDet>();
        public static String Operacion = "Q";
        MonedaDAO objMonedaDao;
        DocumentoCab objDocumentoCab = new DocumentoCab();
        LetraDet objLetraDet = new LetraDet();
        static int index;
        public static String codigoCliente = "NN";
        public static String Modificar = "Q";
        Double montoCanjeadoTemp;
        DocumentoContabilidadDAO objContabilidadDocuDAO;
        DocumentoDAO objDocumentoDao;
        TipoPagoDAO objTipoPagoDao;
        public LetraCambio()
        {
            InitializeComponent();
            this.ControlBox = false;
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            gridParams();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            letraCambioForm = this;
            objContabilidadDocuDAO = new DocumentoContabilidadDAO();
            objTipoPagoDao = new TipoPagoDAO();
            objDocumentoDao = new DocumentoDAO();
            comboDocumento();
            comboPago();
            dpck_Fechavcto.ValueChanged += Dpck_Fechavcto_ValueChanged;
            dpick_Fecha.ValueChanged += Dpick_Fecha_ValueChanged;
            txt_Dividir.KeyPress += Txt_Dividir_KeyPress;
            chk_Dividir.CheckedChanged += Chk_Dividir_CheckedChanged;
            txt_Dividir.TextChanged += Txt_Dividir_TextChanged;
            txt_Porcentaje.KeyPress += Txt_Porcentaje_KeyPress;
            chk_Detraccion.CheckedChanged += Chk_Detraccion_CheckedChanged;
            txt_Porcentaje.TextChanged += Txt_Porcentaje_TextChanged;
            txt_Porcentaje.Text = "0";
            txt_Dividir.Text = "0";
            if (ListaLetraCambio.operacionLetra == "N")
            {
                Modificar = "N";
                if (Ventas.UNIDADNEGOCIO == "01")
                {
                    txt_Serie.Text = "M/";
                }
                else
                {
                    txt_Serie.Text = "G/";
                }
                dpck_Fechavcto.Value = DateTime.Now.AddMonths(1);
                dpick_Fecha.Enabled = true;
                txt_Numero.Text = objDocumentoDao.correlativoLetra(Ventas.UNIDADNEGOCIO);
            }
            else
            {
                if (ListaLetraCambio.objDocumentoCab.EstadoSunat == 0)
                {
                    lbl_Anulado.Visible = true;
                }
               else if (ListaLetraCambio.objDocumentoCab.EstadoSunat != 0)
                {
                    btn_Modificar.Visible = true;
                }
                txt_Serie.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabNro;
                txt_Cliente.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabCliente;
                txt_codcliente.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteCod;
                txt_Direccion.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_codcliente.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteCod;
                txt_Aval.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteAval;
                txt_DireccionAval.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteDireccionAval;
                txt_Porcentaje.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                txt_Ruc.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_RucAval.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabClienteRucAval;
                txt_Dividir.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabDividir.ToString();
                objListaLetraDet = objDocumentoDao.listarLetraDet(txt_Serie.Text, txt_Numero.Text);
                txt_fechaemidcto.Text = dpick_Fecha.Value.ToShortDateString();
                txt_fechavctodcto.Text = dpck_Fechavcto.Value.ToShortDateString();
                txt_CodMoneda.Text = ListaLetraCambio.objDocumentoCab.DocumentoCabTipoMoneda;
                dpick_Fecha.Value = ListaLetraCambio.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechavcto.Value = ListaLetraCambio.objDocumentoCab.DocumentoCabFechaVcto;

                grdDocumento.DataSource = objListaLetraDet;
                grdDocumento.Refresh();
                llenarSumatorias();
                btn_SaveData.Enabled = false;
                btn_Limpiar.Enabled = false;
                btn_Add.Enabled = false;
                txt_Porcentaje.Enabled = false;
                btn_Buscar.Enabled = false;
                btn_BuscarDocu.Enabled = false;
                btn_BuscarAval.Enabled = false;
                btn_Limpiar.Enabled = false;
                chk_Dividir.Enabled = false;
                chk_Detraccion.Enabled = false;
                dpck_Fechavcto.Enabled = false;
                cmb_Pago.SelectedValue = ListaLetraCambio.objDocumentoCab.DocumentoCabTipoPago;
                cmb_Pago.Enabled = false;
                cmb_TipoDocumento.Enabled = false;
               
            }
            grdDocumento.CellClick += GrdDocumento_CellClick;
            txt_Tcambio.Text = objMonedaDao.getTipoCambioVenta(dpick_Fecha.Value.ToString("dd/MM/yyyy")).ToString().PadRight(5, '0');
            cmb_Pago.SelectedIndexChanged += Cmb_Pago_SelectedIndexChanged;
        }

        private void Dpick_Fecha_ValueChanged(object sender, EventArgs e)
        {
            txt_fechaemidcto.Text = dpick_Fecha.Value.ToShortDateString();
        }

        private void Cmb_Pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpck_Fechavcto.Value = DateTime.Now;
            List<int> objInt = new List<int>();
            objInt = objListTipPago.Where(x => x.PagoId.ToString() == cmb_Pago.SelectedValue.ToString()).Select(x => x.Dias).ToList();
            dpck_Fechavcto.Value = dpck_Fechavcto.Value.AddDays(objInt[0]);
        }

        private void Dpck_Fechavcto_ValueChanged(object sender, EventArgs e)
        {


            txt_fechavctodcto.Text = dpck_Fechavcto.Value.ToShortDateString();
        }

        private void GrdDocumento_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (objListaLetraDet.Count != 0)
            {
                objLetraDet = new LetraDet();
                index = grdDocumento.SelectedCells[0].RowIndex;
                objLetraDet = objListaLetraDet[index];
                txt_DetraccionFactura.Text = objLetraDet.LetraDetDetraccion.ToString();
                txt_Porcentaje.Text = objLetraDet.LetraDetDetraccionPorcentaje.ToString();
                txt_SerieDcto.Text = objLetraDet.LetraDetSerieRef;
                txt_NumeroDcto.Text = objLetraDet.LetraDetNroRef;
                txt_TotalFactura.Text = objLetraDet.LetraDetTotal.ToString();
                txt_FacturaCanjeado.Text = objLetraDet.LetraDetAbono.ToString();
               // dpick_Fecha.Value = objLetraDet.LetraDetFechaEmisionRef;
               // dpck_Fechavcto.Value = objLetraDet.LetraDetFechaVctoRef;
                if(objLetraDet.LetraDetDetraccion > 0)
                {
                    chk_Detraccion.Checked = true;
                }else
                {
                    chk_Detraccion.Checked = false;
                }
                

            }
        }

        private void Txt_Porcentaje_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_FacturaCanjeado.Text))
            {
                txt_FacturaCanjeado.Text = montoCanjeadoTemp.ToString();
                if (txt_Porcentaje.Text != "0" && chk_Detraccion.Checked)
                {
                    txt_DetraccionFactura.Text = (convertToDouble(txt_FacturaCanjeado.Text) * convertToDouble(txt_Porcentaje.Text) / 100).ToString();
                    txt_FacturaCanjeado.Text =   (convertToDouble(txt_FacturaCanjeado.Text) - convertToDouble(txt_DetraccionFactura.Text)).ToString();
                }
                else
                {
                    txt_DetraccionFactura.Text = "0";
                    txt_FacturaCanjeado.Text = montoCanjeadoTemp.ToString();
                }
            } 
        }

        private void Txt_Porcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Chk_Detraccion_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Double aux1, aux2, aux3;
                if (chk_Detraccion.Checked)
                {
                    if (txt_Porcentaje.Text != "0" || String.IsNullOrEmpty(txt_Porcentaje.Text))
                    {
                        aux1 = convertToDouble(txt_FacturaCanjeado.Text);
                        aux2 = Convert.ToInt32(txt_Porcentaje.Text);
                        aux3 = aux1 * aux2;
                        txt_DetraccionFactura.Text = (aux3 / 100).ToString();
                        txt_FacturaCanjeado.Text = (convertToDouble(txt_FacturaCanjeado.Text) - convertToDouble(txt_DetraccionFactura.Text)).ToString();
                    }
                }
                else
                {
                    txt_Porcentaje.Text = "";
                    txt_DetraccionFactura.Text = "0";
                    if (chk_Dividir.Checked && (txt_Dividir.Text != "0" || !String.IsNullOrEmpty(txt_Dividir.Text)))
                    {
                        txt_FacturaCanjeado.Text = (convertToDouble(txt_TotalFactura.Text) / convertToDouble(txt_Dividir.Text)).ToString();
                    }
                    else
                    {
                        txt_FacturaCanjeado.Text = txt_TotalFactura.Text;
                        montoCanjeadoTemp = convertToDouble(txt_TotalFactura.Text);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Txt_Dividir_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_TotalFactura.Text) && (txt_Dividir.Text != "0" || !String.IsNullOrEmpty(txt_Dividir.Text)))
            {
                txt_FacturaCanjeado.Text = (convertToDouble(txt_TotalFactura.Text) / Convert.ToInt32(txt_Dividir.Text)).ToString();
                montoCanjeadoTemp = convertToDouble(txt_FacturaCanjeado.Text);
            }
        }

        private void Chk_Dividir_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Dividir.Checked)
            {
                txt_Dividir.Enabled = true;
                if (txt_Dividir.Text != "0" || String.IsNullOrEmpty(txt_Dividir.Text))
                {
                    if (!chk_Detraccion.Checked)
                    {
                        txt_FacturaCanjeado.Text = (convertToDouble(txt_TotalFactura.Text) / Convert.ToInt32(txt_Dividir.Text)).ToString();
                    }
                    else
                    {
                        if (txt_Porcentaje.Text != "0" || !String.IsNullOrEmpty(txt_Porcentaje.Text))
                        {
                            txt_FacturaCanjeado.Text = ((convertToDouble(txt_TotalFactura.Text) / Convert.ToInt32(txt_Dividir.Text))
                                - ((convertToDouble(txt_TotalFactura.Text) / Convert.ToInt32(txt_Dividir.Text)) * convertToDouble(txt_Porcentaje.Text) / 100)).ToString();
                            txt_DetraccionFactura.Text = ((convertToDouble(txt_TotalFactura.Text) / Convert.ToInt32(txt_Dividir.Text)) * convertToDouble(txt_Porcentaje.Text) / 100).ToString();
                        }
                        else
                        {
                            txt_FacturaCanjeado.Text = (convertToDouble(txt_TotalFactura.Text) / Convert.ToInt32(txt_Dividir.Text)).ToString();
                        }
                    }


                    montoCanjeadoTemp = convertToDouble(txt_FacturaCanjeado.Text);
                }
            }
            else
            {
                txt_Dividir.Enabled = false;
                if (!chk_Detraccion.Checked)
                {
                    txt_FacturaCanjeado.Text = txt_TotalFactura.Text;
                }
                else
                {
                    if (txt_Porcentaje.Text != "0" || !String.IsNullOrEmpty(txt_Porcentaje.Text))
                    {
                        txt_FacturaCanjeado.Text = (convertToDouble(txt_TotalFactura.Text) - convertToDouble(txt_TotalFactura.Text)
                            * convertToDouble(txt_Porcentaje.Text) / 100).ToString();
                        txt_DetraccionFactura.Text = (convertToDouble(txt_TotalFactura.Text)
                            * convertToDouble(txt_Porcentaje.Text) / 100).ToString();
                    }
                    else
                    {
                        txt_FacturaCanjeado.Text = txt_TotalFactura.Text;
                        txt_DetraccionFactura.Text = "0";
                    }

                }

                montoCanjeadoTemp = convertToDouble(txt_FacturaCanjeado.Text);

            }

        }

        public void llenarSumatorias()
        {
            txt_Total.Text = objListaLetraDet.Sum(x => x.LetraDetTotal).ToString();
            txt_TotalCanjeado.Text = objListaLetraDet.Sum(x => x.LetraDetAbono).ToString();
            txt_TotalDetraccion.Text = objListaLetraDet.Sum(x => x.LetraDetDetraccion).ToString();

        }



        private void Txt_Dividir_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void gridParams()
        {
            grdDocumento.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Width = 75;
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "LetraDetSerieRef";
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "LetraDetNroRef";
            idColumn1.Width = 120;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Fecha Documento";
            idColumn2.DataPropertyName = "LetraDetFechaEmisionRef";
            idColumn2.Width = 150;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha Vencimiento";
            idColumn3.DataPropertyName = "LetraDetFechaVctoRef";
            idColumn3.Width = 150;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Total";
            idColumn4.DataPropertyName = "LetraDetTotal";
            idColumn4.Width = 120;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Monto Canjeado";
            idColumn5.DataPropertyName = "LetraDetAbono";
            idColumn5.Width = 120;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Detracción";
            idColumn6.DataPropertyName = "LetraDetDetraccion";
            idColumn6.Width = 120;
            grdDocumento.Columns.Add(idColumn6);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            using (var buscarClienteForm = new BuscarCliente("T")) //LT
            {
                buscarClienteForm.ShowDialog();
            }
        }
        public void setClienteDatos(string cliente, string direccion, string ruc, string codigocliente)
        {
            txt_Cliente.Text = cliente;
            txt_Direccion.Text = direccion;
            txt_Ruc.Text = ruc;
            txt_codcliente.Text = codigocliente;
        }
        public void setClienteDatosAval(string cliente, string direccion, string ruc, string codigocliente, string telefono)
        {
            txt_Aval.Text = cliente;
            txt_DireccionAval.Text = direccion;
            txt_RucAval.Text = ruc;
            txt_AvalCod.Text = codigocliente;
            txt_Telefono.Text = telefono;
        }

        private void btn_BuscarAval_Click(object sender, EventArgs e)
        {
            using (var buscarClienteForm = new BuscarCliente("A")) //LT
            {
                buscarClienteForm.ShowDialog();
            }
        }

        private void btn_BuscarDocu_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_codcliente.Text))
            {
                codigoCliente = txt_codcliente.Text;
            }
            using (var buscarDocumentoForm = new BuscarDocumento(cmb_TipoDocumento.SelectedValue.ToString(), "T"))
            {
                buscarDocumentoForm.ShowDialog();
            }
        }
        public void setDatosDocumento(String serie, String numero, Double total, DateTime fechaEmi,
            DateTime fechaVcto, String moneda)
        {
            txt_SerieDcto.Text = serie;
            txt_NumeroDcto.Text = numero;
            txt_TotalFactura.Text = total.ToString();
            txt_fechaemidcto.Text = fechaEmi.ToShortDateString();
            txt_fechavctodcto.Text = fechaVcto.ToShortDateString();
            txt_CodMoneda.Text = moneda;
            if (chk_Dividir.Checked)
            {
                if (!String.IsNullOrEmpty(txt_Dividir.Text))
                {
                    txt_FacturaCanjeado.Text = (total / Convert.ToInt32(txt_Dividir.Text)).ToString();
                    montoCanjeadoTemp = convertToDouble(txt_FacturaCanjeado.Text);
                }
            }
            else
            {
                txt_FacturaCanjeado.Text = txt_TotalFactura.Text;
                montoCanjeadoTemp = convertToDouble(txt_FacturaCanjeado.Text);
            }


        }

        void comboDocumento()
        {
            cmb_TipoDocumento.DataSource = objContabilidadDocuDAO.listarDocumentoContabilidad();
            cmb_TipoDocumento.ValueMember = "DocContabilidadCod";
            cmb_TipoDocumento.DisplayMember = "DocContabilidadDescripcion";
            cmb_TipoDocumento.Refresh();

        }
        public void comboPago()
        {
            objListTipPago = objTipoPagoDao.listarTipoPago();
            cmb_Pago.DataSource = objListTipPago;
            cmb_Pago.DisplayMember = "PagoDescripcion";
            cmb_Pago.ValueMember = "PagoId";
            cmb_Pago.Refresh();

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

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Operacion = "S";
            btn_Editar.Enabled = false;
            btn_Guardar.Enabled = true;
            btn_BuscarDocu.Enabled = true;
            dpck_Fechavcto.Enabled = true;
            btn_Add.Enabled = false;
            chk_Detraccion.Enabled = true;
            txt_Porcentaje.Enabled = true;
            

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

            objDocumentoCab.DocumentoCabClienteCodAval = txt_AvalCod.Text;
            objDocumentoCab.DocumentoCabUsuAdd = Ventas.UsuarioSession;
            objDocumentoCab.DocumentoCabTotal = convertToDouble(txt_Total.Text);
            objDocumentoCab.DocumentoCabTipoDoc = "LT";
            objDocumentoCab.DocumentoCabTipoPago = Convert.ToInt32(cmb_Pago.SelectedValue);
            try
            {
                objDocumentoCab.DocumentoCabDividir = Convert.ToInt32(txt_Dividir.Text);
            }
            catch
            {
                objDocumentoCab.DocumentoCabDividir = 0;
            }

            objDocumentoCab.DocumentoCabFecha = dpick_Fecha.Value;
            objDocumentoCab.DocumentoCabFechaVcto = dpck_Fechavcto.Value;

            objDocumentoCab.DocumentoCabDetraccion = convertToDouble(txt_TotalDetraccion.Text);
            objDocumentoCab.DocumentoCabDetraccionPorcentaje = convertToDouble(txt_Porcentaje.Text);
            objDocumentoCab.DocumentoCabAbono = convertToDouble(txt_TotalCanjeado.Text);
            objDocumentoCab.DocumentoCabSaldo = objDocumentoCab.DocumentoCabTotal - (objDocumentoCab.DocumentoCabAbono + objDocumentoCab.DocumentoCabDetraccion);
            objDocumentoCab.DocumentoCabTipoMoneda = txt_CodMoneda.Text;
            objDocumentoCab.DocumentoCabSerieRef = txt_SerieDcto.Text;
            objDocumentoCab.DocumentoCabNroRef = txt_NumeroDcto.Text;

            if (Modificar =="M")
            {
                binsertar = objDocumentoDao.updateLetraCab(objDocumentoCab, Ventas.UNIDADNEGOCIO,Ventas.UsuarioSession);

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
                objDocumentoDao.deleteLetraDet(objDocumentoCab.DocumentoCabSerie, objDocumentoCab.DocumentoCabNro);
                for (int i = 0; i < objListaLetraDet.Count; i++)
                {
                    bdetalle = objDocumentoDao.insertLetraDet(objListaLetraDet[i]);
                    if (bdetalle == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                }
                if (bdetalle)
                {
                    MessageBox.Show("Letra Guardada exitosamente");
                    nuevoRegistro();
                    btn_SaveData.Enabled = true;
                }
            }
            else
            {
                binsertar = objDocumentoDao.insertarLetraCab(objDocumentoCab, Ventas.UNIDADNEGOCIO);

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
                for (int i = 0; i < objListaLetraDet.Count; i++)
                {
                    bdetalle = objDocumentoDao.insertLetraDet(objListaLetraDet[i]);
                    if (bdetalle == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                }
                if (bdetalle)
                {
                    MessageBox.Show("Letra Guardada exitosamente");
                    nuevoRegistro();
                    btn_SaveData.Enabled = true;
                }
            }
            
            this.Hide();
            objListaLetraDet = null;
            ListaLetraCambio.operacionLetra = "Q";
            ListaLetraCambio Check = new ListaLetraCambio();
            Check.Show();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaLetraCambio.operacionLetra = "Q";
            ListaLetraCambio Check = new ListaLetraCambio();
            Check.Show();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            nuevoRegistro();
        }
        void nuevoRegistro()
        {
            txt_DireccionAval.Text = "";
            txt_Aval.Text = "";
            txt_AvalCod.Text = "";
            txt_Cliente.Text = "";
            txt_codcliente.Text = "";
            txt_DetraccionFactura.Text = "";
            txt_Direccion.Text = "";
            txt_Dividir.Text = "0";
            txt_FacturaCanjeado.Text = "";
            txt_fechaemidcto.Text = "";
            txt_fechavctodcto.Text = "";
            txt_Numero.Text = objDocumentoDao.correlativoLetra(Ventas.UNIDADNEGOCIO);
            txt_NumeroDcto.Text = "";
            txt_Porcentaje.Text = "0";
            txt_Ruc.Text = "";
            txt_RucAval.Text = "";
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                txt_Serie.Text = "M/";
            }
            else
            {
                txt_Serie.Text = "G/";
            }
            txt_SerieDcto.Text = "";
            txt_Tcambio.Text = "";
            txt_Telefono.Text = "";
            txt_Total.Text = "";
            txt_TotalCanjeado.Text = "";
            txt_TotalDetraccion.Text = "";
            txt_TotalFactura.Text = "";
            dpck_Fechavcto.Value = DateTime.Now;
            dpick_Fecha.Value = DateTime.Now;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            objLetraDet = new LetraDet();
            objLetraDet.LetraDetAbono =Math.Round(convertToDouble(txt_FacturaCanjeado.Text),2,MidpointRounding.AwayFromZero);
            objLetraDet.LetraDetDetraccion =Math.Round(convertToDouble(txt_DetraccionFactura.Text),2,MidpointRounding.AwayFromZero);
            objLetraDet.LetraDetDetraccionPorcentaje = convertToDouble(txt_Porcentaje.Text);
           // objLetraDet.LetraDetFechaEmisionRef = Convert.ToDateTime(txt_fechaemidcto.Text);
           // objLetraDet.LetraDetFechaVctoRef = Convert.ToDateTime(txt_fechavctodcto.Text);
            objLetraDet.LetraDetNro = txt_Numero.Text;
            objLetraDet.LetraDetNroRef = txt_NumeroDcto.Text;
            objLetraDet.LetraDetSaldo = objDocumentoCab.DocumentoCabTotal - Math.Round(objDocumentoCab.DocumentoCabAbono + objDocumentoCab.DocumentoCabDetraccion, 2, MidpointRounding.AwayFromZero);
            objLetraDet.LetraDetSerie = txt_Serie.Text;
            objLetraDet.LetraDetSerieRef = txt_SerieDcto.Text;
            objLetraDet.LetraDetTotal = convertToDouble(txt_TotalFactura.Text);
            objLetraDet.LetraDetCodMoneda = txt_CodMoneda.Text;
            if (Operacion == "S")
            {
                objListaLetraDet.Add(objLetraDet);
            }else if(Operacion =="M")
            {
                objListaLetraDet[index] = objLetraDet;
            }
           
            grdDocumento.DataSource = null;
            grdDocumento.DataSource = objListaLetraDet;
            grdDocumento.Refresh();
            llenarSumatorias();
            btn_Buscar.Enabled = false;
            btn_BuscarDocu.Enabled = true;
            btn_Add.Enabled = true;
            btn_Guardar.Enabled = false;
            btn_Editar.Enabled = true;
            btn_BuscarDocu.Enabled = false;
            dpck_Fechavcto.Enabled = false;
            txt_SerieDcto.Text = "";
            txt_NumeroDcto.Text = "";
            txt_TotalFactura.Text = "";
            txt_FacturaCanjeado.Text = "";
            txt_DetraccionFactura.Text = "";
            chk_Detraccion.Checked = false;
            
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";
            btn_Add.Enabled = false;
            btn_BuscarDocu.Enabled = false;
            btn_Guardar.Enabled = true;
            dpck_Fechavcto.Enabled = true;
            chk_Detraccion.Enabled = true;
            txt_Porcentaje.Enabled = true;
            dpick_Fecha.Enabled = true;
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            Modificar = "M";
            btn_Editar.Enabled = true;
            btn_Guardar.Enabled = true;
            btn_Add.Enabled = true;
            btn_SaveData.Enabled = true;
            cmb_Pago.Enabled = true;
            btn_BuscarAval.Enabled = true;
        }

        private void LetraCambio_Load(object sender, EventArgs e)
        {

        }
    }
}
