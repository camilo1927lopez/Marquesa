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
	public partial class TblParteCicloManager : ConexionBD
	{
		public int Guardar(TblParteCicloModel clTblParteCiclo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblParteCicloInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_configuracionRepuesto", clTblParteCiclo.Id_configuracionRepuesto);
			cmd.Parameters.AddWithValue("@NumeroParte", clTblParteCiclo.NumeroParte);
			cmd.Parameters.AddWithValue("@RangoInical", clTblParteCiclo.RangoInical);
			cmd.Parameters.AddWithValue("@RangoFinal", clTblParteCiclo.RangoFinal);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblParteCicloModel clTblParteCiclo)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblParteCicloEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblParteCiclo.Id);
					cmd.Parameters.AddWithValue("@Id_configuracionRepuesto", clTblParteCiclo.Id_configuracionRepuesto);
					cmd.Parameters.AddWithValue("@NumeroParte", clTblParteCiclo.NumeroParte);
					cmd.Parameters.AddWithValue("@RangoInical", clTblParteCiclo.RangoInical);
					cmd.Parameters.AddWithValue("@RangoFinal", clTblParteCiclo.RangoFinal);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblParteCicloEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblParteCicloModel.EnumCampos.Id.ToString()), Id);

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

		public int EliminarIdConfiguracionRepuesto(int Id_configuracionRepuesto)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblParteCicloEliminarXIdConfiguracionRepuesto"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblParteCicloModel.EnumCampos.Id_configuracionRepuesto.ToString()), Id_configuracionRepuesto);

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

		public TblParteCicloModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblParteCiclo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblParteCicloModel.EnumCampos.Id.ToString(), TblParteCicloModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblParteCicloModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblParteCiclo que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblParteCicloModel clTblParteCicloModel = new TblParteCicloModel();
			clTblParteCicloModel.ParseData(tbl.Rows[0]);
			return clTblParteCicloModel;
		}

		public DataTable GetFullTableTblParteCiclo()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblParteCiclo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblParteCicloModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public List<TblParteCicloModel> GetTableTblParteCicloXTblConfiguracionRepuesto(int Id_configuracionRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblParteCicloXTblConfiguracionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblParteCicloModel.EnumCampos.Id_configuracionRepuesto.ToString(), TblParteCicloModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblParteCicloModel.EnumCampos.Id_configuracionRepuesto.ToString(), Id_configuracionRepuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblParteCicloModel> ltsParteCicloModels = new List<TblParteCicloModel>();

			ltsParteCicloModels = Functions.DataTableHelper.ConvertDataTableToList<TblParteCicloModel>(tbl);

			return ltsParteCicloModels;
		}

	}
}