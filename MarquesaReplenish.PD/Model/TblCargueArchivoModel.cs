/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblCargueArchivoModel 
	{
		public const string NOMBRE_TABLA = "tblCargueArchivo";

		public int Id { get; set; }
		public string NombreBibliaImpresion { get; set; }
		public string NombreBibliaDistribucion { get; set; }
		public string NombreCarguePrueba { get; set; }
        public string UsuarioCreacion { get; set; }
        public DateTime? FechaCargue { get; set; }

		public enum EnumCampos
		{
			Id,
			NombreBibliaImpresion,
			NombreBibliaDistribucion,
			NombreCarguePrueba,
			FechaCargue,
			UsuarioCreacion
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreBibliaImpresion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreBibliaImpresion = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreBibliaDistribucion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreBibliaDistribucion = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreCarguePrueba.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreCarguePrueba = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaCargue.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaCargue = Convert.ToDateTime(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.UsuarioCreacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaCargue = Convert.ToDateTime(dr[strNombreCampo]);
			}

		}

	}
}