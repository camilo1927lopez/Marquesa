/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDManager;
using System.Data.SqlClient;
using System.Data;
using MarquesaReplenish.PD.Model;

namespace MarquesaReplenish.MN.Manager
{
	public partial class TblAuditoriaManager : ConexionBD
	{
		public int Guardar(TblAuditoriaModel clTblAuditoria)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblAuditoriaInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			//cmd.Parameters.AddWithValue("@Id", clTblAuditoria.Id);
			cmd.Parameters.AddWithValue("@Id_DetalleRepuesto", clTblAuditoria.Id_DetalleRepuesto);
			cmd.Parameters.AddWithValue("@Id_Estado", clTblAuditoria.Id_Estado);
			cmd.Parameters.AddWithValue("@Id_Usuario", clTblAuditoria.Id_Usuario);
			cmd.Parameters.AddWithValue("@FechaHora", clTblAuditoria.FechaHora);
			cmd.Parameters.AddWithValue("@Observacion", clTblAuditoria.Observacion);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblAuditoriaModel clTblAuditoria)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblAuditoriaEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblAuditoria.Id);
					cmd.Parameters.AddWithValue("@Id_DetalleRepuesto", clTblAuditoria.Id_DetalleRepuesto);
					cmd.Parameters.AddWithValue("@Id_Estado", clTblAuditoria.Id_Estado);
					cmd.Parameters.AddWithValue("@Id_Usuario", clTblAuditoria.Id_Usuario);
					cmd.Parameters.AddWithValue("@FechaHora", clTblAuditoria.FechaHora);
					cmd.Parameters.AddWithValue("@Observacion", clTblAuditoria.Observacion);
					SqlParameter param = new SqlParameter("@Cont", System.Data.SqlDbType.Int);
					param.Direction = System.Data.ParameterDirection.ReturnValue;
					cmd.Parameters.Add(param);

					cmd.ExecuteNonQuery();

					return (Convert.ToInt32(param.Value) == 1);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public bool Eliminar(int Id)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblAuditoriaEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblAuditoriaModel.EnumCampos.Id.ToString()), Id);

					SqlParameter param = new SqlParameter("@Cont", System.Data.SqlDbType.Int);
					param.Direction = System.Data.ParameterDirection.ReturnValue;
					cmd.Parameters.Add(param);
					cmd.ExecuteNonQuery();

					return (Convert.ToInt32(param.Value) == 1);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public TblAuditoriaModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblAuditoria");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblAuditoriaModel.EnumCampos.Id.ToString(), TblAuditoriaModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblAuditoriaModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblAuditoria que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblAuditoriaModel clTblAuditoriaModel = new TblAuditoriaModel();
			clTblAuditoriaModel.ParseData(tbl.Rows[0]);
			return clTblAuditoriaModel;
		}

		public DataTable GetFullTableTblAuditoria()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblAuditoria");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblAuditoriaModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public List<TblAuditoriaModel> GetTableTblAuditoriaXTblDetalleRepuesto(int Id_DetalleRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblAuditoriaXTblDetalleRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblAuditoriaModel.EnumCampos.Id_DetalleRepuesto.ToString(), TblAuditoriaModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblAuditoriaModel.EnumCampos.Id_DetalleRepuesto.ToString(), Id_DetalleRepuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblAuditoriaModel> ltsAuditoriaModels = new List<TblAuditoriaModel>();
			ltsAuditoriaModels = Functions.DataTableHelper.ConvertDataTableToList<TblAuditoriaModel>(tbl);

			return ltsAuditoriaModels;
		}


		public DataTable GetTableTblAuditoriaXTblEstado(int Id_Estado)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblAuditoriaXTblEstado");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblAuditoriaModel.EnumCampos.Id_Estado.ToString(), TblAuditoriaModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblAuditoriaModel.EnumCampos.Id_Estado.ToString(), Id_Estado);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}


		public DataTable GetTableTblAuditoriaXTblUsuario(int Id_Usuario)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblAuditoriaXTblUsuario");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblAuditoriaModel.EnumCampos.Id_Usuario.ToString(), TblAuditoriaModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblAuditoriaModel.EnumCampos.Id_Usuario.ToString(), Id_Usuario);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public DataTable GetValidarLiberacionInstitucion(int Id_ConfiguracionRepuesto, string CodigoSitio)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblAuditoriaValidarLiberacionInstitucion");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@" + TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), Id_ConfiguracionRepuesto);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.CodigoSitio.ToString(), CodigoSitio);
			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public int LiberacionInstitucion(int Id_ConfiguracionRepuesto, string CodigoSitio, int Id_Usuario)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblAuditoriaLiberacionInstitucion");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@" + TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), Id_ConfiguracionRepuesto);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.CodigoSitio.ToString(), CodigoSitio);
			cmd.Parameters.AddWithValue("@" + TblAuditoriaModel.EnumCampos.Id_Usuario.ToString(), Id_Usuario);
			SqlParameter param = new SqlParameter("@Cont", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public DataTable TrazabilidadRepuesto(Dictionary<string, dynamic> dcFiltros)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblAuditoriaTrazabilidad");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (var item in dcFiltros)            
				cmd.Parameters.AddWithValue("@" + item.Key, item.Value);


			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}
	}
}