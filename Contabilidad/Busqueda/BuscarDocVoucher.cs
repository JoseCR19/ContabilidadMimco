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
    public partial class BuscarDocVoucher : Form
    {
        public static List<ContabilidadDTO.Ventas> objListVentas = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaRazon = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaRuc = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaNdoc = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaTotal = new List<ContabilidadDTO.Ventas>();

        public static List<FacturaAbono> objListBusquedaTotalAbono = new List<FacturaAbono>();
        public static List<FacturaAbono> objListBusquedaAbono = new List<FacturaAbono>();
        FacturaAbono objFacturaAbono;
        BancoDAO objBancoDAO;


        ContabilidadDTO.Ventas ojbVentas;

        Caja.EmisionVoucher formVoucher;
        Caja.CajaChica formCaja;

        VoucherDAO objVoucherDao;

        String TipoBusqueda ="";
        String TipoBanco = "Q";
        
        int index = 0;

        public BuscarDocVoucher(String Ruc, String operacion)
        {
            InitializeComponent();
            TipoBusqueda = operacion;
            objVoucherDao = new VoucherDAO();
            objFacturaAbono = new FacturaAbono();
            objBancoDAO = new BancoDAO();


            ojbVentas = new ContabilidadDTO.Ventas();
            if (operacion=="C")
            {
                formCaja = Caja.CajaChica.formCajachica;
            }
            else if(operacion =="V")
            {
                formVoucher = Caja.EmisionVoucher.formEmision;
                TipoBanco = Caja.EmisionVoucher.TipoOperacionBanco;
            }
            if (TipoBanco =="A")
            {
                objListBusquedaAbono = objVoucherDao.geetDocumentoVoucherAbono(Ventas.UNIDADNEGOCIO,Ruc);
                gridParamsAbono();
                grdDocumento.DataSource = objListBusquedaAbono;
                objListBusquedaTotalAbono = objListBusquedaAbono;
            }
            else
            {
                objListVentas = objVoucherDao.listarDocumentosVentas(Ruc, Ventas.UNIDADNEGOCIO/*,moneda,monedadoc*/);
                gridParams();
                grdDocumento.DataSource = objListVentas;
                objListBusquedaTotal = objListVentas;
            }

          
            grdDocumento.Refresh();
            grdDocumento.DoubleClick += GrdDocumento_DoubleClick;
            
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
        }
        public void gridParamsAbono()
        {

            grdDocumento.AutoGenerateColumns = false;
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


        }
        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            if (TipoBanco =="C")
            {
                String busqueda = txt_BuscarDocumento.Text.ToUpper();

                objListBusquedaRazon = objListVentas.Where(t => t.RazonSocial.Contains(busqueda)).ToList();
                objListBusquedaRuc = objListVentas.Where(t => t.Ruc.Contains(busqueda)).ToList();
                objListBusquedaNdoc = objListVentas.Where(t => t.Numero.Contains(busqueda)).ToList();
                objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).Union(objListBusquedaNdoc).ToList();
                grdDocumento.DataSource = null;
                grdDocumento.DataSource = objListBusquedaTotal;
                grdDocumento.Refresh();
            }else if(TipoBanco == "A")
            {
                String busqueda = txt_BuscarDocumento.Text.ToUpper();
                objListBusquedaTotalAbono = objListBusquedaAbono.Where(t => t.Numero.Contains(busqueda)).ToList();

               
                grdDocumento.DataSource = null;
                grdDocumento.DataSource = objListBusquedaTotalAbono;
                grdDocumento.Refresh();
            }
            
        }

        private void GrdDocumento_DoubleClick(object sender, EventArgs e)
        {
            index = grdDocumento.SelectedCells[0].RowIndex;
            //
            if (TipoBanco == "Q")
            {
                ojbVentas = objListBusquedaTotal[index];
                formCaja.setDatosDoc(ojbVentas.Serie, ojbVentas.Numero, ojbVentas.Total);
            }
            else if (TipoBanco == "C")
            {
                ojbVentas = objListBusquedaTotal[index];
                formVoucher.setDatosDoc(ojbVentas.Serie, ojbVentas.Numero,ojbVentas.Total, ojbVentas.VentasId,ojbVentas.Total );
            }else if (TipoBanco == "A")
            {
                objFacturaAbono = objListBusquedaTotalAbono[index];
                formVoucher.setDatosAbono(objFacturaAbono.Serie, objFacturaAbono.Numero, objFacturaAbono.Saldo, objFacturaAbono.Total);
            }
            this.Close();
        }

        public void gridParams()
        {
            grdDocumento.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Width = 70;
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "Serie";
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "Numero";
            idColumn0.Width = 100;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "RUC";
            idColumn2.DataPropertyName = "Ruc";
            idColumn0.Width = 80;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razon Social";
            idColumn3.DataPropertyName = "RazonSocial";
            idColumn3.Width = 270;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Total";
            idColumn4.DataPropertyName = "Total";
            idColumn4.Width = 120;
            grdDocumento.Columns.Add(idColumn4);
        }


    }
}
