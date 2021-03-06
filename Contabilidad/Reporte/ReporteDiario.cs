﻿using System;
using ContabilidadDTO;
using ContabilidadDAO;
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
    public partial class ReporteDiario : Form
    {
        public static List<FacturaRC> objListaFactura = new List<FacturaRC>();
        public static List<ReporteFacturaC> objListaReporte = new List<ReporteFacturaC>();
        public static List<FacturaRC> objListBusquedaTotal = new List<FacturaRC>();
        ReporteFacturaC objReporte;
        VoucherDAO objVoucherDAO;
        public ReporteDiario()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Reporte Diario";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 10);
            objVoucherDAO = new VoucherDAO();
            //objListBusquedaTotal = objListaReporte;
            gridParams();
            /*objListaFactura = objVoucherDAO.FacturaCReporte(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value);*/
            grd_Voucher.DataSource = objListaFactura;
            objListBusquedaTotal = objListaFactura;
            grd_Voucher.Refresh();
            impresos();

        }
        void impresos()
        {
            foreach (DataGridViewRow row in grd_Voucher.Rows)
            {
                if (Convert.ToString(row.Cells["ESTADO"].Value) == "NO SE IMPRIMIO")
                {

                }
                else 
                {
                    row.ReadOnly = true; 
                }
            }
        }
        public void gridParams()
        {
            grd_Voucher.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Est";
            chkColumn.Width = 50;
            chkColumn.DataPropertyName = "chkSelc";
            grd_Voucher.Columns.Add(chkColumn);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "FechaDoc";
            idColumn0.Width = 70;
            idColumn0.DataPropertyName = "FechaEmision";
            grd_Voucher.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "FechaVen";
            idColumn1.DataPropertyName = "FechaVencimiento";
            idColumn1.Width = 70;
            grd_Voucher.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Factura";
            idColumn3.DataPropertyName = "TSD";
            idColumn3.Width = 110;
            grd_Voucher.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "RUC";
            idColumn4.DataPropertyName = "Ruc";
            idColumn4.Width = 75;
            grd_Voucher.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Razon Social";
            idColumn5.Width = 250;
            idColumn5.DataPropertyName = "RazonSocial";
            grd_Voucher.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Moneda";
            idColumn6.DataPropertyName = "Moneda";
            idColumn6.Width = 70;
            grd_Voucher.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "TC";
            idColumn7.DataPropertyName = "TC";
            idColumn7.Width = 40;
            grd_Voucher.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Total";
            idColumn8.DataPropertyName = "Total";
            idColumn8.Width = 70;
            idColumn8.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Abono";
            idColumn9.DataPropertyName = "";
            idColumn9.Width = 70;
            idColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Saldo";
            idColumn10.DataPropertyName = "Total";
            idColumn10.Width = 70;
            idColumn10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn10);
            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "Fecha Entrega";
            idColumn11.DataPropertyName = "FEntrega";
            idColumn11.Width = 70;
            idColumn11.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn11);
            DataGridViewTextBoxColumn idColumn12 = new DataGridViewTextBoxColumn();
            idColumn12.Name = "Hora Entrega";
            idColumn12.DataPropertyName = "HoraEntrega";
            idColumn12.Width = 70;
            idColumn12.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn12);
            DataGridViewTextBoxColumn idColumn13 = new DataGridViewTextBoxColumn();
            idColumn13.Name = "ESTADO";
            idColumn13.DataPropertyName = "Print";
            idColumn13.Width = 120;
            idColumn13.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn13);
            //grd_Voucher.Columns[0].ReadOnly = false;
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
            Ventas.formVentas.setEnabledItems("RPD");
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            objListaFactura = objVoucherDAO.FacturaCReporte(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value);
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListaFactura;
            objListBusquedaTotal = objListaFactura;
            grd_Voucher.Refresh();
            impresos();
        }

        private void grd_Voucher_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void grd_Voucher_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grd_Voucher.IsCurrentCellDirty)
            {
                grd_Voucher.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        public void setDatos(List<ContabilidadDTO.FacturaRC> objList)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                objReporte = new ReporteFacturaC();
                objReporte.FechaEmision = objList[i].FechaEmision;
                objReporte.FechaVencimiento = objList[i].FechaVencimiento;
                objReporte.TSD = objList[i].TSD;
                objReporte.Ruc = objList[i].Ruc+" "+ objList[i].RazonSocial;
                objReporte.Moneda = objList[i].Moneda;
                objReporte.TC = objList[i].TC;
                objReporte.Total = objList[i].Total;
                objReporte.Abono = objList[i].Abono;
                objReporte.Saldo = objList[i].Total;
                objReporte.Usuario = Ventas.UsuarioSession;
                objReporte.FechaEntrega = objList[i].FechaEntrega.Substring(0,16);
                objListaReporte.Add(objReporte);
                objVoucherDAO.ActualizarEstadoPrint(objList[i].NroRegistro, "X", Ventas.UsuarioSession);
            }

        }
        public void setDatos2(List<ContabilidadDTO.FacturaRC> objList)
        {
            for (int i = 0; i < objList.Count; i++)
            {
                objReporte = new ReporteFacturaC();
                objReporte.FechaEmision = objList[i].FechaEmision;
                objReporte.FechaVencimiento = objList[i].FechaVencimiento;
                objReporte.TSD = objList[i].TSD;
                objReporte.Ruc = objList[i].Ruc + " " + objList[i].RazonSocial;
                objReporte.Moneda = objList[i].Moneda;
                objReporte.TC = objList[i].TC;
                objReporte.Total = objList[i].Total;
                objReporte.Abono = objList[i].Abono;
                objReporte.Saldo = objList[i].Total;
                objReporte.Usuario = Ventas.UsuarioSession;
                objReporte.FechaEntrega = objList[i].FechaEntrega.Substring(0, 16);
                objListaReporte.Add(objReporte);
            }

        }
        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();

            setDatos2(objListBusquedaTotal);
            btn_Reporte.Enabled = false;
            //formatearReporte();
            ReporteView Check = new ReporteView("RDC"); // ExcelFecha
            Check.Show();
            btn_Reporte.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            setDatos(objListBusquedaTotal);
            btn_Reporte.Enabled = false;
            //formatearReporte();
            ReporteView Check = new ReporteView("RDC"); // ExcelFecha
            Check.Show();
            btn_Reporte.Enabled = true;
        }


        private void ReporteDiario_Load(object sender, EventArgs e)
        {
        }

        private void grd_Voucher_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (objListaFactura.Count > 0)
            {
                if (grd_Voucher["ESTADO", e.RowIndex].Value.ToString() == "SE IMPRIMIO")
                {
                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }

            }

        }
    }
}
