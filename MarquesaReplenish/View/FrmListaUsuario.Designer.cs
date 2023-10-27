namespace MarquesaReplenish.View
{
    partial class FrmListaUsuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaUsuario));
            this.dgvListaUsuarios = new System.Windows.Forms.DataGridView();
            this.lblCantidadDeUsuarios = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.usrBuscar = new WinFormsControlLibrary.usrNumeric();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListaUsuarios
            // 
            this.dgvListaUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListaUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaUsuarios.Location = new System.Drawing.Point(12, 41);
            this.dgvListaUsuarios.Name = "dgvListaUsuarios";
            this.dgvListaUsuarios.Size = new System.Drawing.Size(918, 379);
            this.dgvListaUsuarios.TabIndex = 0;
            this.dgvListaUsuarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListaUsuarios_CellClick);
            // 
            // lblCantidadDeUsuarios
            // 
            this.lblCantidadDeUsuarios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidadDeUsuarios.AutoSize = true;
            this.lblCantidadDeUsuarios.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadDeUsuarios.Location = new System.Drawing.Point(12, 433);
            this.lblCantidadDeUsuarios.Name = "lblCantidadDeUsuarios";
            this.lblCantidadDeUsuarios.Size = new System.Drawing.Size(0, 19);
            this.lblCantidadDeUsuarios.TabIndex = 6;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.BackColor = System.Drawing.Color.Black;
            this.btnIngresar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnIngresar.Image = ((System.Drawing.Image)(resources.GetObject("btnIngresar.Image")));
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(780, 5);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(150, 30);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Crear Usuarios";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(326, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(13, 13);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(104, 13);
            this.lblBuscar.TabIndex = 9;
            this.lblBuscar.Text = "Buscar Documento: ";
            // 
            // usrBuscar
            // 
            this.usrBuscar.DefaultValue = 0F;
            this.usrBuscar.IsEnabled = true;
            this.usrBuscar.Location = new System.Drawing.Point(123, 10);
            this.usrBuscar.Mascara = "#,##0";
            this.usrBuscar.MaxLength = 32767;
            this.usrBuscar.Name = "usrBuscar";
            this.usrBuscar.PermiteDecimales = false;
            this.usrBuscar.ShortcutsEnabled = true;
            this.usrBuscar.Size = new System.Drawing.Size(197, 20);
            this.usrBuscar.TabIndex = 10;
            this.usrBuscar.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.usrBuscar.KeyPressed += new System.Windows.Forms.KeyPressEventHandler(this.usrBuscar_KeyPressed);
            // 
            // FrmListaUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(942, 461);
            this.Controls.Add(this.usrBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblCantidadDeUsuarios);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.dgvListaUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmListaUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Usuarios";
            this.Load += new System.EventHandler(this.FrmListaUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListaUsuarios;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblCantidadDeUsuarios;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblBuscar;
        private WinFormsControlLibrary.usrNumeric usrBuscar;
    }
}