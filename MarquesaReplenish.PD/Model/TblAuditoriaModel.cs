/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblAuditoriaModel 
	{
		public const string NOMBRE_TABLA = "tblAuditoria";

		public int Id { get; set; }

		public int Id_DetalleRepuesto { get; set; }

		public int Id_Estado { get; set; }

		public int Id_Usuario { get; set; }

		public DateTime FechaHora { get; set; }

		public string Observacion { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_DetalleRepuesto,
			Id_Estado,
			Id_Usuario,
			FechaHora,
			Observacion
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			//if (dr[strNombreCampo] != DBNull.Value)
			//{
			//	this.Id = Guid.Parse(dr[strNombreCampo]);
			//}

			//strNombreCampo = EnumCampos.Id_DetalleRepuesto.ToString();
			//if (dr[strNombreCampo] != DBNull.Value)
			//{
			//	this.Id_DetalleRepuesto = Guid.Parse(dr[strNombreCampo]);
			//}

			strNombreCampo = EnumCampos.Id_Estado.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Estado = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Id_Usuario.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Id_Usuario = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaHora.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaHora = Convert.ToDateTime(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Observacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Observacion = Convert.ToString(dr[strNombreCampo]);
			}

		}

	}
}