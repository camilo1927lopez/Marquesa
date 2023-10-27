namespace MarquesaReplenish.View
{
    partial class FrmEliminacionCargue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEliminacionCargue));
            this.btnEliminarCargue = new System.Windows.Forms.Button();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnEliminarCargue
            // 
            this.btnEliminarCargue.BackColor = System.Drawing.Color.Black;
            this.btnEliminarCargue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarCargue.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminarCargue.Location = new System.Drawing.Point(172, 147);
            this.btnEliminarCargue.Name = "btnEliminarCargue";
            this.btnEliminarCargue.Size = new System.Drawing.Size(150, 30);
            this.btnEliminarCargue.TabIndex = 25;
            this.btnEliminarCargue.Text = "Eliminar Cargue";
            this.btnEliminarCargue.UseVisualStyleBackColor = false;
            this.btnEliminarCargue.Click += new System.EventHandler(this.btnEliminarCargue_Click);
            // 
            // lblSeleccionarPruebas
            // 
            this.lblSeleccionarPruebas.AutoSize = true;
            this.lblSeleccionarPruebas.Location = new System.Drawing.Point(14, 68);
            this.lblSeleccionarPruebas.Name = "lblSeleccionarPruebas";
            this.lblSeleccionarPruebas.Size = new System.Drawing.Size(111, 13);
            this.lblSeleccionarPruebas.TabIndex = 24;
            this.lblSeleccionarPruebas.Text = "Seleccionar Pruebas: ";
            // 
            // cbxSeleccionarPruebas
            // 
            this.cbxSeleccionarPruebas.FormattingEnabled = true;
            this.cbxSeleccionarPruebas.Location = new System.Drawing.Point(193, 65);
            this.cbxSeleccionarPruebas.Name = "cbxSeleccionarPruebas";
            this.cbxSeleccionarPruebas.Size = new System.Drawing.Size(279, 21);
            this.cbxSeleccionarPruebas.TabIndex = 23;
            this.cbxSeleccionarPruebas.SelectionChangeCommitted += new System.EventHandler(this.cbxSeleccionarPruebas_SelectionChangeCommitted);
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(14, 29);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(104, 13);
            this.lblCliente.TabIndex = 22;
            this.lblCliente.Text = "Seleccionar Cliente: ";
            // 
            // cbxCLientes
            // 
            this.cbxCLientes.FormattingEnabled = true;
            this.cbxCLientes.Location = new System.Drawing.Point(193, 26);
            this.cbxCLientes.Name = "cbxCLientes";
            this.cbxCLientes.Size = new System.Drawing.Size(279, 21);
            this.cbxCLientes.TabIndex = 21;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // FrmEliminacionCargue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(487, 212);
            this.Controls.Add(this.btnEliminarCargue);
            this.Controls.Add(this.lblSeleccionarPruebas);
            this.Controls.Add(this.cbxSeleccionarPruebas);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.cbxCLientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEliminacionCargue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminación Cargue";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminarCargue;
        private System.Windows.Forms.Label lblSeleccionarPruebas;
        private System.Windows.Forms.ComboBox cbxSeleccionarPruebas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCLientes;
    }
}