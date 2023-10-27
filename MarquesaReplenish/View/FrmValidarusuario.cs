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
    public partial class FrmValidarusuario : Form
    {
        private ConexionHelper _conexHelper = new ConexionHelper();
        private TblUsuarioManager _tblUsuarioManager = new TblUsuarioManager();
        private TblRolManager _tblRolManager = new TblRolManager();
        private DataTable _dtbRangoExistentes = null;
        private bool _rangoExistentes = false;
        public bool Correcto = false;
        public FrmIngresarRepuesto _frmIngresarRepuesto = null;
        public TblUsuarioModel tblUsuarioLiderAutorizado = null;

        public FrmValidarusuario()
        {
            InitializeComponent();
        }

        public FrmValidarusuario(bool RangoExistentes, DataTable dtbRangoExistentes)
        {
            this._rangoExistentes = RangoExistentes;
            this._dtbRangoExistentes = dtbRangoExistentes;
            
            InitializeComponent();
            CargarTabla(RangoExistentes, dtbRangoExistentes);
            txtClave.Clear();
            txtUsuario.Clear();
        }

        private void CargarTabla(bool rangoExistentes, DataTable dtbRangoExistentes)
        {
            try
            {
                if (rangoExistentes && dtbRangoExistentes != null)
                {
                    if (dtbRangoExistentes.Rows.Count <= 0)
                        throw new Exception($"La lista de repuesto que envia se encuentra vacia.");
                }
                else                
                    throw new Exception($"No se estan enviando los parametros necesarios para cargar la tabla.");

                if (dgvListaRepuestoExistente.Rows.Count > 0)
                {
                    dgvListaRepuestoExistente.Rows.Clear();
                    dgvListaRepuestoExistente.DataSource = null;

                }

                dgvListaRepuestoExistente.DataSource = dtbRangoExistentes;
                dgvListaRepuestoExistente.AllowUserToOrderColumns = true;
                dgvListaRepuestoExistente.AutoGenerateColumns = true;
                dgvListaRepuestoExistente.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la tabla con la lista de repuesto.");
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void Validar()
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;
            List<string> ltsMensaje = new List<string>();
            try
            {
                string clave = txtClave.Text;
                string usuario = txtUsuario.Text;

                if (string.IsNullOrEmpty(clave) || string.IsNullOrWhiteSpace(usuario))
                    ltsMensaje.Add("Por favor ingresar clave.");
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrWhiteSpace(usuario))
                    ltsMensaje.Add("Por favor ingresar clave.");

                if (ltsMensaje.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");

                tblUsuarioLiderAutorizado = null;

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblUsuarioManager._conex = conex;
                _tblUsuarioManager._tx = transaction;
                _tblRolManager._conex = conex;
                _tblRolManager._tx = transaction;

                tblUsuarioLiderAutorizado = new TblUsuarioModel { Clave = clave, Usuario = usuario };

                tblUsuarioLiderAutorizado = _tblUsuarioManager.GetExisteUsuario(tblUsuarioLiderAutorizado);

                if (tblUsuarioLiderAutorizado != null)
                {
                    if (tblUsuarioLiderAutorizado.Estado)
                    {
                        TblRolModel tblRolModel = _tblRolManager.GetData(tblUsuarioLiderAutorizado.Id_Rol);

                        if (Convert.ToInt32(tblRolModel.Codigo) == 1)
                        {
                            if (_rangoExistentes)
                            {
                                int cantidadEliminados = 0;
                                for (int i = 0; i < dgvListaRepuestoExistente.Rows.Count; i++)
                                {
                                    bool eliminar = Convert.ToBoolean(dgvListaRepuestoExistente.Rows[i].Cells[2].Value);
                                    int Repuesto = Convert.ToInt32(dgvListaRepuestoExistente.Rows[i].Cells[0].Value);
                                    if (!eliminar) 
                                    {
                                        _frmIngresarRepuesto._ltsRangos.Remove(Repuesto);
                                        cantidadEliminados++;
                                    }                                        
                                }

                                MessageBox.Show($"Se ingresarón {_frmIngresarRepuesto._ltsRangos.Count} repuestos nuevos.", $"Aprobación de los repuesto por el lider {tblUsuarioLiderAutorizado.Usuario} exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Correcto = true;
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show($"El usuario {usuario} autorizado correctamente.", "Usuario Lider Aprobado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                Correcto = true;
                                this.Close();
                            }
                        }
                        else
                            throw new Exception($"* El usuario '{usuario}' con el rol '{tblRolModel.Nombre}', no tiene rol de lider.");
                    }
                    else
                        throw new Exception($"* El usuario '{usuario}' esta desactivado.");
                }
                else
                    throw new Exception($"* El usuario '{usuario}' que no existe.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al validar el usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Correcto = false;
            this.Close();
        }

        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //El caracter 13 corresponde a la tecla Enter.
            {
                Validar();
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //El caracter 13 corresponde a la tecla Enter.
            {
                Validar();
            }
        }

        private void FrmValidarusuario_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
