using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Caja
{
    public partial class AgregarAbonoFactura : Form
    {
        EmisionVoucher formEmision;

        public static List<FacturaAbono> objListBusquedaTotal = new List<FacturaAbono>();

        public static List<FacturaAbono> objListFacturaAbono = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaRazon = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaRuc = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaNdoc = new List<FacturaAbono>();
        VoucherDAO objVoucherDao;
        String monedavalor = "";

        public AgregarAbonoFactura(String ruc/*,String moneda*/,String monedadoc)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            objListFacturaAbono = objVoucherDao.listarDocumentosAbonoVoucher(ruc, Ventas.UNIDADNEGOCIO/*,moneda,monedadoc*/);
            grdDocumento.DataSource = objListFacturaAbono;
            objListBusquedaTotal = objListFacturaAbono;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            monedavalor = monedadoc;
            grdDocumento.Refresh();
            btn_Aceptar.Enabled = true;
        }
        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();
            objListBusquedaRuc = objListFacturaAbono.Where(x => x.Ruc.Contains(busqueda)).ToList();
            objListBusquedaRazon = objListFacturaAbono.Where(x => x.RazonSocial.Contains(busqueda)).ToList();
            objListBusquedaNdoc = objListFacturaAbono.Where(x => x.Numero.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).Union(objListBusquedaNdoc).ToList();
            grdDocumento.DataSource = null;
            grdDocumento.DataSource = objListBusquedaTotal;
            grdDocumento.Refresh();
        }
        public void gridParams()
        {
            
            grdDocumento.AutoGenerateColumns = false;
            //*0*//
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Selec";
            chkColumn.Width = 50;
            chkColumn.DataPropertyName = "chkSelc";
            grdDocumento.Columns.Add(chkColumn);
            //*1*//
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "Serie";
            idColumn0.Width = 60;
            grdDocumento.Columns.Add(idColumn0);
            /*02*/
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "Numero";
            idColumn1.Width = 70;
            grdDocumento.Columns.Add(idColumn1);
            /*03*/
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "Fecha";
            idColumn4.Width = 80;
            grdDocumento.Columns.Add(idColumn4);
            /*04*/
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Ruc";
            idColumn5.DataPropertyName = "Ruc";
            idColumn5.Width = 80;
            grdDocumento.Columns.Add(idColumn5);
            /*05*/
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.DataPropertyName = "RazonSocial";
            idColumn2.Width = 240;
            grdDocumento.Columns.Add(idColumn2);
            /*06*/
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Moneda";
            idColumn6.DataPropertyName = "MonedaCod";
            idColumn6.Width = 60;
            grdDocumento.Columns.Add(idColumn6);
            /*07*/
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Importe Facturado";
            idColumn9.DataPropertyName = "Total";
            idColumn9.DefaultCellStyle.Format = "0.00";
            idColumn9.Width = 100;
            grdDocumento.Columns.Add(idColumn9);
            /*08*/
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Saldo Facturado";
            idColumn3.DataPropertyName = "Total_Detraccion";
            idColumn3.DefaultCellStyle.Format = "0.00";
            idColumn3.Width = 100;
            grdDocumento.Columns.Add(idColumn3);
            /*09*/
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Importe Detración";
            idColumn10.DataPropertyName = "ImporteDetraccion";
            idColumn10.DefaultCellStyle.Format = "0.00";
            idColumn10.Width = 100;
            grdDocumento.Columns.Add(idColumn10);
            /*10*/
            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "Saldo Detración";
            idColumn11.DataPropertyName = "SaldoDetraccion";
            idColumn11.DefaultCellStyle.Format = "0.00";
            idColumn11.Width = 100;
            grdDocumento.Columns.Add(idColumn11);
            /*11*/
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Cambio";
            idColumn8.DataPropertyName = "TipoCambio";
            idColumn3.DefaultCellStyle.Format = "0.000";
            idColumn8.Width = 60;
            grdDocumento.Columns.Add(idColumn8);
            /*12*/
            DataGridViewTextBoxColumn idColumnPago = new DataGridViewTextBoxColumn();
            idColumnPago.Name = "Pago";
            idColumnPago.DataPropertyName = "Pago";
            idColumnPago.DefaultCellStyle.Format = "0.00";
            idColumnPago.Width = 80;
            grdDocumento.Columns.Add(idColumnPago);

            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;
            grdDocumento.Columns[4].ReadOnly = true;
            grdDocumento.Columns[5].ReadOnly = true;
            grdDocumento.Columns[6].ReadOnly = true;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            formEmision.setDatosAbonoFactura(objListBusquedaTotal);
            this.Close();
        }

        private void grdDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool hola;
            decimal total = 0;
            decimal cambio = 0;
            decimal detraccion = 0;
            foreach (DataGridViewRow row in grdDocumento.Rows)
            {
                hola = Convert.ToBoolean(row.Cells[0].Value);
                /*comparamos si la moneda que viene del emisor voucher es dolares o soles que no convierta pero si la moneda es diferente que lo convierta*/
                /*10 moneda*/
                if(monedavalor == row.Cells[6].Value.ToString())
                {
                    if (hola)
                    {
                        /*saldo facturado*/
                        total = Convert.ToDecimal(row.Cells[8].Value);
                        /* saldo detraccion*/
                        detraccion = Convert.ToDecimal(row.Cells[10].Value);
                        /*pago*/
                        row.Cells[12].Value = total+ detraccion;
                    }
                    else
                    {

                        /*pago*/
                        row.Cells[12].Value = "0.00";
                    }
                }
                else
                {
                    /*moneda*/
                    if (row.Cells[6].Value.ToString() == "USD")
                    {
                        if (hola)
                        {
                            /*asldo facturtado*/
                            total = Convert.ToDecimal(row.Cells[8].Value);
                            /*Saldo Detraccion*/
                            detraccion = Convert.ToDecimal(row.Cells[10].Value);
                            /*Cambio*/
                            cambio = Convert.ToDecimal(row.Cells[11].Value);
                            /*Pago*/
                            row.Cells[12].Value = total * cambio;
                            //row.Cells[7].Value = row.Cells[6].Value;
                        }
                        else
                        {

                            row.Cells[12].Value = "0.00";
                        }
                    }
                    else
                    {
                        if (hola)
                        {
                            /*Saldo Facturado*/
                            total = Convert.ToDecimal(row.Cells[8].Value);
                            /*Saldo Detraccion*/
                            detraccion = Convert.ToDecimal(row.Cells[10].Value);
                            /*Cambio*/
                            cambio = Convert.ToDecimal(row.Cells[11].Value);
                            /*Pago*/
                            row.Cells[12].Value = total / cambio;
                            //row.Cells[7].Value = row.Cells[6].Value;
                        }
                        else
                        {
                            /*Pago*/
                            row.Cells[12].Value = "0.00";
                        }
                    }

                }
            }

        }
        private void grdDocumento_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdDocumento.IsCurrentCellDirty)
            {
                grdDocumento.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void grdDocumento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void grdDocumento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdDocumento_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdDocumento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


            /*DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "Saldo Detración")  //Si es la columna a evaluar
            {
                if (e.Value.ToString().Contains("0"))   //Si el valor de la celda contiene la palabra hora
                {
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            /*
            foreach (DataGridViewRow row in grdDocumento.Rows)
            {

                if (Convert.ToInt32(row.Cells["Saldo Detración"].Value) <= 0)
                {
                    columns  row.DefaultCellStyle.BackColor = Color.Red;
                }
            }

            /*
            if (objListFacturaAbono.Count > 0)
            {
                if (grdDocumento["Saldo Detración", e.RowIndex].Value.ToString() == grdDocumento["Importe Detración", e.RowIndex].Value.ToString())
                {

                    e.CellStyle.ForeColor = Color.Blue;
                }
                else
                {
                    e.CellStyle.ForeColor = Color.Green;
                }

            }*/
        }
    }
}
