/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblPermisosModel 
	{
		public const string NOMBRE_TABLA = "tblPermisos";

		public int Id { get; set; }

		public string NombreFormulario { get; set; }

		public string TituloFormulario { get; set; }

		public string Descripcion { get; set; }

		public enum EnumCampos
		{
			Id,
			NombreFormulario,
			TituloFormulario,
			Descripcion
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreFormulario.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreFormulario = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.TituloFormulario.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.TituloFormulario = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Descripcion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Descripcion = Convert.ToString(dr[strNombreCampo]);
			}

		}

	}
}