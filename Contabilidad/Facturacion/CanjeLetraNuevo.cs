using System;
using Contabilidad.Busqueda;
using Contabilidad.Report;
using ContabilidadDAO;
using ContabilidadDTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Contabilidad.Caja;

namespace Contabilidad.Facturacion
{
    public partial class CanjeLetraNuevo : Form
    {
        public static CanjeLetraNuevo canjeletranuevo;
        public static String RegCompra;
        MonedaDAO objMonedaDao;
        public static String RUC;
        public static String Modificar = "Q";
        String OperacionGuardar = "Q";
        String Operacion = "Q";
        String change = "Q";
        public static List<Moneda> objListMoneda = new List<Moneda>();
        public List<LetraCab> objListLetra = new List<LetraCab>();
        List<LetraDetalle> objListaLetraDet = new List<LetraDetalle>();
        public static LetraCab objVoucher = new LetraCab();
        public static LetraDetalle objLetraDetalle = new LetraDetalle();
        public static List<LetraReportRC> objListaLetraReporte = new List<LetraReportRC>();
        LetraDetalle objLetrarDet;
        LetraCab objLetra;
        VoucherDAO objVoucherDao;
        DocumentoDAO objDocumentoDAO;
        int index = 0;
        public CanjeLetraNuevo()
        {
            InitializeComponent();
            this.ControlBox = false;
            txt_tipodoc.Text = "LT";
            objLetra = new LetraCab();
            objMonedaDao = new MonedaDAO();
            objVoucherDao = new VoucherDAO();
            objDocumentoDAO = new DocumentoDAO();
            objMonedaDao.tipoCambio();
            comboMoneda();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            canjeletranuevo = this;
            txt_Tcambio.Text = objMonedaDao.getTipoCambioVenta(dpick_Fecha.Value.ToString("dd/MM/yyyy")).ToString().PadRight(5, '0');
            if(CanjeLetra.operacionLetra == "V")
            {
                objLetra = CanjeLetra.objVoucher;
                llenarCabecera(objLetra);
                objListaLetraDet = objVoucherDao.listarLetraDet(objLetra.NroRegistro, Ventas.UNIDADNEGOCIO);
                llenarDetalle(objListaLetraDet);
                sumatoria();
                btn_SaveData.Enabled = false;
                btn_Modificar.Visible = true;
            }
            else if (CanjeLetra.operacionLetra == "A")
            {
                objLetra = CanjeLetra.objVoucher;
                llenarCabecera(objLetra);
                objListaLetraDet = objVoucherDao.listarLetraDet(objLetra.NroRegistro, Ventas.UNIDADNEGOCIO);
                llenarDetalle(objListaLetraDet);
                sumatoria();
                btn_Add.Enabled = false;
                btn_Anular.Enabled = false;
                btn_Buscar.Enabled = false;
                btn_Modificar.Enabled = false;
                btn_SaveData.Enabled = false;
                grd_facturas.Enabled = false;
                dpck_Fechavcto.Enabled = false;
                dpick_Fecha.Enabled = false;
                dtp_compromiso.Enabled = false;
                cmb_Moneda.Enabled = false;
                btn_Modificar.Visible = false;
            }
            else if (CanjeLetra.operacionLetra == "N")
            {
                Modificar = "N";
                if(Ventas.UNIDADNEGOCIO=="01")
                {
                    txt_SerieDcto.Text = "0001";
                }
                else
                {
                    txt_SerieDcto.Text = "0001";
                }
                habilitarBotones(true, false);
            }
        }

