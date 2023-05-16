using ABET_assessment_api.DataContext;
using ABET_assessment_api.DTO;
using ABET_assessment_api.Helpers;
using ABET_assessment_api.Models;
using ABET_assessment_api.Services.UserServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NuGet.Versioning;
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
        private readonly Context _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, IConfiguration configuration,SignInManager<IdentityUser> signInManager, Context context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _context = context;
            _roleManager = roleManager;
        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegistrationModel model)
        {
            var newUser = new User { UserName = model.Email, Email = model.Email, Role = model.Role };

            var result = await _userManager.CreateAsync(newUser, model.Password!);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description);

                return Ok(new SuccesResponse { Successful = false, Errors = errors });

            }

            return Ok(new SuccesResponse { Successful = true });
        }

        [Route("LoginUser")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
  
            var result = await _signInManager.PasswordSignInAsync(login.Email!, login.Password!, false, false);

            if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

            var user = await _signInManager.UserManager.FindByEmailAsync(login.Email!);
            var roles = await _signInManager.UserManager.GetRolesAsync(user!);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, login.Email!),
               
            };

            //if (roles != null && roles.Count > 0)
            //{
            //    foreach (var role in roles)
            //    {
            //        claims.Add(new Claim(ClaimTypes.Role, role));
            //    }
            //}

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UpdateUser model)
        {
            // Find the user by ID
            var user = await _context.Users.FindAsync(id.ToString());

            if (user == null)
            {
                // Return appropriate response if user not found
                return NotFound();
            }

            // Update user properties with new values
            user.UserName = model.Email;
            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;

            // Update user password if provided
            if (!string.IsNullOrEmpty(model.Password))
            {
                // Remove existing user password hash
                await _userManager.RemovePasswordAsync(user);

                // Set new user password
                await _userManager.AddPasswordAsync(user, model.Password);
            }

            // Update user in the database
            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                var errors = updateResult.Errors.Select(x => x.Description);
                return BadRequest(new SuccesResponse { Successful = false, Errors = errors });
            }

            return Ok(new SuccesResponse { Successful = true });
        }


        [HttpGet("users")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            List<User> users = new();
            var allUsers = await _userManager.Users.ToListAsync();
            foreach(var user in allUsers)
            {
                var userModel = new User
                {
                    Email= user.Email,
                    Name =user.UserName
                };

                users.Add(userModel);
            }
            return users;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }



    }
}
