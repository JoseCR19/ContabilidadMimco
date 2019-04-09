using ContabilidadDAO;
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
    public partial class AgregarDetracciones : Form
    {
        EmisionVoucher formEmision;
        public static List<ContabilidadDTO.Ventas> objListVentas = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaRazon = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaRuc = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaNdoc = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaTotal = new List<ContabilidadDTO.Ventas>();

        ContabilidadDTO.Ventas ojbVentas;


        VoucherDAO objVoucherDao;
        public AgregarDetracciones()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            objListVentas = objVoucherDao.listarDocumentosVentasDetraccion("NN", Ventas.UNIDADNEGOCIO);
            grdDocumento.DataSource = objListVentas;
            objListBusquedaTotal = objListVentas;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            grdDocumento.Refresh();
        }

        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();
            objListBusquedaRuc = objListVentas.Where(x => x.Ruc.Contains(busqueda)).ToList();
            objListBusquedaRazon = objListVentas.Where(x => x.RazonSocial.Contains(busqueda)).ToList();
            objListBusquedaNdoc = objListVentas.Where(x => x.Numero.Contains(busqueda)).ToList();
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
            idColumn4.DataPropertyName = "FechaEmision";
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
            idColumn2.Width = 250;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Total";
            idColumn3.DefaultCellStyle.Format = "0.00";
            idColumn3.Width = 80;
            grdDocumento.Columns.Add(idColumn3);

            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Moneda";
            idColumn7.DataPropertyName = "Moneda";
            idColumn7.Width = 60;
            grdDocumento.Columns.Add(idColumn7);

            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Cambio";
            idColumn6.DataPropertyName = "TipoCambio";
            idColumn6.Width = 80;
            grdDocumento.Columns.Add(idColumn6);

            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Importe Soles";
            idColumn8.DataPropertyName = "TotalSoles";
            idColumn8.DefaultCellStyle.Format = "0.00";
            idColumn8.Width = 80;
            grdDocumento.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "OT";
            idColumn9.DataPropertyName = "CodOt";
            idColumn9.Width = 80;
            grdDocumento.Columns.Add(idColumn9);


            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "NroOt";
            idColumn10.DataPropertyName = "NroOt";
            idColumn10.Width = 80;
            grdDocumento.Columns.Add(idColumn10);

            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "DirOt";
            idColumn11.DataPropertyName = "DirOt";
            idColumn11.Width = 80;
            grdDocumento.Columns.Add(idColumn11);

            DataGridViewTextBoxColumn idColumn12 = new DataGridViewTextBoxColumn();
            idColumn12.Name = "Documento";
            idColumn12.DataPropertyName = "TipoDocumento";
            idColumn12.Width = 80;
            grdDocumento.Columns.Add(idColumn12);


            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;
            grdDocumento.Columns[4].ReadOnly = true;
            grdDocumento.Columns[5].ReadOnly = true;
            grdDocumento.Columns[10].Visible = false;
            grdDocumento.Columns[11].Visible = false;
            grdDocumento.Columns[12].Visible = false;
            grdDocumento.Columns[13].Visible = false;







        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            formEmision.setDatosDetraccionCajaChica(objListBusquedaTotal);
            this.Close();
        }

        private void btn_Aceptar_Click_1(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            formEmision.setDatosDetraccionCajaChica(objListBusquedaTotal);
            this.Close();
        }

        private void grdDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*bool tp;
            foreach(DataGridViewRow row in grdDocumento.Rows)
            {
                tp = Convert.ToBoolean(row.Cells[0].Value);
                if(row.Cells[])
                if(tp)
                {

                }
            }*/
        }
        public void multiplica()
        {
            bool tp;
            decimal total = 0;
            decimal cambio = 0;
            foreach (DataGridViewRow row in grdDocumento.Rows)
            {
                tp = Convert.ToBoolean(row.Cells[0].Value);
                if (row.Cells[7].Value.ToString() == "USD")
                {
                    if (tp)
                    {
                        total = Convert.ToDecimal(row.Cells[6].Value);
                        cambio = Convert.ToDecimal(row.Cells[8].Value);
                        row.Cells[9].Value = total * cambio;
                    }
                    else
                    {
                        row.Cells[9].Value = "0.00";
                    }
                }

            }
        }
        private void grdDocumento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            multiplica();
        }
    }
}
