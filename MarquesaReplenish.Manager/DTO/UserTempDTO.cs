using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class UserTempDTO : UserDTO
    {
        
        public DateTime FechaCreacion { get; set; }


        [Display(Name = "Codigo")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DataType(DataType.Currency)]
        public string Codigo { get; set; } = null!;

        [Display(Name = "Overol")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataType(DataType.Currency)]
        public string Overol { get; set; } = null!;
    }
}
