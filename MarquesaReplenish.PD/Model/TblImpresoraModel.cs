/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblImpresoraModel 
	{
		public const string NOMBRE_TABLA = "tblImpresora";

		public int Id { get; set; }

		public int? Id_FormatoSalida { get; set; }

		public string Nombre { get; set; }

		public bool? Estado { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_FormatoSalida,
			Nombre,
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

			strNombreCampo = EnumCampos.Id_FormatoSalida.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_FormatoSalida = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Nombre.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Nombre = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Estado.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Estado = Convert.ToBoolean(dr[strNombreCampo]);
			}

		}

	}
}