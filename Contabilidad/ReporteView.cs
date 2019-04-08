using Contabilidad.Report;
using CrystalDecisions.Windows.Forms;
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
    public partial class ReporteView : Form
    {
        public ReporteView(String tipo)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;
            this.Location = new Point(100, 0);
            this.MaximumSize = new Size(1500, 900);
            switch (tipo)
            {
                case "FF":
                    FacturaFecha cr = new FacturaFecha();
                    crystalReportViewer1.ReportSource = cr;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr.SetDataSource(FacturaReporte.objListFacturaReporte);
                    break;
                case "BF":
                    FacturaFecha cr2 = new FacturaFecha();
                    crystalReportViewer1.ReportSource = cr2;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr2.SetDataSource(BoletaReporte.objListFacturaReporte);
                    break;
                case "CF":
                    NotaFecha cr3 = new NotaFecha();
                    crystalReportViewer1.ReportSource = cr3;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr3.SetDataSource(NotaCreditoReporte.objListNotaReporte);
                    break;
                case "DF":
                    NotaFecha cr4 = new NotaFecha();
                    crystalReportViewer1.ReportSource = cr4;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr4.SetDataSource(NotaDebitoReporte.objListNotaReporte);
                    break;
                case "LF":
                    FacturaFecha cr5 = new FacturaFecha();
                    crystalReportViewer1.ReportSource = cr5;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr5.SetDataSource(ListaFactura.objListFacturaReporte);
                    break;
                case "LB":
                    FacturaFecha cr6 = new FacturaFecha();
                    crystalReportViewer1.ReportSource = cr6;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr6.SetDataSource(ListaBoleta.objListFacturaReporte);
                    break;
                case "LC":
                    NotaFecha cr7 = new NotaFecha();
                    crystalReportViewer1.ReportSource = cr7;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr7.SetDataSource(ListaNotaCredito.objListNotaReporte);
                    break;
                case "LD":
                    NotaFecha cr8 = new NotaFecha();
                    crystalReportViewer1.ReportSource = cr8;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr8.SetDataSource(ListaNotaDebito.objListNotaReporte);
                    break;
                case "LL":
                    Letras cr9 = new Letras();
                    crystalReportViewer1.ReportSource = cr9;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr9.SetDataSource(ListaLetraCambio.objListaLetraReporte);
                    break;
                case "EF":
                    DocumentoExcel cr10 = new DocumentoExcel();
                    crystalReportViewer1.ReportSource = cr10;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr10.SetDataSource(ReporteDocumentosPorFecha.objListaReporteExcel);
                    break;
                case "EC":
                    DocumentoExcel cr11 = new DocumentoExcel();
                    crystalReportViewer1.ReportSource = cr11;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr11.SetDataSource(ReporteDocumentosPorCliente.objListaReporteExcel);
                    break;
                case "VO":
                    VoucherRpt cr12 = new VoucherRpt();
                    crystalReportViewer1.ReportSource = cr12;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr12.SetDataSource(Caja.EmisionVoucher.objListaVoucherReporte);
                    break;
                case "VOD":
                    VoucherRptDolar cr13 = new VoucherRptDolar();
                    crystalReportViewer1.ReportSource = cr13;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr13.SetDataSource(Caja.EmisionVoucher.objListaVoucherReporte);
                    break;
                case "LCRC":
                    CanjeLetra cr14 = new CanjeLetra();
                    crystalReportViewer1.ReportSource = cr14;
                    cr14.SetDataSource(Facturacion.CanjeLetraNuevo.objListaLetraReporte);
                    break;
                case "RDC":
                    ReporteDiarioC cr15 = new ReporteDiarioC();
                    crystalReportViewer1.ReportSource = cr15;
                    cr15.SetDataSource(Reporte.ReporteDiario.objListaReporte);
                    break;
                case "RFMP":
                    ReporteMensualProveedor cr16 = new ReporteMensualProveedor();
                    crystalReportViewer1.ReportSource = cr16;
                    cr16.SetDataSource(Reporte.ReporteFacturaProveeodr.objListaVenReporte);
                    break;
                case "RFTP":
                    ReporteTotalizadoProveedor cr17 = new ReporteTotalizadoProveedor();
                    crystalReportViewer1.ReportSource = cr17;
                    cr17.SetDataSource(Reporte.ReporteFacturaProveedorTotalizado.objListaVenReporte);
                    break;
            }
        }
    }
}
