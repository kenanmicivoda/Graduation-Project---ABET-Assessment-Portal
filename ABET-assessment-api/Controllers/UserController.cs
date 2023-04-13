using ABET_assessment_api.DTO;
using ABET_assessment_api.Helpers;
using ABET_assessment_api.Models;
using ABET_assessment_api.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ABET_assessment_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager, IConfiguration configuration,SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
        }
        [Route("Registration")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User model)
        {
            var newUser = new IdentityUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(newUser, model.Password!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new SuccesResponse { Successful = false, Errors = errors });

            }

            return Ok(new SuccesResponse { Successful = true });
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var result = await _signInManager.PasswordSignInAsync(login.Email!, login.Password!, false, false);

            if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, login.Email!)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpiryInDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                claims,
                expires: expiry,
                signingCredentials: creds
            );

            return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
