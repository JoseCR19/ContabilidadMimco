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
    public partial class BuscarProducto : Form
    {
        public Factura formFac;
     
        public Boleta formBole;
        public NotaDeCredito formNCredito;
        public static string TipoDocumento;
        ProductoDAO objProductoDao;

        public static List<Producto> objListProducto = new List<Producto>();
        public static List<Producto> objListBusquedaDescr = new List<Producto>();
        public static List<Producto> objListBusquedaCod = new List<Producto>();
        public static List<Producto> objListBusquedaTotal = new List<Producto>();
        public BuscarProducto(String DocumentoTipo)
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
            }else if(DocumentoTipo == "NC")
            {
                formNCredito = NotaDeCredito.creditoForm;
            }
            objProductoDao = new ProductoDAO();
            objListProducto = objProductoDao.listarProducto(Ventas.UNIDADNEGOCIO);
            objListBusquedaTotal = objListProducto;
            txt_BuscarProducto.TextChanged += Txt_BuscarProducto_TextChanged;
            gridParams();
            listCliente(objListProducto);
      
         

        }

 

     
           
      

        private void Txt_BuscarProducto_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarProducto.Text.ToUpper();

            objListBusquedaDescr = objListProducto.Where(t => t.ProductoDescripcion.Contains(busqueda)).ToList();
            objListBusquedaCod = objListProducto.Where(t => t.ProductoCod.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaCod.Union(objListBusquedaDescr).ToList();
            listCliente(objListBusquedaTotal);
        }

        public void gridParams()
        {
            grd_Producto.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "CÓDIGO";
            idColumn1.DataPropertyName = "ProductoCod";
            idColumn1.Width = 100;
            grd_Producto.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "DESCRIPCIÓN";
            idColumn2.DataPropertyName = "ProductoDescripcion";
            idColumn2.Width = 300;
            grd_Producto.Columns.Add(idColumn2);
           
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "UNIDAD MEDIDA";
            idColumn4.DataPropertyName = "ProductoUnidadMedida";
            idColumn4.Width = 150;
            grd_Producto.Columns.Add(idColumn4);
           
        }
        public void listCliente(List<Producto> lista)
        {
            grd_Producto.DataSource = lista;
            grd_Producto.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grd_Producto.SelectedCells[0].RowIndex;

                switch (TipoDocumento)
                {
                    case "F":
                        formFac.setProductosDatos(objListBusquedaTotal[index].ProductoCod,
                    objListBusquedaTotal[index].ProductoDescripcion, objListBusquedaTotal[index].ProductoUnidadMedidaCorta, 
                    objListBusquedaTotal[index].ProductoUnidadMedidaCod);
                        break;
                    case "B":
                        formBole.setProductosDatos(objListBusquedaTotal[index].ProductoCod,
               objListBusquedaTotal[index].ProductoDescripcion, objListBusquedaTotal[index].ProductoUnidadMedidaCorta,
               objListBusquedaTotal[index].ProductoUnidadMedidaCod);
                        break;
                    case "NC":
                        formNCredito.setProductosDatos(objListBusquedaTotal[index].ProductoCod,
                    objListBusquedaTotal[index].ProductoDescripcion, objListBusquedaTotal[index].ProductoUnidadMedidaCorta,
                    objListBusquedaTotal[index].ProductoUnidadMedidaCod);
                        break;
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
