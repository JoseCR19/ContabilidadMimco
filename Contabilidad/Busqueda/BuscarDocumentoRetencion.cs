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
    public partial class BuscarDocumentoRetencion : Form
    {
        Retencion formRetencion;
        DocumentoDAO objDocumentoDao;
        public static List<DocumentoCab> objListDocumentoCab = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaNdoc = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaTotal = new List<DocumentoCab>();
        public BuscarDocumentoRetencion(String tipoDocumento, String ruc )
        {
            InitializeComponent();
            formRetencion = Retencion.retencionForm;
            objDocumentoDao = new DocumentoDAO();
            objListDocumentoCab = objDocumentoDao.buscarDocumentosNotas(tipoDocumento, Ventas.UNIDADNEGOCIO, ruc);
            objListBusquedaTotal = objListDocumentoCab;
            gridParams();
            listDocumento(objListDocumentoCab);
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
        }
        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();

             objListBusquedaNdoc = objListDocumentoCab.Where(t => t.DocumentoCabNro.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListDocumentoCab.Union(objListBusquedaNdoc).ToList();
            listDocumento(objListBusquedaTotal);
        }

        public void listDocumento(List<DocumentoCab> lista)
        {
            grdDocumento.DataSource = lista;
            grdDocumento.Refresh();
        }
        public void gridParams()
        {
            grdDocumento.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Width = 70;
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "DocumentoCabSerie";
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "DocumentoCabNro";
            idColumn0.Width = 100;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "RUC";
            idColumn2.DataPropertyName = "DocumentoCabClienteDocumento"; 
            idColumn0.Width = 80;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razon Social";
            idColumn3.DataPropertyName = "DocumentoCabCliente";
            idColumn3.Width = 270;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Total";
            idColumn4.DataPropertyName = "DocumentoCabTotal";
            idColumn4.Width = 120;
            grdDocumento.Columns.Add(idColumn4);
        }
        private void btn_Aceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
