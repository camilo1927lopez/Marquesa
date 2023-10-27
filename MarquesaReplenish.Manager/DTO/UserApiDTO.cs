using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class UserApiDTO
    {

        [Display(Name = "identificacion")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string identificacion { get; set; } = null!;

        [Display(Name = "nombres")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string nombres { get; set; } = null!;

        [Display(Name = "apellidos")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string apellidos { get; set; } = null!;

        [Display(Name = "datePassword")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime datePassword { get; set; }

        [Display(Name = "state")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool state { get; set; }


        [Display(Name = "nombreCompleto")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string nombreCompleto { get; set; } = null!;

        [Display(Name = "id")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid id { get; set; }

        [Display(Name = "userName")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string userName { get; set; } = null!;


        [Display(Name = "normalizedUserName")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string normalizedUserName { get; set; } = null!;


        [Display(Name = "email")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string email { get; set; } = null!;


        [Display(Name = "normalizedEmail")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string normalizedEmail { get; set; } = null!;

        [Display(Name = "emailConfirmed")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool emailConfirmed { get; set; }

        [Display(Name = "passwordHash")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string passwordHash { get; set; } = null!;

        [Display(Name = "securityStamp")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string securityStamp { get; set; } = null!;

        [Display(Name = "concurrencyStamp")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public Guid concurrencyStamp { get; set; }

        [Display(Name = "phoneNumber")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string phoneNumber { get; set; } = null!;

        [Display(Name = "phoneNumberConfirmed")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool phoneNumberConfirmed { get; set; }

        [Display(Name = "twoFactorEnabled")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool twoFactorEnabled { get; set; }

        [Display(Name = "lockoutEnd")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? lockoutEnd { get; set; } = null!;

        [Display(Name = "lockoutEnabled")]
       [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool lockoutEnabled { get; set; }

        [Display(Name = "accessFailedCount")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int accessFailedCount { get; set; }





    }
}
