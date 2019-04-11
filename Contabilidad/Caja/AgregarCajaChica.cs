using Contabilidad.Facturacion;
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

namespace Contabilidad.Caja
{
    public partial class AgregarCajaChica : Form
    {
        EmisionVoucher formEmision;
        CanjeLetraNuevo formCanjeLetra;
        public static List<ContabilidadDTO.Ventas> objListVentas = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListVentasDetalle = new List<ContabilidadDTO.Ventas>();

        public static List<ContabilidadDTO.Ventas> objListBusquedaRazon = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaRuc = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaNdoc = new List<ContabilidadDTO.Ventas>();
        public static List<ContabilidadDTO.Ventas> objListBusquedaTotal = new List<ContabilidadDTO.Ventas>();

        ContabilidadDTO.Ventas ojbVentas;
        public static string TipoDocumento;

        VoucherDAO objVoucherDao;
        String nrot = "";
        public AgregarCajaChica(String ruc,String Tipo/*,String moneda,String monedadoc*/)
        {
            InitializeComponent();
            TipoDocumento = Tipo;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            gridParams();
            
            gridParamsDetalle();
            objVoucherDao = new VoucherDAO();
            formEmision = EmisionVoucher.formEmision;
            formCanjeLetra = CanjeLetraNuevo.canjeletranuevo;
            if (Tipo== "CARGO")
            {
                this.Text = "CARGO";
                objListVentas = objVoucherDao.listarDocumentosVentas(ruc, Ventas.UNIDADNEGOCIO/*,moneda,monedadoc*/);
            }
            else
            {
                this.Text = "Facturas Compras";
                objListVentas = objVoucherDao.listarDocumentosVentasForLeter(ruc, Ventas.UNIDADNEGOCIO);
            }
            grdDocumento.DataSource = objListVentas;
            objListBusquedaTotal = objListVentas;
            txt_BuscarDocumento.TextChanged += Txt_BuscarDocumento_TextChanged;
            grdDocumento.Refresh();
        }

