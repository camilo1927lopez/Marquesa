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
    public partial class FrmLiberarInstitucion : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();

        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoCiclo = new List<TblConfiguracionRepuestoModel>();

        private TblClienteManager _tblClienteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();

        public FrmLiberarInstitucion(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
            CargarComboClient();
        }

        #region MetodosDisparadores

        private void cbxCLientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                CargarComboPruebas(Convert.ToInt32(cbxCLientes.SelectedValue));
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxSeleccionarPruebas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (cbxCiclos.SelectedIndex >= 0)
                {
                    cbxCiclos.DataSource = null;
                    cbxCiclos.SelectedIndex = -1;
                }
                CargarComboCiclos(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue));
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar la prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtInstitucion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //El caracter 13 corresponde a la tecla Enter.
            {
                btnLiberarInstitucion.PerformClick();
            }
        }

        private void btnLiberarInstitucion_Click(object sender, EventArgs e)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                cbxCLientes.Enabled = false;
                cbxSeleccionarPruebas.Enabled = false;
                cbxCiclos.Enabled = false;
                txtInstitucion.Enabled = false;

                _tblAuditoriaManager._conex = conex;
                _tblAuditoriaManager._tx = transaction;

                DataTable info = _tblAuditoriaManager.GetValidarLiberacionInstitucion(Convert.ToInt32(cbxCiclos.SelectedValue), txtInstitucion.Text);

                if (Convert.ToInt32(info.Rows[0][0]) != 0)
                {
                    MessageBox.Show($"La institución {txtInstitucion.Text} con ciclo {cbxCiclos.Text} aún cuenta con {info.Rows[0][0]} repuestos por terminar su proceso de auditoría, por lo cual no puede ser liberado", "Error al liberar la institución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int infoLiberacion = _tblAuditoriaManager.LiberacionInstitucion(Convert.ToInt32(cbxCiclos.SelectedValue), txtInstitucion.Text, this._tblUsuarioModel.Id);

                    transaction.Commit();

                    if (infoLiberacion != 0)
                    {
                        MessageBox.Show($"La institución {txtInstitucion.Text} con ciclo {cbxCiclos.Text} se ha liberado correctamente!{Environment.NewLine}Total repuestos realizados: {infoLiberacion}", "Liberación de institución completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"La institución {txtInstitucion.Text} con ciclo {cbxCiclos.Text} no existe o no tiene repuestos por liberar", "Error al liberar la institución", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                txtInstitucion.Text = string.Empty;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message, "Error en la liberación de la institución", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

                cbxCLientes.Enabled = true;
                cbxSeleccionarPruebas.Enabled = true;
                cbxCiclos.Enabled = true;
                txtInstitucion.Enabled = true;
                txtInstitucion.Focus();
            }
        }


        #endregion

        #region MetodosCarga

        private void CargarComboClient()
        {
            try
            {
                _tblClienteManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblClienteManager._conex.Open();
                _tblClienteManager._tx = _tblClienteManager._conex.BeginTransaction();

                _ltsClientes = _tblClienteManager.GetFullTableTblCliente();

                if (_ltsClientes == null)
                    throw new Exception("* No se ha podido obtener los roles.");
                if (_ltsClientes.Count < 1)
                    throw new Exception("* La lista de roles que se intenta cargar esta vacía.");

                cbxCLientes.ValueMember = $"{TblClienteModel.EnumCampos.Id}";
                cbxCLientes.DisplayMember = $"{TblClienteModel.EnumCampos.Nombre}";
                cbxCLientes.DataSource = _ltsClientes.Where(t => t.Estado == true).OrderBy(t => t.Nombre).ToList();

                cbxCLientes.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                if (_tblClienteManager._tx != null)
                    _tblClienteManager._tx.Rollback();

                MessageBox.Show(ex.Message, "Error al cargar la lista de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_tblClienteManager._conex != null)
                    _tblClienteManager._conex.Close();

            }
        }

        private void CargarComboPruebas(int Id_Cliente)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblClienteCargueArchivoManager._conex = conex;
                _tblClienteCargueArchivoManager._tx = transaction;
                _tblCargueArchivoManager._conex = conex;
                _tblCargueArchivoManager._tx = transaction;
                _tblClienteManager._conex = conex;
                _tblClienteManager._tx = transaction;

                TblClienteModel tblClientes = _ltsClientes.Where(t => t.Id == Id_Cliente).FirstOrDefault();
                List<TblClienteCargueArchivoModel> ltsClienteCargueArchivo = _tblClienteCargueArchivoManager.GetTableTblClienteCargueArchivoXTblCliente(tblClientes.Id);
                _ltsCargueArchivo = new List<TblCargueArchivoModel>();

                if (ltsClienteCargueArchivo == null)
                    throw new Exception($"* No se ha podido obtener la lista de pruebas asociadas al cliente '{tblClientes.Nombre}'.");

                if (_ltsClientes.Count < 1)
                    throw new Exception($"* la lista de pruebas asociadas al cliente '{tblClientes.Nombre}' que se intenta cargar esta vacía.");

                foreach (TblClienteCargueArchivoModel item in ltsClienteCargueArchivo)
                {
                    var tblCargueArchivo = _tblCargueArchivoManager.GetData(item.Id_CargueArchivo);
                    if (tblCargueArchivo != null)
                        _ltsCargueArchivo.Add(tblCargueArchivo);

                }


                cbxSeleccionarPruebas.ValueMember = $"{TblCargueArchivoModel.EnumCampos.Id}";
                cbxSeleccionarPruebas.DisplayMember = $"{TblCargueArchivoModel.EnumCampos.NombreCarguePrueba}";
                cbxSeleccionarPruebas.DataSource = _ltsCargueArchivo.OrderBy(t => t.NombreCarguePrueba).ToList();

                cbxSeleccionarPruebas.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxSeleccionarPruebas.SelectedIndex = -1;
                MessageBox.Show(ex.Message, "Error al cargar la lista de pruebas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }

        private void CargarComboCiclos(int Id_Cargue)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblCargueArchivoManager._conex = conex;
                _tblCargueArchivoManager._tx = transaction;
                _tblConfiguracionRepuestoManager._conex = conex;
                _tblConfiguracionRepuestoManager._tx = transaction;

                TblCargueArchivoModel tblCargueArchivo = _ltsCargueArchivo.Where(t => t.Id == Id_Cargue).FirstOrDefault();
                _ltsConfiguracionRepuestoCiclo = _tblConfiguracionRepuestoManager.GetDataXIdCargue(tblCargueArchivo.Id);

                if (_ltsConfiguracionRepuestoCiclo.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de repuesto configurados asociados a la prueba '{tblCargueArchivo.NombreCarguePrueba}'.");


                cbxCiclos.ValueMember = $"{TblConfiguracionRepuestoModel.EnumCampos.Id}";
                cbxCiclos.DisplayMember = $"{TblConfiguracionRepuestoModel.EnumCampos.Ciclo}";
                cbxCiclos.DataSource = _ltsConfiguracionRepuestoCiclo.OrderBy(t => t.Id).ToList();

                cbxCiclos.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxSeleccionarPruebas.SelectedIndex = -1;
                MessageBox.Show(ex.Message, "Error al cargar la lista de ciclos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }


        #endregion
    }
}
