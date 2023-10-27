using BDManager;
using MarquesaReplenish.MN.Helpers;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarquesaReplenish.View
{
    public partial class FrmCreacionCiclo : Form
    {
        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblConfiguracionRepuestoManager _tblConfiguracionRepuestoManager = new TblConfiguracionRepuestoManager();
        private TblParteCicloManager _tblParteCicloManager = new TblParteCicloManager(); 
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();
        private List<TblClienteModel> _ltsClientes = new List<TblClienteModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivo = new List<TblCargueArchivoModel>();
        private List<TblCargueArchivoModel> _ltsCargueArchivoGlobal = new List<TblCargueArchivoModel>();
        public FrmCreacionCiclo(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;            
            InitializeComponent();
            CargarComboClient();
            //_ltsCargueArchivoGlobal = _tblCargueArchivoManager.GetFullDataXExaminando();
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

        private void btnGuardarCiclo_Click(object sender, EventArgs e)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;
            TblParteCicloModel tblParteCicloModel = new TblParteCicloModel();
            List<TblParteCicloModel> tblParteCiclo = new List<TblParteCicloModel>();
            TblConfiguracionRepuestoModel tblConfiguracionRepuestoModel = new TblConfiguracionRepuestoModel();

            try
            {
                DateTime tiempoInicial = DateTime.Now;
                TimeSpan tiempoFinal = new TimeSpan();

                this.Cursor = Cursors.WaitCursor;
                this.btnGuardarCiclo.Enabled = false;
                List<string> ltsMensaje = new List<string>();

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblConfiguracionRepuestoManager._conex = conex;
                _tblConfiguracionRepuestoManager._tx = transaction;
                _tblParteCicloManager._conex = conex;
                _tblParteCicloManager._tx = transaction;

                ValidarFormulario();


                tblConfiguracionRepuestoModel.id_CargueArchivo = Convert.ToInt32(cbxSeleccionarPruebas.SelectedValue);
                tblConfiguracionRepuestoModel.Ciclo = usrCiclo.Value.ToString();

                if (_tblConfiguracionRepuestoManager.GetTableTblConfiguracionRepuestoXTblCargueArchivo(tblConfiguracionRepuestoModel.id_CargueArchivo, tblConfiguracionRepuestoModel.Ciclo) != null)
                    throw new Exception($"El ciclo '{tblConfiguracionRepuestoModel.Ciclo}' ya existe para la prueba '{cbxSeleccionarPruebas.Text}'.");

                tblConfiguracionRepuestoModel.NombrePruebaCondorPrint = txtNombreCondor.Text;
                tblConfiguracionRepuestoModel.UsuarioCreacion = _tblUsuarioModel.Usuario;
                tblConfiguracionRepuestoModel.FechaCreacion = DateTime.Now;
                tblConfiguracionRepuestoModel.Id = _tblConfiguracionRepuestoManager.Guardar(tblConfiguracionRepuestoModel);                

                tblParteCiclo = CargarParteCiclo(usrSeleccionarCargueCiclo.ArchivoSeleccionado, true, "\t", tblConfiguracionRepuestoModel);

                MN.Helpers.Ciclos ciclos = new MN.Helpers.Ciclos();

                tblParteCiclo = ciclos.Validar(tblParteCiclo);

                foreach (TblParteCicloModel item in tblParteCiclo)
                {
                    _tblParteCicloManager.Guardar(item);
                }

                transaction.Commit();

                tiempoFinal = DateTime.Now - tiempoInicial;

                string strFechaHoraFinal = string.Format("Tiempo de configuración de repuesto: {0}hr : {1}min: {2}seg", tiempoFinal.Hours, tiempoFinal.Minutes, tiempoFinal.Seconds);

                MessageBox.Show($"Cliente: {cbxCLientes.Text} {Environment.NewLine}" +
                                $"Pruebas: {cbxSeleccionarPruebas.Text} {Environment.NewLine}" +
                                $"Ciclo: {usrCiclo.Value} {Environment.NewLine}" +
                                $"Nombre Condor: {txtNombreCondor.Text} {Environment.NewLine}" +
                                $"Total de Partes Cargadas: {tblParteCiclo.Count} {Environment.NewLine}{Environment.NewLine}" +
                                $"{strFechaHoraFinal}", "Configuración de repuesto exitoso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                this.Cursor = Cursors.Default;
                this.btnGuardarCiclo.Enabled = true;

                limpiarFormulario();
            }
            catch (Exception ex)
            {
                if (transaction != null)
                    transaction.Rollback();

                this.Cursor = Cursors.Default;
                this.btnGuardarCiclo.Enabled = true;

                MessageBox.Show(ex.Message,"Error al guardar los ciclos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conex != null)
                {
                    conex.Close();
                }
            }
        }

        private void limpiarFormulario()
        {
            try
            {
                cbxCLientes.SelectedIndex = -1;
                cbxSeleccionarPruebas.DataSource = null;
                cbxSeleccionarPruebas.Items.Clear();
                usrCiclo.Value = 0;
                usrSeleccionarCargueCiclo.ArchivoSeleccionado = string.Empty;
                txtNombreCondor.Text =  string.Empty;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private List<TblParteCicloModel> CargarParteCiclo(string archivoSeleccionado, bool Encabezado, string Delimitador, TblConfiguracionRepuestoModel tblConfiguracionRepuestoModel)
        {
            List<TblParteCicloModel> tblParteCiclo = new List<TblParteCicloModel>();
            try
            {
                int cantidadColumnas = 3;
                List<string> ltsMensaje = new List<string>();
                using (StreamReader reader = new StreamReader(archivoSeleccionado, Encoding.Default))
                {
                    String linea;
                    int contador = 0;
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (Encabezado && contador == 0)
                        {
                            contador++;
                            continue;
                        }

                        string[] arrLines = linea.Split(Delimitador.ToCharArray());

                        if (arrLines.Length < cantidadColumnas)                        
                            throw new Exception($"El archivo '{Path.GetFileName(archivoSeleccionado)}' tiene {arrLines.Length} columnas y se esperan {cantidadColumnas} columnas.");
                        

                        int rangoInical = 0, rangoFinal = 0, NumeroParte = 0;

                        int.TryParse(arrLines[0], out NumeroParte);
                        int.TryParse(arrLines[1], out rangoInical);
                        int.TryParse(arrLines[2], out rangoFinal);

                        if (NumeroParte > 0 && rangoInical > 0 && rangoFinal > 0 && contador == NumeroParte)
                        {
                            tblParteCiclo.Add(new TblParteCicloModel
                            {
                                Id_configuracionRepuesto = tblConfiguracionRepuestoModel.Id,
                                NumeroParte = NumeroParte,
                                RangoInical = rangoInical,
                                RangoFinal = rangoFinal                                
                            });
                        }
                        else
                        {
                            int lineaArchivo = contador + 1;

                            if (rangoInical <= 0)
                                ltsMensaje.Add($"En la linea {lineaArchivo} : El rango inicial '{rangoInical}' contiene un valor menor a 1.");
                            if (rangoFinal <= 0)
                                ltsMensaje.Add($"En la linea {lineaArchivo} : El rango final '{rangoFinal}' contiene un valor menor a 1.");
                            if (NumeroParte <= 0)
                                ltsMensaje.Add($"En la linea {lineaArchivo} : El numero de parte '{NumeroParte}' contiene un valor menor a 1.");
                            if (NumeroParte != contador)
                                ltsMensaje.Add($"En la linea {lineaArchivo} : El numero de parte '{NumeroParte}' no es consecutivo.");
                        }

                        contador++;
                    }

                    if (ltsMensaje.Count > 0)
                        throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return tblParteCiclo;
        }

        private void ValidarFormulario()
        {
            try
            {
                CargarArchivo cargarArchivo = new CargarArchivo(null, null);
                List<string> ltsMensajes = new List<string>();

                if (cbxCLientes.SelectedIndex < 0)
                    ltsMensajes.Add($"*Por favor seleccionar el cliente.");

                if (cbxSeleccionarPruebas.SelectedIndex < 0)
                    ltsMensajes.Add($"*Por favor seleccionar la prueba.");

                if (Convert.ToInt32(usrCiclo.Value) <= 0)
                    ltsMensajes.Add($"*Por favor ingrese un número de ciclo.");

                if (string.IsNullOrEmpty(usrSeleccionarCargueCiclo.ArchivoSeleccionado))
                    ltsMensajes.Add($"*Por favor seleccionar un archivo con los ciclos.");
                else                
                    if (!Functions.FileHelper.ExisteArchivo(usrSeleccionarCargueCiclo.ArchivoSeleccionado,false))
                        ltsMensajes.Add($"*El archivo seleccionado {Path.GetFileName(usrSeleccionarCargueCiclo.ArchivoSeleccionado)} en la ruta {Path.GetDirectoryName(usrSeleccionarCargueCiclo.ArchivoSeleccionado)} no existe");

                if (string.IsNullOrEmpty(txtNombreCondor.Text) || string.IsNullOrWhiteSpace(txtNombreCondor.Text))
                    ltsMensajes.Add($"*Por favor ingrese el nombre de la prueba como se creo en condor.");
                else                
                    if (txtNombreCondor.Text.Length < 5)
                        ltsMensajes.Add($"*Por favor ingrese el nombre de la prueba como se creo en condor que sea mayor a 4 caracteres, cantidad de caracteres ingresado {txtNombreCondor.Text.Length}:({txtNombreCondor.Text})");
                

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                string strExtensionArchivoCargueCiclo = Path.GetExtension(usrSeleccionarCargueCiclo.ArchivoSeleccionado);
                string strNombreArchivoCargueCiclo = Path.GetFileName(usrSeleccionarCargueCiclo.ArchivoSeleccionado);
                string strPrimeraLineaArchivoCargueCiclo = cargarArchivo.ObtenerPrimeraLineaArchivo(usrSeleccionarCargueCiclo.ArchivoSeleccionado, true);

                if (!new[] { ".csv", ".txt" }.Any(t => strExtensionArchivoCargueCiclo.Contains(t)))
                    ltsMensajes.Add($"* Por favor seleccinar un archivo con extension '.txt' o '.csv' , el archivo '{strNombreArchivoCargueCiclo}' que intenta cargar tiene extension '{strExtensionArchivoCargueCiclo}'.");                

                if (!strPrimeraLineaArchivoCargueCiclo.Contains("\t"))
                    ltsMensajes.Add($"* El archivo '{strNombreArchivoCargueCiclo}' debe contener como delimitador o separador 'tab'.");

                ValidarEstructuraNombramiento(strNombreArchivoCargueCiclo, "(Ciclo|ciclo|CICLO)");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void lblNombreCondor_Click(object sender, EventArgs e)
        {

        }

        private void txtNombreCondor_TextChanged(object sender, EventArgs e)
        {

        }

        private void ValidarEstructuraNombramiento(string strNombreArchivo, string expresionRegular)
        {
            try
            {

                List<string> ltsMensajes = new List<string>();

                Regex regexEstructuraArchivoDistribucion = new Regex(expresionRegular);

                MatchCollection mc = regexEstructuraArchivoDistribucion.Matches(strNombreArchivo);
                //MatchCollection mcImpresion = regexEstructuraArchivoArchivo.Matches("(impresion|Impresion|IMPRESION|Impresión|impresión)");

                if (mc.Count == 0)
                    throw new Exception($"* El archivo '{strNombreArchivo}' no tiene el nombramiento correcto, debe contener la palabra 'distribucion'.");

                //if (mcImpresion.Count == 0)
                //    ltsMensajes.Add($"* El archivo '{strExtensionArchivoImpresion}' no tiene el nombramiento correcto, debe contener la palabra 'impresion'.");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
