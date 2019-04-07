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
namespace Contabilidad.Reporte
{
    public partial class LetraReporte : Form
    {
        
        public static List<Pago> objListTipPago = new List<Pago>();
        public static List<DocumentoCab> objListaDocumentoCab = new List<DocumentoCab>();
        public static List<LetraDet> objListaLetraDet = new List<LetraDet>();
        public static String Operacion = "Q";
        MonedaDAO objMonedaDao;
        static String  tipoReporte;
        DocumentoCab objDocumentoCab = new DocumentoCab();
        LetraDet objLetraDet = new LetraDet();
        static int index;
        public static String codigoCliente = "NN";
        public static String Modificar = "Q";
        Double montoCanjeadoTemp;
        DocumentoContabilidadDAO objContabilidadDocuDAO;
        DocumentoDAO objDocumentoDao;
        TipoPagoDAO objTipoPagoDao;
        public LetraReporte(String rep)
        {
            InitializeComponent();
            tipoReporte = rep;
            this.ControlBox = false;
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            gridParams();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            
            objContabilidadDocuDAO = new DocumentoContabilidadDAO();
            objTipoPagoDao = new TipoPagoDAO();
            objDocumentoDao = new DocumentoDAO();
            comboDocumento();
            comboPago();

            txt_Dividir.KeyPress += Txt_Dividir_KeyPress;
            chk_Dividir.CheckedChanged += Chk_Dividir_CheckedChanged;
            txt_Dividir.TextChanged += Txt_Dividir_TextChanged;
            txt_Porcentaje.KeyPress += Txt_Porcentaje_KeyPress;
            chk_Detraccion.CheckedChanged += Chk_Detraccion_CheckedChanged;
            txt_Porcentaje.TextChanged += Txt_Porcentaje_TextChanged;
            txt_Porcentaje.Text = "0";
            txt_Dividir.Text = "0";

            if (tipoReporte == "F")
            {
                if (ReporteDocumentosPorFecha.objDocumentoCab.EstadoSunat == 0)
                {
                    lbl_Anulado.Visible = true;
                }

                txt_Serie.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabNro;
                txt_Cliente.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabCliente;

                txt_Direccion.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDireccion;

                txt_Aval.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteAval;
                txt_DireccionAval.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDireccionAval;
                txt_Porcentaje.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                txt_Ruc.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_RucAval.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteRucAval;
                txt_Dividir.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabDividir.ToString();
                objListaLetraDet = objDocumentoDao.listarLetraDetReporte(txt_Serie.Text, txt_Numero.Text, ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabOrdenCompra, Ventas.UNIDADNEGOCIO);
                dpick_Fecha.Value = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechavcto.Value = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFechaVcto;
                cmb_Pago.SelectedValue = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoPago;
            }
            else
            {
                if (ReporteDocumentosPorCliente.objDocumentoCab.EstadoSunat == 0)
                {
                    lbl_Anulado.Visible = true;
                }

                txt_Serie.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabNro;
                txt_Cliente.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabCliente;

                txt_Direccion.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDireccion;

                txt_Aval.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteAval;
                txt_DireccionAval.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDireccionAval;
                txt_Porcentaje.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                txt_Ruc.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_RucAval.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteRucAval;
                txt_Dividir.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabDividir.ToString();
                objListaLetraDet = objDocumentoDao.listarLetraDetReporte(txt_Serie.Text, txt_Numero.Text, ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabOrdenCompra, Ventas.UNIDADNEGOCIO);
                dpick_Fecha.Value = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechavcto.Value = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFechaVcto;
                cmb_Pago.SelectedValue = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTipoPago;
            }

            grdDocumento.DataSource = objListaLetraDet;
                grdDocumento.Refresh();
                llenarSumatorias();
                btn_SaveData.Enabled = false;
                btn_Limpiar.Enabled = false;
             
                txt_Porcentaje.Enabled = false;
                btn_Buscar.Enabled = false;

                btn_Limpiar.Enabled = false;
                chk_Dividir.Enabled = false;
                chk_Detraccion.Enabled = false;
                dpck_Fechavcto.Enabled = false;
                
                cmb_Pago.Enabled = false;
                cmb_TipoDocumento.Enabled = false;

            
            grdDocumento.CellClick += GrdDocumento_CellClick;
            txt_Tcambio.Text = objMonedaDao.getTipoCambioVenta(dpick_Fecha.Value.ToString("dd/MM/yyyy")).ToString().PadRight(5, '0');
            cmb_Pago.SelectedIndexChanged += Cmb_Pago_SelectedIndexChanged;
        }
     
        private void Cmb_Pago_SelectedIndexChanged(object sender, EventArgs e)
        {
            dpck_Fechavcto.Value = DateTime.Now;
            List<int> objInt = new List<int>();
            objInt = objListTipPago.Where(x => x.PagoId.ToString() == cmb_Pago.SelectedValue.ToString()).Select(x => x.Dias).ToList();
            dpck_Fechavcto.Value = dpck_Fechavcto.Value.AddDays(objInt[0]);
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
                if (objLetraDet.LetraDetDetraccion > 0)
                {
                    chk_Detraccion.Checked = true;
                }
                else
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
                    txt_FacturaCanjeado.Text = (convertToDouble(txt_FacturaCanjeado.Text) - convertToDouble(txt_DetraccionFactura.Text)).ToString();
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

    

        

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void btn_Regresar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
