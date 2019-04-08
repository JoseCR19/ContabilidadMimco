using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using Contabilidad.Busqueda;
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

namespace Contabilidad.Reporte
{
    public partial class ReporteVoucher : Form
    {
        List<Voucher> objListVoucher = new List<Voucher>();
        public static ReporteVoucher formReporteCheques;
        String tabs = "";
        VoucherDAO objVoucherDAO;
        public ReporteVoucher()
        {
            InitializeComponent();
            formReporteCheques = this;
            this.ControlBox = false;
            this.Text = "Reporte de Voucher";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 10);
            objVoucherDAO = new VoucherDAO();
            DateTime d1, d2,d11,d22;
            d2 = DateTime.Now;
            d22 = DateTime.Now;
            d11 = new DateTime(d22.Year, d22.Month, 1);
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            dpickerInicio1.Value = d11;

            //if(CHEQUES.CanSelect)
            //{
            //    objListVoucher = objVoucherDAO.voucherReporte(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, "NN");
            //}
            //else if(COBRANZA.CanSelect)
            //{

            //}
            gridParams2();
            gridParams();
            gridParams3();
            dgv_cobranza.DataSource = null;
            grd_Voucher.DataSource = null;
            dgv_personal.DataSource = null;
            //grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();
            dgv_cobranza.Refresh();
            dgv_personal.Refresh();
            llenarSumatorias();
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
            objListVoucher = objVoucherDAO.voucherReporte(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, rucbuscar);
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();
            llenarSumatorias();
            btn_Buscar.Enabled = true;
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
        public void gridParams2()
        {
            dgv_cobranza.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "N° Voucher";
            idColumn0.Width = 90;
            idColumn0.DataPropertyName = "NumeroVoucher";
            dgv_cobranza.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "F. Emisión";
            idColumn2.DataPropertyName = "FechaEmision";
            idColumn2.Width = 90;
            dgv_cobranza.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Solicitante";
            idColumn8.DataPropertyName = "Solicitante";
            idColumn8.Width = 250;
            dgv_cobranza.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Banco";
            idColumn3.DataPropertyName = "Banco";
            idColumn3.Width = 150;
            dgv_cobranza.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumnF = new DataGridViewTextBoxColumn();
            idColumnF.Name = "N° Cuenta";
            idColumnF.Width = 150;
            idColumnF.DataPropertyName = "NumeroCuenta";
            dgv_cobranza.Columns.Add(idColumnF);
            DataGridViewTextBoxColumn idColumnCambio = new DataGridViewTextBoxColumn();
            idColumnCambio.Name = "Cheque";
            idColumnCambio.DataPropertyName = "NumeroCheque";
            idColumnCambio.Width = 70;
            dgv_cobranza.Columns.Add(idColumnCambio);
            DataGridViewTextBoxColumn idColumnPeso = new DataGridViewTextBoxColumn();
            idColumnPeso.Name = "Moneda";
            idColumnPeso.DataPropertyName = "Moneda";
            idColumnPeso.Width = 60;
            dgv_cobranza.Columns.Add(idColumnPeso);
            DataGridViewTextBoxColumn idColumnPrecio = new DataGridViewTextBoxColumn();
            idColumnPrecio.Name = "Monto";
            idColumnPrecio.DataPropertyName = "Monto";
            idColumnPrecio.Width = 70;
            idColumnPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_cobranza.Columns.Add(idColumnPrecio);
            DataGridViewTextBoxColumn idObservacion = new DataGridViewTextBoxColumn();
            idObservacion.Name = "Observación";
            idObservacion.DataPropertyName = "Observacion";
            idObservacion.Width = 70;
            idObservacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_cobranza.Columns.Add(idObservacion);


        }
        public void gridParams3()
        {
            dgv_personal.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "N° Voucher";
            idColumn0.Width = 90;
            idColumn0.DataPropertyName = "NumeroVoucher";
            dgv_personal.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "F. Emisión";
            idColumn2.DataPropertyName = "FechaEmision";
            idColumn2.Width = 90;
            dgv_personal.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Solicitante";
            idColumn8.DataPropertyName = "Solicitante";
            idColumn8.Width = 250;
            dgv_personal.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Banco";
            idColumn3.DataPropertyName = "Banco";
            idColumn3.Width = 150;
            dgv_personal.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumnF = new DataGridViewTextBoxColumn();
            idColumnF.Name = "N° Cuenta";
            idColumnF.Width = 150;
            idColumnF.DataPropertyName = "NumeroCuenta";
            dgv_personal.Columns.Add(idColumnF);
            DataGridViewTextBoxColumn idColumnCambio = new DataGridViewTextBoxColumn();
            idColumnCambio.Name = "Cheque";
            idColumnCambio.DataPropertyName = "NumeroCheque";
            idColumnCambio.Width = 70;
            dgv_personal.Columns.Add(idColumnCambio);
            DataGridViewTextBoxColumn idColumnPeso = new DataGridViewTextBoxColumn();
            idColumnPeso.Name = "Moneda";
            idColumnPeso.DataPropertyName = "Moneda";
            idColumnPeso.Width = 60;
            dgv_personal.Columns.Add(idColumnPeso);
            DataGridViewTextBoxColumn idColumnPrecio = new DataGridViewTextBoxColumn();
            idColumnPrecio.Name = "Monto";
            idColumnPrecio.DataPropertyName = "Monto";
            idColumnPrecio.Width = 70;
            idColumnPrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_personal.Columns.Add(idColumnPrecio);
            DataGridViewTextBoxColumn idObservacion = new DataGridViewTextBoxColumn();
            idObservacion.Name = "Observación";
            idObservacion.DataPropertyName = "Observacion";
            idObservacion.Width = 70;
            idObservacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_personal.Columns.Add(idObservacion);


        }


        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            Ventas.formVentas.setEnabledItems("VR");
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

