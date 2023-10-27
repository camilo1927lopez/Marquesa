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
    public partial class FrmIntercaleRepuesto : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();
        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoCiclo = new List<TblConfiguracionRepuestoModel>();
        private List<TblEstadoModel> _ltsEstadoModel = new List<TblEstadoModel>();
        private List<TblExaminandoModel> _ltsExaminandoModel = new List<TblExaminandoModel>();
        private List<TblDetalleRepuestoModel> _ltsDetalleRepuestoModels = new List<TblDetalleRepuestoModel>();
        private List<TblEstadoModel> _ltsEstadosExaminando = new List<TblEstadoModel>();
        private List<TblAuditoriaModel> _ltsAuditoriaModels = new List<TblAuditoriaModel>();
        private List<TblRepuestoModel> _ltsRepuestoModel = new List<TblRepuestoModel>();
        private List<TblConfiguracionRepuestoModel> _ltsConfiguracionRepuestoModel = new List<TblConfiguracionRepuestoModel>();
        private List<TblParteCicloModel> _ltsParteCicloModel = new List<TblParteCicloModel>();
        private TblEstadoManager _tblEstadoManager = new TblEstadoManager();
        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();
        private TblExaminandoManager _tblExaminandoManager = new TblExaminandoManager();
        private TblDetalleRepuestoManager _tblDetalleRepuestoManager = new TblDetalleRepuestoManager();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();        
        private TblRepuestoManager _tblRepuestoManager = new TblRepuestoManager();
        private TblParteCicloManager _tblParteCicloManager = new TblParteCicloManager();

        public FrmIntercaleRepuesto(TblUsuarioModel UsuarioModel)
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

        private void lblCodigoBarrasCuadernillo_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigoActa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                try
                {
                    ValidarFormulario();

                    if (dgvIntercaleRepuesto.Rows.Count > 0)                    
                        dgvIntercaleRepuesto.Rows.Clear();
                    
                    CargarDataGrid(txtCodigoActa.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error al obtener los datos de codigo de acta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                if (string.IsNullOrEmpty(txtCodigoActa.Text) || string.IsNullOrWhiteSpace(txtCodigoActa.Text))
                    ltsMensaje.Add($"* Por favor ingresar el código de acta.");

                if (ltsMensaje.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarDataGrid(string CodigoActa)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                _ltsExaminandoModel = new List<TblExaminandoModel>();
                _ltsDetalleRepuestoModels = new List<TblDetalleRepuestoModel>();
                _ltsEstadosExaminando = new List<TblEstadoModel>();
                _ltsAuditoriaModels = new List<TblAuditoriaModel>();
                _ltsRepuestoModel = new List<TblRepuestoModel>();
                Dictionary<int,TblExaminandoModel> dicExaminandoModelsIntercale = new Dictionary<int, TblExaminandoModel>();
                Dictionary<TblExaminandoModel, List<TblDetalleRepuestoModel>> dicExaminandoXDetalleRepuesto = new Dictionary<TblExaminandoModel, List<TblDetalleRepuestoModel>>();

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();

                _tblExaminandoManager._conex = conex;
                _tblDetalleRepuestoManager._conex = conex;
                _tblAuditoriaManager._conex = conex;
                _tblRepuestoManager._conex = conex;
                _tblConfiguracionRepuestoManager._conex = conex;
                _tblParteCicloManager._conex = conex;

                _ltsExaminandoModel = _tblExaminandoManager.GetTableTblExaminandoXCodigoActa(Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue), CodigoActa);

                if (_ltsExaminandoModel.Count < 1)
                    throw new Exception($"El código de acta {CodigoActa} no existe.");

                foreach (TblExaminandoModel itemExaminando in _ltsExaminandoModel.OrderBy(t => Convert.ToInt32(t.IdConsecutivo)))                 
                    _ltsDetalleRepuestoModels.AddRange(_tblDetalleRepuestoManager.GetTableTblDetalleRepuestoXTblExaminando(itemExaminando.Id));
                                                        
                if (_ltsDetalleRepuestoModels.Count <= 0)
                    throw new Exception($"El código de acta {CodigoActa} no se le ha ingresado repuesto.");

                foreach (var item in _ltsDetalleRepuestoModels)
                {
                    TblRepuestoModel tblRepuesto = _tblRepuestoManager.GetData(item.Id_Repuesto);
                    TblConfiguracionRepuestoModel tblConfiguracion = _tblConfiguracionRepuestoManager.GetData(tblRepuesto.Id_ConfiguracionRepuesto);

                    if (tblConfiguracion.Ciclo == cbxCiclos.Text)
                    {
                        _ltsRepuestoModel.Add(tblRepuesto);
                        _ltsConfiguracionRepuestoModel.Add(tblConfiguracion);
                        foreach (TblParteCicloModel itemParteCiclo in _tblParteCicloManager.GetTableTblParteCicloXTblConfiguracionRepuesto(tblConfiguracion.Id))
                            _ltsParteCicloModel.Add(itemParteCiclo);

                        TblExaminandoModel tblExaminando = _ltsExaminandoModel.Find(t => t.Id == item.Id_Examinando);

                        if (dicExaminandoXDetalleRepuesto.ContainsKey(tblExaminando))
                            dicExaminandoXDetalleRepuesto[tblExaminando].Add(item);
                        else
                            dicExaminandoXDetalleRepuesto.Add(tblExaminando, new List<TblDetalleRepuestoModel> { item });
                    }                    
                }


                foreach (var itemExaminandoXDetalleRepuesto in dicExaminandoXDetalleRepuesto)
                {


                    TblDetalleRepuestoModel tblDetalleRepuesto = itemExaminandoXDetalleRepuesto.Value.OrderBy(t => t.Id).Last();

                    List<TblAuditoriaModel> ltsAuditorias = _tblAuditoriaManager.GetTableTblAuditoriaXTblDetalleRepuesto(tblDetalleRepuesto.Id);
                    foreach (TblAuditoriaModel itemAuditoria in ltsAuditorias)
                    {
                        TblEstadoModel tblEstadoAu = _ltsEstadoModel.Find(t => t.Id == itemAuditoria.Id_Estado);
                        if (tblEstadoAu.Codigo == "02") 
                        {
                            if (!dicExaminandoModelsIntercale.ContainsKey(tblDetalleRepuesto.Id))
                                dicExaminandoModelsIntercale.Add(tblDetalleRepuesto.Id, itemExaminandoXDetalleRepuesto.Key);
                        }
                        else
                        {
                            if (dicExaminandoModelsIntercale.ContainsKey(tblDetalleRepuesto.Id))
                                dicExaminandoModelsIntercale.Remove(tblDetalleRepuesto.Id);
                        }
                        

                        _ltsAuditoriaModels.Add(itemAuditoria);
                    }
                }

                if (dgvIntercaleRepuesto.Rows.Count > 0)                
                    dgvIntercaleRepuesto.Rows.Clear();
                

                int consecutivoIntercale = 0;
                string IdDetalleRepuesto = string.Empty;
                foreach (var itemExaminando in dicExaminandoModelsIntercale.OrderBy(t => Convert.ToInt32(t.Value.IdConsecutivo)))
                {
                    if (consecutivoIntercale == Convert.ToInt32(itemExaminando.Value.IdConsecutivo))
                    {
                        IdDetalleRepuesto = string.IsNullOrEmpty(IdDetalleRepuesto) ? itemExaminando.Key.ToString() : IdDetalleRepuesto;
                        consecutivoIntercale++;
                    }
                    else 
                    {
                        consecutivoIntercale = 0;
                        IdDetalleRepuesto = string.Empty;
                    }                    
                                                                                   

                    if (consecutivoIntercale == 0)
                        consecutivoIntercale = Convert.ToInt32(itemExaminando.Value.IdConsecutivo) + 1;  


                    dgvIntercaleRepuesto.Rows.Add(
                       itemExaminando.Key,
                       itemExaminando.Value.IdConsecutivo,
                       itemExaminando.Value.CodigoCuadernillo,
                       itemExaminando.Value.CodigoHojaRespuesta,
                       itemExaminando.Value.CodigoSitio,
                       itemExaminando.Value.NombreSitio,
                       itemExaminando.Value.CodigoSalon,
                       itemExaminando.Value.Bloque,
                       "Repuesto Auditado",
                       IdDetalleRepuesto
                       );
                }

                dgvIntercaleRepuesto.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;

                if (dicExaminandoModelsIntercale.Count <= 0)                
                    throw new Exception($"El código de acta {CodigoActa} no existen repuestos auditado para intercalar.");

                Application.DoEvents();

                cbxCLientes.Enabled = false;
                cbxSeleccionarPruebas.Enabled = false;
                cbxCiclos.Enabled = false;
                txtCodigoActa.Enabled = false;
                txtCodigoBarrasHojaRespuesta.Enabled = true;
                this.Cursor = Cursors.Default;
                txtCodigoBarrasHojaRespuesta.Focus();
            }
            catch (Exception ex)
            {
                txtCodigoActa.Clear();
                txtCodigoActa.Focus();
                cbxCLientes.Enabled = true;
                cbxSeleccionarPruebas.Enabled = true;
                cbxCiclos.Enabled = true;
                txtCodigoActa.Enabled = true;
                txtCodigoBarrasHojaRespuesta.Enabled = false;
                this.Cursor = Cursors.Default;
                throw new Exception(ex.Message);
            }
        }

        private void txtCodigoBarrasHojaRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                try
                {
                    if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasHojaRespuesta.Text)) 
                    {
                        txtCodigoBarrasHojaRespuesta.Clear();
                        txtCodigoBarrasHojaRespuesta.Focus();
                        throw new Exception("Por favor ingrese o leea el codigo de barra de la hoja de respuesta.");
                    }                        

                    List<TblExaminandoModel> _ltsExaminandoModelOrdenar = _ltsExaminandoModel.OrderBy(t => Convert.ToInt32(t.IdConsecutivo)).ToList();
                    FrmValideIntercale frmValideIntercale = new FrmValideIntercale(this._tblUsuarioModel);
                    TblExaminandoModel tblExaminandoModel = new TblExaminandoModel();
                    List<TblExaminandoModel> ltsExaminandoModels = new List<TblExaminandoModel>();
                    Dictionary<string,TblExaminandoModel> dicExaminandoPendientes = new Dictionary<string, TblExaminandoModel> ();

                    string IdDetalleRepuesto = string.Empty;
                    string ConsecutivoIntercale = string.Empty;
                    bool estado = false;
                    for (int i = 0; i < dgvIntercaleRepuesto.Rows.Count; i++)
                    {
                        int idConsecutivoInicial = Convert.ToInt32(dgvIntercaleRepuesto.Rows[i].Cells["IdConsecutivo"].Value);
                        string CodigoCuadernilllo = dgvIntercaleRepuesto.Rows[i].Cells["CodigoCuadernillo"].Value.ToString();
                        string CodigoHojaRespuesta = dgvIntercaleRepuesto.Rows[i].Cells["CodigoHojaRespuesta"].Value.ToString();
                        IdDetalleRepuesto = dgvIntercaleRepuesto.Rows[i].Cells["IdDetalleRepuesto"].Value.ToString();
                        ConsecutivoIntercale = dgvIntercaleRepuesto.Rows[i].Cells["ConsecutivoIntercale"].Value.ToString();

                        if (txtCodigoBarrasHojaRespuesta.Text == CodigoHojaRespuesta )
                        {
                            tblExaminandoModel = _ltsExaminandoModelOrdenar.Where(t => t.IdConsecutivo == $"{idConsecutivoInicial}" && t.CodigoCuadernillo == CodigoCuadernilllo && t.CodigoHojaRespuesta == CodigoHojaRespuesta).FirstOrDefault();
                            ltsExaminandoModels.Add(tblExaminandoModel);

                            if (dicExaminandoPendientes.ContainsKey(IdDetalleRepuesto))
                                dicExaminandoPendientes[IdDetalleRepuesto] = tblExaminandoModel;
                            else
                                dicExaminandoPendientes.Add(IdDetalleRepuesto, tblExaminandoModel);                                                        
                            
                            int posicion = _ltsExaminandoModelOrdenar.IndexOf(tblExaminandoModel);

                            for (int iposicio = 1; iposicio <= 2; iposicio++)
                            {
                                int posicionAtras = (posicion - iposicio);
                                int posicionAdelante = (posicion + iposicio);

                                if (posicionAtras >= 0)
                                    ltsExaminandoModels.Add(_ltsExaminandoModelOrdenar[posicionAtras]);

                                if (_ltsExaminandoModelOrdenar.Count > posicionAdelante)
                                    ltsExaminandoModels.Add(_ltsExaminandoModelOrdenar[posicionAdelante]);
                            }
                            estado = true;
                            continue;
                        }

                        if (string.IsNullOrEmpty(ConsecutivoIntercale) && estado)                        
                            break;
                        else if (!string.IsNullOrEmpty(ConsecutivoIntercale) && estado)
                        {

                            TblExaminandoModel tblExaminandoIntercale = _ltsExaminandoModel.Where(t => t.IdConsecutivo == $"{idConsecutivoInicial}" && t.CodigoCuadernillo == CodigoCuadernilllo && t.CodigoHojaRespuesta == CodigoHojaRespuesta).FirstOrDefault();

                            if (dicExaminandoPendientes.ContainsKey(IdDetalleRepuesto))
                                dicExaminandoPendientes[IdDetalleRepuesto] = tblExaminandoIntercale;
                            else
                                dicExaminandoPendientes.Add(IdDetalleRepuesto, tblExaminandoIntercale);

                            int adelante1 = idConsecutivoInicial + 1;   
                            int adelante2 = adelante1 + 1;


                            TblExaminandoModel tblExaminando1 = _ltsExaminandoModel.Find(t => t.IdConsecutivo == adelante1.ToString());
                            TblExaminandoModel tblExaminando2 = _ltsExaminandoModel.Find(t => t.IdConsecutivo == adelante2.ToString());

                            if (!ltsExaminandoModels.Contains(tblExaminando1) && tblExaminando1 != null)                             
                                ltsExaminandoModels.Add(tblExaminando1);
                         
                            
                            if (!ltsExaminandoModels.Contains(tblExaminando2) && tblExaminando2 != null)                             
                                ltsExaminandoModels.Add(tblExaminando2);
                            
                        }
                        
                    }

                    if (ltsExaminandoModels.Count <= 0) 
                    {
                        txtCodigoBarrasHojaRespuesta.Clear();
                        txtCodigoBarrasHojaRespuesta.Focus();
                        throw new Exception($"La hoja de repuesta '{txtCodigoBarrasHojaRespuesta.Text}' no esta en la tabla para realizar el intercale.");
                    }                        

                    foreach (TblExaminandoModel item in ltsExaminandoModels.OrderBy(t => Convert.ToInt32(t.IdConsecutivo)))
                    {

                        string IdDetalleRep = dicExaminandoPendientes.Where(t => t.Value == item).FirstOrDefault().Key;

                        frmValideIntercale.dgvValideIntercale.Rows.Add(
                            !string.IsNullOrEmpty(IdDetalleRep) ? IdDetalleRep : string.Empty,
                            item.CodigoCuadernillo,
                            item.CodigoHojaRespuesta,
                            item.CodigoSitio,
                            item.NombreSitio,
                            item.CodigoSalon,
                            item.Bloque,
                            item.NombreSalon,
                            item.Sesion,
                            item.IdConsecutivo,
                            dicExaminandoPendientes.Values.Contains(item) ? "Pendiente": string.Empty
                            );
                    }

                    //frmValideIntercale.dgvValideIntercale.AllowUserToOrderColumns = true;
                    frmValideIntercale._ltsEstadoModel = this._ltsEstadoModel;
                    frmValideIntercale.dgvValideIntercale.AutoGenerateColumns = true;
                    frmValideIntercale.dgvValideIntercale.AutoResizeColumns();
                    frmValideIntercale.dgvValideIntercale.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
                    frmValideIntercale.txtCodigoBarrasHojaRespuesta.Focus();
                    frmValideIntercale.ShowDialog();

                    if (frmValideIntercale.Correcto)
                    {

                        CargarDataGrid(txtCodigoActa.Text);

                        if (dgvIntercaleRepuesto.Rows.Count > 0)
                        {
                            if (MessageBox.Show("Deseas seguir con el intercale ?", "Intercale de Repuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            {    
                                cbxCLientes.Enabled = true;
                                cbxSeleccionarPruebas.Enabled = true;
                                cbxCiclos.Enabled = true;
                                txtCodigoActa.Enabled = true;
                                txtCodigoActa.Clear();
                                txtCodigoActa.Focus();
                                txtCodigoBarrasHojaRespuesta.Clear();
                                dgvIntercaleRepuesto.Rows.Clear();
                                return;
                            }
                            else
                            {
                                txtCodigoBarrasHojaRespuesta.Clear();
                                txtCodigoBarrasHojaRespuesta.Focus();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error al iniciar la intercale", MessageBoxButtons.OK, MessageBoxIcon.Error);    
                }
            }
        }
    }
}
