namespace MarquesaReplenish.View
{
    partial class FrmValideIntercale
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvValideIntercale = new System.Windows.Forms.DataGridView();
            this.txtCodigoBarrasHojaRespuesta = new System.Windows.Forms.TextBox();
            this.lblCodigoBarrasHojaRespuesta = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.IdDetalleRepuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoCuadernillo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoHojaRespuesta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bloque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSalon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sesion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValideIntercale)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvValideIntercale
            // 
            this.dgvValideIntercale.AllowUserToAddRows = false;
            this.dgvValideIntercale.AllowUserToDeleteRows = false;
            this.dgvValideIntercale.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValideIntercale.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDetalleRepuesto,
            this.CodigoCuadernillo,
            this.CodigoHojaRespuesta,
            this.CodigoSitio,
            this.NombreSitio,
            this.CodigoSalon,
            this.Bloque,
            this.NombreSalon,
            this.Sesion,
            this.IdCons,
            this.Estado});
            this.dgvValideIntercale.Location = new System.Drawing.Point(12, 12);
            this.dgvValideIntercale.Name = "dgvValideIntercale";
            this.dgvValideIntercale.ReadOnly = true;
            this.dgvValideIntercale.Size = new System.Drawing.Size(1076, 246);
            this.dgvValideIntercale.TabIndex = 1;
            // 
            // txtCodigoBarrasHojaRespuesta
            // 
            this.txtCodigoBarrasHojaRespuesta.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(221, 264);
            this.txtCodigoBarrasHojaRespuesta.Name = "txtCodigoBarrasHojaRespuesta";
            this.txtCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(671, 20);
            this.txtCodigoBarrasHojaRespuesta.TabIndex = 0;
            this.txtCodigoBarrasHojaRespuesta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarrasHojaRespuesta_KeyPress);
            // 
            // lblCodigoBarrasHojaRespuesta
            // 
            this.lblCodigoBarrasHojaRespuesta.AutoSize = true;
            this.lblCodigoBarrasHojaRespuesta.Location = new System.Drawing.Point(13, 267);
            this.lblCodigoBarrasHojaRespuesta.Name = "lblCodigoBarrasHojaRespuesta";
            this.lblCodigoBarrasHojaRespuesta.Size = new System.Drawing.Size(202, 13);
            this.lblCodigoBarrasHojaRespuesta.TabIndex = 66;
            this.lblCodigoBarrasHojaRespuesta.Text = "Código de barras de Hoja de Respuesta: ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Brown;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(898, 264);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 30);
            this.btnCancelar.TabIndex = 68;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // IdDetalleRepuesto
            // 
            this.IdDetalleRepuesto.HeaderText = "IdDetalleRepuesto";
            this.IdDetalleRepuesto.Name = "IdDetalleRepuesto";
            this.IdDetalleRepuesto.ReadOnly = true;
            this.IdDetalleRepuesto.Visible = false;
            // 
            // CodigoCuadernillo
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.CodigoCuadernillo.DefaultCellStyle = dataGridViewCellStyle11;
            this.CodigoCuadernillo.HeaderText = "CÓDIGO CUADERNILLO";
            this.CodigoCuadernillo.Name = "CodigoCuadernillo";
            this.CodigoCuadernillo.ReadOnly = true;
            this.CodigoCuadernillo.Width = 170;
            // 
            // CodigoHojaRespuesta
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.CodigoHojaRespuesta.DefaultCellStyle = dataGridViewCellStyle12;
            this.CodigoHojaRespuesta.HeaderText = "CÓDIGO HOJA RESPUESTA";
            this.CodigoHojaRespuesta.Name = "CodigoHojaRespuesta";
            this.CodigoHojaRespuesta.ReadOnly = true;
            this.CodigoHojaRespuesta.Width = 170;
            // 
            // CodigoSitio
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.CodigoSitio.DefaultCellStyle = dataGridViewCellStyle13;
            this.CodigoSitio.HeaderText = "CÓDIGO SITIO";
            this.CodigoSitio.Name = "CodigoSitio";
            this.CodigoSitio.ReadOnly = true;
            // 
            // NombreSitio
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.NombreSitio.DefaultCellStyle = dataGridViewCellStyle14;
            this.NombreSitio.HeaderText = "NOMBRE SITIO";
            this.NombreSitio.Name = "NombreSitio";
            this.NombreSitio.ReadOnly = true;
            // 
            // CodigoSalon
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.CodigoSalon.DefaultCellStyle = dataGridViewCellStyle15;
            this.CodigoSalon.HeaderText = "CÓDIGO SALÓN";
            this.CodigoSalon.Name = "CodigoSalon";
            this.CodigoSalon.ReadOnly = true;
            // 
            // Bloque
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Bloque.DefaultCellStyle = dataGridViewCellStyle16;
            this.Bloque.HeaderText = "BLOQUE";
            this.Bloque.Name = "Bloque";
            this.Bloque.ReadOnly = true;
            this.Bloque.Visible = false;
            this.Bloque.Width = 50;
            // 
            // NombreSalon
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.NombreSalon.DefaultCellStyle = dataGridViewCellStyle17;
            this.NombreSalon.HeaderText = "NOMBRE SALÓN";
            this.NombreSalon.Name = "NombreSalon";
            this.NombreSalon.ReadOnly = true;
            // 
            // Sesion
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Sesion.DefaultCellStyle = dataGridViewCellStyle18;
            this.Sesion.HeaderText = "SESIÓN";
            this.Sesion.Name = "Sesion";
            this.Sesion.ReadOnly = true;
            this.Sesion.Width = 60;
            // 
            // IdCons
            // 
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.White;
            this.IdCons.DefaultCellStyle = dataGridViewCellStyle19;
            this.IdCons.HeaderText = "CONS";
            this.IdCons.Name = "IdCons";
            this.IdCons.ReadOnly = true;
            // 
            // Estado
            // 
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black;
            this.Estado.DefaultCellStyle = dataGridViewCellStyle20;
            this.Estado.HeaderText = "ESTADO";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 120;
            // 
            // FrmValideIntercale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(1100, 300);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCodigoBarrasHojaRespuesta);
            this.Controls.Add(this.lblCodigoBarrasHojaRespuesta);
            this.Controls.Add(this.dgvValideIntercale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmValideIntercale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmValideIntercale";
            this.Load += new System.EventHandler(this.FrmValideIntercale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValideIntercale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCodigoBarrasHojaRespuesta;
        public System.Windows.Forms.DataGridView dgvValideIntercale;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.TextBox txtCodigoBarrasHojaRespuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDetalleRepuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCuadernillo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoHojaRespuesta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bloque;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSalon;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCons;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
    }
}