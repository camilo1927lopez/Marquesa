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
    public class UserEditDTO
    {

        [Display(Name = "Área")]
        [Range(1, 100000, ErrorMessage = "El Área es obligatoria.")]
        [Required(ErrorMessage = "El {0} es obligatoria.")]
        public int areaId { get; set; }

        [Display(Name = "aplicacionId")]
        [MaxLength(200, ErrorMessage = "La {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [DataType(DataType.Currency)]
        public string aplicacionId { get; set; } = null!;

        [Display(Name = "Rol")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [RegularExpression("^(?!0$).*$", ErrorMessage = "El Rol es obligatorio.")]
        [DataType(DataType.Currency)]
        public string rol { get; set; } = null!;

        [Display(Name = "Nombres")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los {0} deben tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "Los {0} no deben contener dígitos especiales.")]
        [Required(ErrorMessage = "Los {0} son obligatorios.")]
        public string nombres { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Los {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "Los {0} no debe, contener dígitos especiales.")]
        [Required(ErrorMessage = "Los {0} son obligatorios.")]
        public string apellidos { get; set; } = null!;


        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "El {0} debe ser una dirección de correo electrónico válida.")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "El {0} no debe contener espacios en blanco.")]
        public string email { get; set; } = null!;

        [Display(Name = "telefono")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} solo debe contener números.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string telefono { get; set; } = null!;

        [NotMapped]
        [Display(Name = "Rol")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        [RegularExpression("^(?!0$).*$", ErrorMessage = "El Rol es obligatorio.")]

        [DataType(DataType.Currency)]
        public string Id_Rol { get; set; } = null!;


        [NotMapped]
        [Display(Name = "Overol")]
        [StringLength(20, ErrorMessage = "El {0} debe tener máximo {1} carácteres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "El {0} no debe contener dígitos especiales o espacios en blanco.")]
        public string? Overol { get; set; }


        



    }
    
}
