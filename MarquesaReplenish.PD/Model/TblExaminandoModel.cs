/**Generado por ProjectManager versión 1.2.0.0 el día 21-02-2022 14:29:56**/

using System;
using System.Data;

namespace MarquesaReplenish.PD.Model
{
	public class TblExaminandoModel 
	{
		public const string NOMBRE_TABLA = "tblExaminando";

		public int Id { get; set; }

		public int id_CargueArchivo { get; set; }

		public string NombrePrueba { get; set; }

		public string NombreDepartamento { get; set; }

		public string CodigoMunicipio { get; set; }

		public string FechaAplicacion { get; set; }

		public string NombreMunicipio { get; set; }

		public string CodigoSitio { get; set; }

		public string NombreSitio { get; set; }

		public string CodigoSalon { get; set; }

		public string Bloque { get; set; }

		public string NombreSalon { get; set; }

		public string Sesion { get; set; }

		public string Registro { get; set; }

		public string Nombre1 { get; set; }

		public string Nombre2 { get; set; }

		public string Apellido1 { get; set; }

		public string Apellido2 { get; set; }

		public string Documento { get; set; }

		public string Forma { get; set; }

		public string TipoHR { get; set; }

		public string ConsecutivoControl { get; set; }

		public string CodigoCuadernillo { get; set; }

		public string CodigoHojaRespuesta { get; set; }

		public string IdConsecutivo { get; set; }

		public string CodigoActa { get; set; }

		public string Contenedor { get; set; }

        public string DireccionSitio { get; set; }

        public enum EnumCampos
		{
			Id = -1,
			id_CargueArchivo = -2,
			NombrePrueba = 0,
			NombreDepartamento = 6,
			CodigoMunicipio = 7,
			FechaAplicacion = 2,
			NombreMunicipio = 8,
			CodigoSitio = 10,
			NombreSitio = 11,
			CodigoSalon = 14,
			Bloque = 15,
			NombreSalon = 16,
			Sesion = 17,
			Registro = 21,
			Nombre1 = 22,
			Nombre2 = 23,
			Apellido1 = 24,
			Apellido2 = 25,
			Documento = 27,
			Forma = 29,
			TipoHR = 31,
			ConsecutivoControl = 20,
			CodigoCuadernillo = 24,
			CodigoHojaRespuesta = 25,
			IdConsecutivo = 31,
			CodigoActa = 32,
			Contenedor,
			DireccionSitio = 12,
			CodigoCuadernilloImpresion = 49,
			CodigoHojaRespuestaImpresion = 50,
		}

		public enum EnumCamposBDGeneral
		{
			Id = -1,
			id_CargueArchivo = -2,
			NombrePrueba = 0,
			NombreDepartamento = 6,
			CodigoMunicipio = 7,
			FechaAplicacion = 2,
			NombreMunicipio = 8,
			CodigoSitio = 10,
			NombreSitio = 11,
			CodigoSalon = 14,
			Bloque = 15,
			NombreSalon = 16,
			Sesion = 17,
			Registro = 21,
			Nombre1 = 39,
			Nombre2 = 40,
			Apellido1 = 41,
			Apellido2 = 42,
			Documento = 43,
			Forma = 38,
			TipoHR = 44,
			ConsecutivoControl = 20,
			CodigoCuadernillo = 24,
			CodigoHojaRespuesta = 25,
			IdConsecutivo = 31,
			CodigoActa = 32,
			Contenedor,
			DireccionSitio = 12
		}

		public void ParseData(DataRow dr)
		{
			string strNombreCampo;
			strNombreCampo = EnumCampos.Id.ToString();
			//if (dr[strNombreCampo] != DBNull.Value)
			//{
			//	this.Id = Guid.Parse(dr[strNombreCampo]);
			//}

			strNombreCampo = EnumCampos.id_CargueArchivo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.id_CargueArchivo = Convert.ToInt32(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombrePrueba.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombrePrueba = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreDepartamento.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreDepartamento = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.CodigoMunicipio.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.CodigoMunicipio = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.FechaAplicacion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.FechaAplicacion = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreMunicipio.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreMunicipio = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.CodigoSitio.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.CodigoSitio = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreSitio.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreSitio = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.CodigoSalon.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.CodigoSalon = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Bloque.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Bloque = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.NombreSalon.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.NombreSalon = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Sesion.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Sesion = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Registro.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Registro = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Nombre1.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Nombre1 = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Nombre2.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Nombre2 = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Apellido1.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Apellido1 = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Apellido2.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Apellido2 = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Documento.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Documento = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Forma.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Forma = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.TipoHR.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.TipoHR = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.ConsecutivoControl.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.ConsecutivoControl = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.CodigoCuadernillo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.CodigoCuadernillo = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.CodigoHojaRespuesta.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.CodigoHojaRespuesta = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.IdConsecutivo.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.IdConsecutivo = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.CodigoActa.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.CodigoActa = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.Contenedor.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Contenedor = Convert.ToString(dr[strNombreCampo]);
			}

			strNombreCampo = EnumCampos.DireccionSitio.ToString();
			if (dr[strNombreCampo] != DBNull.Value)
			{
				this.Contenedor = Convert.ToString(dr[strNombreCampo]);
			}


		}

	}
}