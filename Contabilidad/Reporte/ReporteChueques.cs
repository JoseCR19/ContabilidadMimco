using System;
using ContabilidadDAO;
using ContabilidadDTO;
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
    public partial class ReporteChueques : Form
    {
        List<Voucher> objListVoucher = new List<Voucher>();
        VoucherDAO objVoucherDAO;

        public ReporteChueques()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Reporte de Voucher";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 10);
            objVoucherDAO = new VoucherDAO();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            gridParams();
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            objListVoucher = objVoucherDAO.voucherReporte(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value);
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();
            llenarSumatorias();
        }
        public void llenarSumatorias()
        {
            txt_Total.Text = objListVoucher.Where(t => t.Moneda.Equals("Soles")).Sum(x => x.Monto).ToString();
            txt_Dolares.Text = objListVoucher.Where(t => t.Moneda.Equals("Dólares")).Sum(x => x.Monto).ToString();

        }
        public void gridParams()
        {
            grd_Voucher.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "N° Voucher";
            idColumn0.Width = 90;
            idColumn0.DataPropertyName = "NumeroVoucher";
            grd_Voucher.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "F. Emisión";
            idColumn2.DataPropertyName = "FechaEmision";
            idColumn2.Width = 90;
            grd_Voucher.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Solicitante";
            idColumn8.DataPropertyName = "Solicitante";
            idColumn8.Width = 250;
            grd_Voucher.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Banco";
            idColumn3.DataPropertyName = "Banco";
            idColumn3.Width = 150;
            grd_Voucher.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumnF = new DataGridViewTextBoxColumn();
            idColumnF.Name = "N° Cuenta";
            idColumnF.Width = 150;
            idColumnF.DataPropertyName = "NumeroCuenta";
            grd_Voucher.Columns.Add(idColumnF);
            DataGridViewTextBoxColumn idColumnCambio = new DataGridViewTextBoxColumn();
            idColumnCambio.Name = "Cheque";
            idColumnCambio.DataPropertyName = "NumeroCheque";
            idColumnCambio.Width = 70;
            grd_Voucher.Columns.Add(idColumnCambio);
            DataGridViewTextBoxColumn idColumnPeso = new DataGridViewTextBoxColumn();
            idColumnPeso.Name = "Moneda";
            idColumnPeso.DataPropertyName = "Moneda";
            idColumnPeso.Width = 60;
            grd_Voucher.Columns.Add(idColumnPeso);
            DataGridViewTextBoxColumn idColumnPrecio = new DataGridViewTextBoxColumn();
            idColumnPrecio.Name = "Monto";
            idColumnPrecio.DataPropertyName = "Monto";
            idColumnPrecio.Width = 70;
            idColumnPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumnPrecio);
            DataGridViewTextBoxColumn idObservacion = new DataGridViewTextBoxColumn();
            idObservacion.Name = "Observación";
            idObservacion.DataPropertyName = "Observacion";
            idObservacion.Width = 70;
            idObservacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idObservacion);


        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Ventas.formVentas.setEnabledItems("RPCH");
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
    }
}
