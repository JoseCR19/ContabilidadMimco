using Contabilidad.Busqueda;
using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class Retencion : Form
    {
        public static Retencion retencionForm;
        public static DocumentoCab objDocumentoCab;
        public static List<DocumentoPagoDet> objListPagoDet = new List<DocumentoPagoDet>();
        public static List<RetencionDet> objListaRetencionDet = new List<RetencionDet>();
        DocumentoContabilidadDAO objContabilidadDocuDAO;
        DocumentoDAO objDocumento;
        RetencionDAO objRetencionDAO;
        RetencionCab objRetencionCab;
        RetencionDet objRetencionDet;
        PagoDAO objPagoDAO = new PagoDAO();
        public Retencion()
        {
            InitializeComponent();
            this.Text = "RETENCIONES";
            this.ControlBox = false;
            objContabilidadDocuDAO = new DocumentoContabilidadDAO();
            objDocumento = new DocumentoDAO();
            objRetencionDAO = new RetencionDAO();
            retencionForm = this;


            txt_Serie.Text = "R001";

            if (ListaRetencion.operacionRetencion =="N")
            {
                txt_Observacion.Enabled = true;
                txt_Ruc.Text = "15603034403";
                 gridParams();
            }
            else
            {
                gridParams2();
                btn_Buscar.Enabled = false;
                btn_BuscarDocu.Enabled = false;
                btn_SaveData.Enabled = false;
                txt_Numero.Text = ListaRetencion.objRetencionCab.RetencionCab_Numero;
                txt_Cliente.Text = ListaRetencion.objRetencionCab.RetencionCab_Proveedor;
                txt_codot.Text = ListaRetencion.objRetencionCab.RetencionCab_CodOt;
                txt_MonedaCod.Text = ListaRetencion.objRetencionCab.RetencionCab_CodMoneda;
                txt_Observacion.Text = ListaRetencion.objRetencionCab.RetencionCab_Observacion;
                txt_Ruc.Text = ListaRetencion.objRetencionCab.RetencionCab_RucProv;
                txt_TotalDolares.Text = ListaRetencion.objRetencionCab.RetencionCab_MontoDolar.ToString();
                txt_TotalSoles.Text= ListaRetencion.objRetencionCab.RetencionCab_Monto.ToString();
                txt_TRetencionDolares.Text = ListaRetencion.objRetencionCab.RetencionCab_RetencionDolar.ToString();
                txt_TRetencionSoles.Text = ListaRetencion.objRetencionCab.RetencionCab_Retencion.ToString();
                objListaRetencionDet = objRetencionDAO.listarRetencionDet(txt_Serie.Text, txt_Numero.Text);
                try { txt_Voucher.Text = objListaRetencionDet[0].RetencionDet_Voucher; }
                catch
                {

                }
                    grdDocumento.DataSource = objListaRetencionDet;
                grdDocumento.Refresh();
            }
         
        }
        

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            using (var buscarProveedorForm = new BusquedaProveedor("RT"))
            {
                buscarProveedorForm.ShowDialog();
            }
            btn_Buscar.Enabled = true;
        }
        public void setDatos(Proveedor objCli)
        {
            //objDocumentoCab = objCli;
            txt_codcliente.Text = objCli.ProveedorCod;
            txt_Ruc.Text = objCli.ProveedorNDoc;
            txt_Voucher.Text = "";
            txt_Cliente.Text = objCli.ProveedorRazonSocial;

        }

        private void btn_BuscarDocu_Click(object sender, EventArgs e)
        {
            btn_BuscarDocu.Enabled = false;
            using (var buscarDocuForm = new BuscarVoucher(txt_Ruc.Text))
            {
                buscarDocuForm.ShowDialog();
            }
            btn_BuscarDocu.Enabled = true;
        }
        public void setVoucher(String nrovoucher)
        {
            txt_Voucher.Text = nrovoucher;
            objListPagoDet = objPagoDAO.buscarDocus(nrovoucher);
            try
            {
                txt_codot.Text = objListPagoDet[0].DocumentoPagoDetCodOT;
                txt_MonedaCod.Text = objListPagoDet[0].DocumentoPagoDetCodMoneda;
            }
            catch
            {

            }
            
            grdDocumento.DataSource = objListPagoDet;
            grdDocumento.Refresh();
            llenarSumatorias();
        }
        public void gridParams()
        {
            grdDocumento.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Documento";
            idColumn1.DataPropertyName = "DocumentoPagoDetTipoDocumento";
            idColumn1.Width = 110;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Serie";
            idColumn2.DataPropertyName = "DocumentoPagoDetSerieRef";
            idColumn2.Width = 90;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "N° DOC";
            idColumn3.DataPropertyName = "DocumentoPagoDetNroDocRef";
            idColumn3.Width = 80;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "DocumentoPagoDetFecha";
            idColumn4.Width = 90;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Total $";
            idColumn5.DataPropertyName = "DocumentoPagoDetPagoDolar";
            idColumn5.Width = 90;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Total S/";
            idColumn6.DataPropertyName = "DocumentoPagoDetPago";
            idColumn6.Width = 90;
            grdDocumento.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Retención $";
            idColumn7.DataPropertyName = "DocumentoPagoDetRetencionDolar";
            idColumn7.Width = 90;
            grdDocumento.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Retención S/";
            idColumn8.DataPropertyName = "DocumentoPagoDetRetencion";
            idColumn8.Width = 90;
            grdDocumento.Columns.Add(idColumn8);

        }
        public void gridParams2()
        {
            grdDocumento.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Documento";
            idColumn1.DataPropertyName = "RetencionDet_TipoDocumentoRef";
            idColumn1.Width = 110;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Serie";
            idColumn2.DataPropertyName = "RetencionDet_Serie";
            idColumn2.Width = 90;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "N° DOC";
            idColumn3.DataPropertyName = "RetencionDet_Numero";
            idColumn3.Width = 80;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "RetencionDet_FechaRef";
            idColumn4.Width = 90;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Total $";
            idColumn5.DataPropertyName = "RetencionDet_MontoDolares";
            idColumn5.Width = 90;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Total S/";
            idColumn6.DataPropertyName = "RetencionDet_MontoSoles";
            idColumn6.Width = 90;
            grdDocumento.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Retención $";
            idColumn7.DataPropertyName = "RetencionDet_RetencionDolares";
            idColumn7.Width = 90;
            grdDocumento.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Retención S/";
            idColumn8.DataPropertyName = "RetencionDet_RetencionSoles";
            idColumn8.Width = 90;
            grdDocumento.Columns.Add(idColumn8);

        }
        public void llenarSumatorias()
        {
            txt_TotalDolares.Text = objListPagoDet.Sum(x => x.DocumentoPagoDetPagoDolar).ToString();
            txt_TotalSoles.Text = objListPagoDet.Sum(x => x.DocumentoPagoDetPago).ToString();
            txt_TRetencionDolares.Text = objListPagoDet.Sum(x => x.DocumentoPagoDetRetencionDolar).ToString();
            txt_TRetencionSoles.Text = objListPagoDet.Sum(x => x.DocumentoPagoDetRetencion).ToString();
            lblTotal.Text = objDocumento.numeroALetras(convertToDouble(txt_TRetencionSoles.Text)) ;
           
        }
        public Double convertToDouble(String conv)
        {
            try
            {
                char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
                if (!conv.Contains(","))
                    return double.Parse(conv, CultureInfo.InvariantCulture);
                else
                    return Convert.ToDouble(conv.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaRetencion.operacionRetencion = "Q";
            ListaRetencion Check = new ListaRetencion();
            Check.Show();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            btn_SaveData.Enabled = false;
            bool binsertar, bdetalle = true;
            string msg = "";
            objRetencionCab = new RetencionCab();
            objRetencionDet = new RetencionDet();
            objRetencionCab.RetencionCab_Serie = txt_Serie.Text;
            objRetencionCab.RetencionCab_Numero = txt_Numero.Text;
            objRetencionCab.RetencionCab_Observacion = txt_Observacion.Text;
            objRetencionCab.RetencionCab_Monto = convertToDouble(txt_TotalSoles.Text);
            objRetencionCab.RetencionCab_Retencion = convertToDouble(txt_TRetencionSoles.Text);
            objRetencionCab.RetencionCab_RucProv = txt_Ruc.Text;
            objRetencionCab.RetencionCab_Fecha = dpick_Fecha.Value;
            objRetencionCab.RetencionCab_CodOt = txt_codot.Text;
            objRetencionCab.RetencionCab_MontoDolar = convertToDouble(txt_TotalDolares.Text);
            objRetencionCab.RetencionCab_RetencionDolar = convertToDouble(txt_TRetencionDolares.Text);
            objRetencionCab.RetencionCab_CodMoneda = txt_MonedaCod.Text;

            for (int i = 0; i<objListPagoDet.Count;i++)
            {
                objRetencionDet.RetencionDet_Serie = txt_Serie.Text;
                objRetencionDet.RetencionDet_Numero = txt_Numero.Text;
                objRetencionDet.RetencionDet_Voucher = txt_Voucher.Text;
                objRetencionDet.RetencionDet_FechaRef = objListPagoDet[i].DocumentoPagoDetFecha;
                objRetencionDet.RetencionDet_MontoDolares = objListPagoDet[i].DocumentoPagoDetPagoDolar;
                objRetencionDet.RetencionDet_MontoSoles = objListPagoDet[i].DocumentoPagoDetPago;
                objRetencionDet.RetencionDet_RetencionDolares = objListPagoDet[i].DocumentoPagoDetRetencionDolar;
                objRetencionDet.RetencionDet_RetencionSoles = objListPagoDet[i].DocumentoPagoDetRetencion;
                objRetencionDet.RetencionDet_NumeroRef = objListPagoDet[i].DocumentoPagoDetNroDocRef;
                objRetencionDet.RetencionDet_SerieRef = objListPagoDet[i].DocumentoPagoDetSerieRef;
                objRetencionDet.RetencionDet_TipoDocRef = objListPagoDet[i].DocumentoPagoDetTipoDocumentoCod;
                objListaRetencionDet.Add(objRetencionDet);
            }

            binsertar = objRetencionDAO.insertarCabecera(objRetencionCab, Ventas.UNIDADNEGOCIO);
            if (binsertar)
            {



            }
            else
            {
                msg = "Hubo un problema al guardar";
                MessageBox.Show(msg);
                btn_SaveData.Enabled = true;

                return;
            }
            for (int i = 0; i < objListaRetencionDet.Count; i++)
            {
                bdetalle = objRetencionDAO.insertarDetalle(objListaRetencionDet[i]);
                if (bdetalle == false)
                {
                    MessageBox.Show("Error al guardar");
                    btn_SaveData.Enabled = true;
                    break;
                }
            }
            if (bdetalle)
            {
                MessageBox.Show("Retención guardada exitosamente");
                //nuevoRegistro();
                btn_SaveData.Enabled = true;
            }
        }
    }
}
