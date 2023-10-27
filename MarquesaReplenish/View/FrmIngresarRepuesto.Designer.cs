namespace MarquesaReplenish.View
{
    partial class FrmIngresarRepuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIngresarRepuesto));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.lblPartes = new System.Windows.Forms.Label();
            this.cbxPartes = new System.Windows.Forms.ComboBox();
            this.lblCiclo = new System.Windows.Forms.Label();
            this.cbxCiclos = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.gbxInformacionFija = new System.Windows.Forms.GroupBox();
            this.txtRangoMaximoGeneracionRepuestos = new System.Windows.Forms.TextBox();
            this.txtImprimirPor = new System.Windows.Forms.TextBox();
            this.lblRangoMaximoGeneracionRepuestos = new System.Windows.Forms.Label();
            this.lblImprimirPor = new System.Windows.Forms.Label();
            this.txtResolucion = new System.Windows.Forms.TextBox();
            this.txtTipoPapel = new System.Windows.Forms.TextBox();
            this.lblResolucion = new System.Windows.Forms.Label();
            this.lblTipoPapel = new System.Windows.Forms.Label();
            this.gbxListadoRepuesto = new System.Windows.Forms.GroupBox();
            this.usrHasta = new System.Windows.Forms.TextBox();
            this.usrDesde = new System.Windows.Forms.TextBox();
            this.lblCantidadRepuesto = new System.Windows.Forms.Label();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.dgvRepuestoIngresados = new System.Windows.Forms.DataGridView();
            this.Repuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usrSeleccionarArchivo1 = new WinFormsControlLibrary.usrSeleccionarArchivo();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.btnGuardarRespuesto = new System.Windows.Forms.Button();
            this.usrSeleccionarCarpetaSalida = new WinFormsControlLibrary.usrSeleccionarCarpeta();
            this.groupBox1.SuspendLayout();
            this.gbxInformacionFija.SuspendLayout();
            this.gbxListadoRepuesto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestoIngresados)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.groupBox1.Controls.Add(this.lblPartes);
            this.groupBox1.Controls.Add(this.cbxPartes);
            this.groupBox1.Controls.Add(this.lblCiclo);
            this.groupBox1.Controls.Add(this.cbxCiclos);
            this.groupBox1.Controls.Add(this.lblSeleccionarPruebas);
            this.groupBox1.Controls.Add(this.cbxSeleccionarPruebas);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.cbxCLientes);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 400);
            this.groupBox1.TabIndex = 43;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Información";
            // 
            // lblNovedad
            // 
            this.lblNovedad.AutoSize = true;
            this.lblNovedad.Location = new System.Drawing.Point(11, 361);
            this.lblNovedad.Name = "lblNovedad";
            this.lblNovedad.Size = new System.Drawing.Size(60, 13);
            this.lblNovedad.TabIndex = 60;
            this.lblNovedad.Text = "Novedad : ";
            // 
            // cbxNovedad
            // 
            this.cbxNovedad.FormattingEnabled = true;
            this.cbxNovedad.Location = new System.Drawing.Point(190, 358);
            this.cbxNovedad.Name = "cbxNovedad";
            this.cbxNovedad.Size = new System.Drawing.Size(279, 21);
            this.cbxNovedad.TabIndex = 59;
            this.cbxNovedad.SelectionChangeCommitted += new System.EventHandler(this.cbxNovedad_SelectionChangeCommitted);
            // 
            // lblMaquina
            // 
            this.lblMaquina.AutoSize = true;
            this.lblMaquina.Location = new System.Drawing.Point(11, 321);
            this.lblMaquina.Name = "lblMaquina";
            this.lblMaquina.Size = new System.Drawing.Size(57, 13);
            this.lblMaquina.TabIndex = 58;
            this.lblMaquina.Text = "Maquina : ";
            // 
            // cbxMaquina
            // 
            this.cbxMaquina.FormattingEnabled = true;
            this.cbxMaquina.Location = new System.Drawing.Point(190, 318);
            this.cbxMaquina.Name = "cbxMaquina";
            this.cbxMaquina.Size = new System.Drawing.Size(279, 21);
            this.cbxMaquina.TabIndex = 57;
            this.cbxMaquina.SelectionChangeCommitted += new System.EventHandler(this.cbxMaquina_SelectionChangeCommitted);
            // 
            // lblTipoImpresion
            // 
            this.lblTipoImpresion.AutoSize = true;
            this.lblTipoImpresion.Location = new System.Drawing.Point(11, 275);
            this.lblTipoImpresion.Name = "lblTipoImpresion";
            this.lblTipoImpresion.Size = new System.Drawing.Size(85, 13);
            this.lblTipoImpresion.TabIndex = 56;
            this.lblTipoImpresion.Text = "Tipo Impresión : ";
            // 
            // cbxTipoImpresion
            // 
            this.cbxTipoImpresion.FormattingEnabled = true;
            this.cbxTipoImpresion.Location = new System.Drawing.Point(190, 272);
            this.cbxTipoImpresion.Name = "cbxTipoImpresion";
            this.cbxTipoImpresion.Size = new System.Drawing.Size(279, 21);
            this.cbxTipoImpresion.TabIndex = 55;
            this.cbxTipoImpresion.SelectionChangeCommitted += new System.EventHandler(this.cbxTipoImpresion_SelectionChangeCommitted);
            // 
            // lblImpresora
            // 
            this.lblImpresora.AutoSize = true;
            this.lblImpresora.Location = new System.Drawing.Point(11, 235);
            this.lblImpresora.Name = "lblImpresora";
            this.lblImpresora.Size = new System.Drawing.Size(62, 13);
            this.lblImpresora.TabIndex = 54;
            this.lblImpresora.Text = "Impresora : ";
            // 
            // cbxImpresoras
            // 
            this.cbxImpresoras.FormattingEnabled = true;
            this.cbxImpresoras.Location = new System.Drawing.Point(190, 232);
            this.cbxImpresoras.Name = "cbxImpresoras";
            this.cbxImpresoras.Size = new System.Drawing.Size(279, 21);
            this.cbxImpresoras.TabIndex = 53;
            this.cbxImpresoras.SelectionChangeCommitted += new System.EventHandler(this.cbxImpresoras_SelectionChangeCommitted);
            // 
            // lblFormatoSalidas
            // 
            this.lblFormatoSalidas.AutoSize = true;
            this.lblFormatoSalidas.Location = new System.Drawing.Point(11, 191);
            this.lblFormatoSalidas.Name = "lblFormatoSalidas";
            this.lblFormatoSalidas.Size = new System.Drawing.Size(109, 13);
            this.lblFormatoSalidas.TabIndex = 52;
            this.lblFormatoSalidas.Text = "Formatos de salidas : ";
            // 
            // cbxFormatoSalidas
            // 
            this.cbxFormatoSalidas.FormattingEnabled = true;
            this.cbxFormatoSalidas.Location = new System.Drawing.Point(190, 188);
            this.cbxFormatoSalidas.Name = "cbxFormatoSalidas";
            this.cbxFormatoSalidas.Size = new System.Drawing.Size(279, 21);
            this.cbxFormatoSalidas.TabIndex = 51;
            this.cbxFormatoSalidas.SelectionChangeCommitted += new System.EventHandler(this.cbxFormatoSalidas_SelectionChangeCommitted);
            // 
            // lblPartes
            // 
            this.lblPartes.AutoSize = true;
            this.lblPartes.Location = new System.Drawing.Point(11, 149);
            this.lblPartes.Name = "lblPartes";
            this.lblPartes.Size = new System.Drawing.Size(46, 13);
            this.lblPartes.TabIndex = 50;
            this.lblPartes.Text = "Partes : ";
            // 
            // cbxPartes
            // 
            this.cbxPartes.FormattingEnabled = true;
            this.cbxPartes.Location = new System.Drawing.Point(190, 146);
            this.cbxPartes.Name = "cbxPartes";
            this.cbxPartes.Size = new System.Drawing.Size(279, 21);
            this.cbxPartes.TabIndex = 49;
            this.cbxPartes.SelectionChangeCommitted += new System.EventHandler(this.cbxPartes_SelectionChangeCommitted);
            // 
            // lblCiclo
            // 
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(11, 109);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(44, 13);
            this.lblCiclo.TabIndex = 48;
            this.lblCiclo.Text = "Ciclos : ";
            // 
            // cbxCiclos
            // 
            this.cbxCiclos.FormattingEnabled = true;
            this.cbxCiclos.Location = new System.Drawing.Point(190, 106);
            this.cbxCiclos.Name = "cbxCiclos";
            this.cbxCiclos.Size = new System.Drawing.Size(279, 21);
            this.cbxCiclos.TabIndex = 47;
            this.cbxCiclos.SelectionChangeCommitted += new System.EventHandler(this.cbxCiclos_SelectionChangeCommitted);
            // 
            // lblSeleccionarPruebas
            // 
            this.lblSeleccionarPruebas.AutoSize = true;
            this.lblSeleccionarPruebas.Location = new System.Drawing.Point(11, 73);
            this.lblSeleccionarPruebas.Name = "lblSeleccionarPruebas";
            this.lblSeleccionarPruebas.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccionarPruebas.TabIndex = 46;
            this.lblSeleccionarPruebas.Text = "Seleccionar Pruebas: ";
            // 
            // cbxSeleccionarPruebas
            // 
            this.cbxSeleccionarPruebas.FormattingEnabled = true;
            this.cbxSeleccionarPruebas.Location = new System.Drawing.Point(190, 70);
            this.cbxSeleccionarPruebas.Name = "cbxSeleccionarPruebas";
            this.cbxSeleccionarPruebas.Size = new System.Drawing.Size(279, 21);
            this.cbxSeleccionarPruebas.TabIndex = 45;
            this.cbxSeleccionarPruebas.SelectionChangeCommitted += new System.EventHandler(this.cbxSeleccionarPruebas_SelectionChangeCommitted);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(11, 34);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 44;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(190, 31);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(279, 21);
            this.cbxCLientes.TabIndex = 43;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // gbxInformacionFija
            // 
            this.gbxInformacionFija.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxInformacionFija.Controls.Add(this.txtRangoMaximoGeneracionRepuestos);
            this.gbxInformacionFija.Controls.Add(this.txtImprimirPor);
            this.gbxInformacionFija.Controls.Add(this.lblRangoMaximoGeneracionRepuestos);
            this.gbxInformacionFija.Controls.Add(this.lblImprimirPor);
            this.gbxInformacionFija.Controls.Add(this.txtResolucion);
            this.gbxInformacionFija.Controls.Add(this.txtTipoPapel);
            this.gbxInformacionFija.Controls.Add(this.lblResolucion);
            this.gbxInformacionFija.Controls.Add(this.lblTipoPapel);
            this.gbxInformacionFija.Location = new System.Drawing.Point(500, 15);
            this.gbxInformacionFija.Name = "gbxInformacionFija";
            this.gbxInformacionFija.Size = new System.Drawing.Size(492, 100);
            this.gbxInformacionFija.TabIndex = 44;
            this.gbxInformacionFija.TabStop = false;
            this.gbxInformacionFija.Text = "Información Fija";
            // 
            // txtRangoMaximoGeneracionRepuestos
            // 
            this.txtRangoMaximoGeneracionRepuestos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRangoMaximoGeneracionRepuestos.Location = new System.Drawing.Point(336, 62);
            this.txtRangoMaximoGeneracionRepuestos.Name = "txtRangoMaximoGeneracionRepuestos";
            this.txtRangoMaximoGeneracionRepuestos.Size = new System.Drawing.Size(150, 20);
            this.txtRangoMaximoGeneracionRepuestos.TabIndex = 7;
            // 
            // txtImprimirPor
            // 
            this.txtImprimirPor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImprimirPor.Location = new System.Drawing.Point(336, 27);
            this.txtImprimirPor.Name = "txtImprimirPor";
            this.txtImprimirPor.Size = new System.Drawing.Size(150, 20);
            this.txtImprimirPor.TabIndex = 6;
            // 
            // lblRangoMaximoGeneracionRepuestos
            // 
            this.lblRangoMaximoGeneracionRepuestos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRangoMaximoGeneracionRepuestos.Location = new System.Drawing.Point(203, 59);
            this.lblRangoMaximoGeneracionRepuestos.Name = "lblRangoMaximoGeneracionRepuestos";
            this.lblRangoMaximoGeneracionRepuestos.Size = new System.Drawing.Size(127, 30);
            this.lblRangoMaximoGeneracionRepuestos.TabIndex = 5;
            this.lblRangoMaximoGeneracionRepuestos.Text = "Rango Máximo generación de repuestos: ";
            // 
            // lblImprimirPor
            // 
            this.lblImprimirPor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImprimirPor.AutoSize = true;
            this.lblImprimirPor.Location = new System.Drawing.Point(203, 30);
            this.lblImprimirPor.Name = "lblImprimirPor";
            this.lblImprimirPor.Size = new System.Drawing.Size(66, 13);
            this.lblImprimirPor.TabIndex = 4;
            this.lblImprimirPor.Text = "Imprimir por :";
            // 
            // txtResolucion
            // 
            this.txtResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtResolucion.Location = new System.Drawing.Point(90, 66);
            this.txtResolucion.Name = "txtResolucion";
            this.txtResolucion.Size = new System.Drawing.Size(106, 20);
            this.txtResolucion.TabIndex = 3;
            // 
            // txtTipoPapel
            // 
            this.txtTipoPapel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTipoPapel.Location = new System.Drawing.Point(90, 31);
            this.txtTipoPapel.Name = "txtTipoPapel";
            this.txtTipoPapel.Size = new System.Drawing.Size(106, 20);
            this.txtTipoPapel.TabIndex = 2;
            // 
            // lblResolucion
            // 
            this.lblResolucion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResolucion.AutoSize = true;
            this.lblResolucion.Location = new System.Drawing.Point(7, 70);
            this.lblResolucion.Name = "lblResolucion";
            this.lblResolucion.Size = new System.Drawing.Size(72, 13);
            this.lblResolucion.TabIndex = 1;
            this.lblResolucion.Text = "Resolucción :";
            // 
            // lblTipoPapel
            // 
            this.lblTipoPapel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTipoPapel.AutoSize = true;
            this.lblTipoPapel.Location = new System.Drawing.Point(7, 34);
            this.lblTipoPapel.Name = "lblTipoPapel";
            this.lblTipoPapel.Size = new System.Drawing.Size(79, 13);
            this.lblTipoPapel.TabIndex = 0;
            this.lblTipoPapel.Text = "Tipo de Papel :";
            // 
            // gbxListadoRepuesto
            // 
            this.gbxListadoRepuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxListadoRepuesto.BackColor = System.Drawing.Color.White;
            this.gbxListadoRepuesto.Controls.Add(this.usrHasta);
            this.gbxListadoRepuesto.Controls.Add(this.usrDesde);
            this.gbxListadoRepuesto.Controls.Add(this.lblCantidadRepuesto);
            this.gbxListadoRepuesto.Controls.Add(this.btnLimpiar);
            this.gbxListadoRepuesto.Controls.Add(this.btnInsertar);
            this.gbxListadoRepuesto.Controls.Add(this.dgvRepuestoIngresados);
            this.gbxListadoRepuesto.Controls.Add(this.usrSeleccionarArchivo1);
            this.gbxListadoRepuesto.Controls.Add(this.lblHasta);
            this.gbxListadoRepuesto.Controls.Add(this.lblDesde);
            this.gbxListadoRepuesto.Enabled = false;
            this.gbxListadoRepuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbxListadoRepuesto.Location = new System.Drawing.Point(500, 119);
            this.gbxListadoRepuesto.Name = "gbxListadoRepuesto";
            this.gbxListadoRepuesto.Size = new System.Drawing.Size(492, 296);
            this.gbxListadoRepuesto.TabIndex = 45;
            this.gbxListadoRepuesto.TabStop = false;
            this.gbxListadoRepuesto.Text = "Listado de Repuestos";
            // 
            // usrHasta
            // 
            this.usrHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.usrHasta.Location = new System.Drawing.Point(323, 30);
            this.usrHasta.Name = "usrHasta";
            this.usrHasta.Size = new System.Drawing.Size(138, 20);
            this.usrHasta.TabIndex = 51;
            this.usrHasta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usrHasta_KeyPressed);
            // 
            // usrDesde
            // 
            this.usrDesde.Location = new System.Drawing.Point(68, 30);
            this.usrDesde.Name = "usrDesde";
            this.usrDesde.Size = new System.Drawing.Size(128, 20);
            this.usrDesde.TabIndex = 50;
            this.usrDesde.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usrDesde_KeyPressed);
            // 
            // lblCantidadRepuesto
            // 
            this.lblCantidadRepuesto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadRepuesto.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadRepuesto.Location = new System.Drawing.Point(10, 260);
            this.lblCantidadRepuesto.Name = "lblCantidadRepuesto";
            this.lblCantidadRepuesto.Size = new System.Drawing.Size(52, 30);
            this.lblCantidadRepuesto.TabIndex = 49;
            this.lblCantidadRepuesto.Text = "0";
            this.lblCantidadRepuesto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLimpiar.BackColor = System.Drawing.Color.White;
            this.btnLimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLimpiar.Image = global::MarquesaReplenish.Properties.Resources.borrar_archivo__1_;
            this.btnLimpiar.Location = new System.Drawing.Point(15, 171);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(35, 35);
            this.btnLimpiar.TabIndex = 48;
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnInsertar.BackColor = System.Drawing.Color.White;
            this.btnInsertar.BackgroundImage = global::MarquesaReplenish.Properties.Resources.insertar1;
            this.btnInsertar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnInsertar.Image = global::MarquesaReplenish.Properties.Resources.insertar__3_;
            this.btnInsertar.Location = new System.Drawing.Point(15, 120);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(35, 35);
            this.btnInsertar.TabIndex = 47;
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // dgvRepuestoIngresados
            // 
            this.dgvRepuestoIngresados.AllowUserToAddRows = false;
            this.dgvRepuestoIngresados.AllowUserToDeleteRows = false;
            this.dgvRepuestoIngresados.AllowUserToOrderColumns = true;
            this.dgvRepuestoIngresados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRepuestoIngresados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepuestoIngresados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Repuesto});
            this.dgvRepuestoIngresados.Location = new System.Drawing.Point(68, 96);
            this.dgvRepuestoIngresados.Name = "dgvRepuestoIngresados";
            this.dgvRepuestoIngresados.ReadOnly = true;
            this.dgvRepuestoIngresados.Size = new System.Drawing.Size(411, 194);
            this.dgvRepuestoIngresados.TabIndex = 13;
            // 
            // Repuesto
            // 
            this.Repuesto.HeaderText = "Repuesto";
            this.Repuesto.Name = "Repuesto";
            this.Repuesto.ReadOnly = true;
            // 
            // usrSeleccionarArchivo1
            // 
            this.usrSeleccionarArchivo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usrSeleccionarArchivo1.ArchivoSeleccionado = "";
            this.usrSeleccionarArchivo1.ColorBoton = System.Drawing.SystemColors.ActiveCaption;
            this.usrSeleccionarArchivo1.ColorTextoBoton = System.Drawing.Color.Black;
            this.usrSeleccionarArchivo1.FiltroExtensionPermitida = "archivos de csv|*.csv|archivos de texto|*.txt";
            this.usrSeleccionarArchivo1.InitialDirectory = null;
            this.usrSeleccionarArchivo1.IsEnabled = true;
            this.usrSeleccionarArchivo1.Location = new System.Drawing.Point(9, 56);
            this.usrSeleccionarArchivo1.Name = "usrSeleccionarArchivo1";
            this.usrSeleccionarArchivo1.Size = new System.Drawing.Size(470, 34);
            this.usrSeleccionarArchivo1.TabIndex = 12;
            this.usrSeleccionarArchivo1.Titulo = "Cargar Archivo:";
            this.usrSeleccionarArchivo1.OnSeleccionArchivo += new System.EventHandler<WinFormsControlLibrary.usrSeleccionarArchivo.SeleccionArchivoEventArgs>(this.usrSeleccionarArchivo1_OnSeleccionArchivo);
            // 
            // lblHasta
            // 
            this.lblHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(252, 33);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(41, 13);
            this.lblHasta.TabIndex = 10;
            this.lblHasta.Text = "Hasta :";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(6, 33);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(44, 13);
            this.lblDesde.TabIndex = 8;
            this.lblDesde.Text = "Desde :";
            // 
            // btnGuardarRespuesto
            // 
            this.btnGuardarRespuesto.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGuardarRespuesto.BackColor = System.Drawing.Color.Black;
            this.btnGuardarRespuesto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarRespuesto.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardarRespuesto.Location = new System.Drawing.Point(685, 421);
            this.btnGuardarRespuesto.Name = "btnGuardarRespuesto";
            this.btnGuardarRespuesto.Size = new System.Drawing.Size(188, 30);
            this.btnGuardarRespuesto.TabIndex = 46;
            this.btnGuardarRespuesto.Text = "Guardar Repuestos";
            this.btnGuardarRespuesto.UseVisualStyleBackColor = false;
            this.btnGuardarRespuesto.Click += new System.EventHandler(this.btnGuardarRespuesto_Click);
            // 
            // usrSeleccionarCarpetaSalida
            // 
            this.usrSeleccionarCarpetaSalida.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.usrSeleccionarCarpetaSalida.BackColor = System.Drawing.Color.White;
            this.usrSeleccionarCarpetaSalida.CarpetaSeleccionado = "D:\\jose.valencia\\Desktop\\MarquesaReplenish\\ArchivosCargue";
            this.usrSeleccionarCarpetaSalida.ColorBoton = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.usrSeleccionarCarpetaSalida.Location = new System.Drawing.Point(12, 421);
            this.usrSeleccionarCarpetaSalida.Name = "usrSeleccionarCarpetaSalida";
            this.usrSeleccionarCarpetaSalida.Size = new System.Drawing.Size(550, 34);
            this.usrSeleccionarCarpetaSalida.TabIndex = 47;
            this.usrSeleccionarCarpetaSalida.Titulo = "Seleccionar carpeta de archivo de salidad:";
            this.usrSeleccionarCarpetaSalida.Visible = false;
            // 
            // FrmIngresarRepuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1004, 461);
            this.Controls.Add(this.usrSeleccionarCarpetaSalida);
            this.Controls.Add(this.btnGuardarRespuesto);
            this.Controls.Add(this.gbxListadoRepuesto);
            this.Controls.Add(this.gbxInformacionFija);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmIngresarRepuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Repuesto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbxInformacionFija.ResumeLayout(false);
            this.gbxInformacionFija.PerformLayout();
            this.gbxListadoRepuesto.ResumeLayout(false);
            this.gbxListadoRepuesto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepuestoIngresados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Label lblPartes;
        private System.Windows.Forms.ComboBox cbxPartes;
        private System.Windows.Forms.Label lblCiclo;
        private System.Windows.Forms.ComboBox cbxCiclos;
        private System.Windows.Forms.Label lblSeleccionarPruebas;
        private System.Windows.Forms.ComboBox cbxSeleccionarPruebas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCLientes;
        private System.Windows.Forms.GroupBox gbxInformacionFija;
        private System.Windows.Forms.TextBox txtRangoMaximoGeneracionRepuestos;
        private System.Windows.Forms.TextBox txtImprimirPor;
        private System.Windows.Forms.Label lblRangoMaximoGeneracionRepuestos;
        private System.Windows.Forms.Label lblImprimirPor;
        private System.Windows.Forms.TextBox txtResolucion;
        private System.Windows.Forms.TextBox txtTipoPapel;
        private System.Windows.Forms.Label lblResolucion;
        private System.Windows.Forms.Label lblTipoPapel;
        private System.Windows.Forms.GroupBox gbxListadoRepuesto;
        private WinFormsControlLibrary.usrSeleccionarArchivo usrSeleccionarArchivo1;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnGuardarRespuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Repuesto;
        private System.Windows.Forms.Label lblCantidadRepuesto;
        private WinFormsControlLibrary.usrSeleccionarCarpeta usrSeleccionarCarpetaSalida;
        public System.Windows.Forms.DataGridView dgvRepuestoIngresados;
        private System.Windows.Forms.TextBox usrHasta;
        private System.Windows.Forms.TextBox usrDesde;
    }
}