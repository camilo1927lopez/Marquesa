using BDManager;
using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesaReplenish.View
{
    public partial class FrmListaUsuario : Form
    {
        private ConexionHelper _conexHelper = new ConexionHelper();
        private List<TblUsuarioModel> ltsUsuarios = new List<TblUsuarioModel>();
        private List<TblRolModel> ltsRoles = new List<TblRolModel>();
        private TblUsuarioManager tblUsuarioManager = new TblUsuarioManager();
        private TblRolManager tblRolManager = new TblRolManager();
        private TblUsuarioModel usuarioModel = new TblUsuarioModel();
        private TblRolModel rolModel = new TblRolModel();
        private TblUsuarioModel _tblUsuarioPadreModel = new TblUsuarioModel();
        private TblRolModel _tblRolPadreModel = new TblRolModel();

        public FrmListaUsuario(TblUsuarioModel tblUsuarioPadreModel, TblRolModel tblRolPadreModel)
        {
            this._tblUsuarioPadreModel = tblUsuarioPadreModel;
            this._tblRolPadreModel = tblRolPadreModel;
            InitializeComponent();
        }

        private void FrmListaUsuario_Load(object sender, EventArgs e)
        {

            try
            {
                CargarUsuariosDataGrid();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarUsuariosDataGrid()
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                tblUsuarioManager._conex = conex;
                tblUsuarioManager._tx = transaction;
                tblRolManager._conex = conex;
                tblRolManager._tx = transaction;

                int cons = 1;
                ltsUsuarios = tblUsuarioManager.GetFullTableTblUsuario();
                ltsRoles = tblRolManager.GetFullTableTblRol();

                //dgvListaUsuarios.Columns.Add("Consecutivo", "Consecutivo");
                //dgvListaUsuarios.Columns.Add("Rol", "Rol");

                //foreach (var item in ltsUsuarios.FirstOrDefault().GetType().GetProperties().ToList())
                //{
                //    dgvListaUsuarios.Columns.Add(item.Name.Trim(), item.Name.ToString());

                //    if (item.Name.ToLower().Contains("id") || item.Name.ToLower().Contains("clave"))
                //        this.dgvListaUsuarios.Columns[item.Name.Trim()].Visible = false;

                //}
                //foreach (var item in ltsUsuarios)
                //{
                //    dgvListaUsuarios.Rows.Add(cons, tblRolManager.GetData(item.Id_Rol).Nombre, item.Id, item.Usuario, item.Documento, item.NombreApellido.Replace("-", " "), item.Clave, item.FechaCreacion, item.FechaActualizacion, item.Estado ? "Activo":"Inactivo");
                //    cons++;
                //}

                if (dgvListaUsuarios.Columns != null)                
                    if (dgvListaUsuarios.Columns.Count > 0)                    
                        for (int i = 0; i < dgvListaUsuarios.Columns.Count; i++)                         
                            dgvListaUsuarios.Columns.RemoveAt(i);                        

                dgvListaUsuarios.DataSource = ltsUsuarios.Select(t => new { Consecutivo = cons++, Id = t.Id, Usuario = t.Usuario, Rol = $"{tblRolManager.GetData(t.Id_Rol).Nombre}", Documento = t.Documento, Nombre = t.NombreApellido.Split('-')[0], Apellido = t.NombreApellido.Split('-').Length > 1 ? t.NombreApellido.Split('-')[1] : string.Empty, Estado = t.Estado ? "Activo" : "Inactivo" }).ToList();

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.HeaderText = "";
                btn.Name = "Editar";
                btn.Text = "Editar";
                btn.UseColumnTextForButtonValue = true;
                dgvListaUsuarios.Columns.Add(btn);

                //btn = new DataGridViewButtonColumn();
                //btn.HeaderText = "";
                //btn.Name = "Eliminar";
                //btn.Text = "Eliminar";
                //btn.UseColumnTextForButtonValue = true;
                //dgvListaUsuarios.Columns.Add(btn);
                dgvListaUsuarios.AllowUserToOrderColumns = true;
                dgvListaUsuarios.AutoGenerateColumns = true;
                dgvListaUsuarios.AutoResizeColumns();

                lblCantidadDeUsuarios.Text = $"Cantidad de Usuarios: {cons-1}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                
                string Id_Usuarios = dgvListaUsuarios.Rows[e.RowIndex].Cells["Id"].Value != null ? dgvListaUsuarios.Rows[e.RowIndex].Cells["Id"].Value.ToString() : string.Empty;                

                if (e.ColumnIndex == dgvListaUsuarios.Columns["Editar"].Index && e.RowIndex >= 0) 
                {
                    if (string.IsNullOrEmpty(Id_Usuarios))
                        throw new Exception("No se ha podido obtener el id del usuario");
                    if (string.IsNullOrEmpty(Id_Usuarios))
                        throw new Exception("No se ha podido obtener el id del rol");

                    usuarioModel = ltsUsuarios.Where(t => t.Id == Convert.ToInt32(Id_Usuarios)).FirstOrDefault();
                    rolModel = ltsRoles.Where(t => t.Id == usuarioModel.Id_Rol).FirstOrDefault();                    

                    FrmEditarUsuario frmEditarUsuario = new FrmEditarUsuario(usuarioModel,rolModel, this._tblUsuarioPadreModel, this._tblRolPadreModel);
                    frmEditarUsuario.ShowDialog();

                    if (dgvListaUsuarios.DataSource != null)                     
                        dgvListaUsuarios.DataSource = null;                        
                    
                    CargarUsuariosDataGrid();

                    frmEditarUsuario.Close();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Cargar la lista", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                VerCrearUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro al abrir el modulo de creacíon usuarios.");
            }
        }

        private FrmCrearUsuario _frmCrearUsuario = null;

        private void VerCrearUsuario()
        {
            if ((this._frmCrearUsuario == null ? true : this._frmCrearUsuario.IsDisposed))
            {

                this._frmCrearUsuario = new FrmCrearUsuario(null, null);
            }
            //this._frmCrearUsuario.MdiParent = this;
            this._frmCrearUsuario.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (usrBuscar.Value <= 0)
                    throw new Exception("Por favor ingresar un documento para buscar");

                BuscarDocumento(usrBuscar.Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarDocumento(string documento)
        {
            try
            {
                var ltsusuarioModel = ltsUsuarios.Where(t => t.Documento == documento).ToList();

                if (ltsusuarioModel.Count <= 0)
                    throw new Exception($"El usuario con documento '{documento}' no existe.");

                usuarioModel = ltsusuarioModel.FirstOrDefault();

                rolModel = ltsRoles.Where(t => t.Id == usuarioModel.Id_Rol).FirstOrDefault();

                FrmEditarUsuario frmEditarUsuario = new FrmEditarUsuario(usuarioModel, rolModel, this._tblUsuarioPadreModel, this._tblRolPadreModel);
                frmEditarUsuario.ShowDialog();

                if (dgvListaUsuarios.DataSource != null)
                    dgvListaUsuarios.DataSource = null;

                CargarUsuariosDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usrBuscar_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                try
                {
                    if (usrBuscar.Value <= 0)
                        throw new Exception("Por favor ingresar un documento par buscar");

                    BuscarDocumento(usrBuscar.Value.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al buscar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
