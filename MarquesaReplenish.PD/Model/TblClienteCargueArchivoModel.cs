/**Generado por ProjectManager versión 1.2.0.0 el día 26-02-2022 17:25:01**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblClienteCargueArchivoModel 
	{
		public const string NOMBRE_TABLA = "tblClienteCargueArchivo";

		public int Id { get; set; }

		public int Id_Cliente { get; set; }

		public int Id_CargueArchivo { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_Cliente,
			Id_CargueArchivo
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_Cliente.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Cliente = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_CargueArchivo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_CargueArchivo = Convert.ToInt32(dr[strNombreCampo]);
			}

		}

	}
}