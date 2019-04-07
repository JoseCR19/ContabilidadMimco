using Contabilidad.Report;
using Contabilidad.Busqueda;
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class ReporteDocumentosPorCliente : Form
    {
        public static ReporteDocumentosPorCliente formReporteClientes;
        public static List<DocumentoReporte> objListaDocReporte = new List<DocumentoReporte>();
        public static DocumentoCab objDocumentoCab = new DocumentoCab();
        DocumentoContabilidadDAO objDocContaDao;
        DocumentoDAO objDocumentoDao;
        MonedaDAO objMoneda;
        DocumentoReporte objReporte;
        DocumentoReporteExcel objReporteExcel;
        public static List<DocumentoCab> objListaDocCab = new List<DocumentoCab>();
        public static List<DocumentoReporteExcel> objListaReporteExcel = new List<DocumentoReporteExcel>();
        List<Ejercicio> objListaEjercicio = new List<Ejercicio>();
        List<Periodo> objListaPeriodo = new List<Periodo>();
        Ejercicio objEjercicio;
        Periodo objPeriodo;
        public ReporteDocumentosPorCliente()
        {
            InitializeComponent();
            formReporteClientes = this;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(20, 20);
            objDocContaDao = new DocumentoContabilidadDAO();
            objDocumentoDao = new DocumentoDAO();
            objMoneda = new MonedaDAO();
            this.Text = "REPORTE DOCUMENTOS POR CLIENTE";
            comboMoneda();
            gridParams();
            comboContabilidad();
            cmbejercicio();
            cmbperiodo();
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                objListaDocCab = objDocumentoDao.documentoPorClienteM("NN", cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO,"NN");

            }
            else
            {
                objListaDocCab = objDocumentoDao.documentoPorClienteG("NN", cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO , "NN");

            }
            grd_Documentos.DataSource = objListaDocCab;
            grd_Documentos.Refresh();
            llenarSumatorias();
        }
        void cmbejercicio()
        {
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2018";
            objEjercicio.Descripcion = "2018";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2019";
            objEjercicio.Descripcion = "2019";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2020";
            objEjercicio.Descripcion = "2020";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2021";
            objEjercicio.Descripcion = "2021";
            objListaEjercicio.Add(objEjercicio);
            objEjercicio = new Ejercicio();
            objEjercicio.Id = "2022";
            objEjercicio.Descripcion = "2022";
            objListaEjercicio.Add(objEjercicio);
            cmb_ejercicio2.DataSource = objListaEjercicio;
            cmb_ejercicio2.ValueMember = "Id";
            cmb_ejercicio2.DisplayMember = "Descripcion";
            cmb_ejercicio2.Refresh();
        }
        void cmbperiodo()
        {
            objPeriodo = new Periodo();
            objPeriodo.Id = "13";
            objPeriodo.Descripcion = "Todo";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "1";
            objPeriodo.Descripcion = "01";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "2";
            objPeriodo.Descripcion = "02";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "3";
            objPeriodo.Descripcion = "03";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "4";
            objPeriodo.Descripcion = "04";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "5";
            objPeriodo.Descripcion = "05";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "6";
            objPeriodo.Descripcion = "06";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "7";
            objPeriodo.Descripcion = "07";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "8";
            objPeriodo.Descripcion = "08";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "9";
            objPeriodo.Descripcion = "09";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "10";
            objPeriodo.Descripcion = "10";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "11";
            objPeriodo.Descripcion = "11";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "12";
            objPeriodo.Descripcion = "12";
            objListaPeriodo.Add(objPeriodo);
            cmb_periodo.DataSource = objListaPeriodo;
            cmb_periodo.ValueMember = "Id";
            cmb_periodo.DisplayMember = "Descripcion";
            cmb_periodo.Refresh();

        }
        public void comboContabilidad()
        {
            cmb_TipoDocumento.DataSource = objDocContaDao.listarDocumentoContabilidad();
            cmb_TipoDocumento.ValueMember = "DocContabilidadCod";
            cmb_TipoDocumento.DisplayMember = "DocContabilidadDescripcion";
            cmb_TipoDocumento.Refresh();
        }
        public void comboMoneda()
        {
            cmb_Moneda.DataSource = objMoneda.listarTipoMonedaReporte();
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
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
        public void llenarSumatorias()
        {
            txt_Total.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("PEN")).Sum(x => x.DocumentoCabTotal).ToString();
            txt_SubTotalS.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("PEN")).Sum(x => x.DocumentoCabTotalSinIGV).ToString();
            txt_IGVS.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("PEN")).Sum(x => x.DocumentoCabIGV).ToString();

            txt_IGVD.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("USD")).Sum(x => x.DocumentoCabIGV).ToString();
            txt_SubTotalD.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("USD")).Sum(x => x.DocumentoCabTotalSinIGV).ToString();
            txt_Dolares.Text = objListaDocCab.Where(t => t.DocumentoCabTipoMoneda.Equals("USD")).Sum(x => x.DocumentoCabTotal).ToString();


        }
        void formatearDocumento()
        {
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
        public void setDatosCliente(String ruc, String codcliente)
        {
            txt_Cliente.Text = ruc;
            txt_codcliente.Text = codcliente;
        }

        private void btn_BuscarOT_Click(object sender, EventArgs e)
        {
            using (var buscarClienteForm = new BuscarCliente("R"))
            {
                buscarClienteForm.ShowDialog();
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            String rucbuscar = "";
            if (String.IsNullOrEmpty(txt_Cliente.Text))
            {
                rucbuscar = "NN";
            }
            else
            {
                rucbuscar = txt_codcliente.Text;
            }
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                if(cmb_periodo.SelectedValue.ToString()=="13")
                {
                    objListaDocCab = objDocumentoDao.documentoPorClienteManio(rucbuscar, cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, cmb_TipoDocumento.SelectedValue.ToString());
                }
                else
                {
                    objListaDocCab = objDocumentoDao.documentoPorClienteM(rucbuscar, cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, cmb_TipoDocumento.SelectedValue.ToString());
                }
                
            }
            else
            {
                if(cmb_periodo.SelectedValue.ToString() == "13")
                {
                    objListaDocCab = objDocumentoDao.documentoPorClienteGanio(rucbuscar, cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, cmb_TipoDocumento.SelectedValue.ToString());
                }
                else
                {
                    objListaDocCab = objDocumentoDao.documentoPorClienteG(rucbuscar, cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), cmb_Moneda.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, cmb_TipoDocumento.SelectedValue.ToString());
                }
            }

            grd_Documentos.DataSource = objListaDocCab;
            grd_Documentos.Refresh();
            llenarSumatorias();
            btn_Buscar.Enabled = true;
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grd_Documentos.SelectedCells[0].RowIndex;


                objDocumentoCab = objListaDocCab[index];
               // this.Hide();
                switch (objDocumentoCab.DocumentoCabTipoDoc)
                {
                    case "01":
                        FacturaReporte Check = new FacturaReporte("FACTURA ELECTRÓNICA", "C");
                        Check.ShowDialog();
                        break;
                    case "03":
                        BoletaReporte Check2 = new BoletaReporte("BOLETA ELECTRÓNICA", "C");
                        Check2.ShowDialog();
                        break;
                    case "07":
                        NotaCreditoReporte Check3 = new NotaCreditoReporte("NOTA DE CRÉDITO", "C");
                        Check3.ShowDialog();
                        break;
                    case "08":
                        NotaDebitoReporte Check4 = new NotaDebitoReporte("NOTA DE DÉBITO", "C");
                        Check4.ShowDialog();
                        break;
                    case "LT":
                        Reporte.LetraReporte Check5 = new Reporte.LetraReporte("C");
                        Check5.ShowDialog();
                        break;
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RC");
        }

        private void ReporteDocumentosPorCliente_Load(object sender, EventArgs e)
        {

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
                if (colCount == 5 || colCount == 6 || colCount == 7 || colCount == 8 || colCount == 9 || colCount == 10)
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
            for (int i = 0; i < objListaDocCab.Count; i++)
            {
                objReporteExcel = new DocumentoReporteExcel();
                if (objListaDocCab[i].EstadoS.Contains("SUNAT"))
                {
                    objReporteExcel.Estado = objListaDocCab[i].EstadoS.Substring(0, 8);
                }
                else
                {
                    objReporteExcel.Estado = objListaDocCab[i].EstadoS;
                }

                objReporteExcel.Fecha = objListaDocCab[i].DocumentoCabFecha.ToString("dd/MM/yyyy");
                objReporteExcel.FechaVcto = objListaDocCab[i].DocumentoCabFechaVcto.ToString("dd/MM/yyyy");
                objReporteExcel.IGV = objListaDocCab[i].DocumentoCabIGV.ToString("C").Substring(3);

                if (objListaDocCab[i].DocumentoCabTipoMoneda == "USD")
                {
                    objReporteExcel.Moneda = objListaDocCab[i].DocumentoCabMoneda.Substring(0, 7);
                }
                else
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
                //objReporteExcel.Rango = dpickerInicio.Value.ToString("dd/MM/yyyy") + " a " + dpickerFin.Value.ToString("dd/MM/yyyy");
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
            ReporteView Check = new ReporteView("EC"); // ExcelCliente
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
            saveFileDialog1.FileName = "20300166611-01-ReportePorCliente" +
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
                string rut = @"N:\PDF\20300166611-01-ReportePorCliente" + "-" + randomnum + ".pdf";
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
    }
}


