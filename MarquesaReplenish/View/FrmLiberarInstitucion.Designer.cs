
namespace MarquesaReplenish.View
{
    partial class FrmLiberarInstitucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLiberarInstitucion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInstitucion = new System.Windows.Forms.TextBox();
            this.lblCiclo = new System.Windows.Forms.Label();
            this.cbxCiclos = new System.Windows.Forms.ComboBox();
            this.btnLiberarInstitucion = new System.Windows.Forms.Button();
            this.lblInstitucion = new System.Windows.Forms.Label();
            this.lblSeleccionarPruebas = new System.Windows.Forms.Label();
            this.cbxSeleccionarPruebas = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cbxCLientes = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtInstitucion);
            this.groupBox1.Controls.Add(this.lblCiclo);
            this.groupBox1.Controls.Add(this.cbxCiclos);
            this.groupBox1.Controls.Add(this.btnLiberarInstitucion);
            this.groupBox1.Controls.Add(this.lblInstitucion);
            this.groupBox1.Controls.Add(this.lblSeleccionarPruebas);
            this.groupBox1.Controls.Add(this.cbxSeleccionarPruebas);
            this.groupBox1.Controls.Add(this.lblCliente);
            this.groupBox1.Controls.Add(this.cbxCLientes);
            this.groupBox1.Location = new System.Drawing.Point(87, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 238);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar Información";
            // 
            // txtInstitucion
            // 
            this.txtInstitucion.Location = new System.Drawing.Point(190, 151);
            this.txtInstitucion.Name = "txtInstitucion";
            this.txtInstitucion.Size = new System.Drawing.Size(279, 20);
            this.txtInstitucion.TabIndex = 51;
            this.txtInstitucion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtInstitucion_KeyPress);
            // 
            // lblCiclo
            // 
            this.lblCiclo.AutoSize = true;
            this.lblCiclo.Location = new System.Drawing.Point(11, 112);
            this.lblCiclo.Name = "lblCiclo";
            this.lblCiclo.Size = new System.Drawing.Size(44, 13);
            this.lblCiclo.TabIndex = 50;
            this.lblCiclo.Text = "Ciclos : ";
            // 
            // cbxCiclos
            // 
            this.cbxCiclos.FormattingEnabled = true;
            this.cbxCiclos.Location = new System.Drawing.Point(190, 109);
            this.cbxCiclos.Name = "cbxCiclos";
            this.cbxCiclos.Size = new System.Drawing.Size(279, 21);
            this.cbxCiclos.TabIndex = 49;
            // 
            // btnLiberarInstitucion
            // 
            this.btnLiberarInstitucion.BackColor = System.Drawing.Color.Black;
            this.btnLiberarInstitucion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiberarInstitucion.ForeColor = System.Drawing.SystemColors.Control;
            this.btnLiberarInstitucion.Location = new System.Drawing.Point(281, 186);
            this.btnLiberarInstitucion.Name = "btnLiberarInstitucion";
            this.btnLiberarInstitucion.Size = new System.Drawing.Size(188, 30);
            this.btnLiberarInstitucion.TabIndex = 48;
            this.btnLiberarInstitucion.Text = "Liberar Institución";
            this.btnLiberarInstitucion.UseVisualStyleBackColor = false;
            this.btnLiberarInstitucion.Click += new System.EventHandler(this.btnLiberarInstitucion_Click);
            // 
            // lblInstitucion
            // 
            this.lblInstitucion.AutoSize = true;
            this.lblInstitucion.Location = new System.Drawing.Point(11, 154);
            this.lblInstitucion.Name = "lblInstitucion";
            this.lblInstitucion.Size = new System.Drawing.Size(61, 13);
            this.lblInstitucion.TabIndex = 47;
            this.lblInstitucion.Text = "Institución :";
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
            this.cbxSeleccionarPruebas.TabIndex = 2;
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
            this.cbxCLientes.TabIndex = 1;
            this.cbxCLientes.SelectionChangeCommitted += new System.EventHandler(this.cbxCLientes_SelectionChangeCommitted);
            // 
            // FrmLiberarInstitucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(655, 352);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLiberarInstitucion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liberar Institución";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSeleccionarPruebas;
        private System.Windows.Forms.ComboBox cbxSeleccionarPruebas;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cbxCLientes;
        private System.Windows.Forms.Label lblInstitucion;
        private System.Windows.Forms.Button btnLiberarInstitucion;
        private System.Windows.Forms.Label lblCiclo;
        private System.Windows.Forms.ComboBox cbxCiclos;
        private System.Windows.Forms.TextBox txtInstitucion;
    }
}