namespace MarquesaReplenish.View
{
    partial class FrmSelectColumnTablat
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
            this.dgvSelectColumn = new System.Windows.Forms.DataGridView();
            this.txtColumnasSeleccionadas = new System.Windows.Forms.TextBox();
            this.lblColumnaSeleccionadas = new System.Windows.Forms.Label();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSelectColumn
            // 
            this.dgvSelectColumn.AllowUserToAddRows = false;
            this.dgvSelectColumn.AllowUserToDeleteRows = false;
            this.dgvSelectColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSelectColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectColumn.Location = new System.Drawing.Point(12, 12);
            this.dgvSelectColumn.Name = "dgvSelectColumn";
            this.dgvSelectColumn.ReadOnly = true;
            this.dgvSelectColumn.Size = new System.Drawing.Size(934, 167);
            this.dgvSelectColumn.TabIndex = 0;
            this.dgvSelectColumn.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectColumn_CellClick);
            this.dgvSelectColumn.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSelectColumn_CellContentClick);
            // 
            // txtColumnasSeleccionadas
            // 
            this.txtColumnasSeleccionadas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtColumnasSeleccionadas.Enabled = false;
            this.txtColumnasSeleccionadas.Location = new System.Drawing.Point(178, 185);
            this.txtColumnasSeleccionadas.Multiline = true;
            this.txtColumnasSeleccionadas.Name = "txtColumnasSeleccionadas";
            this.txtColumnasSeleccionadas.Size = new System.Drawing.Size(613, 41);
            this.txtColumnasSeleccionadas.TabIndex = 1;
            // 
            // lblColumnaSeleccionadas
            // 
            this.lblColumnaSeleccionadas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblColumnaSeleccionadas.AutoSize = true;
            this.lblColumnaSeleccionadas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumnaSeleccionadas.Location = new System.Drawing.Point(12, 188);
            this.lblColumnaSeleccionadas.Name = "lblColumnaSeleccionadas";
            this.lblColumnaSeleccionadas.Size = new System.Drawing.Size(160, 13);
            this.lblColumnaSeleccionadas.TabIndex = 2;
            this.lblColumnaSeleccionadas.Text = "Columnas Seleccionadas : ";
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTerminar.BackColor = System.Drawing.Color.Black;
            this.btnTerminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTerminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTerminar.Location = new System.Drawing.Point(12, 204);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(150, 22);
            this.btnTerminar.TabIndex = 14;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.btnTerminar_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.checkBox1.Location = new System.Drawing.Point(797, 188);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(149, 38);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Incluir ultima columna como agrupado";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox1_CheckStateChanged);
            // 
            // FrmSelectColumnTablat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 238);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnTerminar);
            this.Controls.Add(this.lblColumnaSeleccionadas);
            this.Controls.Add(this.txtColumnasSeleccionadas);
            this.Controls.Add(this.dgvSelectColumn);
            this.MinimizeBox = false;
            this.Name = "FrmSelectColumnTablat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Seleccionar Columnas ";
            this.Load += new System.EventHandler(this.FrmSelectColumnTablat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectColumn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvSelectColumn;
        private System.Windows.Forms.TextBox txtColumnasSeleccionadas;
        private System.Windows.Forms.Label lblColumnaSeleccionadas;
        private System.Windows.Forms.Button btnTerminar;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}