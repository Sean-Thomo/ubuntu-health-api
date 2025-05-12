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
  public class PatientsController(IPatientService patientService, IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IPatientService _patientService = patientService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDto>>> GetAllPatients()
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var patients = await _patientService.GetAllPatientsAsync(tenantId);
      return Ok(patients);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet("{id}")]
    public async Task<ActionResult<PatientDto>> GetPatientById(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var patient = await _patientService.GetPatientByIdAsync(id, tenantId);
      if (patient == null) return NotFound();

      return Ok(patient);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPost]
    public async Task<ActionResult> AddPatient([FromBody] Patient patient)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      await _patientService.AddPatientAsync(patient, tenantId);
      return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePatient(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var result = await _patientService.DeletePatientAsync(id, tenantId);
      if (!result) return NotFound();

      return NoContent();
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePatient(int id, [FromBody] Patient patient)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (id != patient.PatientId)
      {
        return BadRequest();
      }

      var existingPatient = await _patientService.GetPatientByIdAsync(id, tenantId);
      if (existingPatient == null)
      {
        return NotFound();
      }

      var result = await _patientService.UpdatePatientAsync(patient, tenantId);
      if (!result) return NotFound();

      return NoContent();
    }
  }
}