        private void btn_Buscar_Click(object sender, EventArgs e)
        {
            btn_Buscar.Enabled = false;
            using (var buscarProveedorForm = new BusquedaProveedor("CL"))
            {
                buscarProveedorForm.ShowDialog();
            }
            btn_Buscar.Enabled = true;
        }
        public void setDatos(Proveedor objCli)
        {
            //objDocumentoCab = objCli;
            txt_codcliente.Text = objCli.ProveedorCod;
            txt_Ruc.Text = objCli.ProveedorNDoc;
            txt_Direccion.Text = objCli.ProveedorDireccion;
            txt_Cliente.Text = objCli.ProveedorRazonSocial;

        }
        void llenarCabecera(LetraCab objV)
        {
            txt_Cliente.Text = objV.NomProv;
            txt_Direccion.Text = objV.direccion;
            txt_Ruc.Text = objV.Ruc;
            cmb_Moneda.SelectedValue = objV.Moneda;
            txt_SerieDcto.Text = objV.SerieDoc;
            txt_NumeroDcto.Text = objV.NroDoc;
            dpick_Fecha.Value = objV.FecRep;
            txt_NumeroDcto.Enabled = false;
            txt_nroregletra.Text = objV.NroRegistro.Trim();
            //txt_NroVoucher.Text = objV.NumeroVoucher;
            //txt_BancoCod.Text = objV.BancoCod;
            //txt_Banco.Text = objV.Banco;
            //txt_NroCheque.Text = objV.NumeroCheque;
            //txt_NroCuenta.Text = objV.NumeroCuenta;
            //txt_Solicitante.Text = objV.Solicitante;
            //txt_SolicitanteCod.Text = objV.SolicitaCod;
            //txt_Observacion.Text = objV.Observacion;
            //dpick_FechaEmision.Value = objV.FechaEmision;
            //dpick_FechaPago.Value = objV.FechaPago;
            //xperiodo = dpick_FechaPago.Value.Month.ToString();
            //cmb_periodo.SelectedValue = xperiodo;
            //xejercicio = dpick_FechaPago.Value.Year.ToString();
            //cmb_ejercicio2.SelectedValue = xejercicio;
            //txt_MontoTotal.Text = objV.Monto.ToString("G");
            //double d = Convert.ToDouble(txt_MontoTotal.Text);
            //txt_MontoTotal.Text = d.ToString(".00");
            //cmb_Moneda.SelectedValue = objV.MonedaCod;
            //if (rb_Metales.Checked)
            //{
            //    Ventas.UNIDADNEGOCIO = "01";
            //}
            //else
            //{
            //    Ventas.UNIDADNEGOCIO = "02";
            //}

        }
        public void comboMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            OperacionGuardar = "M";
            habilitarBotones(true, false);
            btn_SaveData.Enabled = true;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            btn_Add.Enabled = true;
            
            string ruc = "NN";
            RegCompra = "LETRA";
            ruc = txt_Ruc.Text;
            AgregarCajaChica Check = new AgregarCajaChica(ruc, RegCompra/*,moneda,monedadoc*/);
            Check.Show();
        }

