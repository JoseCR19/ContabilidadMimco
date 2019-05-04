using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class ListaFactura : Form
    {
        DocumentoDAO objDocumentoDao;
        FacturaReporteDTO objFacturaReporte;

        public static ListaFactura formListaFactura;
        public static String MotivoAnulacion = "";
        public static DocumentoCab objDocumentoCab = new DocumentoCab();

        public static List<DocumentoCab> objListaDocumentoCab = new List<DocumentoCab>();
        public static List<FacturaReporteDTO> objListFacturaReporte = new List<FacturaReporteDTO>();
        public static List<EstadoSunat> objListaEstadoSunat = new List<EstadoSunat>();
        static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<DocumentoElectronicoDet> objListDocumentoElectronicoDet = new List<DocumentoElectronicoDet>();
        public static DocumentoElectronicoCab objDocumentoElectronicoCab = new DocumentoElectronicoCab();
        Proceso objProceso = new Proceso();
        MonedaDAO objMonedaDao;
        OtDAO objOtDAO;
        public static String operacionFactura = "Q";
        public static String numeroDocumento = "";
        public static String NumeroExtranjero = "";
        public static String numeroSerie = "";
        public static String nroOt = "";
        public static String tablaC = "";
        public static int item = 0;


        public ListaFactura()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "FACTURAS";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            formListaFactura = this;
            gridParams();
            cmbEstado();
            objOtDAO = new OtDAO();
            objDocumentoDao = new DocumentoDAO();
            DateTime d1, d2;
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            d2 = DateTime.Now;
            d1 = new DateTime(2018, 10, 1);
            dpickerInicio.Value = d1;
            objListaDocumentoCab = objDocumentoDao.listarCabecera(d1, d2, txt_Ruc.Text, "01", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
            sumatorias();
            cmb_Estado.SelectedIndexChanged += Cmb_Estado_SelectedIndexChanged;
        }

        private void Cmb_Estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmb_Estado.SelectedValue.ToString()) != 4)
            {
                grd_Facturas.DataSource = null;
               grd_Facturas.DataSource = objListaDocumentoCab.Where(x => x.EstadoSunat == Convert.ToInt32(cmb_Estado.SelectedValue.ToString())).ToList();
                grd_Facturas.Refresh();
            }else
            {
                grd_Facturas.DataSource = null;
                grd_Facturas.DataSource = objListaDocumentoCab;
                grd_Facturas.Refresh();
            }
        }

        void cmbEstado()
        {
            EstadoSunat obj = new EstadoSunat();
            obj.Codigo = 4;
            obj.Descripcion = "TODOS";
            objListaEstadoSunat.Add(obj);
            obj = new EstadoSunat();
            obj.Codigo = 0;
            obj.Descripcion = "ANULADO";
            objListaEstadoSunat.Add(obj);
            obj = new EstadoSunat();
            obj.Codigo = 1;
            obj.Descripcion = "NO ENVIADO";
            objListaEstadoSunat.Add(obj);
            obj = new EstadoSunat();
            obj.Codigo = 2;
            obj.Descripcion = "ENVIADO";
            objListaEstadoSunat.Add(obj);
            obj = new EstadoSunat();
            obj.Codigo = 3;
            obj.Descripcion = "ACEPTADO";
            objListaEstadoSunat.Add(obj);
            cmb_Estado.DataSource = objListaEstadoSunat;
            cmb_Estado.ValueMember = "Codigo";
            cmb_Estado.DisplayMember = "Descripcion";
            cmb_Estado.Refresh();
        }
        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            lbl_Sunat.Visible = true;
            //lbl_Sunat.Text = objDocumentoDao.getSunatObs(numeroSerie, numeroDocumento);
            if (objDocumentoCab.EstadoSunat == 1)
            {
                lbl_Sunat.Text = "NO ENVIADO";
            }
            else if (objDocumentoCab.EstadoSunat == 0)
            {
                lbl_Sunat.Text = "ANULADO";
            }
            else if (objDocumentoCab.EstadoSunat == 2)
            {
                lbl_Sunat.Text = "ENVIADO";
            }
            else if (objDocumentoCab.EstadoSunat == 3)
            {
                lbl_Sunat.Text = "ACEPTADO POR SUNAT";
            }

            switch (objDocumentoCab.EstadoSunat)
            {
                case 0:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = true;
                    btn_Consultar.Enabled = true;
                    break;
                case 1:
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = false;
                    break;
                case 2:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = true;
                    break;
                case 3:
                    btn_EnviarSunat.Enabled = false;
                    btn_Anular.Enabled = true;
                    btn_Consultar.Enabled = true;
                    btn_ConAnulacion.Enabled = false;
                    break;
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            btn_Nuevo.Enabled = false;
            this.Hide();
            operacionFactura = "N";
            Factura Check = new Factura();
            Check.Show();
            btn_Nuevo.Enabled = true;
        }


        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.Width = 50;
            idColumn1.DataPropertyName = "DocumentoCabSerie";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn100 = new DataGridViewTextBoxColumn();
            idColumn100.Name = "Número";
            idColumn100.DataPropertyName = "DocumentoCabNro";
            idColumn100.Width = 90;
            grd_Facturas.Columns.Add(idColumn100);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Fecha";
            idColumn2.DataPropertyName = "DocumentoCabFecha";
            idColumn2.Width = 80;
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Razón Social";
            idColumn3.DataPropertyName = "DocumentoCabCliente";
            idColumn3.Width = 280;
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "RUC";
            idColumn4.DataPropertyName = "DocumentoCabClienteDocumento";
            idColumn4.Width = 100;
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "DocumentoCabMoneda";
            idColumn5.Width = 100;
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumnS = new DataGridViewTextBoxColumn();
            idColumnS.Name = "SubTotal";
            idColumnS.DataPropertyName = "DocumentoCabTotalSinIGV";
            idColumnS.Width = 70;
            grd_Facturas.Columns.Add(idColumnS);
            DataGridViewTextBoxColumn idColumnIGV = new DataGridViewTextBoxColumn();
            idColumnIGV.Name = "IGV";
            idColumnIGV.DataPropertyName = "DocumentoCabIGV";
            idColumnIGV.Width = 60;
            grd_Facturas.Columns.Add(idColumnIGV);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Total";
            idColumn6.DataPropertyName = "DocumentoCabTotal";
            idColumn6.Width = 80;
            grd_Facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Estado";
            idColumn7.DataPropertyName = "EstadoS";
            idColumn7.Width = 140;
            grd_Facturas.Columns.Add(idColumn7);

        }
        void sumatorias()
        {
            txt_TotalSoles.Text = objListaDocumentoCab.Where(x => x.DocumentoCabTipoMoneda == "PEN").Sum(x => x.DocumentoCabTotal).ToString("C").Substring(3);
            txt_TotalDolares.Text = objListaDocumentoCab.Where(x => x.DocumentoCabTipoMoneda == "USD").Sum(x => x.DocumentoCabTotal).ToString("C").Substring(3);
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            objListaDocumentoCab = new List<DocumentoCab>();
            grd_Facturas.DataSource = null;
            objListaDocumentoCab = objDocumentoDao.listarCabecera(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text, "01", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            sumatorias();
            btn_Buscar.Enabled = true;
        }

        private void btn_ver_Click(object sender, EventArgs e)
        {
            operacionFactura = "V";
            try
            {
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
                numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
                objDocumentoCab = objListaDocumentoCab[index];
                this.Hide();

                Factura Check = new Factura();
                Check.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("F");
        }

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                btn_pdf.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|01" + "|" +
   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();

                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                cr.SetDataSource(objListFacturaReporte);

                saveFileDialog1.FileName = "20300166611-01-" + objDocumentoCab.DocumentoCabSerie +
                   "-" + objDocumentoCab.DocumentoCabNro + ".pdf";
                saveFileDialog1.DefaultExt = "pdf";
                saveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @saveFileDialog1.FileName);
                }
                btn_pdf.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btn_pdf.Enabled = true;
            }
        }
        private void formatearFactura(String qr)
        {
            objListDocumentoDet = new List<DocumentoDet>();
            objListFacturaReporte = new List<FacturaReporteDTO>();
            objListDocumentoDet = objDocumentoDao.detalleReporte(objDocumentoCab.DocumentoCabSerie,objDocumentoCab.DocumentoCabNro, Ventas.UNIDADNEGOCIO);

            if (objListDocumentoDet.Count > 0)
            {
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    objFacturaReporte = new FacturaReporteDTO();
                    objFacturaReporte.Cantidad = objListDocumentoDet[i].DocumentoDetCantidad.ToString("C").Substring(3);
                    objFacturaReporte.Descuento = "0";
                    objFacturaReporte.Direccion = objDocumentoCab.DocumentoCabClienteDireccion;
                    objFacturaReporte.FechaEmision = objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                    objFacturaReporte.FechaVcto = objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();
                    objFacturaReporte.GuiaRemision = "";
                    objFacturaReporte.IGV = objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                    objFacturaReporte.Letras = objDocumentoDao.numeroALetras(convertToDouble(objDocumentoCab.DocumentoCabTotal.ToString())) + " " + objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                    objFacturaReporte.Moneda = objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                    objFacturaReporte.Numero = objDocumentoCab.DocumentoCabNro.TrimEnd();
                    objFacturaReporte.Serie = objDocumentoCab.DocumentoCabSerie;
                    objFacturaReporte.TipoPago = objDocumentoCab.DocumentoCabPago.TrimEnd();
                    objFacturaReporte.TOTAL = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                    objFacturaReporte.TotalSinIGV = objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                    objFacturaReporte.UM = objListDocumentoDet[i].DocumentoProdUMcorta;
                    objFacturaReporte.ValorUnitario = objListDocumentoDet[i].DocumentoDetPrecioSinIGV.ToString("C").Substring(3);
                    objFacturaReporte.ValorVenta = objListDocumentoDet[i].DocumentoDetSubTotal.ToString("C").Substring(3);
                    objFacturaReporte.PrecioUnitario = ((objListDocumentoDet[i].DocumentoDetPrecioSinIGV * 0.18) + objListDocumentoDet[i].DocumentoDetPrecioSinIGV).ToString("C").Substring(3);
                    objFacturaReporte.ProdCod = objListDocumentoDet[i].ProductoCod.TrimEnd();
                    objFacturaReporte.ProdDescrip = objListDocumentoDet[i].DocumentoDesProducto.TrimEnd() + " - " + objListDocumentoDet[i].DocumentoDetGlosa;
                    objFacturaReporte.RazonSocial = objDocumentoCab.DocumentoCabCliente;
                    objFacturaReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;
                    objFacturaReporte.OrdenCompra = "";
                    objFacturaReporte.Tipo = "la Factura Electrónica";
                    objFacturaReporte.QR = qr;
                    objFacturaReporte.Glosa = objDocumentoCab.DocumentoCabGlosa;
                    objFacturaReporte.TipoDocumento = "FACTURA ELECTRÓNICA";
                    objFacturaReporte.DetraccionPorcentaje = objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                    objFacturaReporte.DetraccionMonto = objDocumentoCab.DocumentoCabDetraccion.ToString();
                    objFacturaReporte.GuiaRemision = objDocumentoCab.DocumentoCabGuia;
                    objFacturaReporte.OrdenCompra = objDocumentoCab.DocumentoCabOrdenCompra;
                    objFacturaReporte.TipoCambio = objMonedaDao.getTipoCambioVenta(objFacturaReporte.FechaEmision).ToString().PadRight(5, '0');

                    if (Ventas.UNIDADNEGOCIO == "02")
                    {
                        objFacturaReporte.DatoDetraccion = "CÓDIGO PARA DETRACCIÓN: BIEN O SERVICIO:(025) Fabr de bienes x encargo/operación/ (01) Venta de bienes o prest de serv";
                    }
                    if (objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                    {
                        objFacturaReporte.Simbolo = "$";
                    }
                    else
                    {
                        objFacturaReporte.Simbolo = "S/";
                    }
                    objListFacturaReporte.Add(objFacturaReporte);
                }
            }
            else
            {
                objFacturaReporte = new FacturaReporteDTO();
                objFacturaReporte.Descuento = "0";
                objFacturaReporte.Direccion = objDocumentoCab.DocumentoCabClienteDireccion;
                objFacturaReporte.FechaEmision = objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                objFacturaReporte.FechaVcto = objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();
                objFacturaReporte.GuiaRemision = "";
                objFacturaReporte.IGV = objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                objFacturaReporte.Letras = objDocumentoDao.numeroALetras(convertToDouble(objDocumentoCab.DocumentoCabTotal.ToString())) + " " + objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                objFacturaReporte.Moneda = objDocumentoCab.DocumentoCabMoneda.TrimEnd();
                objFacturaReporte.Numero = objDocumentoCab.DocumentoCabNro.TrimEnd();
                objFacturaReporte.Serie = objDocumentoCab.DocumentoCabSerie;
                objFacturaReporte.TipoPago = objDocumentoCab.DocumentoCabPago.TrimEnd();
                objFacturaReporte.TOTAL = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                objFacturaReporte.TotalSinIGV = objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                objFacturaReporte.RazonSocial = objDocumentoCab.DocumentoCabCliente;
                objFacturaReporte.RUC = objDocumentoCab.DocumentoCabClienteDocumento;

                objFacturaReporte.Tipo = "la Factura Electrónica";
                objFacturaReporte.QR = qr;
                objFacturaReporte.OrdenCompra = "";
                objFacturaReporte.TipoDocumento = "FACTURA ELECTRÓNICA";
                objFacturaReporte.DetraccionPorcentaje = objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                objFacturaReporte.DetraccionMonto = objDocumentoCab.DocumentoCabDetraccion.ToString();
                objFacturaReporte.GuiaRemision = objDocumentoCab.DocumentoCabGuia;
                objFacturaReporte.OrdenCompra = objDocumentoCab.DocumentoCabOrdenCompra;
                if (Ventas.UNIDADNEGOCIO == "02")
                {
                    objFacturaReporte.DatoDetraccion = "CÓDIGO PARA DETRACCIÓN: BIEN O SERVICIO:(025) Fabr de bienes x encargo/operación/ (01) Venta de bienes o prest de serv";
                }
                if (ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                {
                    objFacturaReporte.Simbolo = "$";
                }
                else
                {
                    objFacturaReporte.Simbolo = "S/";

                }
                objListFacturaReporte.Add(objFacturaReporte);
            }


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

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Reporte.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|01" + "|" +
                   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
                   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);

                ReporteView Check = new ReporteView("LF"); // listar factura
                Check.Show();
                btn_Reporte.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_Reporte.Enabled = true;
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            try
            {
                btn_excel.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|01" + "|" +
   objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();

                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                cr.SetDataSource(objListFacturaReporte);

                saveFileDialog1.FileName = "20300166611-07-" + objDocumentoCab.DocumentoCabSerie +
                   "-" + objDocumentoCab.DocumentoCabNro + ".xls";
                saveFileDialog1.DefaultExt = "xls";
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.ExcelRecord, @saveFileDialog1.FileName);
                }
                btn_excel.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_excel.Enabled = true;
            }
        }

        private void btn_EnviarSunat_Click(object sender, EventArgs e)
        {

            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            NumeroExtranjero = objListaDocumentoCab[index].DocumentoCabTipoDoc;
            objDocumentoCab = objListaDocumentoCab[index];
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            objListDocumentoElectronicoDet = objDocumentoDao.getDocumentoElectronicoDet(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarText(objDocumentoElectronicoCab, objListDocumentoElectronicoDet);
            String mess = objProceso.sendTxt(rutatext);
           
            String mensajeMostrar = "";
            String[] array = mess.Split('|');

            List<String> objListaString = array.ToList();
            if (objListaString.Count < 10)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                //objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
                btn_EnviarSunat.Enabled = true;
                btn_Anular.Enabled = false;
                btn_ConAnulacion.Enabled = false;
                btn_Consultar.Enabled = false;
            }
            else
            {
                mensajeMostrar = objListaString[9];
                if (mensajeMostrar == "true")
                {
                    mensajeMostrar = "DOCUMENTO ENVIADO";
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    objDocumentoDao.updateEstadoEnviado(numeroSerie, numeroDocumento);
                    //objDocumentoDao.updateEstadoAceptado(numeroSerie, numeroDocumento);
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = false;
                }
                else
                {
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    btn_EnviarSunat.Enabled = true;
                    btn_Anular.Enabled = false;
                    btn_ConAnulacion.Enabled = false;
                    btn_Consultar.Enabled = false;
                }
            }
            cargarLuegoAnulacion();
            MessageBox.Show(mensajeMostrar);
        }
        public void setMotivoAnulacion(String mot)
        {
            MotivoAnulacion = mot;
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String mensajeMostrar = "";
            String rutatext = objProceso.generarAnulacion(objDocumentoElectronicoCab, mot);
            String mess = objProceso.sendTxt(rutatext);

            String[] array = mess.Split('|');
            List<String> objListaString = array.ToList();

            mensajeMostrar = "SOLICITUD DE ANULACIÓN ENVIADA";
            objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
            objListDocumentoDet = objDocumentoDao.listarDetalle(numeroDocumento, numeroSerie, Ventas.UNIDADNEGOCIO);
            for (int i = 0; i < objListDocumentoDet.Count; i++)
            {
                objOtDAO.updateEstadoAnulacionAntiguo(objListDocumentoDet[i].DocumentoDetNroOt, objListDocumentoDet[i].DocumentoDetItemOt, Ventas.UNIDADNEGOCIO);
                objOtDAO.updateEstadoAnulacionNuevo(objListDocumentoDet[i].DocumentoDetNroOt, objListDocumentoDet[i].DocumentoDetItemOt, Ventas.UNIDADNEGOCIO);
            }
            objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
            //if (tablaC == "A")
            //{
            //    objOtDAO.updateEstadoAnulacionAntiguo(nroOt, item, Ventas.UNIDADNEGOCIO);
            //} else if (tablaC == "N")
            //{
            //    objOtDAO.updateEstadoAnulacionNuevo (nroOt, item, Ventas.UNIDADNEGOCIO);
            //}

            MessageBox.Show(mensajeMostrar);
            cargarLuegoAnulacion();
        }

        private void btn_Anular_Click(object sender, EventArgs e)
        {
            try
            {
                int index = grd_Facturas.SelectedCells[0].RowIndex;
                numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
                numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
                item = objListaDocumentoCab[index].DocumentoCabItemOt;
                nroOt = objListaDocumentoCab[index].DocumentoCabOtCod;
                using (var form = new MotivoAnulacion("F"))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe seleccionar un documento");
            }
        }
        void cargarLuegoAnulacion()
        {
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            objListaDocumentoCab = objDocumentoDao.listarCabecera(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text, "01", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = objListaDocumentoCab;
            grd_Facturas.Refresh();
            sumatorias();
        }

        private void btn_imprimir_Click(object sender, EventArgs e)
        {
            string root = @"N:\PDF";
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            try
            {
                btn_imprimir.Enabled = false;
                int index = grd_Facturas.SelectedCells[0].RowIndex;

                objDocumentoCab = objListaDocumentoCab[index];
                String codigoagenerar = "20300166611|01" + "|" + objDocumentoCab.DocumentoCabSerie + "|" + objDocumentoCab.DocumentoCabNro + "|" + objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3).Trim() + "|"
   + objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3).Trim() + "|" + objDocumentoCab.DocumentoCabFecha.ToString("dd-MM-yyyy") + "|" + "6|" + objDocumentoCab.DocumentoCabClienteDocumento + "|";
                String nombreArchivo = objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();
                string rut = @"N:\PDF\20300166611-" + objDocumentoCab.DocumentoCabSerie + "-" + objDocumentoCab.DocumentoCabNro + ".pdf";
                // System.Web.HttpResponse res = new System.Web.HttpResponse();
                if (File.Exists(rut))
                {
                    File.Delete(rut);
                }
                cr.SetDataSource(objListFacturaReporte);
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rut);

                using (PrintDialog Dialog = new PrintDialog())
                {
                    Dialog.ShowDialog();

                    ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                    {
                        Verb = "print",
                        CreateNoWindow = true,
                        FileName = rut,
                        WindowStyle = ProcessWindowStyle.Hidden
                    };

                    Process printProcess = new Process();
                    printProcess.StartInfo = printProcessInfo;
                    printProcess.Start();

                    printProcess.WaitForInputIdle();

                    Thread.Sleep(3000);

                    if (false == printProcess.CloseMainWindow())
                    {
                        printProcess.Kill();
                    }
                }
                btn_imprimir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                btn_imprimir.Enabled = true;
            }





        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarConsulta(objDocumentoElectronicoCab);
            String mess = objProceso.sendTxt(rutatext);
            String mensajeMostrar = "";
            String[] array = mess.Split('|');
            List<String> objListaString = array.ToList();//11-1
            if (objListaString.Count < 10)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
            }
            else
            {
                mensajeMostrar = objListaString[11];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                objDocumentoDao.updateEstadoAceptado(numeroSerie, numeroDocumento);
                objListaDocumentoCab = objDocumentoDao.listarCabecera(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text, "01", Ventas.UNIDADNEGOCIO);
                grd_Facturas.DataSource = null;
                grd_Facturas.DataSource = objListaDocumentoCab;

                grd_Facturas.Refresh();
            }
        }

        private void btn_ConAnulacion_Click(object sender, EventArgs e)
        {
            int index = grd_Facturas.SelectedCells[0].RowIndex;

            numeroDocumento = objListaDocumentoCab[index].DocumentoCabNro;
            numeroSerie = objListaDocumentoCab[index].DocumentoCabSerie;
            objDocumentoCab = objListaDocumentoCab[index];
            objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
            String rutatext = objProceso.generarConsultaAnulacion(objDocumentoElectronicoCab);
            String mess = objProceso.sendTxt(rutatext);
            String mensajeMostrar = "";
            String[] array = mess.Split('|');
            List<String> objListaString = array.ToList();//9
            if (objListaString.Count < 8)
            {
                mensajeMostrar = objListaString[1];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
            }
            else
            {
                mensajeMostrar = objListaString[9];
                objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                objDocumentoDao.updateEstadoAnulado(numeroSerie, numeroDocumento);
            }
        }

        private void btn_ConsultarMasivo_Click(object sender, EventArgs e)
        {
            btn_ConsultarMasivo.Enabled = false;
            List<DocumentoCab> objListConsulta = new List<DocumentoCab>();
            objListConsulta = objDocumentoDao.listarDocumentosPorConsultar("01", Ventas.UNIDADNEGOCIO);
            for (int i = 0; i < objListConsulta.Count; i++)
            {
                numeroDocumento = objListConsulta[i].DocumentoCabNro;
                numeroSerie = objListConsulta[i].DocumentoCabSerie;
                objDocumentoElectronicoCab = objDocumentoDao.getDocumentoElectronicoCab(numeroSerie, numeroDocumento, Ventas.UNIDADNEGOCIO);
                String rutatext = objProceso.generarConsulta(objDocumentoElectronicoCab);
                String mess = objProceso.sendTxt(rutatext);
                String mensajeMostrar = "";
                String[] array = mess.Split('|');
                List<String> objListaString = array.ToList();//11-1
                if (objListaString.Count < 10)
                {
                    mensajeMostrar = objListaString[1];
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                }
                else
                {
                    mensajeMostrar = objListaString[11];
                    objDocumentoDao.updateObservacionSunat(numeroSerie, numeroDocumento, mensajeMostrar);
                    objDocumentoDao.updateEstadoAceptado(numeroSerie, numeroDocumento);

                }
            }
            objListaDocumentoCab = objDocumentoDao.listarCabecera(dpickerInicio.Value, dpickerFin.Value, txt_Ruc.Text, "01", Ventas.UNIDADNEGOCIO);
            grd_Facturas.DataSource = null;
            grd_Facturas.DataSource = objListaDocumentoCab;

            grd_Facturas.Refresh();
            btn_ConsultarMasivo.Enabled = true;
        }
    }
}
