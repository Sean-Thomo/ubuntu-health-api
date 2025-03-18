using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Identity;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController(IPrescriptionService prescriptionService) : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService = prescriptionService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prescription>>> GetAllPrescriptions()
        {
            var prescriptions = await _prescriptionService.GetAllPrescriptionsAsync();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prescription>> GetPrescriptionById(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }
            return Ok(prescription);
        }

        [HttpPost]
        public async Task<ActionResult> AddPrescription([FromBody] Prescription prescription)
        {
            if(prescription == null)
            {
                return BadRequest("Prescription data is null");
            }

            await _prescriptionService.AddPrescriptionAsync(prescription);
            return CreatedAtAction(nameof(GetPrescriptionById), new { id = prescription.Id }, prescription);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            await _prescriptionService.DeletePrescriptionAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePrescription(int id, [FromBody] Prescription prescription)
        {
            if (id != prescription.Id)
            {
                return BadRequest();
            }

            var existingPrescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (existingPrescription == null)
            {
                return NotFound();
            }

            await _prescriptionService.UpdatePrescriptionAsync(prescription);
            return NoContent();
        }
    }
}