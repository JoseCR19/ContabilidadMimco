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

namespace Contabilidad.CtaXcobrar
{
    public partial class AbonoBanco : Form
    {
        public static AbonoBanco AbonoForm;
        public static List<CuentaBanco> objListaComboBanco = new List<CuentaBanco>();
        public static List<CuentaBanco> objListaBancoDatos = new List<CuentaBanco>();
        public static AbonoBancoCab objAbonoBancoCab;
        public static List<AbonoBancoDet> objListaAbonoBancoDet = new List<AbonoBancoDet>();
        public static List<FacturaAbono> objListaFacturaAbono = new List<FacturaAbono>();
        public static FacturaAbono objFacturaAbono;
        public static Asiento objAsiento;
        public static AsientoDetalle objAsientoDetalle;
        public static List<AsientoDetalle> objListAsientoDetalle = new List<AsientoDetalle>();
        public static List<Asiento> objListAsiento = new List<Asiento>();
        AsientoDAO objAsientoDAO;
        int index;
        AbonoBancoDet objAbonoBancoDet;
        CuentaBanco objBancoDatos, objComboBanco;
        BancoDAO objBancoDAO;
        MonedaDAO objMonedaDao;

        String operacion = "Q";
        public AbonoBanco()
        {
            InitializeComponent();
            AbonoForm = this;
            objBancoDAO = new BancoDAO();
            objComboBanco = new CuentaBanco();
            objBancoDatos = new CuentaBanco();
            objMonedaDao = new MonedaDAO();
            objAbonoBancoDet = new AbonoBancoDet();
            objAbonoBancoCab = new AbonoBancoCab();
            objFacturaAbono = new FacturaAbono();
            objAsientoDAO = new AsientoDAO();
            objAsiento = new Asiento();
            objAsientoDetalle = new AsientoDetalle();
            cargarCmbBanco();
            cmb_Banco.SelectedIndexChanged += Cmb_Banco_SelectedIndexChanged;
            txt_Fecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            objComboBanco = (CuentaBanco)cmb_Banco.SelectedItem;
            objBancoDatos = objBancoDAO.listarBancoDatos(Ventas.UNIDADNEGOCIO, objComboBanco.Codigo, objComboBanco.Descripcion);
            txt_Cuenta.Text = objBancoDatos.Cuenta;
            txt_Moneda.Text = objBancoDatos.Moneda;
            txt_Tcambio.Text = objMonedaDao.getTipoCambioVenta(DateTime.Now.ToShortDateString()).ToString().PadRight(5, '0'); ;
            txt_MonedaCod.Text = objBancoDatos.MonedaCod;
            //gridParams();
            grd_Detalle.CellClick += Grd_Detalle_CellClick;
        }

        private void Grd_Detalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = grd_Detalle.SelectedCells[0].RowIndex;
            objAbonoBancoDet = objListaAbonoBancoDet[index];
            txt_Importe.Text = objAbonoBancoDet.Importe.ToString();
            txt_NroDoc.Text = objAbonoBancoDet.Numero.ToString();
            txt_Serie.Text = objAbonoBancoDet.Serie.ToString();

        }

        private void Cmb_Banco_SelectedIndexChanged(object sender, EventArgs e)
        {
            objComboBanco = (CuentaBanco)cmb_Banco.SelectedItem;
            objBancoDatos = objBancoDAO.listarBancoDatos(Ventas.UNIDADNEGOCIO, objComboBanco.Codigo, objComboBanco.Descripcion);
            txt_Cuenta.Text = objBancoDatos.Cuenta;
            txt_Moneda.Text = objBancoDatos.Moneda;
            txt_MonedaCod.Text = objBancoDatos.MonedaCod;
        }

        void cargarCmbBanco()
        {
            objListaComboBanco = objBancoDAO.getCmbBanco(Ventas.UNIDADNEGOCIO);
            cmb_Banco.DataSource = objListaComboBanco;

            cmb_Banco.DisplayMember = "Descripcion";
            cmb_Banco.ValueMember = "Codigo";
            cmb_Banco.Refresh();

        }

