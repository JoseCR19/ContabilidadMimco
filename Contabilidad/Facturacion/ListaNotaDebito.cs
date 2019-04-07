using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Contabilidad
{
    public partial class ListaNotaDebito : Form
    {
        DocumentoDAO objDocumentoDao;
        public static ListaNotaDebito formListaDebito;
        public static DocumentoCab objDocumentoCab = new DocumentoCab();
        MonedaDAO objMoneda;
        public static List<DocumentoCab> objListaDocumentoCab = new List<DocumentoCab>();
        NotaReporteDTO objNotaReporte;
        public static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<NotaReporteDTO> objListNotaReporte = new List<NotaReporteDTO>();
        public static List<DocumentoElectronicoDet> objListDocumentoElectronicoDet = new List<DocumentoElectronicoDet>();
        public static DocumentoElectronicoCab objDocumentoElectronicoCab = new DocumentoElectronicoCab();
        Proceso objProceso = new Proceso();
        public static String MotivoAnulacion = "";
        public static String operacionFactura = "Q";
        public static String numeroDocumento = "";
        public static String numeroSerie = "";
        public ListaNotaDebito()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "NOTA DÉBITO";
            formListaDebito = this;
            objMoneda = new MonedaDAO();
            gridParams();
            objDocumentoDao = new DocumentoDAO();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            objListaDocumentoCab = objDocumentoDao.listarCabecera(d1, d2, txt_Ruc.Text, "08", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
        }
        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            lbl_Sunat.Visible = true;
            lbl_Sunat.Text = objDocumentoDao.getSunatObs(numeroSerie, numeroDocumento);
            objDocumentoCab = objListaDocumentoCab[index];
            switch (objDocumentoCab.EstadoSunat)
            {
                case 0:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = true;
                    btn_Consultar.Enabled = true;
                    break;
                case 1:
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = false;
                    break;
                case 2:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = true;
                    break;
                case 3:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = true;
                    btn_Consultar.Enabled = true;
                    btn_ConAnulacion.Enabled = false;
                    break;
            }
        }
        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_excel.Enabled = false;
            this.Hide();
            operacionFactura = "N";
            NotaDeDebito Check = new NotaDeDebito();
            Check.Show();
            btn_excel.Enabled = true;
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
            objListaDocumentoCab = objDocumentoDao.listarCabecera(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text, "08", Ventas.UNIDADNEGOCIO);
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
                numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
                objDocumentoCab = objListaDocumentoCab[index];
                this.Hide();

                NotaDeDebito Check = new NotaDeDebito();
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
            Ventas.formVentas.setEnabledItems("D");
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
            objListNotaReporte = new List<NotaReporteDTO>();
            objListDocumentoDet = objDocumentoDao.detalleReporte(objDocumentoCab.DocumentoCabSerie,
                  objDocumentoCab.DocumentoCabNro, Ventas.UNIDADNEGOCIO);
            if (objListDocumentoDet.Count > 0)
            {
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    objNotaReporte = new NotaReporteDTO();
                    objNotaReporte.Cantidad = objListDocumentoDet[i].DocumentoDetCantidad.ToString("C").Substring(3);
                    objNotaReporte.Direccion = objDocumentoCab.DocumentoCabClienteDireccion;
                    objNotaReporte.FechaEmision = objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                    objNotaReporte.SerieRef = objDocumentoCab.DocumentoCabSerieRef;
                    objNotaReporte.NumeroRef = objDocumentoCab.DocumentoCabNroRef;
                    objNotaReporte.FechaRef = objDocumentoCab.DocumentoCabFechaDocRef.ToShortDateString();
                    objNotaReporte.IGV = objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                    objNotaReporte.Letras = objDocumentoDao.numeroALetras(convertToDouble(objDocumentoCab.DocumentoCabTotal.ToString())) + " " + objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                    objNotaReporte.Moneda = objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                    objNotaReporte.Numero = objDocumentoCab.DocumentoCabNro.TrimEnd();
                    objNotaReporte.Serie = objDocumentoCab.DocumentoCabSerie;
                    objNotaReporte.Qr = qr;
                    objNotaReporte.Tipo = "la Nota de Débito Electrónica";
                    objNotaReporte.Descripcion = objDocumentoCab.DocumentoCabGlosa.TrimEnd();
                    objNotaReporte.TOTAL = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                    objNotaReporte.TotalSinIGV = objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                    objNotaReporte.UM = objListDocumentoDet[i].DocumentoProdUMcorta;
                    objNotaReporte.ValorUnitario = objListDocumentoDet[i].DocumentoDetPrecioSinIGV.ToString("C").Substring(3);
                    objNotaReporte.Importe = objListDocumentoDet[i].DocumentoDetSubTotal.ToString("C").Substring(3);
                    objNotaReporte.Descr = objListDocumentoDet[i].DocumentoDesProducto.TrimEnd() + " - " + objListDocumentoDet[i].DocumentoDetGlosa.TrimEnd();
                    objNotaReporte.RazonSocial = objDocumentoCab.DocumentoCabCliente;
                    objNotaReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;
                    objNotaReporte.Motivo = objDocumentoCab.DocumentoCabNotaDebito;
                    objNotaReporte.TipoDocumento = "NOTA DE DÉBITO";
                    objNotaReporte.TipoCambio = objMoneda.getTipoCambioVenta(objNotaReporte.FechaEmision).ToString().PadRight(5, '0');

                    if (objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                    {
                        objNotaReporte.Simbolo = "$";
                    }
                    else
                    {
                        objNotaReporte.Simbolo = "S/";

                    }
                    objListNotaReporte.Add(objNotaReporte);
                }
            }
            else
            {
                objNotaReporte = new NotaReporteDTO();

                objNotaReporte.Direccion = objDocumentoCab.DocumentoCabClienteDireccion;
                objNotaReporte.FechaEmision = objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                objNotaReporte.SerieRef = objDocumentoCab.DocumentoCabSerieRef;
                objNotaReporte.NumeroRef = objDocumentoCab.DocumentoCabNroRef;
                objNotaReporte.FechaRef = objDocumentoCab.DocumentoCabFechaDocRef.ToShortDateString();
                objNotaReporte.IGV = objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                objNotaReporte.Letras = objDocumentoDao.numeroALetras(convertToDouble(objDocumentoCab.DocumentoCabTotal.ToString())) + " " + objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                objNotaReporte.Moneda = objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                objNotaReporte.Numero = objDocumentoCab.DocumentoCabNro.TrimEnd();
                objNotaReporte.Serie = objDocumentoCab.DocumentoCabSerie;
                objNotaReporte.Descripcion = objDocumentoCab.DocumentoCabGlosa.TrimEnd();
                objNotaReporte.TOTAL = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                objNotaReporte.TotalSinIGV = objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                objNotaReporte.Motivo = objDocumentoCab.DocumentoCabNotaDebito;
                objNotaReporte.Tipo = "la Nota de Débito Electrónica";
                objNotaReporte.RazonSocial = objDocumentoCab.DocumentoCabCliente;
                objNotaReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;

                objNotaReporte.TipoDocumento = "NOTA DE CRÉDITO";
                if (objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                {
                    objNotaReporte.Simbolo = "$";
                }
                else
                {
                    objNotaReporte.Simbolo = "S/";

                }
                objListNotaReporte.Add(objNotaReporte);
            }


        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Reporte.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|08" + "|" +
   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                ReporteView Check = new ReporteView("LD"); // listar nota debito
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
                String codigoagenerar = "20300166611|08" + "|" +
    objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
    + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                NotaFecha cr = new NotaFecha();

                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                cr.SetDataSource(objListNotaReporte);

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
                String codigoagenerar = "20300166611|08" + "|" +
     objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
     + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                NotaFecha cr = new NotaFecha();

                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                cr.SetDataSource(objListNotaReporte);

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
                //objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
                btn_EnviarSunat.Enabled = true;
                btn_Anular.Enabled = false;
                btn_ConAnulacion.Enabled = false;
                btn_Consultar.Enabled = false;
            }
            else
            {
                mensajeMostrar = objListaString[9];
                if (mensajeMostrar == "true")
                {
                    mensajeMostrar = "DOCUMENTO ENVIADO";
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    // objDocumentoDao.updateEstadoAceptado(numeroSerie, numeroDocumento);
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = false;
                }
                else
                {
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = false;
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

                using (var form = new MotivoAnulacion("D"))
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
            objListaDocumentoCab = objDocumentoDao.listarCabecera(d1, d2, txt_Ruc.Text, "08", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string root = @"N:\PDF";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                btn_imprimir.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|01" + "|" +
   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();
                string rut = @"N:\PDF\20300166611-" + objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro + ".pdf";
                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                if (File.Exists(rut))
                {
                    File.Delete(rut);
                }
                cr.SetDataSource(objListNotaReporte);
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
                btn_imprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btn_imprimir.Enabled = true;
            }
        }

        private void btn_ConAnulacion_Click(object sender, EventArgs e)
        {

            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarConsultaAnulacion(objDocumentoElectronicoCab);
            String mess = objProceso.sendTxt(rutatext);
            String mensajeMostrar = "";
            String[] array = mess.Split('|');
            List<String> objListaString = array.ToList();//9
            if (objListaString.Count < 8)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
            }
            else
            {
                mensajeMostrar = objListaString[9];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarConsulta(objDocumentoElectronicoCab);
            String mess = objProceso.sendTxt(rutatext);
            String mensajeMostrar = "";
            String[] array = mess.Split('|');
            List<String> objListaString = array.ToList();//11-1
            if (objListaString.Count < 10)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
            }
            else
            {
                mensajeMostrar = objListaString[11];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                objDocumentoDao.updateEstadoAceptado(numeroSerie, numeroDocumento);
            }
        }
    }
}
