using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmProveedor : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;
        public bool edicion;

        public FrmProveedor(BindingSource bs, Tabla tabla)
        {
            InitializeComponent();
            _bs = bs;
            _tabla = tabla;
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            // Enlazamos los controles igual que en Clientes
            txtNifCif.DataBindings.Add("Text", _bs, "nifcif");
            txtNombre.DataBindings.Add("Text", _bs, "nombre");
            txtApellidos.DataBindings.Add("Text", _bs, "apellidos");
            txtNombreComercial.DataBindings.Add("Text", _bs, "nombrecomercial");
            txtDomicilio.DataBindings.Add("Text", _bs, "domicilio");
            txtPob.DataBindings.Add("Text", _bs, "poblacion");
            txtCp.DataBindings.Add("Text", _bs, "codigopostal");
            txtTel1.DataBindings.Add("Text", _bs, "telefono1");
            txtTel2.DataBindings.Add("Text", _bs, "telefono2");
            txtEmail.DataBindings.Add("Text", _bs, "email");

            // Cargar provincias (Reutilizamos la misma lógica porque la tabla provincias es común)
            Tabla tablaProvincias = new Tabla(Program.appDAM.LaConexion);
            tablaProvincias.InicializarDatos("SELECT * FROM provincias");
            cbProv.DataSource = tablaProvincias.LaTabla;
            cbProv.DisplayMember = "nombreprovincia";
            cbProv.ValueMember = "id";
            cbProv.DataBindings.Add("SelectedValue", _bs, "idprovincia");
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos()) return;

            _bs.EndEdit();
            _tabla.GuardarCambios();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            this.Close();
        }

        private bool ValidarDatos()
        {
            if (string.IsNullOrWhiteSpace(txtNifCif.Text))
            {
                MessageBox.Show("El campo NIF/CIF no puede estar vacío.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreComercial.Text))
            {
                MessageBox.Show("El campo Nombre Comercial no puede estar vacío.");
                return false;
            }

            string email = txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(email) && !Validaciones.EsEmailValido(email))
            {
                MessageBox.Show("El formato del email no es válido.");
                return false;
            }

            //Validamos duplicados en 'proveedores'
            if (NifDuplicado(txtNifCif.Text.Trim()))
            {
                MessageBox.Show("El NIF/CIF introducido ya existe en otro proveedor.");
                return false;
            }

            return true;
        }

        private bool NifDuplicado(string nifCif)
        {
            //Tabla "proveedores"
            if (edicion && _bs.Current is DataRowView row && row["id"] is int id)
                return !Validaciones.EsValorCampoUnico("proveedores", "nifcif", txtNifCif.Text.Trim(), id);

            return !Validaciones.EsValorCampoUnico("proveedores", "nifcif", txtNifCif.Text.Trim());
        }
    }
}