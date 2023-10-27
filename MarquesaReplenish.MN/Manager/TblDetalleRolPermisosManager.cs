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
	public partial class TblDetalleRolPermisosManager : ConexionBD
	{
		public int Guardar(TblDetalleRolPermisosModel clTblDetalleRolPermisos)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDetalleRolPermisosInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_Permisos", clTblDetalleRolPermisos.Id_Permisos);
			cmd.Parameters.AddWithValue("@Id_Rol", clTblDetalleRolPermisos.Id_Rol);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblDetalleRolPermisosModel clTblDetalleRolPermisos)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDetalleRolPermisosEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblDetalleRolPermisos.Id);
					cmd.Parameters.AddWithValue("@Id_Permisos", clTblDetalleRolPermisos.Id_Permisos);
					cmd.Parameters.AddWithValue("@Id_Rol", clTblDetalleRolPermisos.Id_Rol);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDetalleRolPermisosEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblDetalleRolPermisosModel.EnumCampos.Id.ToString()), Id);

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

		public TblDetalleRolPermisosModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRolPermisos");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblDetalleRolPermisosModel.EnumCampos.Id.ToString(), TblDetalleRolPermisosModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRolPermisosModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblDetalleRolPermisos que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblDetalleRolPermisosModel clTblDetalleRolPermisosModel = new TblDetalleRolPermisosModel();
			clTblDetalleRolPermisosModel.ParseData(tbl.Rows[0]);
			return clTblDetalleRolPermisosModel;
		}

		public DataTable GetFullTableTblDetalleRolPermisos()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblDetalleRolPermisos");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblDetalleRolPermisosModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public DataTable GetTableTblDetalleRolPermisosXTblPermisos(int Id_Permisos)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRolPermisosXTblPermisos");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDetalleRolPermisosModel.EnumCampos.Id_Permisos.ToString(), TblDetalleRolPermisosModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRolPermisosModel.EnumCampos.Id_Permisos.ToString(), Id_Permisos);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}


		public List<TblDetalleRolPermisosModel> GetTableTblDetalleRolPermisosXTblRol(int Id_Rol)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRolPermisosXTblRol");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDetalleRolPermisosModel.EnumCampos.Id_Rol.ToString(), TblDetalleRolPermisosModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRolPermisosModel.EnumCampos.Id_Rol.ToString(), Id_Rol);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}

			List<TblDetalleRolPermisosModel> listDetalleRolPermisos = new List<TblDetalleRolPermisosModel>();
			listDetalleRolPermisos = Functions.DataTableHelper.ConvertDataTableToList<TblDetalleRolPermisosModel>(tbl);
			return listDetalleRolPermisos;
		}

	}
}