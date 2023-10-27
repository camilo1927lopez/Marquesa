namespace MarquesaReplenish.View
{
    partial class FrmCreacionCiclo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreacionCiclo));
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.lblNombreCondor = new System.Windows.Forms.Label();
            this.txtNombreCondor = new System.Windows.Forms.TextBox();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.usrSeleccionarCargueCiclo = new WinFormsControlLibrary.usrSeleccionarArchivo();
            this.btnGuardarCiclo = new System.Windows.Forms.Button();
            this.lblCiclo = new System.Windows.Forms.Label();
            this.usrCiclo = new WinFormsControlLibrary.usrNumeric();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(6, 42);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(185, 39);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(279, 21);
            this.cbxCLientes.TabIndex = 2;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // lblNombreCondor
            // 
            this.lblNombreCondor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreCondor.Location = new System.Drawing.Point(6, 194);
            this.lblNombreCondor.Name = "lblNombreCondor";
            this.lblNombreCondor.Size = new System.Drawing.Size(173, 27);
            this.lblNombreCondor.TabIndex = 7;
            this.lblNombreCondor.Text = "Nombre pruebas como se creo en condor:";
            this.lblNombreCondor.Click += new System.EventHandler(this.lblNombreCondor_Click);
            // 
            // txtNombreCondor
            // 
            this.txtNombreCondor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombreCondor.Location = new System.Drawing.Point(185, 197);
            this.txtNombreCondor.Name = "txtNombreCondor";
            this.txtNombreCondor.Size = new System.Drawing.Size(279, 20);
            this.txtNombreCondor.TabIndex = 6;
            this.txtNombreCondor.TextChanged += new System.EventHandler(this.txtNombreCondor_TextChanged);
            // 
            // lblSeleccionarPruebas
            // 
            this.lblSeleccionarPruebas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSeleccionarPruebas.AutoSize = true;
            this.lblSeleccionarPruebas.Location = new System.Drawing.Point(6, 81);
            this.lblSeleccionarPruebas.Name = "lblSeleccionarPruebas";
            this.lblSeleccionarPruebas.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccionarPruebas.TabIndex = 9;
            this.lblSeleccionarPruebas.Text = "Seleccionar Pruebas: ";
            // 
            // cbxSeleccionarPruebas
            // 
            this.cbxSeleccionarPruebas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxSeleccionarPruebas.FormattingEnabled = true;
            this.cbxSeleccionarPruebas.Location = new System.Drawing.Point(185, 78);
            this.cbxSeleccionarPruebas.Name = "cbxSeleccionarPruebas";
            this.cbxSeleccionarPruebas.Size = new System.Drawing.Size(279, 21);
            this.cbxSeleccionarPruebas.TabIndex = 8;
            this.cbxSeleccionarPruebas.SelectionChangeCommitted += new System.EventHandler(this.cbxSeleccionarPruebas_SelectionChangeCommitted);
            // 
            // usrSeleccionarCargueCiclo
            // 
            this.usrSeleccionarCargueCiclo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usrSeleccionarCargueCiclo.ArchivoSeleccionado = "";
            this.usrSeleccionarCargueCiclo.ColorBoton = System.Drawing.SystemColors.ActiveCaption;
            this.usrSeleccionarCargueCiclo.ColorTextoBoton = System.Drawing.Color.Black;
            this.usrSeleccionarCargueCiclo.FiltroExtensionPermitida = "archivos de txt|*.txt";
            this.usrSeleccionarCargueCiclo.InitialDirectory = null;
            this.usrSeleccionarCargueCiclo.IsEnabled = true;
            this.usrSeleccionarCargueCiclo.Location = new System.Drawing.Point(9, 149);
            this.usrSeleccionarCargueCiclo.Name = "usrSeleccionarCargueCiclo";
            this.usrSeleccionarCargueCiclo.Size = new System.Drawing.Size(464, 34);
            this.usrSeleccionarCargueCiclo.TabIndex = 10;
            this.usrSeleccionarCargueCiclo.Titulo = "Cargue archivo ciclo partes :          ";
            // 
            // btnGuardarCiclo
            // 
            this.btnGuardarCiclo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardarCiclo.BackColor = System.Drawing.Color.Black;
            this.btnGuardarCiclo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCiclo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardarCiclo.Location = new System.Drawing.Point(169, 252);
            this.btnGuardarCiclo.Name = "btnGuardarCiclo";
            this.btnGuardarCiclo.Size = new System.Drawing.Size(150, 30);
            this.btnGuardarCiclo.TabIndex = 20;
            this.btnGuardarCiclo.Text = "Guardar Ciclos";
            this.btnGuardarCiclo.UseVisualStyleBackColor = false;
            this.btnGuardarCiclo.Click += new System.EventHandler(this.btnGuardarCiclo_Click);
            // 
            // lblCiclo
            // 
            this.lblCiclo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(6, 117);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(36, 13);
            this.lblCiclo.TabIndex = 22;
            this.lblCiclo.Text = "Ciclo: ";
            // 
            // usrCiclo
            // 
            this.usrCiclo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usrCiclo.DefaultValue = 0F;
            this.usrCiclo.IsEnabled = true;
            this.usrCiclo.Location = new System.Drawing.Point(185, 117);
            this.usrCiclo.Mascara = "#,##0";
            this.usrCiclo.MaxLength = 32767;
            this.usrCiclo.Name = "usrCiclo";
            this.usrCiclo.PermiteDecimales = false;
            this.usrCiclo.ShortcutsEnabled = true;
            this.usrCiclo.Size = new System.Drawing.Size(279, 20);
            this.usrCiclo.TabIndex = 23;
            this.usrCiclo.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // FrmCreacionCiclo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 294);
            this.Controls.Add(this.usrCiclo);
            this.Controls.Add(this.lblCiclo);
            this.Controls.Add(this.btnGuardarCiclo);
            this.Controls.Add(this.usrSeleccionarCargueCiclo);
            this.Controls.Add(this.lblSeleccionarPruebas);
            this.Controls.Add(this.cbxSeleccionarPruebas);
            this.Controls.Add(this.lblNombreCondor);
            this.Controls.Add(this.txtNombreCondor);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbxCLientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCreacionCiclo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Creación Ciclo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCLientes;
        private System.Windows.Forms.Label lblNombreCondor;
        private System.Windows.Forms.TextBox txtNombreCondor;
        private System.Windows.Forms.Label lblSeleccionarPruebas;
        private System.Windows.Forms.ComboBox cbxSeleccionarPruebas;
        private WinFormsControlLibrary.usrSeleccionarArchivo usrSeleccionarCargueCiclo;
        private System.Windows.Forms.Button btnGuardarCiclo;
        private System.Windows.Forms.Label lblCiclo;
        private WinFormsControlLibrary.usrNumeric usrCiclo;
    }
}