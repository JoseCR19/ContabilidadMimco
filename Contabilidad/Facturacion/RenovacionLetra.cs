using Contabilidad.Busqueda;
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

namespace Contabilidad
{
    public partial class RenovacionLetra : Form
    {
        public static DocumentoCab objDocumentoCab = new DocumentoCab();
        static LetraDet objLetraDet = new LetraDet();
        static int index;
        public static String Operacion = "Q";
        public static RenovacionLetra renovForm;
        public static List<LetraDet> objListaLetraDet = new List<LetraDet>();
        DocumentoDAO objDocumentoDao;
        public RenovacionLetra()
        {
            InitializeComponent();
            renovForm = this;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 50);
            this.ControlBox = false;
            objDocumentoDao = new DocumentoDAO();
            gridParams();
            grdDocumento.CellClick += GrdDocumento_CellClick;
        }

        private void GrdDocumento_CellClick(object sender, EventArgs e)
        {
            if (objListaLetraDet.Count != 0)
            {
                objLetraDet = new LetraDet();
                index = grdDocumento.SelectedCells[0].RowIndex;
                objLetraDet = objListaLetraDet[index];
                txt_TotalFactura.Text = objLetraDet.LetraDetAbonoSuma.ToString();
                txt_SerieDcto.Text = objLetraDet.LetraDetSerieRef;
                txt_NumeroDcto.Text = objLetraDet.LetraDetNroRef;
                if (objLetraDet.LetraDetCodMoneda == "USD")
                {
                    txt_Moneda.Text = "$";
                }else
                {
                    txt_Moneda.Text = "S/";
                }
                
            }
        }

