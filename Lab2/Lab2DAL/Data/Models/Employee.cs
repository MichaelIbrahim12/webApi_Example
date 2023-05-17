using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Data.Models
{
    public class Employee :IdentityUser
    {
        public string Department { get; set; } = string.Empty;
    }
}
