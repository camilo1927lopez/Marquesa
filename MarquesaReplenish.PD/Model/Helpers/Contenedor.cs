using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.PD.Model.Helpers
{
    public class Contenedor
    {
        public string NumeroContenedor { get; set; }

        public List<InfoValue> InfoValue { get; set; }

        public int SumaCantidad { get; set; }

        public string KeyAgrupado { get; set; }

        public TamanoContenedor TamañoContenedore { get; set; }
        public override string ToString()
        {
            string strLinea = string.Empty;
            foreach (var item in InfoValue)            
                strLinea += $"{NumeroContenedor}|{KeyAgrupado}|{item.CodValue}|{item.Cantidad}{Environment.NewLine}";
            
            return strLinea;
        }
    }
}
