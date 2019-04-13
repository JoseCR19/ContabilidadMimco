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

namespace Conta.RegistroVentas
{
    public partial class LibroVentas : Form
    {
        public static List<Ventas> objListVentas = new List<Ventas>();
        Ventas objVentas;
        VentasDAO objVentasDao;
        Proceso objProceso;
        public LibroVentas()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Libro Ventas";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objVentas = new Ventas();
            objVentasDao = new VentasDAO();
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
            if (cmb_Mes.SelectedIndex == -1) /*se coloca -1 porque el array empieza en 0=enero,1=febrero,2=marzo,etc*/
            {
                MessageBox.Show("Debe Seleccionar un MES");/*mensaje de error cuando no esta seleccionado un mes*/
            }
            else
            {
                objListVentas = objVentasDao.listarLibroVentas(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), DateTime.DaysInMonth(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString())).ToString());
                grd_Ventas.DataSource = objListVentas;
                grd_Ventas.Refresh();
                /*foreach (DataGridViewRow row in grd_Ventas.Rows)

                {
                    if (Convert.ToString(row.Cells["Moneda"].Value) == "PEN" && Convert.ToString(row.Cells["TipoCambio"].Value) == "0")
                    {
                        
                        row.Cells["TipoCambio"].Value = "";

                    }


                }*/
            }
            

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            
            String fileName = @"N:\Contabilidad\EXCEL\LibroVentas"+"-"+DateTime.Now.ToString("dd-MM-yyyy")+ "-"+r.Next(1, 30)+ ".xls";
            if (objListVentas.Count == 0)
            {
                MessageBox.Show("No hay registros cargados");
            }
            else
            {
                btn_excel.Enabled = false;
                Conta.Reporte.LibroVentasReporte cr = new Conta.Reporte.LibroVentasReporte();
                cr.SetDataSource(objListVentas);
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

                objVentas = objListVentas[index];

                ReporteView Check = new ReporteView("LV"); // libro ventas
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
            //se genera y se envia la data para generar el txt para ventas
            List<String> aux = objVentasDao.generarTxtVentas(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
            //valores que recibe el generador de txt asientos envia el 05 que es el asiento de libro de ventas y el aux que es la fecha
            String ruta = objProceso.generarTxtAsiento("140100", aux, cmb_Mes.SelectedValue.ToString());
            btn_Txt.Enabled = true;

            /*bool existe = false;
            int soles=0;
            int dolares = 0;
            if (objListVentas.Count == 0)
            {
                MessageBox.Show("No hay registros cargados");
            }
            foreach (DataGridViewRow row in grd_Ventas.Rows)
            {
                if (Convert.ToString(row.Cells["Moneda"].Value) == "PEN" && Convert.ToString(row.Cells["VentasId"].Value ) != "" )
                {
                    soles++;
                    existe = true;
                }
                else if (Convert.ToString(row.Cells["Moneda"].Value) == "USD" && Convert.ToString(row.Cells["VentasId"].Value) != "")
                {
                    dolares++;
                    existe = true;
                }
            }
            if (soles > 0 && dolares > 0)
            {
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para ventas
                List<String> aux = objVentasDao.generarTxtVentasDolares(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> auxsoles = objVentasDao.generarTxtVentasSoles(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 05 que es el asiento de libro de ventas y el aux que es la fecha
                String ruta = objProceso.generarTxtAsientoDolares("140100", aux, cmb_Mes.SelectedValue.ToString());
                String rutasoles = objProceso.generarTxtAsientoSoles("140100", auxsoles, cmb_Mes.SelectedValue.ToString());
                btn_Txt.Enabled = true;
            }
            else if (soles > 0 )
            {
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para ventas
                List<String> auxsoles = objVentasDao.generarTxtVentasSoles(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 05 que es el asiento de libro de ventas y el aux que es la fecha
                String rutasoles = objProceso.generarTxtAsientoSoles("140100", auxsoles, cmb_Mes.SelectedValue.ToString());
                btn_Txt.Enabled = true;
            }
            else if (dolares > 0)
            {
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para ventas
                List<String> aux = objVentasDao.generarTxtVentasDolares(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 05 que es el asiento de libro de ventas y el aux que es la fecha
                String ruta = objProceso.generarTxtAsientoDolares("140100", aux, cmb_Mes.SelectedValue.ToString());
                btn_Txt.Enabled = true;
            }
            else if (dolares == 0 && soles == 0)
            {
                MessageBox.Show("No hay Asientos para exportar");
            }
            if (existe == true)
            {
                MessageBox.Show("Se exportarán "+soles+" de ventas en soles y "+dolares+" de ventas en dolares");
            }

 
            /*
            else { 
        
                btn_Txt.Enabled = false;
                //proceso para convertir el año y año en un string
                DateTime d1 = new DateTime(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString()), 1);
                //proceso para convertir los dias en enteros
                int dias = DateTime.DaysInMonth(d1.Year, d1.Month);
                //se genera y se envia la data para generar el txt para ventas
                List<String> aux = objVentasDao.generarTxtVentasDolares(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                List<String> auxsoles = objVentasDao.generarTxtVentasSoles(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), dias.ToString());
                //valores que recibe el generador de txt asientos envia el 05 que es el asiento de libro de ventas y el aux que es la fecha
                String ruta = objProceso.generarTxtAsientoDolares("140100", aux);
                String rutasoles = objProceso.generarTxtAsientoSoles("140100", auxsoles);
                btn_Txt.Enabled = true;
            }
            */

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContabilidadMenu.formContabilidad.setEnabledItems("LV");
        }

        private void grd_Ventas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void cmb_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LibroVentas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*Función para validar si en el combo de fechas no existe ningun dato*/
            if (cmb_Mes.SelectedIndex == -1) /*se coloca -1 porque el array empieza en 0=enero,1=febrero,2=marzo,etc*/
            {
                MessageBox.Show("Debe Seleccionar un MES");/*mensaje de error cuando no esta seleccionado un mes*/
            }
            else
            {
                objListVentas = objVentasDao.listarLibroVentas(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), DateTime.DaysInMonth(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString())).ToString());
                objListVentas = objVentasDao.listarLibroVentasxsoles(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), DateTime.DaysInMonth(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString())).ToString());
                grd_Ventas.DataSource = objListVentas;
                grd_Ventas.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*Función para validar si en el combo de fechas no existe ningun dato*/
            if (cmb_Mes.SelectedIndex == -1) /*se coloca -1 porque el array empieza en 0=enero,1=febrero,2=marzo,etc*/
            {
                MessageBox.Show("Debe Seleccionar un MES");/*mensaje de error cuando no esta seleccionado un mes*/
            }
            else
            {
                objListVentas = objVentasDao.listarLibroVentas(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), DateTime.DaysInMonth(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString())).ToString());
                objListVentas = objVentasDao.listarLibroVentasxdolares(lbl_anho.Text + cmb_Mes.SelectedValue.ToString(), DateTime.DaysInMonth(Convert.ToInt32(lbl_anho.Text), Convert.ToInt32(cmb_Mes.SelectedValue.ToString())).ToString());
                grd_Ventas.DataSource = objListVentas;
                grd_Ventas.Refresh();
            }
        }
    }
}
