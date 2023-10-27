using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.Entities
{
    public class User : IdentityUser
    {
        [Display(Name = "Documento")]
        [MaxLength(20, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int identificacion { get; set; }

        [Display(Name = "Nombres")]
        [MaxLength(50, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string nombres { get; set; } = null!;

        [Display(Name = "Nombre Completo")]
        [MaxLength(50, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string nombreCompleto { get; set; } = null!;

        [Display(Name = "Apellidos")]
        [MaxLength(50, ErrorMessage = "Los {0} deben tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "Los {0} son obligatorios.")]
        public string apellidos { get; set; } = null!;

        [Display(Name = "Usuario")]
        public string Usuario { get; set; } = null!;

        [Display(Name = "Overol")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Overol { get; set; } = null!;

        [Display(Name = "Correo Electronico")]
        [MaxLength(200, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string email { get; set; } = null!;

        [Display(Name = "Rol")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Currency)]
        public int Rol { get; set; }

    
        public bool state { get; set; }

        public DateTime datePassword { get; set; }

        
       
       
    }
}
