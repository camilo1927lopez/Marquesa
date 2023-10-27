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
	public partial class TblExaminandoManager : ConexionBD
	{
		public int Guardar(TblExaminandoModel clTblExaminando)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblExaminandoInsertar");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			cmd.Parameters.AddWithValue("@Id", clTblExaminando.Id);
			cmd.Parameters.AddWithValue("@id_CargueArchivo", clTblExaminando.id_CargueArchivo);
			cmd.Parameters.AddWithValue("@NombrePrueba", clTblExaminando.NombrePrueba);
			cmd.Parameters.AddWithValue("@NombreDepartamento", clTblExaminando.NombreDepartamento);
			cmd.Parameters.AddWithValue("@NodigoMunicipio", clTblExaminando.CodigoMunicipio);
			cmd.Parameters.AddWithValue("@FechaAplicacion", clTblExaminando.FechaAplicacion);
			cmd.Parameters.AddWithValue("@NombreMunicipio", clTblExaminando.NombreMunicipio);
			cmd.Parameters.AddWithValue("@CodigoSitio", clTblExaminando.CodigoSitio);
			cmd.Parameters.AddWithValue("@NombreSitio", clTblExaminando.NombreSitio);
			cmd.Parameters.AddWithValue("@CodigoSalon", clTblExaminando.CodigoSalon);
			cmd.Parameters.AddWithValue("@Bloque", clTblExaminando.Bloque);
			cmd.Parameters.AddWithValue("@NombreSalon", clTblExaminando.NombreSalon);
			cmd.Parameters.AddWithValue("@Sesion", clTblExaminando.Sesion);
			cmd.Parameters.AddWithValue("@Registro", clTblExaminando.Registro);
			cmd.Parameters.AddWithValue("@Nombre1", clTblExaminando.Nombre1);
			cmd.Parameters.AddWithValue("@Nombre2", clTblExaminando.Nombre2);
			cmd.Parameters.AddWithValue("@Apellido1", clTblExaminando.Apellido1);
			cmd.Parameters.AddWithValue("@Apellido2", clTblExaminando.Apellido2);
			cmd.Parameters.AddWithValue("@Documento", clTblExaminando.Documento);
			cmd.Parameters.AddWithValue("@Forma", clTblExaminando.Forma);
			cmd.Parameters.AddWithValue("@TipoHR", clTblExaminando.TipoHR);
			cmd.Parameters.AddWithValue("@ConsecutivoControl", clTblExaminando.ConsecutivoControl);
			cmd.Parameters.AddWithValue("@CodigoCuadernillo", clTblExaminando.CodigoCuadernillo);
			cmd.Parameters.AddWithValue("@CodigoHojaRespuesta", clTblExaminando.CodigoHojaRespuesta);
			cmd.Parameters.AddWithValue("@IdConsecutivo", clTblExaminando.IdConsecutivo);
			cmd.Parameters.AddWithValue("@CodigoActa", clTblExaminando.CodigoActa);
			cmd.Parameters.AddWithValue("@Contenedor", clTblExaminando.Contenedor);


			SqlParameter param = new SqlParameter("@Id", System.Data.SqlDbType.Int);
			param.Direction = System.Data.ParameterDirection.ReturnValue;
			cmd.Parameters.Add(param);

			cmd.ExecuteNonQuery();

			return Convert.ToInt32(param.Value);
		}

		public bool Guardar(DataTable clTblExaminando)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

            if (clTblExaminando.Columns["Id"] != null)
				clTblExaminando.Columns.Remove("Id");

			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblExaminandoInsertarTemp");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;		

			SqlParameter param = cmd.Parameters.AddWithValue("@TVP_tblExaminando", clTblExaminando);
			param.SqlDbType = SqlDbType.Structured;
			//param.Direction = System.Data.ParameterDirection.ReturnValue;
			//cmd.Parameters.Add(param);
			cmd.CommandTimeout = 200;
			cmd.ExecuteNonQuery();

			return true;
		}

		public bool GuardarBulkCopy(DataTable clTblExaminando)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
            if (_tx != null)
				_tx = null;

			SqlBulkCopy objbulk = new SqlBulkCopy(_conex);
			objbulk.DestinationTableName = TblExaminandoModel.NOMBRE_TABLA;
			objbulk.BulkCopyTimeout = 100;

			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.id_CargueArchivo.ToString(), TblExaminandoModel.EnumCamposBDGeneral.id_CargueArchivo.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.NombrePrueba.ToString(), TblExaminandoModel.EnumCamposBDGeneral.NombrePrueba.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.FechaAplicacion.ToString(), TblExaminandoModel.EnumCamposBDGeneral.FechaAplicacion.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.NombreDepartamento.ToString(), TblExaminandoModel.EnumCamposBDGeneral.NombreDepartamento.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.CodigoMunicipio.ToString(), TblExaminandoModel.EnumCamposBDGeneral.CodigoMunicipio.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.NombreMunicipio.ToString(), TblExaminandoModel.EnumCamposBDGeneral.NombreMunicipio.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.CodigoSitio.ToString(), TblExaminandoModel.EnumCamposBDGeneral.CodigoSitio.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.NombreSitio.ToString(), TblExaminandoModel.EnumCamposBDGeneral.NombreSitio.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.DireccionSitio.ToString(), TblExaminandoModel.EnumCamposBDGeneral.DireccionSitio.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.CodigoSalon.ToString(), TblExaminandoModel.EnumCamposBDGeneral.CodigoSalon.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.NombreSalon.ToString(), TblExaminandoModel.EnumCamposBDGeneral.NombreSalon.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Sesion.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Sesion.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Bloque.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Bloque.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.ConsecutivoControl.ToString(), TblExaminandoModel.EnumCamposBDGeneral.ConsecutivoControl.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.CodigoCuadernillo.ToString(), TblExaminandoModel.EnumCamposBDGeneral.CodigoCuadernillo.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.CodigoHojaRespuesta.ToString(), TblExaminandoModel.EnumCamposBDGeneral.CodigoHojaRespuesta.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.IdConsecutivo.ToString(), TblExaminandoModel.EnumCamposBDGeneral.IdConsecutivo.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.CodigoActa.ToString(), TblExaminandoModel.EnumCamposBDGeneral.CodigoActa.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Registro.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Registro.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Nombre1.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Nombre1.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Nombre2.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Nombre2.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Apellido1.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Apellido1.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Apellido2.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Apellido2.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Documento.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Documento.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.Forma.ToString(), TblExaminandoModel.EnumCamposBDGeneral.Forma.ToString());
			objbulk.ColumnMappings.Add(TblExaminandoModel.EnumCamposBDGeneral.TipoHR.ToString(), TblExaminandoModel.EnumCamposBDGeneral.TipoHR.ToString());


			objbulk.WriteToServer(clTblExaminando);

			return true;
		}

		public bool Editar(DataTable clTblExaminando)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}
			SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblExaminandoModificarTemp");
			cmd.CommandType = System.Data.CommandType.StoredProcedure;

			SqlParameter param = cmd.Parameters.AddWithValue("@TVP_tblExaminando", clTblExaminando);
			param.SqlDbType = SqlDbType.Structured;
			//param.Direction = System.Data.ParameterDirection.ReturnValue;
			//cmd.Parameters.Add(param);
			cmd.CommandTimeout = 200;
			cmd.ExecuteNonQuery();

			return true;
		}

		public bool Editar(TblExaminandoModel clTblExaminando)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblExaminandoEditar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue("@Id", clTblExaminando.Id);
					cmd.Parameters.AddWithValue("@id_CargueArchivo", clTblExaminando.id_CargueArchivo);
					cmd.Parameters.AddWithValue("@NombrePrueba", clTblExaminando.NombrePrueba);
					cmd.Parameters.AddWithValue("@NombreDepartamento", clTblExaminando.NombreDepartamento);
					cmd.Parameters.AddWithValue("@NodigoMunicipio", clTblExaminando.CodigoMunicipio);
					cmd.Parameters.AddWithValue("@FechaAplicacion", clTblExaminando.FechaAplicacion);
					cmd.Parameters.AddWithValue("@NombreMunicipio", clTblExaminando.NombreMunicipio);
					cmd.Parameters.AddWithValue("@CodigoSitio", clTblExaminando.CodigoSitio);
					cmd.Parameters.AddWithValue("@NombreSitio", clTblExaminando.NombreSitio);
					cmd.Parameters.AddWithValue("@CodigoSalon", clTblExaminando.CodigoSalon);
					cmd.Parameters.AddWithValue("@Bloque", clTblExaminando.Bloque);
					cmd.Parameters.AddWithValue("@NombreSalon", clTblExaminando.NombreSalon);
					cmd.Parameters.AddWithValue("@Sesion", clTblExaminando.Sesion);
					cmd.Parameters.AddWithValue("@Registro", clTblExaminando.Registro);
					cmd.Parameters.AddWithValue("@Nombre1", clTblExaminando.Nombre1);
					cmd.Parameters.AddWithValue("@Nombre2", clTblExaminando.Nombre2);
					cmd.Parameters.AddWithValue("@Apellido1", clTblExaminando.Apellido1);
					cmd.Parameters.AddWithValue("@Apellido2", clTblExaminando.Apellido2);
					cmd.Parameters.AddWithValue("@Documento", clTblExaminando.Documento);
					cmd.Parameters.AddWithValue("@Forma", clTblExaminando.Forma);
					cmd.Parameters.AddWithValue("@TipoHR", clTblExaminando.TipoHR);
					cmd.Parameters.AddWithValue("@ConsecutivoControl", clTblExaminando.ConsecutivoControl);
					cmd.Parameters.AddWithValue("@CodigoCuadernillo", clTblExaminando.CodigoCuadernillo);
					cmd.Parameters.AddWithValue("@CodigoHojaRespuesta", clTblExaminando.CodigoHojaRespuesta);
					cmd.Parameters.AddWithValue("@IdConsecutivo", clTblExaminando.IdConsecutivo);
					cmd.Parameters.AddWithValue("@CodigoActa", clTblExaminando.CodigoActa);
					cmd.Parameters.AddWithValue("@Contenedor", clTblExaminando.Contenedor);
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
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblExaminandoEliminar"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblExaminandoModel.EnumCampos.Id.ToString()), Id);

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

		public int EliminarIdcargue(int id_CargueArchivo)
		{
			try
			{
				using (SqlCommand cmd = GetCommand("stpMarquesaReplenish_TblExaminandoEliminarXidCargueArchivo"))
				{
					cmd.CommandType = System.Data.CommandType.StoredProcedure;

					cmd.Parameters.AddWithValue(string.Format("@{0}", TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString()), id_CargueArchivo);

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

		public TblExaminandoModel GetData(int Id)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblExaminando");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1}  WHERE {0}=@{0};", TblExaminandoModel.EnumCampos.Id.ToString(), TblExaminandoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.Id.ToString(), Id);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblExaminando que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblExaminandoModel clTblExaminandoModel = new TblExaminandoModel();
			clTblExaminandoModel.ParseData(tbl.Rows[0]);
			return clTblExaminandoModel;
		}

		public DataTable GetFullTableTblExaminando()
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetTblExaminando");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {0}", TblExaminandoModel.NOMBRE_TABLA);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public DataTable GetTableTblExaminandoXTblCargueArchivo(int id_CargueArchivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblExaminandoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0};", TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), TblExaminandoModel.NOMBRE_TABLA);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			return tbl;
		}

		public TblExaminandoModel GetTableTblExaminandoXTblCargueArchivo(int id_CargueArchivo, int IdConsecutivo)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblExaminandoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0} and {2}=@{2};", TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), TblExaminandoModel.NOMBRE_TABLA, TblExaminandoModel.EnumCampos.IdConsecutivo.ToString());
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.IdConsecutivo.ToString(), IdConsecutivo);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblExaminando que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblExaminandoModel tblExaminandos = new TblExaminandoModel();
			tblExaminandos = Functions.DataTableHelper.ConvertDataTableToList<TblExaminandoModel>(tbl).FirstOrDefault();

			return tblExaminandos;
		}

		public TblExaminandoModel GetTableTblExaminandoXCuadernilloYHojaRespuesta(int id_CargueArchivo, string CodigoCuadernillo, string CodigoHojaRespuesta)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblExaminandoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0} and {2}=@{2} and {3}=@{3};", TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), TblExaminandoModel.NOMBRE_TABLA, TblExaminandoModel.EnumCampos.CodigoCuadernillo.ToString(), TblExaminandoModel.EnumCampos.CodigoHojaRespuesta.ToString());
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.CodigoCuadernillo.ToString(), CodigoCuadernillo);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.CodigoHojaRespuesta.ToString(), CodigoHojaRespuesta);

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());

			if (tbl.Rows.Count == 0)
			{
				return null;
			}
			if (tbl.Rows.Count != 1)
			{
				throw new Exception(string.Format("Se encontró {0} registros de tblExaminando que concuerdan con la búsqueda.", tbl.Rows.Count));
			}

			TblExaminandoModel tblExaminandos = new TblExaminandoModel();
			tblExaminandos = Functions.DataTableHelper.ConvertDataTableToList<TblExaminandoModel>(tbl).FirstOrDefault();

			return tblExaminandos;
		}

		public List<TblExaminandoModel> GetTableTblExaminandoXCodigoActa(int id_CargueArchivo, string CodigoActa)
		{
			if (!this.EsConexionValida())
			{
				throw new Exception("La conexión no está lista o no es válida");
			}

			SqlCommand cmd = GetCommand("GetDataTblExaminandoXTblCargueArchivo");
			cmd.CommandType = System.Data.CommandType.Text;
			cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0} and {2}=@{2};", TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), TblExaminandoModel.NOMBRE_TABLA, TblExaminandoModel.EnumCampos.CodigoActa.ToString());
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);
			cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.CodigoActa.ToString(), CodigoActa);		

			DataTable tbl = new DataTable();
			tbl.Load(cmd.ExecuteReader());


			List<TblExaminandoModel> ltsExaminandos = new List<TblExaminandoModel>();
			ltsExaminandos = Functions.DataTableHelper.ConvertDataTableToList<TblExaminandoModel>(tbl);

			return ltsExaminandos;
		}
		//public TblExaminandoModel GetTableTblExaminandoXTblCargueArchivo(int id_CargueArchivo, int ConsecutivoControl)
		//{
		//	if (!this.EsConexionValida())
		//	{
		//		throw new Exception("La conexión no está lista o no es válida");
		//	}

		//	SqlCommand cmd = GetCommand("GetDataTblExaminandoXTblCargueArchivo");
		//	cmd.CommandType = System.Data.CommandType.Text;
		//	cmd.CommandText = string.Format("SELECT * FROM {1} WHERE {0}=@{0} and {2}=@{2};", TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), TblExaminandoModel.NOMBRE_TABLA, TblExaminandoModel.EnumCampos.IdConsecutivo.ToString());
		//	cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.id_CargueArchivo.ToString(), id_CargueArchivo);
		//	cmd.Parameters.AddWithValue("@" + TblExaminandoModel.EnumCampos.IdConsecutivo.ToString(), ConsecutivoControl);

		//	DataTable tbl = new DataTable();
		//	tbl.Load(cmd.ExecuteReader());

		//	if (tbl.Rows.Count == 0)
		//	{
		//		return null;
		//	}
		//	if (tbl.Rows.Count != 1)
		//	{
		//		throw new Exception(string.Format("Se encontró {0} registros de tblExaminando que concuerdan con la búsqueda.", tbl.Rows.Count));
		//	}

		//	TblExaminandoModel tblExaminandos = new TblExaminandoModel();
		//	tblExaminandos = Functions.DataTableHelper.ConvertDataTableToList<TblExaminandoModel>(tbl).FirstOrDefault();

		//	return tblExaminandos;
		//}

	}
}