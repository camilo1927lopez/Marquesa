/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblDetalleRepuestoModel 
	{
		public const string NOMBRE_TABLA = "tblDetalleRepuesto";

		public int Id { get; set; }

		public int Id_Repuesto { get; set; }

		public int Id_Examinando { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_Repuesto,
			Id_Examinando
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			//strNombreCampo = EnumCampos.Id.ToString();
			//if (dr[strNombreCampo] != DBNull.Value)
			//{
			//	this.Id = Guid.Parse(dr[strNombreCampo]);
			//}

			strNombreCampo = EnumCampos.Id_Repuesto.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Repuesto = Convert.ToInt32(dr[strNombreCampo]);
			}

			//strNombreCampo = EnumCampos.Id_Examinando.ToString();
			//if (dr[strNombreCampo] != DBNull.Value)
			//{
			//	this.Id_Examinando = Guid.Parse(dr[strNombreCampo]);
			//}

		}

	}
}