/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblRepuestoModel 
	{
		public const string NOMBRE_TABLA = "tblRepuesto";

		public int Id { get; set; }

		public int Id_ConfiguracionRepuesto { get; set; }

		public int Id_DescripcionRepuesto { get; set; }

		public int? Rango { get; set; }

		public DateTime? FechaIngreso { get; set; }

		public DateTime? FechaInactivo { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_ConfiguracionRepuesto,
			Id_DescripcionRepuesto,
			Rango,
			FechaIngreso,
			FechaInactivo
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_ConfiguracionRepuesto.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_ConfiguracionRepuesto = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_DescripcionRepuesto.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_DescripcionRepuesto = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Rango.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Rango = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaIngreso.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaIngreso = Convert.ToDateTime(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaInactivo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaInactivo = Convert.ToDateTime(dr[strNombreCampo]);
			}

		}

	}
}