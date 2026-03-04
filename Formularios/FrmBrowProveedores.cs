using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmBrowProveedores : Form
    {
        private Tabla _tabla;
        private BindingSource _bs = new BindingSource();
        private Dictionary<int, string> _provincias;

        public FrmBrowProveedores()
        {
            InitializeComponent();
            _provincias = new Dictionary<int, string>();
        }

        // --- Navegación (Igual que Clientes) ---
        private void tsBtnFirst_Click(object sender, EventArgs e) => _bs.MoveFirst();
        private void tsBtnPrev_Click(object sender, EventArgs e) => _bs.MovePrevious();
        private void tsBtnNext_Click(object sender, EventArgs e) => _bs.MoveNext();
        private void tsBtnLast_Click(object sender, EventArgs e) => _bs.MoveLast();

        // --- CRUD ---

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            _bs.AddNew();
            // CAMBIO: Instanciamos FrmProveedor
            FrmProveedor frm = new FrmProveedor(_bs, _tabla);
            frm.edicion = false;
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                _tabla.Refrescar();
                ActualizarEstado();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                // CAMBIO: Instanciamos FrmProveedor
                FrmProveedor frm = new FrmProveedor(_bs, _tabla);
                frm.edicion = true;
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tabla.Refrescar();
                    ActualizarEstado();
                }
            }
        }

        private void dgTabla_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tsBtnEdit_Click(sender, e);
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (_bs.Current is DataRowView row)
            {
                string mNif = row["nifcif"].ToString();

                // CAMBIO: Verificar si tiene facturas de COMPRA (Recibidas)
                // Implementaremos este método al final devolviendo false por ahora.
                if (TieneFacturasRecibidas(mNif))
                {
                    MessageBox.Show("No se puede eliminar el Proveedor porque tiene facturas de compra asociadas.");
                    return;
                }

                if (MessageBox.Show("¿Desea eliminar el proveedor seleccionado?",
                    "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _bs.RemoveCurrent();
                    _tabla.GuardarCambios();
                    ActualizarEstado();
                }
            }
        }

        private void FrmBrowProveedores_Load(object sender, EventArgs e)
        {
            _tabla = new Tabla(Program.appDAM.LaConexion);

            // CAMBIO: Consulta a proveedores
            string mSql = "SELECT * FROM proveedores";

            if (_tabla.InicializarDatos(mSql))
            {
                _bs.DataSource = _tabla.LaTabla;
                dgTabla.DataSource = _bs;
                CargarProvincias();
                PersonalizarDataGrid();
            }
            else
                MessageBox.Show("No se pudieron cargar los proveedores.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            ActualizarEstado();
        }

        // --- Configuración Visual y Persistencia ---

        private void dgTabla_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgTabla.Columns[e.ColumnIndex].Name == "idprovincia")
            {
                if (e.Value is int idProvincia)
                {
                    e.Value = ObtenerNombreProvincia(idProvincia);
                    e.FormattingApplied = true;
                }
            }
        }

        private void FrmBrowProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            // CAMBIO: Guardamos con una clave distinta "BrowProveedores"
            ConfiguracionVentana.Guardar(this, "BrowProveedores");
        }

        private void FrmBrowProveedores_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowProveedores");
        }

        // --- Exportación ---
        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bs.DataSource, sfd.FileName);
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
                // CAMBIO: Etiqueta XML "Proveedores"
                ExportarDatos.ExportarXML((DataTable)_bs.DataSource, sfd.FileName, "Proveedores");
        }

        // --- Métodos Privados ---

        private void ActualizarEstado()
        {
            tsLbNumReg.Text = $"Nº de registros: {_bs.Count}";
        }

        private void PersonalizarDataGrid()
        {
            // Misma estructura que clientes, asumiendo mismos nombres de campo
            dgTabla.Columns["id"].Visible = false;
            if (dgTabla.Columns.Contains("telefono2")) dgTabla.Columns["telefono2"].Visible = false;
            dgTabla.Columns["domicilio"].Visible = false;

            dgTabla.Columns["nifcif"].HeaderText = "NIF/CIF";
            dgTabla.Columns["nifcif"].Width = 100;
            dgTabla.Columns["nombre"].HeaderText = "Nombre";
            dgTabla.Columns["nombre"].Width = 120;
            dgTabla.Columns["apellidos"].HeaderText = "Apellidos";
            dgTabla.Columns["apellidos"].Width = 160;
            dgTabla.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
            dgTabla.Columns["nombrecomercial"].Width = 200;

            // ... Resto del estilo igual que en Clientes ...
            dgTabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 255, 255);
        }

        private void CargarProvincias()
        {
            using var cmd = new MySqlCommand("SELECT id, nombreprovincia FROM provincias", Program.appDAM.LaConexion);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string nombre = reader.GetString(1);
                _provincias[id] = nombre;
            }
        }

        private string ObtenerNombreProvincia(int id)
        {
            return _provincias.TryGetValue(id, out var nombre) ? nombre : "";
        }

        // Método placeholder hasta que implementemos Compras
        private bool TieneFacturasRecibidas(string aNifCif)
        {
            return false;
        }
    }
}