using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblRol : Base
    {
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
       
        //public List<tblDetalleRolPermisos>? tblDetalleRolPermisos { get; set; }
        //public List<tblCliente>? tblClientes { get; set; }
    }
}
