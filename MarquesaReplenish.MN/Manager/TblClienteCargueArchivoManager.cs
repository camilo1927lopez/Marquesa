/**Generado por ProjectManager versión 1.2.0.0 el día 26-02-2022 17:25:01**/

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
	public partial class TblClienteCargueArchivoManager : ConexionBD
	{
		public int Guardar(TblClienteCargueArchivoModel clTblClienteCargueArchivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteCargueArchivoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			//cmd.Parameters.AddWithValue("@Id", clTblClienteCargueArchivo.Id);
			cmd.Parameters.AddWithValue("@Id_Cliente", clTblClienteCargueArchivo.Id_Cliente);
			cmd.Parameters.AddWithValue("@Id_CargueArchivo", clTblClienteCargueArchivo.Id_CargueArchivo);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblClienteCargueArchivoModel clTblClienteCargueArchivo)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteCargueArchivoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblClienteCargueArchivo.Id);
					cmd.Parameters.AddWithValue("@Id_Cliente", clTblClienteCargueArchivo.Id_Cliente);
					cmd.Parameters.AddWithValue("@Id_CargueArchivo", clTblClienteCargueArchivo.Id_CargueArchivo);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteCargueArchivoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblClienteCargueArchivoModel.EnumCampos.Id.ToString()), Id);

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

		public int EliminarIdCargue(int Id_CargueArchivo)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblClienteCargueArchivoEliminarxIdCargueArchivo"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblClienteCargueArchivoModel.EnumCampos.Id_CargueArchivo.ToString()), Id_CargueArchivo);

					SqlParameter param = new SqlParameter("@Cont", System.Data.SqlDbType.Int);
					param.Direction = System.Data.ParameterDirection.ReturnValue;
					cmd.Parameters.Add(param);
					cmd.ExecuteNonQuery();

					return Convert.ToInt32(param.Value);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public TblClienteCargueArchivoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblClienteCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblClienteCargueArchivoModel.EnumCampos.Id.ToString(), TblClienteCargueArchivoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblClienteCargueArchivoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblClienteCargueArchivo que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblClienteCargueArchivoModel clTblClienteCargueArchivoModel = new TblClienteCargueArchivoModel();
			clTblClienteCargueArchivoModel.ParseData(tbl.Rows[0]);
			return clTblClienteCargueArchivoModel;
		}

		public DataTable GetFullTableTblClienteCargueArchivo()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblClienteCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblClienteCargueArchivoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public DataTable GetTableTblClienteCargueArchivoXTblCargueArchivo(int Id_CargueArchivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblClienteCargueArchivoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblClienteCargueArchivoModel.EnumCampos.Id_CargueArchivo.ToString(), TblClienteCargueArchivoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblClienteCargueArchivoModel.EnumCampos.Id_CargueArchivo.ToString(), Id_CargueArchivo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}


		public List<TblClienteCargueArchivoModel> GetTableTblClienteCargueArchivoXTblCliente(int Id_Cliente)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblClienteCargueArchivoXTblCliente");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblClienteCargueArchivoModel.EnumCampos.Id_Cliente.ToString(), TblClienteCargueArchivoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblClienteCargueArchivoModel.EnumCampos.Id_Cliente.ToString(), Id_Cliente);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}

			List<TblClienteCargueArchivoModel> ltsTblClienteCargueArchivoModel = Functions.DataTableHelper.ConvertDataTableToList<TblClienteCargueArchivoModel>(tbl);

			return ltsTblClienteCargueArchivoModel;
		}

	}
}