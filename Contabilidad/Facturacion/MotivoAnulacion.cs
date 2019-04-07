using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Contabilidad
{
    public partial class MotivoAnulacion : Form
    {
        DocumentoDAO objDocumentoDao;
        public ListaFactura formFac;
        public ListaBoleta formBol;
        public ListaNotaCredito formCred;
        public ListaNotaDebito formDeb;
        public static String tipoDocu = "";
        List<ContabilidadDTO.MotivoAnulacion> objLista = new List<ContabilidadDTO.MotivoAnulacion>();
        public MotivoAnulacion(String tipo)
        {
            InitializeComponent();
            objDocumentoDao = new DocumentoDAO();
            cargarCombo();
            tipoDocu = tipo;
            if (tipo =="F")
            {
                formFac = ListaFactura.formListaFactura;

            }else if (tipo == "B")
            {
                formBol = ListaBoleta.formListaBoleta;
            }
            else if (tipo == "C")
            {
                formCred = ListaNotaCredito.formListaCredito;
            }
            else if (tipo == "D")
            {
                formDeb = ListaNotaDebito.formListaDebito;
            }

        }
        void cargarCombo()
        {
            objLista = objDocumentoDao.getMotivoAnulacion();
            cmb_Anulacion.DataSource = objLista;
            cmb_Anulacion.ValueMember = "Id";
            cmb_Anulacion.DisplayMember = "Descripcion";
            cmb_Anulacion.Refresh();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            switch (tipoDocu)
            {
                case "F": formFac.setMotivoAnulacion(cmb_Anulacion.Text);
                    break;
                case "B":
                    formBol.setMotivoAnulacion(cmb_Anulacion.Text);
                    break;
                case "C":
                    formCred.setMotivoAnulacion(cmb_Anulacion.Text);
                    break;
                case "D":
                    formDeb.setMotivoAnulacion(cmb_Anulacion.Text);
                    break;
            }
            this.Close();
        }
    }
}
