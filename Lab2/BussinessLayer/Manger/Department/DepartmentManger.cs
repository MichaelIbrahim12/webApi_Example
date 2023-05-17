using Lab2BL.Dtos.Department;
using Lab2BL.Dtos.Ticket;
using Lab2DAL.Repo.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2BL.Manger.Department
{
    
    public class DepartmentManger : IDepartmentManger
    {
        private IDepartmentRepo _repo;
        public DepartmentManger(IDepartmentRepo repo)
        {
            _repo = repo;
        }
        public ReadDepartmantDetailsDto getDepDetails(int id)
        {
            var departmentFromDb=_repo.getincludebyid(id);

            if(departmentFromDb is null)
            {
                return null;
            }

            return new ReadDepartmantDetailsDto
            {
                Id=departmentFromDb.Id,
                Name=departmentFromDb.Name,
                Tickets= departmentFromDb.Tickets.Select(t=>new TicketsDetailsForDepDto
                {
                    Id = t.Id,
                    Descripton=t.Description,
                    DeveloperCount=t.Developers.Count

                }).ToList()

            };
        }
    }
}
