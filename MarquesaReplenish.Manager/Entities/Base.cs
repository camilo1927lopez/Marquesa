using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }
        public bool? Sincronizar { get; set; }

    }
}
