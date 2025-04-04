using Microsoft.AspNetCore.Authorization;
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
        RoleManager<IdentityRole> roleManager,
        IConfiguration configuration) : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly IConfiguration _configuration = configuration;

        [HttpPost("create-role")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            if(string.IsNullOrWhiteSpace(roleName))
            {
                return BadRequest(new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = "Role name cannot be empty"
                });
            }

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if(roleExists)
            {
                return BadRequest(new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = "Role already exists"
                });
            }

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                return BadRequest(new AuthResponseDto
                {
                    IsSuccess = false,
                    Message = string.Join(", ", result.Errors.Select(e => e.Description))
                });
            }
            
            return Ok(new AuthResponseDto
            {
                IsSuccess = true,
                Message = "Role created successfully"
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthResponseDto 
                { 
                    IsSuccess = false,
                    Message = "Invalid request",
                });
            }
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                return BadRequest(new AuthResponseDto 
                { 
                    IsSuccess = false, 
                    Message = "User already exists!",
                });

            var user = new ApplicationUser
            {
                TenantId = request.TenantId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                LicenseNumber = request.LicenseNumber,
                Specialty = request.Specialty,
                PracticeName = request.PracticeName,
                PracticePhone = request.PracticePhone,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return BadRequest(new AuthResponseDto 
                { 
                    IsSuccess = false, 
                    Message = string.Join(", ", result.Errors.Select(e => e.Description)) 
                });

            return Ok(new AuthResponseDto 
            { 
                IsSuccess = true, 
                Message = "User created successfully!"
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            return Unauthorized(new AuthResponseDto
            { 
                IsSuccess = false, 
                Message = "Invalid email or password" 
            });

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Email, user.Email),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var tenantId = user.TenantId;
            if (!string.IsNullOrEmpty(tenantId))
            {
                authClaims.Add(new Claim("TenantId", tenantId));
            }

            if (!string.IsNullOrEmpty(user.LicenseNumber))
            {
                authClaims.Add(new Claim("LicenseNumber", user.LicenseNumber));
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            if (string.IsNullOrEmpty(user.LicenseNumber))
            {
                Console.WriteLine("LicenseNumber is null for user: " + user.Email);
            }

            var token = GenerateJwtToken(authClaims);

            return Ok(new AuthResponseDto
            {
                IsSuccess = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Email = user.Email,
                LicenseNumber = user.LicenseNumber,
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
                expires: DateTime.Now.AddHours(4),
                claims: authClaims,
                signingCredentials: new SigningCredentials(
                    authSigningKey, SecurityAlgorithms.HmacSha256)); 

            return token;
        }
    }
}