using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Helpers;
using ubuntu_health_api.Models;
using ubuntu_health_api.Services;

namespace ubuntu_health_api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class AppointmentsController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor) : ControllerBase
  {
    private readonly IAppointmentService _appointmentService = appointmentService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;


    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Appointment>>> GetAllAppointments()
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var appointments = await _appointmentService.GetAllAppointmentsAsync(tenantId);
      return Ok(appointments);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet("{id}")]
    public async Task<ActionResult<Appointment>> GetAppointmentById(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var appointment = await _appointmentService.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null)
      {
        return NotFound();
      }
      return Ok(appointment);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPost]
    public async Task<ActionResult> AddAppointment([FromBody] Appointment appointment)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      if (appointment == null)
      {
        return BadRequest("Appointment data is null");
      }

      await _appointmentService.AddAppointmentAsync(appointment, tenantId);
      return CreatedAtAction(nameof(GetAppointmentById), new { id = appointment.AppointmentId }, appointment);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAppointment(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var appointment = await _appointmentService.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null)
      {
        return NotFound();
      }
      await _appointmentService.DeleteAppointmentAsync(id, tenantId);
      return NoContent();
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAppointment(int id, [FromBody] Appointment appointment)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var result = await _appointmentService.UpdateAppointmentAsync(appointment, tenantId);
      if (!result) return NotFound();

      return NoContent();
    }
  }
}