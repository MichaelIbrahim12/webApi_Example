using Lab2DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Dtos.Ticket
{
    public class ReadTicketDto
    {
        public  int Id { get; set; }
        public string? Description { get; set; }
        public string? Title { get; set; }
        public int? DeptId { get; set; }
    }
}