        public void llenarDetalle(List<LetraDetalle> objLista)
        {
            grd_facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha";
            idColumn3.DataPropertyName = "Fec_emi_ref";
            idColumn3.DefaultCellStyle.Format = "dd/mm/yyyy";
            idColumn3.Width = 80;
            grd_facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Tipo";
            idColumn0.DataPropertyName = "TipoDocRef";
            idColumn0.Width = 40;
            grd_facturas.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.DataPropertyName = "SerDocRef";
            idColumn1.Width = 80;
            grd_facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Numero";
            idColumn2.DataPropertyName = "NroDocRef";
            idColumn2.Width = 100;
            grd_facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Proveedor";
            idColumn9.DataPropertyName = "NomProv";
            idColumn9.Width = 220;
            grd_facturas.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Ruc";
            idColumn5.DataPropertyName = "RucProv";
            idColumn5.Width = 80;
            grd_facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.Width = 80;
            grd_facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Total";
            idColumn7.DataPropertyName = "Monto";
            idColumn7.DefaultCellStyle.Format = "0.00";
            idColumn7.Width = 80;
            grd_facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Abono";
            idColumn6.DataPropertyName = "Abono";
            idColumn6.DefaultCellStyle.Format = "0#.#0";
            idColumn6.Width = 80;
            grd_facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Saldo";
            idColumn8.DataPropertyName = "Saldo";
            idColumn8.DefaultCellStyle.Format = "0.00";
            idColumn8.Width = 80;
            grd_facturas.Columns.Add(idColumn8);
            grd_facturas.DataSource = objLista;
            grd_facturas.Refresh();
        }
        public void setDatosCajaChica(List<ContabilidadDTO.Ventas> objList)
        {
            bool porcentaje = false;
            int cont = 0;
            //objListaVoucherDet = new List<VoucherDet>();
            if (grd_facturas.Columns.Count > 1)
            {
                grd_facturas.Columns.RemoveAt(0);
                grd_facturas.Columns.RemoveAt(0);
                grd_facturas.Columns.RemoveAt(0);
                grd_facturas.Columns.RemoveAt(0);
                grd_facturas.Columns.RemoveAt(0);
            }
            grd_facturas.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Fecha";
            idColumn3.DataPropertyName = "Fec_emi_ref";
            idColumn3.Width = 80;
            grd_facturas.Columns.Add(idColumn3);
            DataGridViewTextBoxColumn idColumn0 = new DataGridViewTextBoxColumn();
            idColumn0.Name = "Tipo";
            idColumn0.DataPropertyName = "TipoDocRef";
            idColumn0.Width = 40;
            grd_facturas.Columns.Add(idColumn0);
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.DataPropertyName = "SerDocRef";
            idColumn1.Width = 80;
            grd_facturas.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Numero";
            idColumn2.DataPropertyName = "NroDocRef";
            idColumn2.Width = 100;
            grd_facturas.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn9 = new DataGridViewTextBoxColumn();
            idColumn9.Name = "Proveedor";
            idColumn9.DataPropertyName = "NomProv";
            idColumn9.Width = 220;
            grd_facturas.Columns.Add(idColumn9);
            DataGridViewTextBoxColumn idColumn5 = new DataGridViewTextBoxColumn();
            idColumn5.Name = "Ruc";
            idColumn5.DataPropertyName = "RucProv";
            idColumn5.Width = 80;
            grd_facturas.Columns.Add(idColumn5);
            DataGridViewTextBoxColumn idColumn4 = new DataGridViewTextBoxColumn();
            idColumn4.Name = "Importe";
            idColumn4.DataPropertyName = "Monto";
            idColumn4.Width = 80;
            grd_facturas.Columns.Add(idColumn4);
            DataGridViewTextBoxColumn idColumn7 = new DataGridViewTextBoxColumn();
            idColumn7.Name = "Total";
            idColumn7.DataPropertyName = "Monto";
            idColumn7.DefaultCellStyle.Format = "0.00";
            idColumn7.Width = 80;
            grd_facturas.Columns.Add(idColumn7);
            DataGridViewTextBoxColumn idColumn6 = new DataGridViewTextBoxColumn();
            idColumn6.Name = "Abono";
            idColumn6.DataPropertyName = "Abono";
            idColumn6.DefaultCellStyle.Format = "0#.#0";
            idColumn6.Width = 80;
            grd_facturas.Columns.Add(idColumn6);
            DataGridViewTextBoxColumn idColumn8 = new DataGridViewTextBoxColumn();
            idColumn8.Name = "Saldo";
            idColumn8.DataPropertyName = "Saldo";
            idColumn8.DefaultCellStyle.Format = "0.00";
            idColumn8.Width = 80;
            grd_facturas.Columns.Add(idColumn8);
            DataGridViewTextBoxColumn idColumn10 = new DataGridViewTextBoxColumn();
            idColumn10.Name = "NroRegistroFC";
            idColumn10.DataPropertyName = "NroRegistro";
            idColumn10.Width = 80;
            grd_facturas.Columns.Add(idColumn10);
            grd_facturas.Columns[0].ReadOnly = true;
            grd_facturas.Columns[1].ReadOnly = true;
            grd_facturas.Columns[2].ReadOnly = true;
            grd_facturas.Columns[3].ReadOnly = true;
            grd_facturas.Columns[4].ReadOnly = true;
            grd_facturas.Columns[5].ReadOnly = true;
            grd_facturas.Columns[6].ReadOnly = true;
            grd_facturas.Columns[7].ReadOnly = true;
            grd_facturas.Columns[8].ReadOnly = false;
            grd_facturas.Columns[9].ReadOnly = true;

            /* grd_facturas.Columns[5].Visible = false;
             grd_facturas.Columns[6].Visible = false;
             grd_facturas.Columns[7].Visible = false;
             grd_facturas.Columns[8].Visible = false;
             grd_facturas.Columns[9].Visible = false;
             grd_facturas.Columns[10].Visible = false;*/

            for (int i = 0; i < objList.Count; i++)
            {
                objLetrarDet = new LetraDetalle();
                objLetrarDet.TipoDocRef = objList[i].TipoDocumento;
                objLetrarDet.SerDocRef = objList[i].Serie;
                objLetrarDet.NroDocRef = objList[i].Numero;
                objLetrarDet.Monto = objList[i].Pago;
                objLetrarDet.Item = i + 1;
                objLetrarDet.Fec_emi_ref = objList[i].FechaEmision;
                objLetrarDet.Fec_ven_ref = objList[i].FechaVcto;
                objLetrarDet.RucProv = objList[i].Ruc;
                objLetrarDet.NomProv = objList[i].RazonSocial;
                objLetrarDet.Abono =objList[i].Pago;

                objLetrarDet.Saldo = objList[i].Pago;
                objLetrarDet.NroRegistro = objList[i].VentasId;
                objLetrarDet.NroDoc = txt_NumeroDcto.Text;
                objLetrarDet.TipDoc = txt_tipodoc.Text;
                objLetrarDet.AbonoLetra = objList[i].AbonoLetra;
                objLetrarDet.EstRepDet = "P";

                /*
                objVoucherDet.CodOtReal = objList[i].CodOtReal;
                objVoucherDet.NroOt = objList[i].NroOt;
                objVoucherDet.NroOtReal = objList[i].NroOtReal;
                objVoucherDet.Descripcion = objList[i].Serie.Trim() + "-" + objList[i].Numero.Trim();
                objVoucherDet.Documento = objList[i].Ruc;
                objVoucherDet.RazonSocial = objList[i].RazonSocial;
                objVoucherDet.Importe = objList[i].Pago;
                objVoucherDet.numeroRegistro = objList[i].VentasId;
                objVoucherDet.NumeroVoucher = txt_NroVoucher.Text;
                objVoucherDet.Item = i + 1;
                objVoucherDet.xret = objList[i].xret;
                objVoucherDet.xper = objList[i].xper;
                objVoucherDet.xbue = objList[i].xbue;
                objVoucherDet.xdetra = objList[i].xdetra;
                objVoucherDet.DirOt = objList[i].DirOt;
                objVoucherDet.DirOtReal = objList[i].DirOtReal;
                objVoucherDet.TipDocRef = objList[i].TipoDocumento;

                if (objList[i].xret.ToString() == "TRET" && objList[i].xbue.ToString() == "TBUE" && objList[i].xdetra.ToString() == "no")
                {
                    porcentaje = true;
                }
                else if (objList[i].xret.ToString() == "TRET" && objList[i].xdetra.ToString() == "no")
                {
                    cont++;
                }
                else if (objList[i].xbue.ToString() == "TBUE" && objList[i].xdetra.ToString() == "no")
                {
                    cont++;
                }
                objLetrarDet.TotalDocumento = objList[i].Total;*/
                if (Ventas.UNIDADNEGOCIO=="01")
                {
                    objLetrarDet.CodEnt = "01";
                }
                else
                {
                    objLetrarDet.CodEnt = "02";
                }

                objListaLetraDet.Add(objLetrarDet);
            }
            grd_facturas.DataSource = null;
            grd_facturas.DataSource = objListaLetraDet;
            grd_facturas.Refresh();
            sumatoria();
        }
        void sumatoria()
        {
            txt_Total.Text = objListaLetraDet.Sum(x => x.Monto).ToString("G");
            double d1 = Convert.ToDouble(txt_Total.Text);
            txt_Total.Text = d1.ToString("0.00");

            txt_Abono.Text = objListaLetraDet.Sum(x => x.Abono).ToString("G");
            double d2 = Convert.ToDouble(txt_Abono.Text);
            txt_Abono.Text = d2.ToString("0.00");
        }

