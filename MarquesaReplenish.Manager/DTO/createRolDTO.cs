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
    public class createRolDTO
    {
        [Display(Name = "Nombre")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "El {0} solo debe contener letras y números.")]
        [Required(ErrorMessage = "Campo obligatorio.")]
        public string roleName { get; set; } = null!;
    }
}
