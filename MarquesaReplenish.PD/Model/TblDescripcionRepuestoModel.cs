/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblDescripcionRepuestoModel 
	{
		public const string NOMBRE_TABLA = "tblDescripcionRepuesto";

		public int Id { get; set; }

		public int Id_Impresora { get; set; }

		public int Id_novedad { get; set; }

		public int Id_tipoImpresion { get; set; }

		public string TipoPapel { get; set; }

		public string Resolucion { get; set; }

		public string ImprimirPor { get; set; }

		public int rangoMaxRepuesto { get; set; }

		public DateTime FechaCreacion { get; set; }

        public string Usuario { get; set; }

        public enum EnumCampos
		{
			Id,
			Id_Impresora,
			Id_novedad,
			Id_tipoImpresion,
			TipoPapel,
			Resolucion,
			ImprimirPor,
			rangoMaxRepuesto,
			FechaCreacion,
			Usuario
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_Impresora.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Impresora = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_novedad.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_novedad = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_tipoImpresion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_tipoImpresion = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.TipoPapel.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.TipoPapel = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Resolucion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Resolucion = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.ImprimirPor.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.ImprimirPor = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.rangoMaxRepuesto.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.rangoMaxRepuesto = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaCreacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaCreacion = Convert.ToDateTime(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Usuario.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Usuario = Convert.ToString(dr[strNombreCampo]);
			}

		}

	}
}