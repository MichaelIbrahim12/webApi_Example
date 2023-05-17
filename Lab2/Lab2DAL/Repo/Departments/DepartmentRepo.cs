using Lab2DAL.Data.Context;
using Lab2DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Repo.Departments
{
    public class DepartmentRepo : IDepartmentRepo
    {
        Lab2Context _context; 
        public DepartmentRepo(Lab2Context context )
        {
            _context = context;
        }
        public Department getincludebyid(int id)
        {
            var department= _context.Departments
                .Include(d=>d.Tickets)
                .ThenInclude(t=>t.Developers)
                .FirstOrDefault(d=>d.Id==id);

            return department;
        }
    }
}
