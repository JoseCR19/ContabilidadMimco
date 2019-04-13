using System;
using System.Collections.Generic;
using System.ComponentModel;
using ContabilidadDAO;
using ContabilidadDTO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contabilidad.Reporte
{
    public partial class ReporteLetraCliente : Form
    {
        public static ReporteLetraCliente formReporteLetrasClientes;
        public static List<DocumentoReporte> objListaDocReporte = new List<DocumentoReporte>();
        public static DocumentoCab objDocumentoCab = new DocumentoCab();
        DocumentoContabilidadDAO objDocContaDao;
        DocumentoDAO objDocumentoDao;
        ReporteFacturaC objReporte;
        DocumentoReporteExcel objReporteExcel;
        public static List<DocumentoCab> objListaDocCab = new List<DocumentoCab>();
        public static List<ReporteFacturaC> objListaVenReporte = new List<ReporteFacturaC>();
        public static List<DocumentoReporteExcel> objListaReporteExcel = new List<DocumentoReporteExcel>();
        public ReporteLetraCliente()
        {
            InitializeComponent();
            formReporteLetrasClientes = this;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(20, 20);
            objDocContaDao = new DocumentoContabilidadDAO();
            objDocumentoDao = new DocumentoDAO();
            this.Text = "REPORTE LETRAS";
            DateTime d1, d2;
            d2 = DateTime.Now;
            d1 = new DateTime(2019, 01, 1);
            dtp_desde.Value = d1;
            gridParams();
            objListaDocCab = objDocumentoDao.reporteLetraCliente(Ventas.UNIDADNEGOCIO, d1 , d2,"NN", "NN");
            dgv_reporte.DataSource = null;
            dgv_reporte.DataSource = objListaDocCab;
            dgv_reporte.Refresh();
        }
        public void gridParams()
        {
            dgv_reporte.AutoGenerateColumns = false;

            
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "RUC";
            idColumn1.DataPropertyName = "DocumentoCabClienteDocumento";
            idColumn1.Width = 100;
            dgv_reporte.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Razón Social";
            idColumn0.DataPropertyName = "DocumentoCabCliente";
            idColumn0.Width = 350;
            dgv_reporte.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Fecha";
            idColumn2.Width = 80;
            idColumn2.DataPropertyName = "DocumentoCabFechaVcto";
            dgv_reporte.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "T.Doc";
            idColumn3.DataPropertyName = "DocumentoCabTipoDoc";
            idColumn3.Width = 40;
            idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_reporte.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Serie";
            idColumn4.DataPropertyName = "DocumentoCabSerie";
            idColumn4.Width = 40;
            idColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_reporte.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "NroDoc";
            idColumn5.Width = 80;
            idColumn5.DataPropertyName = "DocumentoCabNro";
            dgv_reporte.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Total";
            idColumn7.Width = 80;
            idColumn7.DataPropertyName = "DocumentoCabTotal";
            dgv_reporte.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Moneda";
            idColumn8.DataPropertyName = "DocumentoCabMoneda";
            idColumn8.Width = 90;
            dgv_reporte.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Abono";
            idColumn9.DataPropertyName = "DocumentoCabAbono";
            idColumn9.Width = 80;
            idColumn9.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_reporte.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Saldo";
            idColumn10.DataPropertyName = "DocumentoCabSaldo";
            idColumn10.Width = 80;
            idColumn10.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_reporte.Columns.Add(idColumn10);

        }
        void formatearReporte()
        {
            for (int i = 0; i < objListaDocCab.Count; i++)
            {
                objReporte = new ReporteFacturaC();
                objReporte.Ruc = objListaDocCab[i].DocumentoCabClienteDocumento.ToString().Trim();
                objReporte.RazonSocial = objListaDocCab[i].DocumentoCabCliente.ToString().Trim();
                objReporte.FechaVencimiento = objListaDocCab[i].DocumentoCabFechaVcto.ToString().Trim().Substring(0, 10);
                objReporte.TSD = objListaDocCab[i].DocumentoCabTipoDoc.ToString().Trim() + " " + objListaDocCab[i].DocumentoCabSerie.ToString().Trim() + "-" + objListaDocCab[i].DocumentoCabNro.ToString().Trim();
                objReporte.Total = Convert.ToDouble(objListaDocCab[i].DocumentoCabTotal.ToString("G"));
                objReporte.Moneda = objListaDocCab[i].DocumentoCabMoneda.ToString();
                objReporte.TC = objListaDocCab[i].TipoCambio.ToString();
                objReporte.Abono = Convert.ToDouble(objListaDocCab[i].DocumentoCabAbono.ToString("G"));
                objReporte.Saldo = Convert.ToDouble(objListaDocCab[i].DocumentoCabSaldo.ToString("G"));
                objListaVenReporte.Add(objReporte);
            }
        }
        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            btn_Reporte.Enabled = true;
            formatearReporte();
            ReporteView Check = new ReporteView("RLVC"); // ExcelCliente
            Check.Show();
            btn_Reporte.Enabled = true;

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RLC");

        }
    }
}
