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
	public partial class TblRepuestoManager : ConexionBD
	{
		public int Guardar(TblRepuestoModel clTblRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblRepuestoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_ConfiguracionRepuesto", clTblRepuesto.Id_ConfiguracionRepuesto);
			cmd.Parameters.AddWithValue("@Id_DescripcionRepuesto", clTblRepuesto.Id_DescripcionRepuesto);
			cmd.Parameters.AddWithValue("@Rango", clTblRepuesto.Rango);
			cmd.Parameters.AddWithValue("@FechaIngreso", clTblRepuesto.FechaIngreso);
			cmd.Parameters.AddWithValue("@FechaInactivo", clTblRepuesto.FechaInactivo);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblRepuestoModel clTblRepuesto)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblRepuestoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblRepuesto.Id);
					cmd.Parameters.AddWithValue("@Id_ConfiguracionRepuesto", clTblRepuesto.Id_ConfiguracionRepuesto);
					cmd.Parameters.AddWithValue("@Id_DescripcionRepuesto", clTblRepuesto.Id_DescripcionRepuesto);
					cmd.Parameters.AddWithValue("@Rango", clTblRepuesto.Rango);
					cmd.Parameters.AddWithValue("@FechaIngreso", clTblRepuesto.FechaIngreso);
					cmd.Parameters.AddWithValue("@FechaInactivo", clTblRepuesto.FechaInactivo);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblRepuestoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblRepuestoModel.EnumCampos.Id.ToString()), Id);

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

		public TblRepuestoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblRepuestoModel.EnumCampos.Id.ToString(), TblRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblRepuestoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblRepuesto que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblRepuestoModel clTblRepuestoModel = new TblRepuestoModel();
			clTblRepuestoModel.ParseData(tbl.Rows[0]);
			return clTblRepuestoModel;
		}

		public List<TblRepuestoModel> GetDataXIdConfiguracionRepuesto(int Id_ConfiguracionRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), TblRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), Id_ConfiguracionRepuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblRepuestoModel> ltsRepuestoModel = new List<TblRepuestoModel>();
			ltsRepuestoModel = Functions.DataTableHelper.ConvertDataTableToList<TblRepuestoModel>(tbl);

			return ltsRepuestoModel;
		}

		public DataTable GetFullTableTblRepuesto()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblRepuestoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public DataTable GetTableTblRepuestoXTblConfiguracionRepuesto(int Id_ConfiguracionRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblRepuestoXTblConfiguracionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), TblRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblRepuestoModel.EnumCampos.Id_ConfiguracionRepuesto.ToString(), Id_ConfiguracionRepuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}


		public DataTable GetTableTblRepuestoXTblDescripcionRepuesto(int Id_DescripcionRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblRepuestoXTblDescripcionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblRepuestoModel.EnumCampos.Id_DescripcionRepuesto.ToString(), TblRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblRepuestoModel.EnumCampos.Id_DescripcionRepuesto.ToString(), Id_DescripcionRepuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

	}
}