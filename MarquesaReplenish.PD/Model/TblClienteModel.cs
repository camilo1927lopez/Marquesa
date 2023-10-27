/**Generado por ProjectManager versión 1.2.0.0 el día 26-02-2022 17:25:01**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblClienteModel 
	{
		public const string NOMBRE_TABLA = "tblCliente";

		public int Id { get; set; }

		public int? Id_Rol { get; set; }

		public string Nit { get; set; }

		public string Nombre { get; set; }

		public DateTime? FechaCreacion { get; set; }

		public bool? Estado { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_Rol,
			Nit,
			Nombre,
			FechaCreacion,
			Estado
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_Rol.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Rol = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Nit.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Nit = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Nombre.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Nombre = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaCreacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaCreacion = Convert.ToDateTime(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Estado.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Estado = Convert.ToBoolean(dr[strNombreCampo]);
			}

		}

	}
}