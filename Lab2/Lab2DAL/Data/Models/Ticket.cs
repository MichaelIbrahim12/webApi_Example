using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }

        [ForeignKey("Department")]
        public int? DeptId { get; set; }
        public Department Department { get; set; }

        public ICollection<Developer> Developers { get; set; }=new HashSet<Developer>();

    }
}
