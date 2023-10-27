using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class UserEditMarquesaDTO
    {
        //[Display(Name = "Id_Rol")]
        //[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //[DataType(DataType.Currency)]
        //public string Id_Rol { get; set; } = null!;

        //[Display(Name = "Overol")]
        //[MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "El campo {0} solo debe contener números.")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        //public string Overol { get; set; } = null!;
        public int Id { get; set; }
        public int Id_Rol { get; set; }
        public string Codigo { get; set; }
        public string? Overol { get; set; }

        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
    }
}
