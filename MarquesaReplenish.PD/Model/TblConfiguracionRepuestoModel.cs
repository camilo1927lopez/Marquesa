/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblConfiguracionRepuestoModel 
	{
		public const string NOMBRE_TABLA = "tblConfiguracionRepuesto";

		public int Id { get; set; }

		public int id_CargueArchivo { get; set; }

		public string Ciclo { get; set; }

		public string NombrePruebaCondorPrint { get; set; }

        public string UsuarioCreacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public enum EnumCampos
		{
			Id,
			id_CargueArchivo,
			Ciclo,
			NombrePruebaCondorPrint, 
			UsuarioCreacion,
			FechaCreacion
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.id_CargueArchivo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.id_CargueArchivo = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Ciclo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Ciclo = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombrePruebaCondorPrint.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombrePruebaCondorPrint = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.UsuarioCreacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.UsuarioCreacion = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaCreacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaCreacion = Convert.ToDateTime(dr[strNombreCampo]);
			}

		}

	}
}