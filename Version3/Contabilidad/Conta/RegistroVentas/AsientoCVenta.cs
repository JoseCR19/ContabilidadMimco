using ContaDAO;
using ContaDTO;
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

namespace Conta.RegistroVentas
{
    public partial class AsientoCVenta : Form
    {
        public static DocumentoCab objDocumentoCab = new DocumentoCab();
        Asiento objAsiento;
        static int index;
        public static List<AsientoDetalle> objListaAsientoDetalle = new List<AsientoDetalle>();
        AsientoDAO objAsientoDao;
        AsientoDetalle objAsientoDetalle;
        public AsientoCVenta(DocumentoCab obj)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Asientos Contables";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objAsiento = new Asiento();
            objAsientoDao = new AsientoDAO();
            txt_TipoAsiento.Text = "05";
            objDocumentoCab = obj;
            //ára generar el correlativo se creo una funcion con un procedure donde recoge la fecha y el tipo de asiento para validar el  ultimo correlativo
            txt_Correlativo.Text = objAsientoDao.getCorrelativoAsientoVenta(objDocumentoCab.DocumentoCabFecha.ToString("dd/MM/yyyy"), txt_TipoAsiento.Text);

            txt_Fecha.Text = objDocumentoCab.DocumentoCabFecha.ToString("dd/MM/yyyy");
            txt_Moneda.Text = objDocumentoCab.DocumentoCabMoneda;
            txt_Haber.Text = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
            txt_Debe.Text = objDocumentoCab.DocumentoCabTotal.ToString("C").Substring(3);
            gridParams();
            objListaAsientoDetalle = objAsientoDao.getGenerarDetalle(objDocumentoCab.DocumentoCabSerie, objDocumentoCab.DocumentoCabNro);
            grd_Facturas.DataSource = objListaAsientoDetalle;

            grd_Facturas.Refresh();
            grd_Facturas.CellClick += Grd_Facturas_CellClick;
        }

        private void Grd_Facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = grd_Facturas.SelectedCells[0].RowIndex;
            objAsientoDetalle = new AsientoDetalle();
            objAsientoDetalle = objListaAsientoDetalle[index];
            txt_Cuenta.Text = objAsientoDetalle.Cuenta;
            txt_Documento.Text = objAsientoDetalle.Documento;
            txt_Importe.Text = objAsientoDetalle.Importe.ToString();
          
            txt_TipoDoc.Text = objAsientoDetalle.TipoDoc;
            if (objAsientoDetalle.TipoImporte=="D")
            {
                txt_Tipo.Text = "Debe";
            }else
            {
                txt_Tipo.Text = "Haber";
            }
           
        }

        public void gridParams()
        {
            grd_Facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Cuenta";
            idColumn0.Width = 60;
            idColumn0.DataPropertyName = "Cuenta";
            grd_Facturas.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Tipo";
            idColumn1.Width = 40;
            idColumn1.DataPropertyName = "TipoImporte";
            grd_Facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Importe";
            idColumn2.Width = 100;
            idColumn2.DataPropertyName = "Importe";
            grd_Facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Tipo Documento";
            idColumn3.Width = 120;
            idColumn3.DataPropertyName = "TipoDoc";
            grd_Facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Documento";
            idColumn4.Width = 120;
            idColumn4.DataPropertyName = "Documento";
            grd_Facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Fecha";
            idColumn5.Width = 80;
            idColumn5.DataPropertyName = "Fecha";
            grd_Facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Fecha Vcto";
            idColumn6.Width = 80;
            idColumn6.DataPropertyName = "FechaVcto";
            grd_Facturas.Columns.Add(idColumn6);
        }


        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            btn_SaveData.Enabled = false;
            bool insert, insertDet = false;
            objAsiento = new Asiento();
            objAsiento.Correlativo = txt_Correlativo.Text;
            objAsiento.Debe = objDocumentoCab.DocumentoCabTotal;
            objAsiento.Fecha = txt_Fecha.Text;
            objAsiento.Haber = objDocumentoCab.DocumentoCabTotal;
            objAsiento.MonedaCod = objDocumentoCab.DocumentoCabTipoMoneda;
            

         
            objAsiento.TipoAsiento = txt_TipoAsiento.Text;
           
            insert = objAsientoDao.insertarAsientoCab(objAsiento);
            if (insert)
            {

            }else
            {
                MessageBox.Show("Hubo un error al Guardar");
                return;
            }
            for(int i =0; i< objListaAsientoDetalle.Count; i++)
            {
                objListaAsientoDetalle[i].Correlativo = txt_Correlativo.Text;
                objListaAsientoDetalle[i].FechaDoc = objDocumentoCab.DocumentoCabFecha.ToString("dd/MM/yyyy");
                insertDet = objAsientoDao.insertarAsientoDet(objListaAsientoDetalle[i]);
                if (insertDet)
                {
                    String serie, nro;
                    serie = objListaAsientoDetalle[i].Documento.Substring(0, 4);
                    nro = objListaAsientoDetalle[i].Documento.Substring(5);
                    objAsientoDao.updateEstadoAsientoVenta(serie, nro);
                }
                else
                {
                    MessageBox.Show("Hubo un error al Guardar");
                    return;
                }
            }
            if (insertDet)
            {
                MessageBox.Show("Se creó el Asiento Contable");
            }
            btn_SaveData.Enabled = true;
            RegistrarAsientosVentas formAsient = new RegistrarAsientosVentas();
            formAsient.Show();
            this.Close();

        }
        public Double convertToDouble(String conv)
        {
            try
            {
                char systemSeparator = Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator[0];
                if (!conv.Contains(","))
                    return double.Parse(conv, CultureInfo.InvariantCulture);
                else
                    return Convert.ToDouble(conv.Replace(".", systemSeparator.ToString()).Replace(",", systemSeparator.ToString()));
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
           
            RegistrarAsientosVentas formAsient = new RegistrarAsientosVentas();
            formAsient.Show();
            this.Close();
        }

        private void txt_Correlativo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
