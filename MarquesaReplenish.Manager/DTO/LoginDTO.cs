using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "El correo {0} es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debes ingresar un correo válido.")]
        public string usuario { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        [MinLength(6, ErrorMessage = "La {0} debe tener al menos {1} carácteres.")]
        public string password { get; set; } = null!;

        public string aplicacionId { get; set; } = null!;

        public bool directorioActivo { get; set; }

    }

}
