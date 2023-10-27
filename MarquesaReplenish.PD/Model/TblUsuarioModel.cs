/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblUsuarioModel 
	{
		public const string NOMBRE_TABLA = "tblUsuario";
		[Key]
		public int Id { get; set; }

		public int Id_Rol { get; set; }

		public string Usuario { get; set; }

		public string Documento { get; set; }

		public string NombreApellido { get; set; }

		public string Clave { get; set; }

		public DateTime FechaCreacion { get; set; }

		public DateTime FechaActualizacion { get; set; }

		public bool Estado { get; set; }

		public enum EnumCampos
		{
			Id,
			Id_Rol,
			Usuario,
			Documento,
			NombreApellido,
			Clave,
			FechaCreacion,
			FechaActualizacion,
			Estado
		}



	}
}