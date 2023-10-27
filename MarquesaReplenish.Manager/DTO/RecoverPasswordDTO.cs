using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MarquesaReplenish.Manager.DTO
{
    public class RecoverPasswordDTO
    {
        

        public string userid { get; set; } = null!;

       

        public string token { get; set; } = null!;
    }
}
