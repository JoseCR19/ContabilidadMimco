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

namespace Contabilidad
{
    public partial class BuscarDocumento : Form
    {
        public NotaDeCredito formCre;
        public NotaDeDebito formDeb;
        public LetraCambio formLetraCambio;
        public static string TipoDocumento;
        DocumentoDAO objDocumentoDao;

        public static List<DocumentoCab> objListDocumentoCab = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaRazon = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaRuc = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaNdoc = new List<DocumentoCab>();
        public static List<DocumentoCab> objListBusquedaTotal = new List<DocumentoCab>();
        String codClie = "NN";

        public BuscarDocumento(String tipoDocumento, String Documento)
        {
            InitializeComponent();
            TipoDocumento = Documento;
            if (Documento == "C")
            {
                formCre = NotaDeCredito.creditoForm;
            }
            else if (Documento == "D")
            {
                formDeb = NotaDeDebito.debitoForm;
            }
            else if (Documento == "T")
            {
                formLetraCambio = LetraCambio.letraCambioForm;
                codClie = LetraCambio.codigoCliente;
            }

            objDocumentoDao = new DocumentoDAO();
            objListDocumentoCab = objDocumentoDao.buscarDocumentosNotas(tipoDocumento, Ventas.UNIDADNEGOCIO, codClie);
            objListBusquedaTotal = objListDocumentoCab;
            gridParams();
            listDocumento(objListDocumentoCab);
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
        }

        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();

            objListBusquedaRazon = objListDocumentoCab.Where(t => t.DocumentoCabCliente.Contains(busqueda)).ToList();
            objListBusquedaRuc = objListDocumentoCab.Where(t => t.DocumentoCabClienteDocumento.Contains(busqueda)).ToList();
            objListBusquedaNdoc = objListDocumentoCab.Where(t => t.DocumentoCabNro.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).Union(objListBusquedaNdoc).ToList();
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
            try
            {
                int index = grdDocumento.SelectedCells[0].RowIndex;

                switch (TipoDocumento)
                {
                    case "C":
                        formCre.setDatosDocumento(objListBusquedaTotal[index].DocumentoCabSerie,
              objListBusquedaTotal[index].DocumentoCabNro, objListBusquedaTotal[index].DocumentoCabCliente, objListBusquedaTotal[index].DocumentoCabClienteDireccion,
              objListBusquedaTotal[index].DocumentoCabFecha, objListBusquedaTotal[index].DocumentoCabClienteDocumento, objListBusquedaTotal[index].DocumentoCabTipoMoneda,
              objListBusquedaTotal[index].DocumentoCabGlosa, objListBusquedaTotal[index].DocumentoCabClienteCod, objListBusquedaTotal[index].DocumentoCabTotal, objListBusquedaTotal[index].DocumentoCabTotalSinIGV,
              objListBusquedaTotal[index].DocumentoCabIGV);
                        break;
                    case "D":

                        formDeb.setDatosDocumento(objListBusquedaTotal[index].DocumentoCabSerie,
              objListBusquedaTotal[index].DocumentoCabNro, objListBusquedaTotal[index].DocumentoCabCliente, objListBusquedaTotal[index].DocumentoCabClienteDireccion,
              objListBusquedaTotal[index].DocumentoCabFecha, objListBusquedaTotal[index].DocumentoCabClienteDocumento, objListBusquedaTotal[index].DocumentoCabTipoMoneda,
              objListBusquedaTotal[index].DocumentoCabGlosa, objListBusquedaTotal[index].DocumentoCabClienteCod, objListBusquedaTotal[index].DocumentoCabTotal, objListBusquedaTotal[index].DocumentoCabTotalSinIGV,
              objListBusquedaTotal[index].DocumentoCabIGV);
                        break;
                    case "T":
                        formLetraCambio.setDatosDocumento(objListBusquedaTotal[index].DocumentoCabSerie, objListBusquedaTotal[index].DocumentoCabNro,
                            objListBusquedaTotal[index].DocumentoCabTotal, objListBusquedaTotal[index].DocumentoCabFecha, objListBusquedaTotal[index].DocumentoCabFechaVcto,
                            objListBusquedaTotal[index].DocumentoCabTipoMoneda);
                        break;
                }


                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha seleccionado ningún registro");
            }
        }
    }
}
