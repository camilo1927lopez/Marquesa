namespace MarquesaReplenish.View
{
    partial class FrmCargarArchivo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCargarArchivo));
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.usrSeleccionarBibliaUnificada = new WinFormsControlLibrary.usrSeleccionarArchivo();
            this.txtNombreCargue = new System.Windows.Forms.TextBox();
            this.lblNombreCargue = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(193, 12);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(279, 21);
            this.cbxCLientes.TabIndex = 0;
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(14, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 1;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // usrSeleccionarBibliaUnificada
            // 
            this.usrSeleccionarBibliaUnificada.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usrSeleccionarBibliaUnificada.ArchivoSeleccionado = "";
            this.usrSeleccionarBibliaUnificada.ColorBoton = System.Drawing.SystemColors.ActiveCaption;
            this.usrSeleccionarBibliaUnificada.ColorTextoBoton = System.Drawing.Color.Black;
            this.usrSeleccionarBibliaUnificada.FiltroExtensionPermitida = "archivos de txt|*.txt|archivos de csv|*.csv";
            this.usrSeleccionarBibliaUnificada.InitialDirectory = null;
            this.usrSeleccionarBibliaUnificada.IsEnabled = true;
            this.usrSeleccionarBibliaUnificada.Location = new System.Drawing.Point(8, 52);
            this.usrSeleccionarBibliaUnificada.Name = "usrSeleccionarBibliaUnificada";
            this.usrSeleccionarBibliaUnificada.Size = new System.Drawing.Size(464, 34);
            this.usrSeleccionarBibliaUnificada.TabIndex = 2;
            this.usrSeleccionarBibliaUnificada.Titulo = "Cargar archivo de biblia unificada: ";
            // 
            // txtNombreCargue
            // 
            this.txtNombreCargue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNombreCargue.Location = new System.Drawing.Point(193, 108);
            this.txtNombreCargue.Name = "txtNombreCargue";
            this.txtNombreCargue.Size = new System.Drawing.Size(279, 20);
            this.txtNombreCargue.TabIndex = 4;
            // 
            // lblNombreCargue
            // 
            this.lblNombreCargue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNombreCargue.AutoSize = true;
            this.lblNombreCargue.Location = new System.Drawing.Point(14, 111);
            this.lblNombreCargue.Name = "lblNombreCargue";
            this.lblNombreCargue.Size = new System.Drawing.Size(104, 13);
            this.lblNombreCargue.TabIndex = 5;
            this.lblNombreCargue.Text = "Nombre del Cargue: ";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnGuardar.BackColor = System.Drawing.Color.Black;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.Location = new System.Drawing.Point(162, 152);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(150, 30);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Cargar Archivo";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCargarArchivo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(484, 201);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblNombreCargue);
            this.Controls.Add(this.txtNombreCargue);
            this.Controls.Add(this.usrSeleccionarBibliaUnificada);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbxCLientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCargarArchivo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCargarArchivo";
            this.Load += new System.EventHandler(this.FrmCargarArchivo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxCLientes;
        private System.Windows.Forms.Label lblCliente;
        private WinFormsControlLibrary.usrSeleccionarArchivo usrSeleccionarBibliaUnificada;
        private System.Windows.Forms.TextBox txtNombreCargue;
        private System.Windows.Forms.Label lblNombreCargue;
        private System.Windows.Forms.Button btnGuardar;
    }
}