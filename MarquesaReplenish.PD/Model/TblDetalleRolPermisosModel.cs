/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblDetalleRolPermisosModel 
	{
		public const string NOMBRE_TABLA = "tblDetalleRolPermisos";

		public int Id { get; set; }

		public int Id_Permisos { get; set; }

		public int Id_Rol { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_Permisos,
			Id_Rol
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_Permisos.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Permisos = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_Rol.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Rol = Convert.ToInt32(dr[strNombreCampo]);
			}

		}

	}
}