        private void Txt_BuscarDocumento_TextChanged(object sender, EventArgs e)
        {
            String busqueda = txt_BuscarDocumento.Text.ToUpper();
            objListBusquedaRuc= objListVentas.Where(x => x.Ruc.Contains(busqueda)).ToList();
            objListBusquedaRazon = objListVentas.Where(x => x.RazonSocial.Contains(busqueda)).ToList();
            objListBusquedaNdoc = objListVentas.Where(x => x.Numero.Contains(busqueda)).ToList();
            objListBusquedaTotal = objListBusquedaRuc.Union(objListBusquedaRazon).Union(objListBusquedaNdoc).ToList();
            grdDocumento.DataSource = null;
            grdDocumento.DataSource = objListBusquedaTotal;
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
            idColumn0.Name = "Serie";
            idColumn0.DataPropertyName = "Serie";
            idColumn0.Width = 60;
            grdDocumento.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Número";
            idColumn1.DataPropertyName = "Numero";
            idColumn1.Width = 70;
            grdDocumento.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Fecha";
            idColumn4.DataPropertyName = "FechaEmision";
            idColumn4.Width = 80;
            grdDocumento.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Ruc";
            idColumn5.DataPropertyName = "Ruc";
            idColumn5.Width = 80;
            grdDocumento.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Razon Social";
            idColumn2.DataPropertyName = "RazonSocial";
            idColumn2.Width = 240;
            grdDocumento.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Total";
            idColumn3.DefaultCellStyle.Format = "0.00";
            idColumn3.Width = 80;
            grdDocumento.Columns.Add(idColumn3);

            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Moneda";
            idColumn6.DataPropertyName = "Moneda";
            idColumn6.Width = 60;
            grdDocumento.Columns.Add(idColumn6);

            DataGridViewTextBoxColumn idColumn12 = new DataGridViewTextBoxColumn();
            idColumn12.Name = "Tipo Cambio";
            idColumn12.DataPropertyName = "TipoCambio";
            idColumn12.Width = 60;
            grdDocumento.Columns.Add(idColumn12);

            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Retención";
            idColumn7.DataPropertyName = "xret";
            idColumn7.Width = 60;
            grdDocumento.Columns.Add(idColumn7);

            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Percección";
            idColumn8.DataPropertyName = "xper";
            idColumn8.Width = 60;
            grdDocumento.Columns.Add(idColumn8);

            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Buen ";
            idColumn9.DataPropertyName = "xbue";
            idColumn9.Width = 60;
            grdDocumento.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "Detracción";
            idColumn10.DataPropertyName = "xdetra";
            idColumn10.Width = 60;
            grdDocumento.Columns.Add(idColumn10);

            DataGridViewTextBoxColumn idColumnPago = new DataGridViewTextBoxColumn();
            idColumnPago.Name = "Pago";
            idColumnPago.DataPropertyName = "Pago";
            idColumnPago.DefaultCellStyle.Format = "0.00";
            idColumnPago.Width = 80;
            grdDocumento.Columns.Add(idColumnPago);
            DataGridViewTextBoxColumn idColumn11 = new DataGridViewTextBoxColumn();
            idColumn11.Name = "Ot";
            idColumn11.DataPropertyName = "CodOt";
            idColumn11.Width = 60;
            grdDocumento.Columns.Add(idColumn11);
            DataGridViewTextBoxColumn idColumn13 = new DataGridViewTextBoxColumn();
            idColumn13.Name = "Dirección";
            idColumn13.DataPropertyName = "DirOt";
            idColumn13.Width = 60;
            grdDocumento.Columns.Add(idColumn13);

            DataGridViewTextBoxColumn idColumn14 = new DataGridViewTextBoxColumn();
            idColumn14.Name = "Documento";
            idColumn14.DataPropertyName = "TipoDocumento";
            idColumn14.Width = 60;
            grdDocumento.Columns.Add(idColumn14);

            DataGridViewTextBoxColumn idColumn15 = new DataGridViewTextBoxColumn();
            idColumn15.Name = "Ventas Id";
            idColumn15.DataPropertyName = "VentasId";
            idColumn15.Width = 60;
            grdDocumento.Columns.Add(idColumn15);

            DataGridViewTextBoxColumn idColumn16 = new DataGridViewTextBoxColumn();
            idColumn16.Name = "NroOt";
            idColumn16.DataPropertyName = "NroOt";
            idColumn16.Width = 60;
            grdDocumento.Columns.Add(idColumn16);

            DataGridViewTextBoxColumn idColumn17 = new DataGridViewTextBoxColumn();
            idColumn17.Name = "OtReal";
            idColumn17.DataPropertyName = "CodOtReal";
            idColumn17.Width = 60;
            grdDocumento.Columns.Add(idColumn17);

            DataGridViewTextBoxColumn idColumn18 = new DataGridViewTextBoxColumn();
            idColumn18.Name = "NroOtReal";
            idColumn18.DataPropertyName = "NroOtReal";
            idColumn18.Width = 60;
            grdDocumento.Columns.Add(idColumn18);

            DataGridViewTextBoxColumn idColumn19 = new DataGridViewTextBoxColumn();
            idColumn19.Name = "DireccionReal";
            idColumn19.DataPropertyName = "DirOtReal";
            idColumn19.Width = 60;
            grdDocumento.Columns.Add(idColumn19);

            DataGridViewTextBoxColumn idColumn20 = new DataGridViewTextBoxColumn();
            idColumn20.Name = "Abono";
            idColumn20.DataPropertyName = "AbonoLetra";
            idColumn20.Width = 60;
            idColumn20.DefaultCellStyle.Format = "0.00";
            grdDocumento.Columns.Add(idColumn20);



            grdDocumento.Columns[0].ReadOnly = false;
            grdDocumento.Columns[1].ReadOnly = true;
            grdDocumento.Columns[2].ReadOnly = true;
            grdDocumento.Columns[3].ReadOnly = true;
            grdDocumento.Columns[4].ReadOnly = true;
            grdDocumento.Columns[5].ReadOnly = true;
            grdDocumento.Columns[6].ReadOnly = true;
            grdDocumento.Columns[11].ReadOnly = true;
            grdDocumento.Columns[9].Visible = false;
            grdDocumento.Columns[10].Visible = false;
            grdDocumento.Columns[11].Visible = false;
            grdDocumento.Columns[12].Visible = false;
            grdDocumento.Columns[13].Visible = true;
            grdDocumento.Columns[14].Visible = false;
            grdDocumento.Columns[15].Visible = false;
            grdDocumento.Columns[16].Visible = false;
            grdDocumento.Columns[17].Visible = false;
            grdDocumento.Columns[18].Visible = false;
            grdDocumento.Columns[19].Visible = false;
        }

