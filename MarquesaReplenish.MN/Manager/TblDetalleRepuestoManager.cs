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
	public partial class TblDetalleRepuestoManager : ConexionBD
	{
		public int Guardar(TblDetalleRepuestoModel clTblDetalleRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDetalleRepuestoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			//cmd.Parameters.AddWithValue("@Id", clTblDetalleRepuesto.Id);
			cmd.Parameters.AddWithValue("@Id_Repuesto", clTblDetalleRepuesto.Id_Repuesto);
			cmd.Parameters.AddWithValue("@Id_Examinando", clTblDetalleRepuesto.Id_Examinando);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblDetalleRepuestoModel clTblDetalleRepuesto)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDetalleRepuestoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblDetalleRepuesto.Id);
					cmd.Parameters.AddWithValue("@Id_Repuesto", clTblDetalleRepuesto.Id_Repuesto);
					cmd.Parameters.AddWithValue("@Id_Examinando", clTblDetalleRepuesto.Id_Examinando);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDetalleRepuestoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblDetalleRepuestoModel.EnumCampos.Id.ToString()), Id);

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

		public TblDetalleRepuestoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblDetalleRepuestoModel.EnumCampos.Id.ToString(), TblDetalleRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRepuestoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblDetalleRepuesto que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblDetalleRepuestoModel clTblDetalleRepuestoModel = new TblDetalleRepuestoModel();
			clTblDetalleRepuestoModel.ParseData(tbl.Rows[0]);
			return clTblDetalleRepuestoModel;
		}

		public List<TblDetalleRepuestoModel> GetDataXIdRepuesto(int Id_Repuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblDetalleRepuestoModel.EnumCampos.Id_Repuesto.ToString(), TblDetalleRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRepuestoModel.EnumCampos.Id_Repuesto.ToString(), Id_Repuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblDetalleRepuestoModel> ltsDetalleRepuestoModel = new List<TblDetalleRepuestoModel>();

			ltsDetalleRepuestoModel = Functions.DataTableHelper.ConvertDataTableToList<TblDetalleRepuestoModel>(tbl);

			return ltsDetalleRepuestoModel;
		}

		public DataTable GetFullTableTblDetalleRepuesto()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblDetalleRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblDetalleRepuestoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public List<TblDetalleRepuestoModel> GetTableTblDetalleRepuestoXTblExaminando(int Id_Examinando)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRepuestoXTblExaminando");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDetalleRepuestoModel.EnumCampos.Id_Examinando.ToString(), TblDetalleRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRepuestoModel.EnumCampos.Id_Examinando.ToString(), Id_Examinando);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			List<TblDetalleRepuestoModel> ltsDetalleRepuestos = new List<TblDetalleRepuestoModel>();

			ltsDetalleRepuestos = Functions.DataTableHelper.ConvertDataTableToList<TblDetalleRepuestoModel>(tbl);

			return ltsDetalleRepuestos;
		}
		public DataTable GetTableTblDetalleRepuestoXTblRepuesto(int Id_Repuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDetalleRepuestoXTblRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDetalleRepuestoModel.EnumCampos.Id_Repuesto.ToString(), TblDetalleRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDetalleRepuestoModel.EnumCampos.Id_Repuesto.ToString(), Id_Repuesto);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());



			return tbl;
		}

	}
}