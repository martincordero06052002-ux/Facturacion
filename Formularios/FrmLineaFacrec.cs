using FacturacionDAM.Modelos;
using System;
using System.Data;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmLineaFacrec : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        private Tabla _tablaProductos;
        private BindingSource _bsProductos;

        private int _idFactura = -1;
        private bool _modoEdicion = false;

        public FrmLineaFacrec()
        {
            InitializeComponent();
        }

        // Constructor que recibe los datos desde la factura padre
        public FrmLineaFacrec(BindingSource aBs, Tabla aTabla, int aIdFactura, bool aModoEdicion = false)
        {
            InitializeComponent();
            _tabla = aTabla;
            _bs = aBs;
            _idFactura = aIdFactura;
            _modoEdicion = aModoEdicion;
        }

        private void FrmLineaFacrec_Load(object sender, EventArgs e)
        {
            CargarProductos();
            PrepararBindings();
            SeleccionarProductoSiEdicion();
            InitLineaFactura();
            RecalcularLinea();
        }

        // 1. Botón de "Trasladar datos del producto"
        private void BtnProducto_Click(object sender, EventArgs e)
        {
            TrasladarDatosProducto();
        }

        // 2. Botón Aceptar
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ForzarNoNulosLinea();
            RecalcularLinea();

            if (!ValidarLinea())
                return;

            _bs.EndEdit();
            _tabla.GuardarCambios();

            DialogResult = DialogResult.OK;
            Close();
        }

        // 3. Botón Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Métodos propios

        private void InitLineaFactura()
        {
            if (!(_bs.Current is DataRowView row)) return;

            lbBase.Text = ""; lbCuota.Text = ""; lbTotal.Text = "";

            // Verificamos si la columna existe antes de asignar (seguridad extra)
            if (row.Row.Table.Columns.Contains("idfacrec") && row["idfacrec"] == DBNull.Value)
                row["idfacrec"] = _idFactura;

            // Valores por defecto
            if (row["cantidad"] == DBNull.Value) row["cantidad"] = 1.00m;
            if (row["precio"] == DBNull.Value) row["precio"] = 0.00m;
            if (row["base"] == DBNull.Value) row["base"] = 0.00m;
            if (row["cuota"] == DBNull.Value) row["cuota"] = 0.00m;
            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = 0.00m;
            if (row["descripcion"] == DBNull.Value) row["descripcion"] = "";
        }

        private void SeleccionarProductoSiEdicion()
        {
            if (!_modoEdicion || !(_bs.Current is DataRowView row)) return;
        }

        private void PrepararBindings()
        {
            if (!(_bs.Current is DataRowView row))
            {
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Vinculación FK
            if (row.Row.Table.Columns.Contains("idfacrec"))
                row["idfacrec"] = _idFactura;

            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged, "");
            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            numTipoIva.DataBindings.Add("Value", _bs, "tipoiva", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            numCantidad.DataBindings.Add("Value", _bs, "cantidad", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
        }

        private void RecalcularLinea()
        {
            if (!(_bs.Current is DataRowView row)) return;

            decimal unidades = numCantidad.Value;
            decimal precio = numPrecio.Value;
            decimal tipoIva = numTipoIva.Value;

            decimal baseLinea = Math.Round(unidades * precio, 2);
            decimal cuotaLinea = Math.Round(baseLinea * tipoIva / 100m, 2);
            decimal totalLinea = baseLinea + cuotaLinea;

            row["base"] = baseLinea;
            row["cuota"] = cuotaLinea;

            lbBase.Text = $"{baseLinea:N2} €";
            lbCuota.Text = $"{cuotaLinea:N2} €";
            lbTotal.Text = $"{totalLinea:N2} €";
        }

        private void CargarProductos()
        {
            _tablaProductos = new Tabla(Program.appDAM.LaConexion);
            // Consulta para llenar el combo de productos
            string mSql = @"SELECT p.id, p.descripcion, p.preciounidad, 
                            t.porcentaje as iva_porcentaje from productos p 
                            left join tiposiva t on t.id = p.idtipoiva order by p.descripcion";

            if (_tablaProductos.InicializarDatos(mSql))
            {
                _bsProductos = new BindingSource { DataSource = _tablaProductos.LaTabla };
                cbProducto.DataSource = _bsProductos;
                cbProducto.DisplayMember = "descripcion";
                cbProducto.ValueMember = "id";
                cbProducto.SelectedIndex = -1;
            }
        }

        private void TrasladarDatosProducto()
        {
            // Este método copia los datos del combo a los campos de texto
            if (!(_bsProductos.Current is DataRowView row)) return;

            numPrecio.Value = Convert.ToDecimal(row["preciounidad"]);

            if (row["iva_porcentaje"] != DBNull.Value)
                numTipoIva.Value = Convert.ToDecimal(row["iva_porcentaje"]);
            else
                numTipoIva.Value = 0;

            txtDescripcion.Text = row["descripcion"].ToString();
            RecalcularLinea();
        }

        private void ForzarNoNulosLinea()
        {
            if (!(_bs.Current is DataRowView row)) return;

            if (row["cantidad"] == DBNull.Value) row["cantidad"] = numCantidad.Value;
            if (row["precio"] == DBNull.Value) row["precio"] = numPrecio.Value;
            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = numTipoIva.Value;
        }

        private bool ValidarLinea()
        {
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("Debe indicar una descripción.");
                return false;
            }
            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor que 0.");
                return false;
            }
            return true;
        }

        #endregion
    }
}