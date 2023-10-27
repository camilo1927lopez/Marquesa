using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblContenedorCaja : Base
    {
        [ForeignKey(nameof(tblTipo))]
        public int Id_Tipo { get; set; }
        public string CodigoProcesamiento { get; set; }
        public int Numero { get; set; }
        public string PrecintoCierre { get; set; } = null!;
        public string PrecintoRetorno { get; set; } = null!;
        public int Cantidad { get; set; }

        //Relaciones
        public List<tblExaminando>? tblExaminandos { get; set; }
        public tblTipo? tblTipo { get; set; }
    }
}
