using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;
using Microsoft.AspNetCore.Authorization;
using ubuntu_health_api.Helpers;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class ClinicalNotesController(IClinicalNoteService clinicalNoteService
  , IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IClinicalNoteService _clinicalNoteService = clinicalNoteService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [Authorize(Roles = "admin,doctor,nurse")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClinicalNoteDto>>> GetAllClinicalNotes()
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var clinicalNotes = await _clinicalNoteService.GetAllClinicalNotesAsync(tenantId);
      return Ok(clinicalNotes);
    }

    [Authorize(Roles = "admin,doctor,nurse")]
    [HttpGet("{id}")]
    public async Task<ActionResult<ClinicalNoteDto>> GetClinicalNoteById(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var clinicalNote = await _clinicalNoteService.GetClinicalNoteByIdAsync(id, tenantId);
      if (clinicalNote == null) return NotFound();

      return Ok(clinicalNote);
    }
  }
}