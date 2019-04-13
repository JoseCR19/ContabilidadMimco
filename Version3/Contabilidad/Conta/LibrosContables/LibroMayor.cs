using ContaDAO;
using ContaDTO;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conta.LibrosContables
{
    public partial class LibroMayor : Form
    {
        List<TipoAsiento> objListTipoAsiento = new List<TipoAsiento>();
        List<Moneda> objListMoneda = new List<Moneda>();
        public static List<ContaDTO.LibroDiario> objListaLibroMayor = new List<ContaDTO.LibroDiario>();
        MonedaDAO objMonedaDao;
        AsientoDAO objAsientoDao;
        public LibroMayor()
        {
            InitializeComponent();
            this.ControlBox = false;
            this.Text = "Libro Mayor";
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 20);
            objMonedaDao = new MonedaDAO();
            objAsientoDao = new AsientoDAO();
            objMonedaDao.tipoCambio();
            cmbMes();
            comboMoneda();
        }
        public void comboMoneda()
        {
            objListMoneda = objMonedaDao.listarTipoMoneda();
            cmb_Moneda.DataSource = objListMoneda;
            cmb_Moneda.ValueMember = "MonedaCod";
            cmb_Moneda.DisplayMember = "MonedaDescripcion";
            cmb_Moneda.Refresh();
        }
        void cmbMes()
        {
            List<MesDTO> objListMes = new List<MesDTO>();
            MesDTO objMes = new MesDTO();
            objMes.Month = "Enero";
            objMes.Value = "01";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Febrero";
            objMes.Value = "02";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Marzo";
            objMes.Value = "03";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Abril";
            objMes.Value = "04";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Mayo";
            objMes.Value = "05";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Junio";
            objMes.Value = "06";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Julio";
            objMes.Value = "07";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Agosto";
            objMes.Value = "08";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Septiembre";
            objMes.Value = "09";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Octubre";
            objMes.Value = "10";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Noviembre";
            objMes.Value = "11";
            objListMes.Add(objMes);
            objMes = null;
            objMes = new MesDTO();
            objMes.Month = "Diciembre";
            objMes.Value = "12";
            objListMes.Add(objMes);
            cmb_Mes.DisplayMember = "Month";
            cmb_Mes.ValueMember = "Value";
            cmb_Mes.DataSource = objListMes;
            cmb_Mes.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContabilidadMenu.formContabilidad.setEnabledItems("LM");
        }

        private void btn_Cargar_Click(object sender, EventArgs e)
        {
            objListaLibroMayor = objAsientoDao.getLibroMayor(cmb_Moneda.SelectedValue.ToString(), cmb_Mes.SelectedValue.ToString());
            ReporteLibroMayor check = new ReporteLibroMayor();
            check.Show();
            this.Hide();
        }
    }
}