        private void btn_Rest_Click(object sender, EventArgs e)
        {
            objListaLetraDet.RemoveAt(index);
            grd_facturas.DataSource = null;
            grd_facturas.DataSource = objListaLetraDet;
            grd_facturas.Refresh();
            sumatoria();
        }
        void habilitarBotones(bool bhabilita1, bool bhabilita2)
        {
            btn_Add.Enabled = bhabilita1;
            /*btn_Editar.Enabled = bhabilita1;
            btn_Guardar.Enabled = bhabilita2;*/
            btn_Rest.Enabled = bhabilita1;
        }

        private void grd_facturas_Click(object sender, EventArgs e)
        {
            
        }

        private void grd_facturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void grd_facturas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sumatoria();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            string msg = " ";
            btn_SaveData.Enabled = false;
            objLetra = new LetraCab();
            objLetra.TipoDoc = txt_tipodoc.Text;
            objLetra.SerieDoc = txt_SerieDcto.Text;
            objLetra.NroDoc = txt_NumeroDcto.Text;
            objLetra.FecRep = dpick_Fecha.Value;
            objLetra.Ruc = txt_Ruc.Text;
            objLetra.CodEnt = Ventas.UNIDADNEGOCIO;
            objLetra.Usuario = Ventas.UsuarioSession;
            objLetra.EstRep = "P";
            objLetra.TipoCambio = objVoucherDao.convertToDouble(txt_Tcambio.Text);
            objLetra.Fec_Reg = dpick_Fecha.Value;
            objLetra.ImporteTotal= objVoucherDao.convertToDouble(txt_Total.Text);
            objLetra.Monto = objVoucherDao.convertToDouble(txt_Abono.Text);
            objLetra.Saldo = objVoucherDao.convertToDouble(txt_Abono.Text);
            objLetra.Fec_Ven = dpck_Fechavcto.Value;
            objLetra.Moneda= cmb_Moneda.SelectedValue.ToString();
            objLetra.Fec_Compromiso = dtp_compromiso.Value;
            objLetra.RazonSocial = txt_Cliente.Text;
            objLetra.Estado_Doc = ".";
            objLetra.NroRegistro = "";
            bool insert;
            if (OperacionGuardar == "M")
            {
                objLetra.NroRegistro = txt_nroregletra.Text;
                insert = objVoucherDao.updateLetrarCab(objLetra, Ventas.UsuarioSession);
                if (insert)
                {
                }
                else
                {
                    msg = "Hubo un problema al modificar";
                    MessageBox.Show(msg);
                    btn_SaveData.Enabled = true;
                    return;
                }
                objLetra.NroRegistro = txt_nroregletra.Text;
                objVoucherDao.deleteLetraDet(objLetra.NroRegistro, Ventas.UNIDADNEGOCIO);
                for (int i = 0; i < objListaLetraDet.Count; i++)
                {
                    objListaLetraDet[i].NroDoc = txt_NumeroDcto.Text;
                    objListaLetraDet[i].NroRegistroLetra = txt_nroregletra.Text;
                    insert = objVoucherDao.insertarLetraRCDet(objListaLetraDet[i]);
                    if (insert == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                    else
                    {
                        Double abonoletra = 0;
                        abonoletra = objListaLetraDet[i].Monto - objListaLetraDet[i].Abono;
                        if (objListaLetraDet[i].AbonoLetra == 0)
                        {
                            if (objListaLetraDet[i].Monto == objListaLetraDet[i].Abono)
                            {
                                objVoucherDao.ActualizarLetraRCDet(objListaLetraDet[i].NroRegistro, objListaLetraDet[i].CodEnt, abonoletra);
                            }
                            else
                            {
                                objVoucherDao.ActualizarAbonoLetraRCDet(objListaLetraDet[i].NroRegistro, objListaLetraDet[i].CodEnt, abonoletra);

                            }
                        }
                        else if (objListaLetraDet[i].AbonoLetra == objListaLetraDet[i].Abono)
                        {
                            objVoucherDao.ActualizarLetraRCDet(objListaLetraDet[i].NroRegistro, objListaLetraDet[i].CodEnt, abonoletra);
                        }
                    }
                }

            }
            else {
                insert = objVoucherDao.insertarLetraCab(objLetra, Ventas.UsuarioSession);
                if(insert)
                {

                }
                else
                {
                    msg = "Hubo un problema al guardar";
                    MessageBox.Show(msg);
                    btn_SaveData.Enabled = true;
                    return;
                }
                for(int i=0;i<objListaLetraDet.Count;i++)
                {
                    objListaLetraDet[i].NroDoc = txt_NumeroDcto.Text;
                    objListaLetraDet[i].NroRegistroLetra = objVoucherDao.getCanjeLetra(Ventas.UNIDADNEGOCIO);
                    insert = objVoucherDao.insertarLetraRCDet(objListaLetraDet[i]);
                    if (insert == false)
                    {
                        MessageBox.Show("Error al guardar");
                        btn_SaveData.Enabled = true;
                        break;
                    }
                    else
                    {
                        Double abonoletra = 0;
                        abonoletra = objListaLetraDet[i].Monto - objListaLetraDet[i].Abono;
                        if(objListaLetraDet[i].AbonoLetra==0)
                        {
                            if (objListaLetraDet[i].Monto == objListaLetraDet[i].Abono)
                            {
                                objVoucherDao.ActualizarLetraRCDet(objListaLetraDet[i].NroRegistro, objListaLetraDet[i].CodEnt,abonoletra);
                            }
                            else
                            {
                                objVoucherDao.ActualizarAbonoLetraRCDet(objListaLetraDet[i].NroRegistro, objListaLetraDet[i].CodEnt, abonoletra);

                            }
                        }
                        else if(objListaLetraDet[i].AbonoLetra == objListaLetraDet[i].Abono)
                        {
                            objVoucherDao.ActualizarLetraRCDet(objListaLetraDet[i].NroRegistro, objListaLetraDet[i].CodEnt, abonoletra);
                        }

                        
                        
                    }
                }
                if (insert)
                {
                    
                    MessageBox.Show("Letra se Guardado exitosamente");
                    btn_SaveData.Enabled = true;
                }
            }
            this.Close();
            CanjeLetra check = new CanjeLetra();
            check.Show();
        }

