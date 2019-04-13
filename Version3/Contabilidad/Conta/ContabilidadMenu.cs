using Conta.LibrosContables;
using Conta.RegistroPagos;
using ContaDAO;
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
    public partial class ContabilidadMenu : Form
    {

        public static ContabilidadMenu formContabilidad;
        public static String UsuarioSession;
        MonedaDAO objMonedaDao;
        public ContabilidadMenu(String Usuario)
        {
            InitializeComponent();
          
            UsuarioSession = Usuario;
            this.Text = "CONTABILIDAD";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 50);
            formContabilidad = this;
            objMonedaDao = new MonedaDAO();
            objMonedaDao.tipoCambio();
            libroVentasToolStripMenuItem.Click += LibroVentasToolStripMenuItem_Click;
            generarAsientosVentasToolStripMenuItem.Click += GenerarAsientosVentasToolStripMenuItem_Click;
            generarAsientosGeneralesToolStripMenuItem.Click += GenerarAsientosGeneralesToolStripMenuItem_Click;
            mantenimientoDePlanContableToolStripMenuItem.Click += MantenimientoDePlanContableToolStripMenuItem_Click;
            generarAsientosComprasToolStripMenuItem.Click += GenerarAsientosComprasToolStripMenuItem_Click;
            libroComprasToolStripMenuItem.Click += LibroComprasToolStripMenuItem_Click;
            libroDiarioToolStripMenuItem.Click += LibroDiarioToolStripMenuItem_Click;
            libroMayorToolStripMenuItem1.Click += LibroMayorToolStripMenuItem1_Click;
            libroMayorConCajaYBancoToolStripMenuItem.Click += LibroMayorConCajaYBancoToolStripMenuItem_Click;
            cajaChicaToolStripMenuItem.Click += CajaChicaToolStripMenuItem_Click;
            voucherToolStripMenuItem.Click += VoucherToolStripMenuItem_Click;
        }

        private void VoucherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            voucherToolStripMenuItem.Enabled = false;
            RegistrarVoucher check = new RegistrarVoucher();
            
            check.Show();
        }

        private void CajaChicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cajaChicaToolStripMenuItem.Enabled = false;
            RegistrarCajaChica check = new RegistrarCajaChica();
            check.Show();
        }

        private void LibroMayorConCajaYBancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            libroMayorConCajaYBancoToolStripMenuItem.Enabled = false;
            LibroMayorCajaBanco check = new LibroMayorCajaBanco();
            check.Show();
        }

        private void LibroMayorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            libroMayorToolStripMenuItem1.Enabled = false;
            LibroMayor check = new LibroMayor();
            check.Show();
        }

        private void LibroDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            libroDiarioToolStripMenuItem.Enabled = false;
            LibroDiario check = new LibroDiario();
            check.Show();
        }

        private void LibroComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            libroComprasToolStripMenuItem.Enabled = false;
            RegistroCompras.LibroCompras check = new RegistroCompras.LibroCompras();
            check.Show();
        }

        private void GenerarAsientosComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarAsientosComprasToolStripMenuItem.Enabled = false;
            RegistroCompras.RegistrarAsientosCompras check = new RegistroCompras.RegistrarAsientosCompras();
            check.Show();
        }

        private void MantenimientoDePlanContableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mantenimientoDePlanContableToolStripMenuItem.Enabled = false;
            PlanDeCuenta.MantenimientoPlanContable Check = new PlanDeCuenta.MantenimientoPlanContable();
            Check.Show();
        }

        private void GenerarAsientosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarAsientosGeneralesToolStripMenuItem.Enabled = false;
            RegistroAsientoGeneral.RegistrarAsientoGeneral Check = new RegistroAsientoGeneral.RegistrarAsientoGeneral();
            Check.Show();
        }

        private void GenerarAsientosVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            generarAsientosVentasToolStripMenuItem.Enabled = false;
            RegistroVentas.RegistrarAsientosVentas Check = new RegistroVentas.RegistrarAsientosVentas();
            Check.Show();
        }

        private void LibroVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            libroVentasToolStripMenuItem.Enabled = false;
            RegistroVentas.LibroVentas Check = new RegistroVentas.LibroVentas();
            Check.Show();
        }
        public void setEnabledItems(string documento)
        {
            switch (documento)
            {
                case "LV":
                    libroVentasToolStripMenuItem.Enabled = true;
                    break;
                case "AV":
                    generarAsientosVentasToolStripMenuItem.Enabled = true;
                    break;
                case "AG":
                    generarAsientosGeneralesToolStripMenuItem.Enabled = true;
                    break;
                case "MP": //Mantenimiento plan contable
                    mantenimientoDePlanContableToolStripMenuItem.Enabled = true;
                    break;
                case "AC":
                    generarAsientosComprasToolStripMenuItem.Enabled = true;
                    break;
                case "LC":
                    libroComprasToolStripMenuItem.Enabled = true;
                    break;
                case "LD":
                    libroDiarioToolStripMenuItem.Enabled = true;
                    break;
                case "LM":
                    libroMayorToolStripMenuItem1.Enabled = true;
                    break;
                case "LMCB":
                    libroMayorConCajaYBancoToolStripMenuItem.Enabled = true;
                    break;
                case "CC": // caja chica
                    cajaChicaToolStripMenuItem.Enabled = true;
                    break;
                case "VO": // voucher
                    voucherToolStripMenuItem.Enabled = true;
                    break;
            }
        }
    }
}
