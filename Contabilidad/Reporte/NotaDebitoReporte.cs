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
    public partial class NotaDebitoReporte : Form
    {
        NotaReporteDTO objNotaReporte;
        MonedaDAO objMoneda;
        DocumentoDAO objDocumentoDao;
        Proceso objProceso;
        public static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<NotaReporteDTO> objListNotaReporte = new List<NotaReporteDTO>();
        static String tipoDocumento, tipoReporte;
        public NotaDebitoReporte(String tipoDocu, String tipoReport)
        {
            InitializeComponent();
            objMoneda = new MonedaDAO();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 0);
            tipoDocumento = tipoDocu;
            tipoReporte = tipoReport;
            objProceso = new Proceso();
            objDocumentoDao = new DocumentoDAO();
            this.ControlBox = false;
            this.Text = "REPORTE NOTA DE DÉBITO";
            gridParams();

            if (tipoReporte == "F")
            {
                txt_Tipodocu.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabDoc;
                txt_SerieBuscar.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabSerieRef;
                txt_NumeroBuscar.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabNroRef;
                txt_Numero.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabNro;
                txt_Serie.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabSerie;
                txt_Cliente.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabCliente;
                txt_Direccion.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_GlosaCab.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabGlosa;
                txt_Ruc.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Moneda.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabMoneda;
                txt_Motivo.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabNotaDebito;
                txt_IGV.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                txt_TotalsinPercep.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                txt_ValorVenta.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                lblTotal.Text = objDocumentoDao.numeroALetras(convertToDouble(ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTotal.ToString())) + " " + txt_Moneda.Text;
                dpick_Fecha.Value = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechadcto.Value = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFechaDocRef;
                if (ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoMoneda == "USB")
                {
                    lbl_Moneda.Text = "$";
                }
                objListDocumentoDet = objDocumentoDao.detalleReporte(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
            }
            else if (tipoReporte == "C")
            {
                txt_Tipodocu.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabDoc;
                txt_SerieBuscar.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabSerieRef;
                txt_NumeroBuscar.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabNroRef;
                txt_Numero.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabNro;
                txt_Serie.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabSerie;
                txt_Cliente.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabCliente;
                txt_Direccion.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_GlosaCab.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabGlosa;
                txt_Ruc.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Moneda.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabMoneda;
                txt_Motivo.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabNotaDebito;
                txt_IGV.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                txt_TotalsinPercep.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                txt_ValorVenta.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                lblTotal.Text = objDocumentoDao.numeroALetras(convertToDouble(ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTotal.ToString())) + " " + txt_Moneda.Text;
                dpick_Fecha.Value = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechadcto.Value = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFechaDocRef;
                if (ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTipoMoneda == "USB")
                {
                    lbl_Moneda.Text = "$";
                }
                objListDocumentoDet = objDocumentoDao.detalleReporte(txt_Serie.Text, txt_Numero.Text, Ventas.UNIDADNEGOCIO);
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
            }
        }
        public void gridParams()
        {
            grd_Detalle.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "ITEM";
            idColumn1.DataPropertyName = "DocumentoDetId";
            idColumn1.Width = 47;
            grd_Detalle.Columns.Add(idColumn1);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "CANTIDAD";
            idColumn3.DataPropertyName = "DocumentoDetCantidad";
            idColumn3.Width = 110;
            grd_Detalle.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "DESCRIPCION";
            idColumn4.DataPropertyName = "DocumentoDesProducto";
            idColumn4.Width = 355;
            grd_Detalle.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "PRECIO UNIT.";
            idColumn5.DataPropertyName = "DocumentoDetPrecioSinIGV";
            idColumn5.Width = 130;
            grd_Detalle.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "SUB TOTAL";
            idColumn6.DataPropertyName = "DocumentoDetSubTotal";
            idColumn6.Width = 140;
            grd_Detalle.Columns.Add(idColumn6);
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
            if (tipoReporte == "F")
            {
                ReporteDocumentosPorFecha Check = new ReporteDocumentosPorFecha();
                Check.Show();
            }
            else if (tipoReporte == "C")
            {
                ReporteDocumentosPorCliente Check = new ReporteDocumentosPorCliente();
                Check.Show();
            }


        }
        private void formatearFactura(String qr)
        {
            objListNotaReporte = new List<NotaReporteDTO>();
            if (objListDocumentoDet.Count > 0)
            {
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    objNotaReporte = new NotaReporteDTO();
                    objNotaReporte.Cantidad = objListDocumentoDet[i].DocumentoDetCantidad.ToString("C").Substring(3);
                    objNotaReporte.Direccion = txt_Direccion.Text;
                    objNotaReporte.FechaEmision = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                    objNotaReporte.SerieRef = txt_SerieBuscar.Text;
                    objNotaReporte.NumeroRef = txt_NumeroBuscar.Text;
                    objNotaReporte.FechaRef = dpck_Fechadcto.Value.ToShortDateString();
                    objNotaReporte.IGV = txt_IGV.Text;
                    objNotaReporte.Letras = lblTotal.Text.TrimEnd();
                    objNotaReporte.Moneda = txt_Moneda.Text.TrimEnd();
                    objNotaReporte.Numero = txt_Numero.Text.TrimEnd();
                    objNotaReporte.Serie = txt_Serie.Text;
                    objNotaReporte.Motivo = txt_Motivo.Text;
                    objNotaReporte.TOTAL = txt_TotalsinPercep.Text;
                    objNotaReporte.TotalSinIGV = txt_ValorVenta.Text;
                    objNotaReporte.UM = objListDocumentoDet[i].DocumentoProdUMcorta;
                    objNotaReporte.ValorUnitario = objListDocumentoDet[i].DocumentoDetPrecioSinIGV.ToString("C").Substring(3);
                    objNotaReporte.Importe = objListDocumentoDet[i].DocumentoDetSubTotal.ToString("C").Substring(3);
                    objNotaReporte.Descr = objListDocumentoDet[i].DocumentoDetGlosa.TrimEnd();
                    objNotaReporte.RazonSocial = txt_Cliente.Text;
                    objNotaReporte.RUC = txt_Ruc.Text;
                    objNotaReporte.Tipo = "la Nota de Débito Electrónica";
                    objNotaReporte.Qr = qr;
                    objNotaReporte.Descripcion = txt_GlosaCab.Text;
                    objNotaReporte.TipoDocumento = tipoDocumento;
                    objNotaReporte.TipoCambio = objMoneda.getTipoCambioVenta(objNotaReporte.FechaEmision).ToString().PadRight(5, '0');

                    if (ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
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

                objNotaReporte.Direccion = txt_Direccion.Text;
                objNotaReporte.FechaEmision = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                objNotaReporte.IGV = txt_IGV.Text;
                objNotaReporte.Letras = lblTotal.Text.TrimEnd();
                objNotaReporte.Moneda = txt_Moneda.Text.TrimEnd();
                objNotaReporte.Numero = txt_Numero.Text.TrimEnd();
                objNotaReporte.Serie = txt_Serie.Text;
                objNotaReporte.TOTAL = txt_TotalsinPercep.Text;
                objNotaReporte.TotalSinIGV = txt_ValorVenta.Text;
                objNotaReporte.RazonSocial = txt_Cliente.Text;
                objNotaReporte.RUC = txt_Ruc.Text;
                objNotaReporte.Descripcion = txt_GlosaCab.Text;
                objNotaReporte.SerieRef = txt_SerieBuscar.Text;
                objNotaReporte.NumeroRef = txt_NumeroBuscar.Text;
                objNotaReporte.FechaRef = dpck_Fechadcto.Value.ToShortDateString();
                objNotaReporte.Motivo = txt_Motivo.Text;
                objNotaReporte.Tipo = "la Nota de Débito Electrónica";
                objNotaReporte.Qr = qr;
                objNotaReporte.TipoDocumento = tipoDocumento;
                if (ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
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

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            String codigoagenerar = "20300166611|08" + "|" +
             txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
             + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
            String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
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
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            btn_Reporte.Enabled = false;
            String codigoagenerar = "20300166611|08" + "|" +
             txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
             + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
            String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
            String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);

            formatearFactura(qr);
            ReporteView Check = new ReporteView("DF"); // ND fecha
            Check.Show();
            btn_Reporte.Enabled = true;
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



                String codigoagenerar = "20300166611|01" + "|" +
    txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
   + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
                String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();
                string rut = @"N:\PDF\20300166611-" + txt_Serie.Text + "-" + txt_Numero.Text + ".pdf";
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

        private void btn_excel_Click(object sender, EventArgs e)
        {
            String codigoagenerar = "20300166611|08" + "|" +
             txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
             + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
            String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
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
        }
    }
}
