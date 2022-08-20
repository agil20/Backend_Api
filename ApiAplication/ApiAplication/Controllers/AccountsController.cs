using ApiAplication.Dtos.Account;
using ApiAplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _rolemanager;
        public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager = null)
        {
            _userManager = userManager;
            _rolemanager = rolemanager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registrDto)
        {
            AppUser user = await _userManager.FindByNameAsync(registrDto.UserName);
            if (user!=null)
            {
                return BadRequest();

            }
            user = new AppUser
            {

                UserName=registrDto.UserName,
                FullName=registrDto.FullName,

            };
            var result=await _userManager.CreateAsync(user,registrDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
           return Ok();        
        
        }
        [HttpGet]
        public  async Task<IActionResult> CreateRole()
        {
            
            return Ok();
        
        }
    }
}
