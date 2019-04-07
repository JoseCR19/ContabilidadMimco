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

namespace Contabilidad.Caja
{
    public partial class LiquidacionVoucher : Form
    {
        public List<Voucher> objListVoucher = new List<Voucher>();
        public static LiquidacionVoucher liquidacionVoucherForm;

        public static Voucher objVoucher = new Voucher();

        VoucherDAO objVoucherDao;

        public static String operacionVoucher = "Q";
        int index = 0;
        public LiquidacionVoucher()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "LISTA VOUCHER";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            liquidacionVoucherForm = this;
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(d2.Year, d2.Month, 1);
            dpickerInicio.Value = d1;
            gridParams();
            //objVoucher = new Voucher();
            objVoucherDao = new VoucherDAO();
          
            objListVoucher = objVoucherDao.listarVoucher(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value,"P");
            grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();
            grd_Voucher.CellClick += Grd_Voucher_CellClick;
        }

        private void Grd_Voucher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            objVoucher = new Voucher();
            operacionVoucher = "L";
            index = grd_Voucher.SelectedCells[0].RowIndex;
            objVoucher = objListVoucher[index];
            if (objVoucher.TipVou=="C")
            {
                btn_Liquidar.Enabled = false;
            }else
            {
                btn_Liquidar.Enabled = true;
            }
        }

        public void gridParams()
        {
            grd_Voucher.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "N° Voucher";
            idColumn1.DataPropertyName = "NumeroVoucher";
            idColumn1.Width = 90;
            grd_Voucher.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "N° Cheque";
            idColumn2.DataPropertyName = "NumeroCheque";
            idColumn2.Width = 90;
            grd_Voucher.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha Pago";
            idColumn3.DataPropertyName = "FechaPago";
            idColumn3.Width = 100;
            grd_Voucher.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.Width = 60;
            //idColumn4.HeaderCell.
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Voucher.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Moneda";
            idColumn5.DataPropertyName = "Moneda";
            idColumn5.Width = 70;
            grd_Voucher.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Banco";
            idColumn6.DataPropertyName = "Banco";
            idColumn6.Width = 190;
            grd_Voucher.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Estado";
            idColumn7.DataPropertyName = "EstadoS";
            idColumn7.Width = 90;
            grd_Voucher.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Fecha Liquidación";
            idColumn8.DataPropertyName = "FechaEntrega";
            idColumn8.Width = 100;
            grd_Voucher.Columns.Add(idColumn8);
            foreach (DataGridViewColumn col in grd_Voucher.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

        }
        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("LV");
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            objListVoucher = objVoucherDao.listarVoucher(Ventas.UNIDADNEGOCIO, dpickerInicio.Value, dpickerFin.Value, "P");
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();
        }

        private void btn_Liquidar_Click(object sender, EventArgs e)
        {
            objVoucher = new Voucher();
            operacionVoucher = "L";
            index = grd_Voucher.SelectedCells[0].RowIndex;
            objVoucher = objListVoucher[index];
            using (var check = new LiquidarVoucherFecha(objVoucher.NumeroVoucher))
            {
                check.ShowDialog();
            }
            

        }
        public void setLiquidacion(String nrovoucher, DateTime d1)
        {
            objVoucher.FechaEntrega =Convert.ToDateTime( d1.ToShortDateString());
            objVoucher.EstadoS = "LIQUIDADO";
            objVoucher.TipVou = "C";
            bool insertar;
            insertar = objVoucherDao.liquidarVoucher(nrovoucher,Ventas.UNIDADNEGOCIO, objVoucher.FechaEntrega,Ventas.UsuarioSession);
            if (!insertar)
            {
                MessageBox.Show("Error al liquidar el voucher");
                return;
            }else
            {
                MessageBox.Show("El voucher ha sido Liquidado");
            }
            objListVoucher[index] = objVoucher;
            
            grd_Voucher.DataSource = null;
            grd_Voucher.DataSource = objListVoucher;
            grd_Voucher.Refresh();
        }
    }
}
