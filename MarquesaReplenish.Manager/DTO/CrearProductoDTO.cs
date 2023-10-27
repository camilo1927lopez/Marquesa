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
    public class CrearProductoDTO : Base
    {
        public int Id_Cliente { get; set; }

        [Display(Name = "Tipo")]
        [Range(1, 100000, ErrorMessage = "El {0} es obligatorio.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public int Id_Tipo { get; set; }

        [Display(Name = "Nombre de producto")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;

        [Display(Name = "Capacidad máxima cuadernillos X acta")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "La {0} debe tener entre 1 y 3 dígitos positivos.")]
        
        public int? CapacidadMaxBolsaSeguridad { get; set; }

        [Display(Name = "Capacidad máxima cuadernillos X contenedor grande")]
        [RegularExpression(@"^[0-9^e]{1,3}$", ErrorMessage = "La {0} debe tener entre 1 y 3 dígitos positivos.")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        
        public int? CapacidadMaxContenedor { get; set; }

        [Display(Name = "Capacidad máxima cuadernillos X contenedor mediano")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "La {0} debe tener entre 1 y 3 dígitos positivos.")]
        
        public int? CapacidadMinContenedor { get; set; }

        [Display(Name = "Capacidad Máxima de la caja")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "La {0} debe tener entre 1 y 3 dígitos positivos.")]
        
        public int? CapacidadMaxCaja { get; set; }

        [Display(Name = "Cantidad precinto cierre X contenedor o caja")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "La {0} debe tener entre 1 y 3 dígitos positivos.")]
        
        public int? CantidadPrecintoCierre { get; set; }

        [Display(Name = "Cantidad precinto retorno X contenedor o caja")]
        [RegularExpression(@"^[0-9]{1,3}$", ErrorMessage = "La {0} debe tener entre 1 y 3 dígitos positivos.")]
        
        public int? CantidadPrecintoRetorno { get; set; }
    }
}
