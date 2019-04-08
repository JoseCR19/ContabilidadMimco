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

namespace Contabilidad.LoV
{
    public partial class LoVSolicita : Form
    {
        String codigoSolicita = "";
        Caja.EmisionVoucher emisionForm;
        Reporte.ReporteVoucher reportevoucher;
        public static List<Proveedor> objListProveedor = new List<Proveedor>();
        public static List<Proveedor> objListProveedorRUC = new List<Proveedor>();
        public static List<Proveedor> objListProveedorRazon = new List<Proveedor>();
        public static List<Proveedor> objListProveedorTotal = new List<Proveedor>();
        public static List<Personal> objListPersonal = new List<Personal>();
        public static List<Personal> objListPersonalDocumento = new List<Personal>();
        public static List<Personal> objListPersonalNombre = new List<Personal>();
        public static List<Personal> objListPersonalTotal = new List<Personal>();
        public static List<Cliente> objListaCliente = new List<Cliente>();
        public static List<Cliente> objListaClienteRUC = new List<Cliente>();
        public static List<Cliente> objListaClienteRazon = new List<Cliente>();
        public static List<Cliente> objListaClienteTotal = new List<Cliente>();
        public static List<CuentaBanco> objListaBanco = new List<CuentaBanco>();
        public static List<CuentaBanco> objListaBancoNombre = new List<CuentaBanco>();
        public static List<CuentaBanco> objListaBancoTotal = new List<CuentaBanco>();

        LoVDAO objLoVDao;

        Proveedor objProveedor;
        Personal objPersonal;
        CuentaBanco objBanco;
        Cliente objCliente;


        int index = 0;

        public LoVSolicita(String SolicitaCod)
        {
            InitializeComponent();
            this.Text = "Solicitante";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            emisionForm = Caja.EmisionVoucher.formEmision;
            reportevoucher = Reporte.ReporteVoucher.formReporteCheques;
            codigoSolicita = SolicitaCod;
            objLoVDao = new LoVDAO();
            objPersonal = new Personal();
            objProveedor = new Proveedor();
            objBanco = new CuentaBanco();
            objCliente = new Cliente();
            this.ActiveControl = txt_Busqueda;
            objListPersonal = objLoVDao.getLovPersonal();
            objListPersonalTotal = objListPersonal;
            objListProveedor = objLoVDao.getLovProveedor(Ventas.UNIDADNEGOCIO);
            objListProveedorTotal = objListProveedor;
            objListaCliente = objLoVDao.getLovCliente(Ventas.UNIDADNEGOCIO);
            objListaClienteTotal = objListaCliente;
            objListaBanco = objLoVDao.getLovBancoSolicita(Ventas.UNIDADNEGOCIO);
            objListaBancoTotal = objListaBanco;
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            grdSolicita.DoubleClick += GrdSolicita_DoubleClick;
            switch (SolicitaCod)
            {
                case "02":
                    lbl_Solicita.Text = "Razón Social o Ruc";
                    gridParamsProveedor();
                    grdSolicita.DataSource = objListProveedor;
                    grdSolicita.Refresh();
                    break;
                case "03":
                    lbl_Solicita.Text = "Nombre o Documento";
                    gridParamsPersonal();
                    grdSolicita.DataSource = objListPersonal;
                    grdSolicita.Refresh();
                    break;
                case "04":
                    lbl_Solicita.Text = "Nombre del Banco";
                    gridParamsBanco();
                    grdSolicita.DataSource = objListaBanco;
                    grdSolicita.Refresh();
                    break;
                case "05":
                    lbl_Solicita.Text = "Razón Social o Ruc";
                    gridParamsCliente();
                    grdSolicita.DataSource = objListaCliente;
                    grdSolicita.Refresh();
                    break;
                case "06":
                    lbl_Solicita.Text = "Nombre del Banco";
                    gridParamsBanco();
                    grdSolicita.DataSource = objListaBanco;
                    grdSolicita.Refresh();
                    break;

            }
        }
        void gridParamsProveedor()
        {

            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.DataPropertyName = "ProveedorNDoc";
            idColumn1.Width = 100;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razón Social";
            idColumn2.DataPropertyName = "ProveedorRazonSocial";
            idColumn2.Width = 320;
            grdSolicita.Columns.Add(idColumn2);
        }
        void gridParamsCliente()
        {

            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.DataPropertyName = "ClienteNDoc";
            idColumn1.Width = 100;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razón Social";
            idColumn2.DataPropertyName = "ClienteRazonSocial";
            idColumn2.Width = 320;
            grdSolicita.Columns.Add(idColumn2);
        }
        void gridParamsPersonal()
        {

            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° Documento";
            idColumn1.DataPropertyName = "NroDocumento";
            idColumn1.Width = 100;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Nombres";
            idColumn2.DataPropertyName = "Nombre";
            idColumn2.Width = 320;
            grdSolicita.Columns.Add(idColumn2);
        }
        /*void gridParamsBanco()
        {

            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Banco";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 175;
            grdSolicita.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Moneda";
            idColumn2.DataPropertyName = "Moneda";
            idColumn2.Width = 130;
            grdSolicita.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Cuenta";
            idColumn3.DataPropertyName = "Cuenta";
            idColumn3.Width = 140;
            grdSolicita.Columns.Add(idColumn3);
        }*/

