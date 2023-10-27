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
    public class ChangePasswordDTO
    {
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña actual")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "La {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string currentPassword { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Nueva contraseña")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "La {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        public string newPassword { get; set; } = null!;

        [Compare(nameof(newPassword), ErrorMessage = "Nueva contraseña y Confirmar nueva contraseña no son iguales.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [StringLength(20, MinimumLength = 14, ErrorMessage = "{0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [Required(ErrorMessage = " {0} es obligatorio.")]
        public string confirmPassword { get; set; } = null!;

        
    }

}
