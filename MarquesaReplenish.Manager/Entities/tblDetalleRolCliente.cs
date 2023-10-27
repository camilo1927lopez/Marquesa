using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblDetalleRolCliente
    {
        public int Id { get; set; }

        [ForeignKey(nameof(tblCliente))]
        public int Id_Cliente { get; set; }
        [ForeignKey(nameof(tblRol))]
        public int Id_Rol { get; set; }

        public bool Sincronizar { get; set; }

        public tblCliente? tblCliente { get; set; }
        public tblRol? tblRol { get; set; }


    }
}
