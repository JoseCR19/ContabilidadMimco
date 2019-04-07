using Contabilidad.Report;
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


namespace Contabilidad
{
    public partial class ListaBoleta : Form
    {
        DocumentoDAO objDocumentoDao;
        FacturaReporteDTO objFacturaReporte;
        public static ListaBoleta formListaBoleta;
        public static DocumentoCab objDocumentoCab = new DocumentoCab();

        public static List<DocumentoCab> objListaDocumentoCab = new List<DocumentoCab>();
        static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<FacturaReporteDTO> objListFacturaReporte = new List<FacturaReporteDTO>();
        public static List<DocumentoElectronicoDet> objListDocumentoElectronicoDet = new List<DocumentoElectronicoDet>();
        public static DocumentoElectronicoCab objDocumentoElectronicoCab = new DocumentoElectronicoCab();
        Proceso objProceso = new Proceso();
        public static String MotivoAnulacion = "";
        public static String operacionFactura = "Q";
        public static String numeroDocumento = "";
        public static String numeroSerie = "";
        public ListaBoleta()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "BOLETAS";
            formListaBoleta = this;
            gridParams();
            objDocumentoDao = new DocumentoDAO();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            objListaDocumentoCab = objDocumentoDao.listarCabecera(d1, d2, txt_Ruc.Text,"03", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
        }
        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            switch (objDocumentoCab.EstadoSunat)
            {
                case 0:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = false;
                    break;
                case 1:
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    break;
                case 2:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = false;
                    break;
                case 3:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = true;
                    break;
            }
        }
        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_Nuevo.Enabled = false;
            this.Hide();
            operacionFactura = "N";
            Boleta Check = new Boleta();
            Check.Show();
            btn_Nuevo.Enabled = true;
        }


        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.Width = 50;
            idColumn1.DataPropertyName = "DocumentoCabSerie";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Número";
            idColumn2.DataPropertyName = "DocumentoCabNro";
            idColumn2.Width = 90;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razón Social";
            idColumn3.DataPropertyName = "DocumentoCabCliente";
            idColumn3.Width = 290;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "RUC";
            idColumn4.DataPropertyName = "DocumentoCabClienteDocumento";
            idColumn4.Width = 80;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "DocumentoCabMoneda";
            idColumn5.Width = 100;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Total";
            idColumn6.DataPropertyName = "DocumentoCabTotal";
            idColumn6.Width = 120;
            grd_Facturas.Columns.Add(idColumn6);


        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            objListaDocumentoCab = new List<DocumentoCab>();
            grd_Facturas.DataSource = null;
            objListaDocumentoCab = objDocumentoDao.listarCabecera(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text,"03", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            btn_Buscar.Enabled = true;
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            operacionFactura = "V";
            try
            {
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
                numeroSerie     = objListaDocumentoCab[index].DocumentoCabSerie;
                objDocumentoCab = objListaDocumentoCab[index];
                this.Hide();

                Boleta Check = new Boleta();
                Check.Show();

            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("B");
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
        private void formatearFactura(String qr)
        {
            objListDocumentoDet = new List<DocumentoDet>();
            objListFacturaReporte = new List<FacturaReporteDTO>();
               objListDocumentoDet = objDocumentoDao.detalleReporte(objDocumentoCab.DocumentoCabSerie,
                  objDocumentoCab.DocumentoCabNro, Ventas.UNIDADNEGOCIO);
            if (objListDocumentoDet.Count > 0)
            {
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    objFacturaReporte = new FacturaReporteDTO();
                    objFacturaReporte.Cantidad = objListDocumentoDet[i].DocumentoDetCantidad.ToString("C").Substring(3);
                    objFacturaReporte.Descuento = "0";
                    objFacturaReporte.Direccion = objDocumentoCab.DocumentoCabClienteDireccion;
                    objFacturaReporte.FechaEmision = objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                    objFacturaReporte.FechaVcto = objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();
                    objFacturaReporte.GuiaRemision = "";
                    objFacturaReporte.IGV = objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                    objFacturaReporte.Letras = objDocumentoDao.numeroALetras(convertToDouble(objDocumentoCab.DocumentoCabTotal.ToString())) + " " + objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                    objFacturaReporte.Moneda = objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                    objFacturaReporte.Numero = objDocumentoCab.DocumentoCabNro.TrimEnd();
                    objFacturaReporte.Serie = objDocumentoCab.DocumentoCabSerie;
                    objFacturaReporte.TipoPago = objDocumentoCab.DocumentoCabPago.TrimEnd();
                    objFacturaReporte.TOTAL = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                    objFacturaReporte.TotalSinIGV = objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                    objFacturaReporte.UM = objListDocumentoDet[i].DocumentoProdUMcorta;
                    objFacturaReporte.ValorUnitario = objListDocumentoDet[i].DocumentoDetPrecioSinIGV.ToString("C").Substring(3);
                    objFacturaReporte.ValorVenta = objListDocumentoDet[i].DocumentoDetSubTotal.ToString("C").Substring(3);
                    objFacturaReporte.PrecioUnitario = ((objListDocumentoDet[i].DocumentoDetPrecioSinIGV * 0.18) + objListDocumentoDet[i].DocumentoDetPrecioSinIGV).ToString("C").Substring(3);
                    objFacturaReporte.ProdCod = objListDocumentoDet[i].ProductoCod.TrimEnd();
                    objFacturaReporte.ProdDescrip = objListDocumentoDet[i].DocumentoDesProducto.TrimEnd();
                    objFacturaReporte.RazonSocial = objDocumentoCab.DocumentoCabCliente;
                    objFacturaReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;
                    objFacturaReporte.OrdenCompra = "";
                    objFacturaReporte.Tipo = "la Boleta de Venta Electrónica";
                    objFacturaReporte.QR = qr;
                    objFacturaReporte.Glosa = objDocumentoCab.DocumentoCabGlosa;
                    objFacturaReporte.TipoDocumento = "BOLETA DE VENTA";
                    objFacturaReporte.GuiaRemision = objDocumentoCab.DocumentoCabGuia;
                    objFacturaReporte.OrdenCompra = objDocumentoCab.DocumentoCabOrdenCompra;
                    if (objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                    {
                        objFacturaReporte.Simbolo = "$";
                    }
                    else
                    {
                        objFacturaReporte.Simbolo = "S/";
                    }
                    objListFacturaReporte.Add(objFacturaReporte);
                }
            }
            else
            {
                objFacturaReporte = new FacturaReporteDTO();
                objFacturaReporte.Descuento = "0";
                objFacturaReporte.Direccion = objDocumentoCab.DocumentoCabClienteDireccion;
                objFacturaReporte.FechaEmision = objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                objFacturaReporte.FechaVcto = objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();
                objFacturaReporte.GuiaRemision = "";
                objFacturaReporte.IGV = objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                objFacturaReporte.Letras = objDocumentoDao.numeroALetras(convertToDouble(objDocumentoCab.DocumentoCabTotal.ToString())) + " " + objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                objFacturaReporte.Moneda = objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                objFacturaReporte.Numero = objDocumentoCab.DocumentoCabNro.TrimEnd();
                objFacturaReporte.Serie = objDocumentoCab.DocumentoCabSerie;
                objFacturaReporte.TipoPago = objDocumentoCab.DocumentoCabPago.TrimEnd();
                objFacturaReporte.TOTAL = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                objFacturaReporte.TotalSinIGV = objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                objFacturaReporte.RazonSocial = objDocumentoCab.DocumentoCabCliente;
                objFacturaReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;
                objFacturaReporte.OrdenCompra = "";
                objFacturaReporte.Tipo = "la Boleta de Venta Electrónica";
                objFacturaReporte.TipoDocumento = "FACTURA ELECTRÓNICA";
                objFacturaReporte.GuiaRemision = objDocumentoCab.DocumentoCabGuia;
                objFacturaReporte.OrdenCompra = objDocumentoCab.DocumentoCabOrdenCompra;
                if (ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                {
                    objFacturaReporte.Simbolo = "$";
                }
                else
                {
                    objFacturaReporte.Simbolo = "S/";

                }
                objListFacturaReporte.Add(objFacturaReporte);
            }


        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
          
            try
            {
                btn_Reporte.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|03" + "|" +
   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                ReporteView Check = new ReporteView("LB"); // listar boleta
                Check.Show();
                btn_Reporte.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                btn_Reporte.Enabled = true;
            }
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {

            try
            {
                btn_pdf.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|03" + "|" +
   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();

                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                cr.SetDataSource(objListFacturaReporte);

                saveFileDialog1.FileName = ".pdf";
                saveFileDialog1.DefaultExt = "pdf";
                saveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @saveFileDialog1.FileName);
                }
                btn_pdf.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                btn_pdf.Enabled = true;
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|03" + "|" +
    objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
    + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();

                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                cr.SetDataSource(objListFacturaReporte);

                saveFileDialog1.FileName = ".xls";
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, @saveFileDialog1.FileName);
                }
                btn_excel.Enabled = true; 
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
                btn_excel.Enabled = true;
            }
        }

        private void saveFileDialog2_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btn_EnviarSunat_Click(object sender, EventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            objListDocumentoElectronicoDet = objDocumentoDao.getDocumentoElectronicoDet(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarText(objDocumentoElectronicoCab, objListDocumentoElectronicoDet);
            String mess = objProceso.sendTxt(rutatext);
            objDocumentoDao.updateEstadoEnviado(numeroSerie, numeroDocumento);
            String mensajeMostrar = "";
            String[] array = mess.Split('|');

            List<String> objListaString = array.ToList();
            if (objListaString.Count < 10)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
                btn_Anular.Enabled = false;
                btn_EnviarSunat.Enabled = false;
            }
            else
            {
                mensajeMostrar = objListaString[9];
                if (mensajeMostrar == "true")
                {
                    mensajeMostrar = "Documento Aceptado";
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    objDocumentoDao.updateEstadoAceptado(numeroSerie, numeroDocumento);
                    btn_Anular.Enabled = true;
                    btn_EnviarSunat.Enabled = false;
                }
                else
                {
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    btn_Anular.Enabled = false;
                    btn_EnviarSunat.Enabled = false;
                }
            }
            cargarLuegoAnulacion();
            MessageBox.Show(mensajeMostrar);
        }
        public void setMotivoAnulacion(String mot)
        {
            MotivoAnulacion = mot;
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarAnulacion(objDocumentoElectronicoCab, mot);
            String mess = objProceso.sendTxt(rutatext);
            String mensajeMostrar = "";
            String[] array = mess.Split('|');

            List<String> objListaString = array.ToList();
            if (objListaString.Count < 10)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
            }
            else
            {
                mensajeMostrar = "DOCUMENTO ANULADO";
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
            }
            MessageBox.Show(mensajeMostrar);
            cargarLuegoAnulacion();
        }
        private void btn_Anular_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
                numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;

                using (var form = new MotivoAnulacion("B"))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un documento");
            }
        }
        void cargarLuegoAnulacion()
        {
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            objListaDocumentoCab = objDocumentoDao.listarCabecera(d1, d2, txt_Ruc.Text, "01", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
        }
    }
}
