using FacturacionDAM.Modelos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class FrmFacemi : Form
    {
        private BindingSource _bsFactura;
        private BindingSource _bsLineasFactura;
        private Tabla _tablaFactura;
        private Tabla _tablaLineasFactura;
        private Tabla _tablaConceptos;

        private int _idEmisor = -1;
        private int _idCliente = -1;
        private int _anhoFactura = -1;

        public int idFactura = -1;
        public bool modoEdicion = false;

        #region Constructores
        public FrmFacemi()
        {
            InitializeComponent();
            InitFactura();
        }

        public FrmFacemi(BindingSource aBs, Tabla aTabla, int aIdEmisor, int aIdCliente, int aYear, int aIdFactura = -1)
        {
            InitializeComponent();

            _idCliente = aIdCliente;
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

        private void FrmFacemi_Load(object sender, EventArgs e)
        {
            try
            {
                if (!CargarConceptos() || !CargarDatosEmisorYCliente())
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
                Program.appDAM.RegistrarLog("Inicializar factura. Edición: " + modoEdicion.ToString(), ex.Message);
                MessageBox.Show("Se ha producido un error al incializar la factura",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmFacemi_FormClosing(object sender, FormClosingEventArgs e)
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

                FrmLineaFacemi frm = new FrmLineaFacemi(_bsLineasFactura, _tablaLineasFactura, idFactura);
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
                FrmLineaFacemi frm = new FrmLineaFacemi(_bsLineasFactura, _tablaLineasFactura, idFactura, true);
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

        #endregion

        #region Métodos personales

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
                        ActualizarNumeracionEmisorSiEsNuevaFactura();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program.appDAM.RegistrarLog("Guardar nueva factura", ex.Message);
                MessageBox.Show("Se ha producido un error al guardar la factura.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CargarDatosEmisorYCliente()
        {
            lbNifcifEmisor.Text = Program.appDAM.emisor.nifcif;
            lbNombreEmisor.Text = Program.appDAM.emisor.nombreComercial;

            Tabla tCli = new Tabla(Program.appDAM.LaConexion);
            if (tCli.InicializarDatos($"SELECT id, nifcif, nombrecomercial FROM clientes WHERE id = {_idCliente}"))
            {
                lbNifcifCliente.Text = tCli.LaTabla.Rows[0]["nifcif"].ToString();
                lbNombreCliente.Text = tCli.LaTabla.Rows[0]["nombrecomercial"].ToString();

                if (modoEdicion)
                    return true;
                else if (_bsFactura.Current is DataRowView row)
                {
                    row["idemisor"] = Program.appDAM.emisor.id;
                    row["idcliente"] = _idCliente;
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
            lbNifcifCliente.Text = ""; lbNombreCliente.Text = "";
            txtNumero.Text = "";
            fechaFactura.Value = DateTime.Now;
            txtDescripcion.Text = "";
            chkPagada.Checked = false; chkRetencion.Checked = false;
            numTipoRet.Value = 0;
            lbBase.Text = ""; lbCuota.Text = ""; lbTotal.Text = ""; lbRetencion.Text = "";
        }

        private void CargarLineasFacturaExistente()
        {
            int idFacemi = Convert.ToInt32((_bsFactura.Current as DataRowView)["id"]);
            string mSql = $"SELECT * FROM facemilin WHERE idfacemi = {idFacemi}";
            if (_tablaLineasFactura.InicializarDatos(mSql))
                _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
        }

        private void CrearLineasFacturaNueva()
        {
            string mSql = $"SELECT * FROM facemilin WHERE id = -1";
            if (_tablaLineasFactura.InicializarDatos(mSql))
                _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
        }

        private void PrepararBindingFactura()
        {
            if (_bsFactura.Current is DataRowView row)
            {
                if (row["fecha"] == DBNull.Value)
                    row["fecha"] = new DateTime(_anhoFactura, DateTime.Today.Month, DateTime.Today.Day);

                if (!modoEdicion)
                    row["numero"] = Program.appDAM.emisor.nextNumFac;
            }

            txtNumero.DataBindings.Add("Text", _bsFactura, "numero");
            fechaFactura.DataBindings.Add("Value", _bsFactura, "fecha");
            cbConceptFac.DataBindings.Add("SelectedValue", _bsFactura, "idconceptofac");
            txtDescripcion.DataBindings.Add("Text", _bsFactura, "descripcion");
            chkPagada.DataBindings.Add("Checked", _bsFactura, "pagada", true, DataSourceUpdateMode.OnPropertyChanged, false);
            chkRetencion.DataBindings.Add("Checked", _bsFactura, "aplicaret", true, DataSourceUpdateMode.OnPropertyChanged, false);
            numTipoRet.DataBindings.Add("Value", _bsFactura, "tiporet", true, DataSourceUpdateMode.OnPropertyChanged, 0m);
            txtNotas.DataBindings.Add("Text", _bsFactura, "notas");

            lbBase.DataBindings.Add("Text", _bsFactura, "base", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbCuota.DataBindings.Add("Text", _bsFactura, "cuota", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbTotal.DataBindings.Add("Text", _bsFactura, "total", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
            lbRetencion.DataBindings.Add("Text", _bsFactura, "retencion", true, DataSourceUpdateMode.OnPropertyChanged, 0.0, "N2");
        }

        private void PrepararBindingLineas()
        {
            _bsLineasFactura.DataSource = _tablaLineasFactura.LaTabla;
            dgLineasFactura.DataSource = _bsLineasFactura;

            if (dgLineasFactura.Columns.Contains("id"))
                dgLineasFactura.Columns["id"].Visible = false;

            if (dgLineasFactura.Columns.Contains("idfacemi"))
                dgLineasFactura.Columns["idfacemi"].Visible = false;

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
                MessageBox.Show("Debe seleccionar un concepto de facturación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            DateTime inicio = new DateTime(_anhoFactura, 1, 1);
            DateTime fin = new DateTime(_anhoFactura, 12, 31);
            if (fecha < inicio || fecha > fin)
            {
                MessageBox.Show($"La fecha debe estar entre el {inicio:dd/MM/yyyy} y el {fin:dd/MM/yyyy}.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                fechaFactura.Focus();
                return false;
            }

            int numero = Convert.ToInt32(row["numero"]);
            int idActual = modoEdicion ? idFactura : -1;

            string sqlCheck = @"
                SELECT COUNT(*) FROM facemi
                WHERE idemisor = @idemisor
                  AND numero = @numero
                  AND YEAR(fecha) = @anho
                  AND id <> @idActual";

            // Usamos MySqlCommand directo para usar ExecuteScalar
            using (var cmd = new MySqlCommand(sqlCheck, Program.appDAM.LaConexion))
            {
                cmd.Parameters.AddWithValue("@idemisor", _idEmisor);
                cmd.Parameters.AddWithValue("@numero", numero);
                cmd.Parameters.AddWithValue("@anho", _anhoFactura);
                cmd.Parameters.AddWithValue("@idActual", idActual);

                // Ejecutamos Escalar para obtener el conteo real
                int duplicados = Convert.ToInt32(cmd.ExecuteScalar());

                if (duplicados > 0)
                {
                    MessageBox.Show(
                        $"Ya existe otra factura del emisor con el número {numero} en el año {_anhoFactura}.",
                        "Número duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumero.Focus();
                    return false;
                }
            }
            // ------------------------------------------------------

            return true;
        }

        private void ActualizarNumeracionEmisorSiEsNuevaFactura()
        {
            if (!modoEdicion)
            {
                string sql = "UPDATE emisores SET nextnumfac = nextnumfac + 1 WHERE id=@id";
                _tablaFactura.EjecutarComando(sql, new() { { "@id", Program.appDAM.emisor.id } });
                Program.appDAM.emisor.nextNumFac++;
            }
        }

        #endregion
    }
}