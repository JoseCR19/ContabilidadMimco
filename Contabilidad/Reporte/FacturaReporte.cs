using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad
{
    public partial class FacturaReporte : Form
    {
        DocumentoDet objDocumentoDet;
        FacturaReporteDTO objFacturaReporte;
        MonedaDAO objMoneda;
        DocumentoDAO objDocumentoDao;
        Proceso objProceso;
 
        static List<DocumentoDet> objListDocumentoDet = new List<DocumentoDet>();
        public static List<FacturaReporteDTO> objListFacturaReporte = new List<FacturaReporteDTO>();
        static int index ;
        static String tipoDocumento, tipoReporte;
        public FacturaReporte(String tipoDocu, String tipoReport)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 0);
            tipoDocumento = tipoDocu;
            tipoReporte = tipoReport;
            objProceso = new Proceso();
            this.ControlBox = false;
            this.Text = "REPORTE FACTURAS";
            gridParams();
            objMoneda = new MonedaDAO();
            objDocumentoDao = new DocumentoDAO();
            grd_Detalle.CellClick += Grd_Detalle_CellClick;
            if (tipoReporte =="F")
            {
                txt_Ruc.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Cliente.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabCliente;
                txt_Direccion.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_GlosaCab.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabGlosa;
                txt_Serie.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabNro;
                txt_Moneda.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabMoneda;
              //  txt_OT.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabOtCod;
                txt_Pago.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabPago;
                dpick_Fecha.Value = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechavcto.Value = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFechaVcto;
                txt_IGV.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                txt_TotalsinPercep.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                txt_ValorVenta.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                tipoCambio(dpick_Fecha.Value.ToShortDateString());
                
                objListDocumentoDet = objDocumentoDao.detalleReporte(ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabSerie,
                    ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabNro, Ventas.UNIDADNEGOCIO);
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
                lblTotal.Text = objDocumentoDao.numeroALetras(convertToDouble(ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTotal.ToString())) + " " + txt_Moneda.Text;
                if (ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                {
                    lbl_Moneda.Text = "$";
                }
                txt_Detraccion.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabDetraccion.ToString();
                txt_Porcentaje.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                txt_Guia.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabGuia;
                txt_Pedido.Text = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabOrdenCompra;
            }
            else if(tipoReporte == "C")
            {
                txt_Ruc.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDocumento;
                txt_Cliente.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabCliente;
                txt_Direccion.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabClienteDireccion;
                txt_GlosaCab.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabGlosa;
                txt_Serie.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabSerie;
                txt_Numero.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabNro;
                txt_Moneda.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabMoneda;
                txt_OT.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabOtCod;
                txt_Pago.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabPago;
                dpick_Fecha.Value = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFecha;
                dpck_Fechavcto.Value = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFechaVcto;
                txt_IGV.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabIGV.ToString("C").Substring(3);
                txt_TotalsinPercep.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
                txt_ValorVenta.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTotalSinIGV.ToString("C").Substring(3);
                tipoCambio(dpick_Fecha.Value.ToShortDateString());
            
                objListDocumentoDet = objDocumentoDao.detalleReporte(ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabSerie,
                    ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabNro, Ventas.UNIDADNEGOCIO);
                grd_Detalle.DataSource = objListDocumentoDet;
                grd_Detalle.Refresh();
                lblTotal.Text = objDocumentoDao.numeroALetras(convertToDouble(ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTotal.ToString())) + " " + txt_Moneda.Text;
                if (ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabTipoMoneda == "USD")
                {
                    lbl_Moneda.Text = "$";
                }
                txt_Detraccion.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabDetraccion.ToString();
                txt_Porcentaje.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabDetraccionPorcentaje.ToString();
                txt_Guia.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabGuia;
                txt_Pedido.Text = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabOrdenCompra;
            }

            
        }

        private void Grd_Detalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (objListDocumentoDet.Count != 0)
            {
                objDocumentoDet = new DocumentoDet();
                index = grd_Detalle.SelectedCells[0].RowIndex;
                objDocumentoDet = objListDocumentoDet[index];
                txt_ItemN.Text = objDocumentoDet.DocumentoDetId.ToString();
                txt_CodigoProd.Text = objDocumentoDet.ProductoCod;
                txt_ProdDescrip.Text = objDocumentoDet.DocumentoDesProducto;
                txt_UM.Text = objDocumentoDet.DocumentoProdUMcorta;
                txt_Subtotal.Text = objDocumentoDet.DocumentoDetSubTotal.ToString();
                txt_PrecioUnitario.Text = objDocumentoDet.DocumentoDetPrecioSinIGV.ToString();
                txt_Cantidad.Text = objDocumentoDet.DocumentoDetCantidad.ToString();
                txt_GlosaDet.Text = objDocumentoDet.DocumentoDetGlosa;
                txt_OT.Text = objDocumentoDet.DocumentoDetNroOt;
                
            }
        }

        public void tipoCambio(String date)
        {
            txt_Tcambio.Text = objMoneda.getTipoCambioVenta(date).ToString().PadRight(5, '0');
        }
        public void gridParams()
        {
            grd_Detalle.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "ITEM";
            idColumn1.DataPropertyName = "DocumentoDetId";
            idColumn1.Width = 60;
            grd_Detalle.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "CÓDIGO";
            idColumn2.DataPropertyName = "ProductoCod";
            idColumn2.Width = 120;
            grd_Detalle.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "CANTIDAD";
            idColumn3.DataPropertyName = "DocumentoDetCantidad";
            idColumn3.Width = 100;
            grd_Detalle.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "DESCRIPCION";
            idColumn4.DataPropertyName = "DocumentoDesProducto";
            idColumn4.Width = 345;
            grd_Detalle.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "PRECIO UNITARIO";
            idColumn5.DataPropertyName = "DocumentoDetPrecioSinIGV";
            idColumn5.Width = 130;
            grd_Detalle.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "SUB TOTAL";
            idColumn6.DataPropertyName = "DocumentoDetSubTotal";
            idColumn6.Width = 120;
            grd_Detalle.Columns.Add(idColumn6);
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
           
          
            if (tipoReporte == "F")
            {
                this.Hide();
                ReporteDocumentosPorCliente Check = new ReporteDocumentosPorCliente();
               Check.Show();
            }
            else if (tipoReporte == "C")
            {
                this.Hide();
                ReporteDocumentosPorCliente Check = new ReporteDocumentosPorCliente();
                Check.Show();
            }
            
        }
        private void formatearFactura(String qr)
        {
            objListFacturaReporte = new List<FacturaReporteDTO>();
            if (objListDocumentoDet.Count > 0)
            {
                for (int i = 0; i < objListDocumentoDet.Count; i++)
                {
                    objFacturaReporte = new FacturaReporteDTO();
                    objFacturaReporte.Cantidad = objListDocumentoDet[i].DocumentoDetCantidad.ToString("C").Substring(3);
                    objFacturaReporte.Descuento = "0";
                    objFacturaReporte.Direccion =txt_Direccion.Text;
                    if (tipoReporte == "F")
                    {
                        objFacturaReporte.FechaEmision = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                        objFacturaReporte.FechaVcto = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();

                    }
                    else if (tipoReporte == "C")
                    {
                        objFacturaReporte.FechaEmision = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                        objFacturaReporte.FechaVcto = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();

                    }
              
                    objFacturaReporte.IGV = txt_IGV.Text;
                    objFacturaReporte.Letras = lblTotal.Text.TrimEnd();
                    objFacturaReporte.Moneda = txt_Moneda.Text.TrimEnd();
                    objFacturaReporte.Numero = txt_Numero.Text.TrimEnd();
                    objFacturaReporte.Serie = txt_Serie.Text;
                    objFacturaReporte.TipoPago = txt_Pago.Text.TrimEnd();
                    objFacturaReporte.TOTAL = txt_TotalsinPercep.Text;
                    objFacturaReporte.TotalSinIGV = txt_ValorVenta.Text;
                    objFacturaReporte.UM = objListDocumentoDet[i].DocumentoProdUMcorta;
                    objFacturaReporte.ValorUnitario = objListDocumentoDet[i].DocumentoDetPrecioSinIGV.ToString("C").Substring(3);
                    objFacturaReporte.ValorVenta = objListDocumentoDet[i].DocumentoDetSubTotal.ToString("C").Substring(3);
                    objFacturaReporte.PrecioUnitario = ((objListDocumentoDet[i].DocumentoDetPrecioSinIGV * 0.18 ) + objListDocumentoDet[i].DocumentoDetPrecioSinIGV ).ToString("C").Substring(3);
                    objFacturaReporte.ProdCod = objListDocumentoDet[i].ProductoCod.TrimEnd();
                    objFacturaReporte.ProdDescrip = objListDocumentoDet[i].DocumentoDesProducto.TrimEnd() + " - " + objListDocumentoDet[i].DocumentoDetGlosa;
                    objFacturaReporte.RazonSocial = txt_Cliente.Text;
                    objFacturaReporte.RUC = txt_Ruc.Text;
                    objFacturaReporte.Glosa = txt_GlosaCab.Text;
                    objFacturaReporte.TipoDocumento = tipoDocumento;
                    objFacturaReporte.DetraccionPorcentaje = txt_Porcentaje.Text;
                    objFacturaReporte.Tipo = "la Factura Electrónica";
                  //adsasdsadasdasdasdasd
                    objFacturaReporte.QR = qr;
                    objFacturaReporte.TipoCambio = objMoneda.getTipoCambioVenta(objFacturaReporte.FechaEmision).ToString().PadRight(5, '0');

                    objFacturaReporte.DetraccionMonto = txt_Detraccion.Text;
                    if (Ventas.UNIDADNEGOCIO == "02")
                    {
                        objFacturaReporte.DatoDetraccion = "CÓDIGO PARA DETRACCIÓN: BIEN O SERVICIO:(025) Fabr de bienes x encargo/operación/ (01) Venta de bienes o prest de serv";
                    }
                    objFacturaReporte.Simbolo = lbl_Moneda.Text;
                    objFacturaReporte.GuiaRemision = txt_Guia.Text;
                    objFacturaReporte.OrdenCompra = txt_Pedido.Text;

                    objListFacturaReporte.Add(objFacturaReporte);
                }
            }else
            {
                objFacturaReporte = new FacturaReporteDTO();
                objFacturaReporte.Descuento = "0";
                objFacturaReporte.Direccion = txt_Direccion.Text;
                if (tipoReporte == "F")
                {
                    objFacturaReporte.FechaEmision = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                    objFacturaReporte.FechaVcto = ReporteDocumentosPorFecha.objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();

                }
                else if (tipoReporte == "C")
                {
                    objFacturaReporte.FechaEmision = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFecha.ToShortDateString();
                    objFacturaReporte.FechaVcto = ReporteDocumentosPorCliente.objDocumentoCab.DocumentoCabFechaVcto.ToShortDateString();

                }
            
                objFacturaReporte.IGV = txt_IGV.Text;
                objFacturaReporte.Letras = lblTotal.Text.TrimEnd();
                objFacturaReporte.Moneda = txt_Moneda.Text.TrimEnd();
                objFacturaReporte.Numero = txt_Numero.Text.TrimEnd();
                objFacturaReporte.Serie = txt_Serie.Text;
                objFacturaReporte.TipoPago = txt_Pago.Text.TrimEnd();
                objFacturaReporte.TOTAL = txt_TotalsinPercep.Text;
                objFacturaReporte.TotalSinIGV = txt_ValorVenta.Text;
                objFacturaReporte.RazonSocial = txt_Cliente.Text;
                objFacturaReporte.RUC = txt_Ruc.Text;
                objFacturaReporte.Glosa = txt_GlosaCab.Text;
                objFacturaReporte.TipoDocumento = tipoDocumento;
                objFacturaReporte.DetraccionPorcentaje = txt_Porcentaje.Text;
                objFacturaReporte.DetraccionMonto = txt_Detraccion.Text;
                if (Ventas.UNIDADNEGOCIO == "02")
                {
                    objFacturaReporte.DatoDetraccion = "CÓDIGO PARA DETRACCIÓN: BIEN O SERVICIO:(025) Fabr de bienes x encargo/operación/ (01) Venta de bienes o prest de serv";
                }
                objFacturaReporte.Simbolo = lbl_Moneda.Text;
                objFacturaReporte.GuiaRemision = txt_Guia.Text;
                objFacturaReporte.OrdenCompra = txt_Pedido.Text;

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

        private void btn_pdf_Click(object sender, EventArgs e)
        {
            btn_pdf.Enabled = false;
            String codigoagenerar = "20300166611|01" + "|" +
   txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
   + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
            String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
            String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);
            formatearFactura(qr);
            FacturaFecha cr = new FacturaFecha();

            // System.Web.HttpResponse res = new System.Web.HttpResponse();
            cr.SetDataSource(objListFacturaReporte);

            saveFileDialog1.FileName = ".pdf";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "Pdf files (*.pdf)|*.pdf";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @saveFileDialog1.FileName);
            }
            btn_pdf.Enabled = true;

        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            btn_excel.Enabled = false;
            String codigoagenerar = "20300166611|01" + "|" +
  txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
  + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
            String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
            String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


            formatearFactura(qr);
            FacturaExcel cr = new FacturaExcel();
        
            // System.Web.HttpResponse res = new System.Web.HttpResponse();
            cr.SetDataSource(objListFacturaReporte);
            
            saveFileDialog1.FileName = ".xls";
            saveFileDialog1.DefaultExt = "xls";
             saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cr.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.Excel, @saveFileDialog1.FileName);
            }
            btn_excel.Enabled = true;
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
  

 
                String codigoagenerar = "20300166611|01" + "|" +
    txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
   + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
                String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
                String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


                formatearFactura(qr);
                FacturaFecha cr = new FacturaFecha();
                string rut = @"N:\PDF\20300166611-" + txt_Serie.Text + "-" + txt_Numero.Text + ".pdf";
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

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            btn_Reporte.Enabled = false;
            String codigoagenerar = "20300166611|01" + "|" +
   txt_Serie.Text + "|" + txt_Numero.Text + "|" + txt_IGV.Text.Trim() + "|"
   + txt_TotalsinPercep.Text.Trim() + "|" + dpick_Fecha.Value.ToString("dd-MM-yyyy") + "|" + "6|" + txt_Ruc.Text + "|";
            String nombreArchivo = txt_Serie.Text + "-" + txt_Numero.Text;
            String qr = objProceso.genearQr(nombreArchivo, codigoagenerar);


            formatearFactura(qr);
            ReporteView Check = new ReporteView("FF"); // factura fecha
            Check.Show();
            btn_Reporte.Enabled = true;
        }
    }
}
