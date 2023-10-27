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
    public partial class FrmAuditoriaRepuesto : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();
        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoCiclo = new List<TblConfiguracionRepuestoModel>();
        private List<TblDetalleRepuestoModel> _ltsDetalleRepuestoModel = new List<TblDetalleRepuestoModel>();
        private List<TblRepuestoModel> _ltsRepuestoModel = new List<TblRepuestoModel>();
        private List<TblAuditoriaModel> _ltsAuditoriaModels = new List<TblAuditoriaModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoModel = new List<TblConfiguracionRepuestoModel>();
        private List<TblParteCicloModel> _ltsParteCicloModel = new List<TblParteCicloModel>();
        private List<TblEstadoModel> _ltsEstadoModel = new List<TblEstadoModel>();
        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();        
        private TblExaminandoManager _tblExaminandoManager = new TblExaminandoManager();
        private TblDetalleRepuestoManager _tblDetalleRepuestoManager = new TblDetalleRepuestoManager();
        private TblRepuestoManager _tblRepuestoManager = new TblRepuestoManager();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();
        private TblParteCicloManager _tblParteCicloManager = new TblParteCicloManager();
        private TblEstadoManager _tblEstadoManager = new TblEstadoManager();
        private TblExaminandoModel _tblExaminandoModel = null;
        private TblDetalleRepuestoModel _tblDetalleRepuesto = null;
        private List<TblEstadoModel> _ltsEstadosExaminando = new List<TblEstadoModel>();


        public FrmAuditoriaRepuesto(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
            CargarComboClient();
            CargarListaEstados();
        }

        private void CargarListaEstados()
        {
            try
            {
                _tblEstadoManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblEstadoManager._conex.Open();
                _tblEstadoManager._tx = _tblEstadoManager._conex.BeginTransaction();

                _ltsEstadoModel = _tblEstadoManager.GetFullTableTblEstado().Where(t => t.Estado == true).ToList();

                if (_ltsEstadoModel.Count == 0)
                    throw new Exception("La lista de estado esta vacia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la lista de estados.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void cbxCLientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (cbxSeleccionarPruebas.SelectedIndex >= 0)
                {
                    cbxCiclos.DataSource = null;
                    cbxCiclos.SelectedIndex = -1;
                    cbxSeleccionarPruebas.DataSource = null;
                    cbxSeleccionarPruebas.SelectedIndex = -1;
                }
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

        private void txtCodigoBarrasCuadernillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) 
            {
                try
                {

                    ValidarFormulario();

                    if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text))
                        throw new Exception("* Por favor ingrese lea el codigo de barra del cuadernillo.");

                    txtCodigoBarrasHojaRespuesta.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al leer el código de barra del cuadernillo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }                
            }
        }

        private bool ValidarExaminando(string CodigoBarrasCuadernillo, string CodigoBarrasHojaRespuesta)
        {
            SqlConnection conex = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _ltsAuditoriaModels = new List<TblAuditoriaModel>();
                _ltsRepuestoModel = new List<TblRepuestoModel>();
                _ltsConfiguracionRepuestoModel = new List<TblConfiguracionRepuestoModel>();
                _ltsParteCicloModel = new List<TblParteCicloModel>();
                _ltsEstadosExaminando = new List<TblEstadoModel>();
                _tblDetalleRepuesto = null;
                Dictionary<string, List<TblAuditoriaModel>> keyValues = new Dictionary<string, List<TblAuditoriaModel>>();
                List<TblDetalleRepuestoModel> ltsDetalleRepuestosXCiclos = new List<TblDetalleRepuestoModel>();

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                //transaction = conex.BeginTransaction();

                _tblExaminandoManager._conex = conex;
                _tblDetalleRepuestoManager._conex = conex;
                _tblRepuestoManager._conex = conex;
                _tblAuditoriaManager._conex = conex;
                _tblConfiguracionRepuestoManager._conex = conex;
                _tblParteCicloManager._conex = conex;
                _tblEstadoManager._conex = conex;

                _tblExaminandoModel = _tblExaminandoManager.GetTableTblExaminandoXCuadernilloYHojaRespuesta(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue),CodigoBarrasCuadernillo, CodigoBarrasHojaRespuesta);

                if (_tblExaminandoModel == null)
                    throw new Exception($"* El código de barra del cuadernillo '{CodigoBarrasCuadernillo}' y hoja de respuesta '{CodigoBarrasHojaRespuesta}' no existe.");

                _ltsDetalleRepuestoModel = _tblDetalleRepuestoManager.GetTableTblDetalleRepuestoXTblExaminando(_tblExaminandoModel.Id);

                if (_ltsDetalleRepuestoModel.Count <= 0)
                    throw new Exception($"* El código de barra del cuadernillo '{CodigoBarrasCuadernillo}' y hoja de respuesta '{CodigoBarrasHojaRespuesta}' con el consecutivo '{_tblExaminandoModel.IdConsecutivo}' no se le ha ingresado repuesto.");

                foreach (var item in _ltsDetalleRepuestoModel)
                {
                    TblRepuestoModel tblRepuesto = _tblRepuestoManager.GetData(item.Id_Repuesto);
                    TblConfiguracionRepuestoModel tblConfiguracion = _tblConfiguracionRepuestoManager.GetData(tblRepuesto.Id_ConfiguracionRepuesto);

                    if (tblConfiguracion.Ciclo == cbxCiclos.Text)
                    {
                        _ltsRepuestoModel.Add(tblRepuesto);
                        _ltsConfiguracionRepuestoModel.Add(tblConfiguracion);
                        ltsDetalleRepuestosXCiclos.Add(item);
                    }
                }

                //if (_ltsRepuestoModel.Count <= 0)
                //    throw new Exception($"El código de barra del cuadernillo '{CodigoBarrasCuadernillo}' y hoja de respuesta '{CodigoBarrasHojaRespuesta}' con el consecutivo '{_tblExaminandoModel.IdConsecutivo}' no puedo obtener los repuesto ingresados.");                
                if (_ltsConfiguracionRepuestoModel.Count <= 0)
                    throw new Exception($"* El código de barra del cuadernillo '{CodigoBarrasCuadernillo}' y hoja de respuesta '{CodigoBarrasHojaRespuesta}' con el consecutivo '{_tblExaminandoModel.IdConsecutivo}' no pertenece al ciclo '{cbxCiclos.Text}'.");
                
                _tblDetalleRepuesto = ltsDetalleRepuestosXCiclos.OrderBy(t => t.Id).Last();

                List<TblAuditoriaModel> ltsAuditorias = _tblAuditoriaManager.GetTableTblAuditoriaXTblDetalleRepuesto(_tblDetalleRepuesto.Id);
                foreach (TblAuditoriaModel itemAuditoria in ltsAuditorias)
                {
                    TblEstadoModel tblEstado = _ltsEstadoModel.Find(t => t.Id == itemAuditoria.Id_Estado);
                    if (tblEstado.Codigo != "01")                    
                        throw new Exception($"* El código de barra del cuadernillo '{CodigoBarrasCuadernillo}' y hoja de respuesta '{CodigoBarrasHojaRespuesta}' con el consecutivo '{_tblExaminandoModel.IdConsecutivo}' esta con estado '{tblEstado.Nombre}'.");
                    
                    _ltsAuditoriaModels.Add(itemAuditoria);
                }

                if (_ltsAuditoriaModels.Count <= 0)
                    throw new Exception($"* El código de barra del cuadernillo '{CodigoBarrasCuadernillo}' y hoja de respuesta '{CodigoBarrasHojaRespuesta}' con el consecutivo '{_tblExaminandoModel.IdConsecutivo}' no puedo obtener las auditorias realizadas.");                

                //txtCuartilla1Cuadernillo.Focus();

                this.Cursor = Cursors.Default;
                return true;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                this.txtCodigoBarrasCuadernillo.Enabled = true;
                this.txtCodigoBarrasHojaRespuesta.Enabled = true;
                this.txtCodigoBarrasCuadernillo.Clear();
                this.txtCodigoBarrasHojaRespuesta.Clear();
                this.txtCodigoBarrasCuadernillo.Focus();
                throw new Exception($"Error al obtener el cuadernillo:{Environment.NewLine}{ex.Message}");
            }
        }

        private void ValidarFormulario()
        {
            try
            {
                List<string> ltsMensaje = new List<string>();

                if (cbxCLientes.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione el cliente.");
                if (cbxSeleccionarPruebas.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione la prueba.");
                if (cbxCiclos.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione el ciclo.");

                if (ltsMensaje.Count > 0)                
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtCodigoBarrasHojaRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    ValidarCuadernillo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al leer el código de barra de Hoja Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidarCuadernillo()
        {
            try
            {
                List<string> ltsMensajes = new List<string>();

                ValidarFormulario();

                if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea el código de barra del cuadernillo.");

                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea el código de barra de hoja de respuesta.");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                if (txtCodigoBarrasCuadernillo.Text == txtCodigoBarrasHojaRespuesta.Text)
                    throw new Exception("* los Código de barras de cuadernillo y hoja de respuesta ingresados son iguales, por favor validar.");

                if (ValidarExaminando(txtCodigoBarrasCuadernillo.Text, txtCodigoBarrasHojaRespuesta.Text))                
                    txtTipoHR.Focus();
                 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtCuartilla1Cuadernillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    ValidarCuartilla();
                }
                catch (Exception ex)
                {
                    txtCuartilla1Cuadernillo.Clear();
                    txtCuartilla1Cuadernillo.Focus();
                    MessageBox.Show(ex.Message, "Error al leer la Cuartilla final del Cuadernillo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidarCuartilla()
        {
            try
            {
                List<string> ltsMensajes = new List<string>();

                ValidarFormulario();

                if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea el código de barra del cuadernillo.");

                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea el código de barra de hoja de respuesta.");

                if (txtCodigoBarrasCuadernillo.Text == txtCodigoBarrasHojaRespuesta.Text)
                    ltsMensajes.Add("los Código de barras ingresados son iguales, por favor validar.");

                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text))
                    throw new Exception("* Por favor ingrese ó lea el código de barra Tipo HR.");

                if (string.IsNullOrEmpty(txtCuartilla1Cuadernillo.Text) || string.IsNullOrEmpty(txtCuartilla1Cuadernillo.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea la cuartilla 1 del cuadernillo.");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                string strCuartillaYCantodad = ObtenerNumeroCuartillaYCantidad(txtCuartilla1Cuadernillo.Text);

                if (string.IsNullOrEmpty(strCuartillaYCantodad))
                    throw new Exception("No se puedo obtener el numero de cuartilla ni la cantidad.");

                string[] arrCuartillaYCantodad = strCuartillaYCantodad.Split('|');

                //if (Convert.ToInt32(arrCuartillaYCantodad[0]) != 1)
                //    throw new Exception("Se tiene que auditar la cuartilla número 01");

                if (Convert.ToInt32(_tblExaminandoModel.IdConsecutivo) != Convert.ToInt32(arrCuartillaYCantodad[2]))
                    throw new Exception($"* El consecutivo '{Convert.ToInt32(arrCuartillaYCantodad[2])}' de la cuartilla no concuerda con código de cuadernillo '{_tblExaminandoModel.CodigoCuadernillo}' y la hoja de repuesto '{_tblExaminandoModel.CodigoHojaRespuesta}', Por favor validar.");

                txtNumeroCuartillaInicial.Text = "01";
                txtNumeroCuartillaFinal.Text = arrCuartillaYCantodad[1];
                lblIdCons.Text = $"{Convert.ToInt32(arrCuartillaYCantodad[2])}";

                CuartillaNCuadernillo.Text = CuartillaNCuadernillo.Text.Replace("@N", $"{(Convert.ToInt32(txtNumeroCuartillaFinal.Text) - 1):00}");
                txtNumeroCuartillaComprar.Text = $"{(Convert.ToInt32(txtNumeroCuartillaFinal.Text) - 1):00}";

                txtCodigoBarrasCuadernillo.Enabled = false;
                txtCodigoBarrasHojaRespuesta.Enabled = false;
                txtCuartilla1Cuadernillo.Enabled = false;
                txtTipoHR.Enabled = false;
                cbxCLientes.Enabled = false;
                cbxSeleccionarPruebas.Enabled = false;
                cbxCiclos.Enabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string ObtenerNumeroCuartillaYCantidad(string NumeroCuartilla)
        {
            try
            {
                List<string> ltsMensajes = new List<string>();
                int idCons = 7;

                if (NumeroCuartilla.Length == 12)
                {
                    string strNumeroCuartilla = NumeroCuartilla.Substring(0, 2);
                    string strCantidadCuartilla = NumeroCuartilla.Substring(2, 2);
                    string strIdConsecutivoCuartilla = NumeroCuartilla.Substring((NumeroCuartilla.Length - idCons), idCons);

                    int numeroCuartilla = 0;
                    int cantidadCuartilla = 0;
                    int IdConsecutivoCuartilla = 0;

                    int.TryParse(strNumeroCuartilla, out numeroCuartilla);
                    int.TryParse(strCantidadCuartilla, out cantidadCuartilla);
                    int.TryParse(strIdConsecutivoCuartilla, out IdConsecutivoCuartilla);

                    if (numeroCuartilla == 0)
                        ltsMensajes.Add($"El número de cuartilla {strNumeroCuartilla} no es correcto.");

                    if (cantidadCuartilla == 0)
                        ltsMensajes.Add($"La cantidad de cuartilla {strCantidadCuartilla} no es correcto.");

                    if (IdConsecutivoCuartilla == 0)
                        ltsMensajes.Add($"El IdCons de la cuartilla {strIdConsecutivoCuartilla} no es correcto.");

                    return $"{strNumeroCuartilla}|{strCantidadCuartilla}|{strIdConsecutivoCuartilla}";
                }

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtCuartillaNCuadernillo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SqlConnection conex = null;
                SqlTransaction transaction = null;

                try
                {
                    List<string> ltsMensajes = new List<string>();

                    conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                    conex.Open();
                    transaction = conex.BeginTransaction();


                    _tblAuditoriaManager._conex = conex;
                    _tblAuditoriaManager._tx = transaction;


                    ValidarFormulario();

                    if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text))
                        ltsMensajes.Add("* Por favor ingrese o lea el código de barra del cuadernillo.");

                    if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text))
                        ltsMensajes.Add("* Por favor ingrese o lea el código de barra de hoja de respuesta.");

                    if (string.IsNullOrEmpty(txtCuartilla1Cuadernillo.Text) || string.IsNullOrEmpty(txtCuartilla1Cuadernillo.Text))
                        ltsMensajes.Add("* Por favor ingrese o lea la cuartilla 1 del cuadernillo.");

                    if (ltsMensajes.Count > 0)
                        throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                    if (txtCodigoBarrasCuadernillo.Text == txtCodigoBarrasHojaRespuesta.Text)
                        throw new Exception("* los Código de barras ingresados son iguales, por favor validar.");


                    if (string.IsNullOrEmpty(txtCuartillaNCuadernillo.Text) || string.IsNullOrEmpty(txtCuartillaNCuadernillo.Text))
                        throw new Exception($"* Por favor ingrese o lea la cuartilla {(Convert.ToInt32(txtNumeroCuartillaInicial.Text) + 1):00} del cuadernillo.");

                    string strCuartillaYCantodad = ObtenerNumeroCuartillaYCantidad(txtCuartillaNCuadernillo.Text);

                    if (string.IsNullOrEmpty(strCuartillaYCantodad))
                        throw new Exception("* No se puedo obtener el numero de cuartilla ni la cantidad.");

                    string[] arrCuartillaYCantodad = strCuartillaYCantodad.Split('|');

                    if (arrCuartillaYCantodad[0] == txtNumeroCuartillaComprar.Text)
                    {
                        if (Convert.ToInt32(_tblExaminandoModel.IdConsecutivo) != Convert.ToInt32(arrCuartillaYCantodad[2]))
                            throw new Exception($"* El consecutivo '{Convert.ToInt32(arrCuartillaYCantodad[2])}' de la cuartilla no concuerda con código de cuadernillo '{_tblExaminandoModel.CodigoCuadernillo}' y la hoja de repuesto '{_tblExaminandoModel.CodigoHojaRespuesta}', Por favor validar.");

                        if (arrCuartillaYCantodad[0] == txtNumeroCuartillaInicial.Text)
                        {
                            TblAuditoriaModel tblAuditoria = new TblAuditoriaModel();
                            tblAuditoria.Id_DetalleRepuesto = _tblDetalleRepuesto.Id;
                            tblAuditoria.Id_Estado = _ltsEstadoModel.Find(t => t.Codigo == "02").Id;
                            tblAuditoria.Id_Usuario = _tblUsuarioModel.Id;
                            tblAuditoria.FechaHora = DateTime.Now;
                            tblAuditoria.Observacion = $"Repuesto Auditado: Se audita el numero de repuesto {_tblExaminandoModel.IdConsecutivo} con código de barra del cuadernillo {txtCodigoBarrasCuadernillo.Text} y hoja de respuesta {txtCodigoBarrasHojaRespuesta.Text}.";
                            _tblAuditoriaManager.Guardar(tblAuditoria);
                            transaction.Commit();
                            MessageBox.Show($"Cuadernillo: {txtCodigoBarrasCuadernillo.Text}{Environment.NewLine}" +
                                            $"Hoja de respuesta: {txtCodigoBarrasHojaRespuesta.Text}{Environment.NewLine}" +
                                            $"Estado: {_ltsEstadoModel.Find(t => t.Codigo == "02").Nombre}{Environment.NewLine}" +
                                            $"Se auditarón: {txtNumeroCuartillaFinal.Text} cuartilla", $"Repuesto auditado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            LimpiarFormulario();
                        }
                        else
                        {
                            CuartillaNCuadernillo.Text = CuartillaNCuadernillo.Text.Replace($"{arrCuartillaYCantodad[0]}", $"{(Convert.ToInt32(arrCuartillaYCantodad[0]) - 1):00}");
                            txtNumeroCuartillaComprar.Text = $"{(Convert.ToInt32(arrCuartillaYCantodad[0]) - 1):00}";
                            txtCuartillaNCuadernillo.Text = string.Empty;
                            txtCuartillaNCuadernillo.Focus();
                        }
                    }
                    else
                    {
                        throw new Exception($"* La cuartilla '{arrCuartillaYCantodad[0]}' del cuadernillo no es consecutiva, por favor leer o ingresar la cuartilla '{txtNumeroCuartillaComprar.Text}'.");
                    }

                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();

                    txtCuartillaNCuadernillo.Clear();
                    txtCuartillaNCuadernillo.Focus();
                    MessageBox.Show(ex.Message, "Error al leer la Cuartilla @N del Cuadernillo".Replace("@N", txtNumeroCuartillaComprar.Text), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                {
                    if (conex != null)
                        conex.Close();
                }
            }
        }

        private void LimpiarFormulario()
        {
            cbxCLientes.Enabled = true;
            //cbxCLientes.SelectedIndex = -1;
            //cbxSeleccionarPruebas.DataSource = null;
            //cbxSeleccionarPruebas.SelectedIndex = -1;
            cbxSeleccionarPruebas.Enabled = true;
            //cbxCiclos.DataSource = null;
            //cbxCiclos.SelectedIndex = -1;
            cbxCiclos.Enabled = true;
            txtCodigoBarrasCuadernillo.Clear();
            txtCodigoBarrasCuadernillo.Enabled = true;
            txtCodigoBarrasCuadernillo.Focus();
            txtCodigoBarrasHojaRespuesta.Clear();
            txtCodigoBarrasHojaRespuesta.Enabled = true;
            txtCuartilla1Cuadernillo.Clear();
            txtCuartilla1Cuadernillo.Enabled = true;
            txtNumeroCuartillaInicial.Clear();
            txtNumeroCuartillaFinal.Clear();
            txtNumeroCuartillaComprar.Clear();
            CuartillaNCuadernillo.Text = "Cuartilla @N Cuadernillo:";
            txtCuartillaNCuadernillo.Clear();
            txtTipoHR.Clear();  
            txtTipoHR.Enabled = true;
        }

        private void cbxCiclos_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!(cbxCiclos.SelectedIndex < 0))            
                txtCodigoBarrasCuadernillo.Focus();            
        }

        private void txtTipoHR_Enter(object sender, EventArgs e)
        {
            try
            {
                if (_tblDetalleRepuesto == null && _tblExaminandoModel == null)                 
                    ValidarCuadernillo();                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al validar el código de barra de cuadernillo y hoja de repuesta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTipoHR_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                try
                {
                    ValidarTipoHR();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al validar el código de barra Tipo HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ValidarTipoHR()
        {
            try
            {
                List<string> ltsMensajes = new List<string>();

                ValidarFormulario();

                if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea el código de barra del cuadernillo.");

                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text))
                    ltsMensajes.Add("* Por favor ingrese ó lea el código de barra de hoja de respuesta.");

                if (txtCodigoBarrasCuadernillo.Text == txtCodigoBarrasHojaRespuesta.Text)
                    ltsMensajes.Add("* los Código de barras ingresados son iguales, por favor validar.");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text))
                    throw new Exception("* Por favor ingrese ó lea el código de barra Tipo HR.");

                if (_tblExaminandoModel.TipoHR != txtTipoHR.Text) 
                {
                    string strTipoHR = txtTipoHR.Text;
                    txtTipoHR.Focus();
                    txtTipoHR.Clear();
                    throw new Exception($"El código de barra Tipo HR '{strTipoHR}' no concuerda con el codigo del cuadernillo '{txtCodigoBarrasCuadernillo.Text}' y hoja de respuesta '{txtCodigoBarrasHojaRespuesta.Text}'.");
                }

                txtCuartilla1Cuadernillo.Focus();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void txtCuartilla1Cuadernillo_Enter(object sender, EventArgs e)
        {
            try
            {
                ValidarTipoHR();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al validar el código de barra Tipo HR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoBarrasHojaRespuesta_Enter(object sender, EventArgs e)
        {
            try
            {
                ValidarFormulario();

                if (string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text) || string.IsNullOrEmpty(txtCodigoBarrasCuadernillo.Text))
                    throw new Exception("* Por favor ingrese ó lea el código de barra del cuadernillo.");
            }
            catch (Exception ex)
            {
                txtCodigoBarrasCuadernillo.Focus();
                MessageBox.Show(ex.Message, "Error al leer el codigo de barra del cuadernillo.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCuartillaNCuadernillo_Enter(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNumeroCuartillaComprar.Text))
                    ValidarCuartilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al leer la Cuartilla final del Cuadernillo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
