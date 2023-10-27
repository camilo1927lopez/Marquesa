using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblTipo : Base
    {

        public int Id_TGrupo { get; set; }

        public string Codigo { get; set; } = null!;


        public string Nombre { get; set; } = null!;


        public string Descripcion { get; set; } = null!;
    }
}
