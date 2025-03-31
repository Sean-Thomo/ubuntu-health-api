using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResponseDto 
                { 
                    IsSuccess = false,
                    Message = "Invalid request",
                    // Errors = ModelState.Values
                    //     .SelectMany(v => v.Errors)
                    //     .Select(e => e.ErrorMessage)
                });
            }
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return BadRequest(new AuthResponseDto 
                { 
                    IsSuccess = false, 
                    Message = "User already exists!" 
                });

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                LicenseNumber = model.LicenseNumber,
                Specialty = model.Specialty,
                PracticeName = model.PracticeName,
                PracticePhone = model.PracticePhone,
                // CreatedAt = model.CreatedAt,
                // UpdatedAt = model.UpdatedAt
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(new AuthResponseDto 
                { 
                    IsSuccess = false, 
                    Message = string.Join(", ", result.Errors.Select(e => e.Description)) 
                });

            // Optionally add default role
            // await _userManager.AddToRoleAsync(user, "User");

            return Ok(new AuthResponseDto 
            { 
                IsSuccess = true, 
                Message = "User created successfully!" 
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new AuthResponseDto 
                { 
                    IsSuccess = false, 
                    Message = "Invalid email or password" 
                });

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            // Add roles to claims
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = GenerateJwtToken(authClaims);

            return Ok(new AuthResponseDto
            {
                IsSuccess = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                Roles = userRoles,
                Message = "Login successful"
            });
        }

        private JwtSecurityToken GenerateJwtToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authSigningKey, SecurityAlgorithms.HmacSha256));

            return token;
        }
    }
}