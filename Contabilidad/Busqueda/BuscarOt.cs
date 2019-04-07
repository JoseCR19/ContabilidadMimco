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
    public partial class BuscarOt : Form
    {
        Factura facturaForm;
        OtDAO objOtDAO;
        public static List<OtDTO> objListOt = new List<OtDTO>();
        public static List<OtDTO> objListBusquedaNro = new List<OtDTO>();
        public static List<OtDTO> objListBusquedaTotal = new List<OtDTO>();
        OtDTO objOt;
        public BuscarOt(String cliente)
        {
            InitializeComponent();
            objOt = new OtDTO();
            objOtDAO = new OtDAO();
            gridParams();
            objListOt = objOtDAO.listarOtPago(Ventas.UNIDADNEGOCIO, cliente);
            grdOt.DataSource = objListOt;
            facturaForm = Factura.formFactura;
            grdOt.DoubleClick += GrdOt_DoubleClick;
            grdOt.CellClick += GrdOt_CellClick;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            objListBusquedaTotal = objListOt;
        }

        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();

            objListBusquedaTotal = objListOt.Where(t => t.NumeroOt.Contains(busqueda)).ToList();
            grdOt.DataSource = null;
            grdOt.DataSource = objListBusquedaTotal;
            grdOt.Refresh();


        }

        private void GrdOt_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = grdOt.SelectedCells[0].RowIndex;
               
            }
            catch
            {
                
            }
        }

        private void GrdOt_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int index = grdOt.SelectedCells[0].RowIndex;
                facturaForm.setOtDatos(objListBusquedaTotal[index].Importe.ToString(), objListBusquedaTotal[index].NumeroOt + "-"
                    + objListBusquedaTotal[index].Porcentaje + "%", objListBusquedaTotal[index].Tabla, objListBusquedaTotal[index].Item, objListBusquedaTotal[index].CuentaContable,
                     objListBusquedaTotal[index].UnidadMedida, objListBusquedaTotal[index].ProductoCodigo, objListBusquedaTotal[index].NumeroOt,
                    objListBusquedaTotal[index].ProductoDescripcion);
                this.Close();
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }

        public void gridParams()
        {
            grdOt.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Nro OT";
            idColumn1.Width = 150;
            idColumn1.DataPropertyName = "NumeroOt";
            grdOt.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Porcentaje";
            idColumn2.DataPropertyName = "Porcentaje";
            idColumn2.Width = 150;
            grdOt.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.Width = 150;
            grdOt.Columns.Add(idColumn3);
        }

        private void txt_BuscarDocumento_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