        void habilitarCampos(bool bvalida, bool bvalida2)
        {
            txt_Importe.Enabled = bvalida;
            btn_Guardar.Enabled = bvalida;

            btn_Editar.Enabled = bvalida2;
        }
        void limpiaCampos()
        {
            txt_Importe.Text = "";
            txt_Serie.Text = "";
            txt_NroDoc.Text = "";
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            objAbonoBancoDet = new AbonoBancoDet();
            objAbonoBancoDet.Serie = txt_Serie.Text;
            objAbonoBancoDet.Numero = txt_NroDoc.Text;
            objAbonoBancoDet.Importe = objBancoDAO.convertToDouble(txt_Importe.Text);
            objAbonoBancoDet.Tabla = txt_Tabla.Text;

            objListaAbonoBancoDet[index] = objAbonoBancoDet;


            habilitarCampos(false, true);
            limpiaCampos();
            listAbonoDet(objListaAbonoBancoDet);
            cmb_Banco.Enabled = false;
            operacion = "Q";
        }
        public void listAbonoDet(List<AbonoBancoDet> lista)
        {
            grd_Detalle.DataSource = null;
            grd_Detalle.DataSource = lista;

            grd_Detalle.Refresh();
        }
        private void btn_Editar_Click(object sender, EventArgs e)
        {
            operacion = "M";
            habilitarCampos(true, false);
        }

