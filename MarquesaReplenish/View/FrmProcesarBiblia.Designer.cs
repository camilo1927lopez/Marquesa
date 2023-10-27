namespace MarquesaReplenish.View
{
    partial class FrmProcesarBiblia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProcesarBiblia));
            this.usrSeleccionarArchivoReversa = new WinFormsControlLibrary.usrSeleccionarArchivo();
            this.btnProcesoBiblia = new System.Windows.Forms.Button();
            this.gbxConfiguracionActas = new System.Windows.Forms.GroupBox();
            this.usrNumeroInicialActa = new WinFormsControlLibrary.usrNumeric();
            this.pbxSeleccionarColumnaCalculoActa = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtSeleccionarColumnaCalculoActa = new System.Windows.Forms.TextBox();
            this.lblSeleccionarColumnaCalculoActa = new System.Windows.Forms.Label();
            this.lblNumeroInicialActa = new System.Windows.Forms.Label();
            this.lblTipoPrueba = new System.Windows.Forms.Label();
            this.cbxTipoPrueba = new System.Windows.Forms.ComboBox();
            this.gbxConfiguracionContenedor = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usrCantidadMaximoXContenedorM = new WinFormsControlLibrary.usrNumeric();
            this.usrAyuda = new WinFormsControlLibrary.usrWhatThis();
            this.usrCantidadMaximoXBolsaSeguridad = new WinFormsControlLibrary.usrNumeric();
            this.usrCantidadMaximoXContenedorG = new WinFormsControlLibrary.usrNumeric();
            this.usrNumeroInicialContenedor = new WinFormsControlLibrary.usrNumeric();
            this.pbxSeleccionarColumnaCalculoContenedor = new System.Windows.Forms.PictureBox();
            this.lblNumeroInicialTulaVacia = new System.Windows.Forms.Label();
            this.txtNumeroInicialTulaVacia = new System.Windows.Forms.TextBox();
            this.lblNumeroInicialCajaVacia = new System.Windows.Forms.Label();
            this.txtNumeroInicialCajaVacia = new System.Windows.Forms.TextBox();
            this.lblElementos = new System.Windows.Forms.Label();
            this.txtElementos = new System.Windows.Forms.TextBox();
            this.lblCantidadMaximoXContenedor = new System.Windows.Forms.Label();
            this.lblNumeroInicialContenedor = new System.Windows.Forms.Label();
            this.txtSeleccionarColumnaCalculoContenedor = new System.Windows.Forms.TextBox();
            this.lblCantidadMaximoXBolsaSeguridad = new System.Windows.Forms.Label();
            this.lblSeleccionarColumnaCalculoContenedor = new System.Windows.Forms.Label();
            this.txtProcesoMensaje = new System.Windows.Forms.TextBox();
            this.gbxConfiguracionActas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSeleccionarColumnaCalculoActa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbxConfiguracionContenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSeleccionarColumnaCalculoContenedor)).BeginInit();
            this.SuspendLayout();
            // 
            // usrSeleccionarArchivoReversa
            // 
            this.usrSeleccionarArchivoReversa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usrSeleccionarArchivoReversa.ArchivoSeleccionado = "";
            this.usrSeleccionarArchivoReversa.ColorBoton = System.Drawing.SystemColors.ActiveCaption;
            this.usrSeleccionarArchivoReversa.ColorTextoBoton = System.Drawing.Color.Black;
            this.usrSeleccionarArchivoReversa.FiltroExtensionPermitida = "archivos de txt|*.txt|archivos de csv|*.csv";
            this.usrSeleccionarArchivoReversa.InitialDirectory = null;
            this.usrSeleccionarArchivoReversa.IsEnabled = true;
            this.usrSeleccionarArchivoReversa.Location = new System.Drawing.Point(52, 16);
            this.usrSeleccionarArchivoReversa.Name = "usrSeleccionarArchivoReversa";
            this.usrSeleccionarArchivoReversa.Size = new System.Drawing.Size(545, 34);
            this.usrSeleccionarArchivoReversa.TabIndex = 0;
            this.usrSeleccionarArchivoReversa.Titulo = "Seleccionar Archivo Biblia";
            this.usrSeleccionarArchivoReversa.OnSeleccionArchivo += new System.EventHandler<WinFormsControlLibrary.usrSeleccionarArchivo.SeleccionArchivoEventArgs>(this.usrSeleccionarArchivoReversa_OnSeleccionArchivo);
            this.usrSeleccionarArchivoReversa.Leave += new System.EventHandler(this.usrSeleccionarArchivoReversa_Leave);
            // 
            // btnProcesoBiblia
            // 
            this.btnProcesoBiblia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnProcesoBiblia.BackColor = System.Drawing.Color.Black;
            this.btnProcesoBiblia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcesoBiblia.Enabled = false;
            this.btnProcesoBiblia.ForeColor = System.Drawing.SystemColors.Control;
            this.btnProcesoBiblia.Location = new System.Drawing.Point(260, 526);
            this.btnProcesoBiblia.Name = "btnProcesoBiblia";
            this.btnProcesoBiblia.Size = new System.Drawing.Size(150, 30);
            this.btnProcesoBiblia.TabIndex = 13;
            this.btnProcesoBiblia.Text = "Procesar Biblia";
            this.btnProcesoBiblia.UseVisualStyleBackColor = false;
            this.btnProcesoBiblia.Click += new System.EventHandler(this.btnProcesoBiblia_Click);
            // 
            // gbxConfiguracionActas
            // 
            this.gbxConfiguracionActas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxConfiguracionActas.Controls.Add(this.usrNumeroInicialActa);
            this.gbxConfiguracionActas.Controls.Add(this.pbxSeleccionarColumnaCalculoActa);
            this.gbxConfiguracionActas.Controls.Add(this.pictureBox2);
            this.gbxConfiguracionActas.Controls.Add(this.pictureBox1);
            this.gbxConfiguracionActas.Controls.Add(this.txtSeleccionarColumnaCalculoActa);
            this.gbxConfiguracionActas.Controls.Add(this.lblSeleccionarColumnaCalculoActa);
            this.gbxConfiguracionActas.Controls.Add(this.lblNumeroInicialActa);
            this.gbxConfiguracionActas.Controls.Add(this.lblTipoPrueba);
            this.gbxConfiguracionActas.Controls.Add(this.cbxTipoPrueba);
            this.gbxConfiguracionActas.Enabled = false;
            this.gbxConfiguracionActas.Location = new System.Drawing.Point(12, 56);
            this.gbxConfiguracionActas.Name = "gbxConfiguracionActas";
            this.gbxConfiguracionActas.Size = new System.Drawing.Size(645, 158);
            this.gbxConfiguracionActas.TabIndex = 53;
            this.gbxConfiguracionActas.TabStop = false;
            this.gbxConfiguracionActas.Text = "Configuración de Actas";
            // 
            // usrNumeroInicialActa
            // 
            this.usrNumeroInicialActa.DefaultValue = 0F;
            this.usrNumeroInicialActa.IsEnabled = true;
            this.usrNumeroInicialActa.Location = new System.Drawing.Point(237, 56);
            this.usrNumeroInicialActa.Mascara = "#,##0";
            this.usrNumeroInicialActa.MaxLength = 32767;
            this.usrNumeroInicialActa.Name = "usrNumeroInicialActa";
            this.usrNumeroInicialActa.PermiteDecimales = false;
            this.usrNumeroInicialActa.ShortcutsEnabled = true;
            this.usrNumeroInicialActa.Size = new System.Drawing.Size(303, 20);
            this.usrNumeroInicialActa.TabIndex = 53;
            this.usrNumeroInicialActa.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pbxSeleccionarColumnaCalculoActa
            // 
            this.pbxSeleccionarColumnaCalculoActa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbxSeleccionarColumnaCalculoActa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSeleccionarColumnaCalculoActa.Image = global::MarquesaReplenish.Properties.Resources.celdas_de_tabla_de_una_columna_seleccionada_con_cruces;
            this.pbxSeleccionarColumnaCalculoActa.Location = new System.Drawing.Point(545, 102);
            this.pbxSeleccionarColumnaCalculoActa.Name = "pbxSeleccionarColumnaCalculoActa";
            this.pbxSeleccionarColumnaCalculoActa.Size = new System.Drawing.Size(40, 31);
            this.pbxSeleccionarColumnaCalculoActa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxSeleccionarColumnaCalculoActa.TabIndex = 52;
            this.pbxSeleccionarColumnaCalculoActa.TabStop = false;
            this.pbxSeleccionarColumnaCalculoActa.Click += new System.EventHandler(this.pbxSeleccionarColumnaCalculoActa_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::MarquesaReplenish.Properties.Resources.pencil;
            this.pictureBox2.Location = new System.Drawing.Point(581, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 51;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::MarquesaReplenish.Properties.Resources.plus;
            this.pictureBox1.Location = new System.Drawing.Point(545, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 50;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtSeleccionarColumnaCalculoActa
            // 
            this.txtSeleccionarColumnaCalculoActa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSeleccionarColumnaCalculoActa.Enabled = false;
            this.txtSeleccionarColumnaCalculoActa.Location = new System.Drawing.Point(237, 86);
            this.txtSeleccionarColumnaCalculoActa.Multiline = true;
            this.txtSeleccionarColumnaCalculoActa.Name = "txtSeleccionarColumnaCalculoActa";
            this.txtSeleccionarColumnaCalculoActa.Size = new System.Drawing.Size(303, 66);
            this.txtSeleccionarColumnaCalculoActa.TabIndex = 3;
            // 
            // lblSeleccionarColumnaCalculoActa
            // 
            this.lblSeleccionarColumnaCalculoActa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSeleccionarColumnaCalculoActa.Location = new System.Drawing.Point(43, 91);
            this.lblSeleccionarColumnaCalculoActa.Name = "lblSeleccionarColumnaCalculoActa";
            this.lblSeleccionarColumnaCalculoActa.Size = new System.Drawing.Size(150, 31);
            this.lblSeleccionarColumnaCalculoActa.TabIndex = 49;
            this.lblSeleccionarColumnaCalculoActa.Text = "Seleccionar columnas archivo para calculo de actas:";
            // 
            // lblNumeroInicialActa
            // 
            this.lblNumeroInicialActa.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNumeroInicialActa.AutoSize = true;
            this.lblNumeroInicialActa.Location = new System.Drawing.Point(43, 59);
            this.lblNumeroInicialActa.Name = "lblNumeroInicialActa";
            this.lblNumeroInicialActa.Size = new System.Drawing.Size(103, 13);
            this.lblNumeroInicialActa.TabIndex = 47;
            this.lblNumeroInicialActa.Text = "Numero inicial acta: ";
            // 
            // lblTipoPrueba
            // 
            this.lblTipoPrueba.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTipoPrueba.AutoSize = true;
            this.lblTipoPrueba.Location = new System.Drawing.Point(43, 28);
            this.lblTipoPrueba.Name = "lblTipoPrueba";
            this.lblTipoPrueba.Size = new System.Drawing.Size(145, 13);
            this.lblTipoPrueba.TabIndex = 46;
            this.lblTipoPrueba.Text = "Seleccionar tipo de pruebas: ";
            // 
            // cbxTipoPrueba
            // 
            this.cbxTipoPrueba.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxTipoPrueba.FormattingEnabled = true;
            this.cbxTipoPrueba.Location = new System.Drawing.Point(237, 25);
            this.cbxTipoPrueba.Name = "cbxTipoPrueba";
            this.cbxTipoPrueba.Size = new System.Drawing.Size(303, 21);
            this.cbxTipoPrueba.TabIndex = 1;
            // 
            // gbxConfiguracionContenedor
            // 
            this.gbxConfiguracionContenedor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxConfiguracionContenedor.Controls.Add(this.label2);
            this.gbxConfiguracionContenedor.Controls.Add(this.label1);
            this.gbxConfiguracionContenedor.Controls.Add(this.usrCantidadMaximoXContenedorM);
            this.gbxConfiguracionContenedor.Controls.Add(this.usrAyuda);
            this.gbxConfiguracionContenedor.Controls.Add(this.usrCantidadMaximoXBolsaSeguridad);
            this.gbxConfiguracionContenedor.Controls.Add(this.usrCantidadMaximoXContenedorG);
            this.gbxConfiguracionContenedor.Controls.Add(this.usrNumeroInicialContenedor);
            this.gbxConfiguracionContenedor.Controls.Add(this.pbxSeleccionarColumnaCalculoContenedor);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblNumeroInicialTulaVacia);
            this.gbxConfiguracionContenedor.Controls.Add(this.txtNumeroInicialTulaVacia);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblNumeroInicialCajaVacia);
            this.gbxConfiguracionContenedor.Controls.Add(this.txtNumeroInicialCajaVacia);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblElementos);
            this.gbxConfiguracionContenedor.Controls.Add(this.txtElementos);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblCantidadMaximoXContenedor);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblNumeroInicialContenedor);
            this.gbxConfiguracionContenedor.Controls.Add(this.txtSeleccionarColumnaCalculoContenedor);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblCantidadMaximoXBolsaSeguridad);
            this.gbxConfiguracionContenedor.Controls.Add(this.lblSeleccionarColumnaCalculoContenedor);
            this.gbxConfiguracionContenedor.Enabled = false;
            this.gbxConfiguracionContenedor.Location = new System.Drawing.Point(12, 220);
            this.gbxConfiguracionContenedor.Name = "gbxConfiguracionContenedor";
            this.gbxConfiguracionContenedor.Size = new System.Drawing.Size(645, 300);
            this.gbxConfiguracionContenedor.TabIndex = 54;
            this.gbxConfiguracionContenedor.TabStop = false;
            this.gbxConfiguracionContenedor.Text = "Configuración de Contenedor";
            this.gbxConfiguracionContenedor.Enter += new System.EventHandler(this.gbxConfiguracionContenedor_Enter);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 76;
            this.label2.Text = "Grande:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(241, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 75;
            this.label1.Text = "Mediano:";
            // 
            // usrCantidadMaximoXContenedorM
            // 
            this.usrCantidadMaximoXContenedorM.DefaultValue = 0F;
            this.usrCantidadMaximoXContenedorM.IsEnabled = true;
            this.usrCantidadMaximoXContenedorM.Location = new System.Drawing.Point(297, 45);
            this.usrCantidadMaximoXContenedorM.Mascara = "#,##0";
            this.usrCantidadMaximoXContenedorM.MaxLength = 32767;
            this.usrCantidadMaximoXContenedorM.Name = "usrCantidadMaximoXContenedorM";
            this.usrCantidadMaximoXContenedorM.PermiteDecimales = false;
            this.usrCantidadMaximoXContenedorM.ShortcutsEnabled = true;
            this.usrCantidadMaximoXContenedorM.Size = new System.Drawing.Size(91, 20);
            this.usrCantidadMaximoXContenedorM.TabIndex = 74;
            this.usrCantidadMaximoXContenedorM.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usrAyuda
            // 
            this.usrAyuda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.usrAyuda.ControlAsociado = null;
            this.usrAyuda.Descripcion = "";
            this.usrAyuda.Location = new System.Drawing.Point(545, 242);
            this.usrAyuda.Name = "usrAyuda";
            this.usrAyuda.Size = new System.Drawing.Size(30, 25);
            this.usrAyuda.TabIndex = 73;
            // 
            // usrCantidadMaximoXBolsaSeguridad
            // 
            this.usrCantidadMaximoXBolsaSeguridad.DefaultValue = 0F;
            this.usrCantidadMaximoXBolsaSeguridad.IsEnabled = true;
            this.usrCantidadMaximoXBolsaSeguridad.Location = new System.Drawing.Point(237, 71);
            this.usrCantidadMaximoXBolsaSeguridad.Mascara = "#,##0";
            this.usrCantidadMaximoXBolsaSeguridad.MaxLength = 32767;
            this.usrCantidadMaximoXBolsaSeguridad.Name = "usrCantidadMaximoXBolsaSeguridad";
            this.usrCantidadMaximoXBolsaSeguridad.PermiteDecimales = false;
            this.usrCantidadMaximoXBolsaSeguridad.ShortcutsEnabled = true;
            this.usrCantidadMaximoXBolsaSeguridad.Size = new System.Drawing.Size(303, 20);
            this.usrCantidadMaximoXBolsaSeguridad.TabIndex = 72;
            this.usrCantidadMaximoXBolsaSeguridad.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usrCantidadMaximoXContenedorG
            // 
            this.usrCantidadMaximoXContenedorG.DefaultValue = 0F;
            this.usrCantidadMaximoXContenedorG.IsEnabled = true;
            this.usrCantidadMaximoXContenedorG.Location = new System.Drawing.Point(449, 45);
            this.usrCantidadMaximoXContenedorG.Mascara = "#,##0";
            this.usrCantidadMaximoXContenedorG.MaxLength = 32767;
            this.usrCantidadMaximoXContenedorG.Name = "usrCantidadMaximoXContenedorG";
            this.usrCantidadMaximoXContenedorG.PermiteDecimales = false;
            this.usrCantidadMaximoXContenedorG.ShortcutsEnabled = true;
            this.usrCantidadMaximoXContenedorG.Size = new System.Drawing.Size(91, 20);
            this.usrCantidadMaximoXContenedorG.TabIndex = 71;
            this.usrCantidadMaximoXContenedorG.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // usrNumeroInicialContenedor
            // 
            this.usrNumeroInicialContenedor.DefaultValue = 0F;
            this.usrNumeroInicialContenedor.IsEnabled = true;
            this.usrNumeroInicialContenedor.Location = new System.Drawing.Point(237, 19);
            this.usrNumeroInicialContenedor.Mascara = "#,##0";
            this.usrNumeroInicialContenedor.MaxLength = 32767;
            this.usrNumeroInicialContenedor.Name = "usrNumeroInicialContenedor";
            this.usrNumeroInicialContenedor.PermiteDecimales = false;
            this.usrNumeroInicialContenedor.ShortcutsEnabled = true;
            this.usrNumeroInicialContenedor.Size = new System.Drawing.Size(303, 20);
            this.usrNumeroInicialContenedor.TabIndex = 70;
            this.usrNumeroInicialContenedor.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // pbxSeleccionarColumnaCalculoContenedor
            // 
            this.pbxSeleccionarColumnaCalculoContenedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbxSeleccionarColumnaCalculoContenedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxSeleccionarColumnaCalculoContenedor.Image = global::MarquesaReplenish.Properties.Resources.celdas_de_tabla_de_una_columna_seleccionada_con_cruces;
            this.pbxSeleccionarColumnaCalculoContenedor.Location = new System.Drawing.Point(545, 113);
            this.pbxSeleccionarColumnaCalculoContenedor.Name = "pbxSeleccionarColumnaCalculoContenedor";
            this.pbxSeleccionarColumnaCalculoContenedor.Size = new System.Drawing.Size(40, 31);
            this.pbxSeleccionarColumnaCalculoContenedor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxSeleccionarColumnaCalculoContenedor.TabIndex = 53;
            this.pbxSeleccionarColumnaCalculoContenedor.TabStop = false;
            this.pbxSeleccionarColumnaCalculoContenedor.Click += new System.EventHandler(this.pbxSeleccionarColumnaCalculoContenedor_Click);
            // 
            // lblNumeroInicialTulaVacia
            // 
            this.lblNumeroInicialTulaVacia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNumeroInicialTulaVacia.AutoSize = true;
            this.lblNumeroInicialTulaVacia.Location = new System.Drawing.Point(43, 190);
            this.lblNumeroInicialTulaVacia.Name = "lblNumeroInicialTulaVacia";
            this.lblNumeroInicialTulaVacia.Size = new System.Drawing.Size(133, 13);
            this.lblNumeroInicialTulaVacia.TabIndex = 69;
            this.lblNumeroInicialTulaVacia.Text = "Numero inicial tula vacía : ";
            // 
            // txtNumeroInicialTulaVacia
            // 
            this.txtNumeroInicialTulaVacia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumeroInicialTulaVacia.Location = new System.Drawing.Point(237, 187);
            this.txtNumeroInicialTulaVacia.Name = "txtNumeroInicialTulaVacia";
            this.txtNumeroInicialTulaVacia.Size = new System.Drawing.Size(303, 20);
            this.txtNumeroInicialTulaVacia.TabIndex = 11;
            // 
            // lblNumeroInicialCajaVacia
            // 
            this.lblNumeroInicialCajaVacia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNumeroInicialCajaVacia.AutoSize = true;
            this.lblNumeroInicialCajaVacia.Location = new System.Drawing.Point(43, 164);
            this.lblNumeroInicialCajaVacia.Name = "lblNumeroInicialCajaVacia";
            this.lblNumeroInicialCajaVacia.Size = new System.Drawing.Size(136, 13);
            this.lblNumeroInicialCajaVacia.TabIndex = 67;
            this.lblNumeroInicialCajaVacia.Text = "Numero inicial caja vacía : ";
            // 
            // txtNumeroInicialCajaVacia
            // 
            this.txtNumeroInicialCajaVacia.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtNumeroInicialCajaVacia.Location = new System.Drawing.Point(237, 161);
            this.txtNumeroInicialCajaVacia.Name = "txtNumeroInicialCajaVacia";
            this.txtNumeroInicialCajaVacia.Size = new System.Drawing.Size(303, 20);
            this.txtNumeroInicialCajaVacia.TabIndex = 10;
            // 
            // lblElementos
            // 
            this.lblElementos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblElementos.AutoSize = true;
            this.lblElementos.Location = new System.Drawing.Point(43, 216);
            this.lblElementos.Name = "lblElementos";
            this.lblElementos.Size = new System.Drawing.Size(65, 13);
            this.lblElementos.TabIndex = 65;
            this.lblElementos.Text = "Elementos : ";
            // 
            // txtElementos
            // 
            this.txtElementos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtElementos.Location = new System.Drawing.Point(237, 213);
            this.txtElementos.Multiline = true;
            this.txtElementos.Name = "txtElementos";
            this.txtElementos.Size = new System.Drawing.Size(303, 81);
            this.txtElementos.TabIndex = 12;
            // 
            // lblCantidadMaximoXContenedor
            // 
            this.lblCantidadMaximoXContenedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCantidadMaximoXContenedor.AutoSize = true;
            this.lblCantidadMaximoXContenedor.Location = new System.Drawing.Point(43, 48);
            this.lblCantidadMaximoXContenedor.Name = "lblCantidadMaximoXContenedor";
            this.lblCantidadMaximoXContenedor.Size = new System.Drawing.Size(163, 13);
            this.lblCantidadMaximoXContenedor.TabIndex = 63;
            this.lblCantidadMaximoXContenedor.Text = "Cantidad máxima X contenedor : ";
            // 
            // lblNumeroInicialContenedor
            // 
            this.lblNumeroInicialContenedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblNumeroInicialContenedor.AutoSize = true;
            this.lblNumeroInicialContenedor.Location = new System.Drawing.Point(43, 22);
            this.lblNumeroInicialContenedor.Name = "lblNumeroInicialContenedor";
            this.lblNumeroInicialContenedor.Size = new System.Drawing.Size(139, 13);
            this.lblNumeroInicialContenedor.TabIndex = 61;
            this.lblNumeroInicialContenedor.Text = "Numero inicial contenedor : ";
            // 
            // txtSeleccionarColumnaCalculoContenedor
            // 
            this.txtSeleccionarColumnaCalculoContenedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSeleccionarColumnaCalculoContenedor.Enabled = false;
            this.txtSeleccionarColumnaCalculoContenedor.Location = new System.Drawing.Point(237, 97);
            this.txtSeleccionarColumnaCalculoContenedor.Multiline = true;
            this.txtSeleccionarColumnaCalculoContenedor.Name = "txtSeleccionarColumnaCalculoContenedor";
            this.txtSeleccionarColumnaCalculoContenedor.Size = new System.Drawing.Size(303, 58);
            this.txtSeleccionarColumnaCalculoContenedor.TabIndex = 8;
            // 
            // lblCantidadMaximoXBolsaSeguridad
            // 
            this.lblCantidadMaximoXBolsaSeguridad.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCantidadMaximoXBolsaSeguridad.AutoSize = true;
            this.lblCantidadMaximoXBolsaSeguridad.Location = new System.Drawing.Point(43, 74);
            this.lblCantidadMaximoXBolsaSeguridad.Name = "lblCantidadMaximoXBolsaSeguridad";
            this.lblCantidadMaximoXBolsaSeguridad.Size = new System.Drawing.Size(183, 13);
            this.lblCantidadMaximoXBolsaSeguridad.TabIndex = 56;
            this.lblCantidadMaximoXBolsaSeguridad.Text = "Cantidad máxima X bolsa seguridad : ";
            // 
            // lblSeleccionarColumnaCalculoContenedor
            // 
            this.lblSeleccionarColumnaCalculoContenedor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSeleccionarColumnaCalculoContenedor.Location = new System.Drawing.Point(43, 102);
            this.lblSeleccionarColumnaCalculoContenedor.Name = "lblSeleccionarColumnaCalculoContenedor";
            this.lblSeleccionarColumnaCalculoContenedor.Size = new System.Drawing.Size(150, 31);
            this.lblSeleccionarColumnaCalculoContenedor.TabIndex = 58;
            this.lblSeleccionarColumnaCalculoContenedor.Text = "Seleccionar columnas archivo para calculo de contenedor :";
            // 
            // txtProcesoMensaje
            // 
            this.txtProcesoMensaje.Location = new System.Drawing.Point(416, 526);
            this.txtProcesoMensaje.Multiline = true;
            this.txtProcesoMensaje.Name = "txtProcesoMensaje";
            this.txtProcesoMensaje.Size = new System.Drawing.Size(241, 30);
            this.txtProcesoMensaje.TabIndex = 55;
            // 
            // FrmProcesarBiblia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(669, 568);
            this.Controls.Add(this.txtProcesoMensaje);
            this.Controls.Add(this.usrSeleccionarArchivoReversa);
            this.Controls.Add(this.gbxConfiguracionContenedor);
            this.Controls.Add(this.gbxConfiguracionActas);
            this.Controls.Add(this.btnProcesoBiblia);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmProcesarBiblia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Procesar Biblia";
            this.Load += new System.EventHandler(this.FrmProcesarBiblia_Load);
            this.gbxConfiguracionActas.ResumeLayout(false);
            this.gbxConfiguracionActas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSeleccionarColumnaCalculoActa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbxConfiguracionContenedor.ResumeLayout(false);
            this.gbxConfiguracionContenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxSeleccionarColumnaCalculoContenedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private WinFormsControlLibrary.usrSeleccionarArchivo usrSeleccionarArchivoReversa;
        private System.Windows.Forms.Button btnProcesoBiblia;
        private System.Windows.Forms.GroupBox gbxConfiguracionActas;
        private System.Windows.Forms.GroupBox gbxConfiguracionContenedor;
        private System.Windows.Forms.Label lblNumeroInicialActa;
        private System.Windows.Forms.Label lblTipoPrueba;
        private System.Windows.Forms.ComboBox cbxTipoPrueba;
        private System.Windows.Forms.TextBox txtSeleccionarColumnaCalculoActa;
        private System.Windows.Forms.Label lblSeleccionarColumnaCalculoActa;
        private System.Windows.Forms.Label lblNumeroInicialTulaVacia;
        private System.Windows.Forms.TextBox txtNumeroInicialTulaVacia;
        private System.Windows.Forms.Label lblNumeroInicialCajaVacia;
        private System.Windows.Forms.TextBox txtNumeroInicialCajaVacia;
        private System.Windows.Forms.Label lblElementos;
        private System.Windows.Forms.TextBox txtElementos;
        private System.Windows.Forms.Label lblCantidadMaximoXContenedor;
        private System.Windows.Forms.Label lblNumeroInicialContenedor;
        private System.Windows.Forms.TextBox txtSeleccionarColumnaCalculoContenedor;
        private System.Windows.Forms.Label lblCantidadMaximoXBolsaSeguridad;
        private System.Windows.Forms.Label lblSeleccionarColumnaCalculoContenedor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pbxSeleccionarColumnaCalculoActa;
        private System.Windows.Forms.PictureBox pbxSeleccionarColumnaCalculoContenedor;
        private WinFormsControlLibrary.usrNumeric usrNumeroInicialActa;
        private WinFormsControlLibrary.usrWhatThis usrAyuda;
        private WinFormsControlLibrary.usrNumeric usrCantidadMaximoXBolsaSeguridad;
        private WinFormsControlLibrary.usrNumeric usrCantidadMaximoXContenedorG;
        private WinFormsControlLibrary.usrNumeric usrNumeroInicialContenedor;
        private System.Windows.Forms.TextBox txtProcesoMensaje;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private WinFormsControlLibrary.usrNumeric usrCantidadMaximoXContenedorM;
    }
}