using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TenantController : ControllerBase
	{
		private readonly ITenantRepository _tenantRepository;

		public TenantController(ITenantRepository tenantRepository)
		{
			_tenantRepository = tenantRepository;
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAllTenants()
		{
			var tenants = await _tenantRepository.GetAllTenantsAsync();
			return Ok(tenants);
		}
	}
}