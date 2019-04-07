using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Contabilidad
{
    public partial class ListaLetraCambio : Form
    {
        DocumentoDAO objDocumentoDao;
        public static List<DocumentoCab> objListaDocumentoCab = new List<DocumentoCab>();
        public static DocumentoCab objDocumentoCab;
        // public static List<FacturaReporteDTO> objListFacturaReporte = new List<FacturaReporteDTO>();
        public static List<LetraReporte> objListaLetraReporte = new List<LetraReporte>();
        public static LetraReporte objLetraReporte;
        public static String operacionLetra = "Q";
        MonedaDAO objMonedaDao;
        public ListaLetraCambio()
        {
            InitializeComponent();
            objDocumentoDao = new DocumentoDAO();
            this.ControlBox = false;
            this.Text = "LETRAS DE CANJE";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(2018, 10, 1);
            objListaDocumentoCab = objDocumentoDao.listarLetraCab(d1, d2, txt_Ruc.Text, Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;


            objDocumentoCab = objListaDocumentoCab[index];
            if (objDocumentoCab.EstadoSunat ==0)
            {
                lbl_Sunat.Visible = true;
                lbl_Sunat.Text = "ANULADO";
            }else
            {
                lbl_Sunat.Text = "";
                lbl_Sunat.Visible = false;
            }
        }

        private void formatearLetra()
        {
            objLetraReporte = new LetraReporte();
            objLetraReporte.Aceptante = objDocumentoCab.DocumentoCabCliente;
            objLetraReporte.AvalDomicilio = objDocumentoCab.DocumentoCabClienteDireccionAval;
            objLetraReporte.AvalLocalidad = "";
            objLetraReporte.AvalPermanente = objDocumentoCab.DocumentoCabClienteAval;
            objLetraReporte.AvalRUC = objDocumentoCab.DocumentoCabClienteRucAval;
            objLetraReporte.AvalTelefono = objDocumentoCab.DocumentoCabClienteTelefonoAval;
            objLetraReporte.Banco = "";
            objLetraReporte.DC = "";
            objLetraReporte.AvalFirma = "";
            objLetraReporte.DOIRepresentante = "";
            objLetraReporte.Domicilio = objDocumentoCab.DocumentoCabClienteDireccion;
            objLetraReporte.FechaGiro = objDocumentoCab.DocumentoCabFecha.ToString("dd/MM/yyyy");
            objLetraReporte.FechaVencimiento = objDocumentoCab.DocumentoCabFechaVcto.ToString("dd/MM/yyyy");
            objLetraReporte.Importe = Math.Round(objDocumentoCab.DocumentoCabAbono,2).ToString("C").Substring(3);
            objLetraReporte.ImporteLetras = objDocumentoDao.numeroALetras(Math.Round(objDocumentoCab.DocumentoCabAbono, 2)) + " " + objDocumentoCab.DocumentoCabMoneda;
            objLetraReporte.Localidad = "";
            objLetraReporte.LugarGiro = "LIMA";
            if (objDocumentoCab.DocumentoCabMoneda == "SOLES")
            {
                objLetraReporte.Moneda = "S/";
            }
            else
            {
                objLetraReporte.Moneda = "$";
            }

            objLetraReporte.NombreRepresentante = "";
            objLetraReporte.Numero = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
            objLetraReporte.NumeroCuenta = "";
            objLetraReporte.Oficina = "";
            objLetraReporte.ReferenciaGirador = objDocumentoDao.referenciaGIrador(objDocumentoCab.DocumentoCabSerie, objDocumentoCab.DocumentoCabNro);
            objLetraReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;
            objLetraReporte.Telefono = objDocumentoCab.DocumentoCabClienteTelefono;
            objListaLetraReporte.Add(objLetraReporte);


        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {

        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Fecha";
            idColumn10.DataPropertyName = "DocumentoCabFecha";
            idColumn10.Width = 75;
            grd_Facturas.Columns.Add(idColumn10);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.Width = 65;
            idColumn1.DataPropertyName = "DocumentoCabSerie";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Número";
            idColumn2.DataPropertyName = "DocumentoCabNro";
            idColumn2.Width = 75;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razón Social";
            idColumn3.DataPropertyName = "DocumentoCabCliente";
            idColumn3.Width = 300;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "RUC";
            idColumn4.DataPropertyName = "DocumentoCabClienteDocumento";
            idColumn4.Width = 90;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Total";
            idColumn6.DataPropertyName = "DocumentoCabTotal";
            idColumn6.Width = 85;
            grd_Facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Canjeado";
            idColumn7.DataPropertyName = "DocumentoCabAbono";
            idColumn7.Width = 85;
            grd_Facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Detracción";
            idColumn8.DataPropertyName = "DocumentoCabDetraccion";
            idColumn8.Width = 90;
            grd_Facturas.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Estado";
            idColumn9.DataPropertyName = "EstadoS";
            idColumn9.Width = 100;
            grd_Facturas.Columns.Add(idColumn9);   

        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_Nuevo.Enabled = false;
            this.Hide();
            operacionLetra = "N";
            LetraCambio Check = new LetraCambio();
            Check.Show();
            btn_Nuevo.Enabled = true;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("LT");
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            operacionLetra = "V";
            try
            {
                int index = grd_Facturas.SelectedCells[0].RowIndex;


                objDocumentoCab = objListaDocumentoCab[index];
                this.Hide();

                LetraCambio Check = new LetraCambio();
                Check.Show();

            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Reporte.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                formatearLetra();
                ReporteView Check = new ReporteView("LL"); // listar letra
                Check.Show();
                btn_Reporte.Enabled = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_Reporte.Enabled = true;
            }
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string root = @"N:\EXCEL";
            String fileName = @"N:\EXCEL\";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                btn_imprimir.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];

                formatearLetra();
                fileName = fileName + objDocumentoCab.DocumentoCabSerie.Substring(0, 1) + "-" + objDocumentoCab.DocumentoCabNro + ".xls";
                Letras cr = new Letras();


                cr.SetDataSource(objListaLetraReporte);

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

                PrintMyExcelFile(fileName);
                btn_imprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btn_imprimir.Enabled = true;
            }

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

        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                // String fileName = @"C:\FACTURACION\EXCEL\";
                //String path = @"C:\FACTURACION\EXCEL";
                String fileName = @"N:\EXCEL\";
                String path = @"N:\EXCEL";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                formatearLetra();
                Random rnd = new Random();
                int randomnum = rnd.Next(1000);
               

                fileName = fileName + objDocumentoCab.DocumentoCabSerie.Substring(0, 1) + " - " + objDocumentoCab.DocumentoCabNro +"-"+ randomnum+ ".xls";
                Letras cr = new Letras();


                cr.SetDataSource(objListaLetraReporte);

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
                }

                btn_excel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_excel.Enabled = true;
            }
        }
        void PrintMyExcelFile(string ruta)
        {
            
           Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

            // Open the Workbook:
            Microsoft.Office.Interop.Excel.Workbook wb = excelApp.Workbooks.Open(
                ruta,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            // Get the first worksheet.
            // (Excel uses base 1 indexing, not base 0.)
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];

            // Print out 1 copy to the default printer:
            ws.PrintOut(
              Type.Missing, Type.Missing, Type.Missing, Type.Missing,
             Type.Missing, Type.Missing, Type.Missing, Type.Missing);
  

            // Cleanup:
            GC.Collect();
            GC.WaitForPendingFinalizers();

            Marshal.FinalReleaseComObject(ws);

            wb.Close(false, Type.Missing, Type.Missing);
            Marshal.FinalReleaseComObject(wb);

            excelApp.Quit();
            Marshal.FinalReleaseComObject(excelApp);
        }
        private void btn_Anular_Click(object sender, EventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;
            objDocumentoCab = new DocumentoCab();
            objDocumentoCab = objListaDocumentoCab[index];
            bool anular = objDocumentoDao.anularLetra(objDocumentoCab.DocumentoCabSerie, objDocumentoCab.DocumentoCabNro);
            if (anular)
            {
                MessageBox.Show("Se anuló la Letra");
            } else
            {
                MessageBox.Show("Hubo un error al anular la letra");
            }
        }

        private void ListaLetraCambio_Load(object sender, EventArgs e)
        {

        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {

        }
    }
}
