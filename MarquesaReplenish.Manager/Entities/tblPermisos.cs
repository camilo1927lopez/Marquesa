using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblPermisos : Base
    {
        public string NombreFormulario { get; set; } = null!;
        public string TituloFormulario { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int Id_Aplicacion { get; set; }
        public int Orden { get; set; }
        public string? Img { get; set; }


        [NotMapped]
        public string Aplicacion { get; set; } = null!;

        [NotMapped]
        public bool Seleccionado { get; set; }

        public List<tblDetalleRolPermisos>? TblDetalleRolPermisos { get; set; }
    }
}
