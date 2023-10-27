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
	public partial class TblEstadoManager : ConexionBD
	{
		public int Guardar(TblEstadoModel clTblEstado)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblEstadoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Codigo", clTblEstado.Codigo);
			cmd.Parameters.AddWithValue("@Nombre", clTblEstado.Nombre);
			cmd.Parameters.AddWithValue("@Estado", clTblEstado.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblEstadoModel clTblEstado)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblEstadoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblEstado.Id);
					cmd.Parameters.AddWithValue("@Nombre", clTblEstado.Nombre);
					cmd.Parameters.AddWithValue("@Estado", clTblEstado.Estado);
					cmd.Parameters.AddWithValue("@Codigo", clTblEstado.Codigo);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblEstadoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblEstadoModel.EnumCampos.Id.ToString()), Id);

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

		public TblEstadoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblEstado");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblEstadoModel.EnumCampos.Id.ToString(), TblEstadoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblEstadoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblEstado que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblEstadoModel clTblEstadoModel = new TblEstadoModel();
			clTblEstadoModel.ParseData(tbl.Rows[0]);
			return clTblEstadoModel;
		}

		public List<TblEstadoModel> GetFullTableTblEstado()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblEstado");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblEstadoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblEstadoModel> ltsEstadoModels = new List<TblEstadoModel>();
			ltsEstadoModels = Functions.DataTableHelper.ConvertDataTableToList<TblEstadoModel>(tbl);
			return ltsEstadoModels;
		}
	}
}