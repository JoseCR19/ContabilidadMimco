using ContaDAO;
using ContaDTO;
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

namespace Conta.RegistroCompras
{
    public partial class LibroCompras : Form
    {
        public static List<Compras> objListCompras = new List<Compras>();
        Compras objCompras;
        ComprasDAO objComprasDao;
        Proceso objProceso;
        public LibroCompras()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Libro Compras";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objCompras = new Compras();
            objComprasDao = new ComprasDAO();
            objProceso = new Proceso();
            lbl_anho.Text = DateTime.Now.Year.ToString();
            cmbMes();

        }

        void cmbMes()
        {
            List<MesDTO> objListMes = new List<MesDTO>();
            MesDTO objMes = new MesDTO();
            objMes.Month = "Enero";
            objMes.Value = "01";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Febrero";
            objMes.Value = "02";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Marzo";
            objMes.Value = "03";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Abril";
            objMes.Value = "04";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Mayo";
            objMes.Value = "05";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Junio";
            objMes.Value = "06";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Julio";
            objMes.Value = "07";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Agosto";
            objMes.Value = "08";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Septiembre";
            objMes.Value = "09";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Octubre";
            objMes.Value = "10";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Noviembre";
            objMes.Value = "11";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Diciembre";
            objMes.Value = "12";
            objListMes.Add(objMes);
            cmb_Mes.DisplayMember = "Month";
            cmb_Mes.ValueMember = "Value";
            cmb_Mes.DataSource = objListMes;
            cmb_Mes.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            /*Función para validar si en el combo de fechas no existe ningun dato*/
            if (cmb_Mes.SelectedIndex == -1)/*se coloca -1 porque el array empieza en 0=enero,1=febrero,2=marzo,etc*/
            {
                MessageBox.Show("Debe Seleccionar un MES");/*mensaje de error cuando no esta seleccionado un mes*/
            }
            else
            {

                objListCompras = objComprasDao.listarLibroCompras(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), DateTime.DaysInMonth(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString())).ToString());
                grd_Ventas.DataSource = objListCompras;
                grd_Ventas.Refresh();
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContabilidadMenu.formContabilidad.setEnabledItems("LC");
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
           Random r = new Random();

            String fileName = @"N:\Contabilidad\EXCEL\LibroCompras" + "-" + DateTime.Now.ToString("dd-MM-yyyy") + "-" + r.Next(1, 30) + ".xls";
            if (objListCompras.Count == 0)
            {
                MessageBox.Show("No hay registros cargados");
            }
            else
            {
                btn_excel.Enabled = false;
                Conta.Reporte.LibroComprasReportePdf cr = new Conta.Reporte.LibroComprasReportePdf();
                cr.SetDataSource(objListCompras);
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

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Reporte.Enabled = false;
                int index = grd_Ventas.SelectedCells[0].RowIndex;

                objCompras = objListCompras[index];

                ReporteView Check = new ReporteView("LC"); // libro ventas
                Check.Show();
                btn_Reporte.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_Reporte.Enabled = true;
            }
        }

        private void btn_Txt_Click(object sender, EventArgs e)
        {

            btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para compras
                //List<String> aux = objComprasDao.generarTxtCompras(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> auxdolares = objComprasDao.generarTxtCompras(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 11 que es el asiento de libro de compras y el aux que es la fecha

                String rutadolares = objProceso.generarTxtAsiento("080100", auxdolares, cmb_Mes.SelectedValue.ToString());
            btn_Txt.Enabled = true;
            /*bool existe = false;
            int soles = 0;
            int dolares = 0;
            if (objListCompras.Count == 0)
            {
                MessageBox.Show("No hay registros cargados");
            }
            foreach (DataGridViewRow row in grd_Ventas.Rows)/*recorremos la tabla
            {
                if (Convert.ToString(row.Cells["Moneda"].Value) == "1" && Convert.ToString(row.Cells["ComprasId"].Value) != "")
                {
                    soles++;
                    existe = true;
                }
                else if (Convert.ToString(row.Cells["Moneda"].Value) == "2" && Convert.ToString(row.Cells["ComprasId"].Value) !="")
                {
                    dolares++;
                    existe = true;
                }
            }
            if (soles == 0 && dolares == 0)
            {
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para compras
                //List<String> aux = objComprasDao.generarTxtCompras(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> aux = objComprasDao.generarTxtCompraSoles(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> auxdolares = objComprasDao.generarTxtCompraDolares(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 11 que es el asiento de libro de compras y el aux que es la fecha
                String rutasoles = objProceso.generarTxtAsientoCompraSoles("080100", aux, cmb_Mes.SelectedValue.ToString());
                String rutadolares = objProceso.generarTxtAsientoCompraDolares("080100", auxdolares, cmb_Mes.SelectedValue.ToString());

                btn_Txt.Enabled = true;
            }
            /*else if (soles == 0)
            {
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para compras
                //List<String> aux = objComprasDao.generarTxtCompras(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> aux = objComprasDao.generarTxtCompraSoles(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 11 que es el asiento de libro de compras y el aux que es la fecha
                String rutasoles = objProceso.generarTxtAsientoCompraSoles("080100", aux, cmb_Mes.SelectedValue.ToString());

                btn_Txt.Enabled = true;
            }
            else if (dolares >= 0)
            {
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para compras
                //List<String> aux = objComprasDao.generarTxtCompras(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> auxdolares = objComprasDao.generarTxtCompraDolares(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 11 que es el asiento de libro de compras y el aux que es la fecha

                String rutadolares = objProceso.generarTxtAsientoCompraDolares("080100", auxdolares, cmb_Mes.SelectedValue.ToString());
            }*/
            /*else if (dolares == 0 && soles == 0)
            {
                MessageBox.Show("No hay Asientos para exportar");
            }
            if (existe == true)
            {
                MessageBox.Show("Se exportará" + soles + "de Compras en soles y" + dolares + "de compras en dolares");
            }*/

        }
    }
}
