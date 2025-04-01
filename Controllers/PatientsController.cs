using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;
using Microsoft.AspNetCore.Authorization;

namespace ubuntu_health_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController(IPatientService patientService, IHttpContextAccessor httpContextAccessor) : ControllerBase
    {
        private readonly IPatientService _patientService = patientService;
        private readonly string _tenantId = httpContextAccessor.HttpContext?.User?
        .FindFirst("TenantId")?.Value ?? throw new UnauthorizedAccessException();

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync(_tenantId);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id, _tenantId);
            if (patient == null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient([FromBody] Patient patient)
        {
            if (patient == null)
            {
                return BadRequest("Patient data is null.");
            }
            {
                Console.WriteLine($"Received patient: {patient.FirstName}, {patient.LastName}, Email: {patient.Email}");
            }

            await _patientService.AddPatientAsync(patient, _tenantId);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.PatientId }, patient);
        }

        [Authorize(Roles = "Doctor,Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id, _tenantId);
            if (patient == null)
            {
                return NotFound();
            }
            await _patientService.DeletePatientAsync(id, _tenantId);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (id != patient.PatientId)
            {
                return BadRequest();
            }
            var existingPatient = await _patientService.GetPatientByIdAsync(id, _tenantId);
            if (existingPatient == null)
            {
                return NotFound();
            }
            await _patientService.UpdatePatientAsync(patient, _tenantId);
            return NoContent();
        }
    }
}