        public void gridParamsDetalle()
        {

            grv_detalle.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Ot";
            idColumn1.DataPropertyName = "CodOt";
            idColumn1.Width = 60;
            grv_detalle.Columns.Add(idColumn1);

            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Dirección";
            idColumn2.DataPropertyName = "DirOt";
            idColumn2.Width = 60;
            grv_detalle.Columns.Add(idColumn2);

            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Ventas Id";
            idColumn4.DataPropertyName = "VentasId";
            idColumn4.Width = 60;
            grv_detalle.Columns.Add(idColumn4);

            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "NroOt";
            idColumn3.DataPropertyName = "NroOt";
            idColumn3.Width = 60;
            grv_detalle.Columns.Add(idColumn3);

            grv_detalle.Columns[0].ReadOnly = true;
            grv_detalle.Columns[1].ReadOnly = true;
            grv_detalle.Columns[2].ReadOnly = true;
            grv_detalle.Columns[3].ReadOnly = true;
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            objListBusquedaTotal = objListBusquedaTotal.Where(x => x.chkSelc == true).ToList();
             if (TipoDocumento == "CARGO")
             {
                formEmision.setDatosCajaChica(objListBusquedaTotal);
            }
            else
            {

                formCanjeLetra.setDatosCajaChica(objListBusquedaTotal);
            }
            
            this.Close();
        }

        private void grdDocumento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool hola;
            int countdet = 0;
            bool det = false;
            
            decimal cambio;
            decimal totalsoles;
            if(TipoDocumento== "LETRA")
            {
                foreach(DataGridViewRow row in grdDocumento.Rows)
                {
                    hola = Convert.ToBoolean(row.Cells[0].Value);
                    if(hola)
                    {
                        row.Cells[13].Value = row.Cells[6].Value;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in grdDocumento.Rows)
                {
                    hola = Convert.ToBoolean(row.Cells[0].Value);
                    if (row.Cells[7].Value.ToString() == "USD")
                    {
                        if (hola)
                        {
                            cambio = Convert.ToDecimal(row.Cells[8].Value.ToString());
                            totalsoles = Convert.ToDecimal(row.Cells[6].Value.ToString());
                            row.Cells[13].Value = Math.Round(totalsoles * cambio, 2);
                            objListVentasDetalle = objVoucherDao.listarDocumentosVentasDetalle(row.Cells[17].Value.ToString());
                            grv_detalle.DataSource = objListVentasDetalle;

                            if (Convert.ToString(row.Cells["Ot"].Value) == "Ot Vacio")
                            {

                            }
                            else
                            {
                                if (objListVentasDetalle.Count > 1)
                                {
                                    foreach (DataGridViewRow row2 in grv_detalle.Rows)
                                    {
                                        if (Convert.ToString(row2.Cells["NroOt"].Value) == Convert.ToString(row.Cells["Ot"].Value))
                                        {
                                            countdet++;
                                        }
                                    }
                                }
                            }
                            if (countdet == objListVentasDetalle.Count)
                            {
                                row.Cells["Ot"].Value = row.Cells["Ot"].Value;
                            }
                            else
                            {
                                row.Cells["Ot"].Value = "Ot - Varios";
                                row.Cells["NroOt"].Value = "Ot - Varios";
                                row.Cells["Dirección"].Value = "Ot - Varios";
                            }


                            //grv_detalle.Refresh();
                        }
                        else
                        {
                            //grv_detalle.DataSource = null;
                            grv_detalle.Refresh();
                            row.Cells[13].Value = "0.00";
                        }
                    }
                    else
                    {
                        if (hola)
                        {
                            row.Cells[13].Value = row.Cells[6].Value;
                            objListVentasDetalle = objVoucherDao.listarDocumentosVentasDetalle(row.Cells[15].Value.ToString());
                            grv_detalle.DataSource = objListVentasDetalle;
                            grv_detalle.Refresh();
                            if (Convert.ToString(row.Cells["Ot"].Value) == "Ot Vacio")
                            {

                            }
                            else
                            {
                                if (objListVentasDetalle.Count > 1)
                                {
                                    foreach (DataGridViewRow row2 in grv_detalle.Rows)
                                    {
                                        if (Convert.ToString(row2.Cells["NroOt"].Value) == Convert.ToString(row.Cells["Ot"].Value))
                                        {
                                            countdet++;
                                        }
                                    }
                                }
                            }
                            if (countdet == objListVentasDetalle.Count)
                            {
                                row.Cells["Ot"].Value = row.Cells["Ot"].Value;
                            }
                            else
                            {
                                row.Cells["Ot"].Value = "Ot - Varios";
                                row.Cells["NroOt"].Value = "Ot - Varios";
                                row.Cells["Dirección"].Value = "Ot - Varios";
                            }
                        }
                        else
                        {

                            row.Cells[13].Value = "0.00";
                        }
                    }
                }
            }
            


        }

        private void grdDocumento_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdDocumento.IsCurrentCellDirty)
            {
                grdDocumento.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void grdDocumento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void grdDocumento_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void grdDocumento_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}

