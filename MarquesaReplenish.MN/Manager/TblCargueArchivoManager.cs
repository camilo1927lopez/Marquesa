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
	public partial class TblCargueArchivoManager : ConexionBD
	{
		public int Guardar(TblCargueArchivoModel clTblCargueArchivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblCargueArchivoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@NombreBibliaImpresion", clTblCargueArchivo.NombreBibliaImpresion);
			cmd.Parameters.AddWithValue("@NombreBibliaDistribucion", clTblCargueArchivo.NombreBibliaDistribucion);
			cmd.Parameters.AddWithValue("@NombreCarguePrueba", clTblCargueArchivo.NombreCarguePrueba);
			cmd.Parameters.AddWithValue("@FechaCargue", clTblCargueArchivo.FechaCargue);
			cmd.Parameters.AddWithValue("@UsuarioCreacion", clTblCargueArchivo.UsuarioCreacion);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblCargueArchivoModel clTblCargueArchivo)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblCargueArchivoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblCargueArchivo.Id);
					cmd.Parameters.AddWithValue("@NombreBibliaImpresion", clTblCargueArchivo.NombreBibliaImpresion);
					cmd.Parameters.AddWithValue("@NombreBibliaDistribucion", clTblCargueArchivo.NombreBibliaDistribucion);
					cmd.Parameters.AddWithValue("@NombreCarguePrueba", clTblCargueArchivo.NombreCarguePrueba);
					cmd.Parameters.AddWithValue("@FechaCargue", clTblCargueArchivo.FechaCargue);
					cmd.Parameters.AddWithValue("@UsuarioCreacion", clTblCargueArchivo.UsuarioCreacion);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblCargueArchivoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblCargueArchivoModel.EnumCampos.Id.ToString()), Id);

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

		public TblCargueArchivoModel GetData(int Id)
		{
            try
            {
				if (!this.EsConexionValida())
				{
					throw new Exception("La conexión no está lista o no es válida");
				}

				SqlCommand cmd = GetCommand("GetDataTblCargueArchivo");
				cmd.CommandType = System.Data.CommandType.Text;
				cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblCargueArchivoModel.EnumCampos.Id.ToString(), TblCargueArchivoModel.NOMBRE_TABLA);
				cmd.Parameters.AddWithValue("@" + TblCargueArchivoModel.EnumCampos.Id.ToString(), Id);
				cmd.CommandTimeout = 100;

				DataTable tbl = new DataTable();
				tbl.Load(cmd.ExecuteReader());

				if (tbl.Rows.Count == 0)
				{
					return null;
				}
				if (tbl.Rows.Count != 1)
				{
					throw new Exception(string.Format("Se encontró {0} registros de tblCargueArchivo que concuerdan con la búsqueda.", tbl.Rows.Count));
				}

				TblCargueArchivoModel clTblCargueArchivoModel = new TblCargueArchivoModel();

				clTblCargueArchivoModel = Functions.DataTableHelper.ConvertDataTableToList<TblCargueArchivoModel>(tbl).FirstOrDefault();

				//clTblCargueArchivoModel.ParseData(tbl.Rows[0]);
				return clTblCargueArchivoModel;
			}
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
	
		}

		public List<TblCargueArchivoModel> GetFullDataXExaminando()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT ca.*, (select {4} from {5} where {0} = ca.{0}) as Id_Cliente FROM {1} ca WHERE(select COUNT({2}) from {3} where {2} = ca.{0}) > 0 order by ca.{0}; ", TblCargueArchivoModel.EnumCampos.Id.ToString(), TblCargueArchivoModel.NOMBRE_TABLA, TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), TblExaminandoModel.NOMBRE_TABLA, TblClienteCargueArchivoModel.EnumCampos.Id_Cliente.ToString(), TblClienteCargueArchivoModel.NOMBRE_TABLA);
			//cmd.Parameters.AddWithValue("@" + TblCargueArchivoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}

			List<TblCargueArchivoModel>  ltsCargueArchivoModel = new List<TblCargueArchivoModel>();
			ltsCargueArchivoModel = Functions.DataTableHelper.ConvertDataTableToList<TblCargueArchivoModel>(tbl);
			return ltsCargueArchivoModel;
		}

		public TblCargueArchivoModel GetExisteCargueData(int Id_Cliente, string NombreCarguePrueba)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblCargueArchivoExite");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;
			//cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblCargueArchivoModel.EnumCampos.Id.ToString(), TblCargueArchivoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblCargueArchivoModel.EnumCampos.NombreCarguePrueba.ToString(), NombreCarguePrueba);
			cmd.Parameters.AddWithValue("@" + TblClienteCargueArchivoModel.EnumCampos.Id_Cliente.ToString(), Id_Cliente);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblCargueArchivo que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblCargueArchivoModel tblCargueArchivoModel = new TblCargueArchivoModel();
			tblCargueArchivoModel = Functions.DataTableHelper.ConvertDataTableToList<TblCargueArchivoModel>(tbl).FirstOrDefault();
			return tblCargueArchivoModel;
		}

		public DataTable GetFullTableTblCargueArchivo()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblCargueArchivoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}
	}
}