        private void btn_Limpiar_Click(object sender, EventArgs e)
        {
            objListaLetraDet = null;
            objListaLetraDet = new List<LetraDetalle>();
            objLetra = null;
            objLetra = new LetraCab();
            habilitarBotones(true, false);
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            CanjeLetra.operacionLetra = "Q";
            CanjeLetra Check = new CanjeLetra();
            Check.Show();
        }

        private void btn_Anular_Click(object sender, EventArgs e)
        {
            objVoucher = new LetraCab();
            objLetraDetalle = new LetraDetalle();
            bool anular = objVoucherDao.anularLetraFC(txt_nroregletra.Text, Ventas.UNIDADNEGOCIO);
            if (!anular)
            {
                MessageBox.Show("Hubo un error al anular la Letra");
                return;
            }
            else
            {
                for (int i = 0; i < objListaLetraDet.Count; i++)
                {
                    index = grd_facturas.SelectedCells[0].RowIndex;
                    objLetraDetalle = objListaLetraDet[index];
                    bool anulardet = objVoucherDao.anularLetraDetalleFC(objLetraDetalle.NroRegistro, Ventas.UNIDADNEGOCIO,txt_nroregletra.Text.Trim());
                }
                MessageBox.Show("Letra ha sido anulada");
            }
            btn_Anular.Enabled = false;
            btn_Modificar.Enabled = false;
            btn_SaveData.Enabled = false;
            btn_Add.Enabled = false;
            btn_Rest.Enabled = false;
            objLetra = CanjeLetra.objVoucher;
            llenarCabecera(objLetra);
            objListaLetraDet = objVoucherDao.listarLetraDet(objLetra.NroRegistro, Ventas.UNIDADNEGOCIO);
            llenarDetalle(objListaLetraDet);
            sumatoria();

        }
        void formatearVoucher()
        {
            String Moneda = "";
            String Estado = " ";
            if (objListaLetraDet.Count >= 1)
            {
                for (int i = 0; i < objListaLetraDet.Count; i++)
                {
                    LetraReportRC objLetraReporte;
                    objLetraReporte = new LetraReportRC();
                    objLetraReporte.Serie = objLetra.SerieDoc.Trim();
                    objLetraReporte.NumeroLetra = objLetra.NroDoc.Trim();
                    objLetraReporte.Direccion = objLetra.direccion;
                    objLetraReporte.Ruc = objLetra.Ruc;
                    objLetraReporte.RazonSocial = objLetra.NomProv;
                    objLetraReporte.FechaReg = objLetra.FecRep;
                    objLetraReporte.FechaVen = objLetra.Fec_Ven;
                    objLetraReporte.SerieNumeroLetra = objLetra.SerieDoc.Trim() + "-" + objLetra.NroDoc.Trim();
                    if (objLetra.Moneda == "PEN")
                    {
                        Moneda = "SOLES";
                        objLetraReporte.Moneda = Moneda;
                        objLetraReporte.NumLetra = objDocumentoDAO.numeroALetras(objLetra.Monto) + " " + Moneda.TrimEnd();
                    }
                    else
                    {
                        Moneda = "DOLARES AMERICANOS";
                        objLetraReporte.Moneda = Moneda;
                        objLetraReporte.NumLetra = objDocumentoDAO.numeroALetras(objLetra.Monto) + " " + Moneda.TrimEnd();
                    }
                    if(objLetra.EstRep=="A")
                    {
                        Estado = "A N U L A D O";
                        objLetraReporte.EstadoDocumento = Estado;
                    }
                    objLetraReporte.FechaRegRef = objListaLetraDet[i].Fec_emi_ref;
                    objLetraReporte.TipoDocRef = objListaLetraDet[i].TipoDocRef;
                    objLetraReporte.NumDocRef = objListaLetraDet[i].NroDocRef;
                    objLetraReporte.SerieDocRef = objListaLetraDet[i].SerDocRef;
                    objLetraReporte.ImporteDocRef = objListaLetraDet[i].Monto;
                    objLetraReporte.ImportePercpDocRef = 0.00;
                    objLetraReporte.AbonoDocRef = objListaLetraDet[i].Abono;
                    objLetraReporte.SaldoDocRef = objListaLetraDet[i].Saldo;
                    objLetraReporte.Monto = objLetra.Monto;
                    objLetraReporte.Abono = objLetra.Abono;

                    objListaLetraReporte.Add(objLetraReporte);
                }

            }
        }
        private void btn_Reporte_Click(object sender, EventArgs e)
        {
            try
            {
                String reportetipo = "LCRC";
                btn_Reporte.Enabled = false;
                objListaLetraReporte = new List<LetraReportRC>();

                formatearVoucher();

                ReporteView Check = new ReporteView(reportetipo); // listar factura
                Check.Show();
                btn_Reporte.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR :" + ex.Message);
                btn_Reporte.Enabled = true;
            }
        }
    }
}
