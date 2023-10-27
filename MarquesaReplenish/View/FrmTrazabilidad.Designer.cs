namespace MarquesaReplenish.View
{
    partial class FrmTrazabilidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrazabilidad));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCodigoActa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigoSitio = new System.Windows.Forms.TextBox();
            this.lblCodigoSitio = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdRepuesto = new System.Windows.Forms.TextBox();
            this.txtCodigoBarrasHojaRespuesta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCodigoBarrasHojaRespuesta = new System.Windows.Forms.Label();
            this.cbxEstados = new System.Windows.Forms.ComboBox();
            this.btnGuardarRespuesto = new System.Windows.Forms.Button();
            this.lblCodigoBarrasCuadernillo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoBarrasCuadernillo = new System.Windows.Forms.TextBox();
            this.cbxUsuarios = new System.Windows.Forms.ComboBox();
            this.lblNovedad = new System.Windows.Forms.Label();
            this.cbxNovedad = new System.Windows.Forms.ComboBox();
            this.lblMaquina = new System.Windows.Forms.Label();
            this.cbxMaquina = new System.Windows.Forms.ComboBox();
            this.lblTipoImpresion = new System.Windows.Forms.Label();
            this.cbxTipoImpresion = new System.Windows.Forms.ComboBox();
            this.lblImpresora = new System.Windows.Forms.Label();
            this.cbxImpresoras = new System.Windows.Forms.ComboBox();
            this.lblFormatoSalidas = new System.Windows.Forms.Label();
            this.cbxFormatoSalidas = new System.Windows.Forms.ComboBox();
            this.lblCiclo = new System.Windows.Forms.Label();
            this.cbxCiclos = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.dgvListaTrazabilidad = new System.Windows.Forms.DataGridView();
            this.lblCantidadRegistro = new System.Windows.Forms.Label();
            this.btnDescargarCSV = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTrazabilidad)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.txtCodigoActa);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtCodigoSitio);
            this.groupBox1.Controls.Add(this.lblCodigoSitio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIdRepuesto);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasHojaRespuesta);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCodigoBarrasHojaRespuesta);
            this.groupBox1.Controls.Add(this.cbxEstados);
            this.groupBox1.Controls.Add(this.btnGuardarRespuesto);
            this.groupBox1.Controls.Add(this.lblCodigoBarrasCuadernillo);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodigoBarrasCuadernillo);
            this.groupBox1.Controls.Add(this.cbxUsuarios);
            this.groupBox1.Controls.Add(this.lblNovedad);
            this.groupBox1.Controls.Add(this.cbxNovedad);
            this.groupBox1.Controls.Add(this.lblMaquina);
            this.groupBox1.Controls.Add(this.cbxMaquina);
            this.groupBox1.Controls.Add(this.lblTipoImpresion);
            this.groupBox1.Controls.Add(this.cbxTipoImpresion);
            this.groupBox1.Controls.Add(this.lblImpresora);
            this.groupBox1.Controls.Add(this.cbxImpresoras);
            this.groupBox1.Controls.Add(this.lblFormatoSalidas);
            this.groupBox1.Controls.Add(this.cbxFormatoSalidas);
            this.groupBox1.Controls.Add(this.lblCiclo);
            this.groupBox1.Controls.Add(this.cbxCiclos);
            this.groupBox1.Controls.Add(this.lblSeleccionarPruebas);
            this.groupBox1.Controls.Add(this.cbxSeleccionarPruebas);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.cbxCLientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(640, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // txtCodigoActa
            // 
            this.txtCodigoActa.Location = new System.Drawing.Point(462, 166);
            this.txtCodigoActa.Name = "txtCodigoActa";
            this.txtCodigoActa.Size = new System.Drawing.Size(172, 20);
            this.txtCodigoActa.TabIndex = 92;
            this.txtCodigoActa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoActa_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(333, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 93;
            this.label5.Text = "Código Acta:";
            // 
            // txtCodigoSitio
            // 
            this.txtCodigoSitio.Location = new System.Drawing.Point(462, 130);
            this.txtCodigoSitio.Name = "txtCodigoSitio";
            this.txtCodigoSitio.Size = new System.Drawing.Size(172, 20);
            this.txtCodigoSitio.TabIndex = 89;
            this.txtCodigoSitio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoSitio_KeyPress);
            // 
            // lblCodigoSitio
            // 
            this.lblCodigoSitio.AutoSize = true;
            this.lblCodigoSitio.Location = new System.Drawing.Point(333, 133);
            this.lblCodigoSitio.Name = "lblCodigoSitio";
            this.lblCodigoSitio.Size = new System.Drawing.Size(69, 13);
            this.lblCodigoSitio.TabIndex = 90;
            this.lblCodigoSitio.Text = "Código Sitio :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(333, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Id Repuesto :";
            // 
            // txtIdRepuesto
            // 
            this.txtIdRepuesto.Location = new System.Drawing.Point(462, 93);
            this.txtIdRepuesto.Name = "txtIdRepuesto";
            this.txtIdRepuesto.Size = new System.Drawing.Size(172, 20);
            this.txtIdRepuesto.TabIndex = 88;
            this.txtIdRepuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdRepuesto_KeyPress);
            // 
            // txtCodigoBarrasHojaRespuesta
            // 
            this.txtCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(462, 56);
            this.txtCodigoBarrasHojaRespuesta.Name = "txtCodigoBarrasHojaRespuesta";
            this.txtCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(172, 20);
            this.txtCodigoBarrasHojaRespuesta.TabIndex = 85;
            this.txtCodigoBarrasHojaRespuesta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasHojaRespuesta_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(333, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 83;
            this.label2.Text = "Estados : ";
            // 
            // lblCodigoBarrasHojaRespuesta
            // 
            this.lblCodigoBarrasHojaRespuesta.AutoSize = true;
            this.lblCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(333, 59);
            this.lblCodigoBarrasHojaRespuesta.Name = "lblCodigoBarrasHojaRespuesta";
            this.lblCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(130, 13);
            this.lblCodigoBarrasHojaRespuesta.TabIndex = 86;
            this.lblCodigoBarrasHojaRespuesta.Text = "Código hoja de respuesta:";
            // 
            // cbxEstados
            // 
            this.cbxEstados.FormattingEnabled = true;
            this.cbxEstados.Location = new System.Drawing.Point(462, 206);
            this.cbxEstados.Name = "cbxEstados";
            this.cbxEstados.Size = new System.Drawing.Size(172, 21);
            this.cbxEstados.TabIndex = 82;
            this.cbxEstados.SelectionChangeCommitted += new System.EventHandler(this.cbxEstados_SelectionChangeCommitted);
            // 
            // btnGuardarRespuesto
            // 
            this.btnGuardarRespuesto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarRespuesto.BackColor = System.Drawing.Color.White;
            this.btnGuardarRespuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarRespuesto.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarRespuesto.ForeColor = System.Drawing.Color.Black;
            this.btnGuardarRespuesto.Image = global::MarquesaReplenish.Properties.Resources.buscar__2_;
            this.btnGuardarRespuesto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarRespuesto.Location = new System.Drawing.Point(216, 329);
            this.btnGuardarRespuesto.Name = "btnGuardarRespuesto";
            this.btnGuardarRespuesto.Size = new System.Drawing.Size(188, 30);
            this.btnGuardarRespuesto.TabIndex = 81;
            this.btnGuardarRespuesto.Text = "Buscar";
            this.btnGuardarRespuesto.UseVisualStyleBackColor = false;
            this.btnGuardarRespuesto.Click += new System.EventHandler(this.btnGuardarRespuesto_Click);
            // 
            // lblCodigoBarrasCuadernillo
            // 
            this.lblCodigoBarrasCuadernillo.AutoSize = true;
            this.lblCodigoBarrasCuadernillo.Location = new System.Drawing.Point(333, 22);
            this.lblCodigoBarrasCuadernillo.Name = "lblCodigoBarrasCuadernillo";
            this.lblCodigoBarrasCuadernillo.Size = new System.Drawing.Size(97, 13);
            this.lblCodigoBarrasCuadernillo.TabIndex = 87;
            this.lblCodigoBarrasCuadernillo.Text = "Código cuadernillo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 80;
            this.label1.Text = "Seleccionar Usuario: ";
            // 
            // txtCodigoBarrasCuadernillo
            // 
            this.txtCodigoBarrasCuadernillo.Location = new System.Drawing.Point(462, 19);
            this.txtCodigoBarrasCuadernillo.Name = "txtCodigoBarrasCuadernillo";
            this.txtCodigoBarrasCuadernillo.Size = new System.Drawing.Size(172, 20);
            this.txtCodigoBarrasCuadernillo.TabIndex = 84;
            this.txtCodigoBarrasCuadernillo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasCuadernillo_KeyPress);
            // 
            // cbxUsuarios
            // 
            this.cbxUsuarios.FormattingEnabled = true;
            this.cbxUsuarios.Location = new System.Drawing.Point(462, 243);
            this.cbxUsuarios.Name = "cbxUsuarios";
            this.cbxUsuarios.Size = new System.Drawing.Size(172, 21);
            this.cbxUsuarios.TabIndex = 0;
            this.cbxUsuarios.SelectionChangeCommitted += new System.EventHandler(this.cbxUsuarios_SelectionChangeCommitted);
            // 
            // lblNovedad
            // 
            this.lblNovedad.AutoSize = true;
            this.lblNovedad.Location = new System.Drawing.Point(13, 288);
            this.lblNovedad.Name = "lblNovedad";
            this.lblNovedad.Size = new System.Drawing.Size(60, 13);
            this.lblNovedad.TabIndex = 78;
            this.lblNovedad.Text = "Novedad : ";
            // 
            // cbxNovedad
            // 
            this.cbxNovedad.FormattingEnabled = true;
            this.cbxNovedad.Location = new System.Drawing.Point(142, 285);
            this.cbxNovedad.Name = "cbxNovedad";
            this.cbxNovedad.Size = new System.Drawing.Size(172, 21);
            this.cbxNovedad.TabIndex = 77;
            this.cbxNovedad.SelectionChangeCommitted += new System.EventHandler(this.cbxNovedad_SelectionChangeCommitted);
            // 
            // lblMaquina
            // 
            this.lblMaquina.AutoSize = true;
            this.lblMaquina.Location = new System.Drawing.Point(13, 249);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(57, 13);
            this.lblMaquina.TabIndex = 76;
            this.lblMaquina.Text = "Maquina : ";
            // 
            // cbxMaquina
            // 
            this.cbxMaquina.FormattingEnabled = true;
            this.cbxMaquina.Location = new System.Drawing.Point(142, 246);
            this.cbxMaquina.Name = "cbxMaquina";
            this.cbxMaquina.Size = new System.Drawing.Size(172, 21);
            this.cbxMaquina.TabIndex = 75;
            this.cbxMaquina.SelectionChangeCommitted += new System.EventHandler(this.cbxMaquina_SelectionChangeCommitted);
            // 
            // lblTipoImpresion
            // 
            this.lblTipoImpresion.AutoSize = true;
            this.lblTipoImpresion.Location = new System.Drawing.Point(13, 209);
            this.lblTipoImpresion.Name = "lblTipoImpresion";
            this.lblTipoImpresion.Size = new System.Drawing.Size(85, 13);
            this.lblTipoImpresion.TabIndex = 74;
            this.lblTipoImpresion.Text = "Tipo Impresión : ";
            // 
            // cbxTipoImpresion
            // 
            this.cbxTipoImpresion.FormattingEnabled = true;
            this.cbxTipoImpresion.Location = new System.Drawing.Point(142, 206);
            this.cbxTipoImpresion.Name = "cbxTipoImpresion";
            this.cbxTipoImpresion.Size = new System.Drawing.Size(172, 21);
            this.cbxTipoImpresion.TabIndex = 73;
            this.cbxTipoImpresion.SelectionChangeCommitted += new System.EventHandler(this.cbxTipoImpresion_SelectionChangeCommitted);
            // 
            // lblImpresora
            // 
            this.lblImpresora.AutoSize = true;
            this.lblImpresora.Location = new System.Drawing.Point(13, 173);
            this.lblImpresora.Name = "lblImpresora";
            this.lblImpresora.Size = new System.Drawing.Size(62, 13);
            this.lblImpresora.TabIndex = 72;
            this.lblImpresora.Text = "Impresora : ";
            // 
            // cbxImpresoras
            // 
            this.cbxImpresoras.FormattingEnabled = true;
            this.cbxImpresoras.Location = new System.Drawing.Point(142, 170);
            this.cbxImpresoras.Name = "cbxImpresoras";
            this.cbxImpresoras.Size = new System.Drawing.Size(172, 21);
            this.cbxImpresoras.TabIndex = 71;
            this.cbxImpresoras.SelectionChangeCommitted += new System.EventHandler(this.cbxImpresoras_SelectionChangeCommitted);
            // 
            // lblFormatoSalidas
            // 
            this.lblFormatoSalidas.AutoSize = true;
            this.lblFormatoSalidas.Location = new System.Drawing.Point(13, 134);
            this.lblFormatoSalidas.Name = "lblFormatoSalidas";
            this.lblFormatoSalidas.Size = new System.Drawing.Size(109, 13);
            this.lblFormatoSalidas.TabIndex = 70;
            this.lblFormatoSalidas.Text = "Formatos de salidas : ";
            // 
            // cbxFormatoSalidas
            // 
            this.cbxFormatoSalidas.FormattingEnabled = true;
            this.cbxFormatoSalidas.Location = new System.Drawing.Point(142, 131);
            this.cbxFormatoSalidas.Name = "cbxFormatoSalidas";
            this.cbxFormatoSalidas.Size = new System.Drawing.Size(172, 21);
            this.cbxFormatoSalidas.TabIndex = 69;
            this.cbxFormatoSalidas.SelectionChangeCommitted += new System.EventHandler(this.cbxFormatoSalidas_SelectionChangeCommitted);
            // 
            // lblCiclo
            // 
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(13, 96);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(44, 13);
            this.lblCiclo.TabIndex = 66;
            this.lblCiclo.Text = "Ciclos : ";
            // 
            // cbxCiclos
            // 
            this.cbxCiclos.FormattingEnabled = true;
            this.cbxCiclos.Location = new System.Drawing.Point(142, 93);
            this.cbxCiclos.Name = "cbxCiclos";
            this.cbxCiclos.Size = new System.Drawing.Size(172, 21);
            this.cbxCiclos.TabIndex = 65;
            this.cbxCiclos.SelectionChangeCommitted += new System.EventHandler(this.cbxCiclos_SelectionChangeCommitted);
            // 
            // lblSeleccionarPruebas
            // 
            this.lblSeleccionarPruebas.AutoSize = true;
            this.lblSeleccionarPruebas.Location = new System.Drawing.Point(13, 60);
            this.lblSeleccionarPruebas.Name = "lblSeleccionarPruebas";
            this.lblSeleccionarPruebas.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccionarPruebas.TabIndex = 64;
            this.lblSeleccionarPruebas.Text = "Seleccionar Pruebas: ";
            // 
            // cbxSeleccionarPruebas
            // 
            this.cbxSeleccionarPruebas.FormattingEnabled = true;
            this.cbxSeleccionarPruebas.Location = new System.Drawing.Point(142, 57);
            this.cbxSeleccionarPruebas.Name = "cbxSeleccionarPruebas";
            this.cbxSeleccionarPruebas.Size = new System.Drawing.Size(172, 21);
            this.cbxSeleccionarPruebas.TabIndex = 63;
            this.cbxSeleccionarPruebas.SelectionChangeCommitted += new System.EventHandler(this.cbxSeleccionarPruebas_SelectionChangeCommitted);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(13, 22);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 62;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(142, 19);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(172, 21);
            this.cbxCLientes.TabIndex = 1;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // dgvListaTrazabilidad
            // 
            this.dgvListaTrazabilidad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaTrazabilidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaTrazabilidad.Location = new System.Drawing.Point(658, 12);
            this.dgvListaTrazabilidad.Name = "dgvListaTrazabilidad";
            this.dgvListaTrazabilidad.Size = new System.Drawing.Size(496, 401);
            this.dgvListaTrazabilidad.TabIndex = 1;
            // 
            // lblCantidadRegistro
            // 
            this.lblCantidadRegistro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadRegistro.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadRegistro.Location = new System.Drawing.Point(12, 380);
            this.lblCantidadRegistro.Name = "lblCantidadRegistro";
            this.lblCantidadRegistro.Size = new System.Drawing.Size(340, 44);
            this.lblCantidadRegistro.TabIndex = 2;
            this.lblCantidadRegistro.Text = "cantidad de registros encontrados:";
            this.lblCantidadRegistro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDescargarCSV
            // 
            this.btnDescargarCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDescargarCSV.BackColor = System.Drawing.Color.Green;
            this.btnDescargarCSV.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDescargarCSV.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDescargarCSV.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDescargarCSV.Image = global::MarquesaReplenish.Properties.Resources.formato_de_archivo_csv__1_;
            this.btnDescargarCSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDescargarCSV.Location = new System.Drawing.Point(382, 383);
            this.btnDescargarCSV.Name = "btnDescargarCSV";
            this.btnDescargarCSV.Size = new System.Drawing.Size(270, 30);
            this.btnDescargarCSV.TabIndex = 94;
            this.btnDescargarCSV.Text = "Descargar Búsqueda en CSV";
            this.btnDescargarCSV.UseVisualStyleBackColor = false;
            this.btnDescargarCSV.Click += new System.EventHandler(this.btnDescargarCSV_Click);
            // 
            // FrmTrazabilidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1166, 424);
            this.Controls.Add(this.btnDescargarCSV);
            this.Controls.Add(this.lblCantidadRegistro);
            this.Controls.Add(this.dgvListaTrazabilidad);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTrazabilidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trazabilidad Repuesto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaTrazabilidad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxUsuarios;
        private System.Windows.Forms.Label lblNovedad;
        private System.Windows.Forms.ComboBox cbxNovedad;
        private System.Windows.Forms.Label lblMaquina;
        private System.Windows.Forms.ComboBox cbxMaquina;
        private System.Windows.Forms.Label lblTipoImpresion;
        private System.Windows.Forms.ComboBox cbxTipoImpresion;
        private System.Windows.Forms.Label lblImpresora;
        private System.Windows.Forms.ComboBox cbxImpresoras;
        private System.Windows.Forms.Label lblFormatoSalidas;
        private System.Windows.Forms.ComboBox cbxFormatoSalidas;
        private System.Windows.Forms.Label lblCiclo;
        private System.Windows.Forms.ComboBox cbxCiclos;
        private System.Windows.Forms.Label lblSeleccionarPruebas;
        private System.Windows.Forms.ComboBox cbxSeleccionarPruebas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCLientes;
        private System.Windows.Forms.DataGridView dgvListaTrazabilidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxEstados;
        private System.Windows.Forms.TextBox txtCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.Label lblCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.TextBox txtCodigoBarrasCuadernillo;
        private System.Windows.Forms.Label lblCodigoBarrasCuadernillo;
        private System.Windows.Forms.TextBox txtCodigoActa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigoSitio;
        private System.Windows.Forms.Label lblCodigoSitio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdRepuesto;
        private System.Windows.Forms.Label lblCantidadRegistro;
        private System.Windows.Forms.Button btnDescargarCSV;
        private System.Windows.Forms.Button btnGuardarRespuesto;
    }
}