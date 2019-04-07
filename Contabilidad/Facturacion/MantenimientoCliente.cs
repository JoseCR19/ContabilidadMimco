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
    public partial class MantenimientoCliente : Form
    {
        public static List<Ubigeo> objListDepartamento = new List<Ubigeo>();
        public static List<Ubigeo> objListProvincia = new List<Ubigeo>();
        public static List<Ubigeo> objListDistrito = new List<Ubigeo>();
        public static List<Nacion> objListNacion = new List<Nacion>();
        String operacion = "Q";
        ClienteDAO objClienteDao;
        UbigeoDAO objUbigeoDAO;
        public MantenimientoCliente()
        {
            InitializeComponent();
            objUbigeoDAO = new UbigeoDAO();
            objClienteDao = new ClienteDAO();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(50, 50);
            this.ControlBox = false;
            this.Text = "CLIENTE";
            comboDepartamento();
            comboNacion();
            cmb_Departamento.SelectedValueChanged += Cmb_Departamento_SelectedValueChanged;
            cmb_Provincia.SelectedValueChanged += Cmb_Provincia_SelectedValueChanged;
            if (ListaCliente.operacionCliente =="V")
            {
                
                habilitarCampos(false);
                habilitaBotones(false);
          
                txt_Cliente.Text = ListaCliente.objCliente.ClienteRazonSocial;
                txt_Contacto.Text = ListaCliente.objCliente.ClienteContacto;
                txt_Direccion.Text = ListaCliente.objCliente.ClienteDireccion;
                txt_Email.Text = ListaCliente.objCliente.ClienteEmail;
                txt_Observacion.Text = ListaCliente.objCliente.ClienteObservacion;
                txt_Ruc.Text = ListaCliente.objCliente.ClienteNDoc;
                txt_Telefono.Text = ListaCliente.objCliente.ClienteTelefono;
                txt_Web.Text = ListaCliente.objCliente.ClienteWeb;
                cmb_Departamento.Text = ListaCliente.objCliente.ClienteDepartamento;
                cmb_Provincia.Text = ListaCliente.objCliente.ClienteProvincia;
                cmb_Distrito.Text = ListaCliente.objCliente.ClienteDistrito;
               cmb_Nacion.SelectedValue = ListaCliente.objCliente.ClienteNacion;
                
                if (ListaCliente.objCliente.ClienteRetencion == true)
                {
                    chk_Retencion.Checked = true;
                }
                else 
                {
                    chk_Retencion.Checked = false;
                }
            }
            else
            {
                operacion = "G";
                habilitarCampos(true);
                habilitaBotones(true);
            }
        }

        private void Cmb_Provincia_SelectedValueChanged(object sender, EventArgs e)
        {
            objListDistrito = objUbigeoDAO.listarDistrito(cmb_Departamento.SelectedValue.ToString(), cmb_Provincia.SelectedValue.ToString());
            cmb_Distrito.DataSource = objListDistrito;
            cmb_Distrito.ValueMember = "DistritoId";
            cmb_Distrito.DisplayMember = "Distrito";
            cmb_Distrito.Refresh();
        }

        private void Cmb_Departamento_SelectedValueChanged(object sender, EventArgs e)
        {
            objListProvincia = objUbigeoDAO.listarProvincia(cmb_Departamento.SelectedValue.ToString());
            cmb_Provincia.DataSource = objListProvincia;
            cmb_Provincia.ValueMember = "ProvinciaId";
            cmb_Provincia.DisplayMember = "Provincia";
            cmb_Provincia.Refresh();
        }

        public void comboDepartamento()
        {
            objListDepartamento = objUbigeoDAO.listarDepartamento();
            cmb_Departamento.DataSource = objListDepartamento;
            cmb_Departamento.ValueMember = "DepartamentoId";
            cmb_Departamento.DisplayMember = "Departamento";
            cmb_Departamento.Refresh();
        }
        public void comboNacion()
        {
            Nacion obj = new Nacion();
            obj.IdValor = "2";
            obj.Descripcion = "Nacional";
            objListNacion.Add(obj);
            obj = new Nacion();
            obj.IdValor = "3";
            obj.Descripcion = "Extranjero";
            objListNacion.Add(obj);
            cmb_Nacion.DataSource = objListNacion;
            cmb_Nacion.ValueMember = "IdValor";
            cmb_Nacion.DisplayMember = "Descripcion";
            cmb_Nacion.Refresh();
        }

        private void btn_SaveData_Click(object sender, EventArgs e)
        {
            if (operacion =="M")
            {
                String auxCli = "";
                if (chk_Retencion.Checked)
                {
                    auxCli = "1";
                }else
                {
                    auxCli = "0";
                }
                Cliente obj = new Cliente();
                obj.ClienteCod = ListaCliente.objCliente.ClienteCod;
                obj.ClienteContacto = txt_Contacto.Text;
                obj.ClienteDireccion = txt_Direccion.Text;
                obj.ClienteEmail = txt_Email.Text;
                obj.ClienteNacion = cmb_Nacion.SelectedValue.ToString();
                obj.ClienteNDoc = txt_Ruc.Text;
                obj.ClienteObservacion = txt_Observacion.Text;
                obj.ClienteRazonSocial = txt_Cliente.Text;
                obj.ClienteTelefono = txt_Telefono.Text;
                obj.ClienteWeb = txt_Web.Text;
                obj.ClienteUbigeo = cmb_Departamento.SelectedValue.ToString()+cmb_Provincia.SelectedValue.ToString()+cmb_Distrito.SelectedValue.ToString();
                bool bvalida= objClienteDao.updateCliente(obj, Ventas.UNIDADNEGOCIO, auxCli);
                if (bvalida)
                {
                    MessageBox.Show("Cliente modificado correctamente!");
                }
            } else if(operacion =="G")
            {
                String auxCli = "";
                if (chk_Retencion.Checked)
                {
                    auxCli = "1";
                }
                else
                {
                    auxCli = "0";
                }
                Cliente obj = new Cliente();
                obj.ClienteContacto = txt_Contacto.Text;
                obj.ClienteDireccion = txt_Direccion.Text;
                obj.ClienteEmail = txt_Email.Text;
                obj.ClienteNacion = cmb_Nacion.SelectedValue.ToString();
                obj.ClienteNDoc = txt_Ruc.Text;
                obj.ClienteObservacion = txt_Observacion.Text;
                obj.ClienteRazonSocial = txt_Cliente.Text;
                obj.ClienteTelefono = txt_Telefono.Text;
                obj.ClienteWeb = txt_Web.Text;
                obj.ClienteUbigeo = cmb_Departamento.SelectedValue.ToString() + cmb_Provincia.SelectedValue.ToString() + cmb_Distrito.SelectedValue.ToString();
                bool bvalida = objClienteDao.insertCliente(obj, Ventas.UNIDADNEGOCIO, auxCli);
                if (bvalida)
                {
                    MessageBox.Show("Cliente guardado correctamente!");
                }
            }
            this.Hide();
            ListaCliente.operacionCliente = "Q";
            ListaCliente Check = new ListaCliente();
            Check.Show();
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaCliente.operacionCliente = "Q";
            ListaCliente Check = new ListaCliente();
            Check.Show();
        }
        private void habilitarCampos(bool bvalida)
        {
            txt_Cliente.Enabled = bvalida;
            txt_Contacto.Enabled = bvalida;
            txt_Direccion.Enabled = bvalida;
            txt_Email.Enabled = bvalida;
            txt_Ruc.Enabled = bvalida;
            txt_Telefono.Enabled = bvalida;
            txt_Web.Enabled = bvalida;
            txt_Observacion.Enabled = bvalida;
            chk_Retencion.Enabled = bvalida;
            cmb_Departamento.Enabled = bvalida;
            cmb_Distrito.Enabled = bvalida;
            cmb_Garantia.Enabled = bvalida;
            cmb_Nacion.Enabled = bvalida;
            cmb_Provincia.Enabled = bvalida;
        }
        private void habilitaBotones(bool bvalida1)
        {
            btn_Limpiar.Enabled = bvalida1;
           
            btn_SaveData.Enabled = bvalida1;
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            operacion = "M";
            habilitarCampos(true);
            habilitaBotones(true);
        }
    }
}
