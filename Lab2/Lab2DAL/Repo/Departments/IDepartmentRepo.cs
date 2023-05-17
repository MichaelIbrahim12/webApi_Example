using Lab2DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2DAL.Repo.Departments
{
    public interface IDepartmentRepo
    {
        Department getincludebyid(int id);
    }
}
