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
    public partial class FrmLogin : Form
    {

        private ConexionHelper _conexHelper = new ConexionHelper();
        TblUsuarioManager tblUsuarioManager = new TblUsuarioManager();
        TblRolManager tblRolManager = new TblRolManager();
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            try
            {
                //str = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish).ConnectionString;
                Ingresar();               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Ingresar() 
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

                List<string> listMensaje = new List<string>();

                if (string.IsNullOrEmpty(txtUsuario.Text))
                    listMensaje.Add("* Por favor ingresar usuario.");
                if (string.IsNullOrEmpty(txtClave.Text))
                    listMensaje.Add("* Por favor ingresar contraseña.");

                if (listMensaje.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, listMensaje));

                TblUsuarioModel usuario = new TblUsuarioModel();
                TblRolModel rol = new TblRolModel();

                usuario.Usuario = txtUsuario.Text;
                usuario.Clave = txtClave.Text;

                usuario = tblUsuarioManager.GetExisteUsuario(usuario);

                if (usuario == null)
                    throw new Exception($"El usuario '{txtUsuario.Text}' no existe. " +
                        $"{Environment.NewLine}{Environment.NewLine} por favor validar con su líder. ");

                if (!usuario.Estado)
                    throw new Exception($"El usuario '{usuario.Usuario}' con nombre '{usuario.NombreApellido.Replace("-"," ")}' no esta activo. " +
                        $"{Environment.NewLine}{Environment.NewLine} por favor validar con su líder. ");

                rol = tblRolManager.GetData(usuario.Id_Rol);

                //MDIPpal frm = new MDIPpal(usuario, rol);
                Principla frm = new Principla(usuario, rol);

                frm.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();
                throw new Exception(ex.Message);
                //MessageBox.Show(ex.Message, "Error al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                {
                    conex.Close();
                }
            }
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //El caracter 13 corresponde a la tecla Enter.
            {
                try
                {
                    //str = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish).ConnectionString;
                    Ingresar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Al ingresar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
