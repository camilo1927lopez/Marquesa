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
    public partial class FrmEliminacionCargue : Form
    {
        private ConexionHelper _conexHelper = new ConexionHelper();
        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private TblExaminandoManager _tblExaminandoManager = new TblExaminandoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();
        private TblParteCicloManager _tblParteCicloManager = new TblParteCicloManager();
        private TblRepuestoManager _tblRepuestoManager = new TblRepuestoManager();
        private TblDescripcionRepuestoManager _tblDescripcionRepuestoManager = new TblDescripcionRepuestoManager();
        private TblDetalleRepuestoManager _tblDetalleRepuestoManager = new TblDetalleRepuestoManager();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();

        public FrmEliminacionCargue(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
            CargarComboClient();
        }


        private void CargarComboClient()
        {
            try
            {
                _tblCleinteManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblCleinteManager._conex.Open();
                _tblCleinteManager._tx = _tblCleinteManager._conex.BeginTransaction();

                _ltsClientes = _tblCleinteManager.GetFullTableTblCliente();

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
                if (_tblCleinteManager._tx != null)
                    _tblCleinteManager._tx.Rollback();

                MessageBox.Show(ex.Message, "Error al cargar la lista de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_tblCleinteManager._conex != null)
                    _tblCleinteManager._conex.Close();

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
                _tblCleinteManager._conex = conex;
                _tblCleinteManager._tx = transaction;

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
                cbxSeleccionarPruebas.DataSource = _ltsCargueArchivo.OrderBy(t => t.Id).ToList();

                cbxSeleccionarPruebas.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                MessageBox.Show(ex.Message, "Error al cargar la lista de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }

        private void cbxSeleccionarPruebas_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void cbxCLientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CargarComboPruebas(Convert.ToInt32(cbxCLientes.SelectedValue));
            this.Cursor = Cursors.Default;
        }

        private void btnEliminarCargue_Click(object sender, EventArgs e)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.btnEliminarCargue.Enabled = false;

                DateTime tiempoInicial = DateTime.Now;
                TimeSpan tiempoFinal = new TimeSpan();

                List<string> ltsMensaje = new List<string>();

                if (cbxCLientes.SelectedIndex < 0)
                    ltsMensaje.Add($"Por favor seleccione el cliente.");
                if (cbxSeleccionarPruebas.SelectedIndex < 0)
                    ltsMensaje.Add($"Por favor seleccione la prueba.");

                if (ltsMensaje.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");

                int Id_CargueArchivo = Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue);
                int Id_Cliente = Convert.ToInt32(cbxCLientes.SelectedValue);

                if (MessageBox.Show($"Cliente: {cbxCLientes.Text}{Environment.NewLine}Nombre Pruebas: {cbxSeleccionarPruebas.Text}", $"Esta seguro de eliminar el cargue {cbxSeleccionarPruebas.Text} ({cbxCLientes.Text}).", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                    conex.Open();
                    transaction = conex.BeginTransaction();

                    _tblExaminandoManager._conex = conex;
                    _tblExaminandoManager._tx = transaction;
                    _tblConfiguracionRepuestoManager._conex = conex;
                    _tblConfiguracionRepuestoManager._tx = transaction;
                    _tblParteCicloManager._conex = conex;
                    _tblParteCicloManager._tx = transaction;
                    _tblRepuestoManager._conex = conex;
                    _tblRepuestoManager._tx = transaction;
                    _tblDescripcionRepuestoManager._conex = conex;
                    _tblDescripcionRepuestoManager._tx = transaction;
                    _tblDetalleRepuestoManager._conex = conex;
                    _tblDetalleRepuestoManager._tx = transaction;
                    _tblClienteCargueArchivoManager._conex = conex;
                    _tblClienteCargueArchivoManager._tx = transaction;
                    _tblCargueArchivoManager._conex = conex;
                    _tblCargueArchivoManager._tx = transaction;

                    int CantidadDetalleRepuesto = 0, cantidadRepuestoYDescriocion = 0, cantidadParteCiclo = 0, cantidadExaminando = 0, cantidadConfiguracionRepuesto = 0;

                    foreach (var itemConfiguracionRepuesto in _tblConfiguracionRepuestoManager.GetTableTblConfiguracionRepuestoXTblCargueArchivo(Id_CargueArchivo))
                    {

                        foreach (var itemRepuesto in _tblRepuestoManager.GetDataXIdConfiguracionRepuesto(itemConfiguracionRepuesto.Id))
                        {
                            foreach (var itemDetalleRepuesto in _tblDetalleRepuestoManager.GetDataXIdRepuesto(itemRepuesto.Id))
                            {
                                List<TblAuditoriaModel> ltsAuditoriaModels = _tblAuditoriaManager.GetTableTblAuditoriaXTblDetalleRepuesto(itemDetalleRepuesto.Id);
                                if (ltsAuditoriaModels.Count > 0)
                                    throw new Exception($"Tiene auditoria en proceso, por esta razón no se puede eliminar,");

                                _tblDetalleRepuestoManager.Eliminar(itemDetalleRepuesto.Id);
                                CantidadDetalleRepuesto++;
                            }

                            _tblRepuestoManager.Eliminar(itemRepuesto.Id);
                            _tblDescripcionRepuestoManager.Eliminar(itemRepuesto.Id_DescripcionRepuesto);
                            cantidadRepuestoYDescriocion++;
                        }

                        cantidadParteCiclo = _tblParteCicloManager.EliminarIdConfiguracionRepuesto(itemConfiguracionRepuesto.Id);
                    }
                    _tblClienteCargueArchivoManager.EliminarIdCargue(Id_CargueArchivo);
                    cantidadExaminando = _tblExaminandoManager.EliminarIdcargue(Id_CargueArchivo);
                    cantidadConfiguracionRepuesto = _tblConfiguracionRepuestoManager.EliminarIdCargue(Id_CargueArchivo);
                    _tblCargueArchivoManager.Eliminar(Id_CargueArchivo);
                    transaction.Commit();

                    tiempoFinal = DateTime.Now - tiempoInicial;

                    string strFechaHoraFinal = string.Format("Tiempo de eliminacion de cargue: {0}hr : {1}min: {2}seg", tiempoFinal.Hours, tiempoFinal.Minutes, tiempoFinal.Seconds);

                    MessageBox.Show($"Se eliminarón {cantidadExaminando} registro de la biblia cargada.{Environment.NewLine}" +
                        $"Se eliminarón {cantidadConfiguracionRepuesto} registro de las configuraciones de repuesto.{Environment.NewLine}" +
                        $"Se eliminarón {cantidadParteCiclo} registros los ciclos.{Environment.NewLine}{Environment.NewLine}" +
                        $"{strFechaHoraFinal}", "La eliminación fue exitosa.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    cbxCLientes.SelectedIndex = -1;
                    cbxSeleccionarPruebas.DataSource = null;
                    cbxSeleccionarPruebas.SelectedIndex = -1;
                }



                this.Cursor = Cursors.Default;
                this.btnEliminarCargue.Enabled = true;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();


                this.Cursor = Cursors.Default;
                this.btnEliminarCargue.Enabled = true;

                MessageBox.Show(ex.Message, "Error al eliminar el cargue.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                if (conex != null)
                    conex.Close();
            }     
        }
    }
}
