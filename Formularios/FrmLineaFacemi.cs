using FacturacionDAM.Modelos;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmLineaFacemi : Form
    {
        private Tabla _tabla;
        private BindingSource _bs;

        private Tabla _tablaProductos;
        private BindingSource _bsProductos;

        private int _idFactura = -1;
        private bool _modoEdicion = false;

        public FrmLineaFacemi()
        {
            InitializeComponent();
        }

        public FrmLineaFacemi(BindingSource aBs, Tabla aTabla, int aIdFactura, bool aModoEdicion = false)
        {
            InitializeComponent();
            _tabla = aTabla;
            _bs = aBs;
            _idFactura = aIdFactura;
            _modoEdicion = aModoEdicion;
        }


        private void FrmLineaFacemi_Load(object sender, EventArgs e)
        {
            CargarProductos();
            PrepararBindings();

            SeleccionarProductoSiEdicion();

            InitLineaFactura();

            RecalcularLinea();
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            TrasladarDatosProducto();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ForzarNoNulosLinea();
            RecalcularLinea();

            if (!ValidarLinea())
                return;

            _bs.EndEdit();            // Finaliza edición del registro actual
            _tabla.GuardarCambios();  // Se propaga a la BD

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _bs.CancelEdit();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #region Métodos propios

        /// <summary>
        /// Inicializar los campos de la linea de factura, para que sus valores por defecto
        /// sean correctos.
        /// </summary>
        private void InitLineaFactura()
        {
            if (!(_bs.Current is DataRowView row))
                return;

            // Las labels con los datos calculados
            lbBase.Text = "";
            lbCuota.Text = "";
            lbTotal.Text = "";

            // Nos aseguramos de que algunos valores no sean nulos
            if (row["idfacemi"] == DBNull.Value) row["idfacemi"] = _idFactura;
            if (row["cantidad"] == DBNull.Value) row["cantidad"] = 1.00m;
            if (row["precio"] == DBNull.Value) row["precio"] = 0.00m;
            if (row["base"] == DBNull.Value) row["base"] = 0.00m;
            if (row["cuota"] == DBNull.Value) row["cuota"] = 0.00m;

            if (row["tipoiva"] == DBNull.Value) row["tipoiva"] = 0.00m;
            if (row["descripcion"] == DBNull.Value) row["descripcion"] = "";
        }

        /// <summary>
        /// Si estamos en modo edicion y la linea de factura tenia seleccionado un producto
        /// hago que se seleccione en el combo correspondiente.
        /// </summary>
        private void SeleccionarProductoSiEdicion()
        {
            if (!_modoEdicion)
                return;

            if (!(_bs.Current is DataRowView row))
                return;

            if (row["idproducto"] == DBNull.Value)
                return;

            int idProducto = Convert.ToInt32(row["idproducto"]);
            cbProducto.SelectedValue = idProducto;
        }


        /// <summary>
        /// Asocia controles con las fuentes de datos
        /// </summary>
        private void PrepararBindings()
        {
            if (!(_bs.Current is DataRowView row))
            {
                MessageBox.Show("No hay una línea activa.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            // Relacion con la factura 
            row["idfacemi"] = _idFactura;

            // Bindings principales
            cbProducto.DataBindings.Add("SelectedValue", _bs, "idproducto", true, DataSourceUpdateMode.OnPropertyChanged, DBNull.Value);

            txtDescripcion.DataBindings.Add("Text", _bs, "descripcion", true, DataSourceUpdateMode.OnPropertyChanged, "");

            numPrecio.DataBindings.Add("Value", _bs, "precio", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

            numTipoIva.DataBindings.Add("Value", _bs, "tipoiva", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

            numCantidad.DataBindings.Add("Value", _bs, "cantidad", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

        }

        /// <summary>
        /// Calcula base, cuota y totales, en función de los datos del formulario.
        /// </summary>
        private void RecalcularLinea()
        {
            if (!(_bs.Current is DataRowView row))
                return;
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

        /// <summary>
        /// Carga los productos en el formulario de productos.
        /// </summary>
        private void CargarProductos()
        {
            _tablaProductos = new Tabla(Program.appDAM.LaConexion);

            // Sentencia SQL select 
            string mSql = @"SELECT p.id, p.descripcion, p.preciounidad, p.activo as producto_activo,
                            t.porcentaje as iva_porcentaje, t.activo as iva_activo from productos p 
                            left join tiposiva t on t.id = p.idtipoiva order by p.descripcion";

            if (!_tablaProductos.InicializarDatos(mSql))
            {
                MessageBox.Show("No se pudieron cargar los productos.", "Aviso",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
                return;
            }

            _bsProductos = new BindingSource
            {
                DataSource = _tablaProductos.LaTabla
            };

            cbProducto.DataSource = _bsProductos;
            cbProducto.DisplayMember = "descripcion";
            cbProducto.ValueMember = "id";
            cbProducto.SelectedIndex = -1;
        }

        /// <summary>
        /// Traslada a la linea de factura los datos del producto seleccionado
        /// </summary>
        private void TrasladarDatosProducto()
        {
            if (!(_bsProductos.Current is DataRowView row))
                return;
            // Precio
            numPrecio.Value = Convert.ToDecimal(row["preciounidad"]);

            //IVA
            numTipoIva.Value = Convert.ToDecimal(row["iva_porcentaje"]);

            // Descripción
            txtDescripcion.Text = row["descripcion"].ToString();

            RecalcularLinea();
        }

        private void ForzarNoNulosLinea()
        {
            if (!(_bs.Current is DataRowView row))
                return;

            if (row["cantidad"] == DBNull.Value)
                row["cantidad"] = numCantidad.Value;
            if (row["precio"] == DBNull.Value)
                row["precio"] = numPrecio.Value;
            if (row["tipoiva"] == DBNull.Value)
                row["tipoiva"] = numTipoIva.Value;
        }

        /// <summary>
        /// Se asegura de que los datos de la línea son correctos.
        /// </summary>
        /// <returns></returns>
        private bool ValidarLinea()
        {
            if (!(_bs.Current is DataRowView row))
                return false;
            // Validación 1: Descripción no puede estar vacía
            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                MessageBox.Show("El campo Descripción no puede estar vacío.");
                return false;
            }
            // Validación 2: Cantidad debe ser mayor que cero
            if (numCantidad.Value <= 0m)
            {
                MessageBox.Show("El campo Cantidad debe ser mayor que cero.");
                return false;
            }
            // Validación 3: Precio debe ser mayor o igual que cero
            if (numPrecio.Value < 0m)
            {
                MessageBox.Show("El campo Precio debe ser mayor o igual que cero.");
                return false;
            }
            // Validación 4: Tipo IVA debe ser mayor o igual que cero
            if (numTipoIva.Value < 0m)
            {
                MessageBox.Show("El campo Tipo IVA debe ser mayor o igual que cero.");
                return false;
            }
            // Valicación 5: Base y cuota no pueden ser negativas
            if (Convert.ToDecimal(row["base"]) < 0m)
            {
                MessageBox.Show("El campo Base no puede ser negativo.");
                return false;
            }
            // Validación 6: Cuota no puede ser negativa
            if (Convert.ToDecimal(row["cuota"]) < 0m)
            {
                MessageBox.Show("El campo Cuota no puede ser negativo.");
                return false;
            }
            // Valicación 7: Si se ha seleccionado un producto, debe estar activo
            if (row["idproducto"] != DBNull.Value)
            {
                int idProducto = Convert.ToInt32(row["idproducto"]);
                DataRow[] productos = _tablaProductos.LaTabla.Select($"id = {idProducto}");
                if (productos.Length == 0 || Convert.ToBoolean(productos[0]["producto_activo"]) == false)
                {
                    MessageBox.Show("El producto seleccionado no está activo. Por favor, seleccione otro producto.");
                    return false;
                }
            }
            // Validación 8: El IVA debe estar activo
            decimal tipoIva = numTipoIva.Value;
            DataRow[] tiposIva = _tablaProductos.LaTabla.Select($"iva_porcentaje = {tipoIva.ToString(System.Globalization.CultureInfo.InvariantCulture)}");
            if (tiposIva.Length == 0 || Convert.ToBoolean(tiposIva[0]["iva_activo"]) == false)
            {
                MessageBox.Show("El tipo de IVA seleccionado no está activo. Por favor, seleccione otro tipo de IVA.");
                return false;
            }
            //Validación 9: No permitir líneas con base y cuota a cero
            if (Convert.ToDecimal(row["base"]) == 0m && Convert.ToDecimal(row["cuota"]) == 0m)
            {
                MessageBox.Show("La línea no puede tener base y cuota a cero.");
                return false;
            }
            return true;
        }

        #endregion

    }
}
