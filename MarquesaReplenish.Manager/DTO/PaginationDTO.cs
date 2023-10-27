using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarquesaReplenish.Manager.DTO
{
    public class PaginationDTO
    {
        public string? Id { get; set; } = string.Empty;

        public int Page { get; set; } = 1;

        public int RecordsNumber { get; set; } = 0;

        public string? Filter { get; set; }
    }
}
