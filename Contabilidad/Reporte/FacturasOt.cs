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

namespace Contabilidad.Reporte
{
    public partial class FacturasOt : Form
    {
        DocumentoDAO objDocumentoDAO;
        public static List<DocumentoCab> objListDocumentoCab = new List<DocumentoCab>();
        public FacturasOt(String ot)
        {
            InitializeComponent();
            this.Text = "FACTURAS";
            objDocumentoDAO = new DocumentoDAO();
            lbl_Ot.Text = lbl_Ot.Text + ot;
            objListDocumentoCab = objDocumentoDAO.listarFacturasPorOt(ot.Trim(),Ventas.UNIDADNEGOCIO);
            gridParams();
            grd_Documentos.DataSource = objListDocumentoCab;
            grd_Documentos.Refresh();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void gridParams()
        {
            grd_Documentos.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.Width = 100;
            idColumn1.DataPropertyName = "DocumentoCabSerie";//0011-0142-0200751909
            grd_Documentos.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn32 = new DataGridViewTextBoxColumn();
            idColumn32.Name = "Número";
            idColumn32.Width = 100;
            idColumn32.DataPropertyName = "DocumentoCabNro";//0011-0142-0200751909
            grd_Documentos.Columns.Add(idColumn32);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Moneda";
            idColumn2.DataPropertyName = "DocumentoCabTipoMoneda";
            idColumn2.Width = 100;
            idColumn2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Total";
            idColumn3.DataPropertyName = "DocumentoCabTotal";
            idColumn3.Width = 100;
            idColumn3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            grd_Documentos.Columns.Add(idColumn3);
           

        }
    }
}