        private void btn_BuscarFactura_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_ClienteCod.Text))
            {
                MessageBox.Show("Seleccione un Cliente primero");
            }
            else
            {
                using (var buscarFacturaForm = new BuscarFacturaBanco(txt_ClienteCod.Text, objBancoDAO.convertToDouble(txt_Tcambio.Text)))
                {
                    buscarFacturaForm.ShowDialog();
                }
            }
        }
        public void setDatos(List<FacturaAbono> objList)
        {
            objListaAbonoBancoDet = new List<AbonoBancoDet>();
            if (grd_Detalle.Columns.Count > 1)
            {

                grd_Detalle.Columns.RemoveAt(0);
                grd_Detalle.Columns.RemoveAt(0);
                grd_Detalle.Columns.RemoveAt(0);
            }

            objListaFacturaAbono = objList;
            grd_Detalle.AutoGenerateColumns = false;
            DataGridViewTextBoxColumn idColumn1 = new DataGridViewTextBoxColumn();
            idColumn1.Name = "Serie";
            idColumn1.DataPropertyName = "Serie";
            idColumn1.Width = 100;
            grd_Detalle.Columns.Add(idColumn1);
            DataGridViewTextBoxColumn idColumn2 = new DataGridViewTextBoxColumn();
            idColumn2.Name = "Número";
            idColumn2.DataPropertyName = "Numero";
            idColumn2.Width = 100;
            grd_Detalle.Columns.Add(idColumn2);
            DataGridViewTextBoxColumn idColumn3 = new DataGridViewTextBoxColumn();
            idColumn3.Name = "Importe";
            idColumn3.DataPropertyName = "Importe";
            idColumn3.Width = 120;
            grd_Detalle.Columns.Add(idColumn3);

            for (int i = 0; i < objListaFacturaAbono.Count; i++)
            {
                objAbonoBancoDet = new AbonoBancoDet();

                objAbonoBancoDet.Serie = objListaFacturaAbono[i].Serie;
                objAbonoBancoDet.Numero = objListaFacturaAbono[i].Numero;
                if (txt_MonedaCod.Text == "USD")
                {
                    objAbonoBancoDet.Importe = objListaFacturaAbono[i].ImporteDolares;
                }
                else
                {
                    objAbonoBancoDet.Importe = objListaFacturaAbono[i].ImporteSoles;
                }
                objListaAbonoBancoDet.Add(objAbonoBancoDet);

            }

            grd_Detalle.DataSource = objListaAbonoBancoDet;
            grd_Detalle.Refresh();

        }

        public void setDatosCliente(String Ruc, String Razon, String CodClie)
        {
            txt_Ruc.Text = Ruc;
            txt_Razon.Text = Razon;
            txt_ClienteCod.Text = CodClie;
        }
        private void txt_Deshacer_Click(object sender, EventArgs e)
        {

            limpiaCampos();
            objListaAbonoBancoDet = null;
            grd_Detalle.DataSource = null;
            grd_Detalle.Refresh();
            objListaAbonoBancoDet = new List<AbonoBancoDet>();
            cmb_Banco.Enabled = true;
            txt_Observacion.Text = "";
            habilitarCampos(false, true);
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            String msg = "";
            if (objListaAbonoBancoDet.Count== 0)
            {
                msg = "Seleccione alguna factura";
                MessageBox.Show(msg);
                return;
            }
            bool insert;
            int identity;
            
            objAbonoBancoCab = new AbonoBancoCab();
            objAbonoBancoCab.CodEnt = Ventas.UNIDADNEGOCIO;
            objAbonoBancoCab.BancoCod = objBancoDatos.Codigo;
            objAbonoBancoCab.Fecha = txt_Fecha.Text;
            objAbonoBancoCab.MonedaCod = txt_MonedaCod.Text;
            objAbonoBancoCab.Observacion = txt_Observacion.Text;
            objAbonoBancoCab.CuentaContable = objBancoDatos.CuentaContable;
            objAbonoBancoCab.ClienteCod = txt_ClienteCod.Text;
            identity = objBancoDAO.insertAbonoCab(objAbonoBancoCab);

            for (int i = 0; i < objListaAbonoBancoDet.Count; i++)
            {
                msg = objBancoDAO.insertAbonoDet(objListaAbonoBancoDet[i], identity);
                if (msg != "true")
                {
                    MessageBox.Show("Error: " + msg);
                    return;
                }
            }
            String asientoCorrelativo;
            for (int i = 0; i < objListaAbonoBancoDet.Count; i++)
            {
                asientoCorrelativo = objAsientoDAO.getCorrelativoAsientoVenta(txt_Fecha.Text, "21");

                objAsiento = new Asiento();
                objAsiento.Correlativo = asientoCorrelativo;
                objAsiento.MonedaCod = txt_MonedaCod.Text;
                objAsiento.Fecha = txt_Fecha.Text;
                if (objListaFacturaAbono[i].MonedaCod == txt_MonedaCod.Text)
                {
                    objAsiento.Haber = objListaFacturaAbono[i].Total;
                }
                else
                {
                    if (objListaFacturaAbono[i].MonedaCod == "USD" && txt_MonedaCod.Text == "PEN")
                    {
                        objAsiento.Haber = Math.Round(objListaFacturaAbono[i].Total * objBancoDAO.convertToDouble(txt_Tcambio.Text), 2);
                    }
                    else if (objListaFacturaAbono[i].MonedaCod == "PEN" && txt_MonedaCod.Text == "USD")
                    {
                        objAsiento.Haber = Math.Round(objListaFacturaAbono[i].Total / objBancoDAO.convertToDouble(txt_Tcambio.Text), 2);
                    }
                }


                objAsiento.TipoAsiento = "21";
                objAsientoDetalle = new AsientoDetalle();
                objAsientoDetalle.Correlativo = asientoCorrelativo;
                objAsientoDetalle.Fecha = txt_Fecha.Text;
                objAsientoDetalle.TipDocCodigo = "01";
                objAsientoDetalle.TipoAsiento = "21";
                objAsientoDetalle.Documento = objListaAbonoBancoDet[i].Serie + "-" + objListaAbonoBancoDet[i].Numero;
                objAsientoDetalle.Cuenta = objAbonoBancoCab.CuentaContable;
                objAsientoDetalle.TipoImporte = "D";
                if (txt_MonedaCod.Text == "USD")
                {
                    objAsientoDetalle.Importe = objListaFacturaAbono[i].ImporteDolares;
                }
                else
                {
                    objAsientoDetalle.Importe = objListaFacturaAbono[i].ImporteSoles;
                }

                objAsiento.Debe = objAsientoDetalle.Importe;
                objAsientoDAO.insertarAsientoCab(objAsiento);
                objAsientoDAO.insertarAsientoDet(objAsientoDetalle);
                objAsientoDetalle = new AsientoDetalle();
                objAsientoDetalle.Correlativo = asientoCorrelativo;
                objAsientoDetalle.Fecha = txt_Fecha.Text;
                objAsientoDetalle.TipDocCodigo = "01";
                objAsientoDetalle.TipoAsiento = "21";
                objAsientoDetalle.Documento = objListaAbonoBancoDet[i].Serie + "-" + objListaAbonoBancoDet[i].Numero;
                objAsientoDetalle.Cuenta = objListaFacturaAbono[i].CuentaContable;
                objAsientoDetalle.TipoAsiento = "H";
                objAsientoDetalle.Importe = objListaFacturaAbono[i].Total;
                objAsientoDAO.insertarAsientoDet(objAsientoDetalle);
            }

            MessageBox.Show("Abono Guardado Correctamente");
            limpiaCampos();
            habilitarCampos(false, true);
            objListaAbonoBancoDet = null;
            objListaAbonoBancoDet = new List<AbonoBancoDet>();
            grd_Detalle.DataSource = null;
            grd_Detalle.Refresh();
            cmb_Banco.Enabled = true;
            txt_Observacion.Text = "";
        }

        private void btn_BuscarCliente_Click(object sender, EventArgs e)
        {
            using (var buscarClienteForm = new BuscarCliente("AB"))
            {
                buscarClienteForm.ShowDialog();
            }
        }


    }
}
