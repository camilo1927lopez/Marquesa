using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblUsuario : Base
    {
        [ForeignKey(nameof(tblRol))]
        public int Id_Rol { get; set; }
        public string Codigo { get; set; }
        public string? Overol { get; set; } 
        public tblRol? tblRol { get; set; }
    }
}
