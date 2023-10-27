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
	public partial class TblImpresoraManager : ConexionBD
	{
		public int Guardar(TblImpresoraModel clTblImpresora)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblImpresoraInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_FormatoSalida", clTblImpresora.Id_FormatoSalida);
			cmd.Parameters.AddWithValue("@Nombre", clTblImpresora.Nombre);
			cmd.Parameters.AddWithValue("@Estado", clTblImpresora.Estado);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblImpresoraModel clTblImpresora)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblImpresoraEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblImpresora.Id);
					cmd.Parameters.AddWithValue("@Id_FormatoSalida", clTblImpresora.Id_FormatoSalida);
					cmd.Parameters.AddWithValue("@Nombre", clTblImpresora.Nombre);
					cmd.Parameters.AddWithValue("@Estado", clTblImpresora.Estado);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblImpresoraEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblImpresoraModel.EnumCampos.Id.ToString()), Id);

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

		public TblImpresoraModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblImpresora");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblImpresoraModel.EnumCampos.Id.ToString(), TblImpresoraModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblImpresoraModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblImpresora que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblImpresoraModel clTblImpresoraModel = new TblImpresoraModel();
			clTblImpresoraModel.ParseData(tbl.Rows[0]);
			return clTblImpresoraModel;
		}

		public DataTable GetFullTableTblImpresora()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblImpresora");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblImpresoraModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public List<TblImpresoraModel> GetTableTblImpresoraXTblFormatoSalida(int Id_FormatoSalida)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblImpresoraXTblFormatoSalida");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblImpresoraModel.EnumCampos.Id_FormatoSalida.ToString(), TblImpresoraModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblImpresoraModel.EnumCampos.Id_FormatoSalida.ToString(), Id_FormatoSalida);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblImpresoraModel> ltsImpresoras = new List<TblImpresoraModel>();

			ltsImpresoras = Functions.DataTableHelper.ConvertDataTableToList<TblImpresoraModel>(tbl);

			return ltsImpresoras;
		}

	}
}