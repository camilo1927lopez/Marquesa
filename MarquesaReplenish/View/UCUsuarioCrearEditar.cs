using BDManager;
using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace MarquesaReplenish.View
{
    public partial class UCUsuarioCrearEditar : UserControl
    {
        private string Accion = "Crear";
        private TblUsuarioModel tblUsuario { get; set; }
        private TblRolModel tblRol { get; set; }
        private TblUsuarioModel tblUsuarioPadre { get; set; }
        private TblRolModel tblRolPadre { get; set; }

        private ConexionHelper _conexHelper = new ConexionHelper();

        private TblRolManager tblRolManager = new TblRolManager();

        private TblUsuarioManager tblUsuarioManager = new TblUsuarioManager();


        public UCUsuarioCrearEditar(TblUsuarioModel UsuarioModel, TblRolModel RolModel)
        {
            try
            {
                //if (UsuarioModel != null)
                //    throw new Exception("* No se esta enviando la informacion del usuario.");
                //if (RolModel != null)
                //    throw new Exception($"* No se esta enviando la informacion del rol para el usuario '{UsuarioModel.Usuario} con nombre '{UsuarioModel.NombreApellido}''");

                this.tblUsuario = UsuarioModel;
                this.tblRol = RolModel;

                InitializeComponent();

                if (tblUsuario != null && tblRol != null)
                {
                    Accion = "Editar";
                    VisualizarEdiccion(tblUsuario, tblRol, null, null);
                }

                gbxCrearEditarUsuario.Text = $"{Accion} Usuarios";
                btnGuardarEditar.Text = $"{Accion} Usuarios";
                CargarComboRol(tblRol != null ? tblRol.Codigo : null);
                CargarComboEstado(tblUsuario != null ? tblUsuario.Estado : true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar configuraciones");
            }
        }

        public UCUsuarioCrearEditar(TblUsuarioModel UsuarioModel, TblRolModel RolModel, TblUsuarioModel UsuarioPadreModel, TblRolModel RolPadreModel)
        {
            try
            {

                this.tblUsuario = UsuarioModel;
                this.tblRol = RolModel;
                this.tblUsuarioPadre = UsuarioPadreModel;
                this.tblRolPadre = RolPadreModel;

                InitializeComponent();

                if (tblUsuario != null && tblRol != null)
                {
                    Accion = "Editar";
                    VisualizarEdiccion(tblUsuario, tblRol, tblUsuarioPadre, tblRolPadre);
                }

                gbxCrearEditarUsuario.Text = $"{Accion} Usuarios";
                btnGuardarEditar.Text = $"{Accion} Usuarios";
                CargarComboRol(tblRol != null ? tblRol.Codigo : null);
                CargarComboEstado(tblUsuario != null ? tblUsuario.Estado : true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar configuraciones");
            }
        }

        private void VisualizarEdiccion(TblUsuarioModel usuarioModel, TblRolModel rolModel, TblUsuarioModel usuarioPadreModel, TblRolModel rolPadreModel)
        {
            try
            {
                bool OrigenListaUsuario = rolPadreModel != null ? true : false;

                string[] arrNombreApellido = usuarioModel.NombreApellido.Split('-');
                if (arrNombreApellido.Length > 1) 
                {
                    txtApellido.Text = arrNombreApellido[0];
                    txtNombre.Text = arrNombreApellido[1];
                }
                else                
                    txtApellido.Text = arrNombreApellido[0];
                 
                txtUsuario.Text = usuarioModel.Usuario;
                usrDocumento.Value = Convert.ToDecimal(usuarioModel.Documento);

                txtUsuario.Enabled = false;
                usrDocumento.Enabled = false;

                if (Convert.ToInt32(rolModel.Codigo) != 1)
                {
                    txtApellido.Enabled = OrigenListaUsuario ? OrigenListaUsuario : false;
                    txtNombre.Enabled = OrigenListaUsuario ? OrigenListaUsuario : false;
                    cbxEstado.Enabled = OrigenListaUsuario ? OrigenListaUsuario : false;
                    cbxRol.Enabled = OrigenListaUsuario ? OrigenListaUsuario : false;
                }

                if (OrigenListaUsuario)
                {
                    txtClave.Text = usuarioModel.Clave;
                    txtClaveConfirmar.Text = usuarioModel.Clave;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error al {Accion}");
            }
        }

        private void CargarComboRol(string Codigo)
        {
            try
            {
                tblRolManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                tblRolManager._conex.Open();
                tblRolManager._tx = tblRolManager._conex.BeginTransaction();

                List<TblRolModel> tblRols = tblRolManager.GetFullTableTblRol();

                if (tblRols == null)
                    throw new Exception("* No se ha podido obtener los roles.");
                if (tblRols.Count < 1)
                    throw new Exception("* La lista de roles que se intenta cargar esta vacía.");

                cbxRol.ValueMember = $"{TblRolModel.EnumCampos.Codigo}";
                cbxRol.DisplayMember = $"{TblRolModel.EnumCampos.Nombre}";
                cbxRol.DataSource = tblRols.OrderBy(t => t.Codigo).ToList();

                if (!string.IsNullOrEmpty(Codigo))
                    cbxRol.SelectedValue = Codigo;
                else
                    cbxRol.SelectedIndex = -1;

                tblRolManager._tx.Commit();
            }
            catch (Exception ex)
            {
                if (tblRolManager._tx != null)
                    tblRolManager._tx.Rollback();

                MessageBox.Show(ex.Message, "Error al cargar la lista de roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (tblRolManager._conex != null)
                    tblRolManager._conex.Close();

            }
        }

        private void CargarComboEstado(bool? estado)
        {
            try
            {
                DataTable dtbEstado = new DataTable();
                dtbEstado.Columns.Add("Id", typeof(bool));
                dtbEstado.Columns.Add("Nombre", typeof(string));

                DataRow dtrEstado = dtbEstado.NewRow();
                dtrEstado["Id"] = true;
                dtrEstado["Nombre"] = "Activo";

                DataRow dtrEstado2 = dtbEstado.NewRow();
                dtrEstado2["Id"] = false;
                dtrEstado2["Nombre"] = "Inactivo";

                dtbEstado.Rows.Add(dtrEstado);
                dtbEstado.Rows.Add(dtrEstado2);

                cbxEstado.ValueMember = "Id";
                cbxEstado.DisplayMember = "Nombre";
                cbxEstado.DataSource = dtbEstado;

                if (estado != null)
                    cbxEstado.SelectedValue = estado;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la lista de estado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            GuardarEditar();
        }

        public void GuardarEditar()
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                tblUsuarioManager._conex = conex;
                tblUsuarioManager._tx = transaction;
                tblRolManager._conex = conex;
                tblRolManager._tx = transaction;

                List<string> ltsmensaje = new List<string>();

                if (usrDocumento.Value <= 0)
                    ltsmensaje.Add($"* por favor ingrese un '{TblUsuarioModel.EnumCampos.Documento}'.");

                if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
                    ltsmensaje.Add($"* por favor ingrese un 'Nombre'.");

                if (string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrWhiteSpace(txtApellido.Text))
                    ltsmensaje.Add($"* por favor ingrese un 'Apellido'.");

                if (cbxRol.SelectedIndex < 0)
                    ltsmensaje.Add($"* por favor seleccione un 'Rol'.");

                if (cbxEstado.SelectedIndex < 0)
                    ltsmensaje.Add($"* por favor seleccione un '{TblUsuarioModel.EnumCampos.Estado}'.");

                if (string.IsNullOrEmpty(txtClave.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
                    ltsmensaje.Add($"* por favor ingrese una 'Contraseña'.");

                if (txtClave.Text != txtClaveConfirmar.Text)
                    ltsmensaje.Add($"* La Contraseña y la confirmación de la contraseña son diferentes.");

                if (!Convert.ToBoolean(cbxEstado.SelectedValue) && Accion == "Crear")
                    ltsmensaje.Add($"* No se puede crear un usuario con estado 'inactivo'");

                if (ltsmensaje.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsmensaje)}");

                tblRol = tblRolManager.GetRolCodigo(cbxRol.SelectedValue.ToString());

                if (tblUsuario == null)
                    tblUsuario = new TblUsuarioModel();

                tblUsuario.Id_Rol = tblRol.Id;
                tblUsuario.Usuario = txtUsuario.Text;
                tblUsuario.Documento = usrDocumento.Value.ToString();
                tblUsuario.Estado = Convert.ToBoolean(cbxEstado.SelectedValue);
                tblUsuario.NombreApellido = $"{txtNombre.Text}-{txtApellido.Text}";

                if (tblUsuario.Clave != txtClave.Text)
                    tblUsuario.Clave = Functions.EncriptadoHelper.GetHashSha256(txtClave.Text);
                else
                    tblUsuario.Clave = txtClave.Text;

                tblUsuario.FechaActualizacion = DateTime.Now;

                if (Accion == "Crear")
                {
                    tblUsuario.FechaCreacion = DateTime.Now;
                    bool existeUsuario = tblUsuarioManager.GetExisteUsuario(tblUsuario.Usuario);

                    if (!existeUsuario)
                        tblUsuarioManager.Guardar(tblUsuario);
                    else
                        throw new Exception($"* El usuario {tblUsuario.Usuario} ya existe.");

                    Accion = "Creado";
                }
                else
                {
                    tblUsuarioManager.Editar(tblUsuario);
                    Accion = "Editado";
                }


                string strMensajeCreacion = $"Usuario: {tblUsuario.Usuario}{Environment.NewLine}" +
                                            $"Documento: {tblUsuario.Documento}{Environment.NewLine}" +
                                            $"Nombre: {tblUsuario.NombreApellido.Replace("-", " ")}{Environment.NewLine}" +
                                            $"Rol: {tblRol.Nombre}{Environment.NewLine}";

                MessageBox.Show(strMensajeCreacion, $"Usuario {Accion}", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                LimpiarFormulario();

                this.Cursor = Cursors.Default;
                transaction.Commit();

                //if (this.tblUsuarioPadre != null && this.tblRolPadre != null)
                //    this.Visible = false;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, $"Error al {Accion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                {
                    conex.Close();
                }
            }
        }

        private void LimpiarFormulario()
        {
            try
            {
                usrDocumento.Value = 0;
                txtApellido.Clear();
                txtClave.Clear();
                txtClaveConfirmar.Clear();
                txtNombre.Clear();
                txtUsuario.Clear();
                cbxRol.SelectedIndex = -1;
                cbxEstado.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, $"Error al limpiar formulario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
