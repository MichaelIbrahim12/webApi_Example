using Lab2BL.Dtos.Department;
using Lab2BL.Manger;
using Lab2BL.Manger.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
       private IDepartmentManger _manger;

        public DepartmentController(IDepartmentManger manger)
        {
            _manger= manger;
        }

        [HttpGet]
        [Route("{id}")]

        public ActionResult<ReadDepartmantDetailsDto> getbyid(int id)
        {
            var department= _manger.getDepDetails(id);

            if(department== null)
            {
                return NotFound();
            }

            return department;
            
        }
    }
}
