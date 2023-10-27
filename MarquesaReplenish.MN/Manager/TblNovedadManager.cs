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
	public partial class TblNovedadManager : ConexionBD
	{
		public int Guardar(TblNovedadModel clTblNovedad)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblNovedadInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@id_Maquina", clTblNovedad.id_Maquina);
			cmd.Parameters.AddWithValue("@Nombre", clTblNovedad.Nombre);
			cmd.Parameters.AddWithValue("@Estado", clTblNovedad.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblNovedadModel clTblNovedad)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblNovedadEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblNovedad.Id);
					cmd.Parameters.AddWithValue("@id_Maquina", clTblNovedad.id_Maquina);
					cmd.Parameters.AddWithValue("@Nombre", clTblNovedad.Nombre);
					cmd.Parameters.AddWithValue("@Estado", clTblNovedad.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblNovedadEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblNovedadModel.EnumCampos.Id.ToString()), Id);

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

		public TblNovedadModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblNovedad");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblNovedadModel.EnumCampos.Id.ToString(), TblNovedadModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblNovedadModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblNovedad que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblNovedadModel clTblNovedadModel = new TblNovedadModel();
			clTblNovedadModel.ParseData(tbl.Rows[0]);
			return clTblNovedadModel;
		}

		public DataTable GetFullTableTblNovedad()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblNovedad");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblNovedadModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public List<TblNovedadModel> GetTableTblNovedadXTblMaquina(int id_Maquina)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblNovedadXTblMaquina");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblNovedadModel.EnumCampos.id_Maquina.ToString(), TblNovedadModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblNovedadModel.EnumCampos.id_Maquina.ToString(), id_Maquina);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblNovedadModel> ltsNovedads = new List<TblNovedadModel>();

			ltsNovedads = Functions.DataTableHelper.ConvertDataTableToList<TblNovedadModel>(tbl);

			return ltsNovedads;
		}

	}
}