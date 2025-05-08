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
  public class PatientsController(IPatientService patientService, IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IPatientService _patientService = patientService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var patients = await _patientService.GetAllPatientsAsync(tenantId);
      return Ok(patients);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Patient>> GetPatientById(int id)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var patient = await _patientService.GetPatientByIdAsync(id, tenantId);
      if (patient == null)
      {
        return NotFound();
      }
      return Ok(patient);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPost]
    public async Task<ActionResult> AddPatient([FromBody] Patient patient)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (patient == null)
      {
        return BadRequest("Patient data is null.");
      }

      patient.TenantId = tenantId;

      await _patientService.AddPatientAsync(patient, tenantId);
      return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePatient(int id)
    {
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var patient = await _patientService.GetPatientByIdAsync(id, tenantId);
      if (patient == null)
      {
        return NotFound();
      }
      await _patientService.DeletePatientAsync(id, tenantId);
      return NoContent();
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePatient(int id, [FromBody] Patient patient)
    {
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

      patient.TenantId = tenantId;

      await _patientService.UpdatePatientAsync(patient, tenantId);
      return NoContent();
    }
  }
}