namespace FacturacionDAM.Formularios
{
    partial class FrmBrowFacrec
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowFacrec));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tsComboYear = new ToolStripComboBox();
            toolStripSeparator4 = new ToolStripSeparator();
            tsBtnExportXML = new ToolStripButton();
            tsBtnExportCSV = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsBtnLast = new ToolStripButton();
            tsBtnNext = new ToolStripButton();
            tsBtnPrev = new ToolStripButton();
            tsBtnFirst = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsBtnDelete = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsBtnEdit = new ToolStripButton();
            tsBtnNew = new ToolStripButton();
            toolStripLabel1 = new ToolStripLabel();
            tsHerramientas = new ToolStrip();
            tsLbTotalImporte = new ToolStripStatusLabel();
            tsLbStatus = new ToolStripStatusLabel();
            tsLbNumReg = new ToolStripStatusLabel();
            statusStrip1 = new StatusStrip();
            pnStatus = new Panel();
            lbHeadFacemi = new Label();
            dgFacturas = new DataGridView();
            pnHeadFacemi = new Panel();
            pnGrid = new Panel();
            label1 = new Label();
            pnHeadClientes = new Panel();
            dgProveedores = new DataGridView();
            pnClientes = new Panel();
            pnMenu = new Panel();
            splitContainerFacemi = new SplitContainer();
            tsLbTotalBase = new ToolStripStatusLabel();
            tsLbTotalCuota = new ToolStripStatusLabel();
            tsLbTotalRetencion = new ToolStripStatusLabel();
            tsHerramientas.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgFacturas).BeginInit();
            pnHeadFacemi.SuspendLayout();
            pnGrid.SuspendLayout();
            pnHeadClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgProveedores).BeginInit();
            pnClientes.SuspendLayout();
            pnMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerFacemi).BeginInit();
            splitContainerFacemi.Panel1.SuspendLayout();
            splitContainerFacemi.Panel2.SuspendLayout();
            splitContainerFacemi.SuspendLayout();
            SuspendLayout();
            // 
            // tsComboYear
            // 
            tsComboYear.BackColor = Color.Azure;
            tsComboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            tsComboYear.Name = "tsComboYear";
            tsComboYear.Size = new Size(105, 33);
            tsComboYear.SelectedIndexChanged += tsComboYear_SelectedIndexChanged;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Margin = new Padding(5, 0, 20, 0);
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 33);
            // 
            // tsBtnExportXML
            // 
            tsBtnExportXML.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnExportXML.Image = (Image)resources.GetObject("tsBtnExportXML.Image");
            tsBtnExportXML.ImageTransparentColor = Color.Magenta;
            tsBtnExportXML.Name = "tsBtnExportXML";
            tsBtnExportXML.Size = new Size(34, 28);
            tsBtnExportXML.Text = "toolStripButton1";
            tsBtnExportXML.ToolTipText = "Exportar a formato XML";
            tsBtnExportXML.Click += tsBtnExportXML_Click;
            // 
            // tsBtnExportCSV
            // 
            tsBtnExportCSV.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnExportCSV.Image = (Image)resources.GetObject("tsBtnExportCSV.Image");
            tsBtnExportCSV.ImageTransparentColor = Color.Magenta;
            tsBtnExportCSV.Name = "tsBtnExportCSV";
            tsBtnExportCSV.Size = new Size(34, 28);
            tsBtnExportCSV.Text = "toolStripButton1";
            tsBtnExportCSV.ToolTipText = "Exportar a formato CSV";
            tsBtnExportCSV.Click += tsBtnExportCSV_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 33);
            // 
            // tsBtnLast
            // 
            tsBtnLast.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnLast.Image = (Image)resources.GetObject("tsBtnLast.Image");
            tsBtnLast.ImageTransparentColor = Color.Magenta;
            tsBtnLast.Name = "tsBtnLast";
            tsBtnLast.Size = new Size(34, 28);
            tsBtnLast.Text = "Último registro";
            tsBtnLast.Click += tsBtnLast_Click;
            // 
            // tsBtnNext
            // 
            tsBtnNext.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnNext.Image = (Image)resources.GetObject("tsBtnNext.Image");
            tsBtnNext.ImageTransparentColor = Color.Magenta;
            tsBtnNext.Name = "tsBtnNext";
            tsBtnNext.Size = new Size(34, 28);
            tsBtnNext.Text = "Siguiente registro";
            tsBtnNext.Click += tsBtnNext_Click;
            // 
            // tsBtnPrev
            // 
            tsBtnPrev.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnPrev.Image = (Image)resources.GetObject("tsBtnPrev.Image");
            tsBtnPrev.ImageTransparentColor = Color.Magenta;
            tsBtnPrev.Name = "tsBtnPrev";
            tsBtnPrev.Size = new Size(34, 28);
            tsBtnPrev.Text = "Registro anterior";
            tsBtnPrev.Click += tsBtnPrev_Click;
            // 
            // tsBtnFirst
            // 
            tsBtnFirst.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnFirst.Image = (Image)resources.GetObject("tsBtnFirst.Image");
            tsBtnFirst.ImageTransparentColor = Color.Magenta;
            tsBtnFirst.Name = "tsBtnFirst";
            tsBtnFirst.Size = new Size(34, 28);
            tsBtnFirst.Text = "Primer registro";
            tsBtnFirst.Click += tsBtnFirst_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 33);
            // 
            // tsBtnDelete
            // 
            tsBtnDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnDelete.Image = (Image)resources.GetObject("tsBtnDelete.Image");
            tsBtnDelete.ImageTransparentColor = Color.Magenta;
            tsBtnDelete.Name = "tsBtnDelete";
            tsBtnDelete.Size = new Size(34, 28);
            tsBtnDelete.Text = "Eliminar registro";
            tsBtnDelete.Click += tsBtnDelete_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 33);
            // 
            // tsBtnEdit
            // 
            tsBtnEdit.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnEdit.Image = (Image)resources.GetObject("tsBtnEdit.Image");
            tsBtnEdit.ImageTransparentColor = Color.Magenta;
            tsBtnEdit.Name = "tsBtnEdit";
            tsBtnEdit.Size = new Size(34, 28);
            tsBtnEdit.Text = "Editar registro";
            tsBtnEdit.Click += tsBtnEdit_Click;
            // 
            // tsBtnNew
            // 
            tsBtnNew.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnNew.Image = (Image)resources.GetObject("tsBtnNew.Image");
            tsBtnNew.ImageTransparentColor = Color.Magenta;
            tsBtnNew.Name = "tsBtnNew";
            tsBtnNew.Size = new Size(34, 28);
            tsBtnNew.Text = "Nuevo registro";
            tsBtnNew.Click += tsBtnNew_Click;
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(54, 28);
            toolStripLabel1.Text = "Año: ";
            // 
            // tsHerramientas
            // 
            tsHerramientas.ImageScalingSize = new Size(20, 20);
            tsHerramientas.Items.AddRange(new ToolStripItem[] { tsBtnNew, tsBtnEdit, toolStripSeparator1, tsBtnDelete, toolStripSeparator2, tsBtnFirst, tsBtnPrev, tsBtnNext, tsBtnLast, toolStripSeparator3, tsBtnExportCSV, tsBtnExportXML, toolStripSeparator4, toolStripLabel1, tsComboYear });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Padding = new Padding(0, 0, 3, 0);
            tsHerramientas.Size = new Size(803, 33);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "toolStrip1";
            // 
            // tsLbTotalImporte
            // 
            tsLbTotalImporte.BorderSides = ToolStripStatusLabelBorderSides.Left;
            tsLbTotalImporte.Name = "tsLbTotalImporte";
            tsLbTotalImporte.Size = new Size(111, 29);
            tsLbTotalImporte.Text = "Total: 0,00 €";
            // 
            // tsLbStatus
            // 
            tsLbStatus.Margin = new Padding(10, 3, 0, 2);
            tsLbStatus.Name = "tsLbStatus";
            tsLbStatus.Size = new Size(0, 31);
            // 
            // tsLbNumReg
            // 
            tsLbNumReg.Name = "tsLbNumReg";
            tsLbNumReg.Size = new Size(136, 29);
            tsLbNumReg.Text = "Nº de registros:";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsLbNumReg, tsLbStatus, tsLbTotalBase, tsLbTotalCuota, tsLbTotalRetencion, tsLbTotalImporte });
            statusStrip1.Location = new Point(0, 1);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 20, 0);
            statusStrip1.Size = new Size(803, 36);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(statusStrip1);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 696);
            pnStatus.Margin = new Padding(4, 5, 4, 5);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(803, 37);
            pnStatus.TabIndex = 2;
            // 
            // lbHeadFacemi
            // 
            lbHeadFacemi.BackColor = Color.Gainsboro;
            lbHeadFacemi.Dock = DockStyle.Fill;
            lbHeadFacemi.Font = new Font("Segoe UI", 12F);
            lbHeadFacemi.Location = new Point(0, 0);
            lbHeadFacemi.Margin = new Padding(4, 0, 4, 0);
            lbHeadFacemi.Name = "lbHeadFacemi";
            lbHeadFacemi.Size = new Size(803, 70);
            lbHeadFacemi.TabIndex = 0;
            lbHeadFacemi.Text = "Facturas del proveedor seleccionado, en el año seleccionado";
            lbHeadFacemi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgFacturas
            // 
            dgFacturas.AllowUserToAddRows = false;
            dgFacturas.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightGray;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgFacturas.Dock = DockStyle.Fill;
            dgFacturas.Location = new Point(0, 73);
            dgFacturas.Margin = new Padding(4, 5, 4, 5);
            dgFacturas.MultiSelect = false;
            dgFacturas.Name = "dgFacturas";
            dgFacturas.ReadOnly = true;
            dgFacturas.RowHeadersWidth = 51;
            dgFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFacturas.Size = new Size(803, 576);
            dgFacturas.TabIndex = 0;
            dgFacturas.CellMouseDoubleClick += dgFacturas_CellMouseDoubleClick;
            // 
            // pnHeadFacemi
            // 
            pnHeadFacemi.Controls.Add(lbHeadFacemi);
            pnHeadFacemi.Dock = DockStyle.Top;
            pnHeadFacemi.Location = new Point(0, 3);
            pnHeadFacemi.Margin = new Padding(4, 5, 4, 5);
            pnHeadFacemi.Name = "pnHeadFacemi";
            pnHeadFacemi.Size = new Size(803, 70);
            pnHeadFacemi.TabIndex = 1;
            // 
            // pnGrid
            // 
            pnGrid.Controls.Add(dgFacturas);
            pnGrid.Controls.Add(pnHeadFacemi);
            pnGrid.Dock = DockStyle.Fill;
            pnGrid.Location = new Point(0, 47);
            pnGrid.Margin = new Padding(4, 5, 4, 5);
            pnGrid.Name = "pnGrid";
            pnGrid.Padding = new Padding(0, 3, 0, 0);
            pnGrid.Size = new Size(803, 649);
            pnGrid.TabIndex = 3;
            // 
            // label1
            // 
            label1.BackColor = Color.LightGray;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(396, 45);
            label1.TabIndex = 0;
            label1.Text = "Proveedores";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnHeadClientes
            // 
            pnHeadClientes.Controls.Add(label1);
            pnHeadClientes.Dock = DockStyle.Top;
            pnHeadClientes.Location = new Point(0, 0);
            pnHeadClientes.Margin = new Padding(4, 5, 4, 5);
            pnHeadClientes.Name = "pnHeadClientes";
            pnHeadClientes.Size = new Size(396, 45);
            pnHeadClientes.TabIndex = 0;
            // 
            // dgProveedores
            // 
            dgProveedores.AllowUserToAddRows = false;
            dgProveedores.AllowUserToDeleteRows = false;
            dgProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProveedores.Dock = DockStyle.Fill;
            dgProveedores.Location = new Point(0, 0);
            dgProveedores.Margin = new Padding(4, 5, 4, 5);
            dgProveedores.Name = "dgProveedores";
            dgProveedores.RowHeadersWidth = 51;
            dgProveedores.Size = new Size(396, 688);
            dgProveedores.TabIndex = 0;
            dgProveedores.SelectionChanged += dgProveedores_SelectionChanged;
            // 
            // pnClientes
            // 
            pnClientes.Controls.Add(dgProveedores);
            pnClientes.Dock = DockStyle.Fill;
            pnClientes.Location = new Point(0, 45);
            pnClientes.Margin = new Padding(4, 5, 4, 5);
            pnClientes.Name = "pnClientes";
            pnClientes.Size = new Size(396, 688);
            pnClientes.TabIndex = 1;
            // 
            // pnMenu
            // 
            pnMenu.Controls.Add(tsHerramientas);
            pnMenu.Dock = DockStyle.Top;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Margin = new Padding(4, 5, 4, 5);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(803, 47);
            pnMenu.TabIndex = 1;
            // 
            // splitContainerFacemi
            // 
            splitContainerFacemi.BorderStyle = BorderStyle.FixedSingle;
            splitContainerFacemi.Dock = DockStyle.Fill;
            splitContainerFacemi.Location = new Point(0, 0);
            splitContainerFacemi.Margin = new Padding(4, 5, 4, 5);
            splitContainerFacemi.Name = "splitContainerFacemi";
            // 
            // splitContainerFacemi.Panel1
            // 
            splitContainerFacemi.Panel1.Controls.Add(pnClientes);
            splitContainerFacemi.Panel1.Controls.Add(pnHeadClientes);
            splitContainerFacemi.Panel1MinSize = 150;
            // 
            // splitContainerFacemi.Panel2
            // 
            splitContainerFacemi.Panel2.Controls.Add(pnGrid);
            splitContainerFacemi.Panel2.Controls.Add(pnStatus);
            splitContainerFacemi.Panel2.Controls.Add(pnMenu);
            splitContainerFacemi.Panel2MinSize = 250;
            splitContainerFacemi.Size = new Size(1209, 735);
            splitContainerFacemi.SplitterDistance = 398;
            splitContainerFacemi.SplitterWidth = 6;
            splitContainerFacemi.TabIndex = 1;
            // 
            // tsLbTotalBase
            // 
            tsLbTotalBase.Name = "tsLbTotalBase";
            tsLbTotalBase.Size = new Size(179, 29);
            tsLbTotalBase.Text = "toolStripStatusLabel1";
            // 
            // tsLbTotalCuota
            // 
            tsLbTotalCuota.Name = "tsLbTotalCuota";
            tsLbTotalCuota.Size = new Size(179, 29);
            tsLbTotalCuota.Text = "toolStripStatusLabel1";
            // 
            // tsLbTotalRetencion
            // 
            tsLbTotalRetencion.Name = "tsLbTotalRetencion";
            tsLbTotalRetencion.Size = new Size(179, 29);
            tsLbTotalRetencion.Text = "toolStripStatusLabel1";
            // 
            // FrmBrowFacrec
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 735);
            Controls.Add(splitContainerFacemi);
            Name = "FrmBrowFacrec";
            Text = "Facturas Recibidas";
            Load += FrmBrowFacrec_Load;
            Shown += FrmBrowFacrec_Shown;
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgFacturas).EndInit();
            pnHeadFacemi.ResumeLayout(false);
            pnGrid.ResumeLayout(false);
            pnHeadClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgProveedores).EndInit();
            pnClientes.ResumeLayout(false);
            pnMenu.ResumeLayout(false);
            pnMenu.PerformLayout();
            splitContainerFacemi.Panel1.ResumeLayout(false);
            splitContainerFacemi.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerFacemi).EndInit();
            splitContainerFacemi.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ToolStripComboBox tsComboYear;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsBtnExportXML;
        private ToolStripButton tsBtnExportCSV;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsBtnLast;
        private ToolStripButton tsBtnNext;
        private ToolStripButton tsBtnPrev;
        private ToolStripButton tsBtnFirst;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsBtnDelete;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsBtnEdit;
        private ToolStripButton tsBtnNew;
        private ToolStripLabel toolStripLabel1;
        private ToolStrip tsHerramientas;
        private ToolStripStatusLabel tsLbTotalImporte;
        private ToolStripStatusLabel tsLbStatus;
        private ToolStripStatusLabel tsLbNumReg;
        private StatusStrip statusStrip1;
        private Panel pnStatus;
        private Label lbHeadFacemi;
        private DataGridView dgFacturas;
        private Panel pnHeadFacemi;
        private Panel pnGrid;
        private Label label1;
        private Panel pnHeadClientes;
        private DataGridView dgProveedores;
        private Panel pnClientes;
        private Panel pnMenu;
        private SplitContainer splitContainerFacemi;
        private ToolStripStatusLabel tsLbTotalBase;
        private ToolStripStatusLabel tsLbTotalCuota;
        private ToolStripStatusLabel tsLbTotalRetencion;
    }
}