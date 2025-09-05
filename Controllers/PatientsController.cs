using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;
using Microsoft.AspNetCore.Authorization;
using ubuntu_health_api.Helpers;
using ubuntu_health_api.Models.DTO;
using AutoMapper;
using ubuntu_health_api.Exceptions;

namespace ubuntu_health_api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class PatientsController(IPatientService patientService,
  IHttpContextAccessor httpContextAccessor,
  IMapper mapper,
  ILogger<PatientsController> logger) : ControllerBase
  {
    private readonly IPatientService _patientService = patientService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IMapper _mapper = mapper;
    private readonly ILogger<PatientsController> _logger = logger;

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientResponseDto>>> GetAllPatients()
    {
      _logger.LogInformation("Getting all patients for tenant");

      if (_httpContextAccessor.HttpContext == null)
      {
        _logger.LogWarning("HttpContext is null when getting all patients");
        return Forbid();
      }

      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null)
      {
        _logger.LogWarning("TenantId is null when getting all patients");
        return Forbid();
      }

      try
      {
        var patients = await _patientService.GetAllPatientsAsync(tenantId);
        _logger.LogInformation("Successfully retrieved {Count} patients for tenant {TenantId}",
          patients.Count(), tenantId);
        return Ok(patients);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while getting all patients for tenant {TenantId}", tenantId);
        throw;
      }
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
    public async Task<ActionResult> AddPatient([FromBody] PatientDto patient)
    {
      _logger.LogInformation("Adding new patient for tenant");

      if (!ModelState.IsValid)
      {
        _logger.LogWarning("Invalid model state when adding patient: {Errors}",
          string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));
        return BadRequest(ModelState);
      }

      if (_httpContextAccessor.HttpContext == null)
      {
        _logger.LogWarning("HttpContext is null when adding patient");
        return Forbid();
      }

      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null)
      {
        _logger.LogWarning("TenantId is null when adding patient");
        return Forbid();
      }

      try
      {
        var responseDto = await _patientService.AddPatientAsync(patient, tenantId);
        _logger.LogInformation("Successfully added patient {PatientId} for tenant {TenantId}",
          responseDto.Id, tenantId);
        return CreatedAtAction(nameof(GetPatientById), new { id = responseDto.Id }, responseDto);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, "Error occurred while adding patient for tenant {TenantId}", tenantId);
        throw;
      }
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePatient(int id, [FromBody] PatientDto patient)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var updatedPatient = await _patientService.UpdatePatientAsync(id, patient, tenantId);
      if (updatedPatient == null) return NotFound();

      return Ok(updatedPatient);
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
  }
}