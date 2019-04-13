using System;
using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using System.IO;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Spire.Xls;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Facturacion
{
    public partial class CanjeLetra : Form
    {
        public static CanjeLetra formReporteProveedor;
        public List<LetraCab> objListLetra = new List<LetraCab>();
        public List<LetraCab> objReporteListLetra = new List<LetraCab>();
        List<LetraDetalle> objListaLetraDet = new List<LetraDetalle>();
        public static LetraCab objVoucher = new LetraCab();
        public static LetraDetalle objLetraDetalle = new LetraDetalle();
        public static List<ReporteFacturaC> objListaVenReporte = new List<ReporteFacturaC>();
        ReporteFacturaC objReporte;
        VoucherDAO objVoucherDao;
        int index = 0;
        ChequeImpresion objCheque = new ChequeImpresion();
        List<ChequeImpresion> objListCheque = new List<ChequeImpresion>();
        public static String operacionLetra = "Q";
        public CanjeLetra()
        {
            InitializeComponent();
            formReporteProveedor = this;
            this.Text = "CANJE LETRAS";
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            gridParams();
            gridParams2();
            objVoucherDao = new VoucherDAO();
            objListLetra = objVoucherDao.listarLetra(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, "NN",txt_Ruc.Text);
            objReporteListLetra = objVoucherDao.ReportelistarLetra(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, "NN", txt_Ruc.Text);
            dgv_reporte.DataSource = objReporteListLetra;
            grd_letra.DataSource = objListLetra;
            dgv_reporte.Refresh();
            grd_letra.Refresh();
            cmbEstado();
        }
        public void gridParams()
        {
            grd_letra.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "NroRegistro";
            idColumn1.DataPropertyName = "NroRegistro";
            idColumn1.Width = 70;
            grd_letra.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Tipo";
            idColumn2.DataPropertyName = "TipoDoc";
            idColumn2.Width = 30;
            grd_letra.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Serie";
            idColumn3.DataPropertyName = "SerieDoc";
            idColumn3.Width = 60;
            grd_letra.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Documento";
            idColumn6.DataPropertyName = "NroDoc";
            idColumn6.Width = 90;
            grd_letra.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "RUC";
            idColumn8.DataPropertyName = "Ruc";
            idColumn8.Width = 80;
            grd_letra.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Razón Social";
            idColumn9.DataPropertyName = "NomProv";
            idColumn9.Width = 140;
            grd_letra.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Importe Total";
            idColumn10.DataPropertyName = "ImporteTotal";
            idColumn10.DefaultCellStyle.Format = "0#.#0";
            idColumn10.Width = 80;
            grd_letra.Columns.Add(idColumn10);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe Letra";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.DefaultCellStyle.Format = "0#.#0";
            idColumn4.Width = 80;
            grd_letra.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "Abono";
            idColumn11.DataPropertyName = "Abono";
            idColumn11.DefaultCellStyle.Format = "0#.#0";
            idColumn11.Width = 80;
            grd_letra.Columns.Add(idColumn11);
            DataGridViewTextBoxColumn idColumn12 = new DataGridViewTextBoxColumn();
            idColumn12.Name = "Saldo";
            idColumn12.DataPropertyName = "Saldo";
            idColumn12.DefaultCellStyle.Format = "0#.#0";
            idColumn12.Width = 80;
            grd_letra.Columns.Add(idColumn12);
            //idColumn4.HeaderCell.
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "Moneda";
            idColumn5.Width = 60;
            grd_letra.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Estado";
            idColumn7.DataPropertyName = "Anulado";
            idColumn7.Width = 80;
            grd_letra.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn15 = new DataGridViewTextBoxColumn();
            idColumn15.Name = "F.Ven";
            idColumn15.DataPropertyName = "Fec_Ven";
            idColumn15.Width = 80;
            grd_letra.Columns.Add(idColumn15);
            foreach (DataGridViewColumn col in grd_letra.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

        }
        public void gridParams2()
        {
            dgv_reporte.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "NroRegistro";
            idColumn1.DataPropertyName = "NroRegistro";
            idColumn1.Width = 70;
            dgv_reporte.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Tipo";
            idColumn2.DataPropertyName = "TipoDoc";
            idColumn2.Width = 30;
            dgv_reporte.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Serie";
            idColumn3.DataPropertyName = "SerieDoc";
            idColumn3.Width = 60;
            dgv_reporte.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Documento";
            idColumn6.DataPropertyName = "NroDoc";
            idColumn6.Width = 90;
            dgv_reporte.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "RUC";
            idColumn8.DataPropertyName = "Ruc";
            idColumn8.Width = 80;
            dgv_reporte.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Razón Social";
            idColumn9.DataPropertyName = "NomProv";
            idColumn9.Width = 140;
            dgv_reporte.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Importe Total";
            idColumn10.DataPropertyName = "ImporteTotal";
            idColumn10.DefaultCellStyle.Format = "0#.#0";
            idColumn10.Width = 80;
            dgv_reporte.Columns.Add(idColumn10);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe Letra";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.DefaultCellStyle.Format = "0#.#0";
            idColumn4.Width = 80;
            dgv_reporte.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "Abono";
            idColumn11.DataPropertyName = "Abono";
            idColumn11.DefaultCellStyle.Format = "0#.#0";
            idColumn11.Width = 80;
            dgv_reporte.Columns.Add(idColumn11);
            DataGridViewTextBoxColumn idColumn12 = new DataGridViewTextBoxColumn();
            idColumn12.Name = "Saldo";
            idColumn12.DataPropertyName = "Saldo";
            idColumn12.DefaultCellStyle.Format = "0#.#0";
            idColumn12.Width = 80;
            dgv_reporte.Columns.Add(idColumn12);
            //idColumn4.HeaderCell.
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "Moneda";
            idColumn5.Width = 60;
            dgv_reporte.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Estado";
            idColumn7.DataPropertyName = "Anulado";
            idColumn7.Width = 80;
            dgv_reporte.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn15 = new DataGridViewTextBoxColumn();
            idColumn15.Name = "F.Ven";
            idColumn15.DataPropertyName = "Fec_Ven";
            idColumn15.Width = 80;
            dgv_reporte.Columns.Add(idColumn15);
            foreach (DataGridViewColumn col in dgv_reporte.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

        }
        private void CanjeLetra_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("CJLT");
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_Nuevo.Enabled = false;
            this.Hide();
            operacionLetra = "N";
            CanjeLetraNuevo Check = new CanjeLetraNuevo();
            Check.Show();
            btn_Nuevo.Enabled = true;
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
            grd_letra.DoubleClick += Grd_Voucher_DoubleClick;
            grd_letra.CellClick += grd_letra_CellClick;

        }
        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            objListLetra = objVoucherDao.listarLetra(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value,cmb_Estado.SelectedValue.ToString(),txt_Ruc.Text);
            grd_letra.DataSource = null;
            grd_letra.DataSource = objListLetra;
            grd_letra.Refresh();
        }
        private void Grd_Voucher_DoubleClick(object sender, EventArgs e)
        {
            index = grd_letra.SelectedCells[0].RowIndex;
            DataGridViewRow dtg = grd_letra.Rows[index];
            objVoucher = new LetraCab();

            if (dtg.Cells[11].Value.ToString() == "ANULADO")
            {
                operacionLetra = "A";
                index = grd_letra.SelectedCells[0].RowIndex;
                objVoucher = objListLetra[index];
                CanjeLetraNuevo check = new CanjeLetraNuevo();
                this.Hide();
                check.Show();
            }
            else
            {
                operacionLetra = "V";
                index = grd_letra.SelectedCells[0].RowIndex;
                objVoucher = objListLetra[index];
                CanjeLetraNuevo check = new CanjeLetraNuevo();
                this.Hide();
                check.Show();
            }


        }


        private void grd_letra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objVoucher = new LetraCab();
            operacionLetra = "V";
            index = grd_letra.SelectedCells[0].RowIndex;
            objVoucher = objListLetra[index];

            index = grd_letra.SelectedCells[0].RowIndex;
            DataGridViewRow dtg = grd_letra.Rows[index];
        }

        private void btn_Anular_Click(object sender, EventArgs e)
        {

      
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                ExportToExcelWithFormat_Simple(grd_letra);

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

        private void btn_ver_Click(object sender, EventArgs e)
        {
            index = grd_letra.SelectedCells[0].RowIndex;
            DataGridViewRow dtg = grd_letra.Rows[index];
            objVoucher = new LetraCab();

            if (dtg.Cells[11].Value.ToString() == "ANULADO")
            {
                operacionLetra = "A";
                index = grd_letra.SelectedCells[0].RowIndex;
                objVoucher = objListLetra[index];
                CanjeLetraNuevo check = new CanjeLetraNuevo();
                this.Hide();
                check.Show();
            }
            else
            {
                operacionLetra = "V";
                index = grd_letra.SelectedCells[0].RowIndex;
                objVoucher = objListLetra[index];
                CanjeLetraNuevo check = new CanjeLetraNuevo();
                this.Hide();
                check.Show();
            }
        }
        void formatearReporte()
        {
            for (int i = 0; i < objReporteListLetra.Count; i++)
            {
                objReporte = new ReporteFacturaC();
                objReporte.Ruc = objReporteListLetra[i].Ruc.ToString().Trim();
                objReporte.RazonSocial = objReporteListLetra[i].NomProv.ToString().Trim();
                objReporte.FechaVencimiento = objReporteListLetra[i].Fec_Ven.ToString().Trim().Substring(0,10);
                objReporte.TSD = objReporteListLetra[i].TipoDoc.ToString().Trim() + " "+ objReporteListLetra[i].SerieDoc.ToString().Trim() + "-" + objReporteListLetra[i].NroDoc.ToString().Trim();
                objReporte.Total = Convert.ToDouble(objReporteListLetra[i].Monto.ToString("G"));
                objReporte.Moneda = objReporteListLetra[i].Moneda.ToString();
                objReporte.TC = objReporteListLetra[i].TipoCambio.ToString();
                objReporte.Abono =Convert.ToDouble(objReporteListLetra[i].Abono.ToString("G"));
                objReporte.Saldo = Convert.ToDouble(objReporteListLetra[i].Saldo.ToString("G"));
                objListaVenReporte.Add(objReporte);
            }
        }
        private void btn_Reporte_Click(object sender, EventArgs e)
        {


        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {

        }

        private void btn_reporteletras_Click(object sender, EventArgs e)
        {

        }

        private void btn_Reporte_Click_1(object sender, EventArgs e)
        {
            btn_Reporte.Enabled = true;
            formatearReporte();
            ReporteView Check = new ReporteView("RLV"); // ExcelCliente
            Check.Show();
            btn_Reporte.Enabled = true;
        }

        private void btn_reporteletras_Click_1(object sender, EventArgs e)
        {
            objReporteListLetra = objVoucherDao.ReportelistarLetra(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, cmb_Estado.SelectedValue.ToString(), txt_Ruc.Text);
            dgv_reporte.DataSource = null;
            dgv_reporte.DataSource = objReporteListLetra;
            dgv_reporte.Refresh();
        }
    }
}
