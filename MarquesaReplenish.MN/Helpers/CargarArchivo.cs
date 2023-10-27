using MarquesaReplenish.MN.Manager;
using MarquesaReplenish.PD.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.MN.Helpers
{
    public class CargarArchivo 
    {
        public SqlConnection _conexion = null;
        public SqlTransaction _transaction = null;

        private TblCargueArchivoManager tblCargueArchivoManager = new TblCargueArchivoManager();
        private TblClienteCargueArchivoManager tblClienteCargueArchivoManager = new TblClienteCargueArchivoManager();
        private TblExaminandoManager tblExaminandoManager = new TblExaminandoManager();
        private DataTable dtbExaminando = new DataTable();

        public CargarArchivo(SqlConnection Conexion, SqlTransaction Transaction)
        {
            this._conexion = Conexion;
            this._transaction = Transaction;

            TblExaminandoModel tblExaminandoModel = new TblExaminandoModel();

            if (dtbExaminando.Columns.Count <= 0)
            {
                foreach (var item in tblExaminandoModel.GetType().GetProperties())
                {
                    Type myType = item.PropertyType;
                    dtbExaminando.Columns.Add(item.Name, myType);

                }
            }
        }
        public List<TblExaminandoModel> CargarDistribucion(string Archivo, char Delimitador, bool Encabezado, TblCargueArchivoModel tblCargueArchivo) 
        {
            List<TblExaminandoModel> ltsExaminandoModel = new List<TblExaminandoModel>();
            try
            {
                tblExaminandoManager._conex = _conexion;
                tblExaminandoManager._tx = _transaction;
                using (StreamReader reader = new StreamReader(Archivo, Encoding.Default)) 
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
                        Guid guid = Guid.NewGuid();
                        string[] arrLines = linea.Split(Delimitador);

                        ltsExaminandoModel.Add(new TblExaminandoModel()
                        {
                            NombrePrueba = arrLines[(int)TblExaminandoModel.EnumCampos.NombrePrueba],
                            FechaAplicacion = arrLines[(int)TblExaminandoModel.EnumCampos.FechaAplicacion],
                            NombreDepartamento = arrLines[(int)TblExaminandoModel.EnumCampos.NombreDepartamento],
                            CodigoMunicipio = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoMunicipio],
                            NombreMunicipio = arrLines[(int)TblExaminandoModel.EnumCampos.NombreMunicipio],
                            CodigoSitio = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoSitio],
                            NombreSitio = arrLines[(int)TblExaminandoModel.EnumCampos.NombreSitio],
                            DireccionSitio = arrLines[(int)TblExaminandoModel.EnumCampos.DireccionSitio],
                            CodigoSalon = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoSalon],
                            NombreSalon = arrLines[(int)TblExaminandoModel.EnumCampos.NombreSalon],
                            Sesion = arrLines[(int)TblExaminandoModel.EnumCampos.Sesion],
                            Bloque = arrLines[(int)TblExaminandoModel.EnumCampos.Bloque],
                            ConsecutivoControl = arrLines[(int)TblExaminandoModel.EnumCampos.ConsecutivoControl],
                            CodigoCuadernillo = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoCuadernillo],
                            CodigoHojaRespuesta = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoHojaRespuesta],
                            IdConsecutivo = arrLines[(int)TblExaminandoModel.EnumCampos.IdConsecutivo],
                            CodigoActa = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoActa],
                            id_CargueArchivo = tblCargueArchivo.Id
                        });

                        //DataRow dtrExaminando = dtbExaminando.NewRow();
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Id.ToString()] = guid;
                        //dtrExaminando[TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString()] = tblCargueArchivo.Id;
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombrePrueba.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombrePrueba];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.FechaAplicacion.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.FechaAplicacion];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreDepartamento.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreDepartamento];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoMunicipio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoMunicipio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreMunicipio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreMunicipio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoSitio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoSitio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreSitio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreSitio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.DireccionSitio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.DireccionSitio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoSalon.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoSalon];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreSalon.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreSalon];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Sesion.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Sesion];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Bloque.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Bloque];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.ConsecutivoControl.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.ConsecutivoControl];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoCuadernillo.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoCuadernillo];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoHojaRespuesta.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoHojaRespuesta];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.IdConsecutivo.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.IdConsecutivo];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoActa.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoActa];

                        //dtbExaminando.Rows.Add(dtrExaminando);

                        if (ltsExaminandoModel.Count == 5000)
                        {
                            tblExaminandoManager.Guardar(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                            ltsExaminandoModel = new List<TblExaminandoModel>();
                            //tblExaminandoManager.Guardar(dtbExaminando);
                            //dtbExaminando.Rows.Clear();
                        }

                        contador++;
                    }

                    if (ltsExaminandoModel.Count > 0)
                    {
                        tblExaminandoManager.Guardar(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                        ltsExaminandoModel = new List<TblExaminandoModel>();
                        //tblExaminandoManager.Guardar(dtbExaminando);
                        //dtbExaminando.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                dtbExaminando.Rows.Clear();
                throw new Exception(ex.Message);
            }
            return ltsExaminandoModel;
        }
        public int CargarBDGeneral(string Archivo, char Delimitador, bool Encabezado, TblCargueArchivoModel tblCargueArchivo)
        {
            List<TblExaminandoModel> ltsExaminandoModel = new List<TblExaminandoModel>();
            int contador = 0;
            try
            {
                tblExaminandoManager._conex = _conexion;
                //tblExaminandoManager._tx = _transaction;
                int cantidadLineasIngresar = 10000;
                int cantidadColumnas = 46;
                using (StreamReader reader = new StreamReader(Archivo, Encoding.Default))
                {
                    String linea;                   
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (Encabezado && contador == 0)
                        {
                            contador++;
                            continue;
                        }
                        Guid guid = Guid.NewGuid();
                        string[] arrLines = linea.Split(Delimitador);

                        if (arrLines.Length < cantidadColumnas) 
                        {                          
                            if (contador < cantidadLineasIngresar)
                                throw new Exception($"El archivo '{Path.GetFileName(Archivo)}' tiene {arrLines.Length} columnas y se esperan {cantidadColumnas} columnas.");
                            else 
                            {
                                int resultadoCantidadLineasCargadas = cantidadLineasIngresar * (contador / cantidadLineasIngresar);

                                throw new Exception($"El archivo '{Path.GetFileName(Archivo)}' tiene {arrLines.Length} columnas y se esperan {cantidadColumnas} columnas{Environment.NewLine}{Environment.NewLine}" +
                                    $"Se han cargado {resultadoCantidadLineasCargadas} lineas, por favor notificar a TI Gestion del Riesgo para realizar la eliminacion cargadas.");
                            }                                                            
                        }                            

                        ltsExaminandoModel.Add(new TblExaminandoModel()
                        {
                            NombrePrueba = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.NombrePrueba],
                            FechaAplicacion = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.FechaAplicacion],
                            NombreDepartamento = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.NombreDepartamento],
                            CodigoMunicipio = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.CodigoMunicipio],
                            NombreMunicipio = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.NombreMunicipio],
                            CodigoSitio = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.CodigoSitio],
                            NombreSitio = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.NombreSitio],
                            DireccionSitio = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.DireccionSitio],
                            CodigoSalon = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.CodigoSalon],
                            NombreSalon = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.NombreSalon],
                            Sesion = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Sesion],
                            Bloque = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Bloque],
                            ConsecutivoControl = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.ConsecutivoControl],
                            CodigoCuadernillo = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.CodigoCuadernillo],
                            CodigoHojaRespuesta = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.CodigoHojaRespuesta],
                            IdConsecutivo = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.IdConsecutivo],
                            CodigoActa = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.CodigoActa],
                            Registro = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Registro],
                            Nombre1 = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Nombre1],
                            Nombre2 = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Nombre2],
                            Apellido1 = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Apellido1],
                            Apellido2 = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Apellido2],
                            Documento = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Documento],
                            Forma = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.Forma],
                            TipoHR = arrLines[(int)TblExaminandoModel.EnumCamposBDGeneral.TipoHR],
                            id_CargueArchivo = tblCargueArchivo.Id
                        });

                        #region UsuarDatablet
                        //DataRow dtrExaminando = dtbExaminando.NewRow();
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Id.ToString()] = guid;
                        //dtrExaminando[TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString()] = tblCargueArchivo.Id;
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombrePrueba.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombrePrueba];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.FechaAplicacion.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.FechaAplicacion];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreDepartamento.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreDepartamento];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoMunicipio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoMunicipio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreMunicipio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreMunicipio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoSitio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoSitio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreSitio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreSitio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.DireccionSitio.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.DireccionSitio];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoSalon.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoSalon];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.NombreSalon.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.NombreSalon];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Sesion.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Sesion];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Bloque.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Bloque];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.ConsecutivoControl.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.ConsecutivoControl];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoCuadernillo.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoCuadernillo];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoHojaRespuesta.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoHojaRespuesta];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.IdConsecutivo.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.IdConsecutivo];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoActa.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoActa];

                        //dtbExaminando.Rows.Add(dtrExaminando);
                        #endregion                        

                        if (ltsExaminandoModel.Count == cantidadLineasIngresar)
                        {
                            tblExaminandoManager.GuardarBulkCopy(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                            //tblExaminandoManager.Guardar(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                            ltsExaminandoModel = new List<TblExaminandoModel>();
                            //tblExaminandoManager.Guardar(dtbExaminando);
                            //dtbExaminando.Rows.Clear();
                        }

                        contador++;
                    }

                    if (ltsExaminandoModel.Count > 0)
                    {
                        tblExaminandoManager.GuardarBulkCopy(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                        ltsExaminandoModel = new List<TblExaminandoModel>();
                        //tblExaminandoManager.Guardar(dtbExaminando);
                        //dtbExaminando.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                dtbExaminando.Rows.Clear();
                throw new Exception(ex.Message);
            }
            return contador;
        }
        public List<TblExaminandoModel> CargarImpresion(string Archivo, char Delimitador, bool Encabezado, TblCargueArchivoModel tblCargueArchivo)
        {
            try
            {
                tblExaminandoManager._conex = _conexion;
                tblExaminandoManager._tx = _transaction;

                List<TblExaminandoModel> ltsExaminandoModel = new List<TblExaminandoModel>();

                using (StreamReader reader = new StreamReader(Archivo, Encoding.Default))
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

                        string[] arrLines = linea.Split(Delimitador);

                        //DataRow dtrExaminando = dtbExaminando.NewRow();
                        //dtrExaminando[TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString()] = tblCargueArchivo.Id;
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Registro.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Registro];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Nombre1.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Nombre1];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Nombre2.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Nombre2];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Apellido1.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Apellido1];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Apellido2.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Apellido2];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Documento.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Documento];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.Forma.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.Forma];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.TipoHR.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.TipoHR];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoCuadernilloImpresion.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoCuadernilloImpresion];
                        //dtrExaminando[TblExaminandoModel.EnumCampos.CodigoHojaRespuestaImpresion.ToString()] = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoHojaRespuestaImpresion];

                        //dtbExaminando.Rows.Add(dtrExaminando);

                        ltsExaminandoModel.Add(new TblExaminandoModel()
                        {
                            Registro = arrLines[(int)TblExaminandoModel.EnumCampos.Registro],
                            Nombre1 = arrLines[(int)TblExaminandoModel.EnumCampos.Nombre1],
                            Nombre2 = arrLines[(int)TblExaminandoModel.EnumCampos.Nombre2],
                            Apellido1 = arrLines[(int)TblExaminandoModel.EnumCampos.Apellido1],
                            Apellido2 = arrLines[(int)TblExaminandoModel.EnumCampos.Apellido2],
                            Documento = arrLines[(int)TblExaminandoModel.EnumCampos.Documento],
                            Forma = arrLines[(int)TblExaminandoModel.EnumCampos.Forma],
                            TipoHR = arrLines[(int)TblExaminandoModel.EnumCampos.TipoHR],
                            CodigoCuadernillo = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoCuadernilloImpresion],
                            CodigoHojaRespuesta = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoHojaRespuestaImpresion],
                            id_CargueArchivo = tblCargueArchivo.Id
                        });


                        if (ltsExaminandoModel.Count == 1000)
                        {
                            tblExaminandoManager.Editar(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                            ltsExaminandoModel = new List<TblExaminandoModel>();
                            //tblExaminandoManager.Editar(dtbExaminando);
                            //dtbExaminando.Rows.Clear();
                        }
                        contador++;
                    }

                    if (ltsExaminandoModel.Count > 0)
                    {
                        tblExaminandoManager.Editar(Functions.ListHelper.ConvertToDataTable<TblExaminandoModel>(ltsExaminandoModel));
                        ltsExaminandoModel = new List<TblExaminandoModel>();
                        //tblExaminandoManager.Editar(dtbExaminando);
                        //dtbExaminando.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                dtbExaminando.Rows.Clear();
                throw new Exception(ex.Message);
            }

            return new List<TblExaminandoModel>();
        }
        public List<TblExaminandoModel> CargarImpresion(string Archivo, char Delimitador, List<TblExaminandoModel> ltsArchivosDistribucion, bool Encabezado)
        {
            try
            {
                List<TblExaminandoModel> ltsExaminandoModel = new List<TblExaminandoModel>();
                List<string> ltsMensaje = new List<string>();

                using (StreamReader reader = new StreamReader(Archivo, Encoding.Default))
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

                        string[] arrLines = linea.Split(Delimitador);

                        TblExaminandoModel tblExaminandoModel = new TblExaminandoModel()
                        {
                            Registro = arrLines[(int)TblExaminandoModel.EnumCampos.Registro],
                            Nombre1 = arrLines[(int)TblExaminandoModel.EnumCampos.Nombre1],
                            Nombre2 = arrLines[(int)TblExaminandoModel.EnumCampos.Nombre2],
                            Apellido1 = arrLines[(int)TblExaminandoModel.EnumCampos.Apellido1],
                            Apellido2 = arrLines[(int)TblExaminandoModel.EnumCampos.Apellido2],
                            Documento = arrLines[(int)TblExaminandoModel.EnumCampos.Documento],
                            Forma = arrLines[(int)TblExaminandoModel.EnumCampos.Forma],
                            TipoHR = arrLines[(int)TblExaminandoModel.EnumCampos.TipoHR],
                            CodigoCuadernillo = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoCuadernilloImpresion],
                            CodigoHojaRespuesta = arrLines[(int)TblExaminandoModel.EnumCampos.CodigoHojaRespuestaImpresion]
                        };

                        List<TblExaminandoModel> tblExaminandoEncontrado = ltsArchivosDistribucion.Where(t => t.CodigoCuadernillo == tblExaminandoModel.CodigoCuadernillo && t.CodigoHojaRespuesta == tblExaminandoModel.CodigoHojaRespuesta).ToList();

                        if (tblExaminandoEncontrado.Count > 1)
                            ltsMensaje.Add($"La siguiente informacion se repite '{tblExaminandoEncontrado.Count}' veces:{Environment.NewLine}" +
                                $"Documento: {tblExaminandoModel.Documento}{Environment.NewLine}" +
                                $"Nombres: {tblExaminandoModel.Nombre1} {tblExaminandoModel.Nombre2} {Environment.NewLine}" +
                                $"Apellidos: {tblExaminandoModel.Apellido1} {tblExaminandoModel.Apellido1} {Environment.NewLine}" +
                                $"Registro: {tblExaminandoModel.Registro} {Environment.NewLine}" +
                                $"Forma: {tblExaminandoModel.Forma} {Environment.NewLine}" +
                                $"TipoHR: {tblExaminandoModel.TipoHR} {Environment.NewLine}" +
                                $"CodigoCuadernillo: {tblExaminandoModel.CodigoCuadernillo} {Environment.NewLine}" +
                                $"CodigoHojaRespuesta: {tblExaminandoModel.CodigoHojaRespuesta}");


                        tblExaminandoEncontrado.ForEach(t => { t.Registro = tblExaminandoModel.Registro; 
                            t.Nombre1 = tblExaminandoModel.Nombre1; 
                            t.Nombre2 = tblExaminandoModel.Nombre2;
                            t.Apellido1 = tblExaminandoModel.Apellido1;
                            t.Apellido2 = tblExaminandoModel.Apellido2;
                            t.Documento = tblExaminandoModel.Documento;
                            t.Forma = tblExaminandoModel.Forma;
                            t.TipoHR = tblExaminandoModel.TipoHR;
                            t.CodigoCuadernillo = tblExaminandoModel.CodigoCuadernillo;
                            t.CodigoHojaRespuesta = tblExaminandoModel.CodigoHojaRespuesta;
                            //ltsArchivosDistribucion.Remove(t);
                        });                        

                        //ltsExaminandoModel.AddRange(tblExaminandoEncontrado);

                        contador++;
                        
                    }
                }

                if (ltsMensaje.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensaje)}");
            }
            catch (Exception ex)
            {
                throw new Exception($"La informacion que se encuentra en el archivo {Path.GetFileName(Archivo)} se encuentra varias veces repetida en el archivo de distribución." +
                                $"{Environment.NewLine}{Environment.NewLine}"+ ex.Message);
            }

            return ltsArchivosDistribucion;
        }
        public string ObtenerPrimeraLineaArchivo(string Archivo, bool Encabezado)
        {
            try
            {
                String linea;
                string strLineaEncabezado = string.Empty;
                string strLineaUno = string.Empty;
                List<string> ltsMensajes = new List<string>();
                int contador = 0;
                if (!File.Exists(Archivo))                
                    throw new Exception($"El archivo '{Path.GetFileName(Archivo)}' no existe en la ruta '{Path.GetDirectoryName(Archivo)}'.");                

                using (StreamReader reader = new StreamReader(Archivo, Encoding.Default))
                {
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (Encabezado && contador == 0)
                        {
                            strLineaEncabezado = linea;
                            contador++;
                            continue;
                        }   
                        
                        strLineaUno = linea;
                        contador++;
                        break;
                    }
                }

                if ((Encabezado) && (string.IsNullOrEmpty(strLineaEncabezado) || string.IsNullOrWhiteSpace(strLineaEncabezado)))
                    ltsMensajes.Add($"El archivo '{Path.GetFileName(Archivo)}' contiene lineas vacias");

                if (string.IsNullOrEmpty(strLineaUno) || string.IsNullOrWhiteSpace(strLineaUno))
                    ltsMensajes.Add($"El archivo '{Path.GetFileName(Archivo)}' contiene lineas vacias");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                return linea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public DataTable ObtenerLineaArchivo(string Archivo, bool Encabezado, int CantidadLineas, char Delimitador, string[] listaNuevasColumnas)
        {
            try
            {
                String linea;
                DataTable dt = new DataTable();
                string strLineaEncabezado = string.Empty;
                string strLineaUno = string.Empty;
                List<string> ltsMensajes = new List<string>();
                int contador = 0;
                if (!File.Exists(Archivo))
                    throw new Exception($"El archivo '{Path.GetFileName(Archivo)}' no existe en la ruta '{Path.GetDirectoryName(Archivo)}'.");

                using (StreamReader reader = new StreamReader(Archivo, Encoding.Default))
                {
                    while ((linea = reader.ReadLine()) != null)
                    {
                        if (Encabezado && contador == 0)
                        {
                            strLineaEncabezado = linea;

                            string[] arrLineaEncabezado = strLineaEncabezado.Split(Delimitador);

                            for (int i = 0; i < arrLineaEncabezado.Length; i++)
                            {
                                if (dt.Columns[arrLineaEncabezado[i]] == null)                                
                                    dt.Columns.Add(arrLineaEncabezado[i], typeof(string));                                           
                            }


                            if (listaNuevasColumnas != null)
                                if (listaNuevasColumnas.Length > 0)
                                    for (int x = 0; x < listaNuevasColumnas.Length; x++)
                                    {
                                        if (dt.Columns[listaNuevasColumnas[x]] == null)
                                            dt.Columns.Add(listaNuevasColumnas[x], typeof(string));

                                    }

                            contador++;
                            continue;
                        }

                        strLineaUno = linea;

                        string[] arrLineaUno = strLineaUno.Split(Delimitador);

                        dt.Rows.Add(arrLineaUno);

                        if (CantidadLineas == contador)
                            break;

                        contador++;

                    }
                }

                if ((Encabezado) && (string.IsNullOrEmpty(strLineaEncabezado) || string.IsNullOrWhiteSpace(strLineaEncabezado)))
                    ltsMensajes.Add($"El archivo '{Path.GetFileName(Archivo)}' contiene lineas vacias");

                if (string.IsNullOrEmpty(strLineaUno) || string.IsNullOrWhiteSpace(strLineaUno))
                    ltsMensajes.Add($"El archivo '{Path.GetFileName(Archivo)}' contiene lineas vacias");

                if (ltsMensajes.Count > 0)
                    throw new Exception($"{string.Join(Environment.NewLine, ltsMensajes)}");

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
