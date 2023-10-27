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
	public partial class TblTipoImpresionManager : ConexionBD
	{
		public int Guardar(TblTipoImpresionModel clTblTipoImpresion)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblTipoImpresionInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Nombre", clTblTipoImpresion.Nombre);
			cmd.Parameters.AddWithValue("@Estado", clTblTipoImpresion.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblTipoImpresionModel clTblTipoImpresion)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblTipoImpresionEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblTipoImpresion.Id);
					cmd.Parameters.AddWithValue("@Nombre", clTblTipoImpresion.Nombre);
					cmd.Parameters.AddWithValue("@Estado", clTblTipoImpresion.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblTipoImpresionEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblTipoImpresionModel.EnumCampos.Id.ToString()), Id);

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

		public TblTipoImpresionModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblTipoImpresion");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblTipoImpresionModel.EnumCampos.Id.ToString(), TblTipoImpresionModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblTipoImpresionModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblTipoImpresion que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblTipoImpresionModel clTblTipoImpresionModel = new TblTipoImpresionModel();
			clTblTipoImpresionModel.ParseData(tbl.Rows[0]);
			return clTblTipoImpresionModel;
		}

		public List<TblTipoImpresionModel> GetFullTableTblTipoImpresion()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblTipoImpresion");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblTipoImpresionModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblTipoImpresionModel> ltsTipoImpresions = new List<TblTipoImpresionModel>();

			ltsTipoImpresions = Functions.DataTableHelper.ConvertDataTableToList<TblTipoImpresionModel>(tbl);

			return ltsTipoImpresions;
		}
	}
}