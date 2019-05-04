using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using System;
using Spire.Xls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Caja
{
    public partial class ListaEmisionVoucher : Form
    {
        public static List<Voucher> objListVoucher = new List<Voucher>();
        public List<VoucherDet> objListaVoucherDet = new List<VoucherDet>();
        ChequeImpresion objCheque = new ChequeImpresion();
        List<ChequeImpresion> objListCheque = new List<ChequeImpresion>();
        List<EstadoVoucher> objLista = new List<EstadoVoucher>();
        public static Voucher objVoucher = new Voucher();
        public static List<VoucherReporte> objListaVoucherReporte = new List<VoucherReporte>();
        public static List<Voucher> objListBusquedaTotal = new List<Voucher>();
        public static List<EnvioMasivoContinental> objListEnvioMasivoContinentalDet = new List<EnvioMasivoContinental>();
        public static EnvioMasivoContinentalCab objEnvioMasivoContinentalCab = new EnvioMasivoContinentalCab();
        VoucherDAO objVoucherDao;
        string rutaCompleta = @"N:\TXT\20300166611-";
        PagoVoucherDAO objPagoVoucherDao;
        DocumentoDAO objDocumentoDAO;
        EstadoVoucher objEstado;
        MonedaDAO objMonedaDao;
        public static String numeroVoucher = "";
        public static String operacionVoucher = "Q";
        int index = 0;
        public ListaEmisionVoucher()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "LISTA CAJA BANCO";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objMonedaDao = new MonedaDAO();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            gridParams();
            objEstado = new EstadoVoucher();
            //objVoucher = new Voucher();
            objVoucherDao = new VoucherDAO();
            objPagoVoucherDao = new PagoVoucherDAO();
            objDocumentoDAO = new DocumentoDAO();
            objListVoucher = objVoucherDao.listarVoucher(Ventas.UNIDADNEGOCIO,dpickerInicio.Value, dpickerFin.Value,"NN");
            
            grd_Voucher.DataSource = objListVoucher;
            objListBusquedaTotal = objListVoucher;
            grd_Voucher.Refresh();
            grd_Voucher.DoubleClick += Grd_Voucher_DoubleClick;
            cmbEstado();

        }
        private void Grd_Voucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //objVoucher = new Voucher();
            //operacionVoucher = "V";
            //index = grd_Voucher.SelectedCells[0].RowIndex;
            //objVoucher = objListVoucher[index];
           // if (objVoucher.EstadoCheque=="F")
           // {
           ///     btn_ImprimirCheque.Enabled = true;
           // }else 
           // {
            //    btn_ImprimirCheque.Enabled = false;
            //}

        }
        private void Grd_Voucher_DoubleClick(object sender, EventArgs e)
        {
            index = grd_Voucher.SelectedCells[0].RowIndex;
            DataGridViewRow dtg = grd_Voucher.Rows[index];
            objVoucher = new Voucher();

            if (dtg.Cells[6].Value.ToString() == "ANULADO")
            {
                operacionVoucher = "A";
                index = grd_Voucher.SelectedCells[0].RowIndex;
                objVoucher = objListVoucher[index];
                EmisionVoucher check = new EmisionVoucher();
                this.Hide();
                check.Show();
            }
            else
            {
                operacionVoucher = "V";
                index = grd_Voucher.SelectedCells[0].RowIndex;
                objVoucher = objListVoucher[index];
                EmisionVoucher check = new EmisionVoucher();
                this.Hide();
                check.Show();
            }
            

        }

        public void gridParams()
        {
            grd_Voucher.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Selec";
            chkColumn.Width = 50;
            chkColumn.DataPropertyName = "chkSelc";
            grd_Voucher.Columns.Add(chkColumn);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° Voucher";
            idColumn1.DataPropertyName = "NumeroVoucher";
            idColumn1.Width = 90;
            grd_Voucher.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N° Cheque";
            idColumn2.DataPropertyName = "NumeroCheque";
            idColumn2.Width = 90;
            grd_Voucher.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha Pago";
            idColumn3.DataPropertyName = "FechaPago";
            idColumn3.Width = 100;
            grd_Voucher.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.DefaultCellStyle.Format = "#0.00";
            idColumn4.Width = 60;
            //idColumn4.HeaderCell.
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "Moneda";
            idColumn5.Width = 70;
            grd_Voucher.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Banco";
            idColumn6.DataPropertyName = "Banco";
            idColumn6.Width = 190;
            grd_Voucher.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Estado";
            idColumn7.DataPropertyName = "Anulado";
            idColumn7.Width = 90;
            grd_Voucher.Columns.Add(idColumn7);
        }

        void cmbEstado()
        {
            List<EstadoVoucher> objLista = new List<EstadoVoucher>();
            EstadoVoucher obj = new EstadoVoucher();
            obj.Codigo = "NN";
            obj.Descripcion = " ";
            objLista.Add(obj);
            obj = new EstadoVoucher();
            obj.Codigo = "P";
            obj.Descripcion = "Proceso";
            objLista.Add(obj);
            obj = new EstadoVoucher();
            obj.Codigo = "A";
            obj.Descripcion = "Anulado";
            objLista.Add(obj);
            cmb_Estado.DataSource = objLista;
            cmb_Estado.ValueMember = "Codigo";
            cmb_Estado.DisplayMember = "Descripcion";
            cmb_Estado.Refresh();
        }
        
        void formatearCheque(Voucher objVoucher)
        {
            objCheque = new ChequeImpresion();
            objCheque.Receptor = "**"+objVoucher.Solicitante.Trim().PadRight(100,'*');
            objCheque.Total = objVoucher.Monto.ToString("C").Substring(3);
            objCheque.Dia = objVoucher.FechaPago.Day.ToString().PadLeft(2,'0');
            objCheque.Mes = objVoucher.FechaPago.Month.ToString().PadLeft(2, '0');
            objCheque.Anho = objVoucher.FechaPago.Year.ToString().Substring(2);
            //objCheque.Receptor = objVoucher.Solicitante;
            objCheque.TotalLetras ="  "+ objDocumentoDAO.numeroALetras(objVoucher.Monto).PadRight(150,'*');
            
            objListCheque.Add(objCheque);
        }
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("EV");
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            objListVoucher = objVoucherDao.listarVoucher(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value,cmb_Estado.SelectedValue.ToString());
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListVoucher;
            objListBusquedaTotal = objListVoucher;
            grd_Voucher.Refresh();
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_Nuevo.Enabled = false;
            this.Hide();
            operacionVoucher = "N";
            EmisionVoucher Check = new EmisionVoucher();
            Check.Show();
            btn_Nuevo.Enabled = true;
            /*
            bool resultado=false;
            DialogResult DlgRes;
            DlgRes = MessageBox.Show("¿Desea utilizar la versión actual?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (DlgRes == DialogResult.Yes)
            {
                
                resultado = true;
            }
            else if(DlgRes == DialogResult.No)
            {

            }

            if (resultado == true)
            {
                operacionVoucher = "v2019";
                btn_Nuevo.Enabled = false;
                this.Hide();
                operacionVoucher = "N";
                EmisionVoucher Check = new EmisionVoucher();
                Check.Show();
                btn_Nuevo.Enabled = true;
            }
            */
        }

        private void btn_Anular_Click(object sender, EventArgs e)
        {
            objVoucher = new Voucher();
            operacionVoucher = "V";
            index = grd_Voucher.SelectedCells[0].RowIndex;
            objVoucher = objListVoucher[index];
            bool anular = objVoucherDao.anularVoucher(objVoucher.NumeroVoucher,Ventas.UNIDADNEGOCIO, Ventas.UsuarioSession);
            if (!anular)
            {
                MessageBox.Show("Hubo un error al anular el voucher");
                return;
            }else
            {
                objListaVoucherDet = objVoucherDao.listarVoucherDet(objVoucher.NumeroVoucher, Ventas.UNIDADNEGOCIO);
                for (int i =0; i< objListaVoucherDet.Count; i++)
                {
                    String anularPago;
                    anularPago = "";
                    if (anularPago == objListaVoucherDet[i].numeroRegistro)
                    {

                        objPagoVoucherDao.anularAbono(objListaVoucherDet[i].SerieDocRef, objListaVoucherDet[i].NumeroDocRef, objListaVoucherDet[i].Importe);
                        
                    }
                    else if(anularPago != null)
                    {
                        objPagoVoucherDao.anularPago(objListaVoucherDet[i].numeroRegistro);
                    }
                    
                }
                MessageBox.Show("Voucher ha sido anulado");
            }
            objListVoucher = objVoucherDao.listarVoucher(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, "NN");
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();

        }

        private void btn_ImprimirCheque_Click(object sender, EventArgs e)
        {
            string root = @"N:\CHEQUE";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                btn_ImprimirCheque.Enabled = false;
                int index = grd_Voucher.SelectedCells[0].RowIndex;

                objVoucher = objListVoucher[index];
                String nombreArchivo = "Cheque-"+objVoucher.BancoCod+"-"+objVoucher.NumeroCheque;
                formatearCheque(objVoucher);
                if (objVoucher.BancoCod =="02")
                {
                    ChequeBBVA cr = new ChequeBBVA();
                    string rut = @"N:\CHEQUE\" + nombreArchivo + ".xls";
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    if (File.Exists(rut))
                    {
                        File.Delete(rut);
                    }
                    cr.SetDataSource(objListCheque);

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
                    diskOpts.DiskFileName = rut;
                    exportOpts.DestinationOptions = diskOpts;

                    cr.Export();

                    PrintMyExcelFile(rut);

                }
                else if (objVoucher.BancoCod == "04")
                {

                    ChequeBCP cr = new ChequeBCP();
                    string rut = @"N:\CHEQUE\" + nombreArchivo + ".xls";
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    if (File.Exists(rut))
                    {
                        File.Delete(rut);
                    }

                  
                    cr.SetDataSource(objListCheque);

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
                    diskOpts.DiskFileName = rut;
                    exportOpts.DestinationOptions = diskOpts;

                    cr.Export();

                    PrintMyExcelFile(rut);



                    /* cr.SetDataSource(objListCheque);
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
                     }*/
                }
                else if (objVoucher.BancoCod == "05")
                {
                    ChequeScotia cr = new ChequeScotia();
                    string rut = @"N:\CHEQUE\" + nombreArchivo + ".xls";
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    if (File.Exists(rut))
                    {
                        File.Delete(rut);
                    }


                    cr.SetDataSource(objListCheque);

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
                    diskOpts.DiskFileName = rut;
                    exportOpts.DestinationOptions = diskOpts;

                    cr.Export();

                    PrintMyExcelFile(rut);
                }

                btn_ImprimirCheque.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btn_ImprimirCheque.Enabled = true;
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
        private void btn_imprimir_Click(object sender, EventArgs e)
        {

        }

        private void grd_Voucher_Click(object sender, EventArgs e)
        {
            index = grd_Voucher.SelectedCells[0].RowIndex;
            DataGridViewRow dtg = grd_Voucher.Rows[index];

            if (dtg.Cells[6].Value.ToString() == "ANULADO")
            {
                btn_Anular.Enabled = false;
            }
            else
            {
                btn_Anular.Enabled = true;
            }
            
        }

        private void grd_Voucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                ExportToExcelWithFormat_Simple(grd_Voucher);

                btn_excel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_excel.Enabled = true;
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
                xlRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                if (colCount == 7)
                {
                    xlRange.EntireColumn.NumberFormat = "#,###.00";
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

        private void ListaEmisionVoucher_Load(object sender, EventArgs e)
        {

        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {

        }

        void formatearVoucher()
        {
            objListaVoucherDet = new List<VoucherDet>();
            objListaVoucherReporte = new List<VoucherReporte>();
            objListaVoucherDet = objVoucherDao.listarVoucherDet(objVoucher.NumeroVoucher, Ventas.UNIDADNEGOCIO);

            if (objListaVoucherDet.Count >= 1)
            {
                for (int i = 0; i < objListaVoucherDet.Count; i++)
                {
                    VoucherReporte objVoucherReporte;
                    objVoucherReporte = new VoucherReporte();
                    objVoucherReporte.Banco = objVoucher.Banco;
                    objVoucherReporte.Fecha = objVoucher.FechaPago.ToString("dd/MM/yyyy");
                    objVoucherReporte.Monto =objVoucher.Monto.ToString("G");

                    if (objVoucher.MonedaCod.ToString() == "PEN")
                    {
                        objVoucher.Moneda = "SOLES";
                        objVoucherReporte.simbolo = "S./";
                    }
                    else if (objVoucher.MonedaCod.ToString() == "USD")
                    {
                        objVoucher.Moneda = "DOLARES AMERICANOS";
                        objVoucherReporte.simbolo = "$";
                    }
                    else if (objVoucher.MonedaCod.ToString() == "EUR")
                    {
                        objVoucher.Moneda = "EUROS";
                    }

                    objVoucherReporte.MontoLetras = objDocumentoDAO.numeroALetras(objVoucher.Monto) + " " + objVoucher.Moneda;
                    objVoucherReporte.NroVoucher = objVoucher.NumeroVoucher;
                    objVoucherReporte.Observacion = objVoucher.Observacion;
                    objVoucherReporte.Persona = objVoucher.Solicitante.Trim();
                    objVoucherReporte.RazonSocial = objListaVoucherDet[i].RazonSocial.ToString().Trim();
                    objVoucherReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objVoucher.FechaPago.ToShortDateString()).ToString().PadRight(5, '0');
                    objVoucherReporte.Usuario = Ventas.UsuarioSession;
                    if (objVoucher.TpersonaCod == "04")
                    {
                        objVoucherReporte.PersonaDocumento = "";
                    }
                    else
                    {
                        objVoucherReporte.PersonaDocumento = objVoucher.SolicitaCod;
                    }
                    if (objVoucher.Estado == "A")
                    {
                        objVoucherReporte.Anulado = "A N U L A D O";
                    }
                    objVoucherReporte.Descripcion = objListaVoucherDet[i].TAOB.ToString();
                    objVoucherReporte.FechaEmision = objListaVoucherDet[i].FechaEmiRef.ToString();
                    objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("0.00"); 
                    objVoucherReporte.NroDocumento = objListaVoucherDet[i].NroDocumento;
                    objVoucherReporte.Ruc = objListaVoucherDet[i].NroOt + " " + "-" + " " + objListaVoucherDet[i].DirOt;
                    objListaVoucherReporte.Add(objVoucherReporte);
                }
            }
            else
            {
                VoucherReporte objVoucherReporte;
                // for (int i = 0; i < objListaVoucherDet.Count; i++)
                // {
                objVoucherReporte = new VoucherReporte();
                objVoucherReporte.Banco = objVoucher.Banco;
                //objVoucherReporte.Descripcion = objListaVoucherDet[i].Descripcion;
                objVoucherReporte.Fecha = objVoucher.FechaPago.ToString("dd/MM/yyyy");
                //objVoucherReporte.ImporteDetalle = objListaVoucherDet[i].Importe.ToString("C").Substring(3);
                objVoucherReporte.Monto = objVoucher.Monto.ToString("G")/*.Substring(3)*/;
                objVoucherReporte.MontoLetras = objDocumentoDAO.numeroALetras(objVoucher.Monto) + " " + objVoucher.Moneda.TrimEnd();
                objVoucherReporte.NroCheque = objVoucher.NumeroCheque;
                //objVoucherReporte.NroDocumento = objListaVoucherDet[i].NroDocumento;
                
                if (objVoucher.MonedaCod.ToString() == "PEN")
                {

                    objVoucherReporte.simbolo = "S./";
                }
                else if (objVoucher.MonedaCod.ToString() == "USD")
                {

                    objVoucherReporte.simbolo = "$";
                }
                objVoucherReporte.NroVoucher = objVoucher.NumeroVoucher;
                objVoucherReporte.Observacion = objVoucher.Observacion;
                objVoucherReporte.Persona = objVoucher.Solicitante;
                if (objVoucher.TpersonaCod == "04")
                {
                    objVoucherReporte.PersonaDocumento = "";
                }
                else
                {
                    objVoucherReporte.PersonaDocumento = objVoucher.SolicitaCod;
                }
                if (objVoucher.Estado == "A")
                {
                    objVoucherReporte.Anulado = "A N U L A D O";
                }

                //objVoucherReporte.RazonSocial = objListaVoucherDet[i].
                //objVoucherReporte.Ruc = objListaVoucherDet[i].
                objVoucherReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objVoucher.FechaPago.ToShortDateString()).ToString().PadRight(5, '0');
                objVoucherReporte.Usuario = Ventas.UsuarioSession;
                objListaVoucherReporte.Add(objVoucherReporte);
                // }
            }
        }
        public string generartext(List<EnvioMasivoContinental> objListDetalle)
        {

            objEnvioMasivoContinentalCab.Descripcion = "PRUEBA";
            Random r = new Random();
            string root = @"W:\public\TXT";
            rutaCompleta = @"W:\public\TXT\20300166611-";

            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            string t1, t2;
            rutaCompleta = rutaCompleta + DateTime.Now.ToString("dd-MM-yyyy") + ".txt";
            //if(File.Exists(rutaCompleta))
            //{
            //    File.Delete(rutaCompleta);
            //}
            t1 = "operacion|" + objEnvioMasivoContinentalCab.Descripcion;
            using (StreamWriter mylogs = File.AppendText(rutaCompleta))
            {
                //mylogs.WriteLine(t1);
                for(int i =0; i<objListDetalle.Count;i++)
                {
                    t2 = "001-003|" + "001"+"|"+ "004-004"+"|"+objListDetalle[i].DOITipoDocumento+"|"+"005-016"+"|"+ objListDetalle[i].DOINumeroDocumento+"|"+"017-017"+ objListDetalle[i].TipoAbono+"|"+"018-037"+"|"+objListDetalle[i].NumeroCuenta+"|"+"038-077"+"|"+objListDetalle[i].NombreBeneficiario+"|"+"078-092"+"|"+objListDetalle[i].ImporteAbonar+"|"+"093-093"+"|"+objListDetalle[i].TipoDocumento+"|"+"094-105"+"|"+objListDetalle[i].NumeroDocumento+"|"+"106-106"+"|"+objListDetalle[i].AbonoAgrupado+"|"+"107-146"+"|"+objListDetalle[i].Referencia+"|"+"147-147"+"|"+objListDetalle[i].IndicadorAviso+"|"+"148-197"+"|"+objListDetalle[i].MedioAviso+"|"+"198-227"+"|"+objListDetalle[i].PersonaContacto+"|"+"228-229"+"|"+objListDetalle[i].IndicadorProceso+"|"+"230-259"+"|"+objListDetalle[i].Descripcion+"|"+"260-278"+"|"+objListDetalle[i].Filler;
                    mylogs.WriteLine(t2);
                }
                mylogs.Close();
            }
            return rutaCompleta;
        }



        private void btn_pdf_Click(object sender, EventArgs e)
        {
            bool hola;
             
            foreach(DataGridViewRow row in grd_Voucher.Rows)
            {
                hola = Convert.ToBoolean(row.Cells[0].Value);
                if(hola)
                {
                    string root = @"W:\public\PDF";
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    try
                    {
                        int index = row.Cells[0].RowIndex;
                        numeroVoucher = objListVoucher[index].NumeroVoucher;
                        objVoucher = objListVoucher[index];
                        objListEnvioMasivoContinentalDet = objVoucherDao.getEnvioMasivoContinental(numeroVoucher);
                        String rutatext = generartext(objListEnvioMasivoContinentalDet);
                        //objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
                        formatearVoucher();
                        VoucherRpt cr = new VoucherRpt();
                        string rut = @"W:\public\PDF\20300166611-" + objVoucher.NumeroVoucher + "-" + objVoucher.Solicitante + ".pdf";
                        if (File.Exists(rut))
                        {
                            File.Delete(rut);
                        }
                        cr.SetDataSource(objListaVoucherReporte);
                        cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rut);
                        btn_pdf.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        btn_pdf.Enabled = true;
                    }
                }
            }
            
        }
        private void grd_Voucher_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grd_Voucher.IsCurrentCellDirty)
            {
                grd_Voucher.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
