using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmFacrec : Form
    {
        private BindingSource _bsFactura;
        private BindingSource _bsLineasFactura;
        private Tabla _tablaFactura;
        private Tabla _tablaLineasFactura;
        private Tabla _tablaConceptos;

        private int _idEmisor = -1;
        private int _idProveedor = -1;
        private int _anhoFactura = -1;

        public int idFactura = -1;
        public bool modoEdicion = false;

        #region Constructores

        public FrmFacrec()
        {
            InitializeComponent();
            InitFactura();
        }

        public FrmFacrec(BindingSource aBs, Tabla aTabla, int aIdEmisor, int aIdProveedor, int aYear, int aIdFactura = -1)
        {
            InitializeComponent();

            _idProveedor = aIdProveedor;
            _idEmisor = aIdEmisor;
            _anhoFactura = aYear;
            idFactura = aIdFactura;
            modoEdicion = (aIdFactura != -1);

            _bsFactura = aBs;
            _tablaFactura = aTabla;

            InitFactura();
        }

        #endregion

        #region Eventos del formulario

        private void FrmFacrec_Load(object sender, EventArgs e)
        {
            try
            {
                if (!CargarConceptos() || !CargarDatosEmisorYProveedor())
                    return;

                PrepararBindingFactura();

                if (modoEdicion)
                    CargarLineasFacturaExistente();
                else
                    CrearLineasFacturaNueva();

                PrepararBindingLineas();
                RecalcularTotales();
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Inicializar factura compra. Edición: " + modoEdicion.ToString(), ex.Message);
                MessageBox.Show("Se ha producido un error al incializar la factura",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmFacrec_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && _bsFactura != null)
            {
                fechaFactura.DataBindings.Clear();
                _bsFactura.CancelEdit();
            }
        }

        #endregion

        #region Botones

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            bool mCrearNuevaLinea = false;
            if (!modoEdicion)
            {
                if (MessageBox.Show(
                            "No ha guardado la nueva factura.\n" +
                            "¿Guardar la nueva factura antes crear la línea de facturación?",
                            "Confirmación", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes)

                    mCrearNuevaLinea = GuardarFactura();
            }
            else
                mCrearNuevaLinea = true;

            if (mCrearNuevaLinea)
            {
                _bsLineasFactura.AddNew();

                FrmLineaFacrec frm = new FrmLineaFacrec(_bsLineasFactura, _tablaLineasFactura, idFactura);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tablaLineasFactura.Refrescar();
                    ActualizarEstado();
                    RecalcularTotales();
                }
                else
                    _bsLineasFactura.CancelEdit();
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bsLineasFactura.Current is DataRowView)
            {
                FrmLineaFacrec frm = new FrmLineaFacrec(_bsLineasFactura, _tablaLineasFactura, idFactura, true);
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    _tablaLineasFactura.Refrescar();
                    ActualizarEstado();
                    RecalcularTotales();
                }
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (!(_bsLineasFactura.Current is DataRowView)) return;

            if (MessageBox.Show("¿Eliminar la línea de factura seleccionada?",
                "Confirmar", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            _bsLineasFactura.RemoveCurrent();
            _tablaLineasFactura.GuardarCambios();

            ActualizarEstado();
            RecalcularTotales();
        }

        private void tsBtnFirst_Click(object sender, EventArgs e) => _bsLineasFactura.MoveFirst();
        private void tsBtnPrev_Click(object sender, EventArgs e) => _bsLineasFactura.MovePrevious();
        private void tsBtnNext_Click(object sender, EventArgs e) => _bsLineasFactura.MoveNext();
        private void tsBtnLast_Click(object sender, EventArgs e) => _bsLineasFactura.MoveLast();

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (GuardarFactura())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            if (_bsLineasFactura == null || _bsLineasFactura.Count == 0)
            {
                MessageBox.Show("No hay líneas de factura para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            sfd.FileName = $"Factura_Compra_{txtNumero.Text}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportarDatos.ExportarCSV((DataTable)_bsLineasFactura.DataSource, sfd.FileName);
            }
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            if (_bsLineasFactura == null || _bsLineasFactura.Count == 0)
            {
                MessageBox.Show("No hay líneas de factura para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            sfd.FileName = $"Factura_Compra_{txtNumero.Text}.xml";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportarDatos.ExportarXML((DataTable)_bsLineasFactura.DataSource, sfd.FileName, "LineasFacturaCompra");
            }
        }

        #endregion

        #region Métodos privados

        private void ActualizarEstado()
        {
            tsLbNumReg.Text = $"Nº de registros: {_bsLineasFactura.Count}";
        }

        private bool GuardarFactura()
        {
            try
            {
                this.ValidateChildren();

                if (!ValidarDatos())
                    return false;
                else
                {
                    ForzarValoresNoNulos();
                    _bsFactura.EndEdit();
                    _tablaFactura.GuardarCambios();

                    if (!modoEdicion)
                    {
                        using (var cmd = new MySqlCommand("SELECT LAST_INSERT_ID()", Program.appDAM.LaConexion))
                        {
                            object res = cmd.ExecuteScalar();
                            idFactura = Convert.ToInt32(res);
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Guardar nueva factura compra", ex.Message);
                MessageBox.Show("Se ha producido un error al guardar la factura.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CargarDatosEmisorYProveedor()
        {
            lbNifcifEmisor.Text = Program.appDAM.emisor.nifcif;
            lbNombreEmisor.Text = Program.appDAM.emisor.nombreComercial;

            Tabla tProv = new Tabla(Program.appDAM.LaConexion);
            if (tProv.InicializarDatos($"SELECT id, nifcif, nombrecomercial FROM proveedores WHERE id = {_idProveedor}"))
            {
                lbNifcifProveedor.Text = tProv.LaTabla.Rows[0]["nifcif"].ToString();
                lbNombreProveedor.Text = tProv.LaTabla.Rows[0]["nombrecomercial"].ToString();

                if (modoEdicion)
                    return true;
                else if (_bsFactura.Current is DataRowView row)
                {
                    row["idempresa"] = Program.appDAM.emisor.id;
                    row["idproveedor"] = _idProveedor;
                    return true;
                }
            }
            return false;
        }

        private bool CargarConceptos()
        {
            if (_tablaConceptos.InicializarDatos("SELECT id, descripcion FROM conceptosfac ORDER BY descripcion"))
            {
                cbConceptFac.DataSource = _tablaConceptos.LaTabla;
                cbConceptFac.DisplayMember = "descripcion";
                cbConceptFac.ValueMember = "id";
                return true;
            }
            cbConceptFac.Enabled = false;
            return false;
        }

        private void InitFactura()
        {
            _tablaLineasFactura = new Tabla(Program.appDAM.LaConexion);
            _tablaConceptos = new Tabla(Program.appDAM.LaConexion);
            _bsLineasFactura = new BindingSource();

            lbNifcifEmisor.Text = ""; lbNombreEmisor.Text = "";
            lbNifcifProveedor.Text = ""; lbNombreProveedor.Text = "";
            txtNumero.Text = "";
            fechaFactura.Value = DateTime.Now;
            txtDescripcion.Text = "";
            chkPagada.Checked = false; chkRetencion.Checked = false;
            numTipoRet.Value = 0;
            lbBase.Text = ""; lbCuota.Text = ""; lbTotal.Text = ""; lbRetencion.Text = "";
        }

        private void CargarLineasFacturaExistente()
        {
            int idFacrec = Convert.ToInt32((_bsFactura.Current as DataRowView)["id"]);
            //Tabla 'facrelin' 
            string mSql = $"SELECT * FROM facrelin WHERE idfacrec = {idFacrec}";
            if (_tablaLineasFactura.InicializarDatos(mSql))
                _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
        }

        private void CrearLineasFacturaNueva()
        {
            //Tabla 'facrelin'
            string mSql = $"SELECT * FROM facrelin WHERE id = -1";
            if (_tablaLineasFactura.InicializarDatos(mSql))
                _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
        }

        private void PrepararBindingFactura()
        {
            if (_bsFactura.Current is DataRowView row)
            {
                if (row["fecha"] == DBNull.Value)
                    row["fecha"] = new DateTime(_anhoFactura, DateTime.Today.Month, DateTime.Today.Day);
            }

            txtNumero.DataBindings.Add("Text", _bsFactura, "numero");
            fechaFactura.DataBindings.Add("Value", _bsFactura, "fecha");
            cbConceptFac.DataBindings.Add("SelectedValue", _bsFactura, "idconceptofac");
            txtDescripcion.DataBindings.Add("Text", _bsFactura, "descripcion");
            chkPagada.DataBindings.Add("Checked", _bsFactura, "pagada", true, DataSourceUpdateMode.OnPropertyChanged, false);
            chkRetencion.DataBindings.Add("Checked", _bsFactura, "aplicaret", true, DataSourceUpdateMode.OnPropertyChanged, false);
            numTipoRet.DataBindings.Add("Value", _bsFactura, "tiporet", true, DataSourceUpdateMode.OnPropertyChanged, 0m);

            lbBase.DataBindings.Add("Text", _bsFactura, "base", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbCuota.DataBindings.Add("Text", _bsFactura, "cuota", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbTotal.DataBindings.Add("Text", _bsFactura, "total", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbRetencion.DataBindings.Add("Text", _bsFactura, "retencion", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
        }

        private void PrepararBindingLineas()
        {
            _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
            dgLineasFactura.DataSource = _bsLineasFactura;

            //Solo oculta/modifica si la columna existe
            if (dgLineasFactura.Columns.Contains("id"))
                dgLineasFactura.Columns["id"].Visible = false;

            if (dgLineasFactura.Columns.Contains("idfacrec"))
                dgLineasFactura.Columns["idfacrec"].Visible = false;

            if (dgLineasFactura.Columns.Contains("descripcion"))
                dgLineasFactura.Columns["descripcion"].HeaderText = "Descripción";

            if (dgLineasFactura.Columns.Contains("cantidad"))
                dgLineasFactura.Columns["cantidad"].HeaderText = "Cantidad";

            if (dgLineasFactura.Columns.Contains("precio"))
                dgLineasFactura.Columns["precio"].HeaderText = "Precio";

            if (dgLineasFactura.Columns.Contains("base"))
                dgLineasFactura.Columns["base"].HeaderText = "Base";

            if (dgLineasFactura.Columns.Contains("tipoiva"))
                dgLineasFactura.Columns["tipoiva"].HeaderText = "IVA %";

            if (dgLineasFactura.Columns.Contains("cuota"))
                dgLineasFactura.Columns["cuota"].HeaderText = "Cuota IVA";
        }

        private void RecalcularTotales()
        {
            decimal baseSum = 0, cuotaSum = 0;

            foreach (DataRow fila in _tablaLineasFactura.LaTabla.Rows)
            {
                if (fila.RowState != DataRowState.Deleted)
                {
                    baseSum += fila.Field<decimal>("base");
                    cuotaSum += fila.Field<decimal>("cuota");
                }
            }
            decimal total = baseSum + cuotaSum;
            decimal tipoRet = chkRetencion.Checked ? numTipoRet.Value : 0;
            decimal retencion = Math.Round(baseSum * (tipoRet / 100), 2);

            if (_bsFactura.Current is DataRowView row)
            {
                row["base"] = baseSum;
                row["cuota"] = cuotaSum;
                row["total"] = total;
                row["retencion"] = retencion;
            }
        }

        private void ForzarValoresNoNulos()
        {
            if (_bsFactura.Current is DataRowView row)
            {
                if (row["tiporet"] == DBNull.Value) row["tiporet"] = numTipoRet.Value;
                if (row["aplicaret"] == DBNull.Value) row["aplicaret"] = chkRetencion.Checked ? 1 : 0;
                if (row["pagada"] == DBNull.Value) row["pagada"] = chkPagada.Checked ? 1 : 0;
            }
        }

        private bool ValidarDatos()
        {
            if (!(_bsFactura.Current is DataRowView row)) return false;

            if (row["numero"] == DBNull.Value || string.IsNullOrWhiteSpace(row["numero"].ToString()))
            {
                MessageBox.Show("El campo 'Número' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumero.Focus();
                return false;
            }

            if (row["fecha"] == DBNull.Value)
            {
                MessageBox.Show("El campo 'Fecha' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaFactura.Focus();
                return false;
            }

            if (row["idconceptofac"] == DBNull.Value || Convert.ToInt32(row["idconceptofac"]) <= 0)
            {
                MessageBox.Show("Debe seleccionar un concepto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbConceptFac.Focus();
                return false;
            }

            if (row["descripcion"] == DBNull.Value || string.IsNullOrWhiteSpace(row["descripcion"].ToString()))
            {
                MessageBox.Show("El campo 'Descripción' es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescripcion.Focus();
                return false;
            }

            DateTime fecha = Convert.ToDateTime(row["fecha"]);
            if (fecha.Year != _anhoFactura)
            {
                MessageBox.Show($"La fecha debe estar dentro del año {_anhoFactura}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaFactura.Focus();
                return false;
            }

            int idActual = modoEdicion ? idFactura : -1;
            string sqlCheck = @"
                SELECT COUNT(*) FROM facrec
                WHERE idproveedor = @idproveedor
                  AND numero = @numero
                  AND YEAR(fecha) = @anho
                  AND id <> @idActual";

            // Usamos MySqlCommand directo para usar ExecuteScalar
            using (var cmd = new MySqlCommand(sqlCheck, Program.appDAM.LaConexion))
            {
                cmd.Parameters.AddWithValue("@idproveedor", _idProveedor);
                cmd.Parameters.AddWithValue("@numero", row["numero"]);
                cmd.Parameters.AddWithValue("@anho", _anhoFactura);
                cmd.Parameters.AddWithValue("@idActual", idActual);

                // Ejecutamos Escalar devuelve el conteo real
                int duplicados = Convert.ToInt32(cmd.ExecuteScalar());

                if (duplicados > 0)
                {
                    MessageBox.Show(
                        $"Ya existe una factura de este proveedor con el número {row["numero"]} en el año {_anhoFactura}.",
                        "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumero.Focus();
                    return false;
                }
            }
            // ------------------------------------------------------

            return true;
        }

        #endregion
    }
}