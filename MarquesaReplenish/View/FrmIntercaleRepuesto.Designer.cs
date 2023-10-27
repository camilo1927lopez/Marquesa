namespace MarquesaReplenish.View
{
    partial class FrmIntercaleRepuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIntercaleRepuesto));
            this.lblCiclo = new System.Windows.Forms.Label();
            this.cbxCiclos = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.dgvIntercaleRepuesto = new System.Windows.Forms.DataGridView();
            this.IdDetalleRepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConsecutivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuadernillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoHojaRespuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bloque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsecutivoIntercale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigoActa = new System.Windows.Forms.TextBox();
            this.lblCodigoActa = new System.Windows.Forms.Label();
            this.txtCodigoBarrasHojaRespuesta = new System.Windows.Forms.TextBox();
            this.lblCodigoBarrasHojaRespuesta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntercaleRepuesto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCiclo
            // 
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(297, 90);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(44, 13);
            this.lblCiclo.TabIndex = 60;
            this.lblCiclo.Text = "Ciclos : ";
            // 
            // cbxCiclos
            // 
            this.cbxCiclos.FormattingEnabled = true;
            this.cbxCiclos.Location = new System.Drawing.Point(476, 87);
            this.cbxCiclos.Name = "cbxCiclos";
            this.cbxCiclos.Size = new System.Drawing.Size(279, 21);
            this.cbxCiclos.TabIndex = 59;
            // 
            // lblSeleccionarPruebas
            // 
            this.lblSeleccionarPruebas.AutoSize = true;
            this.lblSeleccionarPruebas.Location = new System.Drawing.Point(297, 54);
            this.lblSeleccionarPruebas.Name = "lblSeleccionarPruebas";
            this.lblSeleccionarPruebas.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccionarPruebas.TabIndex = 58;
            this.lblSeleccionarPruebas.Text = "Seleccionar Pruebas: ";
            // 
            // cbxSeleccionarPruebas
            // 
            this.cbxSeleccionarPruebas.FormattingEnabled = true;
            this.cbxSeleccionarPruebas.Location = new System.Drawing.Point(476, 51);
            this.cbxSeleccionarPruebas.Name = "cbxSeleccionarPruebas";
            this.cbxSeleccionarPruebas.Size = new System.Drawing.Size(279, 21);
            this.cbxSeleccionarPruebas.TabIndex = 57;
            this.cbxSeleccionarPruebas.SelectionChangeCommitted += new System.EventHandler(this.cbxSeleccionarPruebas_SelectionChangeCommitted);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(297, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 56;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(476, 12);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(279, 21);
            this.cbxCLientes.TabIndex = 55;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // dgvIntercaleRepuesto
            // 
            this.dgvIntercaleRepuesto.AllowUserToAddRows = false;
            this.dgvIntercaleRepuesto.AllowUserToDeleteRows = false;
            this.dgvIntercaleRepuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIntercaleRepuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntercaleRepuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDetalleRepuesto,
            this.IdConsecutivo,
            this.CodigoCuadernillo,
            this.CodigoHojaRespuesta,
            this.CodigoSitio,
            this.NombreSitio,
            this.CodigoSalon,
            this.Bloque,
            this.Estados,
            this.ConsecutivoIntercale});
            this.dgvIntercaleRepuesto.Location = new System.Drawing.Point(12, 155);
            this.dgvIntercaleRepuesto.Name = "dgvIntercaleRepuesto";
            this.dgvIntercaleRepuesto.ReadOnly = true;
            this.dgvIntercaleRepuesto.Size = new System.Drawing.Size(1031, 303);
            this.dgvIntercaleRepuesto.TabIndex = 61;
            // 
            // IdDetalleRepuesto
            // 
            this.IdDetalleRepuesto.HeaderText = "IdDetalleRepuesto";
            this.IdDetalleRepuesto.Name = "IdDetalleRepuesto";
            this.IdDetalleRepuesto.ReadOnly = true;
            this.IdDetalleRepuesto.Visible = false;
            this.IdDetalleRepuesto.Width = 70;
            // 
            // IdConsecutivo
            // 
            this.IdConsecutivo.HeaderText = "CONS";
            this.IdConsecutivo.Name = "IdConsecutivo";
            this.IdConsecutivo.ReadOnly = true;
            this.IdConsecutivo.Width = 50;
            // 
            // CodigoCuadernillo
            // 
            this.CodigoCuadernillo.HeaderText = "CÓDIGO CUADERNILLO";
            this.CodigoCuadernillo.Name = "CodigoCuadernillo";
            this.CodigoCuadernillo.ReadOnly = true;
            this.CodigoCuadernillo.Width = 210;
            // 
            // CodigoHojaRespuesta
            // 
            this.CodigoHojaRespuesta.HeaderText = "CÓDIGO HOJA RESPUESTA";
            this.CodigoHojaRespuesta.Name = "CodigoHojaRespuesta";
            this.CodigoHojaRespuesta.ReadOnly = true;
            this.CodigoHojaRespuesta.Width = 210;
            // 
            // CodigoSitio
            // 
            this.CodigoSitio.HeaderText = "CÓDIGO SITIO";
            this.CodigoSitio.Name = "CodigoSitio";
            this.CodigoSitio.ReadOnly = true;
            // 
            // NombreSitio
            // 
            this.NombreSitio.HeaderText = "NOMBRE SITIO";
            this.NombreSitio.Name = "NombreSitio";
            this.NombreSitio.ReadOnly = true;
            // 
            // CodigoSalon
            // 
            this.CodigoSalon.HeaderText = "CÓDIGO SALÓN";
            this.CodigoSalon.Name = "CodigoSalon";
            this.CodigoSalon.ReadOnly = true;
            // 
            // Bloque
            // 
            this.Bloque.HeaderText = "BLOQUE";
            this.Bloque.Name = "Bloque";
            this.Bloque.ReadOnly = true;
            this.Bloque.Width = 55;
            // 
            // Estados
            // 
            this.Estados.HeaderText = "ESTADOS";
            this.Estados.Name = "Estados";
            this.Estados.ReadOnly = true;
            // 
            // ConsecutivoIntercale
            // 
            this.ConsecutivoIntercale.HeaderText = "ConsecutivoIntercale";
            this.ConsecutivoIntercale.Name = "ConsecutivoIntercale";
            this.ConsecutivoIntercale.ReadOnly = true;
            this.ConsecutivoIntercale.Visible = false;
            // 
            // txtCodigoActa
            // 
            this.txtCodigoActa.Location = new System.Drawing.Point(476, 124);
            this.txtCodigoActa.Name = "txtCodigoActa";
            this.txtCodigoActa.Size = new System.Drawing.Size(279, 20);
            this.txtCodigoActa.TabIndex = 63;
            this.txtCodigoActa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoActa_KeyPress);
            // 
            // lblCodigoActa
            // 
            this.lblCodigoActa.AutoSize = true;
            this.lblCodigoActa.Location = new System.Drawing.Point(297, 127);
            this.lblCodigoActa.Name = "lblCodigoActa";
            this.lblCodigoActa.Size = new System.Drawing.Size(86, 13);
            this.lblCodigoActa.TabIndex = 62;
            this.lblCodigoActa.Text = "Código de Acta: ";
            this.lblCodigoActa.Click += new System.EventHandler(this.lblCodigoBarrasCuadernillo_Click);
            // 
            // txtCodigoBarrasHojaRespuesta
            // 
            this.txtCodigoBarrasHojaRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodigoBarrasHojaRespuesta.Enabled = false;
            this.txtCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(224, 475);
            this.txtCodigoBarrasHojaRespuesta.Name = "txtCodigoBarrasHojaRespuesta";
            this.txtCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(424, 20);
            this.txtCodigoBarrasHojaRespuesta.TabIndex = 65;
            this.txtCodigoBarrasHojaRespuesta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasHojaRespuesta_KeyPress);
            // 
            // lblCodigoBarrasHojaRespuesta
            // 
            this.lblCodigoBarrasHojaRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCodigoBarrasHojaRespuesta.AutoSize = true;
            this.lblCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(16, 478);
            this.lblCodigoBarrasHojaRespuesta.Name = "lblCodigoBarrasHojaRespuesta";
            this.lblCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(202, 13);
            this.lblCodigoBarrasHojaRespuesta.TabIndex = 64;
            this.lblCodigoBarrasHojaRespuesta.Text = "Código de barras de Hoja de Respuesta: ";
            // 
            // FrmIntercaleRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1055, 507);
            this.Controls.Add(this.txtCodigoBarrasHojaRespuesta);
            this.Controls.Add(this.lblCodigoBarrasHojaRespuesta);
            this.Controls.Add(this.txtCodigoActa);
            this.Controls.Add(this.lblCodigoActa);
            this.Controls.Add(this.dgvIntercaleRepuesto);
            this.Controls.Add(this.lblCiclo);
            this.Controls.Add(this.cbxCiclos);
            this.Controls.Add(this.lblSeleccionarPruebas);
            this.Controls.Add(this.cbxSeleccionarPruebas);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbxCLientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmIntercaleRepuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intercalar Repuesto";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntercaleRepuesto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCiclo;
        private System.Windows.Forms.ComboBox cbxCiclos;
        private System.Windows.Forms.Label lblSeleccionarPruebas;
        private System.Windows.Forms.ComboBox cbxSeleccionarPruebas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCLientes;
        private System.Windows.Forms.DataGridView dgvIntercaleRepuesto;
        private System.Windows.Forms.TextBox txtCodigoActa;
        private System.Windows.Forms.Label lblCodigoActa;
        private System.Windows.Forms.TextBox txtCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.Label lblCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalleRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConsecutivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuadernillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoHojaRespuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bloque;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estados;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConsecutivoIntercale;
    }
}