﻿using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using CrystalDecisions.Shared;
using Microsoft.Office.Interop.Excel;
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
    public partial class CuentasPorCobrar : Form
    {
        public static List<FacturaAbono> objListVentas = new List<FacturaAbono>();
         VoucherDAO objVoucherDao;
        public CuentasPorCobrar()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "REPORTE DOCUMENTOS POR COBRAR";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(20, 20);
            cmbUnidadNegocio2();
            gridParams2();
            cbxanio2();
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            gridParams();
            cmbUnidadNegocio();
            objVoucherDao = new VoucherDAO();
            objListVentas = objVoucherDao.ListarCuentasPorCobrarPorVencer(Ventas.UNIDADNEGOCIO, 0);
            grd_Documentos2.DataSource = null;
            grd_Documentos2.DataSource = objListVentas;
            grd_Documentos2.Refresh();
            sumatorias2();

            grd_Documentos.DataSource = objListVentas;
            grd_Documentos.Refresh();
            sumatorias();
            cbxanio();
            cbxmes();
        }
        void cbxmes()
        {
            List<Monthdto> objListMonth = new List<Monthdto>();
            Monthdto objm = new Monthdto();
            objm.MonthD = "Enero";
            objm.value = "01";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();
            
            objm.MonthD = "Febrero";
            objm.value = "02";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Marzo";
            objm.value = "03";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Abril";
            objm.value = "04";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Mayo";
            objm.value = "05";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Junio";
            objm.value = "06";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Julio";
            objm.value = "07";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Agosto";
            objm.value = "08";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Setiembre";
            objm.value = "09";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Octubre";
            objm.value = "10";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Noviembre";
            objm.value = "11";
            objListMonth.Add(objm);

            objm = null;
            objm = new Monthdto();

            objm.MonthD = "Diciembre";
            objm.value = "12";
            objListMonth.Add(objm);

            cbx_mes.DisplayMember = "MonthD";
            cbx_mes.ValueMember = "value";
            cbx_mes.DataSource = objListMonth;
            cbx_mes.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void cbxanio()
        {
            List<Anio> objListAnio =new List<Anio>();
            Anio objA =new Anio();
            objA.anio = "2018";
            objA.value = "2018";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "2019";
            objA.value = "2019";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "2020";
            objA.value = "2020";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "2021";
            objA.value = "2021";
            objListAnio.Add(objA);

            cbx_anio.DisplayMember = "anio";
            cbx_anio.ValueMember = "value";
            cbx_anio.DataSource = objListAnio;
            cbx_anio.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void gridParams()
        {
            grd_Documentos.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Serie";
            idColumn0.Width = 60;
            idColumn0.DataPropertyName = "Serie";
            grd_Documentos.Columns.Add(idColumn0);
            

            DataGridViewTextBoxColumn idColumnRuc = new DataGridViewTextBoxColumn();
            idColumnRuc.Name = "RUC";
            idColumnRuc.Width = 80;
            idColumnRuc.DataPropertyName = "ruc";
            grd_Documentos.Columns.Add(idColumnRuc);


            DataGridViewTextBoxColumn idColumnnro = new DataGridViewTextBoxColumn();
            idColumnnro.Name = "Número";
            idColumnnro.Width = 70;
            idColumnnro.DataPropertyName = "Numero";
            grd_Documentos.Columns.Add(idColumnnro);


            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.Width = 200;
            idColumn2.DataPropertyName = "RazonSocial";
            grd_Documentos.Columns.Add(idColumn2);

            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Fecha";
            idColumn1.Width = 90;
            idColumn1.DataPropertyName = "Fecha";
            grd_Documentos.Columns.Add(idColumn1);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "F. Vcto";
            idColumn3.Width = 80;
            idColumn3.DataPropertyName = "FechaVcto";
            grd_Documentos.Columns.Add(idColumn3);

            DataGridViewTextBoxColumn idColumnMoneda = new DataGridViewTextBoxColumn();
            idColumnMoneda.Name = "Moneda";
            idColumnMoneda.Width = 60;
            idColumnMoneda.DataPropertyName = "MonedaCod";
            idColumnMoneda.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumnMoneda);

            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Total";
            idColumn5.Width = 80;
            idColumn5.DataPropertyName = "Total";
            idColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn5);

            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Saldo";
            idColumn6.Width = 80;
            idColumn6.DataPropertyName = "Saldo";
            idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn6);

            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Total Soles";
            idColumn7.Width = 80;
            idColumn7.DataPropertyName = "Total_soles";
            idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn7);

            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Total Dolares";
            idColumn8.Width = 80;
            idColumn8.DataPropertyName = "Total_dolares";
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Ttipo de Cambio";
            idColumn9.Width = 80;
            idColumn9.DataPropertyName = "Cambio";
            idColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn9);


        }
        void cmbUnidadNegocio()
        {
            List<UnidadNegocio> objList = new List<UnidadNegocio>();
            UnidadNegocio obj = new UnidadNegocio();
            obj.Codigo = "01";
            obj.Negocio = "Metales";
            objList.Add(obj);

            obj = new UnidadNegocio();
            obj.Codigo = "02";
            obj.Negocio = "Galvanizado";
            objList.Add(obj);

            cmb_UnidadNegocio.DataSource = objList;
            cmb_UnidadNegocio.ValueMember = "Codigo";
            cmb_UnidadNegocio.DisplayMember = "Negocio";
            cmb_UnidadNegocio.Refresh();
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
                if (colCount == 6 || colCount == 7)
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
        private void btn_Buscar_Click(object sender, EventArgs e)
        {

            objListVentas = objVoucherDao.ListarCuentasPorCobrar(cmb_UnidadNegocio.SelectedValue.ToString(), cbx_anio.SelectedValue.ToString() + cbx_mes.SelectedValue.ToString() , DateTime.DaysInMonth(Convert.ToInt32(cbx_anio.SelectedValue.ToString()), Convert.ToInt32(cbx_mes.SelectedValue.ToString())).ToString());
            grd_Documentos.DataSource = null;
            grd_Documentos.DataSource = objListVentas;
            grd_Documentos.Refresh();
            sumatorias();



        }

        private void button1_Click(object sender, EventArgs e)
        {




        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("CC");
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {

        }

        void sumatorias()
        {
            txt_Dolares.Text = objListVentas.Where(x => x.MonedaCod == "USD").Sum(x => x.Saldo).ToString("C").Substring(3);
            txt_Total.Text = objListVentas.Where(x => x.MonedaCod == "PEN").Sum(x => x.Saldo).ToString("C").Substring(3);
        }
        void sumatorias2()
        {
            txt_Dolares2.Text = objListVentas.Where(x => x.MonedaCod == "USD").Sum(x => x.Saldo).ToString("C").Substring(3);
            txt_Total2.Text = objListVentas.Where(x => x.MonedaCod == "PEN").Sum(x => x.Saldo).ToString("C").Substring(3);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        void gridParams2()
        {
            grd_Documentos2.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Serie";
            idColumn0.Width = 60;
            idColumn0.DataPropertyName = "Serie";
            grd_Documentos2.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumnRuc = new DataGridViewTextBoxColumn();
            idColumnRuc.Name = "RUC";
            idColumnRuc.Width = 80;
            idColumnRuc.DataPropertyName = "ruc";
            grd_Documentos2.Columns.Add(idColumnRuc);
            DataGridViewTextBoxColumn idColumnnro = new DataGridViewTextBoxColumn();
            idColumnnro.Name = "Número";
            idColumnnro.Width = 70;
            idColumnnro.DataPropertyName = "Numero";
            grd_Documentos2.Columns.Add(idColumnnro);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.Width = 200;
            idColumn2.DataPropertyName = "RazonSocial";
            grd_Documentos2.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Fecha";
            idColumn1.Width = 90;
            idColumn1.DataPropertyName = "Fecha";
            grd_Documentos2.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "F. Vcto";
            idColumn3.Width = 80;
            idColumn3.DataPropertyName = "FechaVcto";
            grd_Documentos2.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumnMoneda = new DataGridViewTextBoxColumn();
            idColumnMoneda.Name = "Moneda";
            idColumnMoneda.Width = 60;
            idColumnMoneda.DataPropertyName = "MonedaCod";
            idColumnMoneda.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos2.Columns.Add(idColumnMoneda);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Total";
            idColumn5.Width = 80;
            idColumn5.DataPropertyName = "Total";
            idColumn5.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos2.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Saldo";
            idColumn6.Width = 80;
            idColumn6.DataPropertyName = "Saldo";
            idColumn6.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos2.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Total Soles";
            idColumn7.Width = 80;
            idColumn7.DataPropertyName = "Total_soles";
            idColumn7.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos2.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Total Dolares";
            idColumn8.Width = 80;
            idColumn8.DataPropertyName = "Total_dolares";
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos2.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Ttipo de Cambio";
            idColumn9.Width = 80;
            idColumn9.DataPropertyName = "Cambio";
            idColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos2.Columns.Add(idColumn9);
        }
        void cbxanio2()
        {
            List<Anio> objListAnio = new List<Anio>();
            Anio objA = new Anio();
            objA.anio = "0";
            objA.value = "0";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "30";
            objA.value = "30";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "45";
            objA.value = "45";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "90";
            objA.value = "90";
            objListAnio.Add(objA);
            objA = null;
            objA = new Anio();

            objA.anio = "120";
            objA.value = "120";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "180";
            objA.value = "180";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            objA.anio = "MAS";
            objA.value = "MAS";
            objListAnio.Add(objA);

            objA = null;
            objA = new Anio();

            cbx_dias.DisplayMember = "anio";
            cbx_dias.ValueMember = "value";
            cbx_dias.DataSource = objListAnio;
            cbx_dias.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        void cmbUnidadNegocio2()
        {
            List<UnidadNegocio> objList = new List<UnidadNegocio>();
            UnidadNegocio obj = new UnidadNegocio();
            obj.Codigo = "01";
            obj.Negocio = "Metales";
            objList.Add(obj);

            obj = new UnidadNegocio();
            obj.Codigo = "02";
            obj.Negocio = "Galvanizado";
            objList.Add(obj);

            cmb_UnidadNegocio2.DataSource = objList;
            cmb_UnidadNegocio2.ValueMember = "Codigo";
            cmb_UnidadNegocio2.DisplayMember = "Negocio";
            cmb_UnidadNegocio2.Refresh();
        }

        private void btn_Buscar2_Click(object sender, EventArgs e)
        {
            objListVentas = objVoucherDao.ListarCuentasPorCobrarPorVencer(cmb_UnidadNegocio2.SelectedValue.ToString(), Convert.ToInt32(cbx_dias.SelectedValue.ToString()));
            grd_Documentos2.DataSource = null;
            grd_Documentos2.DataSource = objListVentas;
            grd_Documentos2.Refresh();
            sumatorias2();
        }

        private void btn_Cerrar_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("CC");
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                ExportToExcelWithFormat_Simple(grd_Documentos2);
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
