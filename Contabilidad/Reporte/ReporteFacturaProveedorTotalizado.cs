using System;
using ContabilidadDAO;
using ContabilidadDTO;
using Contabilidad.Busqueda;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Reporte
{
    public partial class ReporteFacturaProveedorTotalizado : Form
    {
        public static ReporteFacturaProveedorTotalizado formReporteProveedor;
        public static ContabilidadDTO.Ventas objVetasCab = new ContabilidadDTO.Ventas();
        public static List<ReporteFacturaC> objListaVenReporte = new List<ReporteFacturaC>();
        public static List<ContabilidadDTO.Ventas> objListaDocCab = new List<ContabilidadDTO.Ventas>();
        ReporteFacturaC objReporte;
        List<Ejercicio> objListaEjercicio = new List<Ejercicio>();
        List<Periodo> objListaPeriodo = new List<Periodo>();
        DocumentoDAO objDocumentoDao;
        Ejercicio objEjercicio;
        Periodo objPeriodo;
        public ReporteFacturaProveedorTotalizado()
        {
            InitializeComponent();
            formReporteProveedor = this;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(100, 100);
            this.Text = "REPORTE DOCUMENTOS POR PROVEEDOR TOTALIZADO";
            objDocumentoDao = new DocumentoDAO();
            gridParams();
            cmbejercicio();
            cmbperiodo();
            if (cmb_periodo.SelectedValue.ToString() == "13")
            {
                objListaDocCab = objDocumentoDao.documentoPorProveedorTotalziadoAnio(cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, "NN");
            }
            else
            {
                objListaDocCab = objDocumentoDao.documentoPorProveedorTotalziado(cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, "NN");
            }
            grd_Documentos.DataSource = objListaDocCab;
            grd_Documentos.Refresh();
        }
        public void gridParams()
        {
            grd_Documentos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Ruc";
            idColumn0.Width = 80;
            idColumn0.DataPropertyName = "Ruc";
            grd_Documentos.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Razon Social";
            idColumn1.Width = 400;
            idColumn1.DataPropertyName = "RazonSocial";
            grd_Documentos.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Importe Soles";
            idColumn7.DataPropertyName = "total_soles";
            idColumn7.DefaultCellStyle.Format = "#0.00";
            idColumn7.Width = 80;
            grd_Documentos.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Importe Dolares";
            idColumn8.DataPropertyName = "total_dolares";
            idColumn8.DefaultCellStyle.Format = "#0.00";
            idColumn8.Width = 80;
            grd_Documentos.Columns.Add(idColumn8);
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
            objPeriodo.Id = "01";
            objPeriodo.Descripcion = "01";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "02";
            objPeriodo.Descripcion = "02";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "03";
            objPeriodo.Descripcion = "03";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "04";
            objPeriodo.Descripcion = "04";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "05";
            objPeriodo.Descripcion = "05";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "06";
            objPeriodo.Descripcion = "06";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "07";
            objPeriodo.Descripcion = "07";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "08";
            objPeriodo.Descripcion = "08";
            objListaPeriodo.Add(objPeriodo);
            objPeriodo = new Periodo();
            objPeriodo.Id = "09";
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


        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            String rucbuscar = "";
            if (String.IsNullOrEmpty(txt_Ruc.Text))
            {
                rucbuscar = "NN";
            }
            else
            {
                rucbuscar = txt_Ruc.Text;
            }
            if (cmb_periodo.SelectedValue.ToString() == "13")
            {
                objListaDocCab = objDocumentoDao.documentoPorProveedorTotalziadoAnio(cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, rucbuscar);
            }
            else
            {
                objListaDocCab = objDocumentoDao.documentoPorProveedorTotalziado(cmb_ejercicio2.SelectedValue.ToString(), cmb_periodo.SelectedValue.ToString(), Ventas.UNIDADNEGOCIO, rucbuscar);
            }
            grd_Documentos.DataSource = objListaDocCab;
            grd_Documentos.Refresh();
            btn_Buscar.Enabled = true;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RFPPT");
        }
        private void copyAlltoClipboard(DataGridView dataview)
        {
            dataview.SelectAll();
            DataObject dataObj = dataview.GetClipboardContent();
            if (dataObj != null)
                Clipboard.SetDataObject(dataObj);

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
                if (colCount == 4 || colCount == 5 )
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

        private void btn_excel_Click_1(object sender, EventArgs e)
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
    }
}
