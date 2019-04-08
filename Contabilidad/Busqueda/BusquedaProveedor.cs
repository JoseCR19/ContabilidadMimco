using ContabilidadDAO;
using ContabilidadDTO;
using Contabilidad.Reporte;
using Contabilidad.Facturacion;
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
    public partial class BusquedaProveedor : Form
    {
        public Retencion formRetencion;
        public CanjeLetraNuevo formCajaLetra;
        public ReporteFacturaProveeodr formReporte;
        public ReporteVoucher formCheques;
        public static string TipoDocumento;
        ProveedorDAO objProveedorDAO;
        public static List<Proveedor> objListProveedor = new List<Proveedor>();
        public static List<Proveedor> objListBusquedaRazon = new List<Proveedor>();
        public static List<Proveedor> objListBusquedaRuc = new List<Proveedor>();
        public static List<Proveedor> objListBusquedaTotal = new List<Proveedor>();
        public BusquedaProveedor(String DocumentoTipo)
        {
            InitializeComponent();
            objProveedorDAO = new ProveedorDAO();
            TipoDocumento = DocumentoTipo;
            formRetencion = Retencion.retencionForm;
            formCajaLetra = CanjeLetraNuevo.canjeletranuevo;
            formReporte = ReporteFacturaProveeodr.formReporteProveedor;
            formCheques = ReporteVoucher.formReporteCheques;
            objListProveedor = objProveedorDAO.listarProveedor();
            objListBusquedaTotal = objListProveedor;
            gridParams();
            listProveedor(objListProveedor);
            txt_BuscarCliente.TextChanged += Txt_BuscarCliente_TextChanged;
        }
        private void Txt_BuscarCliente_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarCliente.Text.ToUpper();

            objListBusquedaRazon = objListProveedor.Where(t => t.ProveedorRazonSocial.Contains(busqueda)).ToList();
            objListBusquedaRuc = objListProveedor.Where(t => t.ProveedorNDoc.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).ToList();
            listProveedor(objListBusquedaTotal);
        }
        public void gridParams()
        {
            grdCliente.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.DataPropertyName = "ProveedorNDoc";
            grdCliente.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.DataPropertyName = "ProveedorRazonSocial";
            idColumn2.Width = 260;
            grdCliente.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Direccion";
            idColumn3.DataPropertyName = "ProveedorDireccion";
            idColumn3.Width = 320;
            grdCliente.Columns.Add(idColumn3);
        }
        public void listProveedor(List<Proveedor> lista)
        {
            grdCliente.DataSource = lista;
            grdCliente.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grdCliente.SelectedCells[0].RowIndex;
                if(TipoDocumento == "RT")
                {
                    formRetencion.setDatos(objListBusquedaTotal[index]);
                }
                else if (TipoDocumento == "CL")
                {
                    formCajaLetra.setDatos(objListBusquedaTotal[index]);
                }
                else if (TipoDocumento == "PV")
                {
                    formReporte.setDatos(objListBusquedaTotal[index]);
                }
                else if(TipoDocumento =="CH")
                {
                    formCheques.setDatos(objListBusquedaTotal[index]);
                }
                this.Close();
            }
            catch
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }
    }
}
