using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class StateClienteDTO
    {
        [Display(Name = "clienteId")]
        [MaxLength(100, ErrorMessage = "El {0} debe tener máximo {1} caractéres.")]
        public string clienteId { get; set; }
    }
}
