using Lab2DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Data.Context
{
    public class Lab2Context:IdentityDbContext <Employee>
    {
        public DbSet<Ticket> Tickets =>Set<Ticket>();
        public DbSet<Developer> Developers=>Set<Developer>();
        public DbSet<Department> Departments =>Set<Department>();

        public Lab2Context(DbContextOptions<Lab2Context> options ):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().ToTable("Employees");
            builder.Entity<IdentityUserClaim<string>>().ToTable("EmployeesClaims");
        }
    }
}
