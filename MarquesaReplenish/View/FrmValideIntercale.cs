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
    public partial class FrmValideIntercale : Form
    {
        public bool Correcto = false;
        private TblUsuarioModel _tblUsuarioModel = new TblUsuarioModel();
        private ConexionHelper _conexHelper = new ConexionHelper();
        private TblAuditoriaManager _tblAuditoriaManager = new TblAuditoriaManager();
        public List<TblEstadoModel> _ltsEstadoModel = new List<TblEstadoModel>();
        public FrmValideIntercale(TblUsuarioModel tblUsuarioModel)
        {
            this._tblUsuarioModel = tblUsuarioModel;             
            InitializeComponent();
            this.txtCodigoBarrasHojaRespuesta.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Correcto = false;
            this.Close();   
        }

        private void txtCodigoBarrasHojaRespuesta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) 
            {
                SqlConnection conex = null;
                SqlTransaction transaction = null;

                try
                {
                    if (string.IsNullOrEmpty(txtCodigoBarrasHojaRespuesta.Text) || string.IsNullOrWhiteSpace(txtCodigoBarrasHojaRespuesta.Text))
                        throw new Exception("* Por favor ingrese o leea el codigo de barra de la hoja de respuesta.");

                    conex = _conexHelper.GetConexion(ConexionHelper.BaseDatos.MarquesaReplenish);
                    conex.Open();
                    transaction = conex.BeginTransaction();


                    _tblAuditoriaManager._conex = conex;
                    _tblAuditoriaManager._tx = transaction;


                    bool encontrado = false;
                    int consecutivo = 0;
                    string nombreEstado = "Leído";
                    List<string> ltsIdDetalleRepuesto = new List<string>();

                    for (int i = 0; i < dgvValideIntercale.Rows.Count; i++)
                    {
                        string IdDetalleRepuesto = dgvValideIntercale.Rows[i].Cells["IdDetalleRepuesto"].Value.ToString();
                        int idConsecutivoInicial = Convert.ToInt32(dgvValideIntercale.Rows[i].Cells["IdCons"].Value);
                        string CodigoCuadernilllo = dgvValideIntercale.Rows[i].Cells["CodigoCuadernillo"].Value.ToString();
                        string CodigoHojaRespuesta = dgvValideIntercale.Rows[i].Cells["CodigoHojaRespuesta"].Value.ToString();
                        string estado = dgvValideIntercale.Rows[i].Cells["Estado"].Value.ToString();

                        if (estado == "Leído")
                            consecutivo = i + 1;
                        else if (estado == "Pendiente - Leído")
                            consecutivo = i + 1;
                        else if (estado == "Pendiente")
                            nombreEstado = "Pendiente - Leído";

                        if (!string.IsNullOrEmpty(IdDetalleRepuesto))
                            ltsIdDetalleRepuesto.Add($"{IdDetalleRepuesto}|{idConsecutivoInicial}|{CodigoCuadernilllo}|{CodigoHojaRespuesta}");

                        if (CodigoHojaRespuesta == txtCodigoBarrasHojaRespuesta.Text && estado != "Leído" && consecutivo == i)
                        {
                            dgvValideIntercale.Rows[i].Cells["Estado"].Value = nombreEstado;
                            encontrado = true;
                            dgvValideIntercale.Rows[i].Cells["Estado"].Style.BackColor = Color.Green;

                            if (dgvValideIntercale.Rows.Count == (i + 1))
                            {
                                foreach (var item in ltsIdDetalleRepuesto)
                                {
                                    string[] arrinformacion = item.Split('|');
                                    TblAuditoriaModel tblAuditoria = new TblAuditoriaModel();
                                    tblAuditoria.FechaHora = DateTime.Now;
                                    tblAuditoria.Id_DetalleRepuesto = Convert.ToInt32(arrinformacion[0]);
                                    tblAuditoria.Observacion = $"Repuesto Intercalado: Se intercala el numero de repuesto {arrinformacion[1]} con código de barra del cuadernillo {arrinformacion[2]} y hoja de respuesta {arrinformacion[3]}.";
                                    tblAuditoria.Id_Estado = _ltsEstadoModel.Find(t => t.Codigo == "03").Id;
                                    tblAuditoria.Id_Usuario = this._tblUsuarioModel.Id;
                                    tblAuditoria.Id = _tblAuditoriaManager.Guardar(tblAuditoria);
                                }

                                Correcto = true;
                                MessageBox.Show("Intercale terminado.");
                                transaction.Commit();
                                this.Close();
                            }

                            txtCodigoBarrasHojaRespuesta.Clear();
                            txtCodigoBarrasHojaRespuesta.Focus();
                            break;
                        }
                    }

                    if (!encontrado)
                        throw new Exception($"* Por favor ingresar o leer la hoja de repuesta '{dgvValideIntercale.Rows[consecutivo].Cells["CodigoHojaRespuesta"].Value}'.");

                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        transaction.Rollback();

                    txtCodigoBarrasHojaRespuesta.Text = String.Empty;
                    txtCodigoBarrasHojaRespuesta.Focus();
                    MessageBox.Show(ex.Message, "Error al buscar la hoja de respuesta para el intercale", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally 
                {
                    if (conex != null)
                        conex.Close();
                }
            }
        }

        private void FrmValideIntercale_Load(object sender, EventArgs e)
        {
            this.txtCodigoBarrasHojaRespuesta.Focus();
        }

        private void txtCodigoBarrasHojaRespuesta_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
