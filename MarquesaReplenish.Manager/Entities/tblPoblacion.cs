using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblPoblacion: Base
    {
        //[Display(Name = "Usuario Procesamiento")]
        //[Range(1, 100000, ErrorMessage = "El {0} es obligatorio.")]
        //[Required(ErrorMessage = "El {0} es obligatorio.")]
        public int? Id_UsuarioProcesamiento { get; set; }

        public int Id_producto { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El {0} debe tener mínimo {2} y máximo {1} caractéres.")]
        [RegularExpression(@"^[a-zA-Z0-9_\- ]+$", ErrorMessage = "El {0} no debe contener dígitos especiales.")]
        [Required(ErrorMessage = "El {0} es obligatorio.")]
        public string Nombre { get; set; } = null!;

        public int InicioActa { get; set; }

        public int InicioContenedorOCaja { get; set; }

        
        public string? NombreArchivo { get; set; } = null!;

        public DateTime? FechaCargue { get; set; }

        public bool Adicional { get; set; }


        public bool Interprete { get; set; }




    }
}
