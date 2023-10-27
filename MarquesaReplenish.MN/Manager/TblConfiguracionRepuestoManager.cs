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
	public partial class TblConfiguracionRepuestoManager : ConexionBD
	{
		public int Guardar(TblConfiguracionRepuestoModel clTblConfiguracionRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblConfiguracionRepuestoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@id_CargueArchivo", clTblConfiguracionRepuesto.id_CargueArchivo);
			cmd.Parameters.AddWithValue("@Ciclo", clTblConfiguracionRepuesto.Ciclo);
			cmd.Parameters.AddWithValue("@NombrePruebaCondorPrint", clTblConfiguracionRepuesto.NombrePruebaCondorPrint);
			cmd.Parameters.AddWithValue("@UsuarioCreacion", clTblConfiguracionRepuesto.UsuarioCreacion);
			cmd.Parameters.AddWithValue("@FechaCreacion", clTblConfiguracionRepuesto.FechaCreacion);

			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblConfiguracionRepuestoModel clTblConfiguracionRepuesto)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblConfiguracionRepuestoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblConfiguracionRepuesto.Id);
					cmd.Parameters.AddWithValue("@id_CargueArchivo", clTblConfiguracionRepuesto.id_CargueArchivo);
					cmd.Parameters.AddWithValue("@Ciclo", clTblConfiguracionRepuesto.Ciclo);
					cmd.Parameters.AddWithValue("@NombrePruebaCondorPrint", clTblConfiguracionRepuesto.NombrePruebaCondorPrint);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblConfiguracionRepuestoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblConfiguracionRepuestoModel.EnumCampos.Id.ToString()), Id);

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

		public int EliminarIdCargue(int id_CargueArchivo)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblConfiguracionRepuestoEliminarXidCargueArchivo"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString()), id_CargueArchivo);

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

		public TblConfiguracionRepuestoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblConfiguracionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblConfiguracionRepuestoModel.EnumCampos.Id.ToString(), TblConfiguracionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblConfiguracionRepuestoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblConfiguracionRepuesto que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblConfiguracionRepuestoModel clTblConfiguracionRepuestoModel = new TblConfiguracionRepuestoModel();
			clTblConfiguracionRepuestoModel.ParseData(tbl.Rows[0]);
			return clTblConfiguracionRepuestoModel;
		}


		public List<TblConfiguracionRepuestoModel> GetDataXIdCargue(int id_CargueArchivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblConfiguracionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), TblConfiguracionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblConfiguracionRepuestoModel> ltsConfiguracionRepuestoModel = new List<TblConfiguracionRepuestoModel>();

			ltsConfiguracionRepuestoModel = Functions.DataTableHelper.ConvertDataTableToList<TblConfiguracionRepuestoModel>(tbl);

			return ltsConfiguracionRepuestoModel;
		}

		public DataTable GetFullTableTblConfiguracionRepuesto()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblConfiguracionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblConfiguracionRepuestoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public List<TblConfiguracionRepuestoModel> GetTableTblConfiguracionRepuestoXTblCargueArchivo(int id_CargueArchivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblConfiguracionRepuestoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), TblConfiguracionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblConfiguracionRepuestoModel> ltsConfiguracionRepuesto = new List<TblConfiguracionRepuestoModel>();

			ltsConfiguracionRepuesto = Functions.DataTableHelper.ConvertDataTableToList<TblConfiguracionRepuestoModel>(tbl);

			return ltsConfiguracionRepuesto;
		}

		public List<TblConfiguracionRepuestoModel> GetTableTblConfiguracionRepuestoXTblCargueArchivo(int id_CargueArchivo, string Ciclo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblConfiguracionRepuestoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0} and {2}=@{2};", TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), TblConfiguracionRepuestoModel.NOMBRE_TABLA, TblConfiguracionRepuestoModel.EnumCampos.Ciclo.ToString());
			cmd.Parameters.AddWithValue("@" + TblConfiguracionRepuestoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);
			cmd.Parameters.AddWithValue("@" + TblConfiguracionRepuestoModel.EnumCampos.Ciclo.ToString(), Ciclo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			List <TblConfiguracionRepuestoModel> ltsConfiguracionRepuesto = new List<TblConfiguracionRepuestoModel>();

			ltsConfiguracionRepuesto = Functions.DataTableHelper.ConvertDataTableToList<TblConfiguracionRepuestoModel>(tbl);

			return ltsConfiguracionRepuesto;
		}

	}
}