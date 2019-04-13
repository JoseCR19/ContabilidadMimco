using Conta.RegistroCompras;
using Conta.RegistroVentas;
using Conta.Reporte;
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

namespace Conta
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
                case "LV":
                    LibroVentasReportePDF cr = new LibroVentasReportePDF();
                    crystalReportViewer1.ReportSource = cr;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr.SetDataSource(LibroVentas.objListVentas);
                    break;
                case "LC":
                    LibroComprasReportePdf cr1 = new LibroComprasReportePdf();
                    crystalReportViewer1.ReportSource = cr1;
                    // System.Web.HttpResponse res = new System.Web.HttpResponse();
                    cr1.SetDataSource(LibroCompras.objListCompras);
                    break;
                case "LD":
                    Reporte.LibroDiarioReporteExcel cr2 = new LibroDiarioReporteExcel();
                    crystalReportViewer1.ReportSource = cr2;
                    cr2.SetDataSource(LibrosContables.LibroDiario.objListaLibroDiario);
                    break;
                case "LM":
                    LibroMayorReporte cr3 = new LibroMayorReporte();
                    crystalReportViewer1.ReportSource = cr3;
                    cr3.SetDataSource(LibrosContables.LibroMayor.objListaLibroMayor);
                    break;
                case "LMCB":
                    LibroMayorReporte cr4 = new LibroMayorReporte();
                    crystalReportViewer1.ReportSource = cr4;
                    cr4.SetDataSource(LibrosContables.LibroMayorCajaBanco.objListaLibroMayorCajaBanco);
                    break;
            }

        }
    }
}
