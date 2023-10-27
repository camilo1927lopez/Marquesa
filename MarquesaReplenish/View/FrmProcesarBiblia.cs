using BDManager;
using MarquesaReplenish.Helpers;
using MarquesaReplenish.MN.Helpers;
using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.PD.Model;
using MarquesaReplenish.PD.Model.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsControlLibrary;

namespace MarquesaReplenish.View
{
    public partial class FrmProcesarBiblia : Form
    {
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();
        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private CargarArchivo CargarArchivo = new CargarArchivo(null, null);
        private string _ListaTiposPruebas = String.Empty;
        private string _NombreColumnaActas = String.Empty;
        private string _NombreColumnaBolsa = String.Empty;
        private string _NombreColumnaContenedor = String.Empty;
        private string _NombreColumnaTulaVacia = String.Empty;
        private string _NombreColumnaCajaVacia = String.Empty;
        private string _PrefijoColmnaBolsa = String.Empty;
        private string _RutaBaseTemp = String.Empty;
        private FrmSelectColumnTablat _frmSelectColumnTablat = null;
        private Dictionary<string, Dictionary<string, string>> ColumnasPrefijoNumeracion = new Dictionary<string, Dictionary<string, string>>();
        private DataTable datatabletSelectColumn = null;
        private List<TamanoContenedor> _ltsTamañoContenedors = new List<TamanoContenedor>();
        private bool _IncluirUltimaColumnaAgrupado;

        public FrmProcesarBiblia(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.pbxSeleccionarColumnaCalculoActa, "Seleccionar columnas para el cálculo de acta.");
            toolTip.SetToolTip(this.pbxSeleccionarColumnaCalculoContenedor, "Seleccionar columnas para el cálculo de contenedor.");
            toolTip.SetToolTip(this.pictureBox1, "Seleccionar para agregar un nuevo tipo producto.");
            toolTip.SetToolTip(this.pictureBox2, "Seleccionar para editar un nuevo tipo producto.");
            usrAyuda.Descripcion = $"Ejemplo para ingresar información de los elementos{Environment.NewLine}{Environment.NewLine}" +
                                   $"CINTA[B006] | " +
                                   $"CARTÓN PRESENTE[P003] | " +
                                   $"CARTÓN AUSENTE[CA004]{Environment.NewLine}{Environment.NewLine}" +
                                   $"Descripción 'CINTA[B006]': Nombre:CINTA, Prefijo:B, InicioConsecutivo: 006";

            CargarConfiguraciones();
        }

