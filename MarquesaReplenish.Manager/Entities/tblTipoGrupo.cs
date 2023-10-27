using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblTipoGrupo : Base
    {
        
        public string Codigo { get; set; } = null!;

        
        public string Nombre { get; set; } = null!;

        
        public string Descripcion { get; set; } = null!;
    }
}