        public void gridParams()
        {
            grdDocumento.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Width = 100;
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "LetraDetSerieRef";
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "LetraDetNroRef";
            idColumn1.Width = 140;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Fecha Documento";
            idColumn2.DataPropertyName = "LetraDetFechaEmisionRef";
            idColumn2.Width = 170;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha Vencimiento";
            idColumn3.DataPropertyName = "LetraDetFechaVctoRef";
            idColumn3.Width = 170;
            grdDocumento.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Total";
            idColumn4.DataPropertyName = "LetraDetTotal";
            idColumn4.Width = 130;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Monto Canjeado";
            idColumn5.DataPropertyName = "LetraDetAbonoSuma";
            idColumn5.Width = 130;
            grdDocumento.Columns.Add(idColumn5);

        }
        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ventas.formVentas.setEnabledItems("RL");
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            using (var buscarLetraForm = new BuscarLetra())
            {
                buscarLetraForm.ShowDialog();
            }
            btn_Buscar.Enabled = true;
        }

        public void setDatos(DocumentoCab objCab)
        {
            objDocumentoCab = objCab;
            txt_Cliente.Text = objDocumentoCab.DocumentoCabCliente;
            txt_Direccion.Text = objDocumentoCab.DocumentoCabClienteDireccion;
            txt_Ruc.Text = objDocumentoCab.DocumentoCabClienteDocumento;
            txt_Telefono.Text = objDocumentoCab.DocumentoCabClienteTelefono;
           // dpick_Fecha.Value = objDocumentoCab.DocumentoCabFecha;
            dpck_Fechavcto.Value = objDocumentoCab.DocumentoCabFechaVcto;
            txt_Aval.Text = objDocumentoCab.DocumentoCabClienteAval;
            txt_DireccionAval.Text = objDocumentoCab.DocumentoCabClienteDireccionAval;
            txt_RucAval.Text = objDocumentoCab.DocumentoCabClienteRucAval;
            txt_TelefAval.Text = objDocumentoCab.DocumentoCabClienteTelefonoAval;
            txt_Serie.Text = objDocumentoCab.DocumentoCabSerie;
            txt_Numero.Text = objDocumentoCab.DocumentoCabNro;
            txt_AvalCod.Text = objDocumentoCab.DocumentoCabClienteCodAval;
            txt_codcliente.Text = objDocumentoCab.DocumentoCabClienteCod;
            objListaLetraDet = objDocumentoDao.listarLetraDetRenovacion(txt_Serie.Text, txt_Numero.Text);
            grdDocumento.DataSource = objListaLetraDet;
            grdDocumento.Refresh();
            llenarSumatorias();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            bool binsertar1,binsertar2 = true;
            btn_SaveData.Enabled = false;
            objDocumentoCab.DocumentoCabNroRef = objDocumentoCab.DocumentoCabNro;
            objDocumentoCab.DocumentoCabSerieRef = objDocumentoCab.DocumentoCabSerie;
            objDocumentoCab.DocumentoCabSaldo = objDocumentoCab.DocumentoCabAbono;
            objDocumentoCab.DocumentoCabAbono = 0;
            objDocumentoCab.DocumentoCabTipoDoc = "LT";
            objDocumentoCab.DocumentoCabUsuAdd = Ventas.UsuarioSession;
            objDocumentoCab.DocumentoCabFechaVcto = dpck_Fechavcto.Value;
            String aux = objDocumentoCab.DocumentoCabNro.Substring(0, 4);

            aux += "R3-18";
            objDocumentoCab.DocumentoCabNro = aux;
            for (int i = 0;i<objListaLetraDet.Count; i++)
            {
                objListaLetraDet[i].LetraDetNro = objDocumentoCab.DocumentoCabNro;
                objListaLetraDet[i].LetraDetSerie = objDocumentoCab.DocumentoCabSerie;
            }
            


            binsertar1 = objDocumentoDao.insertarRenovacionCab(objDocumentoCab, Ventas.UNIDADNEGOCIO);
            string msg = "";
            if (binsertar1)
            {



            }
            else
            {
                msg = "Hubo un problema al guardar";
                MessageBox.Show(msg);
                btn_SaveData.Enabled = true;

                return;
            }
            for (int i = 0; i < objListaLetraDet.Count; i++)
            {
                binsertar2 = objDocumentoDao.insertLetraDet(objListaLetraDet[i]);
                if (binsertar2 == false)
                {
                    MessageBox.Show("Error al guardar");
                    btn_SaveData.Enabled = true;
                    break;
                }
            }
            if (binsertar2)
            {
                MessageBox.Show("Renovación Guardada exitosamente");
                nuevoRegistro();
                btn_SaveData.Enabled = true;
            }
        }


        void nuevoRegistro()
        {
            txt_DireccionAval.Text = "";
            txt_Aval.Text = "";
            txt_AvalCod.Text = "";
            txt_Cliente.Text = "";
            txt_codcliente.Text = "";
          
            txt_Direccion.Text = "";
        

            txt_Numero.Text = objDocumentoDao.correlativoLetra(Ventas.UNIDADNEGOCIO);
            txt_NumeroDcto.Text = "";
 
            txt_Ruc.Text = "";
            txt_RucAval.Text = "";
            if (Ventas.UNIDADNEGOCIO == "01")
            {
                txt_Serie.Text = "M/";
            }
            else
            {
                txt_Serie.Text = "G/";
            }
            txt_SerieDcto.Text = "";
       
            txt_Telefono.Text = "";
            txt_Total.Text = "";

            txt_TotalFactura.Text = "";
            dpck_Fechavcto.Value = DateTime.Now;
            dpick_Fecha.Value = DateTime.Now;
        }
        public void llenarSumatorias()
        {
            txt_Total.Text = objListaLetraDet.Sum(x => x.LetraDetAbonoSuma).ToString();
            txt_TotalLetra.Text = objListaLetraDet.Sum(x => x.LetraDetTotal).ToString();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Operacion = "S";
            
          
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Operacion = "M";
            txt_SerieDcto.Enabled = true;
            txt_NumeroDcto.Enabled = true;
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {

        }
    }
}
