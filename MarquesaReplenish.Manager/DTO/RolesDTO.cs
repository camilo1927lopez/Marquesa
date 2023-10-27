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
    public class RolesDTO
    {
        [Display(Name = "IdRol")]
        public string id { get; set; } = null!;

        [Display(Name = "Nombre de rol")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "El {0} debe contener solo letras y números.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Name { get; set; } = null!;

        [Display(Name = "Nombre normalizado")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string NormalizedName { get; set; } = null!;

        [Display(Name = "concurrencyStamp")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string ConcurrencyStamp { get; set; } = null!;

        [NotMapped]
        public DateTime FechaCreacion { get; set; }

        [NotMapped]
        public bool Estado { get; set; }

        [NotMapped]
        public string Codigo { get; set; }
    }
}
