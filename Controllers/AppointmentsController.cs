using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;

namespace ubuntu_health_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController(IAppointmentService appointmentService) : ControllerBase
    {
        private readonly IAppointmentService _appointmentService = appointmentService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
        {
            var appointments = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult> AddAppointment([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment data is null");
            }

            await _appointmentService.AddAppointmentAsync(appointment);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentId }, appointment);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAppointment(int id)
        {
            var appointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            await _appointmentService.DeleteAppointmentAsync(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
        {
            if (id != appointment.AppointmentId)
            {
                return BadRequest();
            }
            var existingAppointment = await _appointmentService.GetAppointmentByIdAsync(id);
            if (existingAppointment == null)
            {
                return NotFound();
            }
            await _appointmentService.UpdateAppointmentAsync(appointment);
            return NoContent();
        }
    }
}