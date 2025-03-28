using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;

namespace ubuntu_health_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionsController(IPrescriptionService prescriptionService) : ControllerBase
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
            return CreatedAtAction(nameof(GetPrescriptionById), new { id = prescription.PrescriptionId }, prescription);
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
            if (id != prescription.PrescriptionId)
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