        private void button1_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            using (var buscarProveedorForm = new BusquedaProveedor("CH"))
            {
                buscarProveedorForm.ShowDialog();
            }
            btn_Buscar.Enabled = true;
        }
        public void setDatos(Proveedor objCli)
        {

            txt_Ruc.Text = objCli.ProveedorNDoc;
        }

        private void Cheues_Click(object sender, EventArgs e)
        {

        }

        private void dpickerInicio_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_BuscarOT_Click(object sender, EventArgs e)
        {
            using (var buscarClienteForm = new BuscarCliente("VC"))
            {
                buscarClienteForm.ShowDialog();
            }
        }
        public void setClienteDatos( string ruc)
        {
            txt_Cliente.Text = ruc;

        }

        private void button2_Click(object sender, EventArgs e)
        { 

        }

        private void CHEQUES_MouseClick(object sender, MouseEventArgs e)
        {
            tabs = "1";
        }

        private void btn_buscarC_Click(object sender, EventArgs e)
        {
            btn_buscarC.Enabled = false;
            String rucbuscar = "";
            if (String.IsNullOrEmpty(txt_Cliente.Text))
            {
                rucbuscar = "NN";
            }
            else
            {
                rucbuscar = txt_Cliente.Text;
            }
            objListVoucher = objVoucherDAO.voucherReporteCliente(Ventas.UNIDADNEGOCIO, dpickerInicio1.Value, dpickerFin1.Value, rucbuscar);
            dgv_cobranza.DataSource = null;
            dgv_cobranza.DataSource = objListVoucher;
            dgv_cobranza.Refresh();
            llenarSumatorias();
            btn_buscarC.Enabled = true;
        }

        private void btn_prestamos_Click(object sender, EventArgs e)
        {
            btn_prestamos.Enabled = false;
            String rucbuscar = "";
            if (String.IsNullOrEmpty(txt_personal.Text))
            {
                rucbuscar = "NN";
            }
            else
            {
                rucbuscar = txt_personal.Text;
            }
            objListVoucher = objVoucherDAO.voucherReportePersonal(Ventas.UNIDADNEGOCIO, dpickerInicio2.Value, dpickerFin3.Value, rucbuscar);
            dgv_personal.DataSource = null;
            dgv_personal.DataSource = objListVoucher;
            dgv_personal.Refresh();
            llenarSumatorias();
            btn_prestamos.Enabled = true;
        }
    }
}
