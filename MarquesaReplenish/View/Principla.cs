using BDManager;
using Functions;
using Global;
using MarquesaReplenish.Helpers;
using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesaReplenish.View
{
    public partial class Principla : ClaseBase
    {
        private FrmCrearUsuario _frmCrearUsuario = null;
        private FrmEditarUsuario _frmEditarUsuario = null;
        private FrmListaUsuario _frmListaUsuario = null;
        private FrmCargarArchivo _frmCargarArchivo = null;
        private FrmCreacionCiclo _frmCreacionCiclo = null;
        private FrmEliminacionCargue _frmEliminacionCargue = null;
        private FrmIngresarRepuesto _frmIngresarRepuesto = null;
        private FrmAuditoriaRepuesto _frmAuditoriaRepuesto = null;
        private FrmIntercaleRepuesto _frmIntercaleRepuesto = null;
        private FrmLiberarInstitucion _frmLiberarInstitucion = null;
        private FrmTrazabilidad _frmTrazabilidadRepuesto = null;
        private FrmProcesarBiblia _frmProcesarBiblia = null;
        

        public Guid GuidAplicacion { get; set; }
        public string strAmbienteEjecucion { get; set; }
        public Principla(TblUsuarioModel usuarioModel, TblRolModel rolModel)
        {
            this.usuarioModel = usuarioModel;
            this.rolModel = rolModel;
            InitializeComponent();
        }
        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCrearUsuario();
        }
        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerEditarUsuario();
        }
        private void ValidarVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            SqlConnection conexion = null;
            try
            {
                try
                {
                    conexion = this._conexHelper.GetConexion(ConexionHelper.BaseDatos.Utilidades);
                    conexion.Open();
                    AplicacionManager aplicacionManager = new AplicacionManager()
                    {
                        _conex = conexion
                    };
                    AplicacionModel data = aplicacionManager.GetData(this.GuidAplicacion);
                    if (data.Version != version.ToString())
                    {
                        MessageBox.Show(string.Format("La versión de su aplicación es '{0}', la versión actualizada es '{1}'. \n\nPor lo tanto debe actualizar su versión antes de continuar", version.ToString(), data.Version));
                        Application.Exit();
                    }

                    if (ConfigurationManager.AppSettings["AmbienteEjecucion"] != null)
                    {
                        this.strAmbienteEjecucion = (ConfigurationManager.AppSettings["AmbienteEjecucion"].ToString().ToLower() == "pruebas" ? "PRUEBAS" : "PRODUCCIÓN");
                    }
                    else
                    {
                        this.strAmbienteEjecucion = "PRODUCCIÓN";
                    }
                    //this.tssLblServidor.Text = empty;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                    Application.Exit();
                }
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }
        private void VerCrearUsuario()
        {
            if ((this._frmCrearUsuario == null ? true : this._frmCrearUsuario.IsDisposed))
            {

                this._frmCrearUsuario = new FrmCrearUsuario(null, null);
            }
            this._frmCrearUsuario.MdiParent = this;
            this._frmCrearUsuario.Show();
        }
        private void VerEditarUsuario()
        {
            if ((this._frmEditarUsuario == null ? true : this._frmEditarUsuario.IsDisposed))
            {

                this._frmEditarUsuario = new FrmEditarUsuario(this.usuarioModel, this.rolModel);
            }
            this._frmEditarUsuario.MdiParent = this;
            this._frmEditarUsuario.Show();
        }
        private void VerListaUsuarios()
        {
            if ((this._frmListaUsuario == null ? true : this._frmListaUsuario.IsDisposed))
            {

                this._frmListaUsuario = new FrmListaUsuario(this.usuarioModel, this.rolModel);
            }
            this._frmListaUsuario.MdiParent = this;
            this._frmListaUsuario.Show();
        }
        private void VerCargarArchivo()
        {
            if ((this._frmCargarArchivo == null ? true : this._frmCargarArchivo.IsDisposed))
            {

                this._frmCargarArchivo = new FrmCargarArchivo(this.usuarioModel);
            }
            this._frmCargarArchivo.MdiParent = this;
            this._frmCargarArchivo.Show();
        }
        private void VerCreacionCiclo()
        {
            if ((this._frmCreacionCiclo == null ? true : this._frmCreacionCiclo.IsDisposed))
            {

                this._frmCreacionCiclo = new FrmCreacionCiclo(this.usuarioModel);
            }
            this._frmCreacionCiclo.MdiParent = this;
            this._frmCreacionCiclo.Show();
        }
        private void VerEliminarCargue()
        {
            if ((this._frmEliminacionCargue == null ? true : this._frmEliminacionCargue.IsDisposed))
            {

                this._frmEliminacionCargue = new FrmEliminacionCargue(this.usuarioModel);
            }
            this._frmEliminacionCargue.MdiParent = this;
            this._frmEliminacionCargue.Show();
        }
        private void VerIngresarRepuesto()
        {
            if ((this._frmIngresarRepuesto == null ? true : this._frmIngresarRepuesto.IsDisposed))
            {

                this._frmIngresarRepuesto = new FrmIngresarRepuesto(this.usuarioModel);
            }
            this._frmIngresarRepuesto.MdiParent = this;
            this._frmIngresarRepuesto.Show();
        }
        private void VerAuditoriaRepuesto()
        {
            if ((this._frmAuditoriaRepuesto == null ? true : this._frmAuditoriaRepuesto.IsDisposed))
            {

                this._frmAuditoriaRepuesto = new FrmAuditoriaRepuesto(this.usuarioModel);
            }
            this._frmAuditoriaRepuesto.MdiParent = this;
            this._frmAuditoriaRepuesto.Show();
        }
        private void VerIntercaleRepuesto()
        {
            if ((this._frmIntercaleRepuesto == null ? true : this._frmIntercaleRepuesto.IsDisposed))
            {

                this._frmIntercaleRepuesto = new FrmIntercaleRepuesto(this.usuarioModel);
            }
            this._frmIntercaleRepuesto.MdiParent = this;
            this._frmIntercaleRepuesto.Show();
        }
        private void VerLiberarInstitucion()
        {
            if ((this._frmLiberarInstitucion == null ? true : this._frmLiberarInstitucion.IsDisposed))
            {

                this._frmLiberarInstitucion = new FrmLiberarInstitucion(this.usuarioModel);
            }
            this._frmLiberarInstitucion.MdiParent = this;
            this._frmLiberarInstitucion.Show();
        }
        private void VerTrazabalidadRepuesto()
        {
            if ((this._frmTrazabilidadRepuesto == null ? true : this._frmTrazabilidadRepuesto.IsDisposed))
            {

                this._frmTrazabilidadRepuesto = new FrmTrazabilidad(this.usuarioModel);
            }
            this._frmTrazabilidadRepuesto.MdiParent = this;
            this._frmTrazabilidadRepuesto.Show();
        }
        private void VerProcesarBiblia()
        {
            if ((this._frmProcesarBiblia == null ? true : this._frmProcesarBiblia.IsDisposed))
            {
                this._frmProcesarBiblia = new FrmProcesarBiblia(this.usuarioModel);
            }
            this._frmProcesarBiblia.MdiParent = this;
            this._frmProcesarBiblia.Show();
        }
        private void Principla_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void Principla_Load(object sender, EventArgs e)
        {
            TblDetalleRolPermisosManager tbldetalleRolPermisosManager = new TblDetalleRolPermisosManager();
            TblPermisosManager tblPermisosManager = new TblPermisosManager();
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                tbldetalleRolPermisosManager._conex = conex;
                tbldetalleRolPermisosManager._tx = transaction;
                tblPermisosManager._conex = conex;
                tblPermisosManager._tx = transaction;


                Conexion conexion = new Conexion();

                if (conexion.AmbienteProduccion)
                    this.strAmbienteEjecucion = "Producción";
                else
                    this.strAmbienteEjecucion = "Pruebas";


                #region Validacion de Versión
                Version version = Assembly.GetExecutingAssembly().GetName().Version;
                object major = version.Major;
                object minor = version.Minor;
                object Build = version.Build;
                object Revision = version.Revision;

                DateTime linkerTime = AssemblyHelper.GetLinkerTime(Assembly.GetExecutingAssembly(), null);
                this.GuidAplicacion = AssemblyHelper.GetGuidAplicacion(Assembly.GetExecutingAssembly());

                //this.ValidarVersion();

                this.Text = string.Format("MARQUESA V. {0}.{1}.{3}.{4} ({2}) - {5}", major, minor, DateTime.Now.ToString("dd - MMM - yyyy"), Build, Revision, this.strAmbienteEjecucion);
                //Helper.RutaTemporal = FileHelper.GenerateTempPath("TempCoordinadoraSmartTag", Application.ExecutablePath);
                toolStripStatusLabel1.Text = this.Text;
                lblStatusUsuario.Text = $"Usuario: {this.usuarioModel.NombreApellido.Replace("-"," ")} ({this.usuarioModel.Usuario})";
                #endregion

                #region asignacion de permisos 
                List <TblDetalleRolPermisosModel> listDetalleRolPermisosModel = tbldetalleRolPermisosManager.GetTableTblDetalleRolPermisosXTblRol(this.usuarioModel.Id_Rol);
                List<TblPermisosModel> tblPermisos = new List<TblPermisosModel>();

                if (listDetalleRolPermisosModel == null)
                    throw new Exception($"El rol '{this.rolModel.Nombre}' no se le ha asignado permisos " +
                        $"{Environment.NewLine}{Environment.NewLine} por favor validar con TI Gestion del Riesgo.");

                foreach (TblDetalleRolPermisosModel item in listDetalleRolPermisosModel)
                {
                    tblPermisos.Add(tblPermisosManager.GetData(item.Id_Permisos));
                }

                bool menuItemBaseVisible = false;
                foreach (ToolStripMenuItem itemMenuItem in menuStrip1.Items)
                {

                    foreach (ToolStripItem itemStripItem in itemMenuItem.DropDownItems)
                    {
                        if (tblPermisos.Where(t => itemStripItem.Name.Contains(t.NombreFormulario)).Count() <= 0)
                        {
                            if (!new[] { "cerrarSesion" }.Any(t => itemStripItem.Name.Contains(t))) 
                            {
                                itemStripItem.Enabled = false;
                                itemStripItem.ToolTipText = $"El usuario '{this.usuarioModel.Usuario}' no tiene permisos para ingresar a esta opción";
                            }                            
                        }
                    }

                    if (!new[] { "gestionUsuario", "configuracionRepuesto", "generacionRepuesto", "cerrarSesion" }.Any(t => itemMenuItem.Name.Contains(t)))
                    {
                        if (tblPermisos.Where(t => itemMenuItem.Name.Contains(t.NombreFormulario)).Count() <= 0)
                        {
                            itemMenuItem.Enabled = false;
                            itemMenuItem.ToolTipText = $"El usuario '{this.usuarioModel.Usuario}' no tiene permisos para ingresar a esta opción";
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Error al iniciar aplicativo:{1}{0}", ex.Message, Environment.NewLine), "Marquesa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            finally
            {
                if (conex != null)
                {
                    conex.Close();
                }
            }
        }
        public void MostrarVentana<T>(ref T frm)
        where T : Form
        {
            if ((frm == null ? true : frm.IsDisposed))
            {
                frm = (T)Activator.CreateInstance(typeof(T));
                frm.MdiParent = this;
            }
            frm.Show();
            frm.Activate();
        }
        private void FrmListaUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerListaUsuarios();
        }

        private void cargarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCargarArchivo();
        }

        private void FrmCreacionCicloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCreacionCiclo();
        }

        private void FrmEliminacionCargueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerEliminarCargue();
        }

        private void FrmIngresarRepuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerIngresarRepuesto();
        }

        private void FrmAuditoriaRepuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerAuditoriaRepuesto();
        }

        private void FrmIntercaleRepuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerIntercaleRepuesto();
        }

        private void FrmLiberarInstitucionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerLiberarInstitucion();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
            this.Visible = false;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void trazabilidadRepuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerTrazabalidadRepuesto();
        }

        private void FrmProcesarBibliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerProcesarBiblia();
        }

    }
}
