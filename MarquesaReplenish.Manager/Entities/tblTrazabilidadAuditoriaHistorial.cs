using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.Entities
{
    public class tblTrazabilidadAuditoriaHistorial : Base
    {
        [ForeignKey(nameof(tblUsuario))]
        public int Id_Usuario { get; set; }
        [ForeignKey(nameof(tblExaminando))]
        public int Id_Examinando { get; set; }
        [ForeignKey(nameof(tblTipo))]
        public int Id_Tipo { get; set; }


        //Relaciones
        public tblUsuario tblUsuario { get; set; }
        public tblExaminando tblExaminando { get; set; }
        public tblTipo tblTipo { get; set; }
    }
}
