using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Dtos.Ticket
{
    public class TicketsDetailsForDepDto
    {
        public int Id { get; set; }
        public string? Descripton { get; set; }

        public int? DeveloperCount { get; set; }
    }
}
