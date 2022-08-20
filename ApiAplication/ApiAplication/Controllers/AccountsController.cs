using ApiAplication.Dtos.Account;
using ApiAplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static ApiAplication.Helper.Helper;

namespace ApiAplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> rolemanager = null)
        {
            _userManager = userManager;
            _roleManager = rolemanager;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registrDto)
        {
            AppUser user = await _userManager.FindByNameAsync(registrDto.UserName);
            if (user != null)
            {
                return BadRequest();

            }
            user = new AppUser
            {

                UserName = registrDto.UserName,
                FullName = registrDto.Fullname,

            };
            var result = await _userManager.CreateAsync(user, registrDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest();
            }
            result = await _userManager.AddToRoleAsync(user, "Admin");
            return Ok();

        }
        [HttpGet]
        public async Task CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                if (!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
                }
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            AppUser user=await _userManager.FindByNameAsync(loginDto.UserName);
            if (User == null) return NotFound();
            if (!await _userManager.CheckPasswordAsync(user,loginDto.Password))
            {
                return NotFound();
            }
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim("Fulljame", user.FullName));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            var roles = await _userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));
            string secretKey = "cc870d56-968e-467a-aa63-0873e2603f11";

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(3),
                SigningCredentials=credentials,
                Audience= "http://localhost:6393/",
                Issuer= "http://localhost:6393/"

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token= tokenHandler.WriteToken(token)});
        }
        [Authorize]
        [HttpGet("userprofile")]
     
        public async Task<IActionResult >GetProfile()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
       
        return Ok(new {Name = user.UserName });
        
        }
    }
}
