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
	public partial class TblFormatoSalidaManager : ConexionBD
	{
		public int Guardar(TblFormatoSalidaModel clTblFormatoSalida)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblFormatoSalidaInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Nombre", clTblFormatoSalida.Nombre);
			cmd.Parameters.AddWithValue("@Estado", clTblFormatoSalida.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblFormatoSalidaModel clTblFormatoSalida)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblFormatoSalidaEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblFormatoSalida.Id);
					cmd.Parameters.AddWithValue("@Nombre", clTblFormatoSalida.Nombre);
					cmd.Parameters.AddWithValue("@Estado", clTblFormatoSalida.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblFormatoSalidaEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblFormatoSalidaModel.EnumCampos.Id.ToString()), Id);

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

		public TblFormatoSalidaModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblFormatoSalida");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblFormatoSalidaModel.EnumCampos.Id.ToString(), TblFormatoSalidaModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblFormatoSalidaModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblFormatoSalida que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblFormatoSalidaModel clTblFormatoSalidaModel = new TblFormatoSalidaModel();
			clTblFormatoSalidaModel.ParseData(tbl.Rows[0]);
			return clTblFormatoSalidaModel;
		}

		public List<TblFormatoSalidaModel> GetFullTableTblFormatoSalida()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblFormatoSalida");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblFormatoSalidaModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblFormatoSalidaModel> ltsFormatoSalidas = new List<TblFormatoSalidaModel>();

			ltsFormatoSalidas = Functions.DataTableHelper.ConvertDataTableToList<TblFormatoSalidaModel>(tbl);


			return ltsFormatoSalidas;
		}
	}
}