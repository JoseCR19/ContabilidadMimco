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
    public partial class BuscarLetra : Form
    {
        RenovacionLetra renovacionForm;
        DocumentoDAO objDocumentoDao;
        public static List<DocumentoCab> objListDocumentoCab = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaRazon = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaNdoc = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaTotal = new List<DocumentoCab>();
        public BuscarLetra()
        {
            InitializeComponent();
            objDocumentoDao = new DocumentoDAO();
            gridParams();
            objListDocumentoCab = objDocumentoDao.listarLetraCabRenovacion(Ventas.UNIDADNEGOCIO);
            objListBusquedaTotal = objListDocumentoCab;
            listDocumento(objListDocumentoCab);
            renovacionForm = RenovacionLetra.renovForm;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
        }

        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();

            objListBusquedaRazon = objListDocumentoCab.Where(t => t.DocumentoCabCliente.Contains(busqueda)).ToList();
    
            objListBusquedaNdoc = objListDocumentoCab.Where(t => t.DocumentoCabNro.Contains(busqueda)).ToList();
            objListBusquedaTotal =objListBusquedaRazon.Union(objListBusquedaNdoc).ToList();
            listDocumento(objListBusquedaTotal);
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grdDocumento.SelectedCells[0].RowIndex;
                renovacionForm.setDatos(objListBusquedaTotal[index]);
                    this.Close();
            } 
            catch(Exception ex)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
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
            idColumn0.Width = 60;
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "DocumentoCabSerie";
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "DocumentoCabNro";
            idColumn0.Width = 90;
            grdDocumento.Columns.Add(idColumn1);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razon Social";
            idColumn3.DataPropertyName = "DocumentoCabCliente";
            idColumn3.Width = 250;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Monto Letra";
            idColumn2.DataPropertyName = "DocumentoCabAbonoSuma";
            idColumn2.Width = 120;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Total";
            idColumn4.DataPropertyName = "DocumentoCabTotal";
            idColumn4.Width = 120;
            grdDocumento.Columns.Add(idColumn4);
        }
    }
}
