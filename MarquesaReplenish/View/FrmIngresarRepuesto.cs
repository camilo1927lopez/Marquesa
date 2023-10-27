using BDManager;
using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesaReplenish.View
{
    public partial class FrmIngresarRepuesto : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();
        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoCiclo = new List<TblConfiguracionRepuestoModel>();
        private List<TblFormatoSalidaModel> _ltsFormatoSalida = new List<TblFormatoSalidaModel>();
        private List<TblTipoImpresionModel> _ltsTipoImpresions = new List<TblTipoImpresionModel>();
        private List<TblMaquinaModel> _ltsMaquinas = new List<TblMaquinaModel>();
        private List<TblImpresoraModel> _tblImpresoras = new List<TblImpresoraModel>();
        private List<TblNovedadModel> _ltsNovedads = new List<TblNovedadModel>();
        private List<TblParteCicloModel> _ltsParteCiclo = new List<TblParteCicloModel>();
        private List<TblEstadoModel> _EstadoModel = new List<TblEstadoModel>();
        private List<TblDetalleRepuestoModel> _ltsDetalleRepuestosExistente = new List<TblDetalleRepuestoModel>();
        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();
        private TblParteCicloManager _tblParteCicloManager = new TblParteCicloManager();
        private TblFormatoSalidaManager _tblFormatoSalidaManager = new TblFormatoSalidaManager();
        private TblImpresoraManager _tblImpresoraManager = new TblImpresoraManager();
        private TblTipoImpresionManager _tblTipoImpresionManager = new TblTipoImpresionManager();
        private TblMaquinaManager _tblMaquinaManager = new TblMaquinaManager();
        private TblNovedadManager _tblNovedadManager = new TblNovedadManager();
        private TblExaminandoManager _tblExaminandoManager = new TblExaminandoManager();
        private TblDetalleRepuestoManager _tblDetalleRepuestoManager = new TblDetalleRepuestoManager();
        private TblDescripcionRepuestoManager _tblDescripcionRepuestoManager = new TblDescripcionRepuestoManager();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();
        private TblRepuestoManager _tblRepuestoManager = new TblRepuestoManager();
        private TblEstadoManager _tblEstadoManager = new TblEstadoManager();
        private FrmValidarusuario _frmValidarusuario = null;
        public List<int> _ltsRangos = new List<int>();
        private DataTable dtbRangoExistentes = new DataTable();
        private string strNombreColumna = "Repuesto|Cantidad|Seleccionar";
        private TblUsuarioModel tblUsuarioLiderAutorizado = null;
        private string _RutaBaseArchivoSalidaConfigurada = Properties.Settings.Default.RutaBaseArchivoSalida.ToString();
        private string _RutaBaseTemp = Properties.Settings.Default.RutaBaseTemp.ToString();
        private string _RutaBaseArchivoSalidalocal = string.Empty;
        public FrmIngresarRepuesto(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
            CargarComboClient();
            CargarComboFormatoSalida();
            CargarComboTipoImpresion();
            CargarComboMaquina();
            InformacionFija();
            CargarListaEstados();

            string[] arrColumna = strNombreColumna.Split('|');

            for (int i = 0; i < arrColumna.Length; i++)           
                if (dtbRangoExistentes.Columns[arrColumna[i]] == null)                
                    dtbRangoExistentes.Columns.Add(arrColumna[i], arrColumna[i] == "Seleccionar" ? typeof(bool):typeof(int));

            //string strRutaBase = Path.Combine("C:\\", "MarquesaReplenish");
            string strRutaBase = _RutaBaseTemp;
            if (!Directory.Exists(strRutaBase))
                Directory.CreateDirectory(strRutaBase);

            //usrSeleccionarArchivo1.ArchivoSeleccionado = strRutaBase;
            strRutaBase = Path.Combine(strRutaBase, "@NombrePrueba");
            _RutaBaseArchivoSalidalocal = strRutaBase;
        }
        private void CargarListaEstados()
        {
            try
            {
                _tblEstadoManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblEstadoManager._conex.Open();
                _tblEstadoManager._tx = _tblEstadoManager._conex.BeginTransaction();

                _EstadoModel = _tblEstadoManager.GetFullTableTblEstado().Where(t => t.Estado == true).ToList();

                if (_EstadoModel.Count == 0)
                    throw new Exception("La lista de estado esta vacia.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar la lista de estados.");
            }
        }
        public void InsertarRowTable(int Desde, int Hasta) 
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblExaminandoManager._conex = conex;
                _tblExaminandoManager._tx = transaction;
                _tblDetalleRepuestoManager._conex = conex;
                _tblDetalleRepuestoManager._tx = transaction;
                _tblRepuestoManager._conex = conex;
                _tblRepuestoManager._tx = transaction;
                _tblConfiguracionRepuestoManager._conex = conex;
                _tblConfiguracionRepuestoManager._tx = transaction;

                List<string> ltsMensjase = new List<string>();

                if (Desde <= 0)
                    ltsMensjase.Add($"* Por favor ingresar en el campo desde.");
                if ((Hasta <= Desde) && Hasta > 0)
                    ltsMensjase.Add($"* El campo hasta '{Hasta}' debe ser mayor al campo desde '{Desde}'.");

                if (ltsMensjase.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensjase)}");

                if (Hasta <= 0)
                    Hasta = Desde;

                int resultadoMaximaRepuesto = (Hasta - Desde) + 1;
                resultadoMaximaRepuesto = _ltsRangos.Count + resultadoMaximaRepuesto;
                int cantidadMaximaRepuesto = Convert.ToInt32(txtRangoMaximoGeneracionRepuestos.Text);


                if (resultadoMaximaRepuesto > cantidadMaximaRepuesto)
                    throw new Exception($"La cantidad maxima para generar repuesto es de '{cantidadMaximaRepuesto}' y se esta ingresando un cantidad de '{resultadoMaximaRepuesto}'");


                TblParteCicloModel parteCiclo = _ltsParteCiclo.Where(t => t.Id == Convert.ToInt32(cbxPartes.SelectedValue)).FirstOrDefault();

                if (!(Desde >= parteCiclo.RangoInical  && Hasta <= parteCiclo.RangoFinal))                
                    throw new Exception($"El rango inicial '{Desde}' y el rango final '{Hasta}' ingresado no pertenese a la parte '{parteCiclo.NumeroParte} : ({parteCiclo.RangoInical} - {parteCiclo.RangoFinal})'.");
                

            
                for (int i = Desde; i <= Hasta; i++)
                {
                    if (_ltsRangos.Where(t => t == i).Count() <= 0) 
                    {
                        TblExaminandoModel tblExaminando =  _tblExaminandoManager.GetTableTblExaminandoXTblCargueArchivo(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue),i);
                        List<TblDetalleRepuestoModel> ltsDetalleRepuestos = new List<TblDetalleRepuestoModel>();
                        if (tblExaminando != null)
                            ltsDetalleRepuestos = _tblDetalleRepuestoManager.GetTableTblDetalleRepuestoXTblExaminando(tblExaminando.Id);

                        List<TblDetalleRepuestoModel> ltsDetalleRepuestosXCiclo = new List<TblDetalleRepuestoModel>();

                        foreach (var item in ltsDetalleRepuestos)
                        {
                            TblRepuestoModel tblRepuesto = _tblRepuestoManager.GetData(item.Id_Repuesto);
                            TblConfiguracionRepuestoModel tblConfiguracionRepuesto = _tblConfiguracionRepuestoManager.GetData(tblRepuesto.Id_ConfiguracionRepuesto);

                            if (tblConfiguracionRepuesto.Ciclo == cbxCiclos.Text)                            
                                ltsDetalleRepuestosXCiclo.Add(item);
                            
                        }

                        if (ltsDetalleRepuestosXCiclo.Count > 0) 
                        {
                            MessageBox.Show($"El repuesto '{i}' que esta intentando generar ya tiene repuestos asignado.{Environment.NewLine}" +
                                $"Por favor comunicarse con su lider si desae generarlo nuevamente.{Environment.NewLine}{Environment.NewLine}" +
                                $"NOTA: El proceso siguiente se necesita presencia del lider del area para poder continuar.", "Repuesto Existente", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            dtbRangoExistentes.Rows.Add(i, ltsDetalleRepuestosXCiclo.Count, true);
                            _ltsDetalleRepuestosExistente.AddRange(ltsDetalleRepuestosXCiclo);
                        }                                                                                                         

                        _ltsRangos.Add(i);
                        dgvRepuestoIngresados.Rows.Add(i.ToString());
                    }
                    else                    
                        MessageBox.Show($"El repuesto '{i}' que esta intentando ya existe en la tabla.", "Repuesto Existente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }                

                dgvRepuestoIngresados.AllowUserToOrderColumns = true;
                dgvRepuestoIngresados.AutoGenerateColumns = true;
                dgvRepuestoIngresados.AutoResizeColumns();                
                //dgvRepuestoIngresados.Sort(dgvRepuestoIngresados.Columns[0] , ListSortDirection.Ascending);

                Application.DoEvents();

                lblCantidadRepuesto.Text = $"{_ltsRangos.Count:000}";
                usrHasta.Text = string.Empty;
                usrDesde.Text = string.Empty;
                usrDesde.Focus();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                usrHasta.Text = string.Empty;
                usrDesde.Text = string.Empty;
                usrDesde.Focus();
                this.Cursor = Cursors.Default;
                throw new Exception(ex.Message);
            }
        }
        public void InsertarRowTable(string RutaArchivoRango)
        {            
            try
            {
                if (dgvRepuestoIngresados.Rows.Count > 0)
                {
                    if (MessageBox.Show($"ya existe repuesto ingresados en la tabla, deseas limplar la tabla ?.{Environment.NewLine}{Environment.NewLine}" +
                        $"Si (Para limpiar){Environment.NewLine}" +
                        $"No (Para agregar sin limpiar la tabla.)","Ingresando repuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        dgvRepuestoIngresados.Rows.Clear();
                        _ltsRangos = new List<int>();
                        _ltsDetalleRepuestosExistente = new List<TblDetalleRepuestoModel>();
                    }
                }

                using (StreamReader reader = new StreamReader(RutaArchivoRango, Encoding.Default))
                {
                    String linea;
                    int contador = 0;
                    while ((linea = reader.ReadLine()) != null)
                    {

                        if (true && contador == 0)
                        {
                            contador++;
                            continue;
                        }

                        string[] arrLines = linea.Split('|');

                        int repuesto = 0;

                        int.TryParse(arrLines[0].ToString(), out repuesto);

                        InsertarRowTable(repuesto, 0);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool VerValidarUsuarios(DataTable dtbRangoExistentes)
        {
            if ((this._frmValidarusuario == null ? true : this._frmValidarusuario.IsDisposed))
            {

                this._frmValidarusuario = new FrmValidarusuario(true,dtbRangoExistentes);
            }
            _frmValidarusuario._frmIngresarRepuesto = this;
            this._frmValidarusuario.ShowDialog();
            tblUsuarioLiderAutorizado = this._frmValidarusuario.tblUsuarioLiderAutorizado;
            return this._frmValidarusuario.Correcto;
        }
        private void InformacionFija()
        {
            txtTipoPapel.Text = "Carta";
            txtResolucion.Text = "300";
            txtImprimirPor.Text = "PQ-PAQUETE";
            txtRangoMaximoGeneracionRepuestos.Text = "200";
            gbxInformacionFija.Enabled = false;
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
                cbxFormatoSalidas.DataSource = _ltsFormatoSalida.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxFormatoSalidas.SelectedIndex = -1;

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

                _ltsTipoImpresions = _tblTipoImpresionManager.GetFullTableTblTipoImpresion();

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

                _ltsMaquinas = _tblMaquinaManager.GetFullTableTblMaquina();

                if (_ltsMaquinas.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de maquinas.");


                cbxMaquina.ValueMember = $"{TblMaquinaModel.EnumCampos.Id}";
                cbxMaquina.DisplayMember = $"{TblMaquinaModel.EnumCampos.Nombre}";
                cbxMaquina.DataSource = _ltsMaquinas.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxMaquina.SelectedIndex = -1;

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
        private void CargarComboConfiguracionRepuestosCiclos(int Id_ConfiguracionRepuestosCiclos)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblParteCicloManager._conex = conex;
                _tblParteCicloManager._tx = transaction;


                TblConfiguracionRepuestoModel tblConfiguracionRepuesto = _ltsConfiguracionRepuestoCiclo.Where(t => t.Id == Id_ConfiguracionRepuestosCiclos).FirstOrDefault();
                _ltsParteCiclo = _tblParteCicloManager.GetTableTblParteCicloXTblConfiguracionRepuesto(tblConfiguracionRepuesto.Id);

                if (_ltsParteCiclo.Count <= 0)
                    throw new Exception($"* No se ha podido obtener la lista de los rangos asociados al ciclo '{tblConfiguracionRepuesto.Ciclo}'.");


                cbxPartes.ValueMember = $"{TblParteCicloModel.EnumCampos.Id}";
                //cbxPartes.DisplayMember = $"{TblParteCicloModel.EnumCampos.NumeroParte}  ({TblParteCicloModel.EnumCampos.RangoInical} - {TblParteCicloModel.EnumCampos.RangoFinal})";
                cbxPartes.DisplayMember = $"{TblParteCicloModel.EnumCampos.NumeroParte}";
                cbxPartes.DataSource = _ltsParteCiclo.OrderBy(t => t.Id).ToList();

                cbxPartes.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                cbxCiclos.SelectedIndex = -1;
                MessageBox.Show(ex.Message, "Error al cargar la lista de rangos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cbxImpresoras.DataSource = _tblImpresoras.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxImpresoras.SelectedIndex = -1;

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
                cbxNovedad.DataSource = _ltsNovedads.Where(t => t.Estado == true).OrderBy(t => t.Id).ToList();

                cbxNovedad.SelectedIndex = -1;

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
        private void cbxCLientes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (cbxSeleccionarPruebas.SelectedIndex >= 0)
                {
                    cbxPartes.DataSource = null;
                    cbxPartes.SelectedIndex = -1;
                    cbxCiclos.DataSource = null;
                    cbxCiclos.SelectedIndex = -1;
                    cbxSeleccionarPruebas.DataSource = null; 
                    cbxSeleccionarPruebas.SelectedIndex = -1;
                }
                CargarComboPruebas(Convert.ToInt32(cbxCLientes.SelectedValue));
                MostrarGbxListadoRepuesto();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error al seleccionar el cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MostrarGbxListadoRepuesto()
        {
            if (ValidarFormulario(false))
                gbxListadoRepuesto.Enabled = true;
            else 
            {
                if (dgvRepuestoIngresados.Rows.Count > 0)
                {
                    dgvRepuestoIngresados.Rows.Clear();
                    _ltsRangos = new List<int>();
                    _ltsDetalleRepuestosExistente = new List<TblDetalleRepuestoModel>();
                    lblCantidadRepuesto.Text = "0";
                    dtbRangoExistentes.Rows.Clear();
                    MessageBox.Show("Se limpio la tabla correctamente.", "Tabla de repuesto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                gbxListadoRepuesto.Enabled = false;
            }

        }
        private bool ValidarFormulario(bool MostrarError)
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
                if (cbxPartes.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione la parte del ciclo.");
                if (cbxFormatoSalidas.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione el formato de salida.");
                if (cbxImpresoras.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione la impresora.");
                if (cbxTipoImpresion.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione el tipo de impresora.");
                if (cbxMaquina.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione la maquina.");
                if (cbxNovedad.SelectedIndex < 0)
                    ltsMensaje.Add($"* Por favor seleccione la novedad.");

                if (ltsMensaje.Count > 0)
                {
                    if (MostrarError)
                    {
                        throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);    
            }
        }
        private void cbxSeleccionarPruebas_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (cbxCiclos.SelectedIndex >= 0)
                {
                    cbxPartes.DataSource = null;
                    cbxPartes.SelectedIndex = -1;
                    cbxCiclos.DataSource = null;
                    cbxCiclos.SelectedIndex = -1;
                }
                CargarComboCiclos(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue));
                MostrarGbxListadoRepuesto();
                this.Cursor = Cursors.Default;
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
                this.Cursor = Cursors.WaitCursor;
                if (cbxPartes.SelectedIndex >= 0)
                {
                    cbxPartes.DataSource = null;
                    cbxPartes.SelectedIndex = -1;
                }
                CargarComboConfiguracionRepuestosCiclos(Convert.ToInt32(cbxCiclos.SelectedValue));
                MostrarGbxListadoRepuesto();
                this.Cursor = Cursors.Default;
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
                this.Cursor = Cursors.WaitCursor;
                if (cbxImpresoras.SelectedIndex >= 0)
                {
                    cbxImpresoras.DataSource = null;
                    cbxImpresoras.SelectedIndex = -1;
                }
                CargarComboImpresora(Convert.ToInt32(cbxFormatoSalidas.SelectedValue));
                MostrarGbxListadoRepuesto();
                this.Cursor = Cursors.Default;
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
                this.Cursor = Cursors.WaitCursor;
                if (cbxNovedad.SelectedIndex >= 0)
                {
                    cbxNovedad.DataSource = null;
                    cbxNovedad.SelectedIndex = -1;
                }
                CargarComboNovedad(Convert.ToInt32(cbxMaquina.SelectedValue));
                MostrarGbxListadoRepuesto();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al seleccionar el formato de salida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void usrHasta_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //El caracter 13 corresponde a la tecla Enter.
            {
                try
                {
                    if (string.IsNullOrEmpty(usrHasta.Text))
                        usrHasta.Text = "00";
                    if (string.IsNullOrEmpty(usrDesde.Text))
                        usrDesde.Text = "00";
                    InsertarRowTable(Convert.ToInt32(usrDesde.Text), Convert.ToInt32(usrHasta.Text));
                }
                catch (Exception ex)
                {
                    usrHasta.Focus();
                    usrHasta.Text = string.Empty;
                    MessageBox.Show(ex.Message,"Error al ingresar los rangos.");
                }
            }
        }
        private void usrDesde_KeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) //El caracter 13 corresponde a la tecla Enter.
            {
                try
                {
                    if (string.IsNullOrEmpty(usrHasta.Text))
                        usrHasta.Text = "00";
                    if (string.IsNullOrEmpty(usrDesde.Text))
                        usrDesde.Text = "00";
                    InsertarRowTable(Convert.ToInt32(usrDesde.Text), Convert.ToInt32(usrHasta.Text));
                }
                catch (Exception ex)
                {
                    usrDesde.Focus();
                    usrDesde.Text = string.Empty;
                    MessageBox.Show(ex.Message, "Error al ingresar los rangos.");
                }                
            }
        }
        private void cbxPartes_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MostrarGbxListadoRepuesto();
        }
        private void cbxImpresoras_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MostrarGbxListadoRepuesto();
        }
        private void cbxTipoImpresion_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MostrarGbxListadoRepuesto();
        }
        private void cbxNovedad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            MostrarGbxListadoRepuesto();
        }
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                InsertarRowTable(Convert.ToInt32(usrDesde.Text), Convert.ToInt32(usrHasta.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar los rangos.");
            }
            
        }
        private void usrSeleccionarArchivo1_OnSeleccionArchivo(object sender, WinFormsControlLibrary.usrSeleccionarArchivo.SeleccionArchivoEventArgs e)
        {
            try
            {
                if (!Functions.FileHelper.ExisteArchivo(usrSeleccionarArchivo1.ArchivoSeleccionado, false))
                    throw new Exception($"el archivo seleccionado {Path.GetFileName(usrSeleccionarArchivo1.ArchivoSeleccionado)} no existe en la ruta {Path.GetDirectoryName(usrSeleccionarArchivo1.ArchivoSeleccionado)}.");

                InsertarRowTable(usrSeleccionarArchivo1.ArchivoSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al ingresar los rangos.");
            }
        }
        private void btnGuardarRespuesto_Click(object sender, EventArgs e)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                this.btnGuardarRespuesto.Enabled = false;

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();


                _tblDescripcionRepuestoManager._conex = conex;
                _tblDescripcionRepuestoManager._tx = transaction;
                _tblRepuestoManager._conex = conex;
                _tblRepuestoManager._tx = transaction;
                _tblDetalleRepuestoManager._conex = conex;
                _tblDetalleRepuestoManager._tx = transaction;
                _tblAuditoriaManager._conex = conex;
                _tblAuditoriaManager._tx = transaction;

                List<string> ltsmensaje = new List<string>();

                string srtRutaArchivo = _RutaBaseArchivoSalidaConfigurada;

                if (string.IsNullOrEmpty(srtRutaArchivo) || string.IsNullOrWhiteSpace(srtRutaArchivo))
                    ltsmensaje.Add($"* por favor seleccionar la carpeta donde se deja el archivo de salida");
                
                ValidarFormulario(true);

                bool validacionUsuario = true;

                if (_ltsRangos.Count <= 0 || dgvRepuestoIngresados.Rows.Count <= 0)
                    ltsmensaje.Add($"* por favor ingresar los rangos que se van a reponer.");

                if (ltsmensaje.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsmensaje)}");

                if (dtbRangoExistentes.Rows.Count > 0) 
                {
                    validacionUsuario = VerValidarUsuarios(dtbRangoExistentes);

                    if (!validacionUsuario)                   
                        throw new Exception($"* Se cancelo el proceso de validación de repuestos ya existentes, Si desea generar otros repuestos por favor limpiar la tabla.");
                    
                }

                TblEstadoModel tblEstado = _EstadoModel.Where(t => t.Codigo == "01").FirstOrDefault();
                TblEstadoModel tblEstadoDañado = _EstadoModel.Where(t => t.Codigo == "05").FirstOrDefault();

                if (tblEstado == null)
                    throw new Exception($"* No se ha podido obtener el estado para asignar a este repuesto.");

                DateTime FechaCreacion = DateTime.Now;

                TblDescripcionRepuestoModel tblDescripcionRepuestoModel = new TblDescripcionRepuestoModel();
                tblDescripcionRepuestoModel.Id_Impresora = Convert.ToInt32(cbxImpresoras.SelectedValue);
                tblDescripcionRepuestoModel.Id_novedad = Convert.ToInt32(cbxNovedad.SelectedValue);
                tblDescripcionRepuestoModel.Id_tipoImpresion = Convert.ToInt32(cbxTipoImpresion.SelectedValue);
                tblDescripcionRepuestoModel.TipoPapel = txtTipoPapel.Text;
                tblDescripcionRepuestoModel.ImprimirPor = txtImprimirPor.Text;
                tblDescripcionRepuestoModel.Resolucion = txtResolucion.Text;
                tblDescripcionRepuestoModel.rangoMaxRepuesto = Convert.ToInt32(txtRangoMaximoGeneracionRepuestos.Text);
                tblDescripcionRepuestoModel.Usuario = _tblUsuarioModel.Usuario;
                tblDescripcionRepuestoModel.FechaCreacion = FechaCreacion;
                tblDescripcionRepuestoModel.Id = _tblDescripcionRepuestoManager.Guardar(tblDescripcionRepuestoModel);

                TblRepuestoModel tblRepuestoModel = new TblRepuestoModel();
                tblRepuestoModel.Id_DescripcionRepuesto = tblDescripcionRepuestoModel.Id;
                tblRepuestoModel.Id_ConfiguracionRepuesto = Convert.ToInt32(cbxCiclos.SelectedValue);
                tblRepuestoModel.Rango = _ltsRangos.Count;
                tblRepuestoModel.FechaIngreso = FechaCreacion;
                tblRepuestoModel.FechaInactivo = FechaCreacion;
                tblRepuestoModel.Id = _tblRepuestoManager.Guardar(tblRepuestoModel);

                foreach (var item in _ltsDetalleRepuestosExistente)
                {
                    TblAuditoriaModel tblAuditoriaModel = new TblAuditoriaModel();
                    tblAuditoriaModel.Id_Usuario = _tblUsuarioModel.Id;
                    tblAuditoriaModel.FechaHora = FechaCreacion;
                    tblAuditoriaModel.Id_DetalleRepuesto = item.Id;
                    tblAuditoriaModel.Id_Estado = tblEstadoDañado.Id;
                    tblAuditoriaModel.Observacion = $"Repuesto Dañado: Se cambia de estado a dañado por un ingresaso nuevo";
                    tblAuditoriaModel.Id = _tblAuditoriaManager.Guardar(tblAuditoriaModel);
                }

                for (int i = 0; i < _ltsRangos.Count; i++)
                {
                    TblDetalleRepuestoModel tblDetalleRepuestoModel = new TblDetalleRepuestoModel();
                    tblDetalleRepuestoModel.Id_Repuesto = tblRepuestoModel.Id;
                    TblExaminandoModel tblExaminando = _tblExaminandoManager.GetTableTblExaminandoXTblCargueArchivo(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue), _ltsRangos[i]);
                    tblDetalleRepuestoModel.Id_Examinando = tblExaminando.Id;
                    tblDetalleRepuestoModel.Id = _tblDetalleRepuestoManager.Guardar(tblDetalleRepuestoModel);

                    string strUsuarioAutoriza = string.Empty;

                    if (dtbRangoExistentes.Rows.Count > 0) 
                    {
                        DataRow[] dataRow = dtbRangoExistentes.Select($"Repuesto={_ltsRangos[i]} and Seleccionar=1");
                        if (dataRow.Length > 0)
                            strUsuarioAutoriza = $", se ha generado {dataRow[0][1]} veces y fue autorizado por {tblUsuarioLiderAutorizado.NombreApellido} CC: {tblUsuarioLiderAutorizado.Documento} ({tblUsuarioLiderAutorizado.Usuario})";
                    }                    

                    TblAuditoriaModel tblAuditoriaModel = new TblAuditoriaModel();
                    tblAuditoriaModel.Id_Usuario = _tblUsuarioModel.Id;
                    tblAuditoriaModel.FechaHora = FechaCreacion;
                    tblAuditoriaModel.Id_DetalleRepuesto = tblDetalleRepuestoModel.Id;
                    tblAuditoriaModel.Id_Estado = tblEstado.Id;
                    tblAuditoriaModel.Observacion = $"Repuesto Ingresando: Se ingresa el numero de repuesto {_ltsRangos[i]} {strUsuarioAutoriza}";
                    tblAuditoriaModel.Id = _tblAuditoriaManager.Guardar(tblAuditoriaModel);
                }
                List<string> ltsGeneracion = new List<string>();

                if (cbxTipoImpresion.Text.ToLower().Contains("completo"))
                {
                    ltsGeneracion.Add("hojasrespuestas");
                    ltsGeneracion.Add("cuadernillos");
                }
                else                
                    ltsGeneracion.Add(cbxTipoImpresion.Text.ToLower().Trim());

                string strId = $"{tblDescripcionRepuestoModel.Id:000000}";
                string srtRutaArchivoConfigurada = string.Empty;
                string srtRutaArchivoLocal = string.Empty;

                for (int i = 0; i < ltsGeneracion.Count; i++)
                {

                    List<string> ltsArchivoSalida = new List<string>();

                    ltsArchivoSalida.Add($"tipoimpresion:{ltsGeneracion[i].Replace(" ", string.Empty).ToLower()}");
                    ltsArchivoSalida.Add($"tamanopapel:{txtTipoPapel.Text.Trim().ToLower()}");
                    ltsArchivoSalida.Add($"imprimirpor:pq");
                    ltsArchivoSalida.Add($"impresora:{cbxImpresoras.Text.Trim().ToLower()}");
                    ltsArchivoSalida.Add($"dpi:{txtResolucion.Text.Trim()}");
                    ltsArchivoSalida.Add($"formatosalida:{cbxFormatoSalidas.Text.Trim().ToLower()}");
                    ltsArchivoSalida.Add($"apilamiento:");
                    ltsArchivoSalida.Add($"cavida:");
                    ltsArchivoSalida.Add($"consecutivos:");

                    foreach (var item in _ltsRangos)
                        ltsArchivoSalida.Add($"{item}");

                    TblConfiguracionRepuestoModel strConfiguracionRepuestoCiclo = _ltsConfiguracionRepuestoCiclo.Where(t => t.Id == Convert.ToInt32(cbxCiclos.SelectedValue)).FirstOrDefault();

                    string strNombrePruebas = strConfiguracionRepuestoCiclo.NombrePruebaCondorPrint;
                    string strAnoMesDia = $"{DateTime.Now.Year:0000}{DateTime.Now.Month:00}{(DateTime.Now.Day+i):00}";


                    List<string> listaArchivos = new List<string>();
                    try
                    {
                        if (!Directory.Exists(srtRutaArchivo.Replace("@NombrePrueba", string.Empty)))
                            Directory.CreateDirectory(srtRutaArchivo.Replace("@NombrePrueba", string.Empty));
                    }
                    catch (Exception)
                    {
                        srtRutaArchivo = _RutaBaseArchivoSalidalocal;

                        if (!Directory.Exists(srtRutaArchivo.Replace("@NombrePrueba", string.Empty)))
                            Directory.CreateDirectory(srtRutaArchivo.Replace("@NombrePrueba", string.Empty));
                    }

                    srtRutaArchivoConfigurada = Path.Combine(srtRutaArchivo.Replace("@NombrePrueba", strConfiguracionRepuestoCiclo.NombrePruebaCondorPrint), $"REPOS_{strNombrePruebas}-01_{strAnoMesDia}_{strId}_CICLO{strConfiguracionRepuestoCiclo.Ciclo}_PARTE{cbxPartes.Text}.txt");
                    srtRutaArchivoLocal = Path.Combine(_RutaBaseArchivoSalidalocal.Replace("@NombrePrueba", strConfiguracionRepuestoCiclo.NombrePruebaCondorPrint), $"REPOS_{strNombrePruebas}-01_{strAnoMesDia}_{strId}_CICLO{strConfiguracionRepuestoCiclo.Ciclo}_PARTE{cbxPartes.Text}.txt");

                    if (File.Exists(srtRutaArchivoLocal))
                        File.Delete(srtRutaArchivoLocal);

                    listaArchivos.Add(srtRutaArchivoConfigurada);
                    listaArchivos.Add(srtRutaArchivoLocal);

                    foreach (string item in listaArchivos)
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(item)))
                            Directory.CreateDirectory(Path.GetDirectoryName(item));


                        //Helpers.File file1 = new Helpers.File();
                        //file1.GenerarArchivo(Functions.ListHelper.ConvertToDataTable(ltsArchivoSalida), false, item, Environment.NewLine);
                        using (StreamWriter file = new System.IO.StreamWriter(item))
                        {
                            foreach (string line in ltsArchivoSalida)
                                file.WriteLine(line);

                            file.Dispose();
                            file.Close();
                        }
                    }
                }

                transaction.Commit();

                MessageBox.Show($"Repuestos ingresado con exitos{Environment.NewLine}{Environment.NewLine}" +
                    $"Id de repuesto: {strId}{Environment.NewLine}" +
                    $"Cantidad de repuestos: {_ltsRangos.Count}{Environment.NewLine}" +
                    $"Nombre Archivo: {Path.GetFileName(srtRutaArchivoConfigurada)}{Environment.NewLine}" +
                    $"Ruta Archivo: {Path.GetDirectoryName(srtRutaArchivoConfigurada)}", "Guardado exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                Limpiar();
                this.btnGuardarRespuesto.Enabled = true;
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                this.btnGuardarRespuesto.Enabled = true;
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "Error al guardar los repuestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                if (conex != null)
                    conex.Close();  
            }    
        }
        private void Limpiar()
        {
            cbxCLientes.SelectedIndex = -1;
            cbxFormatoSalidas.SelectedIndex = -1;
            cbxTipoImpresion.SelectedIndex = -1;
            cbxMaquina.SelectedIndex = -1;
            cbxSeleccionarPruebas.DataSource = null;
            cbxSeleccionarPruebas.SelectedIndex = -1;
            cbxCiclos.DataSource = null;
            cbxCiclos.SelectedIndex = -1;
            cbxPartes.DataSource = null;
            cbxPartes.SelectedIndex = -1;
            cbxImpresoras.DataSource = null;
            cbxImpresoras.SelectedIndex = -1;
            cbxNovedad.DataSource = null;
            cbxNovedad.SelectedIndex = -1;
            dgvRepuestoIngresados.Rows.Clear();
            _ltsRangos = new List<int>();
            _ltsDetalleRepuestosExistente = new List<TblDetalleRepuestoModel>();
            dtbRangoExistentes.Rows.Clear();
            usrDesde.Text = string.Empty;
            usrHasta.Text = string.Empty;
            usrSeleccionarArchivo1.ArchivoSeleccionado = string.Empty;
            gbxListadoRepuesto.Enabled = false;
            lblCantidadRepuesto.Text = "0";
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (dgvRepuestoIngresados.Rows.Count > 0)
            {
                dgvRepuestoIngresados.Rows.Clear();
                _ltsRangos = new List<int>();
                _ltsDetalleRepuestosExistente = new List<TblDetalleRepuestoModel>();
                lblCantidadRepuesto.Text = "0";
                dtbRangoExistentes.Rows.Clear();
                MessageBox.Show("Se limpio la tabla correctamente.", "Tabla de repuesto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
    }
}
