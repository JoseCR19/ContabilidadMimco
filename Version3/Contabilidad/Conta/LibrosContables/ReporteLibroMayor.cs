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


namespace Conta.LibrosContables
{
    public partial class ReporteLibroMayor : Form
    {
        public ReporteLibroMayor()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Libro Diario";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            grd_Ventas.DataSource = LibrosContables.LibroMayor.objListaLibroMayor;
            grd_Ventas.Refresh();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            LibrosContables.LibroMayor check = new LibroMayor();
            check.Show();
            this.Hide();
        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Reporte.Enabled = false;
                int index = grd_Ventas.SelectedCells[0].RowIndex;


                ReporteView Check = new ReporteView("LM"); // libro ventas
                Check.Show();
                btn_Reporte.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_Reporte.Enabled = true;
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            Random r = new Random();

            String fileName = @"N:\Contabilidad\EXCEL\LibroMayor" + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + r.Next(1, 30) + ".xls";
            if (LibroMayor.objListaLibroMayor.Count == 0)
            {
                MessageBox.Show("No hay registros cargados");
            }
            else
            {
                btn_excel.Enabled = false;
                Conta.Reporte.LibroMayorReporteExcel cr = new Conta.Reporte.LibroMayorReporteExcel();
                cr.SetDataSource(LibroMayor.objListaLibroMayor);
                ExportOptions exportOpts = new ExportOptions();
                ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
                DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
                exportOpts = cr.ExportOptions;

                // Set the excel format options.
                excelFormatOpts.ExcelUseConstantColumnWidth = true;
                excelFormatOpts.ExcelTabHasColumnHeadings = true;
                excelFormatOpts.ShowGridLines = true;
                excelFormatOpts.ExportPageBreaksForEachPage = true;
                //excelFormatOpts.UsePageRange = true;

                exportOpts.ExportFormatType = ExportFormatType.Excel;
                exportOpts.FormatOptions = excelFormatOpts;

                // Set the disk file options and export.
                exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
                diskOpts.DiskFileName = fileName;
                exportOpts.DestinationOptions = diskOpts;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                cr.Export();



                btn_excel.Enabled = true;
            }
        }
    }
}
