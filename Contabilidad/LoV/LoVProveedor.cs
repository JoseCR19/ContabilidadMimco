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
    public partial class LoVProveedor : Form
    {
        Caja.CajaChica cajaChicaForm;
        public static List<Proveedor> objListProveedor = new List<Proveedor>();
        public static List<Proveedor> objListProveedorRUC = new List<Proveedor>();
        public static List<Proveedor> objListProveedorRazon = new List<Proveedor>();
        public static List<Proveedor> objListProveedorTotal = new List<Proveedor>();
        public static List<Personal> objListPersonal = new List<Personal>();
        public static List<Personal> objListPersonalDocumento = new List<Personal>();
        public static List<Personal> objListPersonalNombre = new List<Personal>();
        public static List<Personal> objListPersonalTotal = new List<Personal>();
        Proveedor objProveedor;
        Personal objPersonal;
        LoVDAO objLoVDao;
        int index = 0;
        public LoVProveedor()
        {
            InitializeComponent();
            this.Text = "Proveedor / Personal";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objLoVDao = new LoVDAO();
            objPersonal = new Personal();
            objProveedor = new Proveedor();
            cajaChicaForm = Caja.CajaChica.formCajachica;
            objListPersonal = objLoVDao.getLovPersonal();
            objListProveedor = objLoVDao.getLovProveedor(Ventas.UNIDADNEGOCIO);
            
            rb_Prov.Checked = true;
            rb_Prov.CheckedChanged += Rb_Prov_CheckedChanged;
            txt_Busqueda.TextChanged += Txt_Busqueda_TextChanged;
            grdProveedor.DoubleClick += GrdProveedor_DoubleClick;
            lbl_Buscar.Text = "Razón Social o RUC:";
            gridParams("Ruc", "ProveedorNDoc", "Razón Social", "ProveedorRazonSocial");
            listProveedor(objListProveedor);
            objListProveedorTotal = objListProveedor;
            objListPersonalTotal = objListPersonal;
        }

        private void GrdProveedor_DoubleClick(object sender, EventArgs e)
        {
            index = grdProveedor.SelectedCells[0].RowIndex;
            if (rb_Prov.Checked)
            {
                objProveedor = new Proveedor();
                objProveedor = objListProveedorTotal[index];
                cajaChicaForm.setProveedor(objProveedor.ProveedorNDoc, objProveedor.ProveedorRazonSocial,"02");
            }else
            {
                objPersonal = new Personal();
                objPersonal = objListPersonalTotal[index];
                cajaChicaForm.setProveedor(objPersonal.NroDocumento, objPersonal.Nombre,"03");
            }
           
            this.Close();
        }

        private void Txt_Busqueda_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_Busqueda.Text.ToUpper();
            if (rb_Prov.Checked)
            {
                objListProveedorRUC = objListProveedor.Where(t => t.ProveedorNDoc.Contains(busqueda)).ToList();
                objListProveedorRazon = objListProveedor.Where(t => t.ProveedorRazonSocial.Contains(busqueda)).ToList();
                objListProveedorTotal = objListProveedorRUC.Union(objListProveedorRazon).ToList().OrderBy(x => x.ProveedorRazonSocial).ToList();
                listProveedor(objListProveedorTotal);
            }else
            {
                objListPersonalDocumento = objListPersonal.Where(t => t.NroDocumento.Contains(busqueda)).ToList();
                objListPersonalNombre = objListPersonal.Where(t => t.Nombre.Contains(busqueda)).ToList();
                objListPersonalTotal = objListPersonalDocumento.Union(objListPersonalNombre).ToList().OrderBy(x => x.Nombre).ToList();
                listPersonal(objListPersonalTotal);
            }
           
        }

        void listPersonal(List<Personal>lista)
        {
            grdProveedor.DataSource = null;
            grdProveedor.DataSource = lista;
            grdProveedor.Refresh();
        }
        void listProveedor(List<Proveedor> lista)
        {
            grdProveedor.DataSource = null;
            grdProveedor.DataSource = lista;
            grdProveedor.Refresh();
        }
        private void Rb_Prov_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Prov.Checked)
            {
                if (grdProveedor.ColumnCount ==2)
                {
                    gridRemove();
                }
                gridParams("Ruc", "ProveedorNDoc", "Razón Social", "ProveedorRazonSocial");
                listProveedor(objListProveedor);
                lbl_Buscar.Text = "Razón Social o RUC:";
            }
            else
            {
                if (grdProveedor.ColumnCount == 2)
                {
                    gridRemove();
                }
                gridParams("N° Documento", "NroDocumento", "Nombres", "Nombre");
                listPersonal(objListPersonal);
                lbl_Buscar.Text = "N° Documento o Nombre:";
            }
            
        }

        void gridParams(String Documento, String DocColumn, String Razon, String RazonColumn)
        {
            
            grdProveedor.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = Documento;
            idColumn1.DataPropertyName = DocColumn;
            idColumn1.Width = 100;
            grdProveedor.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = Razon;
            idColumn2.DataPropertyName = RazonColumn;
            idColumn2.Width = 320;
            grdProveedor.Columns.Add(idColumn2);
        }
        void gridRemove()
        {
            grdProveedor.Columns.RemoveAt(0);
            grdProveedor.Columns.RemoveAt(0);
        }
    }
}