        void gridParamsBanco()
        {

            grdSolicita.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Código";
            idColumn2.DataPropertyName = "Codigo";
            idColumn2.Width = 120;
            grdSolicita.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Banco";
            idColumn1.DataPropertyName = "Descripcion";
            idColumn1.Width = 330;
            grdSolicita.Columns.Add(idColumn1);


        }
        private void GrdSolicita_DoubleClick(object sender, EventArgs e)
        {
            index = grdSolicita.SelectedCells[0].RowIndex;
            switch (codigoSolicita)
            {
                case "02":
                    objProveedor = new Proveedor();
                    objProveedor = objListProveedorTotal[index];
                    emisionForm.setSolicitaProveedor(objProveedor.ProveedorNDoc, objProveedor.ProveedorRazonSocial);
                    this.Close();
                    break;
                case "03":
                    objPersonal = new Personal();
                    objPersonal = objListPersonalTotal[index];
                    emisionForm.setSolicitaPersonal(objPersonal.NroDocumento, objPersonal.Nombre);
                    this.Close();
                    break;
                case "04":
                    objBanco = new CuentaBanco();
                    objBanco = objListaBancoTotal[index];
                    emisionForm.setSolicitaBanco(objBanco.Codigo, objBanco.Descripcion);
                    this.Close();
                    break;
                case "05":
                    objCliente = new Cliente();
                    objCliente = objListaClienteTotal[index];
                    emisionForm.setSolicitaCliente(objCliente.ClienteNDoc, objCliente.ClienteRazonSocial);
                    this.Close();
                    break;
                case "06":
                    objBanco = new CuentaBanco();
                    objBanco = objListaBancoTotal[index];
                    reportevoucher.setBancoDatos(objBanco.Codigo, objBanco.Descripcion);
                    break;


            }
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();
            switch (codigoSolicita)
            {
                case "02":
                    objListProveedorRUC = objListProveedor.Where(t => t.ProveedorNDoc.Contains(busqueda)).ToList();
                    objListProveedorRazon = objListProveedor.Where(t => t.ProveedorRazonSocial.Contains(busqueda)).ToList();
                    objListProveedorTotal = objListProveedorRUC.Union(objListProveedorRazon).ToList().OrderBy(x => x.ProveedorRazonSocial).ToList();
                    grdSolicita.DataSource = objListProveedorTotal;
                    grdSolicita.Refresh();

                    break;
                case "03":
                    objListPersonalDocumento = objListPersonal.Where(t => t.NroDocumento.Contains(busqueda)).ToList();
                    objListPersonalNombre = objListPersonal.Where(t => t.Nombre.Contains(busqueda)).ToList();
                    objListPersonalTotal = objListPersonalDocumento.Union(objListPersonalNombre).ToList().OrderBy(x => x.Nombre).ToList();
                    grdSolicita.DataSource = objListPersonalTotal;
                    grdSolicita.Refresh();
                    break;
                case "04":
                    objListaBancoNombre = objListaBanco.Where(t => t.Descripcion.Contains(busqueda)).ToList();
                    objListaBancoTotal = objListaBancoNombre;
                    grdSolicita.DataSource = objListaBancoTotal;
                    grdSolicita.Refresh();
                    break;
                case "05":
                    objListaClienteRUC = objListaCliente.Where(t => t.ClienteNDoc.Contains(busqueda)).ToList();
                    objListaClienteRazon = objListaCliente.Where(t => t.ClienteRazonSocial.Contains(busqueda)).ToList();
                    objListaClienteTotal = objListaClienteRUC.Union(objListaClienteRazon).ToList().OrderBy(x => x.ClienteRazonSocial).ToList();
                    grdSolicita.DataSource = objListaClienteTotal;
                    grdSolicita.Refresh();
                    break;
                case "06":
                    objListaBancoNombre = objListaBanco.Where(t => t.Descripcion.Contains(busqueda)).ToList();
                    objListaBancoTotal = objListaBancoNombre;
                    grdSolicita.DataSource = objListaBancoTotal;
                    grdSolicita.Refresh();
                    break;
            }
        }

        private void txt_Busqueda_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void LoVSolicita_Load(object sender, EventArgs e)
        {

        }
    }
}
