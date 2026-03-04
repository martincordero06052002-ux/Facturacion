namespace FacturacionDAM.Formularios
{
    partial class FrmBrowFacemi
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBrowFacemi));
            splitContainerFacemi = new SplitContainer();
            pnClientes = new Panel();
            dgClientes = new DataGridView();
            pnHeadClientes = new Panel();
            label1 = new Label();
            pnGrid = new Panel();
            dgFacturas = new DataGridView();
            pnHeadFacemi = new Panel();
            lbHeadFacemi = new Label();
            pnStatus = new Panel();
            statusStrip1 = new StatusStrip();
            tsLbNumReg = new ToolStripStatusLabel();
            tsLbStatus = new ToolStripStatusLabel();
            tsLbTotalImporte = new ToolStripStatusLabel();
            pnMenu = new Panel();
            tsHerramientas = new ToolStrip();
            tsBtnNew = new ToolStripButton();
            tsBtnEdit = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsBtnDelete = new ToolStripButton();
            toolStripSeparator2 = new ToolStripSeparator();
            tsBtnFirst = new ToolStripButton();
            tsBtnPrev = new ToolStripButton();
            tsBtnNext = new ToolStripButton();
            tsBtnLast = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            tsBtnExportCSV = new ToolStripButton();
            tsBtnExportXML = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tsBtnInformes = new ToolStripDropDownButton();
            tsMnInfFechas = new ToolStripMenuItem();
            tsMnInfClientes = new ToolStripMenuItem();
            tsMnInfFacSinRet = new ToolStripMenuItem();
            tsMnInfFacConRet = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            tsComboYear = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainerFacemi).BeginInit();
            splitContainerFacemi.Panel1.SuspendLayout();
            splitContainerFacemi.Panel2.SuspendLayout();
            splitContainerFacemi.SuspendLayout();
            pnClientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgClientes).BeginInit();
            pnHeadClientes.SuspendLayout();
            pnGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgFacturas).BeginInit();
            pnHeadFacemi.SuspendLayout();
            pnStatus.SuspendLayout();
            statusStrip1.SuspendLayout();
            pnMenu.SuspendLayout();
            tsHerramientas.SuspendLayout();
            SuspendLayout();
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
            splitContainerFacemi.SplitterDistance = 400;
            splitContainerFacemi.SplitterWidth = 6;
            splitContainerFacemi.TabIndex = 0;
            // 
            // pnClientes
            // 
            pnClientes.Controls.Add(dgClientes);
            pnClientes.Dock = DockStyle.Fill;
            pnClientes.Location = new Point(0, 45);
            pnClientes.Margin = new Padding(4, 5, 4, 5);
            pnClientes.Name = "pnClientes";
            pnClientes.Size = new Size(398, 688);
            pnClientes.TabIndex = 1;
            // 
            // dgClientes
            // 
            dgClientes.AllowUserToAddRows = false;
            dgClientes.AllowUserToDeleteRows = false;
            dgClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgClientes.Dock = DockStyle.Fill;
            dgClientes.Location = new Point(0, 0);
            dgClientes.Margin = new Padding(4, 5, 4, 5);
            dgClientes.Name = "dgClientes";
            dgClientes.RowHeadersWidth = 51;
            dgClientes.Size = new Size(398, 688);
            dgClientes.TabIndex = 0;
            dgClientes.SelectionChanged += dgClientes_SelectionChanged;
            // 
            // pnHeadClientes
            // 
            pnHeadClientes.Controls.Add(label1);
            pnHeadClientes.Dock = DockStyle.Top;
            pnHeadClientes.Location = new Point(0, 0);
            pnHeadClientes.Margin = new Padding(4, 5, 4, 5);
            pnHeadClientes.Name = "pnHeadClientes";
            pnHeadClientes.Size = new Size(398, 45);
            pnHeadClientes.TabIndex = 0;
            // 
            // label1
            // 
            label1.BackColor = Color.LightGray;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(398, 45);
            label1.TabIndex = 0;
            label1.Text = "Clientes";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            pnGrid.Size = new Size(801, 649);
            pnGrid.TabIndex = 3;
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
            dgFacturas.Size = new Size(801, 576);
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
            pnHeadFacemi.Size = new Size(801, 70);
            pnHeadFacemi.TabIndex = 1;
            // 
            // lbHeadFacemi
            // 
            lbHeadFacemi.BackColor = Color.Gainsboro;
            lbHeadFacemi.Dock = DockStyle.Fill;
            lbHeadFacemi.Font = new Font("Segoe UI", 12F);
            lbHeadFacemi.Location = new Point(0, 0);
            lbHeadFacemi.Margin = new Padding(4, 0, 4, 0);
            lbHeadFacemi.Name = "lbHeadFacemi";
            lbHeadFacemi.Size = new Size(801, 70);
            lbHeadFacemi.TabIndex = 0;
            lbHeadFacemi.Text = "Facturas del cliente seleccionado, en el año seleccionado";
            lbHeadFacemi.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnStatus
            // 
            pnStatus.Controls.Add(statusStrip1);
            pnStatus.Dock = DockStyle.Bottom;
            pnStatus.Location = new Point(0, 696);
            pnStatus.Margin = new Padding(4, 5, 4, 5);
            pnStatus.Name = "pnStatus";
            pnStatus.Size = new Size(801, 37);
            pnStatus.TabIndex = 2;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsLbNumReg, tsLbStatus, tsLbTotalImporte });
            statusStrip1.Location = new Point(0, 1);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 20, 0);
            statusStrip1.Size = new Size(801, 36);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // tsLbNumReg
            // 
            tsLbNumReg.Name = "tsLbNumReg";
            tsLbNumReg.Size = new Size(136, 29);
            tsLbNumReg.Text = "Nº de registros:";
            // 
            // tsLbStatus
            // 
            tsLbStatus.Margin = new Padding(10, 3, 0, 2);
            tsLbStatus.Name = "tsLbStatus";
            tsLbStatus.Size = new Size(0, 31);
            // 
            // tsLbTotalImporte
            // 
            tsLbTotalImporte.BorderSides = ToolStripStatusLabelBorderSides.Left;
            tsLbTotalImporte.Name = "tsLbTotalImporte";
            tsLbTotalImporte.Size = new Size(111, 29);
            tsLbTotalImporte.Text = "Total: 0,00 €";
            // 
            // pnMenu
            // 
            pnMenu.Controls.Add(tsHerramientas);
            pnMenu.Dock = DockStyle.Top;
            pnMenu.Location = new Point(0, 0);
            pnMenu.Margin = new Padding(4, 5, 4, 5);
            pnMenu.Name = "pnMenu";
            pnMenu.Size = new Size(801, 47);
            pnMenu.TabIndex = 1;
            // 
            // tsHerramientas
            // 
            tsHerramientas.ImageScalingSize = new Size(20, 20);
            tsHerramientas.Items.AddRange(new ToolStripItem[] { tsBtnNew, tsBtnEdit, toolStripSeparator1, tsBtnDelete, toolStripSeparator2, tsBtnFirst, tsBtnPrev, tsBtnNext, tsBtnLast, toolStripSeparator3, tsBtnExportCSV, tsBtnExportXML, toolStripSeparator4, tsBtnInformes, toolStripButton1, toolStripSeparator5, toolStripLabel1, tsComboYear });
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Padding = new Padding(0, 0, 3, 0);
            tsHerramientas.Size = new Size(801, 33);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "toolStrip1";
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
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 33);
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
            // toolStripSeparator2
            // 
            toolStripSeparator2.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 33);
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
            // toolStripSeparator3
            // 
            toolStripSeparator3.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 33);
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
            // toolStripSeparator4
            // 
            toolStripSeparator4.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 33);
            // 
            // tsBtnInformes
            // 
            tsBtnInformes.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsBtnInformes.DropDownItems.AddRange(new ToolStripItem[] { tsMnInfFechas, tsMnInfClientes, tsMnInfFacSinRet, tsMnInfFacConRet });
            tsBtnInformes.Image = (Image)resources.GetObject("tsBtnInformes.Image");
            tsBtnInformes.ImageTransparentColor = Color.Magenta;
            tsBtnInformes.Name = "tsBtnInformes";
            tsBtnInformes.Size = new Size(38, 28);
            tsBtnInformes.Text = "toolStripButton1";
            tsBtnInformes.ToolTipText = "Generar Informe";
            // 
            // tsMnInfFechas
            // 
            tsMnInfFechas.Name = "tsMnInfFechas";
            tsMnInfFechas.Size = new Size(400, 34);
            tsMnInfFechas.Text = "Listado entre fechas (Acumulado)";
            tsMnInfFechas.Click += tsMnInfFechas_Click;
            // 
            // tsMnInfClientes
            // 
            tsMnInfClientes.Name = "tsMnInfClientes";
            tsMnInfClientes.Size = new Size(400, 34);
            tsMnInfClientes.Text = "Listado entre fechas (Por Clientes)";
            tsMnInfClientes.Click += tsMnInfClientes_Click;
            // 
            // tsMnInfFacSinRet
            // 
            tsMnInfFacSinRet.Name = "tsMnInfFacSinRet";
            tsMnInfFacSinRet.Size = new Size(400, 34);
            tsMnInfFacSinRet.Text = "Factura seleccionada (Sin retención)";
            tsMnInfFacSinRet.Click += tsMnInfFacSinRet_Click;
            // 
            // tsMnInfFacConRet
            // 
            tsMnInfFacConRet.Name = "tsMnInfFacConRet";
            tsMnInfFacConRet.Size = new Size(400, 34);
            tsMnInfFacConRet.Text = "Factura seleccionada (Con retención)";
            tsMnInfFacConRet.Click += tsMnInfFacConRet_Click;
            // 
            // toolStripButton1
            // 
            toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton1.Image = (Image)resources.GetObject("toolStripButton1.Image");
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(34, 28);
            toolStripButton1.Text = "tsBtnDiseno";
            toolStripButton1.Click += toolStripButton1_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Margin = new Padding(5, 0, 5, 0);
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 33);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(54, 28);
            toolStripLabel1.Text = "Año: ";
            // 
            // tsComboYear
            // 
            tsComboYear.BackColor = Color.Azure;
            tsComboYear.DropDownStyle = ComboBoxStyle.DropDownList;
            tsComboYear.Name = "tsComboYear";
            tsComboYear.Size = new Size(75, 33);
            tsComboYear.SelectedIndexChanged += tsComboYear_SelectedIndexChanged;
            // 
            // FrmBrowFacemi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 735);
            Controls.Add(splitContainerFacemi);
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmBrowFacemi";
            Text = "Facturas Emitidas";
            FormClosing += FrmBrowFacemi_FormClosing;
            Load += FrmBrowFacemi_Load;
            Shown += FrmBrowFacemi_Shown;
            splitContainerFacemi.Panel1.ResumeLayout(false);
            splitContainerFacemi.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerFacemi).EndInit();
            splitContainerFacemi.ResumeLayout(false);
            pnClientes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgClientes).EndInit();
            pnHeadClientes.ResumeLayout(false);
            pnGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgFacturas).EndInit();
            pnHeadFacemi.ResumeLayout(false);
            pnStatus.ResumeLayout(false);
            pnStatus.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            pnMenu.ResumeLayout(false);
            pnMenu.PerformLayout();
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainerFacemi;
        private Panel pnHeadClientes;
        private Label label1;
        private Panel pnMenu;
        private ToolStrip tsHerramientas;
        private ToolStripButton tsBtnNew;
        private ToolStripButton tsBtnEdit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsBtnDelete;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton tsBtnFirst;
        private ToolStripButton tsBtnPrev;
        private ToolStripButton tsBtnNext;
        private ToolStripButton tsBtnLast;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton tsBtnExportCSV;
        private ToolStripButton tsBtnExportXML;
        private Panel pnStatus;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsLbNumReg;
        private ToolStripStatusLabel tsLbStatus;
        private Panel pnGrid;
        private DataGridView dgFacturas;
        private Panel pnClientes;
        private DataGridView dgClientes;
        private ToolStripSeparator toolStripSeparator4;
        private Panel pnHeadFacemi;
        private Label lbHeadFacemi;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox tsComboYear;
        private ToolStripStatusLabel tsLbTotalImporte;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripDropDownButton tsBtnInformes;
        private ToolStripMenuItem tsMnInfFechas;
        private ToolStripMenuItem tsMnInfClientes;
        private ToolStripMenuItem tsMnInfFacSinRet;
        private ToolStripMenuItem tsMnInfFacConRet;
        private ToolStripButton toolStripButton1;
    }
}