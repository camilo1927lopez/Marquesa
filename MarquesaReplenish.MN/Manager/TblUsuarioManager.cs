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
	public partial class TblUsuarioManager : ConexionBD
	{

		public int Guardar(TblUsuarioModel clTblUsuario)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblUsuarioInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_Rol", clTblUsuario.Id_Rol);
			cmd.Parameters.AddWithValue("@Usuario", clTblUsuario.Usuario);
			cmd.Parameters.AddWithValue("@Documento", clTblUsuario.Documento);
			cmd.Parameters.AddWithValue("@NombreApellido", clTblUsuario.NombreApellido);
			cmd.Parameters.AddWithValue("@Clave", clTblUsuario.Clave);
			cmd.Parameters.AddWithValue("@FechaCreacion", clTblUsuario.FechaCreacion);
			cmd.Parameters.AddWithValue("@FechaActualizacion", clTblUsuario.FechaActualizacion);
			cmd.Parameters.AddWithValue("@Estado", clTblUsuario.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblUsuarioModel clTblUsuario)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblUsuarioEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblUsuario.Id);
					cmd.Parameters.AddWithValue("@Id_Rol", clTblUsuario.Id_Rol);
					cmd.Parameters.AddWithValue("@Usuario", clTblUsuario.Usuario);
					cmd.Parameters.AddWithValue("@Documento", clTblUsuario.Documento);
					cmd.Parameters.AddWithValue("@NombreApellido", clTblUsuario.NombreApellido);
					cmd.Parameters.AddWithValue("@Clave", clTblUsuario.Clave);
					cmd.Parameters.AddWithValue("@FechaCreacion", clTblUsuario.FechaCreacion);
					cmd.Parameters.AddWithValue("@FechaActualizacion", clTblUsuario.FechaActualizacion);
					cmd.Parameters.AddWithValue("@Estado", clTblUsuario.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblUsuarioEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblUsuarioModel.EnumCampos.Id.ToString()), Id);

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

		public TblUsuarioModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblUsuario");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblUsuarioModel.EnumCampos.Id.ToString(), TblUsuarioModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblUsuarioModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblUsuario que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblUsuarioModel clTblUsuarioModel = new TblUsuarioModel();
			//clTblUsuarioModel.ParseData(tbl.Rows[0]);
			return clTblUsuarioModel;
		}

		public TblUsuarioModel GetExisteUsuario(TblUsuarioModel tblUsuarioModel)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblUsuarioExisteUsuarioModel");
			cmd.CommandType = CommandType.StoredProcedure;			
			cmd.Parameters.AddWithValue("@" + TblUsuarioModel.EnumCampos.Usuario.ToString(), tblUsuarioModel.Usuario);
			cmd.Parameters.AddWithValue("@" + TblUsuarioModel.EnumCampos.Clave.ToString(), EncriptadoHelper.GetHashSha256(tblUsuarioModel.Clave));

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblUsuario que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblUsuarioModel clTblUsuarioModel = new TblUsuarioModel();

			clTblUsuarioModel = DataTableHelper.ConvertDataTableToList<TblUsuarioModel>(tbl).FirstOrDefault();

			return clTblUsuarioModel;
		}
		public bool GetExisteUsuario(string UsuarioModel)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblUsuarioExisteUsuario");
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.AddWithValue("@" + TblUsuarioModel.EnumCampos.Usuario.ToString(), UsuarioModel);			

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return false;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblUsuario que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			return true;
		}

		public List<TblUsuarioModel> GetFullTableTblUsuario()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblUsuario");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblUsuarioModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}

			List<TblUsuarioModel> ltsUsuarioModels = new List<TblUsuarioModel>();

			ltsUsuarioModels = Functions.DataTableHelper.ConvertDataTableToList<TblUsuarioModel>(tbl);

			return ltsUsuarioModels;
		}

		public DataTable GetTableTblUsuarioXTblRol(int Id_Rol)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblUsuarioXTblRol");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblUsuarioModel.EnumCampos.Id_Rol.ToString(), TblUsuarioModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblUsuarioModel.EnumCampos.Id_Rol.ToString(), Id_Rol);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

	}
}