using FacturacionDAM.Modelos;
using FacturacionDAM.Utils;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FacturacionDAM.Formularios
{
    public partial class FrmBrowFacrec : Form
    {
        private Tabla _tablaProveedores;
        private BindingSource _bsProveedores;

        private Tabla _tablaFacturas;
        private BindingSource _bsFacturas;

        private YearManager _year;

        private int _idProveedorSeleccionado = -1;

        #region Constructores
        public FrmBrowFacrec()
        {
            InitializeComponent();
            _year = new YearManager(DateTime.Now.Year, 2000, DateTime.Now.Year + 1);
        }
        #endregion

        #region Eventos del formulario

        private void FrmBrowFacrec_Load(object sender, EventArgs e)
        {
            if (!CargarProveedores())
            {
                MessageBox.Show(
                    "No se pudieron cargar los proveedores.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Ajustamos los años disponibles en el combobox
            tsComboYear.Items.Clear();
            tsComboYear.Items.AddRange(
                _year.GetYearList().Select(y => y.ToString()).ToArray()
            );
            int anho = Properties.Settings.Default.UltimoAnhoSeleccionado;
            if (anho != 0)
                _year.CurrentYear = anho;

            tsComboYear.SelectedItem = _year.CurrentYear.ToString();

            // Cargamos las facturas del año y proveedor seleccionado
            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void FrmBrowFacrec_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Guardamos la configuración específica de esta ventana
            ConfiguracionVentana.Guardar(this, "BrowFacrec");
            Properties.Settings.Default.UltimoAnhoSeleccionado = _year.CurrentYear;
            Properties.Settings.Default.Save();
        }

        private void FrmBrowFacrec_Shown(object sender, EventArgs e)
        {
            ConfiguracionVentana.Restaurar(this, "BrowFacrec");
        }

        #endregion

        #region Eventos de controles

        private void tsComboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsComboYear.SelectedItem == null)
                return;

            int newYear = int.Parse(tsComboYear.SelectedItem.ToString());
            _year.CurrentYear = newYear;

            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void dgProveedores_SelectionChanged(object sender, EventArgs e)
        {
            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        private void dgFacturas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tsBtnEdit_Click(sender, e);
        }

        #endregion

        #region Botones

        private void tsBtnNew_Click(object sender, EventArgs e)
        {
            if (_bsFacturas == null) return;

            _bsFacturas.AddNew();
            int nuevoIdFactura = -1;

            // Instanciamos el formulario de Detalle de Compras (FrmFacrec)
            FrmFacrec frm = new FrmFacrec(_bsFacturas, _tablaFacturas,
                Program.appDAM.emisor.id, _idProveedorSeleccionado,
                _year.CurrentYear);

            frm.Text = "Nueva factura recibida (Compra)";

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                nuevoIdFactura = frm.idFactura;
                _tablaFacturas.Refrescar();
            }

            CargarFacturasProveedorYAnyo(_year.CurrentYear);

            if (nuevoIdFactura != -1)
            {
                int idx = _bsFacturas.Find("id", nuevoIdFactura);
                if (idx >= 0)
                    _bsFacturas.Position = idx;
            }
        }

        private void tsBtnEdit_Click(object sender, EventArgs e)
        {
            if (_bsFacturas.Current is DataRowView row)
            {
                int idFacrec = Convert.ToInt32(row["id"]);

                FrmFacrec frm = new FrmFacrec(_bsFacturas, _tablaFacturas,
                    Program.appDAM.emisor.id, _idProveedorSeleccionado,
                    _year.CurrentYear, idFacrec);

                frm.Text = "Editar factura de compra";

                if (frm.ShowDialog(this) == DialogResult.OK)
                    _tablaFacturas.Refrescar();

                CargarFacturasProveedorYAnyo(_year.CurrentYear);

                int idx = _bsFacturas.Find("id", idFacrec);
                if (idx >= 0)
                    _bsFacturas.Position = idx;
            }
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {
            if (!(_bsFacturas.Current is DataRowView row)) return;

            if (MessageBox.Show("¿Eliminar la factura de compra seleccionada?\nSe eliminarán también sus líneas.",
                "Confirmar borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                != DialogResult.Yes)
                return;

            int idFacrec = Convert.ToInt32(row["id"]);

            // Borramos de la tabla facrec
            Tabla tFac = new Tabla(Program.appDAM.LaConexion);
            tFac.EjecutarComando("DELETE FROM facrec WHERE id=@id",
                new() { { "@id", idFacrec } });

            CargarFacturasProveedorYAnyo(_year.CurrentYear);
        }

        // Navegación
        private void tsBtnFirst_Click(object sender, EventArgs e) => _bsFacturas.MoveFirst();
        private void tsBtnPrev_Click(object sender, EventArgs e) => _bsFacturas.MovePrevious();
        private void tsBtnNext_Click(object sender, EventArgs e) => _bsFacturas.MoveNext();
        private void tsBtnLast_Click(object sender, EventArgs e) => _bsFacturas.MoveLast();

        // Exportación
        private void tsBtnExportCSV_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo CSV (*.csv)|*.csv";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarCSV((DataTable)_bsFacturas.DataSource, sfd.FileName);
        }

        private void tsBtnExportXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo XML (*.xml)|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
                ExportarDatos.ExportarXML((DataTable)_bsFacturas.DataSource, sfd.FileName, "Facturas Recibidas");
        }

        #endregion

        #region Métodos Privados

        private bool CargarProveedores()
        {
            string mSql = "SELECT id, nifcif, nombrecomercial FROM proveedores ORDER BY nombrecomercial";

            _tablaProveedores = new Tabla(Program.appDAM.LaConexion);

            if (_tablaProveedores.InicializarDatos(mSql))
            {
                try
                {
                    _bsProveedores = new BindingSource { DataSource = _tablaProveedores.LaTabla };

                    dgProveedores.DataSource = _bsProveedores;

                    dgProveedores.Columns["id"].Visible = false;

                    dgProveedores.Columns["nifcif"].HeaderText = "NIF/CIF";
                    dgProveedores.Columns["nifcif"].Width = 100;
                    dgProveedores.Columns["nombrecomercial"].HeaderText = "Nombre Comercial";
                    dgProveedores.Columns["nombrecomercial"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dgProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgProveedores.MultiSelect = false;

                    dgProveedores.EnableHeadersVisualStyles = false;
                    dgProveedores.ColumnHeadersHeight = 34;
                    dgProveedores.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240, 240);
                    dgProveedores.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 33, 33, 33);
                    dgProveedores.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgProveedores.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 255, 255);
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("Facrec cargar proveedores", ex.Message);
                    return false;
                }
                return true;
            }
            return false;
        }

        private void CargarFacturasProveedorYAnyo(int aAnho)
        {
            if (!(_bsProveedores.Current is DataRowView prov))
            {
                dgFacturas.DataSource = null;
                tsLbNumReg.Text = "Facturas: 0";
                if (tsLbTotalImporte != null) tsLbTotalImporte.Text = "";
                lbHeadFacemi.Text = "FACTURAS DE COMPRA";
                return;
            }

            _idProveedorSeleccionado = Convert.ToInt32(prov["id"]);

            string mSql = $@"
            SELECT id, idempresa, idproveedor, idconceptofac, numero, fecha, descripcion, base, cuota,
            total, tiporet, retencion, aplicaret, pagada, notas
            FROM facrec
            WHERE idproveedor = {_idProveedorSeleccionado} AND idempresa = {Program.appDAM.emisor.id}
            AND YEAR(fecha) = {aAnho}
            ORDER BY fecha, numero DESC";

            _tablaFacturas = new Tabla(Program.appDAM.LaConexion);

            if (_tablaFacturas.InicializarDatos(mSql))
            {
                try
                {
                    _bsFacturas = new BindingSource { DataSource = _tablaFacturas.LaTabla };
                    dgFacturas.DataSource = _bsFacturas;

                    // Ocultar IDs internos
                    dgFacturas.Columns["id"].Visible = false;
                    dgFacturas.Columns["idempresa"].Visible = false;
                    dgFacturas.Columns["idproveedor"].Visible = false;
                    dgFacturas.Columns["idconceptofac"].Visible = false;
                    dgFacturas.Columns["aplicaret"].Visible = false;
                    dgFacturas.Columns["notas"].Visible = false;
                    dgFacturas.Columns["tiporet"].Visible = false;

                    // Configuración visual (Idéntica a Ventas)
                    dgFacturas.Columns["numero"].HeaderText = "Nº";
                    dgFacturas.Columns["numero"].Width = 60; // Un poco más ancho por si son referencias largas
                    dgFacturas.Columns["numero"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgFacturas.Columns["fecha"].HeaderText = "Fecha";
                    dgFacturas.Columns["fecha"].Width = 105;
                    dgFacturas.Columns["fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgFacturas.Columns["descripcion"].HeaderText = "Descripción";
                    dgFacturas.Columns["descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    dgFacturas.Columns["base"].HeaderText = "Base";
                    dgFacturas.Columns["base"].Width = 85;
                    dgFacturas.Columns["base"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacturas.Columns["base"].DefaultCellStyle.Format = "N2";

                    dgFacturas.Columns["cuota"].HeaderText = "Cuota";
                    dgFacturas.Columns["cuota"].Width = 85;
                    dgFacturas.Columns["cuota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacturas.Columns["cuota"].DefaultCellStyle.Format = "N2";

                    dgFacturas.Columns["total"].HeaderText = "Total";
                    dgFacturas.Columns["total"].Width = 85;
                    dgFacturas.Columns["total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacturas.Columns["total"].DefaultCellStyle.Format = "N2";

                    dgFacturas.Columns["retencion"].HeaderText = "Retención";
                    dgFacturas.Columns["retencion"].Width = 85;
                    dgFacturas.Columns["retencion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgFacturas.Columns["retencion"].DefaultCellStyle.Format = "N2";

                    dgFacturas.Columns["pagada"].HeaderText = "¿Pagada?";
                    dgFacturas.Columns["pagada"].Width = 75;
                    dgFacturas.Columns["pagada"].ReadOnly = true;

                    dgFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgFacturas.MultiSelect = false;

                    dgFacturas.EnableHeadersVisualStyles = false;
                    dgFacturas.ColumnHeadersHeight = 34;
                    // Configuración de colores
                    dgFacturas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 240, 240, 240);
                    dgFacturas.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                    dgFacturas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    dgFacturas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(255, 230, 255, 255);

                    string nombreProveedor = prov["nombrecomercial"].ToString();

                    lbHeadFacemi.Text = $"Facturas de '{nombreProveedor}', año {_year.CurrentYear}";
                    tsLbNumReg.Text = $"Facturas: {_bsFacturas.Count}";

                    CalcularTotalFacturas();
                }
                catch (Exception ex)
                {
                    Program.appDAM.RegistrarLog("Cargando Facturas recibidas", ex.Message);
                    MessageBox.Show("No se pudieron cargar las facturas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalcularTotalFacturas()
        {
            decimal totalSum = 0;
            if (_tablaFacturas != null && _tablaFacturas.LaTabla != null)
            {
                foreach (DataRow row in _tablaFacturas.LaTabla.Rows)
                {
                    if (row["total"] != DBNull.Value)
                        totalSum += Convert.ToDecimal(row["total"]);
                }
            }
            if (tsLbTotalImporte != null)
                tsLbTotalImporte.Text = $" | Total: {totalSum:C2}";
        }

        #endregion
    }
}