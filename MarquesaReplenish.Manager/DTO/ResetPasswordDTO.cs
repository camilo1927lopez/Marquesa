using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class ResetPasswordDTO
    {

        public string usuario { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "La {0} debe tener entre {2} y {1} carácteres.")]
        public string password { get; set; } = null!;

        [Compare("password", ErrorMessage = "La nueva contraseña y confirmar nueva contraseña no coinciden.")]
        [Display(Name = "Confirmar nueva contraseña")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "{0} es obligatorio.")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "{0} debe tener entre {2} y {1} carácteres.")]
        public string confirmPassword { get; set; } = null!;


        public string token { get; set; } = null!;
    }
}
