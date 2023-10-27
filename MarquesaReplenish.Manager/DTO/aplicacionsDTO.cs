using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.DTO
{
    public class aplicacionsDTO
    {

        public int id { get; set; }

        public string nombre { get; set; }

        public string guid { get; set; }

        public string version { get; set; }
    }
}
