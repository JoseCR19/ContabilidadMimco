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
    public partial class AgregarDetracionFactura : Form
    {
        EmisionVoucher formEmision;

        public static List<FacturaAbono> objListBusquedaTotal = new List<FacturaAbono>();

        public static List<FacturaAbono> objListFacturaAbono = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaRazon = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaRuc = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaNdoc = new List<FacturaAbono>();

        FacturaAbono objFacturaAbono;

        VoucherDAO objVoucherDao;

        public AgregarDetracionFactura(String ruc)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            objListFacturaAbono = objVoucherDao.listarDocumentosFacturaDetraccion(ruc, Ventas.UNIDADNEGOCIO/*,moneda,monedadoc*/);
            grdDocumento.DataSource = objListFacturaAbono;
            objListBusquedaTotal = objListFacturaAbono;
            txt_BuscarDocumentoD.TextChanged += txt_BuscarDocumentoD_TextChanged;
            grdDocumento.Refresh();
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            formEmision.setDatosDetraccionFactura(objListBusquedaTotal);
            this.Close();
        }

        private void txt_BuscarDocumentoD_TextChanged(object sender, EventArgs e)
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
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Selec";
            chkColumn.Width = 50;
            chkColumn.DataPropertyName = "chkSelc";
            grdDocumento.Columns.Add(chkColumn);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();

            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "Serie";
            idColumn0.Width = 60;
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "Numero";
            idColumn1.Width = 70;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "Fecha";
            idColumn4.Width = 80;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Ruc";
            idColumn5.DataPropertyName = "Ruc";
            idColumn5.Width = 80;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.DataPropertyName = "RazonSocial";
            idColumn2.Width = 240;
            grdDocumento.Columns.Add(idColumn2);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DefaultCellStyle.Format = "0.00";
            idColumn3.DataPropertyName = "Total";
            idColumn3.Width = 80;
            grdDocumento.Columns.Add(idColumn3);


            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Moneda";
            idColumn6.DataPropertyName = "MonedaCod";
            idColumn6.Width = 60;
            grdDocumento.Columns.Add(idColumn6);


            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Cambio";
            idColumn8.DataPropertyName = "TipoCambio";
            idColumn3.DefaultCellStyle.Format = "0.000";
            idColumn8.Width = 60;
            grdDocumento.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Soles";
            idColumn9.DataPropertyName = "TotalSoles";
            idColumn9.DefaultCellStyle.Format = "0.00";
            idColumn9.Width = 60;
            grdDocumento.Columns.Add(idColumn9);

            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;
            grdDocumento.Columns[4].ReadOnly = true;
            grdDocumento.Columns[5].ReadOnly = true;
            grdDocumento.Columns[6].ReadOnly = true;

        }

        private void grdDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool tp;
            decimal total=0;
            decimal cambio = 0;
            foreach(DataGridViewRow row in grdDocumento.Rows)
            {
                tp = Convert.ToBoolean(row.Cells[0].Value);
                if(row.Cells[7].Value.ToString()=="USD")
                {
                    if (tp)
                    {
                        total =Convert.ToDecimal(row.Cells[6].Value);
                        cambio = Convert.ToDecimal(row.Cells[8].Value);
                        row.Cells[9].Value =total * cambio;
                    }
                    else
                    {
                        row.Cells[9].Value = "0.00";
                        row.Cells[8].Value = "0.00";
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

        private void grdDocumento_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void grdDocumento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdDocumento_DataError_1(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
