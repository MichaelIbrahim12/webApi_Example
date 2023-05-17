using Lab2BL.Dtos.Login_Registration;
using Lab2DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Lab2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IConfiguration _Configuration { get; set; }
        private UserManager<Employee> _UserManager { get; set; }
        public DataController( IConfiguration config,UserManager<Employee> manger)
        {
            _Configuration = config;
            _UserManager = manger;
        }

        [HttpGet]
        [Authorize]
        [Route("user")]

        public async Task< ActionResult<RegisterDto>> GetUserInfo()
        {
            var user= await _UserManager.GetUserAsync(User);

            return Ok(new string[]
            {
                user.UserName,
                user.Email,
                user.Department
            });
        }        
        [HttpGet]
        [Authorize(Policy ="admin")]
        [Route("mangerAuth")]
        public async Task< ActionResult<RegisterDto>> GetInfoForManage()
        {
            var user= await _UserManager.GetUserAsync(User);

            return Ok(new string[]
            {
                user.UserName,
                user.Email,
                user.Department
            });
        }        
        [HttpGet]
        [Authorize(Policy ="user")]
        [Route("userAuth")]
        public async Task< ActionResult<RegisterDto>> GetInfoForUser()
        {
            var user= await _UserManager.GetUserAsync(User);

            return Ok(new string[]
            {
                user.UserName,
                user.Email,
                user.Department
            });
        }
    }
}
