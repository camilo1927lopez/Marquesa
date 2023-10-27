namespace MarquesaReplenish.View
{
    partial class FrmAuditoriaRepuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuditoriaRepuesto));
            this.lblCiclo = new System.Windows.Forms.Label();
            this.cbxCiclos = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblIdCons = new System.Windows.Forms.Label();
            this.txtTipoHR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroCuartillaComprar = new System.Windows.Forms.TextBox();
            this.txtCuartillaNCuadernillo = new System.Windows.Forms.TextBox();
            this.CuartillaNCuadernillo = new System.Windows.Forms.Label();
            this.txtNumeroCuartillaFinal = new System.Windows.Forms.TextBox();
            this.lblNumeroCuartillaFinal = new System.Windows.Forms.Label();
            this.txtNumeroCuartillaInicial = new System.Windows.Forms.TextBox();
            this.lblNumeroCuartillaInicial = new System.Windows.Forms.Label();
            this.txtCuartilla1Cuadernillo = new System.Windows.Forms.TextBox();
            this.lblCuartilla1Cuadernillo = new System.Windows.Forms.Label();
            this.txtCodigoBarrasHojaRespuesta = new System.Windows.Forms.TextBox();
            this.lblCodigoBarrasHojaRespuesta = new System.Windows.Forms.Label();
            this.txtCodigoBarrasCuadernillo = new System.Windows.Forms.TextBox();
            this.lblCodigoBarrasCuadernillo = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCiclo
            // 
            this.lblCiclo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(61, 90);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(44, 13);
            this.lblCiclo.TabIndex = 54;
            this.lblCiclo.Text = "Ciclos : ";
            // 
            // cbxCiclos
            // 
            this.cbxCiclos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxCiclos.FormattingEnabled = true;
            this.cbxCiclos.Location = new System.Drawing.Point(240, 87);
            this.cbxCiclos.Name = "cbxCiclos";
            this.cbxCiclos.Size = new System.Drawing.Size(279, 21);
            this.cbxCiclos.TabIndex = 2;
            this.cbxCiclos.SelectionChangeCommitted += new System.EventHandler(this.cbxCiclos_SelectionChangeCommitted);
            // 
            // lblSeleccionarPruebas
            // 
            this.lblSeleccionarPruebas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSeleccionarPruebas.AutoSize = true;
            this.lblSeleccionarPruebas.Location = new System.Drawing.Point(61, 54);
            this.lblSeleccionarPruebas.Name = "lblSeleccionarPruebas";
            this.lblSeleccionarPruebas.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccionarPruebas.TabIndex = 52;
            this.lblSeleccionarPruebas.Text = "Seleccionar Pruebas: ";
            // 
            // cbxSeleccionarPruebas
            // 
            this.cbxSeleccionarPruebas.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxSeleccionarPruebas.FormattingEnabled = true;
            this.cbxSeleccionarPruebas.Location = new System.Drawing.Point(240, 51);
            this.cbxSeleccionarPruebas.Name = "cbxSeleccionarPruebas";
            this.cbxSeleccionarPruebas.Size = new System.Drawing.Size(279, 21);
            this.cbxSeleccionarPruebas.TabIndex = 1;
            this.cbxSeleccionarPruebas.SelectionChangeCommitted += new System.EventHandler(this.cbxSeleccionarPruebas_SelectionChangeCommitted);
            // 
            // lblCliente
            // 
            this.lblCliente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(61, 15);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 50;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(240, 12);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(279, 21);
            this.cbxCLientes.TabIndex = 0;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.lblIdCons);
            this.groupBox1.Controls.Add(this.txtTipoHR);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtNumeroCuartillaComprar);
            this.groupBox1.Controls.Add(this.txtCuartillaNCuadernillo);
            this.groupBox1.Controls.Add(this.CuartillaNCuadernillo);
            this.groupBox1.Controls.Add(this.txtNumeroCuartillaFinal);
            this.groupBox1.Controls.Add(this.lblNumeroCuartillaFinal);
            this.groupBox1.Controls.Add(this.txtNumeroCuartillaInicial);
            this.groupBox1.Controls.Add(this.lblNumeroCuartillaInicial);
            this.groupBox1.Controls.Add(this.txtCuartilla1Cuadernillo);
            this.groupBox1.Controls.Add(this.lblCuartilla1Cuadernillo);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasHojaRespuesta);
            this.groupBox1.Controls.Add(this.lblCodigoBarrasHojaRespuesta);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasCuadernillo);
            this.groupBox1.Controls.Add(this.lblCodigoBarrasCuadernillo);
            this.groupBox1.Location = new System.Drawing.Point(12, 132);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(604, 306);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información de reposición ";
            // 
            // lblIdCons
            // 
            this.lblIdCons.AutoSize = true;
            this.lblIdCons.Location = new System.Drawing.Point(548, 202);
            this.lblIdCons.Name = "lblIdCons";
            this.lblIdCons.Size = new System.Drawing.Size(35, 13);
            this.lblIdCons.TabIndex = 22;
            this.lblIdCons.Text = "label2";
            this.lblIdCons.Visible = false;
            // 
            // txtTipoHR
            // 
            this.txtTipoHR.Location = new System.Drawing.Point(252, 121);
            this.txtTipoHR.Name = "txtTipoHR";
            this.txtTipoHR.Size = new System.Drawing.Size(289, 20);
            this.txtTipoHR.TabIndex = 5;
            this.txtTipoHR.Enter += new System.EventHandler(this.txtTipoHR_Enter);
            this.txtTipoHR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTipoHR_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Lectura código de barras TipoHR:";
            // 
            // txtNumeroCuartillaComprar
            // 
            this.txtNumeroCuartillaComprar.Location = new System.Drawing.Point(125, 250);
            this.txtNumeroCuartillaComprar.Name = "txtNumeroCuartillaComprar";
            this.txtNumeroCuartillaComprar.Size = new System.Drawing.Size(117, 20);
            this.txtNumeroCuartillaComprar.TabIndex = 12;
            this.txtNumeroCuartillaComprar.Visible = false;
            // 
            // txtCuartillaNCuadernillo
            // 
            this.txtCuartillaNCuadernillo.Location = new System.Drawing.Point(252, 231);
            this.txtCuartillaNCuadernillo.Name = "txtCuartillaNCuadernillo";
            this.txtCuartillaNCuadernillo.Size = new System.Drawing.Size(289, 20);
            this.txtCuartillaNCuadernillo.TabIndex = 7;
            this.txtCuartillaNCuadernillo.Enter += new System.EventHandler(this.txtCuartillaNCuadernillo_Enter);
            this.txtCuartillaNCuadernillo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuartillaNCuadernillo_KeyPress);
            // 
            // CuartillaNCuadernillo
            // 
            this.CuartillaNCuadernillo.AutoSize = true;
            this.CuartillaNCuadernillo.Location = new System.Drawing.Point(122, 234);
            this.CuartillaNCuadernillo.Name = "CuartillaNCuadernillo";
            this.CuartillaNCuadernillo.Size = new System.Drawing.Size(124, 13);
            this.CuartillaNCuadernillo.TabIndex = 10;
            this.CuartillaNCuadernillo.Text = "Cuartilla @N Cuadernillo:";
            // 
            // txtNumeroCuartillaFinal
            // 
            this.txtNumeroCuartillaFinal.Enabled = false;
            this.txtNumeroCuartillaFinal.Location = new System.Drawing.Point(500, 196);
            this.txtNumeroCuartillaFinal.Name = "txtNumeroCuartillaFinal";
            this.txtNumeroCuartillaFinal.Size = new System.Drawing.Size(41, 20);
            this.txtNumeroCuartillaFinal.TabIndex = 9;
            // 
            // lblNumeroCuartillaFinal
            // 
            this.lblNumeroCuartillaFinal.AutoSize = true;
            this.lblNumeroCuartillaFinal.Location = new System.Drawing.Point(385, 199);
            this.lblNumeroCuartillaFinal.Name = "lblNumeroCuartillaFinal";
            this.lblNumeroCuartillaFinal.Size = new System.Drawing.Size(112, 13);
            this.lblNumeroCuartillaFinal.TabIndex = 8;
            this.lblNumeroCuartillaFinal.Text = "Número Cuartilla Final:";
            // 
            // txtNumeroCuartillaInicial
            // 
            this.txtNumeroCuartillaInicial.Enabled = false;
            this.txtNumeroCuartillaInicial.Location = new System.Drawing.Point(334, 196);
            this.txtNumeroCuartillaInicial.Name = "txtNumeroCuartillaInicial";
            this.txtNumeroCuartillaInicial.Size = new System.Drawing.Size(45, 20);
            this.txtNumeroCuartillaInicial.TabIndex = 7;
            // 
            // lblNumeroCuartillaInicial
            // 
            this.lblNumeroCuartillaInicial.AutoSize = true;
            this.lblNumeroCuartillaInicial.Location = new System.Drawing.Point(213, 199);
            this.lblNumeroCuartillaInicial.Name = "lblNumeroCuartillaInicial";
            this.lblNumeroCuartillaInicial.Size = new System.Drawing.Size(117, 13);
            this.lblNumeroCuartillaInicial.TabIndex = 6;
            this.lblNumeroCuartillaInicial.Text = "Número Cuartilla Inicial:";
            // 
            // txtCuartilla1Cuadernillo
            // 
            this.txtCuartilla1Cuadernillo.Location = new System.Drawing.Point(252, 161);
            this.txtCuartilla1Cuadernillo.Name = "txtCuartilla1Cuadernillo";
            this.txtCuartilla1Cuadernillo.Size = new System.Drawing.Size(289, 20);
            this.txtCuartilla1Cuadernillo.TabIndex = 6;
            this.txtCuartilla1Cuadernillo.Enter += new System.EventHandler(this.txtCuartilla1Cuadernillo_Enter);
            this.txtCuartilla1Cuadernillo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuartilla1Cuadernillo_KeyPress);
            // 
            // lblCuartilla1Cuadernillo
            // 
            this.lblCuartilla1Cuadernillo.AutoSize = true;
            this.lblCuartilla1Cuadernillo.Location = new System.Drawing.Point(115, 164);
            this.lblCuartilla1Cuadernillo.Name = "lblCuartilla1Cuadernillo";
            this.lblCuartilla1Cuadernillo.Size = new System.Drawing.Size(127, 13);
            this.lblCuartilla1Cuadernillo.TabIndex = 15;
            this.lblCuartilla1Cuadernillo.Text = "Cuartilla Final Cuadernillo:";
            // 
            // txtCodigoBarrasHojaRespuesta
            // 
            this.txtCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(252, 84);
            this.txtCodigoBarrasHojaRespuesta.Name = "txtCodigoBarrasHojaRespuesta";
            this.txtCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(289, 20);
            this.txtCodigoBarrasHojaRespuesta.TabIndex = 4;
            this.txtCodigoBarrasHojaRespuesta.Enter += new System.EventHandler(this.txtCodigoBarrasHojaRespuesta_Enter);
            this.txtCodigoBarrasHojaRespuesta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasHojaRespuesta_KeyPress);
            // 
            // lblCodigoBarrasHojaRespuesta
            // 
            this.lblCodigoBarrasHojaRespuesta.AutoSize = true;
            this.lblCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(27, 87);
            this.lblCodigoBarrasHojaRespuesta.Name = "lblCodigoBarrasHojaRespuesta";
            this.lblCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(215, 13);
            this.lblCodigoBarrasHojaRespuesta.TabIndex = 16;
            this.lblCodigoBarrasHojaRespuesta.Text = "Lectura código de barras hoja de respuesta:";
            // 
            // txtCodigoBarrasCuadernillo
            // 
            this.txtCodigoBarrasCuadernillo.Location = new System.Drawing.Point(252, 43);
            this.txtCodigoBarrasCuadernillo.Name = "txtCodigoBarrasCuadernillo";
            this.txtCodigoBarrasCuadernillo.Size = new System.Drawing.Size(289, 20);
            this.txtCodigoBarrasCuadernillo.TabIndex = 3;
            this.txtCodigoBarrasCuadernillo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasCuadernillo_KeyPress);
            // 
            // lblCodigoBarrasCuadernillo
            // 
            this.lblCodigoBarrasCuadernillo.AutoSize = true;
            this.lblCodigoBarrasCuadernillo.Location = new System.Drawing.Point(60, 46);
            this.lblCodigoBarrasCuadernillo.Name = "lblCodigoBarrasCuadernillo";
            this.lblCodigoBarrasCuadernillo.Size = new System.Drawing.Size(182, 13);
            this.lblCodigoBarrasCuadernillo.TabIndex = 19;
            this.lblCodigoBarrasCuadernillo.Text = "Lectura código de barras cuadernillo:";
            // 
            // FrmAuditoriaRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(628, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblCiclo);
            this.Controls.Add(this.cbxCiclos);
            this.Controls.Add(this.lblSeleccionarPruebas);
            this.Controls.Add(this.cbxSeleccionarPruebas);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbxCLientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAuditoriaRepuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Auditoria Repuesto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCuartillaNCuadernillo;
        private System.Windows.Forms.Label CuartillaNCuadernillo;
        private System.Windows.Forms.TextBox txtNumeroCuartillaFinal;
        private System.Windows.Forms.Label lblNumeroCuartillaFinal;
        private System.Windows.Forms.TextBox txtNumeroCuartillaInicial;
        private System.Windows.Forms.Label lblNumeroCuartillaInicial;
        private System.Windows.Forms.TextBox txtCuartilla1Cuadernillo;
        private System.Windows.Forms.Label lblCuartilla1Cuadernillo;
        private System.Windows.Forms.TextBox txtCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.Label lblCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.TextBox txtCodigoBarrasCuadernillo;
        private System.Windows.Forms.Label lblCodigoBarrasCuadernillo;
        private System.Windows.Forms.TextBox txtNumeroCuartillaComprar;
        private System.Windows.Forms.TextBox txtTipoHR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIdCons;
    }
}