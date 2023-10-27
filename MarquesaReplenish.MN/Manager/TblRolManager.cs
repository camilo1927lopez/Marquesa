/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BDManager;
using System.Data.SqlClient;
using System.Data;
using MarquesaReplenish.PD.Model;
using Functions;

namespace MarquesaReplenish.MN.Manager
{
	public partial class TblRolManager : ConexionBD
	{
		public int Guardar(TblRolModel clTblRol)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblRolInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Nombre", clTblRol.Nombre);
			cmd.Parameters.AddWithValue("@Estado", clTblRol.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblRolModel clTblRol)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblRolEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblRol.Id);
					cmd.Parameters.AddWithValue("@Nombre", clTblRol.Nombre);
					cmd.Parameters.AddWithValue("@Estado", clTblRol.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblRolEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblRolModel.EnumCampos.Id.ToString()), Id);

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

		public TblRolModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblRol");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblRolModel.EnumCampos.Id.ToString(), TblRolModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblRolModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblRol que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblRolModel clTblRolModel = new TblRolModel();
			clTblRolModel = DataTableHelper.ConvertDataTableToList<TblRolModel>(tbl).FirstOrDefault();
			return clTblRolModel;
		}

		public TblRolModel GetRolCodigo(string codigo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblRol");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblRolModel.EnumCampos.Codigo.ToString(), TblRolModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblRolModel.EnumCampos.Codigo.ToString(), codigo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblRol que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblRolModel clTblRolModel = new TblRolModel();
			clTblRolModel = DataTableHelper.ConvertDataTableToList<TblRolModel>(tbl).FirstOrDefault();
			return clTblRolModel;
		}

		public List<TblRolModel> GetFullTableTblRol()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblRol");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblRolModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblRolModel> TblRolList = DataTableHelper.ConvertDataTableToList<TblRolModel>(tbl);

			return TblRolList;
		}
	}
}