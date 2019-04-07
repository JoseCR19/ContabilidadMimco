using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using System;
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
    public partial class PendientePorFacturar : Form
    {
        List<PendienteFacturar> objListPendienteFacturar = new List<PendienteFacturar>();
        DocumentoDAO objDocumentoDao;
        PendienteFacturar objPendienteFacturar;
        public PendientePorFacturar()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "PENDIENTE POR FACTURAR";
            cmbAño();
            gridParams();
         
            objDocumentoDao = new DocumentoDAO();
            DateTime d1, d2;
    
           
            if (Ventas.UNIDADNEGOCIO =="01")
            {
                objListPendienteFacturar = objDocumentoDao.pendienteFacturarM(cmb_Anho.SelectedValue.ToString());
            }
            else
            {
                objListPendienteFacturar = objDocumentoDao.pendienteFacturarG(cmb_Anho.SelectedValue.ToString());
            }
            grd_Facturas.DataSource = objListPendienteFacturar;
            grd_Facturas.Refresh();

        }
        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N°Ot";
            idColumn1.Width = 70;
            idColumn1.DataPropertyName = "NroOt";//0011-0142-0200751909
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn32 = new DataGridViewTextBoxColumn();
            idColumn32.Name = "Cliente";
            idColumn32.Width = 220;
            idColumn32.DataPropertyName = "Cliente";//0011-0142-0200751909
            grd_Facturas.Columns.Add(idColumn32);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Importe";
            idColumn2.DataPropertyName = "Importe";
            idColumn2.Width = 100;
            idColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Facturado";
            idColumn3.DataPropertyName = "Facturado";
            idColumn3.Width = 80;
            idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Saldo";
            idColumn4.DataPropertyName = "saldo";
            idColumn4.Width = 80;
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Documentos";
            idColumn5.DataPropertyName = "Documentos";
            idColumn5.Width = 200;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Fecha Ot";
            idColumn6.DataPropertyName = "FechaOt";
            idColumn6.Width = 80;
            grd_Facturas.Columns.Add(idColumn6);


        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            objListPendienteFacturar = new List<PendienteFacturar>();
            grd_Facturas.DataSource = null;
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                objListPendienteFacturar = objDocumentoDao.pendienteFacturarM(cmb_Anho.SelectedValue.ToString());
            }
            else
            {
                objListPendienteFacturar = objDocumentoDao.pendienteFacturarG(cmb_Anho.SelectedValue.ToString());
            }
            grd_Facturas.DataSource = objListPendienteFacturar;
            grd_Facturas.Refresh();
            btn_Buscar.Enabled = true;
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("PF");
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
                xlRange.EntireColumn.NumberFormat = "@";

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
                ExportToExcelWithFormat_Simple(grd_Facturas);

                btn_excel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_excel.Enabled = true;
            }
        }

        void cmbAño()
        {
            List<String> Años = new List<String>();
            Años.Add("2018");
            Años.Add("2017");
            Años.Add("2016");
            Años.Add("2015");

            Años.Add("2014");

            cmb_Anho.DataSource = Años;


        }


    }
}
