using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientsController  : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
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

            await _patientService.AddPatientAsync(patient);
            return CreatedAtAction(nameof(GetPatientById), new { id = patient.Id }, patient);
        }
    }
    }
}