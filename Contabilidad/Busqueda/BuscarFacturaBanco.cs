using Contabilidad.CtaXcobrar;
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


namespace Contabilidad.Busqueda
{
    public partial class BuscarFacturaBanco : Form
    {
        public static List<FacturaAbono> objListBusquedaTotal = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusqueda = new List<FacturaAbono>();
        FacturaAbono objFacturaAbono;
        BancoDAO objBancoDAO;
        AbonoBanco formAbono;
        Double tipoCambio=1;
        public BuscarFacturaBanco(String codCliente,Double cambio)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objFacturaAbono  = new FacturaAbono();
            formAbono = AbonoBanco.AbonoForm;
            objBancoDAO = new BancoDAO();
            tipoCambio = cambio;
            gridParams();
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            objListBusquedaTotal = objBancoDAO.getFacturaAbono(Ventas.UNIDADNEGOCIO, codCliente);
            listDocumento(objListBusquedaTotal);
            objListBusqueda  = objListBusquedaTotal;
            grdDocumento.CellValueChanged += GrdDocumento_CellValueChanged;
            grdDocumento.DoubleClick += GrdDocumento_DoubleClick;
        }

        private void GrdDocumento_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void GrdDocumento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            int coulmn = e.ColumnIndex;
            if (coulmn ==7)
            {
                objListBusquedaTotal[index].ImporteDolares = 0;
            }
            if (coulmn == 8)
            {
                objListBusquedaTotal[index].ImporteSoles = 0;
            }

            if (objListBusquedaTotal[index].ImporteSoles == 0)
            {
                objListBusquedaTotal[index].ImporteSoles = Math.Round(objListBusquedaTotal[index].ImporteDolares * tipoCambio, 2);
                grdDocumento.DataSource = null;
                grdDocumento.DataSource = objListBusquedaTotal;
                grdDocumento.Refresh();
            }
            if (objListBusquedaTotal[index].ImporteDolares == 0)
            {
                objListBusquedaTotal[index].ImporteDolares = Math.Round(objListBusquedaTotal[index].ImporteSoles / tipoCambio,2);
                grdDocumento.DataSource = null;
                grdDocumento.DataSource = objListBusquedaTotal;
                grdDocumento.Refresh();
            }
            //objListBusquedaTotal = objListBusquedaTotal;
        }

        public void gridParams()
        {

            grdDocumento.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Seleccionar";
            chkColumn.Width = 70;
            chkColumn.DataPropertyName = "chkSelc";
            grdDocumento.Columns.Add(chkColumn);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Width = 60;
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "Serie";
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "Numero";
            idColumn0.Width = 70;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "Fecha";
            idColumn4.Width = 80;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Fecha Vcto";
            idColumn5.DataPropertyName = "FechaVcto";
            idColumn5.Width = 100;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Total";
            idColumn2.DataPropertyName = "Total";
            idColumn0.Width = 70;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Saldo";
            idColumn3.DataPropertyName = "Saldo";
            idColumn3.Width = 70;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn6= new DataGridViewTextBoxColumn();
            idColumn6.Name = "Importe Soles";
            idColumn6.DataPropertyName = "ImporteSoles";
            idColumn6.Width = 95;
            grdDocumento.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Importe Dolares";
            idColumn7.DataPropertyName = "ImporteDolares";
            idColumn7.Width = 95;
            grdDocumento.Columns.Add(idColumn7);

           
            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;
            grdDocumento.Columns[4].ReadOnly = true;
            grdDocumento.Columns[5].ReadOnly = true;
            grdDocumento.Columns[6].ReadOnly = true;
        }

        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();
            objListBusquedaTotal = objListBusqueda.Where(t => t.Numero.Contains(busqueda)).ToList();
            listDocumento(objListBusquedaTotal);
        }
        public void listDocumento(List<FacturaAbono> lista)
        {
            grdDocumento.DataSource = lista;
            grdDocumento.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
            formAbono.setDatos(objListBusquedaTotal);
            this.Close();
        }
    }
}
