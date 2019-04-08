using Contabilidad.CtaXcobrar;
using Contabilidad.Reporte;
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
    public partial class BuscarCliente : Form
    {
        public Factura formFac;
        public Boleta formBole;
        public ReporteVoucher formVoucher;
        public ReporteDocumentosPorCliente formReport;
        public LetraCambio formLetraCambio;
        public Retencion formRetencion;
        public AbonoBanco formAbono;


        public static string TipoDocumento;
        ClienteDAO objClienteDao;

        public static List<Cliente> objListCliente = new List<Cliente>();
        public static List<Cliente> objListBusquedaRazon = new List<Cliente>();
        public static List<Cliente> objListBusquedaRuc = new List<Cliente>();
        public static List<Cliente> objListBusquedaTotal = new List<Cliente>();
        public BuscarCliente(String DocumentoTipo)
        {
            InitializeComponent();
            TipoDocumento = DocumentoTipo;
            if (DocumentoTipo == "F")
            {
                formFac = Factura.formFactura;
            }
            else if (DocumentoTipo == "B")
            {
                formBole = Boleta.boletaForm;
            }else if (DocumentoTipo =="R")
            {
                formReport = ReporteDocumentosPorCliente.formReporteClientes;
            }else if (DocumentoTipo=="T" || DocumentoTipo == "A")
            {
                formLetraCambio = LetraCambio.letraCambioForm;
            }else if (DocumentoTipo =="RT")
            {
                formRetencion = Retencion.retencionForm;
            }
            else if (DocumentoTipo == "AB")
            {
                formAbono = AbonoBanco.AbonoForm;
            }
            else if (DocumentoTipo == "VC")
            {
                formVoucher = ReporteVoucher.formReporteCheques;
            }
            else if(DocumentoTipo == "BAN")
            {
                formVoucher = ReporteVoucher.formReporteCheques;
            }
            objClienteDao = new ClienteDAO();
            objListCliente = objClienteDao.listarCliente(Ventas.UNIDADNEGOCIO);
            objListBusquedaTotal = objListCliente;
            gridParams();
            listCliente(objListCliente);
            txt_BuscarCliente.TextChanged += Txt_BuscarCliente_TextChanged;
            
            
        }

    

        private void Txt_BuscarCliente_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarCliente.Text.ToUpper();

            objListBusquedaRazon = objListCliente.Where(t => t.ClienteRazonSocial.Contains(busqueda)).ToList();
            objListBusquedaRuc = objListCliente.Where(t => t.ClienteNDoc.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).ToList().OrderBy(x => x.ClienteRazonSocial).ToList();
            listCliente(objListBusquedaTotal);
        }
        public void gridParams()
        {
            grdCliente.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.DataPropertyName = "ClienteNDoc";
            grdCliente.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.DataPropertyName = "ClienteRazonSocial";
            idColumn2.Width = 260;
            grdCliente.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Direccion";
            idColumn3.DataPropertyName = "ClienteDireccion";
            idColumn3.Width = 320;
            grdCliente.Columns.Add(idColumn3);
        }
        public void listCliente(List<Cliente> lista)
        {
            grdCliente.DataSource = lista;
            grdCliente.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
           
            try
            {
                int index = grdCliente.SelectedCells[0].RowIndex;

                switch (TipoDocumento)
                {
                    case "F":
                        formFac.setClienteDatos(objListBusquedaTotal[index].ClienteRazonSocial,
              objListBusquedaTotal[index].ClienteDireccion, objListBusquedaTotal[index].ClienteNDoc, objListBusquedaTotal[index].ClienteCod);
                        break;
                    case "B":
                        formBole.setClienteDatos(objListBusquedaTotal[index].ClienteRazonSocial,
              objListBusquedaTotal[index].ClienteDireccion, objListBusquedaTotal[index].ClienteNDoc, objListBusquedaTotal[index].ClienteCod);
                        break;
                    case "R":
                        formReport.setDatosCliente(objListBusquedaTotal[index].ClienteNDoc, objListBusquedaTotal[index].ClienteCod);
                        break;
                    case "T":
                        formLetraCambio.setClienteDatos(objListBusquedaTotal[index].ClienteRazonSocial,
              objListBusquedaTotal[index].ClienteDireccion, objListBusquedaTotal[index].ClienteNDoc, objListBusquedaTotal[index].ClienteCod);
                        break;
                    case "A":
                        formLetraCambio.setClienteDatosAval(objListBusquedaTotal[index].ClienteRazonSocial,
              objListBusquedaTotal[index].ClienteDireccion, objListBusquedaTotal[index].ClienteNDoc, objListBusquedaTotal[index].ClienteCod, 
              objListBusquedaTotal[index].ClienteTelefono);
                        break;
                    case "AB":
                        formAbono.setDatosCliente(objListBusquedaTotal[index].ClienteNDoc, objListBusquedaTotal[index].ClienteRazonSocial, objListBusquedaTotal[index].ClienteCod);
                        break;
                    case "VC":
                        formVoucher.setClienteDatos(objListBusquedaTotal[index].ClienteNDoc);
                        break;
                    //case "BAN":
                    //    formVoucher.setBancoDatos(objListBusquedaTotal[index].c)
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
