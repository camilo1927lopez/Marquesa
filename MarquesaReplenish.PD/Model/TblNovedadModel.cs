/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblNovedadModel 
	{
		public const string NOMBRE_TABLA = "tblNovedad";

		public int Id { get; set; }

		public int? id_Maquina { get; set; }

		public string Nombre { get; set; }

		public bool? Estado { get; set; }

		public enum EnumCampos
		{
			Id,
			id_Maquina,
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

			strNombreCampo = EnumCampos.id_Maquina.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.id_Maquina = Convert.ToInt32(dr[strNombreCampo]);
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