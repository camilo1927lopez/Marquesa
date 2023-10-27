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
    public partial class FrmTrazabilidad : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();

        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblUsuarioModel> _ltsusuarios = new List<TblUsuarioModel>();
        private List<TblEstadoModel> _ltsEstados = new List<TblEstadoModel>();
        private List<TblFormatoSalidaModel> _ltsFormatoSalida = new List<TblFormatoSalidaModel>();
        private List<TblTipoImpresionModel> _ltsTipoImpresions = new List<TblTipoImpresionModel>();
        private List<TblMaquinaModel> _ltsMaquinas = new List<TblMaquinaModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoCiclo = new List<TblConfiguracionRepuestoModel>();
        private List<TblParteCicloModel> _ltsParteCiclo = new List<TblParteCicloModel>();
        private List<TblImpresoraModel> _tblImpresoras = new List<TblImpresoraModel>();
        private List<TblNovedadModel> _ltsNovedads = new List<TblNovedadModel>();

        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblUsuarioManager _tblUsuarioManager = new TblUsuarioManager();
        private TblEstadoManager _tblEstadoManager = new TblEstadoManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblFormatoSalidaManager _tblFormatoSalidaManager = new TblFormatoSalidaManager();
        private TblTipoImpresionManager _tblTipoImpresionManager = new TblTipoImpresionManager();
        private TblMaquinaManager _tblMaquinaManager = new TblMaquinaManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();
        private TblParteCicloManager _tblParteCicloManager = new TblParteCicloManager();
        private TblImpresoraManager _tblImpresoraManager = new TblImpresoraManager();
        private TblNovedadManager _tblNovedadManager = new TblNovedadManager();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();

        Dictionary<string, dynamic> dcFiltros = new Dictionary<string, dynamic>();
        DataTable dtbFiltrosEncontrados = new DataTable();
        public FrmTrazabilidad(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
            CargarComboUsuarios();
            CargarComboClient();
            CargarComboEstados();
            CargarComboFormatoSalida();
            CargarComboTipoImpresion();
            CargarComboMaquina();
        }
        private void CargarComboEstados()
        {
            try
            {
                _tblEstadoManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblEstadoManager._conex.Open();

                _ltsEstados = _tblEstadoManager.GetFullTableTblEstado();

                if (_ltsEstados == null)
                    throw new Exception("* No se ha podido obtener la lista de estados.");
                if (_ltsEstados.Count < 1)
                    throw new Exception("* La lista de estados que se intenta cargar esta vacía.");

                cbxEstados.ValueMember = $"{TblEstadoModel.EnumCampos.Id}";
                cbxEstados.DisplayMember = $"{TblEstadoModel.EnumCampos.Nombre}";

                _ltsEstados.Add(new TblEstadoModel {Estado = true, Id = 0, Nombre = "---Selecciona Estado---" });
                cbxEstados.DataSource = _ltsEstados.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxEstados.SelectedValue = 0;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error al cargar la lista de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_tblEstadoManager._conex != null)
                    _tblEstadoManager._conex.Close();

            }
        }
        private void CargarComboUsuarios()
        {
            try
            {
                _tblUsuarioManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblUsuarioManager._conex.Open();

                _ltsusuarios = _tblUsuarioManager.GetFullTableTblUsuario();

                if (_ltsusuarios == null)
                    throw new Exception("* No se ha podido obtener la lista de usuarios.");
                if (_ltsusuarios.Count < 1)
                    throw new Exception("* La lista de usuarios que se intenta cargar esta vacía.");

                cbxUsuarios.ValueMember = $"{TblUsuarioModel.EnumCampos.Id}";
                cbxUsuarios.DisplayMember = $"{TblUsuarioModel.EnumCampos.Usuario}";

                _ltsusuarios.Add(new TblUsuarioModel { Id = 0, Usuario = "---Seleccionar Usuario---", Estado = true });
                cbxUsuarios.DataSource = _ltsusuarios.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxUsuarios.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la lista de cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_tblUsuarioManager._conex != null)
                    _tblUsuarioManager._conex.Close();

            }
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

                _ltsClientes.Add(new TblClienteModel { Estado = true, Id = 0, Nombre = "---Seleccionar Cliente---" });
                cbxCLientes.DataSource = _ltsClientes.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxCLientes.SelectedValue = 0;

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
        private void CargarComboFormatoSalida()
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblFormatoSalidaManager._conex = conex;
                _tblFormatoSalidaManager._tx = transaction;

                _ltsFormatoSalida = _tblFormatoSalidaManager.GetFullTableTblFormatoSalida();

                if (_ltsFormatoSalida.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de formatos de salidas.");


                cbxFormatoSalidas.ValueMember = $"{TblFormatoSalidaModel.EnumCampos.Id}";
                cbxFormatoSalidas.DisplayMember = $"{TblFormatoSalidaModel.EnumCampos.Nombre}";

                _ltsFormatoSalida.Add(new TblFormatoSalidaModel { Estado = true, Id = 0, Nombre = "---Seleccionar Formato de Salida---"});
                cbxFormatoSalidas.DataSource = _ltsFormatoSalida.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxFormatoSalidas.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxFormatoSalidas.SelectedIndex = -1;
                MessageBox.Show(ex.Message, "Error al cargar la lista de formatos de salidas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }
        private void CargarComboTipoImpresion()
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblTipoImpresionManager._conex = conex;
                _tblTipoImpresionManager._tx = transaction;

                _ltsTipoImpresions = _tblTipoImpresionManager.GetFullTableTblTipoImpresion().ToList();

                if (_ltsTipoImpresions.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de tipo de impresiones.");


                cbxTipoImpresion.ValueMember = $"{TblTipoImpresionModel.EnumCampos.Id}";
                cbxTipoImpresion.DisplayMember = $"{TblTipoImpresionModel.EnumCampos.Nombre}";
                cbxTipoImpresion.DataSource = _ltsTipoImpresions.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxTipoImpresion.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxTipoImpresion.SelectedIndex = -1;
                MessageBox.Show(ex.Message, "Error al cargar la lista de formatos de salidas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }
        private void CargarComboMaquina()
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblMaquinaManager._conex = conex;
                _tblMaquinaManager._tx = transaction;

                _ltsMaquinas = _tblMaquinaManager.GetFullTableTblMaquina().ToList();

                if (_ltsMaquinas.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de maquinas.");


                cbxMaquina.ValueMember = $"{TblMaquinaModel.EnumCampos.Id}";
                cbxMaquina.DisplayMember = $"{TblMaquinaModel.EnumCampos.Nombre}";

                _ltsMaquinas.Add(new TblMaquinaModel {Estado = true, Id = 0, Nombre = "---Seleccionar Maquina---" });
                cbxMaquina.DataSource = _ltsMaquinas.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxMaquina.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxMaquina.SelectedIndex = -1;
                MessageBox.Show(ex.Message, "Error al cargar la lista de formatos de salidas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

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

                _ltsCargueArchivo.Add(new TblCargueArchivoModel { Id = 0, NombreCarguePrueba = "---Seleccionar Nombre Cargue---"});
                cbxSeleccionarPruebas.DataSource = _ltsCargueArchivo.OrderBy(t => t.Id).ToList();

                cbxSeleccionarPruebas.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxSeleccionarPruebas.SelectedValue = 0;
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

                _ltsConfiguracionRepuestoCiclo.Add(new TblConfiguracionRepuestoModel {Id = 0, Ciclo = "---Seleccionar Ciclo---" });
                cbxCiclos.DataSource = _ltsConfiguracionRepuestoCiclo.OrderBy(t => t.Id).ToList();

                cbxCiclos.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxSeleccionarPruebas.SelectedValue = 0;
                MessageBox.Show(ex.Message, "Error al cargar la lista de ciclos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }
        private void CargarComboImpresora(int Id_FormatoSalidas)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblImpresoraManager._conex = conex;
                _tblImpresoraManager._tx = transaction;

                TblFormatoSalidaModel TblFormatoSalida = _ltsFormatoSalida.Where(x => x.Id == Id_FormatoSalidas).FirstOrDefault();
                _tblImpresoras = _tblImpresoraManager.GetTableTblImpresoraXTblFormatoSalida(TblFormatoSalida.Id);

                if (_tblImpresoras.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de impresoras asociadas al formato de salidad '{TblFormatoSalida.Nombre}'.");


                cbxImpresoras.ValueMember = $"{TblImpresoraModel.EnumCampos.Id}";
                cbxImpresoras.DisplayMember = $"{TblImpresoraModel.EnumCampos.Nombre}";

                _tblImpresoras.Add(new TblImpresoraModel {Id = 0, Nombre = "---Seleccionar Impresora---", Estado = true});
                cbxImpresoras.DataSource = _tblImpresoras.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxImpresoras.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxFormatoSalidas.SelectedValue = 0;
                MessageBox.Show(ex.Message, "Error al cargar la lista de formatos de salidas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }
        private void CargarComboNovedad(int Id_Maquina)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblNovedadManager._conex = conex;
                _tblNovedadManager._tx = transaction;

                TblMaquinaModel tblMaquina = _ltsMaquinas.Where(t => t.Id == Id_Maquina).FirstOrDefault();

                _ltsNovedads = _tblNovedadManager.GetTableTblNovedadXTblMaquina(tblMaquina.Id);

                if (_ltsMaquinas.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de maquinas.");


                cbxNovedad.ValueMember = $"{TblNovedadModel.EnumCampos.Id}";
                cbxNovedad.DisplayMember = $"{TblNovedadModel.EnumCampos.Nombre}";

                _ltsNovedads.Add(new TblNovedadModel {Id = 0, Nombre = "---Seleccionar Novedades---" });
                cbxNovedad.DataSource = _ltsNovedads.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxNovedad.SelectedValue = 0;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxMaquina.SelectedValue = 0;
                MessageBox.Show(ex.Message, "Error al cargar la lista de formatos de salidas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                    conex.Close();

            }
        }

        private void cbxCLientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbxCLientes.SelectedValue) != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue) != 0)
                    {
                        cbxCiclos.DataSource = null;
                        cbxCiclos.SelectedIndex = -1;
                        cbxSeleccionarPruebas.DataSource = null;
                        cbxSeleccionarPruebas.SelectedIndex = -1;
                        QuitarFiltro(TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString());
                        QuitarFiltro(TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString());
                    }

                    AgregarFiltro(TblClienteCargueArchivoModel.EnumCampos.Id_Cliente.ToString(), Convert.ToInt32(cbxCLientes.SelectedValue));
                    CargarComboPruebas(Convert.ToInt32(cbxCLientes.SelectedValue));
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    QuitarFiltro(TblClienteCargueArchivoModel.EnumCampos.Id_Cliente.ToString());
                }
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
                if (Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue) != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Convert.ToInt32(cbxCiclos.SelectedValue) != 0)
                    {
                        cbxCiclos.DataSource = null;
                        cbxCiclos.SelectedIndex = -1;

                        QuitarFiltro(TblParteCicloModel.EnumCampos.Id_configuracionRepuesto.ToString());
                    }
                    AgregarFiltro(TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue));
                    CargarComboCiclos(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue));
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    QuitarFiltro(TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar la prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxCiclos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbxCiclos.SelectedValue) != 0) 
                {
                    this.Cursor = Cursors.WaitCursor;
                    AgregarFiltro(TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), Convert.ToInt32(cbxCiclos.SelectedValue));
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    QuitarFiltro(TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el ciclo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxFormatoSalidas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbxFormatoSalidas.SelectedValue) != 0) 
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Convert.ToInt32(cbxImpresoras.SelectedValue) != 0)
                    {
                        cbxImpresoras.DataSource = null;
                        cbxImpresoras.SelectedIndex = -1;
                        QuitarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_Impresora.ToString());
                    }
                    AgregarFiltro(TblImpresoraModel.EnumCampos.Id_FormatoSalida.ToString(), Convert.ToInt32(cbxFormatoSalidas.SelectedValue));
                    CargarComboImpresora(Convert.ToInt32(cbxFormatoSalidas.SelectedValue));
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    QuitarFiltro(TblImpresoraModel.EnumCampos.Id_FormatoSalida.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el formato de salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxMaquina_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(cbxMaquina.SelectedValue) != 0)
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (Convert.ToInt32(cbxNovedad.SelectedValue) != 0)
                    {
                        cbxNovedad.DataSource = null;
                        cbxNovedad.SelectedIndex = -1;
                        QuitarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_novedad.ToString());
                    }
                    AgregarFiltro(TblNovedadModel.EnumCampos.id_Maquina.ToString(), Convert.ToInt32(cbxMaquina.SelectedValue));
                    CargarComboNovedad(Convert.ToInt32(cbxMaquina.SelectedValue));
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    QuitarFiltro(TblNovedadModel.EnumCampos.id_Maquina.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el formato de salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable Buscar() 
        {
            SqlConnection conex = null;
            try
            {
                if (dcFiltros.Count <= 0)
                    throw new Exception("* Por favor seleccionar o ingresar filtro para realizar la búsqueda.");

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();

                _tblAuditoriaManager._conex = conex;

                DataTable dataTable = _tblAuditoriaManager.TrazabilidadRepuesto(dcFiltros);

                

                if (dgvListaTrazabilidad.Columns.Count <= 0)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        string strNombreColumna = dataTable.Columns[i].ColumnName;
                        string strNombreColumnaGrid = dataTable.Columns[i].ColumnName.Replace("*", "");
                        if (dgvListaTrazabilidad.Columns[strNombreColumna] == null)
                        {                            
                            dgvListaTrazabilidad.Columns.Add(strNombreColumna, strNombreColumnaGrid);                            
                            dgvListaTrazabilidad.Columns[strNombreColumna].SortMode = DataGridViewColumnSortMode.NotSortable;                                                                                                                                              
                        }
                    }

                    dgvListaTrazabilidad.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
                    //dgvListaTrazabilidad.ClearSelection();

                    for (int i = 0; i < dgvListaTrazabilidad.Columns.Count; i++)                    
                        if (dgvListaTrazabilidad.Columns[i].Name.Contains("*"))
                            dgvListaTrazabilidad.Columns[i].Selected = true;
                    
                }

                if (dgvListaTrazabilidad.Rows.Count > 0)                
                    dgvListaTrazabilidad.Rows.Clear();

                for (int i = 0; i < dataTable.Rows.Count; i++)
                        dgvListaTrazabilidad.Rows.Add(dataTable.Rows[i].ItemArray);




                //dgvListaTrazabilidad.DataSource = dataTable;

                lblCantidadRegistro.Text = $"cantidad de registros encontrados: {dataTable.Rows.Count}";
                btnDescargarCSV.Focus();
                Application.DoEvents();

                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void cbxUsuarios_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxUsuarios.SelectedValue) != 0)
                AgregarFiltro(TblAuditoriaModel.EnumCampos.Id_Usuario.ToString(), Convert.ToInt32(cbxUsuarios.SelectedValue));
            else            
                QuitarFiltro(TblAuditoriaModel.EnumCampos.Id_Usuario.ToString());
            
        }

        private void AgregarFiltro(string ClaveFiltro, dynamic ValorFiltro)
        {
            try
            {
                if (dcFiltros.ContainsKey(ClaveFiltro))                
                    dcFiltros[ClaveFiltro] = ValorFiltro;
                else                
                    dcFiltros.Add(ClaveFiltro, ValorFiltro);                                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar el filtro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QuitarFiltro(string ClaveFiltro)
        {
            try
            {
                if (dcFiltros.ContainsKey(ClaveFiltro))
                    dcFiltros.Remove(ClaveFiltro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar el filtro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxImpresoras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxImpresoras.SelectedValue) != 0)
                AgregarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_Impresora.ToString(), Convert.ToInt32(cbxImpresoras.SelectedValue));
            else            
                QuitarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_Impresora.ToString());
            
        }

        private void cbxTipoImpresion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxTipoImpresion.SelectedValue) != 0)
                AgregarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_tipoImpresion.ToString(), Convert.ToInt32(cbxTipoImpresion.SelectedValue));
            else            
                QuitarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_tipoImpresion.ToString());
            
        }

        private void cbxNovedad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxNovedad.SelectedValue) != 0)
                AgregarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_novedad.ToString(), Convert.ToInt32(cbxNovedad.SelectedValue));
            else            
                QuitarFiltro(TblDescripcionRepuestoModel.EnumCampos.Id_novedad.ToString());
            
        }

        private void cbxEstados_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbxEstados.SelectedValue) != 0)
                AgregarFiltro(TblAuditoriaModel.EnumCampos.Id_Estado.ToString(), Convert.ToInt32(cbxEstados.SelectedValue));
            else            
                QuitarFiltro(TblAuditoriaModel.EnumCampos.Id_Estado.ToString());
            
        }

        private void txtCodigoBarrasCuadernillo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasCuadernillo.Text))                    
                        throw new Exception("Por favor ingresar un codigo de cuadernillo.");

                    AgregarFiltro("CodigoCuadernillo", txtCodigoBarrasCuadernillo.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al ingresar código cuadernillo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasCuadernillo.Text))
                    QuitarFiltro("CodigoCuadernillo");
            }
        }

        private void txtCodigoBarrasHojaRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasHojaRespuesta.Text))                    
                        throw new Exception("Por favor ingresar un codigo de hoja de repuesta.");

                    AgregarFiltro("CodigoHojaRespuesta", txtCodigoBarrasHojaRespuesta.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al ingresar código de hoja de repuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasHojaRespuesta.Text))
                    QuitarFiltro("CodigoHojaRespuesta");
            }
        }

        private void txtIdRepuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtIdRepuesto.Text) || string.IsNullOrWhiteSpace(txtIdRepuesto.Text))
                        throw new Exception("Por favor ingresar el id de repuesto.");

                    AgregarFiltro("IdRepuesto", txtIdRepuesto.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al ingresar el id de repuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (string.IsNullOrEmpty(txtIdRepuesto.Text) || string.IsNullOrWhiteSpace(txtIdRepuesto.Text))
                    QuitarFiltro("IdRepuesto");
            }
        }

        private void txtCodigoSitio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtCodigoSitio.Text) || string.IsNullOrWhiteSpace(txtCodigoSitio.Text))
                        throw new Exception("Por favor ingresar el código de sitio.");

                    AgregarFiltro("CodigoSitio", txtCodigoSitio.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al ingresar el código de sitio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (string.IsNullOrEmpty(txtCodigoSitio.Text) || string.IsNullOrWhiteSpace(txtCodigoSitio.Text))
                    QuitarFiltro("CodigoSitio");
            }
        }

        private void txtCodigoActa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    if (string.IsNullOrEmpty(txtCodigoActa.Text) || string.IsNullOrWhiteSpace(txtCodigoActa.Text))
                        throw new Exception("Por favor ingresar el código de acta.");

                    AgregarFiltro("CodigoActa", txtCodigoActa.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al ingresar el código de acta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (e.KeyChar == (char)Keys.Back)
            {
                if (string.IsNullOrEmpty(txtCodigoActa.Text) || string.IsNullOrWhiteSpace(txtCodigoActa.Text))
                    QuitarFiltro("CodigoActa");
            }
        }

        private void btnGuardarRespuesto_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasCuadernillo.Text))
                    QuitarFiltro("CodigoCuadernillo");
                else                
                    AgregarFiltro("CodigoCuadernillo", txtCodigoBarrasCuadernillo.Text);
                

                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasHojaRespuesta.Text))
                    QuitarFiltro("CodigoHojaRespuesta");
                else                
                    AgregarFiltro("CodigoHojaRespuesta", txtCodigoBarrasHojaRespuesta.Text);
                

                if (string.IsNullOrEmpty(txtIdRepuesto.Text) || string.IsNullOrWhiteSpace(txtIdRepuesto.Text))
                    QuitarFiltro("IdRepuesto");
                else                
                    AgregarFiltro("IdRepuesto", txtIdRepuesto.Text);
                

                if (string.IsNullOrEmpty(txtCodigoSitio.Text) || string.IsNullOrWhiteSpace(txtCodigoSitio.Text))
                    QuitarFiltro("CodigoSitio");
                else                
                    AgregarFiltro("CodigoSitio", txtCodigoSitio.Text);
                

                if (string.IsNullOrEmpty(txtCodigoActa.Text) || string.IsNullOrWhiteSpace(txtCodigoActa.Text))
                    QuitarFiltro("CodigoActa");
                else                
                    AgregarFiltro("CodigoActa", txtCodigoActa.Text);
                

                dtbFiltrosEncontrados = Buscar();

                int cantidadRegistros = dtbFiltrosEncontrados.Rows.Count;

                if (cantidadRegistros > 0)                
                    MessageBox.Show($"Se encontrarón {cantidadRegistros} registros.", "Búsqueda Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                else                
                    MessageBox.Show($"No se encontraron registros", "Búsqueda No Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Warning);                                

                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;

                MessageBox.Show(ex.Message,"Error al realizar busqueda", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescargarCSV_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtbFiltrosEncontrados.Rows.Count <= 0)
                    throw new Exception("Por favor realizar búsqueda para poder generar el archivo CSV.");
 
                Helpers.File file1 = new Helpers.File();
                DateTime dateTime = DateTime.Now;

                string strRutaArchivo = $@"C:\MarquesaReplenish\RoporteTrazabilidad\ArchivoTrazabilidad_{dateTime.Year:0000}{dateTime.Month:00}{dateTime.Day:00}_{dateTime.Hour:00}{dateTime.Minute:00}{dateTime.Second:00}.csv";

                DataTable dtbFiltrosEncontradosGenerar = dtbFiltrosEncontrados.Copy();

                for (int i = 0; i < dgvListaTrazabilidad.Columns.Count; i++)
                {
                    DataGridViewColumn ColumnSeleccionada = dgvListaTrazabilidad.Columns[i];
                    if (!ColumnSeleccionada.Selected)                    
                        dtbFiltrosEncontradosGenerar.Columns.Remove(ColumnSeleccionada.Name);
                    else                    
                        dtbFiltrosEncontradosGenerar.Columns[ColumnSeleccionada.Name].ColumnName = ColumnSeleccionada.Name.Replace("*","");
                                        
                }

                file1.GenerarArchivo(dtbFiltrosEncontradosGenerar, true, strRutaArchivo, "|");

                dtbFiltrosEncontradosGenerar = new DataTable();

                MessageBox.Show($"Ruta del archivo: {strRutaArchivo}","Archivo Generado con Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al generar el archivo CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
