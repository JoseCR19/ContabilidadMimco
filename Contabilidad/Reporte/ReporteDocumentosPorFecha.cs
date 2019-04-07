using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using Microsoft.Office.Interop.Excel;
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

namespace Contabilidad
{
    public partial class ReporteDocumentosPorFecha : Form
    {
        public static DocumentoCab objDocumentoCab = new DocumentoCab();

        DocumentoContabilidadDAO objDocContaDao;
        DocumentoDAO objDocumentoDao;
        MonedaDAO objMoneda;
        DocumentoReporte objReporte;
        DocumentoReporteExcel objReporteExcel;
        public static List<DocumentoCab> objListaDocCab = new List<DocumentoCab>();
        public static List<DocumentoReporte> objListaDocReporte = new List<DocumentoReporte>();
        public static List<DocumentoReporteExcel> objListaReporteExcel = new List<DocumentoReporteExcel>();

        public ReporteDocumentosPorFecha()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "REPORTE DOCUMENTOS POR FECHA";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(20, 20);
            objDocContaDao = new DocumentoContabilidadDAO();
            objDocumentoDao = new DocumentoDAO();
            objMoneda = new MonedaDAO();
            comboContabilidad();
            comboMoneda();
            gridParams();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                objListaDocCab = objDocumentoDao.documentoPorFechaM(cmb_TipoDocumento.SelectedValue.ToString(),
                dpickerInicio.Value, dpickerFin.Value, cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO);
            }else
            {
                objListaDocCab = objDocumentoDao.documentoPorFechaG(cmb_TipoDocumento.SelectedValue.ToString(),
                dpickerInicio.Value, dpickerFin.Value, cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO);

            }
            grd_Documentos.DataSource = objListaDocCab;
            grd_Documentos.Refresh();
            llenarSumatorias();
        }
        public void comboMoneda()
        {
            cmb_Moneda.DataSource = objMoneda.listarTipoMonedaReporte();
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }
        public void comboContabilidad()
        {
            cmb_TipoDocumento.DataSource = objDocContaDao.listarDocumentoContabilidad();
            cmb_TipoDocumento.ValueMember = "DocContabilidadCod";
            cmb_TipoDocumento.DisplayMember = "DocContabilidadDescripcion";
            cmb_TipoDocumento.Refresh();
        }
        public void gridParams()
        {
            grd_Documentos.AutoGenerateColumns = false;
           
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Documento";
            idColumn0.Width = 80;
            idColumn0.DataPropertyName = "DocumentoCabDoc";
            grd_Documentos.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N°Documento";
            idColumn2.DataPropertyName = "NumeroDocumento";
            idColumn2.Width = 120;
            grd_Documentos.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Nro Ot";
            idColumn8.DataPropertyName = "DocumentoCabOtCod";
            idColumn8.Width = 80;
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grd_Documentos.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razón Social";
            idColumn3.DataPropertyName = "DocumentoCabCliente";
            idColumn3.Width = 250;
            grd_Documentos.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumnF = new DataGridViewTextBoxColumn();
            idColumnF.Name = "Fecha";
            idColumnF.Width = 80;
            idColumnF.DataPropertyName = "DocumentoCabFecha";
            grd_Documentos.Columns.Add(idColumnF);
            DataGridViewTextBoxColumn idColumnCambio = new DataGridViewTextBoxColumn();
            idColumnCambio.Name = "T.Cambio";
            idColumnCambio.DataPropertyName = "TipoCambio";
            idColumnCambio.Width = 50;
            grd_Documentos.Columns.Add(idColumnCambio);
            DataGridViewTextBoxColumn idColumnPeso = new DataGridViewTextBoxColumn();
            idColumnPeso.Name = "Peso";
            idColumnPeso.DataPropertyName = "Peso";
            idColumnPeso.Width = 70;
            grd_Documentos.Columns.Add(idColumnPeso);
            DataGridViewTextBoxColumn idColumnPrecio = new DataGridViewTextBoxColumn();
            idColumnPrecio.Name = "Precio";
            idColumnPrecio.DataPropertyName = "Precio";
            idColumnPrecio.Width = 70;
            grd_Documentos.Columns.Add(idColumnPrecio);

            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "SubTotal";
            idColumn7.DataPropertyName = "DocumentoCabTotalSinIGV";
            idColumn7.Width = 70;
            idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumnIgv = new DataGridViewTextBoxColumn();
            idColumnIgv.Name = "IGV";
            idColumnIgv.DataPropertyName = "DocumentoCabIGV";
            idColumnIgv.Width = 70;
            idColumnIgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumnIgv);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Total";
            idColumn6.DataPropertyName = "DocumentoCabTotal";
            idColumn6.Width = 70;
            idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn6);
          
            DataGridViewTextBoxColumn idColumnV = new DataGridViewTextBoxColumn();
            idColumnV.Name = "F. Vcto";
            idColumnV.Width = 80;
            idColumnV.DataPropertyName = "DocumentoCabFechaVcto";
            grd_Documentos.Columns.Add(idColumnV);
            DataGridViewTextBoxColumn idColumnP = new DataGridViewTextBoxColumn();
            idColumnP.Name = "Pago";
            idColumnP.Width = 110;
            idColumnP.DataPropertyName = "DocumentoCabPago";
            grd_Documentos.Columns.Add(idColumnP);
            DataGridViewTextBoxColumn idColumnO = new DataGridViewTextBoxColumn();
            idColumnO.Name = "Ord Compra";
            idColumnO.Width = 80;
            idColumnO.DataPropertyName = "DocumentoCabOrdenCompra";
            grd_Documentos.Columns.Add(idColumnO);
           
           
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "RUC";
            idColumn4.DataPropertyName = "DocumentoCabClienteDocumento";
            idColumn4.Width = 80;
            grd_Documentos.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "DocumentoCabMoneda";
            idColumn5.Width = 80;
            grd_Documentos.Columns.Add(idColumn5);
          
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Estado";
            idColumn9.DataPropertyName = "EstadoS";
            idColumn9.Width = 140;
            idColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn9);

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RF");
        }

        public void llenarSumatorias()
        {
            txt_Total.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("PEN")).Sum(x => x.DocumentoCabTotal).ToString();
            txt_SubTotalS.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("PEN")).Sum(x => x.DocumentoCabTotalSinIGV).ToString();
            txt_IGVS.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("PEN")).Sum(x => x.DocumentoCabIGV).ToString();

            txt_IGVD.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("USD")).Sum(x => x.DocumentoCabIGV).ToString();
            txt_SubTotalD.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("USD")).Sum(x => x.DocumentoCabTotalSinIGV).ToString();
            txt_Dolares.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("USD")).Sum(x => x.DocumentoCabTotal).ToString();


        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                objListaDocCab = objDocumentoDao.documentoPorFechaM(cmb_TipoDocumento.SelectedValue.ToString(),
                dpickerInicio.Value, dpickerFin.Value, cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO);
            }else
            {
                objListaDocCab = objDocumentoDao.documentoPorFechaG(cmb_TipoDocumento.SelectedValue.ToString(),
                dpickerInicio.Value, dpickerFin.Value, cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO);

            }


            grd_Documentos.DataSource = objListaDocCab;
            grd_Documentos.Refresh();
            llenarSumatorias();
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grd_Documentos.SelectedCells[0].RowIndex;


                objDocumentoCab = objListaDocCab[index];
               //this.Hide();
                switch (objDocumentoCab.DocumentoCabTipoDoc)
                {
                    case "01":
                        FacturaReporte Check = new FacturaReporte("FACTURA ELECTRÓNICA", "F");
                        Check.ShowDialog();
                        break;
                    case "03":
                        BoletaReporte Check2 = new BoletaReporte("BOLETA ELECTRÓNICA", "F");
                        Check2.Show();
                        break;
                    case "07":
                        NotaCreditoReporte Check3 = new NotaCreditoReporte("NOTA DE CRÉDITO", "F");
                        Check3.ShowDialog();
                        break;
                    case "08":
                        NotaDebitoReporte Check4 = new NotaDebitoReporte("NOTA DE DÉBITO", "F");
                        Check4.ShowDialog();
                        break;
                    case "LT":
                        Reporte.LetraReporte Check5 = new Reporte.LetraReporte("F");
                        Check5.ShowDialog();
                        break;
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }
        void formatearDocumento()
        {
            objListaDocReporte = new List<DocumentoReporte>();
            for (int i = 0; i < objListaDocCab.Count; i++)
            {
                objReporte = new DocumentoReporte();
                objReporte.Documento = objListaDocCab[i].DocumentoCabDoc;
                objReporte.Fecha = objListaDocCab[i].DocumentoCabFecha.ToString("dd/MM/yyyy");
                objReporte.FechaVcto = objListaDocCab[i].DocumentoCabFechaVcto.ToString("dd/MM/yyyy");
                objReporte.FormaPago = objListaDocCab[i].DocumentoCabPago;
                objReporte.Moneda = objListaDocCab[i].DocumentoCabMoneda;
                objReporte.Numero = objListaDocCab[i].DocumentoCabNro;
                objReporte.OrdenCompra = objListaDocCab[i].DocumentoCabOrdenCompra;
                if (String.IsNullOrEmpty(objReporte.OrdenCompra))
                {
                    objReporte.OrdenCompra = "-";
                }
                objReporte.RazonSocial = objListaDocCab[i].DocumentoCabCliente;
                objReporte.RUC = objListaDocCab[i].DocumentoCabClienteDocumento;
                objReporte.Serie = objListaDocCab[i].DocumentoCabSerie;
                objReporte.Total = objListaDocCab[i].DocumentoCabTotal.ToString("C").Substring(3);
                objListaDocReporte.Add(objReporte);
            }


        }


        public void ExportToExcelWithFormat_Simple(DataGridView dataGridView_show)
        {
            int rownum = 1;
            copyAlltoClipboard(dataGridView_show);
            Microsoft.Office.Interop.Excel.Application xlexcel;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlexcel = new Microsoft.Office.Interop.Excel.Application();
            xlexcel.Visible = true;
            xlWorkBook = xlexcel.Workbooks.Add(misValue);
            xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int colCount = 0; colCount < dataGridView_show.Columns.Count; colCount++)
            {
                Microsoft.Office.Interop.Excel.Range xlRange = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[rownum, colCount + 2];
                xlRange.Value2 = dataGridView_show.Columns[colCount].Name;
                xlRange.Font.Bold = -1;
                xlRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                xlRange.ColumnWidth = 20;
                xlRange.Borders.LineStyle =Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (colCount == 5 || colCount == 6 || colCount == 7 || colCount == 8 || colCount ==9 || colCount == 10)
                {
                    xlRange.EntireColumn.NumberFormat = "#,###.00";
                }
                else if (colCount == 4 || colCount == 11)
                {
                    xlRange.EntireColumn.NumberFormat = "DD/MM/YYYY";
                }
                else
                {
                    xlRange.EntireColumn.NumberFormat = "@";
                }
            }

            Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[2, 1];
            CR.Select();
            xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            Microsoft.Office.Interop.Excel.Range rng = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.get_Range("B1", "E" + (dataGridView_show.Rows.Count + 1).ToString());
           // rng.Columns.ColumnWidth = 20; // You can define the columnwith by yoursetf or 
           // rng.Columns.AutoFit(); // Use Autofit.
          //  rng.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlDouble;
            rng.Borders.Weight = 1d;
        }
        private void copyAlltoClipboard(DataGridView dataview)
        {
            dataview.SelectAll();
            DataObject dataObj = dataview.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

        }


        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                // String fileName = @"C:\FACTURACION\EXCEL\";
                //String path = @"C:\FACTURACION\EXCEL";
                /*  String fileName = @"C:\REPORTE\";
                  String path = @"C:\REPORTE";
                  if (!Directory.Exists(path))
                  {
                      Directory.CreateDirectory(path);
                  }



                  formatearDocumento();
                  String unidN = "";
                  if (Ventas.UNIDADNEGOCIO == "01")
                      unidN = "METALES";
                  else
                      unidN = "GALVANIZADO";

                  Random rnd = new Random();
                  int randomnum = rnd.Next(1000);
                  fileName = fileName + unidN + "ReporteXFecha-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + randomnum + ".xls";
                  Report.DocumentosFecha cr = new Report.DocumentosFecha();


                  cr.SetDataSource(objListaDocReporte);

                  ExportOptions exportOpts = new ExportOptions();
                  ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
                  DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                  exportOpts = cr.ExportOptions;

                  // Set the excel format options.
                  excelFormatOpts.ExcelUseConstantColumnWidth = true;
                  excelFormatOpts.ExcelTabHasColumnHeadings = true;
                  excelFormatOpts.ShowGridLines = true;
                  exportOpts.ExportFormatType = ExportFormatType.Excel;
                  exportOpts.FormatOptions = excelFormatOpts;

                  // Set the disk file options and export.
                  exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                  diskOpts.DiskFileName = fileName;
                  exportOpts.DestinationOptions = diskOpts;

                  cr.Export();
                  FileInfo fi = new FileInfo(fileName);
                  if (fi.Exists)
                  {
                      System.Diagnostics.Process.Start(fileName);
                  }
                  else
                  {
                      //file doesn't exist
                  }*/
                ExportToExcelWithFormat_Simple(grd_Documentos);
                btn_excel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_excel.Enabled = true;
            }
        }
        void formatearReporte()
        {
            for (int i = 0; i< objListaDocCab.Count; i++ ) {
                objReporteExcel = new DocumentoReporteExcel();
                if (objListaDocCab[i].EstadoS.Contains("SUNAT"))
                {
                    objReporteExcel.Estado = objListaDocCab[i].EstadoS.Substring(0, 8);
                }else
                {
                    objReporteExcel.Estado = objListaDocCab[i].EstadoS;
                }
                
                objReporteExcel.Fecha = objListaDocCab[i].DocumentoCabFecha.ToString("dd/MM/yyyy");
                objReporteExcel.FechaVcto = objListaDocCab[i].DocumentoCabFechaVcto.ToString("dd/MM/yyyy");
                objReporteExcel.IGV = objListaDocCab[i].DocumentoCabIGV.ToString("C").Substring(3);
               
                if(objListaDocCab[i].DocumentoCabTipoMoneda =="USD")
                {
                    objReporteExcel.Moneda = objListaDocCab[i].DocumentoCabMoneda.Substring(0, 7);
                }else
                {
                    objReporteExcel.Moneda = objListaDocCab[i].DocumentoCabMoneda;
                }
                objReporteExcel.Peso = objListaDocCab[i].Peso.ToString("C").Substring(3);
                objReporteExcel.NroOt = objListaDocCab[i].DocumentoCabOtCod;
                objReporteExcel.Numero = objListaDocCab[i].DocumentoCabNro;
                objReporteExcel.OrdenCompra = objListaDocCab[i].DocumentoCabOrdenCompra;
                objReporteExcel.Pago = objListaDocCab[i].DocumentoCabPago;
                objReporteExcel.RazonSocial = objListaDocCab[i].DocumentoCabCliente;
                objReporteExcel.RUC = objListaDocCab[i].DocumentoCabClienteDocumento;
                objReporteExcel.Serie = objListaDocCab[i].DocumentoCabSerie;
                objReporteExcel.Rango = dpickerInicio.Value.ToString("dd/MM/yyyy") + " a " + dpickerFin.Value.ToString("dd/MM/yyyy");
                objReporteExcel.Precio = objListaDocCab[i].Precio.ToString("C").Substring(3);
                objReporteExcel.Subtotal = objListaDocCab[i].DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                objReporteExcel.Total = objListaDocCab[i].DocumentoCabTotal.ToString("C").Substring(3);
                objReporteExcel.TipoCambio = objListaDocCab[i].TipoCambio.ToString("C").Substring(3);
                objReporteExcel.TotalSoles = txt_Total.Text;
                objReporteExcel.TotalDolares = txt_Dolares.Text;
                objReporteExcel.SubtotalSoles = txt_SubTotalS.Text;
                objReporteExcel.IGVSoles = txt_IGVS.Text;
                objReporteExcel.IGVDolares = txt_IGVD.Text;
                objReporteExcel.SubtotalDolares = txt_SubTotalD.Text;
                objListaReporteExcel.Add(objReporteExcel);
            }
        }
        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            btn_Reporte.Enabled = false;
            formatearReporte();
            ReporteView Check = new ReporteView("EF"); // ExcelFecha
            Check.Show();
            btn_Reporte.Enabled = true;

        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            btn_pdf.Enabled = false;
            DocumentoExcel cr = new DocumentoExcel();
            formatearReporte();
            // System.Web.HttpResponse res = new System.Web.HttpResponse();
            cr.SetDataSource(objListaReporteExcel);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "20300166611-01-ReportePorFecha" + dpickerInicio.Value.ToString("ddMMyyyy")+ "-"
                +dpickerFin.Value.ToString("ddMMyyyy") +
            ".pdf";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @saveFileDialog1.FileName);
            }

            btn_pdf.Enabled = true;
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int randomnum = rnd.Next(1000);
            string root = @"N:\PDF";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                btn_imprimir.Enabled = false;
               


                formatearReporte();
                DocumentoExcel cr = new DocumentoExcel();
                string rut = @"N:\PDF\20300166611-01-ReportePorFecha" + dpickerInicio.Value.ToString("ddMMyyyy") + "-"
                + dpickerFin.Value.ToString("ddMMyyyy")+"-"+ randomnum + ".pdf";
                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                if (File.Exists(rut))
                {
                    File.Delete(rut);
                }
                cr.SetDataSource(objListaReporteExcel);
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

        private void ReporteDocumentosPorFecha_Load(object sender, EventArgs e)
        {

        }
    }
}
