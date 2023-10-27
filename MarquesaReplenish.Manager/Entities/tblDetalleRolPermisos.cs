using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblDetalleRolPermisos
    {
        public int Id { get; set; }

        [ForeignKey(nameof(tblPermisos))]
        public int Id_Permisos { get; set; }
        [ForeignKey(nameof(tblRol))]
        public int Id_Rol { get; set; }
        public bool Sincronizar { get; set; }
        public tblPermisos? tblPermisos { get; set; }
        public tblRol? tblRol { get; set; }
    }
}
