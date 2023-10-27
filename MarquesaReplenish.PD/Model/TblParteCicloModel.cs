/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblParteCicloModel 
	{
		public const string NOMBRE_TABLA = "tblParteCiclo";

		public int Id { get; set; }

		public int Id_configuracionRepuesto { get; set; }

		public int NumeroParte { get; set; }

		public int RangoInical { get; set; }

		public int RangoFinal { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_configuracionRepuesto,
			NumeroParte,
			RangoInical,
			RangoFinal
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_configuracionRepuesto.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_configuracionRepuesto = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NumeroParte.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NumeroParte = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.RangoInical.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.RangoInical = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.RangoFinal.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.RangoFinal = Convert.ToInt32(dr[strNombreCampo]);
			}

		}

	}
}