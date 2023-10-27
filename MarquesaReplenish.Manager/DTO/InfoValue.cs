using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.DTO
{
    public class InfoValue
    {
        public int Cantidad { get; set; }
        public bool Seleccionado { get; set; }
        public string CodValue { get; set; } = null!;
        public int consecutivo { get; set; }
        //public List<string[]> InfLinea { get; set; }
    }
}
