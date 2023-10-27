using BDManager;
using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.MN.Helpers;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace MarquesaReplenish.View
{
    public partial class FrmCargarArchivo : Form
    {
        private ConexionHelper _conexHelper = new ConexionHelper();

        private TblClienteManager _tblCleinteManager = new TblClienteManager();
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private TblCargueArchivoManager _tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblClienteCargueArchivoManager _tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblExaminandoManager tblExaminandoManager = new TblExaminandoManager();

        public FrmCargarArchivo(TblUsuarioModel UsuarioModel)
        {
            this._tblUsuarioModel = UsuarioModel;
            InitializeComponent();
        }

        private void CargarComboClient()
        {
            try
            {
                _tblCleinteManager._conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                _tblCleinteManager._conex.Open();
                _tblCleinteManager._tx = _tblCleinteManager._conex.BeginTransaction();

                List<TblClienteModel> tblClientes = _tblCleinteManager.GetFullTableTblCliente();

                if (tblClientes == null)
                    throw new Exception("* No se ha podido obtener los cliente.");
                if (tblClientes.Count < 1)
                    throw new Exception("* La lista de cliente que se intenta cargar esta vacía.");

                cbxCLientes.ValueMember = $"{TblClienteModel.EnumCampos.Id}";
                cbxCLientes.DisplayMember = $"{TblClienteModel.EnumCampos.Nombre}";
                cbxCLientes.DataSource = tblClientes.OrderBy(t => t.Nombre).Where(t => t.Estado == true).ToList();

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

        private void FrmCargarArchivo_Load(object sender, EventArgs e)
        {
            CargarComboClient();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            SqlConnection conex = null;
            SqlTransaction transaction = null;
            TblCargueArchivoModel tblCargueArchivoModel = new TblCargueArchivoModel();
            TblClienteCargueArchivoModel tblClienteCargueArchivoModel = new TblClienteCargueArchivoModel();
            TblClienteModel tblClienteModel = new TblClienteModel();

            try
            {
                DateTime tiempoInicial = DateTime.Now;
                TimeSpan tiempoFinal = new TimeSpan();

                this.Cursor = Cursors.WaitCursor;
                this.btnGuardar.Enabled = false;    
                ValidarInformacion();

                conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                conex.Open();
                transaction = conex.BeginTransaction();

                _tblCargueArchivoManager._conex = conex;
                _tblCargueArchivoManager._tx = transaction;
                _tblClienteCargueArchivoManager._conex = conex;
                _tblClienteCargueArchivoManager._tx = transaction;
                _tblCleinteManager._conex = conex;
                _tblCleinteManager._tx = transaction;

                CargarArchivo cargarArchivo = new CargarArchivo(conex, transaction);

                int Id_Cliente = Convert.ToInt32(cbxCLientes.SelectedValue);

                tblClienteModel = _tblCleinteManager.GetData(Id_Cliente);

                tblCargueArchivoModel.NombreCarguePrueba = txtNombreCargue.Text;
                tblCargueArchivoModel.FechaCargue = DateTime.Now;
                tblCargueArchivoModel.NombreBibliaDistribucion = Path.GetFileName(usrSeleccionarBibliaUnificada.ArchivoSeleccionado);
                //tblCargueArchivoModel.NombreBibliaImpresion = Path.GetFileName(usrSeleccionarBibliaImpresion.ArchivoSeleccionado);
                tblCargueArchivoModel.NombreBibliaImpresion = string.Empty;
                tblCargueArchivoModel.UsuarioCreacion = this._tblUsuarioModel.Usuario;

                TblCargueArchivoModel tblCargueArchivoExiste = _tblCargueArchivoManager.GetExisteCargueData(Id_Cliente, tblCargueArchivoModel.NombreCarguePrueba);

                if (tblCargueArchivoExiste != null)
                    throw new Exception($"Ya existe el nombre de pruebas '{txtNombreCargue.Text}' asignado al cliente '{cbxCLientes.SelectedText}'");

                tblCargueArchivoModel.Id = _tblCargueArchivoManager.Guardar(tblCargueArchivoModel);

                tblClienteCargueArchivoModel.Id_CargueArchivo = tblCargueArchivoModel.Id;
                tblClienteCargueArchivoModel.Id_Cliente = Convert.ToInt32(cbxCLientes.SelectedValue);
                tblClienteCargueArchivoModel.Id = _tblClienteCargueArchivoManager.Guardar(tblClienteCargueArchivoModel);

                transaction.Commit();

                int cantidadLineasCargadas = cargarArchivo.CargarBDGeneral(usrSeleccionarBibliaUnificada.ArchivoSeleccionado, '|', true, tblCargueArchivoModel);
                //cargarArchivo.CargarDistribucion(usrSeleccionarBibliaDistribucion.ArchivoSeleccionado, '|', true, tblCargueArchivoModel);
                //cargarArchivo.CargarImpresion(usrSeleccionarBibliaImpresion.ArchivoSeleccionado, '|', true, tblCargueArchivoModel);                

                //transaction.Commit();

                tiempoFinal = DateTime.Now - tiempoInicial;
                string strFechaHoraFinal = string.Format("Tiempo de cargue de archivo: {0}hr : {1}min: {2}seg", tiempoFinal.Hours, tiempoFinal.Minutes, tiempoFinal.Seconds);

                MessageBox.Show($"Nombre del Cague: {tblCargueArchivoModel.NombreCarguePrueba} {Environment.NewLine}" +
                                $"Archivo Cargado: {tblCargueArchivoModel.NombreBibliaDistribucion} {Environment.NewLine}" +
                                $"Cantidad de lineas cargadas: {(cantidadLineasCargadas - 1)} {Environment.NewLine}" +
                                $"Nombre del cliente: {tblClienteModel.Nombre} {Environment.NewLine}{Environment.NewLine}" +
                                $"{strFechaHoraFinal}", "Cargue Exitoso.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                limpiarFormulario();

            }
            catch (Exception ex)
            {
                try
                {
                    if (transaction != null)
                        transaction.Rollback();
                }
                catch (Exception)
                {

                    this.Cursor = Cursors.Default;
                    this.btnGuardar.Enabled = true;
                    MessageBox.Show(ex.Message, "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                this.Cursor = Cursors.Default;
                this.btnGuardar.Enabled = true;
                MessageBox.Show(ex.Message, "Error al cargar el archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                txtNombreCargue.Text = string.Empty;
                usrSeleccionarBibliaUnificada.ArchivoSeleccionado = string.Empty;
                this.Cursor = Cursors.Default;
                this.btnGuardar.Enabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ValidarInformacion()
        {
            try
            {
                List<string> ltsMensajes = new List<string>();
                CargarArchivo cargarArchivo = new CargarArchivo(null, null);

                if (cbxCLientes.SelectedIndex < 0)
                    ltsMensajes.Add("* Por favor seleccione el cliente.");

                if (string.IsNullOrEmpty(usrSeleccionarBibliaUnificada.ArchivoSeleccionado))
                    ltsMensajes.Add("* Por favor seleccione el la biblia Unificada.");
                else
                {
                    if (!Functions.FileHelper.ExisteArchivo(usrSeleccionarBibliaUnificada.ArchivoSeleccionado, false))
                        ltsMensajes.Add($"*El archivo seleccionado '{Path.GetFileName(usrSeleccionarBibliaUnificada.ArchivoSeleccionado)}' en la ruta '{Path.GetDirectoryName(usrSeleccionarBibliaUnificada.ArchivoSeleccionado)}' no existe.");
                }

                //if (string.IsNullOrEmpty(usrSeleccionarBibliaImpresion.ArchivoSeleccionado))
                //    ltsMensajes.Add("* Por favor seleccione el la biblia de impresión.");

                if (string.IsNullOrEmpty(txtNombreCargue.Text) || string.IsNullOrEmpty(txtNombreCargue.Text))
                    ltsMensajes.Add("* Por favor ingresar un nombre de cargue.");
                else
                    if (txtNombreCargue.Text.Length < 5)
                    ltsMensajes.Add($"* Por favor ingresar un nombre del cargue que sea mayor a 4 caracteres, cantidad de caracteres ingresado {txtNombreCargue.Text.Length}:({txtNombreCargue.Text})");


                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                string strRutaArchivoDistribucion = usrSeleccionarBibliaUnificada.ArchivoSeleccionado;
                //string strRutaArchivoImpresion = usrSeleccionarBibliaImpresion.ArchivoSeleccionado;

                string strExtensionArchivoDistribucion = Path.GetExtension(strRutaArchivoDistribucion).Trim().ToLower();
                //string strExtensionArchivoImpresion = Path.GetExtension(strRutaArchivoImpresion).Trim().ToLower();

                string strNombreArchivoDistribucion = Path.GetFileName(strRutaArchivoDistribucion);
                //string strNombreArchivoImpresion = Path.GetFileName(strRutaArchivoImpresion);

                string strPrimeraLineaArchivoDistribucion = cargarArchivo.ObtenerPrimeraLineaArchivo(strRutaArchivoDistribucion, true);
                //string strPrimeraLineaArchivoImpresion = cargarArchivo.ObtenerPrimeraLineaArchivo(strRutaArchivoDistribucion, true);

                if ( !new[] {".csv",".txt" }.Any(t => strExtensionArchivoDistribucion.Contains(t)))
                    ltsMensajes.Add($"* Por favor seleccinar un archivo con extension '.txt' o '.csv' , el archivo '{strNombreArchivoDistribucion}' que intenta cargar tiene extension '{strExtensionArchivoDistribucion}'.");

                //if (strExtensionArchivoImpresion != ".csv")
                //    ltsMensajes.Add($"* Por favor seleccinar un archivo con extension '.csv', el archivo '{strRutaArchivoImpresion}' que intenta cargar tiene extension '{strRutaArchivoImpresion}'.");

                if (!strPrimeraLineaArchivoDistribucion.Contains("|"))
                    ltsMensajes.Add($"* El archivo '{strNombreArchivoDistribucion}' debe contener como delimitador o separador '|'.");

                //if (!strPrimeraLineaArchivoImpresion.Contains("|"))
                //    ltsMensajes.Add($"* El archivo '{strExtensionArchivoDistribucion}' debe contenenr como delimitador o separador '|'.");

                ValidarEstructuraNombramiento(strNombreArchivoDistribucion, "(BDGeneral|bdGeneral|BDgeneral|bdgeneral)");
                //ValidarEstructuraNombramiento(strNombreArchivoDistribucion, "(distribucion|Distribucion|distribución|Distribución|DISTRIBUCION)");
                //ValidarEstructuraNombramiento(strNombreArchivoImpresion, "(impresion|Impresion|IMPRESION|Impresión|impresión)");


                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
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
                    throw new Exception($"* El archivo '{strNombreArchivo}' no tiene el nombramiento correcto, debe contener la palabra '{expresionRegular.Replace("|"," ó ")}'.");

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
