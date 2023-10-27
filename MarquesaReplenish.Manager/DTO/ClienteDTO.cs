using MarquesaReplenish.Manager.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class ClienteDTO : Base
    {
        [Display(Name = "NIT")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\-]+$", ErrorMessage = "El {0} no debe contener dígitos especiales o espacios.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Nit { get; set; } = null!;

        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El {0} no debe contener dígitos especiales o espacios.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Imagen-Logo")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string? Img { get; set; } = null!;

        public bool Sincronizar { get; set; }
    }
}
