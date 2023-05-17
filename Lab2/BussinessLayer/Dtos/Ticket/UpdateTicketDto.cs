using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Dtos.Ticket
{
    public class UpdateTicketDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public int? DeptId { get; set; }

    }
}
