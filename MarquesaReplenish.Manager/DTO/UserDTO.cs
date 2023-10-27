using MarquesaReplenish.Manager.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class UserDTO
    {
        


        [Display(Name = "Área")]
        [Range(1, 100000, ErrorMessage = "El Área es obligatoria.")]
        [Required(ErrorMessage = "El {0} es obligatoria.")]
        public int areaId { get; set; }
        public string aplicacionId { get; set; } = null!;

        public Guid id { get; set; } 

        [Display(Name = "Nombre de usuario")]
        [MaxLength(200, ErrorMessage = "El  {0} debe tener máximo {1} caractéres.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "El Nombre de usuario, no debe contener espacios")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string userName { get; set; } = null!;

        [Display(Name = "telefono")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} solo debe contener números.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string telefono { get; set; } = null!;



        [Display(Name = "Cédula ")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "La {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "La {0} solo debe contener números.")]
        public string identificacion { get; set; } = null!;

        [Display(Name = "Nombres")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los {0} deben tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "Los {0} no deben contener dígitos especiales.")]
        [Required(ErrorMessage = "Los {0} son obligatorios.")]
        public string nombres { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los {0} deben tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "Los {0} no deben contener dígitos especiales.")]
        [Required(ErrorMessage = "Los {0} son obligatorios.")]
        public string apellidos { get; set; } = null!;

        //[Display(Name = "Usuario")]
        //public string userName { get; set; } = null!;

        //[Display(Name = "Overol")]
        //[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public string Overol { get; set; } = null!;

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El {0} debe ser una dirección de correo electrónico válida.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "El {0} no debe contener espacios en blanco.")]
        public string email { get; set; } = null!;

        [Display(Name = "Rol")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [RegularExpression("^(?!0$).*$", ErrorMessage = "El Rol es obligatorio.")]
        //[DataType(DataType.Currency)]
        public string rol { get; set; } = null!;

        
        public bool state { get; set; }

        public string EstadoString { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "La {0} debe tener entre {2} y {1} carácteres.")]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "La contraseña y confirmar contraseña no son iguales.")]
        [Display(Name = "Confirmar contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "{0} debe tener entre {2} y {1} carácteres.")]
        public string PasswordConfirm { get; set; } = null!;


        [NotMapped]
        public DateTime FechaCreacion { get; set; }
        [NotMapped]
        public string Codigo { get; set; } = null!;


        [NotMapped]
        [Display(Name = "Overol")]
        [StringLength(20, ErrorMessage = "El {0} debe tener máximo {1} carácteres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "El {0} no deben contener dígitos especiales.")]
        public string? Overol { get; set; }
        
        
        [NotMapped]
        public int Id_Rol { get; set; }

        [NotMapped]
        public string? LockoutEnd { get; set; }

        [NotMapped]
        public bool Estado { get; set; }

        [NotMapped]
        public string phoneNumber { get; set; }

        [NotMapped]
        
        public AreasDTO? area { get; set; }

        [NotMapped]
        public ICollection<aplicacionsDTO>? aplicacions { get; set; }

        [NotMapped]
        public bool Sincronizar { get; set; }





        //public ICollection<TemporalSale>? TemporalSales { get; set; }

        //public ICollection<Sale>? Sales { get; set; }
    }
}
