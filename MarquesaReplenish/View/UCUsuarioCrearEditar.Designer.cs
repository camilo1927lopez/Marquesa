namespace MarquesaReplenish.View
{
    partial class UCUsuarioCrearEditar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxCrearEditarUsuario = new System.Windows.Forms.GroupBox();
            this.usrDocumento = new WinFormsControlLibrary.usrNumeric();
            this.btnGuardarEditar = new System.Windows.Forms.Button();
            this.txtClaveConfirmar = new System.Windows.Forms.TextBox();
            this.lblClaveConfirmar = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lblClave = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cbxEstado = new System.Windows.Forms.ComboBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cbxRol = new System.Windows.Forms.ComboBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.gbxCrearEditarUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCrearEditarUsuario
            // 
            this.gbxCrearEditarUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbxCrearEditarUsuario.AutoSize = true;
            this.gbxCrearEditarUsuario.Controls.Add(this.usrDocumento);
            this.gbxCrearEditarUsuario.Controls.Add(this.btnGuardarEditar);
            this.gbxCrearEditarUsuario.Controls.Add(this.txtClaveConfirmar);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblClaveConfirmar);
            this.gbxCrearEditarUsuario.Controls.Add(this.txtClave);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblClave);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblEstado);
            this.gbxCrearEditarUsuario.Controls.Add(this.cbxEstado);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblRol);
            this.gbxCrearEditarUsuario.Controls.Add(this.cbxRol);
            this.gbxCrearEditarUsuario.Controls.Add(this.txtUsuario);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblUsuario);
            this.gbxCrearEditarUsuario.Controls.Add(this.txtApellido);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblApellido);
            this.gbxCrearEditarUsuario.Controls.Add(this.txtNombre);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblNombre);
            this.gbxCrearEditarUsuario.Controls.Add(this.lblDocumento);
            this.gbxCrearEditarUsuario.Location = new System.Drawing.Point(0, 0);
            this.gbxCrearEditarUsuario.Name = "gbxCrearEditarUsuario";
            this.gbxCrearEditarUsuario.Size = new System.Drawing.Size(394, 323);
            this.gbxCrearEditarUsuario.TabIndex = 2;
            this.gbxCrearEditarUsuario.TabStop = false;
            // 
            // usrDocumento
            // 
            this.usrDocumento.DefaultValue = 0F;
            this.usrDocumento.IsEnabled = true;
            this.usrDocumento.Location = new System.Drawing.Point(150, 50);
            this.usrDocumento.Mascara = "#,##0";
            this.usrDocumento.MaxLength = 32767;
            this.usrDocumento.Name = "usrDocumento";
            this.usrDocumento.PermiteDecimales = false;
            this.usrDocumento.ShortcutsEnabled = true;
            this.usrDocumento.Size = new System.Drawing.Size(223, 20);
            this.usrDocumento.TabIndex = 0;
            this.usrDocumento.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnGuardarEditar
            // 
            this.btnGuardarEditar.BackColor = System.Drawing.Color.Black;
            this.btnGuardarEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarEditar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGuardarEditar.Location = new System.Drawing.Point(130, 14);
            this.btnGuardarEditar.Name = "btnGuardarEditar";
            this.btnGuardarEditar.Size = new System.Drawing.Size(150, 30);
            this.btnGuardarEditar.TabIndex = 16;
            this.btnGuardarEditar.UseVisualStyleBackColor = false;
            this.btnGuardarEditar.Visible = false;
            this.btnGuardarEditar.Click += new System.EventHandler(this.btnGuardarEditar_Click);
            // 
            // txtClaveConfirmar
            // 
            this.txtClaveConfirmar.Location = new System.Drawing.Point(150, 276);
            this.txtClaveConfirmar.Name = "txtClaveConfirmar";
            this.txtClaveConfirmar.PasswordChar = '*';
            this.txtClaveConfirmar.Size = new System.Drawing.Size(223, 20);
            this.txtClaveConfirmar.TabIndex = 7;
            // 
            // lblClaveConfirmar
            // 
            this.lblClaveConfirmar.Location = new System.Drawing.Point(23, 279);
            this.lblClaveConfirmar.Name = "lblClaveConfirmar";
            this.lblClaveConfirmar.Size = new System.Drawing.Size(121, 17);
            this.lblClaveConfirmar.TabIndex = 14;
            this.lblClaveConfirmar.Text = "Confirmar Contraseña";
            this.lblClaveConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(150, 242);
            this.txtClave.Name = "txtClave";
            this.txtClave.PasswordChar = '*';
            this.txtClave.Size = new System.Drawing.Size(223, 20);
            this.txtClave.TabIndex = 6;
            // 
            // lblClave
            // 
            this.lblClave.Location = new System.Drawing.Point(23, 245);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(121, 17);
            this.lblClave.TabIndex = 12;
            this.lblClave.Text = "Contraseña: ";
            this.lblClave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(23, 210);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(121, 17);
            this.lblEstado.TabIndex = 11;
            this.lblEstado.Text = "Estado: ";
            this.lblEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxEstado
            // 
            this.cbxEstado.FormattingEnabled = true;
            this.cbxEstado.Location = new System.Drawing.Point(150, 206);
            this.cbxEstado.Name = "cbxEstado";
            this.cbxEstado.Size = new System.Drawing.Size(223, 21);
            this.cbxEstado.TabIndex = 5;
            // 
            // lblRol
            // 
            this.lblRol.Location = new System.Drawing.Point(23, 178);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(121, 17);
            this.lblRol.TabIndex = 9;
            this.lblRol.Text = "Rol";
            this.lblRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxRol
            // 
            this.cbxRol.FormattingEnabled = true;
            this.cbxRol.Location = new System.Drawing.Point(150, 174);
            this.cbxRol.Name = "cbxRol";
            this.cbxRol.Size = new System.Drawing.Size(223, 21);
            this.cbxRol.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(150, 141);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(223, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(23, 144);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(121, 17);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario: ";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(150, 110);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(223, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // lblApellido
            // 
            this.lblApellido.Location = new System.Drawing.Point(23, 113);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(121, 17);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido:";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(150, 79);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(223, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Location = new System.Drawing.Point(23, 82);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(121, 17);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDocumento
            // 
            this.lblDocumento.Location = new System.Drawing.Point(23, 50);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(121, 17);
            this.lblDocumento.TabIndex = 0;
            this.lblDocumento.Text = "Documento:";
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UCUsuarioCrearEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbxCrearEditarUsuario);
            this.Margin = new System.Windows.Forms.Padding(10);
            this.Name = "UCUsuarioCrearEditar";
            this.Size = new System.Drawing.Size(400, 400);
            this.gbxCrearEditarUsuario.ResumeLayout(false);
            this.gbxCrearEditarUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCrearEditarUsuario;
        private System.Windows.Forms.TextBox txtClaveConfirmar;
        private System.Windows.Forms.Label lblClaveConfirmar;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbxEstado;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cbxRol;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.Button btnGuardarEditar;
        private WinFormsControlLibrary.usrNumeric usrDocumento;
    }
}
