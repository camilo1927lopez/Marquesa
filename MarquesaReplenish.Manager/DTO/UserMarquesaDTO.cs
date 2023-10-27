using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class UserMarquesaDTO
    {
        public DateTime FechaCreacion { get; set; }


       
        public Guid Codigo { get; set; }

        
        public string? Overol { get; set; } 


        public int Id_Rol { get; set; }

       
        public bool Estado { get; set; }

        public bool Sincronizar { get; set; }
    }
}
