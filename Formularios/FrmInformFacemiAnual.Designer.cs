namespace FacturacionDAM.Formularios
{
    partial class FrmInformFacemiAnual
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
            fechaInit = new DateTimePicker();
            fechaFin = new DateTimePicker();
            btnInforme = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // fechaInit
            // 
            fechaInit.Format = DateTimePickerFormat.Short;
            fechaInit.Location = new Point(63, 81);
            fechaInit.Margin = new Padding(4, 5, 4, 5);
            fechaInit.Name = "fechaInit";
            fechaInit.Size = new Size(160, 31);
            fechaInit.TabIndex = 0;
            // 
            // fechaFin
            // 
            fechaFin.Format = DateTimePickerFormat.Short;
            fechaFin.Location = new Point(290, 81);
            fechaFin.Margin = new Padding(4, 5, 4, 5);
            fechaFin.Name = "fechaFin";
            fechaFin.Size = new Size(174, 31);
            fechaFin.TabIndex = 1;
            // 
            // btnInforme
            // 
            btnInforme.DialogResult = DialogResult.OK;
            btnInforme.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInforme.Location = new Point(63, 164);
            btnInforme.Margin = new Padding(4, 5, 4, 5);
            btnInforme.Name = "btnInforme";
            btnInforme.Size = new Size(401, 88);
            btnInforme.TabIndex = 2;
            btnInforme.Text = "Generar Informe";
            btnInforme.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 38);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(104, 25);
            label1.TabIndex = 3;
            label1.Text = "Fecha Inicio";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(290, 38);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 4;
            label2.Text = "Fecha Fin";
            // 
            // FrmInformFacemiAnual
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(541, 306);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnInforme);
            Controls.Add(fechaFin);
            Controls.Add(fechaInit);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmInformFacemiAnual";
            Text = "Facturas emitidas entre fechas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnInforme;
        private Label label1;
        private Label label2;
        public DateTimePicker fechaInit;
        public DateTimePicker fechaFin;
    }
}