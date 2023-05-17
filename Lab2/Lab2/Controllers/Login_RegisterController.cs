using Lab2BL.Dtos.Login_Registration;
using Lab2DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Lab2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login_RegisterController : ControllerBase
    {
        private   IConfiguration _Configuration { get; set; }
        private  UserManager<Employee> _UserManager { get; set; }

        public Login_RegisterController( IConfiguration config, UserManager<Employee> manger)
        {
            _Configuration = config;
            _UserManager = manger;
        }

        [HttpPost]
        [Route("Register_admin")]
        public async Task< ActionResult> RegisterAdmin(RegisterDto registerDto)
        {
            var newEmployee = new Employee
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Department = registerDto.Department,
            };
            var creationResult = await _UserManager.CreateAsync(newEmployee, registerDto.Password);

            if(!creationResult.Succeeded)
            {
                return BadRequest();
            }
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, newEmployee.Id),
            new Claim(ClaimTypes.Role, "admin"),
            new Claim("Nationality", "Egyptian")
        };

            await _UserManager.AddClaimsAsync(newEmployee, claims);

            return NoContent();

        }        
        [HttpPost]
        [Route("Register_user")]
        public async Task< ActionResult> RegisterUser(RegisterDto registerDto)
        {
            var newEmployee = new Employee
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Department = registerDto.Department,
            };
            var creationResult = await _UserManager.CreateAsync(newEmployee, registerDto.Password);

            if(!creationResult.Succeeded)
            {
                return BadRequest();
            }
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, newEmployee.Id),
            new Claim(ClaimTypes.Role, "user"),
            new Claim("Nationality", "Egyptian")
        };

            await _UserManager.AddClaimsAsync(newEmployee, claims);

            return NoContent();

        }
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<TokenDto>> RegisterUser(LoginDto credentials)
        { 
            Employee user= await _UserManager.FindByNameAsync(credentials.UserName);

            if(user is null)
            {
                return BadRequest();
            }
            bool isPasswordCorrect= await _UserManager.CheckPasswordAsync(user, credentials.Password);

            if (!isPasswordCorrect)
            {
                return BadRequest();
            }
            var claims=await _UserManager.GetClaimsAsync(user);

            return GenerateToken(claims);
        
        }
        private TokenDto GenerateToken(IList<Claim> claimsList)
        {
            string keyString = _Configuration.GetValue<string>("secretKey") ?? string.Empty;
            var keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);

            //Combination of secret Key and HashingAlgorithm
            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            //Putting All together
            var expiry = DateTime.Now.AddMinutes(15);

            var jwt = new JwtSecurityToken(
                    expires: expiry,
                    claims: claimsList,
                    signingCredentials: signingCredentials);

            //Getting Token String
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return new TokenDto
            {
                Token = tokenString,
                Expiry = expiry
            };
        }




    }
}
