namespace MarquesaReplenish.View
{
    partial class Principla
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principla));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gestionUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmCrearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmEditarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmListaUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmProcesarBibliaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmCargarArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionRepuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmCreacionCicloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmEliminacionCargueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generacionRepuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmIngresarRepuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarRepuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmAuditoriaRepuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmIntercaleRepuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmLiberarInstitucionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmTrazabilidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionUsuarioToolStripMenuItem,
            this.FrmProcesarBibliaToolStripMenuItem,
            this.FrmCargarArchivoToolStripMenuItem,
            this.configuracionRepuestoToolStripMenuItem,
            this.generacionRepuestoToolStripMenuItem,
            this.FrmAuditoriaRepuestoToolStripMenuItem,
            this.FrmIntercaleRepuestoToolStripMenuItem,
            this.FrmLiberarInstitucionToolStripMenuItem,
            this.FrmTrazabilidadToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1211, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gestionUsuarioToolStripMenuItem
            // 
            this.gestionUsuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FrmCrearUsuarioToolStripMenuItem,
            this.FrmEditarUsuarioToolStripMenuItem,
            this.FrmListaUsuarioToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem});
            this.gestionUsuarioToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.users_solid;
            this.gestionUsuarioToolStripMenuItem.Name = "gestionUsuarioToolStripMenuItem";
            this.gestionUsuarioToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.gestionUsuarioToolStripMenuItem.Text = "Gestion Usuario";
            // 
            // FrmCrearUsuarioToolStripMenuItem
            // 
            this.FrmCrearUsuarioToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.add_user;
            this.FrmCrearUsuarioToolStripMenuItem.Name = "FrmCrearUsuarioToolStripMenuItem";
            this.FrmCrearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.FrmCrearUsuarioToolStripMenuItem.Text = "Crear Usuario";
            this.FrmCrearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.crearUsuarioToolStripMenuItem_Click);
            // 
            // FrmEditarUsuarioToolStripMenuItem
            // 
            this.FrmEditarUsuarioToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.edit;
            this.FrmEditarUsuarioToolStripMenuItem.Name = "FrmEditarUsuarioToolStripMenuItem";
            this.FrmEditarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.FrmEditarUsuarioToolStripMenuItem.Text = "Editar Usuario";
            this.FrmEditarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.editarUsuarioToolStripMenuItem_Click);
            // 
            // FrmListaUsuarioToolStripMenuItem
            // 
            this.FrmListaUsuarioToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.user;
            this.FrmListaUsuarioToolStripMenuItem.Name = "FrmListaUsuarioToolStripMenuItem";
            this.FrmListaUsuarioToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.FrmListaUsuarioToolStripMenuItem.Text = "Lista de Usuarios";
            this.FrmListaUsuarioToolStripMenuItem.Click += new System.EventHandler(this.FrmListaUsuarioToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.cerrar_sesion;
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // FrmProcesarBibliaToolStripMenuItem
            // 
            this.FrmProcesarBibliaToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.automatizacion;
            this.FrmProcesarBibliaToolStripMenuItem.Name = "FrmProcesarBibliaToolStripMenuItem";
            this.FrmProcesarBibliaToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.FrmProcesarBibliaToolStripMenuItem.Text = "Procesar Biblia";
            this.FrmProcesarBibliaToolStripMenuItem.Click += new System.EventHandler(this.FrmProcesarBibliaToolStripMenuItem_Click);
            // 
            // FrmCargarArchivoToolStripMenuItem
            // 
            this.FrmCargarArchivoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.upload_file;
            this.FrmCargarArchivoToolStripMenuItem.Name = "FrmCargarArchivoToolStripMenuItem";
            this.FrmCargarArchivoToolStripMenuItem.Size = new System.Drawing.Size(114, 20);
            this.FrmCargarArchivoToolStripMenuItem.Text = "Cargar Archivo";
            this.FrmCargarArchivoToolStripMenuItem.Click += new System.EventHandler(this.cargarArchivoToolStripMenuItem_Click);
            // 
            // configuracionRepuestoToolStripMenuItem
            // 
            this.configuracionRepuestoToolStripMenuItem.AutoToolTip = true;
            this.configuracionRepuestoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FrmCreacionCicloToolStripMenuItem,
            this.FrmEliminacionCargueToolStripMenuItem});
            this.configuracionRepuestoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.three_gears_of_configuration_tools;
            this.configuracionRepuestoToolStripMenuItem.Name = "configuracionRepuestoToolStripMenuItem";
            this.configuracionRepuestoToolStripMenuItem.Size = new System.Drawing.Size(163, 20);
            this.configuracionRepuestoToolStripMenuItem.Text = "Configuración Repuesto";
            // 
            // FrmCreacionCicloToolStripMenuItem
            // 
            this.FrmCreacionCicloToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.setting;
            this.FrmCreacionCicloToolStripMenuItem.Name = "FrmCreacionCicloToolStripMenuItem";
            this.FrmCreacionCicloToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.FrmCreacionCicloToolStripMenuItem.Text = "Creación Ciclo";
            this.FrmCreacionCicloToolStripMenuItem.Click += new System.EventHandler(this.FrmCreacionCicloToolStripMenuItem_Click);
            // 
            // FrmEliminacionCargueToolStripMenuItem
            // 
            this.FrmEliminacionCargueToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.eliminar__2_;
            this.FrmEliminacionCargueToolStripMenuItem.Name = "FrmEliminacionCargueToolStripMenuItem";
            this.FrmEliminacionCargueToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.FrmEliminacionCargueToolStripMenuItem.Text = "Eliminacion Cargue";
            this.FrmEliminacionCargueToolStripMenuItem.Click += new System.EventHandler(this.FrmEliminacionCargueToolStripMenuItem_Click);
            // 
            // generacionRepuestoToolStripMenuItem
            // 
            this.generacionRepuestoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FrmIngresarRepuestoToolStripMenuItem,
            this.eliminarRepuestoToolStripMenuItem});
            this.generacionRepuestoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.insertar__1_;
            this.generacionRepuestoToolStripMenuItem.Name = "generacionRepuestoToolStripMenuItem";
            this.generacionRepuestoToolStripMenuItem.Size = new System.Drawing.Size(147, 20);
            this.generacionRepuestoToolStripMenuItem.Text = "Generacion Repuesto";
            // 
            // FrmIngresarRepuestoToolStripMenuItem
            // 
            this.FrmIngresarRepuestoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.insertar__2_;
            this.FrmIngresarRepuestoToolStripMenuItem.Name = "FrmIngresarRepuestoToolStripMenuItem";
            this.FrmIngresarRepuestoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.FrmIngresarRepuestoToolStripMenuItem.Text = "Ingresar Repuesto";
            this.FrmIngresarRepuestoToolStripMenuItem.Click += new System.EventHandler(this.FrmIngresarRepuestoToolStripMenuItem_Click);
            // 
            // eliminarRepuestoToolStripMenuItem
            // 
            this.eliminarRepuestoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.eliminar__2_;
            this.eliminarRepuestoToolStripMenuItem.Name = "eliminarRepuestoToolStripMenuItem";
            this.eliminarRepuestoToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.eliminarRepuestoToolStripMenuItem.Text = "Eliminar Repuesto";
            // 
            // FrmAuditoriaRepuestoToolStripMenuItem
            // 
            this.FrmAuditoriaRepuestoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.auditoria__1_;
            this.FrmAuditoriaRepuestoToolStripMenuItem.Name = "FrmAuditoriaRepuestoToolStripMenuItem";
            this.FrmAuditoriaRepuestoToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.FrmAuditoriaRepuestoToolStripMenuItem.Text = "Auditoria Repuesto";
            this.FrmAuditoriaRepuestoToolStripMenuItem.Click += new System.EventHandler(this.FrmAuditoriaRepuestoToolStripMenuItem_Click);
            // 
            // FrmIntercaleRepuestoToolStripMenuItem
            // 
            this.FrmIntercaleRepuestoToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.capas;
            this.FrmIntercaleRepuestoToolStripMenuItem.Name = "FrmIntercaleRepuestoToolStripMenuItem";
            this.FrmIntercaleRepuestoToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.FrmIntercaleRepuestoToolStripMenuItem.Text = "Intercale Repuesto";
            this.FrmIntercaleRepuestoToolStripMenuItem.Click += new System.EventHandler(this.FrmIntercaleRepuestoToolStripMenuItem_Click);
            // 
            // FrmLiberarInstitucionToolStripMenuItem
            // 
            this.FrmLiberarInstitucionToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.debilidad;
            this.FrmLiberarInstitucionToolStripMenuItem.Name = "FrmLiberarInstitucionToolStripMenuItem";
            this.FrmLiberarInstitucionToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.FrmLiberarInstitucionToolStripMenuItem.Text = "Liberar Institución";
            this.FrmLiberarInstitucionToolStripMenuItem.Click += new System.EventHandler(this.FrmLiberarInstitucionToolStripMenuItem_Click);
            // 
            // FrmTrazabilidadToolStripMenuItem
            // 
            this.FrmTrazabilidadToolStripMenuItem.Image = global::MarquesaReplenish.Properties.Resources.trazabilidad;
            this.FrmTrazabilidadToolStripMenuItem.Name = "FrmTrazabilidadToolStripMenuItem";
            this.FrmTrazabilidadToolStripMenuItem.Size = new System.Drawing.Size(149, 20);
            this.FrmTrazabilidadToolStripMenuItem.Text = "Trazabilidad Repuesto";
            this.FrmTrazabilidadToolStripMenuItem.Click += new System.EventHandler(this.trazabilidadRepuestoToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusUsuario,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 639);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1211, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusUsuario
            // 
            this.lblStatusUsuario.Name = "lblStatusUsuario";
            this.lblStatusUsuario.Size = new System.Drawing.Size(100, 17);
            this.lblStatusUsuario.Text = "UsuarioLogueado";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(18, 17);
            this.toolStripStatusLabel3.Text = " \\ ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.SkyBlue;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusLabel1.Text = "V 0.0.0.4 17/03/2022";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // Principla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1211, 661);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principla";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principla_FormClosing);
            this.Load += new System.EventHandler(this.Principla_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem gestionUsuarioToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem FrmCrearUsuarioToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem FrmEditarUsuarioToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem FrmListaUsuarioToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem FrmCargarArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionRepuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrmCreacionCicloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrmEliminacionCargueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generacionRepuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrmIngresarRepuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarRepuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrmAuditoriaRepuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrmIntercaleRepuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FrmLiberarInstitucionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem FrmTrazabilidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusUsuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripMenuItem FrmProcesarBibliaToolStripMenuItem;
    }
}