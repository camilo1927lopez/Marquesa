using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.DTO
{
    public class TamanoContenedor
    {
        public int Tamano { get; set; }
        public string Nombre { get; set; } = null!;
        public string Prefijo { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
