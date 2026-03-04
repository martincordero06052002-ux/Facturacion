namespace FacturacionDAM.Formularios
{
    partial class FrmLineaFacrec
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLineaFacrec));
            BtnProducto = new Button();
            label1 = new Label();
            label7 = new Label();
            gbProducto = new GroupBox();
            cbProducto = new ComboBox();
            label6 = new Label();
            gbCalculo = new GroupBox();
            numCantidad = new NumericUpDown();
            label4 = new Label();
            numTipoIva = new NumericUpDown();
            label5 = new Label();
            label10 = new Label();
            numPrecio = new NumericUpDown();
            txtDescripcion = new TextBox();
            label2 = new Label();
            label3 = new Label();
            lbBase = new Label();
            label17 = new Label();
            pnBtns = new Panel();
            btnCancelar = new Button();
            btnAceptar = new Button();
            pnData = new Panel();
            panel1 = new Panel();
            lbTotal = new Label();
            label12 = new Label();
            lbCuota = new Label();
            label11 = new Label();
            gbProducto.SuspendLayout();
            gbCalculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTipoIva).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).BeginInit();
            pnBtns.SuspendLayout();
            pnData.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnProducto
            // 
            BtnProducto.Image = (Image)resources.GetObject("BtnProducto.Image");
            BtnProducto.ImageAlign = ContentAlignment.MiddleLeft;
            BtnProducto.Location = new Point(661, 87);
            BtnProducto.Margin = new Padding(4, 3, 4, 3);
            BtnProducto.Name = "BtnProducto";
            BtnProducto.Padding = new Padding(20, 0, 14, 0);
            BtnProducto.Size = new Size(170, 53);
            BtnProducto.TabIndex = 9;
            BtnProducto.Text = "Trasladar";
            BtnProducto.TextAlign = ContentAlignment.MiddleRight;
            BtnProducto.UseVisualStyleBackColor = true;
            BtnProducto.Click += BtnProducto_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 50);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(777, 25);
            label1.TabIndex = 8;
            label1.Text = "Selecciona un producto para trasladar su precio y tipo de IVA a los cálculos de la línea de factura.";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Location = new Point(60, 93);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(97, 38);
            label7.TabIndex = 0;
            label7.Text = "Producto:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbProducto
            // 
            gbProducto.Controls.Add(BtnProducto);
            gbProducto.Controls.Add(label1);
            gbProducto.Controls.Add(cbProducto);
            gbProducto.Controls.Add(label7);
            gbProducto.Location = new Point(29, 23);
            gbProducto.Margin = new Padding(4, 5, 4, 5);
            gbProducto.Name = "gbProducto";
            gbProducto.Padding = new Padding(4, 5, 4, 5);
            gbProducto.Size = new Size(927, 158);
            gbProducto.TabIndex = 5;
            gbProducto.TabStop = false;
            gbProducto.Text = "Producto (opcional)";
            // 
            // cbProducto
            // 
            cbProducto.FormattingEnabled = true;
            cbProducto.Location = new Point(166, 97);
            cbProducto.Margin = new Padding(4, 5, 4, 5);
            cbProducto.Name = "cbProducto";
            cbProducto.Size = new Size(475, 33);
            cbProducto.TabIndex = 7;
            // 
            // label6
            // 
            label6.Location = new Point(293, 107);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(93, 38);
            label6.TabIndex = 34;
            label6.Text = "(sin IVA)";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gbCalculo
            // 
            gbCalculo.Controls.Add(label6);
            gbCalculo.Controls.Add(numCantidad);
            gbCalculo.Controls.Add(label4);
            gbCalculo.Controls.Add(numTipoIva);
            gbCalculo.Controls.Add(label5);
            gbCalculo.Controls.Add(label10);
            gbCalculo.Controls.Add(numPrecio);
            gbCalculo.Controls.Add(txtDescripcion);
            gbCalculo.Controls.Add(label2);
            gbCalculo.Controls.Add(label3);
            gbCalculo.Location = new Point(29, 200);
            gbCalculo.Margin = new Padding(4, 3, 4, 3);
            gbCalculo.Name = "gbCalculo";
            gbCalculo.Padding = new Padding(4, 3, 4, 3);
            gbCalculo.Size = new Size(927, 167);
            gbCalculo.TabIndex = 18;
            gbCalculo.TabStop = false;
            gbCalculo.Text = "Cálculo de la Linea de Factura";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(749, 108);
            numCantidad.Margin = new Padding(4, 3, 4, 3);
            numCantidad.Maximum = new decimal(new int[] { 9999, 0, 0, 131072 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(134, 31);
            numCantidad.TabIndex = 33;
            numCantidad.TextAlign = HorizontalAlignment.Right;
            // 
            // label4
            // 
            label4.Location = new Point(641, 107);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(109, 38);
            label4.TabIndex = 32;
            label4.Text = "Unidades:";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numTipoIva
            // 
            numTipoIva.DecimalPlaces = 2;
            numTipoIva.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numTipoIva.Location = new Point(497, 108);
            numTipoIva.Margin = new Padding(4, 3, 4, 3);
            numTipoIva.Maximum = new decimal(new int[] { 9999, 0, 0, 131072 });
            numTipoIva.Name = "numTipoIva";
            numTipoIva.Size = new Size(91, 31);
            numTipoIva.TabIndex = 31;
            numTipoIva.TextAlign = HorizontalAlignment.Right;
            // 
            // label5
            // 
            label5.Location = new Point(591, 107);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(36, 38);
            label5.TabIndex = 30;
            label5.Text = "%";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.Location = new Point(376, 107);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(123, 38);
            label10.TabIndex = 28;
            label10.Text = "Tipo de IVA:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // numPrecio
            // 
            numPrecio.DecimalPlaces = 2;
            numPrecio.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numPrecio.Location = new Point(154, 108);
            numPrecio.Margin = new Padding(4, 3, 4, 3);
            numPrecio.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numPrecio.Name = "numPrecio";
            numPrecio.Size = new Size(136, 31);
            numPrecio.TabIndex = 27;
            numPrecio.TextAlign = HorizontalAlignment.Right;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(154, 55);
            txtDescripcion.Margin = new Padding(4, 5, 4, 5);
            txtDescripcion.MaxLength = 255;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(728, 31);
            txtDescripcion.TabIndex = 26;
            // 
            // label2
            // 
            label2.Location = new Point(7, 107);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(144, 38);
            label2.TabIndex = 24;
            label2.Text = "Precio/Unidad:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            label3.Location = new Point(29, 55);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(123, 38);
            label3.TabIndex = 25;
            label3.Text = "Descripción:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbBase
            // 
            lbBase.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbBase.ForeColor = Color.Black;
            lbBase.Location = new Point(224, 20);
            lbBase.Margin = new Padding(4, 0, 4, 0);
            lbBase.Name = "lbBase";
            lbBase.Size = new Size(124, 38);
            lbBase.TabIndex = 14;
            lbBase.Text = "10,00 €";
            lbBase.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.Location = new Point(141, 20);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(80, 38);
            label17.TabIndex = 13;
            label17.Text = "Base:";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnBtns
            // 
            pnBtns.Controls.Add(btnCancelar);
            pnBtns.Controls.Add(btnAceptar);
            pnBtns.Dock = DockStyle.Bottom;
            pnBtns.Location = new Point(0, 502);
            pnBtns.Margin = new Padding(4, 5, 4, 5);
            pnBtns.Name = "pnBtns";
            pnBtns.Size = new Size(990, 105);
            pnBtns.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = (Image)resources.GetObject("btnCancelar.Image");
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(573, 23);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Padding = new Padding(14, 0, 14, 0);
            btnCancelar.Size = new Size(143, 60);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleRight;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Image = (Image)resources.GetObject("btnAceptar.Image");
            btnAceptar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAceptar.Location = new Point(283, 23);
            btnAceptar.Margin = new Padding(4, 5, 4, 5);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Padding = new Padding(14, 0, 14, 0);
            btnAceptar.Size = new Size(143, 60);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.TextAlign = ContentAlignment.MiddleRight;
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // pnData
            // 
            pnData.Controls.Add(panel1);
            pnData.Controls.Add(gbCalculo);
            pnData.Controls.Add(gbProducto);
            pnData.Dock = DockStyle.Fill;
            pnData.Location = new Point(0, 0);
            pnData.Margin = new Padding(4, 5, 4, 5);
            pnData.Name = "pnData";
            pnData.Size = new Size(990, 607);
            pnData.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.AntiqueWhite;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(lbTotal);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(lbCuota);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(lbBase);
            panel1.Controls.Add(label17);
            panel1.Location = new Point(29, 388);
            panel1.Margin = new Padding(4, 3, 4, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(928, 79);
            panel1.TabIndex = 36;
            // 
            // lbTotal
            // 
            lbTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbTotal.ForeColor = Color.Black;
            lbTotal.Location = new Point(644, 20);
            lbTotal.Margin = new Padding(4, 0, 4, 0);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(124, 38);
            lbTotal.TabIndex = 18;
            lbTotal.Text = "10,00 €";
            lbTotal.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Location = new Point(561, 20);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(80, 38);
            label12.TabIndex = 17;
            label12.Text = "Total:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lbCuota
            // 
            lbCuota.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lbCuota.ForeColor = Color.Black;
            lbCuota.Location = new Point(440, 20);
            lbCuota.Margin = new Padding(4, 0, 4, 0);
            lbCuota.Name = "lbCuota";
            lbCuota.Size = new Size(124, 38);
            lbCuota.TabIndex = 16;
            lbCuota.Text = "10,00 €";
            lbCuota.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.Location = new Point(360, 20);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(80, 38);
            label11.TabIndex = 15;
            label11.Text = "Cuota:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FrmLineaFacrec
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(990, 607);
            Controls.Add(pnBtns);
            Controls.Add(pnData);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmLineaFacrec";
            Text = "Linea de Factura Recibida";
            Load += FrmLineaFacrec_Load;
            gbProducto.ResumeLayout(false);
            gbProducto.PerformLayout();
            gbCalculo.ResumeLayout(false);
            gbCalculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTipoIva).EndInit();
            ((System.ComponentModel.ISupportInitialize)numPrecio).EndInit();
            pnBtns.ResumeLayout(false);
            pnData.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button BtnProducto;
        private Label label1;
        private Label label7;
        private GroupBox gbProducto;
        private ComboBox cbProducto;
        private Label label6;
        private GroupBox gbCalculo;
        private NumericUpDown numCantidad;
        private Label label4;
        private NumericUpDown numTipoIva;
        private Label label5;
        private Label label10;
        private NumericUpDown numPrecio;
        private TextBox txtDescripcion;
        private Label label2;
        private Label label3;
        private Label lbBase;
        private Label label17;
        private Panel pnBtns;
        private Button btnCancelar;
        private Button btnAceptar;
        private Panel pnData;
        private Panel panel1;
        private Label lbTotal;
        private Label label12;
        private Label lbCuota;
        private Label label11;
    }
}