using Contabilidad.Caja;
using ContabilidadDAO;
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
    public partial class Ventas : Form
    {
        public static Ventas formVentas;
        public static String UsuarioSession;
        public static String UNIDADNEGOCIO;
        public static String nomEntidad;

        MonedaDAO objMonedaDao;
        public Ventas(String Usuario, String CodEnt, String entidad)
        {
            InitializeComponent();
            //UsuarioSession = Usuario;
            //UNIDADNEGOCIO = CodEnt;
            //this.Text = "TESORERÍA";
            UNIDADNEGOCIO = CodEnt;
            nomEntidad = entidad;
            this.Text = "SISTEMA TESORERIA   -   ERPS MIMCO" + "              USUARIO  : " + Usuario.Trim() + "                    " + nomEntidad.Trim();
            UsuarioSession = Usuario;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 50);
            formVentas = this;
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            // cajaToolStripMenuItem.Enabled = false;
            // registrarAbonoBancoToolStripMenuItem.Enabled = false;//
            facturaToolStripMenuItem.Click += FacturaToolStripMenuItem_Click;
            boletaToolStripMenuItem.Click += BoletaToolStripMenuItem_Click;
            notaDeCréditoToolStripMenuItem.Click += NotaDeCréditoToolStripMenuItem_Click;
            notaDeDébitoToolStripMenuItem.Click += NotaDeDébitoToolStripMenuItem_Click;
            documentosPorFechaToolStripMenuItem.Click += DocumentosPorFechaToolStripMenuItem_Click;
            documentosPorClienteToolStripMenuItem.Click += DocumentosPorClienteToolStripMenuItem_Click;
            letraDeCambioToolStripMenuItem.Click += LetraDeCambioToolStripMenuItem_Click;
            renovaciónLetraToolStripMenuItem.Click += RenovaciónLetraToolStripMenuItem_Click;
            emisionToolStripMenuItem.Click += EmisionToolStripMenuItem_Click;
            pendientesPorFacturarToolStripMenuItem.Click += PendientesPorFacturarToolStripMenuItem_Click;
            documentosPorOTToolStripMenuItem.Click += DocumentosPorOTToolStripMenuItem_Click;
            registrarAbonoBancoToolStripMenuItem.Click += RegistrarAbonoBancoToolStripMenuItem_Click;
            cajaChicaToolStripMenuItem.Click += CajaChicaToolStripMenuItem_Click;
            liquidaciónToolStripMenuItem.Click += LiquidaciónToolStripMenuItem_Click;
            chequeToolStripMenuItem.Click += ChequeToolStripMenuItem_Click;
            voucherReporteToolStripMenuItem.Click += VoucherReporteToolStripMenuItem_Click;
            cuentasPorPagarToolStripMenuItem.Click += CuentasPorPagarToolStripMenuItem_Click;
            cuentasPorCobrarToolStripMenuItem.Click += CuentasPorCobrarToolStripMenuItem_Click;
            canjearLetrasToolStripMenuItem.Click += CanjearLetrasToolStripMenuItem_Click;
            reporteDiarioFacturasToolStripMenuItem.Click += reporteDiarioFacturasToolStripMenuItem_Click;
            documentosPorProveedorToolStripMenuItem.Click += DocumentosPorProveedorToolStripMenuItem_Click;
            documentoPorProveedorTotalizadoToolStripMenuItem.Click += DocumentoPorProveedorTotalizadoToolStripMenuItem_Click;
        }
        private void CanjearLetrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canjearLetrasToolStripMenuItem.Enabled = false;
            Facturacion.CanjeLetra Check = new Facturacion.CanjeLetra();
            Check.Show();
        }
        private void DocumentoPorProveedorTotalizadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentoPorProveedorTotalizadoToolStripMenuItem.Enabled = false;
            Reporte.ReporteFacturaProveedorTotalizadoCheck = new Reporte.ReporteFacturaProveedorTotalizado();
            Check.Show();
        }

        private void reporteDiarioFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            reporteDiarioFacturasToolStripMenuItem.Enabled = false;
            Reporte.ReporteDiario check = new Reporte.ReporteDiario();
            check.Show(); 
        }
        private void DocumentosPorProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentosPorProveedorToolStripMenuItem.Enabled = false;
            Reporte.ReporteFacturaProveeodr check = new Reporte.ReporteFacturaProveeodr();
            check.Show(); 
        }
        private void CuentasPorCobrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cuentasPorCobrarToolStripMenuItem.Enabled = false;
            Reporte.CuentasPorCobrar check = new Reporte.CuentasPorCobrar();
            check.Show();
        } 
        private void CuentasPorPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cuentasPorPagarToolStripMenuItem.Enabled = false;
            Reporte.CuentasPorPagar check = new Reporte.CuentasPorPagar();
            check.Show();
        }

        private void VoucherReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voucherReporteToolStripMenuItem.Enabled = false;
            Reporte.ReporteVoucher check = new Reporte.ReporteVoucher();
            check.Show();
        }
        private void ChequeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimiento.MantenimientoCheque check = new Mantenimiento.MantenimientoCheque();
            check.Show();
        }

        private void LiquidaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            liquidaciónToolStripMenuItem.Enabled = false;
            LiquidacionVoucher Check = new LiquidacionVoucher();
            Check.Show();
        }

        private void CajaChicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cajaChicaToolStripMenuItem.Enabled = false;
            ListaCajaChica Check = new ListaCajaChica();
            Check.Show();
        }

        private void RegistrarAbonoBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CtaXcobrar.AbonoBanco Check = new CtaXcobrar.AbonoBanco();
            Check.Show();
        }

        private void DocumentosPorOTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentosPorOTToolStripMenuItem.Enabled = false;
            Reporte.ReportDocumentosPorOt Check = new Reporte.ReportDocumentosPorOt();
            Check.Show();
        }

        private void PendientesPorFacturarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pendientesPorFacturarToolStripMenuItem.Enabled = false;
            Reporte.PendientePorFacturar Check = new Reporte.PendientePorFacturar();
            Check.Show();
        }

        private void EmisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            emisionToolStripMenuItem.Enabled = false;
            ListaEmisionVoucher Check = new ListaEmisionVoucher();
            Check.Show();
        }

        private void RenovaciónLetraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renovaciónLetraToolStripMenuItem.Enabled = false;
            RenovacionLetra Check = new RenovacionLetra();
            Check.Show();
        }

        private void LetraDeCambioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            letraDeCambioToolStripMenuItem.Enabled = false;
            ListaLetraCambio Check = new ListaLetraCambio();
            Check.Show();
        }

        private void DocumentosPorClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentosPorClienteToolStripMenuItem.Enabled = false;
            ReporteDocumentosPorCliente Check = new ReporteDocumentosPorCliente();
            Check.Show();
        }

        private void DocumentosPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            documentosPorFechaToolStripMenuItem.Enabled = false;
            ReporteDocumentosPorFecha Check = new ReporteDocumentosPorFecha();
            Check.Show();
        }

        private void NotaDeDébitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notaDeDébitoToolStripMenuItem.Enabled = false;
            ListaNotaDebito Check = new ListaNotaDebito();
            Check.Show();
        }

        private void NotaDeCréditoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notaDeCréditoToolStripMenuItem.Enabled = false;
            ListaNotaCredito Check = new ListaNotaCredito();
            Check.Show();
        }

        private void BoletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            boletaToolStripMenuItem.Enabled = false;
            ListaBoleta Check = new ListaBoleta();
            Check.Show();
        }

        private void FacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            facturaToolStripMenuItem.Enabled = false;
            ListaFactura Check = new ListaFactura();
            Check.Show();

        }

        public void setEnabledItems(string documento)
        {
            switch (documento)
            {
                case "F":
                    facturaToolStripMenuItem.Enabled = true;
                    break;
                case "B":
                    boletaToolStripMenuItem.Enabled = true;
                    break;
                case "C":
                    notaDeCréditoToolStripMenuItem.Enabled = true;
                    break;
                case "D":
                    notaDeDébitoToolStripMenuItem.Enabled = true;
                    break;
                case "RF":
                    documentosPorFechaToolStripMenuItem.Enabled = true;
                    break;
                case "RC":
                    documentosPorClienteToolStripMenuItem.Enabled = true;
                    break;
                case "LT":
                    letraDeCambioToolStripMenuItem.Enabled = true;
                    break;
                case "RL":
                    renovaciónLetraToolStripMenuItem.Enabled = true;
                    break;
                case "CL":
                    clientesToolStripMenuItem.Enabled = true;
                    break;
                case "EV":
                    emisionToolStripMenuItem.Enabled = true;
                    break;
                case "PF":
                    pendientesPorFacturarToolStripMenuItem.Enabled = true;
                    break;
                case "RO":
                    documentosPorOTToolStripMenuItem.Enabled = true;
                    break;
                case "LCC":
                    cajaChicaToolStripMenuItem.Enabled = true;
                    break;
                case "LV":
                    liquidaciónToolStripMenuItem.Enabled = true;
                    break;
                case "MC":
                    chequeToolStripMenuItem.Enabled = true;
                    break;
                case "VR":
                    voucherReporteToolStripMenuItem.Enabled = true;
                    break;
                case "CP":
                    cuentasPorPagarToolStripMenuItem.Enabled = true;
                    break;
                case "CC":
                    cuentasPorCobrarToolStripMenuItem.Enabled = true;
                    break;
                case "CJLT":
                    canjearLetrasToolStripMenuItem.Enabled = true;
                    break;
                case "RPD":
                    reporteDiarioFacturasToolStripMenuItem.Enabled = true;
                    break;
                case "RFPP":
                    documentosPorProveedorToolStripMenuItem.Enabled = true;
                    break;
                case "RFPPT":
                    documentoPorProveedorTotalizadoToolStripMenuItem.Enabled = true;
                    break;
            }
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clientesToolStripMenuItem.Enabled = false;
            ListaCliente Check = new ListaCliente();
            Check.Show();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {

        }

        private void facturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void letraDeCambioToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

        }

        private void canjearLetrasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
