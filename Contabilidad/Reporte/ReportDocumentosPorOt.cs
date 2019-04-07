using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Contabilidad.Reporte
{
    public partial class ReportDocumentosPorOt : Form
    {
        List<PendienteFacturar> objListPendienteFacturar = new List<PendienteFacturar>();
        List<DetalleReporte> objListaDetalle = new List<DetalleReporte>();
        DocumentoDAO objDocumentoDao;
        PendienteFacturar objPendienteFacturar;
        DataGridView grd_Documentos = new DataGridView();

        DataGridView Detail_shanuDGV = new DataGridView();

        List<int> lstNumericTextBoxColumns;

        Helper.ShanuDGVHelper objshanudgvHelper = new Helper.ShanuDGVHelper();
        public int ColumnIndex;
        DataTable dtName = new DataTable();
        public ReportDocumentosPorOt()
        {
            InitializeComponent();
            cmbAño();
            this.ControlBox = false;
            this.Text = "FACTURAS POR OT";
            cmb_Anho.SelectedIndex = 0;
          //  gridParams();
           
            objDocumentoDao = new DocumentoDAO();
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                objListPendienteFacturar = objDocumentoDao.reportPorOtM(cmb_Anho.SelectedValue.ToString());
                objListaDetalle = objDocumentoDao.listarDetalleReportPorOtM(cmb_Anho.SelectedValue.ToString());
            }
            else
            {
                objListPendienteFacturar = objDocumentoDao.reportPorOtG(cmb_Anho.SelectedValue.ToString());
                objListaDetalle = objDocumentoDao.listarDetalleReportPorOtG(cmb_Anho.SelectedValue.ToString());
            }
            // grd_Documentos.DataSource = objListPendienteFacturar;
            // grd_Documentos.Refresh();
            MasterGrid_Initialize();

            DetailGrid_Initialize();
            //grd_Documentos.CellDoubleClick += Grd_Documentos_CellDoubleClick;
        }

        private void Grd_Documentos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_Documentos.SelectedCells[0].RowIndex;

            
            objPendienteFacturar = objListPendienteFacturar[index];
            FacturasOt form = new FacturasOt(objPendienteFacturar.NroOt);
            form.Show();
        }

        public void gridParams()
        {
            grd_Documentos.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N°Ot";
            idColumn1.Width = 100;
            idColumn1.DataPropertyName = "NroOt";//0011-0142-0200751909
            grd_Documentos.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn32 = new DataGridViewTextBoxColumn();
            idColumn32.Name = "Cliente";
            idColumn32.Width = 200;
            idColumn32.DataPropertyName = "Cliente";//0011-0142-0200751909
            grd_Documentos.Columns.Add(idColumn32);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Importe";
            idColumn2.DataPropertyName = "Importe";
            idColumn2.Width = 100;
            idColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Facturado";
            idColumn3.DataPropertyName = "Facturado";
            idColumn3.Width = 100;
            idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Saldo";
            idColumn4.DataPropertyName = "saldo";
            idColumn4.Width = 100;
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn12 = new DataGridViewTextBoxColumn();
            idColumn12.Name = "Documentos";
            idColumn12.DataPropertyName = "Documentos";
            idColumn12.Width = 180;
            grd_Documentos.Columns.Add(idColumn12);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Fecha Ot";
            idColumn6.DataPropertyName = "FechaOt";
            idColumn6.Width = 100;
            grd_Documentos.Columns.Add(idColumn6);

        }



        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                objListPendienteFacturar = objDocumentoDao.reportPorOtM(cmb_Anho.SelectedValue.ToString());
                objListaDetalle = objDocumentoDao.listarDetalleReportPorOtM(cmb_Anho.SelectedValue.ToString());
            }
            else
            {
                objListPendienteFacturar = objDocumentoDao.reportPorOtG(cmb_Anho.SelectedValue.ToString());
                objListaDetalle = objDocumentoDao.listarDetalleReportPorOtG(cmb_Anho.SelectedValue.ToString());
            }
            grd_Documentos.DataSource = null;
            grd_Documentos.DataSource = objListPendienteFacturar;
            grd_Documentos.Refresh();
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

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RO");
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
                ExportToExcelWithFormat_Simple(grd_Documentos);

                btn_excel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_excel.Enabled = true;
            }
        }


        public void MasterGrid_Initialize()
        {

            //First generate the grid Layout Design
            Helper.ShanuDGVHelper.Layouts(grd_Documentos, Color.LightSteelBlue, Color.AliceBlue, Color.WhiteSmoke, false, Color.SteelBlue, false, false, false);

            //Set Height,width and add panel to your selected control
            Helper.ShanuDGVHelper.Generategrid(grd_Documentos, this, 800, 300, 100, 110);


            // Color Image Column creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.ImageColumn, "img", "", "", true, 26, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.BoundColumn, "NroOt", "NroOt", "NroOt", true, 90, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.BoundColumn, "Cliente", "Cliente", "Cliente", true, 320, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.BoundColumn, "Importe", "Importe", "Importe", true, 80, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.BoundColumn, "Facturado", "Facturado", "Facturado", true, 80, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.BoundColumn, "Saldo", "Saldo", "Saldo", true, 80, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);
            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(grd_Documentos, ShanuControlTypes.BoundColumn, "FechaOt", "FechaOt", "FechaOt", true, 100, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);


            //Convert the List to DataTable
            DataTable detailTableList = ListtoDataTable(objListaDetalle);

            // Image Colum Click Event - In  this method we create an event for cell click and we will display the Detail grid with result.

            objshanudgvHelper.DGVMasterGridClickEvents(grd_Documentos, Detail_shanuDGV, grd_Documentos.Columns["img"].Index, ShanuEventTypes.cellContentClick, ShanuControlTypes.ImageColumn, detailTableList, "NroOt");

            // Bind data to DGV.
            grd_Documentos.DataSource = objListPendienteFacturar;



        }
        //List to Data Table Convert
        private static DataTable ListtoDataTable<T>(IEnumerable<T> DetailList)
        {
            Type type = typeof(T);
            var typeproperties = type.GetProperties();

            DataTable listToDT = new DataTable();
            foreach (PropertyInfo propInfo in typeproperties)
            {
                listToDT.Columns.Add(new DataColumn(propInfo.Name, propInfo.PropertyType));
            }

            foreach (T ListItem in DetailList)
            {
                object[] values = new object[typeproperties.Length];
                for (int i = 0; i < typeproperties.Length; i++)
                {
                    values[i] = typeproperties[i].GetValue(ListItem, null);
                }

                listToDT.Rows.Add(values);
            }

            return listToDT;
        }


        // to generate Detail Datagridview with your coding
        public void DetailGrid_Initialize()
        {

            //First generate the grid Layout Design
            Helper.ShanuDGVHelper.Layouts(Detail_shanuDGV, Color.LightSteelBlue, Color.AliceBlue, Color.WhiteSmoke, false, Color.SteelBlue, false, false, false);

            //Set Height,width and add panel to your selected control
            Helper.ShanuDGVHelper.Generategrid(Detail_shanuDGV, this,600, 300, 100, 110);


            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(Detail_shanuDGV, ShanuControlTypes.BoundColumn, "NroOt", "NroOt", "NroOt", true, 130, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // Color Dialog Column creation
            Helper.ShanuDGVHelper.Templatecolumn(Detail_shanuDGV, ShanuControlTypes.BoundColumn, "Serie", "Serie", "Serie", true, 90, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(Detail_shanuDGV, ShanuControlTypes.BoundColumn, "Numero", "Numero", "Numero", true, 90, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(Detail_shanuDGV, ShanuControlTypes.BoundColumn, "SubTotal", "SubTotal", "SubTotal", true, 160, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);

            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(Detail_shanuDGV, ShanuControlTypes.BoundColumn, "IGV", "IGV", "IGV", true, 100, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);
            // BoundColumn creation
            Helper.ShanuDGVHelper.Templatecolumn(Detail_shanuDGV, ShanuControlTypes.BoundColumn, "Total", "Total", "Total", true, 100, DataGridViewTriState.True, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleCenter, Color.Transparent, null, "", "", Color.Black);
          

            objshanudgvHelper.DGVDetailGridClickEvents(Detail_shanuDGV);


        }

      
    }
}