        private void CargarConfiguraciones()
        {
            try
            {
                _ListaTiposPruebas = Properties.Settings.Default.ListaTiposPruebas.ToString();
                _NombreColumnaActas = Properties.Settings.Default.NombreColumnaActa.ToString();
                _NombreColumnaBolsa = Properties.Settings.Default.NombreColumnaBolsa.ToString();
                _PrefijoColmnaBolsa = Properties.Settings.Default.PrefijoColmnaBolsa.ToString();
                _NombreColumnaContenedor = Properties.Settings.Default.NombreColumnaContenedor.ToString();
                _NombreColumnaTulaVacia = Properties.Settings.Default.NombreColumnaTulaVacia.ToString();
                _NombreColumnaCajaVacia = Properties.Settings.Default.NombreColumnaCajaVacia.ToString();
                _RutaBaseTemp = Properties.Settings.Default.RutaBaseTemp.ToString();

                ValidarConfiguraciones();

            }
            catch (Exception ex)
            {                
                MessageBox.Show(ex.Message, "Error al obtener configuraciones", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidarConfiguraciones()
        {
            List<string> ltsMensaje = new List<string>();
            try
            {
                if (string.IsNullOrWhiteSpace(_NombreColumnaActas))                
                    ltsMensaje.Add($"* La configuracion de propiedades 'NombreColumnaActa' se cuentra vacía, por favor configurar.");
                if (string.IsNullOrWhiteSpace(_NombreColumnaBolsa))
                    ltsMensaje.Add($"* La configuracion de propiedades 'NombreColumnaBolsa' se cuentra vacía, por favor configurar.");
                if (string.IsNullOrWhiteSpace(_PrefijoColmnaBolsa))
                    ltsMensaje.Add($"* La configuracion de propiedades 'PrefijoColmnaBolsa' se cuentra vacía, por favor configurar.");
                if (string.IsNullOrWhiteSpace(_NombreColumnaContenedor))
                    ltsMensaje.Add($"* La configuracion de propiedades 'NombreColumnaContenedor' se cuentra vacía, por favor configurar.");
                if (string.IsNullOrWhiteSpace(_NombreColumnaTulaVacia))
                    ltsMensaje.Add($"* La configuracion de propiedades 'NombreColumnaTulaVacia' se cuentra vacía, por favor configurar.");
                if (string.IsNullOrWhiteSpace(_NombreColumnaCajaVacia))
                    ltsMensaje.Add($"* La configuracion de propiedades 'NombreColumnaCajaVacia' se cuentra vacía, por favor configurar.");
                if (string.IsNullOrWhiteSpace(_RutaBaseTemp))
                    ltsMensaje.Add($"* La configuracion de propiedades 'Default.RutaBaseTemp' se cuentra vacía, por favor configurar.");
                else                
                    if (!Directory.Exists(_RutaBaseTemp))                    
                        ltsMensaje.Add($"* La ruta configurada '{_RutaBaseTemp}' no existe por favor validar.");


                if (ltsMensaje.Count > 0)
                {
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void usrSeleccionarArchivoReversa_OnSeleccionArchivo(object sender, WinFormsControlLibrary.usrSeleccionarArchivo.SeleccionArchivoEventArgs e)
        {
            try
            {
                string strRutaArchivo = usrSeleccionarArchivoReversa.ArchivoSeleccionado;
                string strCargarArchivo = CargarArchivo.ObtenerPrimeraLineaArchivo(usrSeleccionarArchivoReversa.ArchivoSeleccionado, true);
                if (string.IsNullOrEmpty(strCargarArchivo) || string.IsNullOrWhiteSpace(strCargarArchivo))
                    throw new Exception($"El archivo '{Path.GetFileName(strRutaArchivo)}' contiene lineas vacias");

                gbxConfiguracionActas.Enabled = true;
                gbxConfiguracionContenedor.Enabled = true;
                btnProcesoBiblia.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void usrSeleccionarArchivoReversa_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(usrSeleccionarArchivoReversa.ArchivoSeleccionado) || !string.IsNullOrWhiteSpace(usrSeleccionarArchivoReversa.ArchivoSeleccionado))
                {
                    if (!System.IO.File.Exists(usrSeleccionarArchivoReversa.ArchivoSeleccionado))
                        throw new Exception($"El archivo '{Path.GetFileName(usrSeleccionarArchivoReversa.ArchivoSeleccionado)}' no existe en la ruta '{Path.GetDirectoryName(usrSeleccionarArchivoReversa.ArchivoSeleccionado)}'.");

                    gbxConfiguracionActas.Enabled = true;
                    gbxConfiguracionContenedor.Enabled = true;
                }
                else
                {
                    gbxConfiguracionActas.Enabled = false;
                    gbxConfiguracionContenedor.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                gbxConfiguracionActas.Enabled = false;
                gbxConfiguracionContenedor.Enabled = false;
                MessageBox.Show(ex.Message, "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmProcesarBiblia_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(_ListaTiposPruebas) || string.IsNullOrWhiteSpace(_ListaTiposPruebas))
                {
                    ModuloAgregarEditarTipoPruebas(null);
                }

                CargarTipoPruebas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar el modulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarTipoPruebas()
        {
            string[] arrListaTiposPruebas = null;
            try
            {
                if (cbxTipoPrueba.Items.Count > 0)
                    cbxTipoPrueba.Items.Clear();


                string strListaTiposPruebas = Properties.Settings.Default.ListaTiposPruebas;

                if (!string.IsNullOrEmpty(strListaTiposPruebas))
                {
                    arrListaTiposPruebas = strListaTiposPruebas.Split('|');
                }

                cbxTipoPrueba.Items.Add("---Seleccionar Tipo Pruebas---");

                for (int i = 0; i < arrListaTiposPruebas.Length; i++)
                {
                    cbxTipoPrueba.Items.Add(arrListaTiposPruebas[i]);
                }

                cbxTipoPrueba.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar los tipos de pruebas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModuloAgregarEditarTipoPruebas(string NombrePrueba)
        {
            string[] arrListaTiposPruebas = null;
            try
            {
                string tlo = string.IsNullOrEmpty(NombrePrueba) ? "INGRESAR NUEVO TIPO DE PRUEBAS" : $"EDITAR TIPO DE PRUEBAS '{NombrePrueba}'";
                string msg = "NOMBRE TIPO PRUEBAS";
                string respuesta = InputBox.Prompt(tlo, msg, true, false, string.IsNullOrEmpty(NombrePrueba) ? string.Empty : NombrePrueba);

                if (string.IsNullOrEmpty(respuesta) || string.IsNullOrWhiteSpace(respuesta))
                    throw new Exception("Por favor ingres el nombre del tipo de prueba");
                else
                    if (respuesta.Length <= 3 && respuesta.Length > 50)
                    throw new Exception("Por favor ingresar un cantidad de caracteres mayor a 3 y menor que 50.");

                string strListaTiposPruebas = Properties.Settings.Default.ListaTiposPruebas;

                if (!string.IsNullOrEmpty(strListaTiposPruebas))
                {
                    arrListaTiposPruebas = strListaTiposPruebas.Split('|');
                }

                if (!string.IsNullOrEmpty(NombrePrueba))
                {
                    for (int i = 0; i < arrListaTiposPruebas.Length; i++)
                    {
                        if (arrListaTiposPruebas[i] == NombrePrueba)
                            arrListaTiposPruebas[i] = respuesta;
                    }
                    Properties.Settings.Default.ListaTiposPruebas = string.Join("|", arrListaTiposPruebas);
                    Properties.Settings.Default.Save();
                }
                else
                {
                    int cantidad = arrListaTiposPruebas == null ? 1 : arrListaTiposPruebas.Length + 1;
                    string[] arrListaTiposPruebasNuevo = new string[cantidad];

                    for (int i = 0; i < cantidad; i++)
                    {
                        if (cantidad == (i + 1))
                        {
                            arrListaTiposPruebasNuevo[i] = respuesta;
                            continue;
                        }
                        arrListaTiposPruebasNuevo[i] = arrListaTiposPruebas[i];
                    }

                    Properties.Settings.Default.ListaTiposPruebas = string.Join("|", arrListaTiposPruebasNuevo);
                    Properties.Settings.Default.Save();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                ModuloAgregarEditarTipoPruebas(null);
                CargarTipoPruebas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar un nuevo tipo de prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTipoPrueba.SelectedIndex <= 0)
                    throw new Exception("Por favor seleccione un tipo de prueba para editar");


                ModuloAgregarEditarTipoPruebas(cbxTipoPrueba.Text);
                CargarTipoPruebas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar un nuevo tipo de prueba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pbxSeleccionarColumnaCalculoActa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(usrSeleccionarArchivoReversa.ArchivoSeleccionado) || !string.IsNullOrWhiteSpace(usrSeleccionarArchivoReversa.ArchivoSeleccionado))
                {
                    ModuloSelectColumnTablet(usrSeleccionarArchivoReversa.ArchivoSeleccionado, txtSeleccionarColumnaCalculoActa, '|', null, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar información a la tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModuloSelectColumnTablet(string rutaArchivo, TextBox textBox, char delimitador, string[] columnasNuevas, bool IncluirUltimaColumnaAgrupado)
        {
            try
            {
                datatabletSelectColumn = CargarArchivo.ObtenerLineaArchivo(rutaArchivo, true, 5, delimitador, columnasNuevas);

                if (datatabletSelectColumn == null)
                    throw new Exception("No se pudo cargar el archivo.");
                if (datatabletSelectColumn.Rows.Count < 1)
                    throw new Exception("El archivo esta vacío.");

                _frmSelectColumnTablat = new FrmSelectColumnTablat();
                List<string> ltsColumnasDefault = new List<string>();
                _frmSelectColumnTablat._IncluirUltimaColumnaAgrupado = IncluirUltimaColumnaAgrupado;
                if (!string.IsNullOrEmpty(textBox.Text))
                {
                    Dictionary<string, int> keyValuePairs = ObtenerColumnasYPosicion(textBox.Text);

                    foreach (var item in keyValuePairs)
                    {
                        ltsColumnasDefault.Add(item.Key);
                        _frmSelectColumnTablat._ListaColumnaSelect.Add(new FrmSelectColumnTablat.ColumnaPosicion() { Key = item.Key.Trim(), Value = item.Value });
                    }
                }
                CargarDataGridView(_frmSelectColumnTablat.dgvSelectColumn, datatabletSelectColumn, ltsColumnasDefault.Count < 1 ? null : ltsColumnasDefault);
                _frmSelectColumnTablat.ShowDialog();
                textBox.Text = _frmSelectColumnTablat._ColumnasPosicionSeleccionadas;
                _IncluirUltimaColumnaAgrupado = _frmSelectColumnTablat._IncluirUltimaColumnaAgrupado;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Dictionary<string, int> ObtenerColumnasYPosicion(string text)
        {
            Dictionary<string, int> dicColumnasYPosicion = new Dictionary<string, int>();
            try
            {
                List<string> ltsMensajes = new List<string>();

                if (string.IsNullOrEmpty(text))
                    throw new Exception("Por favor seleccionar las columnas necesarias para el proceso.");

                string[] arrColumnaSeleccionas = text.Split('|');

                if (arrColumnaSeleccionas.Length < 1)
                    throw new Exception("No se ha seleccionado las columnas necesarias para el proceso.");

                for (int i = 0; i < arrColumnaSeleccionas.Length; i++)
                {
                    string[] arrPosicion = arrColumnaSeleccionas[i].Split('[');
                    if (arrPosicion.Length == 2)
                    {
                        bool cierraPosicion = false;
                        string strPosicion = string.Empty;
                        foreach (var item in arrPosicion[1])
                        {
                            if (item == ']')
                            {
                                cierraPosicion = true;
                                break;
                            }
                            strPosicion += item.ToString().Trim();
                        }
                        if (!cierraPosicion)
                        {
                            ltsMensajes.Add($"* Por favor encapsular la posición de la siguiente información '{arrColumnaSeleccionas[i]}' detro de corchetes, Ej: Columna[01]");
                        }
                        else
                        {
                            int posicion = 0;

                            int.TryParse(strPosicion, out posicion);

                            dicColumnasYPosicion.Add(arrPosicion[0].Trim(), posicion);
                        }

                    }
                    else
                    {
                        ltsMensajes.Add($"* La información '{arrColumnaSeleccionas[i]}' no tiene la estructura correcta, por favor enviar Ej: Columna[01]");
                    }
                }

                if (ltsMensajes.Count > 0)
                {
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));
                }
                return dicColumnasYPosicion;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CargarDataGridView(DataGridView DataGridView, DataTable DataTable, List<string> ColumnasDefault = null)
        {
            try
            {
                if (DataGridView == null)
                    throw new Exception("Por favor enviar 'DataGrid' que desees cargar");
                if (DataTable == null)
                    throw new Exception($"Por favor enviar la 'Tabla' que desees cargar en el {DataGridView.Name}");

                if (DataGridView.Columns.Count <= 0)
                {
                    for (int i = 0; i < DataTable.Columns.Count; i++)
                    {
                        string strNombreColumna = DataTable.Columns[i].ColumnName;
                        if (DataGridView.Columns[strNombreColumna] == null)
                        {
                            DataGridView.Columns.Add(strNombreColumna, strNombreColumna);
                            DataGridView.Columns[strNombreColumna].SortMode = DataGridViewColumnSortMode.NotSortable;
                        }
                    }

                    DataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;

                    if (ColumnasDefault != null)
                    {
                        if (ColumnasDefault.Count > 0)
                        {
                            for (int i = 0; i < DataGridView.Columns.Count; i++)
                                if (ColumnasDefault.Contains(DataGridView.Columns[i].Name))
                                    DataGridView.Columns[i].Selected = true;
                        }
                    }

                }


                if (DataGridView.Rows.Count > 0)
                    DataGridView.Rows.Clear();

                for (int i = 0; i < DataTable.Rows.Count; i++)
                    DataGridView.Rows.Add(DataTable.Rows[i].ItemArray);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void pbxSeleccionarColumnaCalculoContenedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(usrSeleccionarArchivoReversa.ArchivoSeleccionado) || !string.IsNullOrWhiteSpace(usrSeleccionarArchivoReversa.ArchivoSeleccionado))
                {
                    ModuloSelectColumnTablet(usrSeleccionarArchivoReversa.ArchivoSeleccionado, txtSeleccionarColumnaCalculoContenedor, '|', new string[] { _NombreColumnaActas }, false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar información a la tabla", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnProcesoBiblia_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime tiempoInicialCompleto = DateTime.Now;
                AgruparXOrdenColumnas agruparXOrdenColumnas = new AgruparXOrdenColumnas();
                CalculoContenedores calculoContenedores = new CalculoContenedores();
                GenerarArchivo generarArchivo = new GenerarArchivo();
                List<string> ltsMensajes = new List<string>();
                List<string[]> NuevasColumnas = new List<string[]>();
                List<string> listFile = new List<string>();
                char delimitador = '|';
                int cantidadXContenedor = 0, contadorContenedor = 0, cantidadXBolsaMaxima = 0;
                ColumnasPrefijoNumeracion = new Dictionary<string, Dictionary<string, string>>();
                List<string> ltsArchivosGenerados = new List<string>();

                mensajeProceso("Inicio Valición.....");
                ValidarConfiguraciones();
                ltsMensajes = ValidarFormulario();

                if (ltsMensajes.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));
                mensajeProceso("Finalicion Valición");

                #region Procesar
                Dictionary<string, Dictionary<string, InfoValue>> dcAgruparXOrdenColumnas = new Dictionary<string, Dictionary<string, InfoValue>>();
                List<Campo> ltsCampos = new List<Campo>();

                mensajeProceso("Inicio Calculo Acta.........");
                DateTime tiempoInicialCalculoActa = DateTime.Now;
                #region CalculoActa

                DateTime tiempoInicial1 = DateTime.Now;
                Dictionary<string, int> dicActaInicial = ObtenerColumnasYPosicion(txtSeleccionarColumnaCalculoActa.Text);
                TimeSpan tiempoFinal1 = DateTime.Now - tiempoInicial1;

                ltsCampos = agruparXOrdenColumnas.ListaCampoAgrupar(dicActaInicial, datatabletSelectColumn, _IncluirUltimaColumnaAgrupado);

                DateTime tiempoInicial2 = DateTime.Now;
                dcAgruparXOrdenColumnas = agruparXOrdenColumnas.MapearArchivo(usrSeleccionarArchivoReversa.ArchivoSeleccionado, ltsCampos, delimitador, "Actas");
                TimeSpan tiempoFinal2 = DateTime.Now - tiempoInicial2;

                DateTime tiempoInicial3 = DateTime.Now;
                int numeracionInicialActa = Convert.ToInt32(usrNumeroInicialActa.Value);
                NuevasColumnas.Add(new string[] { _NombreColumnaActas, _NombreColumnaBolsa });
                foreach (var item in dcAgruparXOrdenColumnas)
                {
                    foreach (var itemInfoActa in item.Value)
                    {
                        if (itemInfoActa.Value.Cantidad <= usrCantidadMaximoXBolsaSeguridad.Value)
                        {
                            for (int i = 0; i < itemInfoActa.Value.Cantidad; i++)
                            {
                                NuevasColumnas.Add(new string[] { $"{numeracionInicialActa}", $"{_PrefijoColmnaBolsa}{numeracionInicialActa}" });
                            }
                            numeracionInicialActa++;
                        }
                        else
                        {
                            string mensaje = InformacionMensaje(dicActaInicial, item.Key, delimitador);
                            ltsMensajes.Add($"El agrupado {mensaje} con cantidad de agrupado {itemInfoActa.Value.Cantidad}, sobre pasa la cantidad maxima por bolsa '{usrCantidadMaximoXBolsaSeguridad.Value}'");
                        }
                    }
                    //numeracionInicialActa++;
                }
                TimeSpan tiempoFinal3 = DateTime.Now - tiempoInicial3;

                if (ltsMensajes.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));

                DateTime tiempoInicial4 = DateTime.Now;
                listFile = generarArchivo.AgregarNuevaColumna(usrSeleccionarArchivoReversa.ArchivoSeleccionado, NuevasColumnas, delimitador);
                TimeSpan tiempoFinal4 = DateTime.Now - tiempoInicial4;

                string strRutaArchivoActa = Path.Combine(_RutaBaseTemp, Path.GetFileNameWithoutExtension(usrSeleccionarArchivoReversa.ArchivoSeleccionado) + "_CalculoActa" + Path.GetExtension(usrSeleccionarArchivoReversa.ArchivoSeleccionado));

                if (!System.IO.File.Exists(strRutaArchivoActa))
                    System.IO.File.Create(strRutaArchivoActa).Close();
                {
                    System.IO.File.Delete(strRutaArchivoActa);
                    System.IO.File.Create(strRutaArchivoActa).Close();
                }

                DateTime tiempoInicial5 = DateTime.Now;
                System.IO.File.AppendAllLines(strRutaArchivoActa, listFile, System.Text.Encoding.Default);
                TimeSpan tiempoFinal5 = DateTime.Now - tiempoInicial5;
                #endregion
                TimeSpan tiempoFinalCalculoActa = DateTime.Now - tiempoInicialCalculoActa;

                if (ltsMensajes.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));
                mensajeProceso("Finalizacion Calculo Acta");

                mensajeProceso("Inicio Calculo Contenedor.........");
                ltsArchivosGenerados.Add(strRutaArchivoActa);

                DateTime tiempoInicialCalculoConte = DateTime.Now;
                #region CalculoContenedor

                DateTime tiempoInicialConte = DateTime.Now;
                Dictionary<string, int> dicContenedorInicial = ObtenerColumnasYPosicion(txtSeleccionarColumnaCalculoContenedor.Text);
                TimeSpan tiempoFinalConte = DateTime.Now - tiempoInicialConte;

                ltsCampos = agruparXOrdenColumnas.ListaCampoAgrupar(dicContenedorInicial, datatabletSelectColumn, _IncluirUltimaColumnaAgrupado);

                DateTime tiempoInicialConte2 = DateTime.Now;
                dcAgruparXOrdenColumnas = agruparXOrdenColumnas.MapearArchivo(strRutaArchivoActa, ltsCampos, delimitador, "Contenedor");
                TimeSpan tiempoFinalConte2 = DateTime.Now - tiempoInicialConte2;

                DateTime tiempoInicialConte3 = DateTime.Now;
                cantidadXContenedor = Convert.ToInt32(usrCantidadMaximoXContenedorG.Value);
                contadorContenedor = Convert.ToInt32(usrNumeroInicialContenedor.Value);
                cantidadXBolsaMaxima = Convert.ToInt32(usrCantidadMaximoXBolsaSeguridad.Value);
                List<Contenedor> ltContenedores = calculoContenedores.Generar(dcAgruparXOrdenColumnas, _ltsTamañoContenedors, contadorContenedor, cantidadXBolsaMaxima);
                TimeSpan tiempoFinalConte3 = DateTime.Now - tiempoInicialConte3;


                //NuevasColumnas.Add(new string[] { _NombreColumnaContenedor });
                DateTime tiempoInicialConte4 = DateTime.Now;
                List<string> ltsNombresValorAgregar = new List<string>();
                ltsNombresValorAgregar.Add(_NombreColumnaContenedor);

                //AgregarNuevas columnas
                foreach (var item in ColumnasPrefijoNumeracion)
                {
                    ltsNombresValorAgregar.Add(item.Key);
                }

                string strValue = string.Empty;
                int cantidadColumnas = NuevasColumnas[0].Length;

                int cantidadPart = ltContenedores.Count / 1;
                int resultado = ltContenedores.Count / cantidadPart;

                int residuo = (ltContenedores.Count % cantidadPart == 0) ? 0:1;

                List<Task> hilos = new List<Task>();
                List<CruceContenedores> ltscruceContenedores = new List<CruceContenedores>();

                for (int h = 0; h < resultado; h++)
                {
                    CruceContenedores cruceContenedores = new CruceContenedores();
                    cruceContenedores.ltContenedores = ltContenedores.Skip(h * cantidadPart).Take(cantidadPart).ToList();
                    cruceContenedores.ltsMensajes = ltsMensajes;
                    cruceContenedores.dicContenedorInicial = dicContenedorInicial;
                    cruceContenedores.cantidadColumnas = cantidadColumnas;
                    cruceContenedores.CantidadMaximoXContenedor = _ltsTamañoContenedors;
                    //cruceContenedores.ColumnasPrefijoNumeracion = CalculoNevosElementos(ColumnasPrefijoNumeracion, (cantidadPart * h) - (h == 0 ? 0:h));
                    cruceContenedores.ColumnasPrefijoNumeracion = DeepClone(ColumnasPrefijoNumeracion);
                    cruceContenedores.delimitador = delimitador;
                    cruceContenedores.ltsNombresValorAgregar = ltsNombresValorAgregar;
                    cruceContenedores._PrefijoColmnaBolsa = _PrefijoColmnaBolsa;
                    cruceContenedores.NuevasColumnas = NuevasColumnas;
                    cruceContenedores.NuevasColumnasSalida = new List<string[]>();
                    NuevasColumnas.ForEach(t => cruceContenedores.NuevasColumnasSalida.Add(t));
                    Task ejecucion = Task.Run(() => cruceContenedores.Generar());
                    hilos.Add(ejecucion);
                    ltscruceContenedores.Add(cruceContenedores);
                }

                if (residuo != 0)
                {
                    CruceContenedores cruceContenedores = new CruceContenedores();
                    cruceContenedores.ltContenedores = ltContenedores.Skip(resultado * cantidadPart).Take(ltContenedores.Count - (resultado * cantidadPart)).ToList();
                    cruceContenedores.ltsMensajes = ltsMensajes;
                    cruceContenedores.dicContenedorInicial = dicContenedorInicial;
                    cruceContenedores.cantidadColumnas = cantidadColumnas;
                    cruceContenedores.CantidadMaximoXContenedor = _ltsTamañoContenedors;
                    //cruceContenedores.ColumnasPrefijoNumeracion = CalculoNevosElementos(ColumnasPrefijoNumeracion, (resultado * cantidadPart));
                    cruceContenedores.ColumnasPrefijoNumeracion = DeepClone(ColumnasPrefijoNumeracion);
                    cruceContenedores.delimitador = delimitador;
                    cruceContenedores.ltsNombresValorAgregar = ltsNombresValorAgregar;
                    cruceContenedores._PrefijoColmnaBolsa = _PrefijoColmnaBolsa;
                    cruceContenedores.NuevasColumnas = NuevasColumnas;
                    cruceContenedores.NuevasColumnasSalida = new List<string[]>();
                    NuevasColumnas.ForEach(t => cruceContenedores.NuevasColumnasSalida.Add(t));
                    Task ejecucion = Task.Run(() => cruceContenedores.Generar());
                    hilos.Add(ejecucion);
                    ltscruceContenedores.Add(cruceContenedores);
                }

                Task.WaitAll(hilos.ToArray());
                //var prueba = await hilos.FirstOrDefault().

                string[] bc = new string[cantidadColumnas + ltsNombresValorAgregar.Count];
                bc = RetornaArryStrig(NuevasColumnas[0], ltsNombresValorAgregar);
                NuevasColumnas[0] = bc;

                NuevasColumnas = OrdenarCalculoElementos(ltscruceContenedores, NuevasColumnas, cantidadColumnas);                                                         

                TimeSpan tiempoFinalConte4 = DateTime.Now - tiempoInicialConte4;


                if (ltsMensajes.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));

                DateTime tiempoInicialConte5 = DateTime.Now;
                listFile = generarArchivo.AgregarNuevaColumna(usrSeleccionarArchivoReversa.ArchivoSeleccionado, NuevasColumnas, delimitador);
                TimeSpan tiempoFinalConte5 = DateTime.Now - tiempoInicialConte5;

                string strRutaArchivoCont = Path.Combine(_RutaBaseTemp, Path.GetFileNameWithoutExtension(usrSeleccionarArchivoReversa.ArchivoSeleccionado) + "_CalculoContenedor" + Path.GetExtension(usrSeleccionarArchivoReversa.ArchivoSeleccionado));

                if (!System.IO.File.Exists(strRutaArchivoCont))
                    System.IO.File.Create(strRutaArchivoCont).Close();
                else
                {
                    System.IO.File.Delete(strRutaArchivoCont);
                    System.IO.File.Create(strRutaArchivoCont).Close();
                }

                DateTime tiempoInicialConte6 = DateTime.Now;
                System.IO.File.AppendAllLines(strRutaArchivoCont, listFile, System.Text.Encoding.Default);
                TimeSpan tiempoFinalConte6 = DateTime.Now - tiempoInicialConte6;

                #endregion
                TimeSpan tiempoFinalCalculoCont = DateTime.Now - tiempoInicialCalculoConte;

                #endregion

                if (ltsMensajes.Count > 0)
                    throw new Exception(string.Join(Environment.NewLine, ltsMensajes));
                mensajeProceso("Finalizacion Calculo Contenedor");

                mensajeProceso("Inicio Generando Archivos.........");
                ltsArchivosGenerados.Add(strRutaArchivoCont);

                this.Cursor = Cursors.Default;

                string strMensaje = string.Empty;
                string strRutaTemp = string.Empty;
                int contador = 0;
                foreach (var item in ltsArchivosGenerados.OrderBy(t => t))
                {
                    if (strRutaTemp != Path.GetDirectoryName(item))
                    {
                        strMensaje += string.IsNullOrEmpty(strRutaTemp) ? strMensaje : $"{Environment.NewLine}{Environment.NewLine}";
                        strMensaje += $"Ruta = {Path.GetDirectoryName(item)} :{Environment.NewLine}";
                        strRutaTemp = Path.GetDirectoryName(item);
                        contador = 1;
                    }
                    strMensaje += $"Archivo #{contador}: {Path.GetFileName(item)}{Environment.NewLine}";
                    contador++;
                }
                mensajeProceso("Finalizacion Generacion Archivos");

                TimeSpan tiempoFinalCompleto = DateTime.Now - tiempoInicialCompleto;
                string strFechaHoraFinal = string.Format("Tiempo de duración final: {0}hr : {1}min: {2}seg", tiempoFinalCompleto.Hours, tiempoFinalCompleto.Minutes, tiempoFinalCompleto.Seconds);

                MessageBox.Show($"{strMensaje}{Environment.NewLine}{Environment.NewLine}" +
                                $"{strFechaHoraFinal}","Proceso terminado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                string strRutaLog = Path.Combine(_RutaBaseTemp, Path.GetFileNameWithoutExtension(usrSeleccionarArchivoReversa.ArchivoSeleccionado) + "_Log" + Path.GetExtension(usrSeleccionarArchivoReversa.ArchivoSeleccionado));
                if (!System.IO.File.Exists(strRutaLog))
                    System.IO.File.Create(strRutaLog).Close();
                else
                {
                    System.IO.File.Delete(strRutaLog);
                    System.IO.File.Create(strRutaLog).Close();
                }
                System.IO.File.AppendAllLines(strRutaLog, new List<string>() { ex.Message } , System.Text.Encoding.Default);
                _ltsTamañoContenedors = new List<TamanoContenedor>();
                MessageBox.Show(ex.Message.Length > 500 ? $"Por favor revisar el archivo de log {Path.GetFileName(strRutaLog)} " +
                                $"que se encuentra en la siguiente ruta {Path.GetDirectoryName(strRutaLog)}" : $"{ex.Message}", "Error al procesar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<string[]> OrdenarCalculoElementos(List<CruceContenedores> ltscruceContenedores, List<string[]> nuevasColumnas, int cantidadColumnas)
        {
            try
            {

                foreach (CruceContenedores item in ltscruceContenedores) 
                {
                    for (int i = 0; i < item.NuevasColumnasSalida.Count; i++)
                    {
                        if (item.NuevasColumnasSalida[i].Length > cantidadColumnas)
                        {
                            for (int x = 0; x < ColumnasPrefijoNumeracion.Count; x++)
                            {
                                int consec = (item.NuevasColumnasSalida[i].Length - ColumnasPrefijoNumeracion.Count) + x;
                                if (item.NuevasColumnasSalida[i][consec] != "0")
                                {
                                    var itemColumnasPrefijoNumeracion = ColumnasPrefijoNumeracion.ElementAt(x);

                                    string strKey = itemColumnasPrefijoNumeracion.Value.FirstOrDefault().Key;
                                    string strValor = itemColumnasPrefijoNumeracion.Value.FirstOrDefault().Value;

                                    int valor = Convert.ToInt32(strValor) + (i == 1 ? 0 : 1);
                                    string inf = valor.ToString().PadLeft(strValor.Length, '0'); ;

                                    ColumnasPrefijoNumeracion[itemColumnasPrefijoNumeracion.Key][strKey] = inf;
                                    item.NuevasColumnasSalida[i][consec] = $"{strKey}{inf}";
                                }
                                nuevasColumnas[i] = item.NuevasColumnasSalida[i];
                            }
                        }
                    }
                }                    

                return nuevasColumnas;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private Dictionary<string, Dictionary<string, string>> CalculoNevosElementos(Dictionary<string, Dictionary<string, string>> columnasPrefijoNumeracion, int inicio)
        {
            try
            {
                foreach (var item in ColumnasPrefijoNumeracion)
                {
                    string strKey = item.Value.FirstOrDefault().Key;
                    string strValor = item.Value.FirstOrDefault().Value;
                    int valor = inicio + 1;
                    ColumnasPrefijoNumeracion[item.Key][strKey] = valor.ToString().PadLeft(strValor.Length, '0');
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ColumnasPrefijoNumeracion;
        }

        private void mensajeProceso(string mensajeProceso)
        {
            try
            {
                txtProcesoMensaje.Text = mensajeProceso + Environment.NewLine + txtProcesoMensaje.Text;
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string InformacionMensaje(Dictionary<string, int> dicActaInicial, string key, char delimitador)
        {
            string mensaje = string.Empty;
            try
            {
                for (int i = 0; i < dicActaInicial.Count; i++)
                {
                    string[] arrKey = key.Split(delimitador);
                    if (i < arrKey.Length)                    
                        mensaje += $"{dicActaInicial.ElementAt(i).Key}: {arrKey[i]} ";                    
                                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return mensaje;
        }

        private string[] RetornaArryStrig(string[] arry, List<string> nuevoValor)
        {
            string[] bc = new string[arry.Length + nuevoValor.Count];
            try
            {
                int posicionNuevoValor = 0;
                for (int x = 0; x < bc.Length; x++)
                {
                    if (x >= arry.Length)
                    {
                        if (posicionNuevoValor < nuevoValor.Count)
                        {
                            bc[x] = nuevoValor[posicionNuevoValor];
                            posicionNuevoValor++;
                            continue;
                        }
                    }
                    bc[x] = arry[x];
                }
            }
            catch (Exception)
            {

                throw;
            }

            return bc;
        }

        private List<string> ValidarFormulario()
        {
            List<string> ltsMensajes = new List<string>();
            try
            {
                Dictionary<string, string> keyValues = new Dictionary<string, string>();
                string strArchivo = usrSeleccionarArchivoReversa.ArchivoSeleccionado;
                if (string.IsNullOrEmpty(strArchivo))
                {
                    ltsMensajes.Add($"* Por favor seleccionar biblia");
                    return ltsMensajes;
                }

                if (cbxTipoPrueba.SelectedIndex < 1)
                    ltsMensajes.Add($"* Por favor seleccionar tipo de prueba");
                if (usrNumeroInicialActa.Value < 1)
                    ltsMensajes.Add($"* Por favor ingresar un numero de acta inicial");
                if (string.IsNullOrEmpty(txtSeleccionarColumnaCalculoActa.Text))
                    ltsMensajes.Add($"* Por favor seleccionar las columnas para el calculo de actas.");
                if (usrNumeroInicialContenedor.Value < 1)
                    ltsMensajes.Add($"* Por favor ingresar un numero inicial del contenedor.");

                if (usrCantidadMaximoXContenedorG.Value < 1)
                    ltsMensajes.Add($"* Por favor ingresar un numero máximo por contenedor Grande.");
                else                
                    _ltsTamañoContenedors.Add(new TamanoContenedor { Tamano = (int)usrCantidadMaximoXContenedorG.Value, Nombre = "Grande",  Prefijo = "G",Estado = true });
                
                if (usrCantidadMaximoXContenedorM.Value < 1)
                    ltsMensajes.Add($"* Por favor ingresar un numero máximo por contenedor Mediano.");
                else
                    _ltsTamañoContenedors.Add(new TamanoContenedor { Tamano = (int)usrCantidadMaximoXContenedorM.Value, Nombre = "Mediano", Prefijo = "M" ,Estado = true });

                if (usrCantidadMaximoXBolsaSeguridad.Value < 1)
                    ltsMensajes.Add($"* Por favor ingresar un numero máximo por bolsa de seguridad.");
                if (usrCantidadMaximoXContenedorG.Value > 0 && usrCantidadMaximoXBolsaSeguridad.Value > 0)                
                    if (usrCantidadMaximoXBolsaSeguridad.Value > usrCantidadMaximoXContenedorG.Value)                    
                        ltsMensajes.Add($"* la cantidad maxima por bolsa no debe ser mayor a la cantidad maxima por contenedor..");                  
                if (string.IsNullOrEmpty(txtSeleccionarColumnaCalculoContenedor.Text))
                    ltsMensajes.Add($"* Por favor seleccionar las columnas para el calculo de contenedores.");
                if (string.IsNullOrEmpty(txtNumeroInicialCajaVacia.Text))
                    ltsMensajes.Add($"* Por favor ingresar el numero inicial de la caja vacía");
                else
                {
                    keyValues = new Dictionary<string, string>();
                    ltsMensajes.AddRange(validarPrefijoNumeracion(txtNumeroInicialCajaVacia.Text, out keyValues));
                    if (keyValues != null)
                    {
                        ColumnasPrefijoNumeracion.Add(_NombreColumnaCajaVacia, keyValues);
                    }
                }
                if (string.IsNullOrEmpty(txtNumeroInicialTulaVacia.Text))
                    ltsMensajes.Add($"* Por favor ingresar el numero inicial de la tula vacía");
                else
                {
                    keyValues = new Dictionary<string, string>();
                    ltsMensajes.AddRange(validarPrefijoNumeracion(txtNumeroInicialTulaVacia.Text, out keyValues));
                    if (keyValues != null)
                    {
                        ColumnasPrefijoNumeracion.Add(_NombreColumnaTulaVacia, keyValues);
                    }
                }

                if (string.IsNullOrEmpty(txtElementos.Text))
                    ltsMensajes.Add($"* Por favor ingresar por lo menos un elemento");
                else
                {
                    ltsMensajes.AddRange(ValidarElementos(txtElementos.Text));
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ltsMensajes;
        }

        private IEnumerable<string> ValidarElementos(string dato)
        {
            List<string> ltsMensajes = new List<string>();
            try
            {
                ltsMensajes.AddRange(ObtenerColumnasPrefijoNumeracion(dato));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ltsMensajes;
        }

        private List<string> ObtenerColumnasPrefijoNumeracion(string text)
        {
            Dictionary<string, Dictionary<string, string>> dicColumnasPrefijoNumeracion = new Dictionary<string, Dictionary<string, string>>();
            try
            {
                List<string> ltsMensajes = new List<string>();

                if (string.IsNullOrEmpty(text))
                    throw new Exception("Por favor ingrese los elementos necesarios para el proceso.");

                string[] arrColumnaSeleccionas = text.Split('|');

                if (arrColumnaSeleccionas.Length < 1)
                    throw new Exception("No se ha ingresado los elementos necesarias para el proceso.");

                for (int i = 0; i < arrColumnaSeleccionas.Length; i++)
                {
                    string[] arrPosicion = arrColumnaSeleccionas[i].Split('[');
                    if (arrPosicion.Length == 2)
                    {
                        bool cierraPrefijoNumeracion = false;
                        string strPrefijoNumeracion = string.Empty;
                        foreach (var item in arrPosicion[1])
                        {
                            if (item == ']')
                            {
                                cierraPrefijoNumeracion = true;
                                break;
                            }
                            strPrefijoNumeracion += item;
                        }

                        if (!cierraPrefijoNumeracion)
                        {
                            ltsMensajes.Add($"* Por favor encapsular el prefijo y la numeracion de la siguiente información '{arrColumnaSeleccionas[i]}' detro de corchetes, Ej: Nombre[P006]");
                        }
                        else
                        {
                            Dictionary<string, string> keyValues = new Dictionary<string, string>();
                            ltsMensajes.AddRange(validarPrefijoNumeracion(strPrefijoNumeracion, out keyValues));
                            dicColumnasPrefijoNumeracion.Add(arrPosicion[0], keyValues);
                        }
                    }
                    else
                    {
                        ltsMensajes.Add($"* La información '{arrColumnaSeleccionas[i]}' no tiene la estructura correcta, por favor enviar Ej: Columna[01]");
                    }
                }

                if (ltsMensajes.Count < 1)
                {
                    foreach (var item in dicColumnasPrefijoNumeracion)
                        ColumnasPrefijoNumeracion.Add(item.Key, item.Value);
                }
                return ltsMensajes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private IEnumerable<string> validarPrefijoNumeracion(string dato, out Dictionary<string, string> PrefijoNumeracion)
        {
            Dictionary<string, string> dcPrefijoNumeracion = new Dictionary<string, string>();
            List<string> ltsMensajes = new List<string>();
            try
            {
                int numeracion = 0;
                string prefijo = string.Empty;
                string strNumeracion = string.Empty;

                foreach (var item in dato)
                    if (!char.IsDigit(item))
                        prefijo += item;
                    else
                        strNumeracion += item;

                numeracion = Convert.ToInt32(strNumeracion);
                if (string.IsNullOrEmpty(prefijo))
                    ltsMensajes.Add($"* Por favor ingresar un prefijo al numeracíon '{dato}'.");
                if (string.IsNullOrEmpty(strNumeracion))
                    ltsMensajes.Add($"* Por favor ingresar una numeración '{dato}'.");
                else if (numeracion < 1)
                    ltsMensajes.Add($"* Por favor ingresar una numeración mayor a cero '{dato}'.");

                if (ltsMensajes.Count < 1)
                {
                    dcPrefijoNumeracion.Add(prefijo.Replace("[", string.Empty).Replace("]", string.Empty), strNumeracion);
                    PrefijoNumeracion = dcPrefijoNumeracion;
                }
                else
                {
                    PrefijoNumeracion = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return ltsMensajes;
        }

        private void gbxConfiguracionContenedor_Enter(object sender, EventArgs e)
        {

        }

        public T DeepClone<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);
                ms.Position = 0;

                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
