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
namespace Contabilidad.Caja
{
    public partial class AgregarPrestamoBancario : Form
    {
        EmisionVoucher formEmision;

        public static List<PrestamoBancario> objListPrestamoBancario = new List<PrestamoBancario>();

        VoucherDAO objVoucherDao;
        public AgregarPrestamoBancario(String CodBanco, String Moneda)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            objListPrestamoBancario = objVoucherDao.getPrestamoBancarioVoucher(CodBanco, Moneda);
            grdDocumento.DataSource = objListPrestamoBancario;
            grdDocumento.Refresh();
        }

        public void gridParams()
        {

            grdDocumento.AutoGenerateColumns = false;
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.HeaderText = "Selec";
            chkColumn.Width = 50;
            chkColumn.DataPropertyName = "chkSelc";
            grdDocumento.Columns.Add(chkColumn);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();

            idColumn0.Name = "Código";
            idColumn0.DataPropertyName = "CodigoPrestamo";
            idColumn0.Width = 70;
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Banco";
            idColumn1.DataPropertyName = "Banco";
            idColumn1.Width = 260;
            grdDocumento.Columns.Add(idColumn1);

            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "F. Vcto";
            idColumn5.DataPropertyName = "FechaVcto";
            idColumn5.Width = 100;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Moneda";
            idColumn2.DataPropertyName = "Moneda";
            idColumn2.Width = 70;
            grdDocumento.Columns.Add(idColumn2);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Monto";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.Width = 100;
            grdDocumento.Columns.Add(idColumn4);



            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListPrestamoBancario = objListPrestamoBancario.Where(x => x.chkSelc == true).ToList();
            formEmision.setDatosPrestamoBancario(objListPrestamoBancario);
            this.Close();
        }
    }
}
