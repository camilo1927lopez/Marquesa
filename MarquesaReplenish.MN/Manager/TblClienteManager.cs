/**Generado por ProjectManager versión 1.2.0.0 el día 26-02-2022 17:25:01**/

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
	public partial class TblClienteManager : ConexionBD
	{
		public int Guardar(TblClienteModel clTblCliente)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_Rol", clTblCliente.Id_Rol);
			cmd.Parameters.AddWithValue("@Nit", clTblCliente.Nit);
			cmd.Parameters.AddWithValue("@Nombre", clTblCliente.Nombre);
			cmd.Parameters.AddWithValue("@FechaCreacion", clTblCliente.FechaCreacion);
			cmd.Parameters.AddWithValue("@Estado", clTblCliente.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblClienteModel clTblCliente)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblCliente.Id);
					cmd.Parameters.AddWithValue("@Id_Rol", clTblCliente.Id_Rol);
					cmd.Parameters.AddWithValue("@Nit", clTblCliente.Nit);
					cmd.Parameters.AddWithValue("@Nombre", clTblCliente.Nombre);
					cmd.Parameters.AddWithValue("@FechaCreacion", clTblCliente.FechaCreacion);
					cmd.Parameters.AddWithValue("@Estado", clTblCliente.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblClienteModel.EnumCampos.Id.ToString()), Id);

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

		public TblClienteModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblCliente");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblClienteModel.EnumCampos.Id.ToString(), TblClienteModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblClienteModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblCliente que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblClienteModel clTblClienteModel = new TblClienteModel();
			clTblClienteModel.ParseData(tbl.Rows[0]);
			return clTblClienteModel;
		}

		public List<TblClienteModel> GetFullTableTblCliente()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblCliente");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblClienteModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblClienteModel> TblClienteList = DataTableHelper.ConvertDataTableToList<TblClienteModel>(tbl);

			return TblClienteList;
		}

		public DataTable GetTableTblClienteXTblRol(int Id_Rol)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblClienteXTblRol");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblClienteModel.EnumCampos.Id_Rol.ToString(), TblClienteModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblClienteModel.EnumCampos.Id_Rol.ToString(), Id_Rol);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

	}
}