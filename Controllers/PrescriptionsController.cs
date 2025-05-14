using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;
using Microsoft.AspNetCore.Authorization;
using ubuntu_health_api.Helpers;

namespace ubuntu_health_api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class PrescriptionsController(IPrescriptionService prescriptionService, IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IPrescriptionService _prescriptionService = prescriptionService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [Authorize(Roles = "admin, doctor, nurse")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Prescription>>> GetAllPrescriptions()
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var prescriptions = await _prescriptionService.GetAllPrescriptionsAsync(tenantId);
      return Ok(prescriptions);
    }

    [Authorize(Roles = "admin, doctor, nurse")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Prescription>> GetPrescriptionById(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id, tenantId);
      if (prescription == null)
      {
        return NotFound();
      }
      return Ok(prescription);
    }

    [Authorize(Roles = "doctor")]
    [HttpPost]
    public async Task<ActionResult> AddPrescription([FromBody] Prescription prescription)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();
      if (prescription == null)
      {
        return BadRequest("Prescription data is null");
      }

      await _prescriptionService.AddPrescriptionAsync(prescription, tenantId);
      return CreatedAtAction(nameof(GetPrescriptionById), new { id = prescription.Id }, prescription);
    }

    [Authorize(Roles = "doctor")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAppointment(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id, tenantId);
      if (prescription == null)
      {
        return NotFound();
      }

      await _prescriptionService.DeletePrescriptionAsync(id, tenantId);
      return NoContent();
    }

    [Authorize(Roles = "doctor")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePrescription(int id, [FromBody] Prescription prescription)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (id != prescription.Id)
      {
        return BadRequest();
      }

      var existingPrescription = await _prescriptionService.GetPrescriptionByIdAsync(id, tenantId);
      if (existingPrescription == null)
      {
        return NotFound();
      }

      var result = await _prescriptionService.UpdatePrescriptionAsync(prescription, tenantId);
      if (!result) return NotFound();

      return NoContent();
    }
  }
}