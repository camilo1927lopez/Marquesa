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
	public partial class TblDescripcionRepuestoManager : ConexionBD
	{
		public int Guardar(TblDescripcionRepuestoModel clTblDescripcionRepuesto)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDescripcionRepuestoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id_Impresora", clTblDescripcionRepuesto.Id_Impresora);
			cmd.Parameters.AddWithValue("@Id_novedad", clTblDescripcionRepuesto.Id_novedad);
			cmd.Parameters.AddWithValue("@Id_tipoImpresion", clTblDescripcionRepuesto.Id_tipoImpresion);
			cmd.Parameters.AddWithValue("@TipoPapel", clTblDescripcionRepuesto.TipoPapel);
			cmd.Parameters.AddWithValue("@Resolucion", clTblDescripcionRepuesto.Resolucion);
			cmd.Parameters.AddWithValue("@ImprimirPor", clTblDescripcionRepuesto.ImprimirPor);
			cmd.Parameters.AddWithValue("@rangoMaxRepuesto", clTblDescripcionRepuesto.rangoMaxRepuesto);
			cmd.Parameters.AddWithValue("@FechaCreacion", clTblDescripcionRepuesto.FechaCreacion);
			cmd.Parameters.AddWithValue("@Usuario", clTblDescripcionRepuesto.Usuario);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Editar(TblDescripcionRepuestoModel clTblDescripcionRepuesto)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDescripcionRepuestoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblDescripcionRepuesto.Id);
					cmd.Parameters.AddWithValue("@Id_Impresora", clTblDescripcionRepuesto.Id_Impresora);
					cmd.Parameters.AddWithValue("@Id_novedad", clTblDescripcionRepuesto.Id_novedad);
					cmd.Parameters.AddWithValue("@Id_tipoImpresion", clTblDescripcionRepuesto.Id_tipoImpresion);
					cmd.Parameters.AddWithValue("@TipoPapel", clTblDescripcionRepuesto.TipoPapel);
					cmd.Parameters.AddWithValue("@Resolucion", clTblDescripcionRepuesto.Resolucion);
					cmd.Parameters.AddWithValue("@ImprimirPor", clTblDescripcionRepuesto.ImprimirPor);
					cmd.Parameters.AddWithValue("@rangoMaxRepuesto", clTblDescripcionRepuesto.rangoMaxRepuesto);
					cmd.Parameters.AddWithValue("@FechaCreacion", clTblDescripcionRepuesto.FechaCreacion);
					cmd.Parameters.AddWithValue("@Usuario", clTblDescripcionRepuesto.Usuario);

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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblDescripcionRepuestoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblDescripcionRepuestoModel.EnumCampos.Id.ToString()), Id);

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

		public TblDescripcionRepuestoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDescripcionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblDescripcionRepuestoModel.EnumCampos.Id.ToString(), TblDescripcionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDescripcionRepuestoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblDescripcionRepuesto que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblDescripcionRepuestoModel clTblDescripcionRepuestoModel = new TblDescripcionRepuestoModel();
			clTblDescripcionRepuestoModel.ParseData(tbl.Rows[0]);
			return clTblDescripcionRepuestoModel;
		}

		public DataTable GetFullTableTblDescripcionRepuesto()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblDescripcionRepuesto");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblDescripcionRepuestoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public DataTable GetTableTblDescripcionRepuestoXTblImpresora(int Id_Impresora)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDescripcionRepuestoXTblImpresora");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDescripcionRepuestoModel.EnumCampos.Id_Impresora.ToString(), TblDescripcionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDescripcionRepuestoModel.EnumCampos.Id_Impresora.ToString(), Id_Impresora);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}


		public DataTable GetTableTblDescripcionRepuestoXTblNovedad(int Id_novedad)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDescripcionRepuestoXTblNovedad");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDescripcionRepuestoModel.EnumCampos.Id_novedad.ToString(), TblDescripcionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDescripcionRepuestoModel.EnumCampos.Id_novedad.ToString(), Id_novedad);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}


		public DataTable GetTableTblDescripcionRepuestoXTblTipoImpresion(int Id_tipoImpresion)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblDescripcionRepuestoXTblTipoImpresion");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblDescripcionRepuestoModel.EnumCampos.Id_tipoImpresion.ToString(), TblDescripcionRepuestoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblDescripcionRepuestoModel.EnumCampos.Id_tipoImpresion.ToString(), Id_tipoImpresion);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

	}
}