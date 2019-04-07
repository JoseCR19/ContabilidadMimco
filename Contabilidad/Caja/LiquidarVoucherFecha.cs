using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Caja
{
    public partial class LiquidarVoucherFecha : Form
    {
        LiquidacionVoucher formLiquidacion;
        String NroVoucher = "";
        
        public LiquidarVoucherFecha(String voucher)
        {
            InitializeComponent();
            NroVoucher = voucher;
            formLiquidacion = LiquidacionVoucher.liquidacionVoucherForm;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {

            formLiquidacion.setLiquidacion(NroVoucher,dpickerFin.Value);
            this.Close();
        }
    }
}
