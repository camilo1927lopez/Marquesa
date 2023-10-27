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
    public class EmailDTO
    {
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        
        public string usuario { get; set; } = null!;

        [Display(Name = "Aplicación")]
        [Required(ErrorMessage = "La {0} es obligatoria.")]
        
        public string AplicacionId { get; set; } = null!;
        [NotMapped]
        public string userid { get; set; } = null!;
        [NotMapped]
        public string token { get; set; } = null!;
    }

}
