using Lab2BL.Dtos.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Manger.Department
{
    public interface IDepartmentManger
    {
        public ReadDepartmantDetailsDto getDepDetails(int id);
       

    }
}
