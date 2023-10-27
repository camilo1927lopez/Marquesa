using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblAdicionales : Base
    {

        public int Id_producto { get; set; }

        [Display(Name = "Tipo de dato")]
        [Range(1, 99999, ErrorMessage = "El {0} es obligatorio.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public int Id_Tipo { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "El {0} no debe contener dígitos especiales.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Prefijo")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El {0} solo debe contener letras.")]
        public string? Prefijo { get; set; } = null!;

        [Display(Name = "Consecutivo Inicial")]
        [Range(1, 99999, ErrorMessage = "El {0} debe estar en el rango de 1 a 99999.")]
        public int? ConsecutivoInicial { get; set; }

        [Display(Name = "Valor fijo")]
        [StringLength(5, MinimumLength = 1, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caracteres.")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "El {0} solo debe contener letras y números.")]
        public string? ValorFijo { get; set; } = null!;

        [Display(Name = "Máscara")]
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "El {0} debe contener solo letras y números.")]
        public string? Mascara { get; set; } = null!;

        public bool TodasSesiones { get; set; }






    }
}
