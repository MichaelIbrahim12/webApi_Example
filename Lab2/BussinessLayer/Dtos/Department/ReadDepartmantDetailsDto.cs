using Lab2BL.Dtos.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Dtos.Department
{
    public class ReadDepartmantDetailsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<TicketsDetailsForDepDto> Tickets { get; set; } = new();

    }
}
