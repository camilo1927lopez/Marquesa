using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.DTO
{
    public class IdentityRoleDTO
    {
        public string id {  get; set; }
        public string name { get; set; }
        public string normalizedName { get; set; }
        public string concurrencyStamp { get; set; }

    }
}
