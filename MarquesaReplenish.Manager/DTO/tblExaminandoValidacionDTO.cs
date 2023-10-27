using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.DTO
{
    public class tblExaminandoValidacionDTO
    {
     
        [Display(Name = "Prueba")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(200, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 1)]
        public string Prueba { get; set; } = null!;
        [Display(Name = "Aplicación")]
        [StringLength(7, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 2)]
        public string Aplicacion { get; set; } = null!;
        [Display(Name = "Examen ID")]
        [Range(1, 9999999999, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 3)]
        public int ExamID { get; set; }
        [Display(Name = "Examen")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 4)]
        public string Examen { get; set; } = null!;
        [Display(Name = "Fecha")]
        [DataMember(Order = 5)]
        [DataType(DataType.Date, ErrorMessage = "El campo {0} debe ser una fecha valida.")]
        public DateTime Fecha { get; set; }
        [Display(Name = "Hora Citación")]
        [DataType(DataType.Time, ErrorMessage = "El campo {0} debe ser una fecha valida.")]
        [DataMember(Order = 6)]
        public DateTime HoraCitacion { get; set; }
        [Display(Name = "Código Pais")]
        [StringLength(5, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 7)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string CodPais { get; set; } = null!;
        [Display(Name = "Nombre País")]
        [StringLength(200, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 8)]
        public string NombrePais { get; set; } = null!;
        [Display(Name = "Nombre Departamento")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 9)]
        public string NombreDepartamento { get; set; } = null!;
        [Display(Name = "Código Municipio")]
        [StringLength(5, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 10)]
        public string CodMunicipio { get; set; } = null!;
        [Display(Name = "Nombre Municipio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 11)]
        public string NombreMunicipio { get; set; } = null!;
        [Display(Name = "Region")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 12)]
        public string Region { get; set; } = null!;
        [Display(Name = "Código Sitio")]
        [StringLength(15, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 13)]
        public string CodigoSitio { get; set; } = null!;
        [Display(Name = "Nombre Sitio")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 14)]
        public string NombreSitio { get; set; } = null!;
        [Display(Name = "Dirección Sitio")]
        [StringLength(200, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 15)]
        public string DireccionSitio { get; set; } = null!;
        [Display(Name = "Telefono Sitio")]
        [StringLength(200, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 16)]
        public string TelefonoSitio { get; set; } = null!;
        [Display(Name = "Código Sitio Salón")]
        [StringLength(15, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 17)]
        public string CodSitioSalon { get; set; } = null!;
        [Display(Name = "Bloque")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 18)]
        public string Bloque { get; set; } = null!;
        [Display(Name = "Nombre Salón")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 19)]
        public string NombreSalon { get; set; } = null!;
        [Display(Name = "Sesión")]
        [Range(1, 9, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 20)]
        public int Sesion { get; set; }
        [Display(Name = "Consecutivo")]
        [Range(1, 9999999, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 21)]
        public int Consecutivo { get; set; }
        [Display(Name = "Registro")]
        [StringLength(15, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 22)]
        public string Registro { get; set; } = null!;
        [Display(Name = "Primer Nombre")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 23)]
        public string PrimerNombre { get; set; } = null!;
        [Display(Name = "Segundo Nombre")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 24)]
        public string SegundoNombre { get; set; } = null!;
        [Display(Name = "Primer Apellido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 25)]
        public string PrimerApellido { get; set; } = null!;
        [Display(Name = "Segundo Apellido")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 26)]
        public string SegundoApellido { get; set; } = null!;
        [Display(Name = "TipoDocumento")]
        [StringLength(5, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 27)]
        public string TipoDocumento { get; set; } = null!;
        [Display(Name = "Segundo Apellido")]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 28)]
        public string Documento { get; set; } = null!;
        [Display(Name = "Orden Salon")]
        [Range(1, 99, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 29)]
        public int OrdenSalon { get; set; }
        [Display(Name = "Forma")]
        [StringLength(5, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 30)]
        public string Forma { get; set; } = null!;
        [Display(Name = "Numero Cuadernillo")]
        [StringLength(10, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 31)]
        public string NumeroCuadernillo { get; set; } = null!;
        [Display(Name = "Tipo HR")]
        [StringLength(5, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 32)]
        public string TipoHR { get; set; } = null!;
        [Display(Name = "Tipo HR")]
        [StringLength(2, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 33)]
        public string TipoPA { get; set; } = null!;
        [Display(Name = "Universidad")]
        [StringLength(150, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 34)]
        public string Universidad { get; set; } = null!;
        [Display(Name = "Programa Académico")]
        [StringLength(200, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 35)]
        public string ProgramaAcademico { get; set; } = null!;
        [Display(Name = "Grupo Certificado")]
        //[Range(1, 9, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 36)]
        public string GrupoCertificado { get; set; }
        [Display(Name = "Grupo Referencia")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 37)]
        public string GrupoReferencia { get; set; } = null!;
        [Display(Name = "Motriz")]
        [DataMember(Order = 38)]
        public bool Motriz { get; set; }
        [Display(Name = "Discapacidad Cognitiva")]
        [DataMember(Order = 39)]
        public bool DiscapacidadCognitiva { get; set; }
        [Display(Name = "Invidente")]
        [DataMember(Order = 40)]
        public bool Invidente { get; set; }
        [Display(Name = "Sordo")]
        [DataMember(Order = 41)]
        public bool Sordo { get; set; }
        [Display(Name = "Maniobrar Materials")]
        [DataMember(Order = 42)]
        public bool ManiobrarMaterial { get; set; }
        [Display(Name = "Requiere Apoyo Acompañamiento")]
        [DataMember(Order = 43)]
        public bool RequiereApoyoAcompañamiento { get; set; }
        [Display(Name = "Lector")]
        [DataMember(Order = 44)]
        public bool Lector { get; set; }
        [Display(Name = "Interprete")]
        [DataMember(Order = 45)]
        public bool Interprete { get; set; }
        [Display(Name = "Interprete Sordo Ciego")]
        [DataMember(Order = 46)]
        public bool InterpreteSordoCiego { get; set; }
        [Display(Name = "Duracion")]
        //[DataType(DataType.Time, ErrorMessage = "El campo {0} debe ser una fecha valida.")]
        [DataMember(Order = 47)]
        public string Duracion { get; set; }
        [Display(Name = "Usuario")]
        [StringLength(20, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 48)]
        public string Usuario { get; set; } = null!;
        [Display(Name = "Password")]
        [StringLength(50, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 49)]
        public string Password { get; set; } = null!;
        [Display(Name = "Código Cuadernillo")]
        [StringLength(22, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 50)]
        public string CodigoCuadernillo { get; set; } = null!;
        [Display(Name = "Código Hoja Respuesta")]
        [StringLength(22, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataMember(Order = 51)]
        public string CodigoHojaRespuesta { get; set; } = null!;
        [Display(Name = "Código Grupo Certificado")]
        [StringLength(22, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 52)]
        public string CodigoGrupoCertificado { get; set; } = null!;
        [Display(Name = "Código PA1")]
        [StringLength(22, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 53)]
        public string CodigoPA1 { get; set; } = null!;
        [Display(Name = "Código PA2")]
        [StringLength(22, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 54)]
        public string CodigoPA2 { get; set; } = null!;
        [Display(Name = "Código PA3")]
        [StringLength(22, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 55)]
        public string CodigoPA3 { get; set; } = null!;
        [Display(Name = "Dane Estab")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 56)]
        public string DaneEstab { get; set; } = null!;
        [Display(Name = "Dane Sede")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 57)]
        public string DaneSede { get; set; } = null!;
        [Display(Name = "Codigo ICFES")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 58)]
        public string CodigoICFES { get; set; } = null!;
        [Display(Name = "Jornada")]
        [StringLength(100, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 59)]
        public string Jornada { get; set; } = null!;
        [Display(Name = "NBC ID")]
        [StringLength(15, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 60)]
        public string NBCID { get; set; } = null!;
        [Display(Name = "NBC Nombre")]
        [StringLength(280, ErrorMessage = "El campo {0} debe tener mínimo {2} y máximo {1} caractéres.", MinimumLength = 1)]
        [DataMember(Order = 61)]
        public string NBCNombre { get; set; } = null!;

        //[Display(Name = "Prioridad")]
        ////[Range(1, 99, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        ////[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataMember(Order = 62)]
        //public int Prioridad { get; set; } = 0;
        //[Display(Name = "NumeroConsecutivoPrioridad")]
        ////[Range(1, 99, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        ////[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataMember(Order = 63)]
        //public int ConsecutivoPrioridad { get; set; } = 0;

        //[Display(Name = "Código Acta")]
        ////[Range(1, 9999999999, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        ////[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataMember(Order = 64)]
        //public int CodigoActa { get; set; } = 0;
        //[Display(Name = "Código Bolsa")]
        ////[Range(1, 9999999999, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        ////[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataMember(Order = 65)]
        //public string? CodigoBolsa { get; set; } = null!;
        //[Display(Name = "Número Contenedor")]
        ////[Range(1, 9999999999, ErrorMessage = "El campo {0} debe ser un número entero, mayor a {1} y menor igual a {2}.")]
        ////[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataMember(Order = 66)]

        //public int NumeroContenedor { get; set; } = 0;

    }
}
