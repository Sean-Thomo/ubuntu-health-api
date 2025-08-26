using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ubuntu_health_api.Helpers;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Services;

namespace ubuntu_health_api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class AppointmentsController(IAppointmentService appointmentService, IHttpContextAccessor httpContextAccessor, IMapper mapper) : ControllerBase
  {
    private readonly IAppointmentService _appointmentService = appointmentService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IMapper _mapper = mapper;

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppointmentResponseDto>>> GetAllAppointments(
      int page = 1,
      int pageSize = 10,
    )
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var results = await _appointmentService.GetPaginatedAppointmentsAsync(tenantId, page, pageSize);

      var mapped = _mapper.Map<IEnumerable<AppointmentResponseDto>>(results.Items);

      return Ok(new PagedResult<AppointmentResponseDto>
      {
        Items = mapped,
        TotalCount = results.TotalCount,
        Page = results.Page,
        PageSize = results.PageSize
      });
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppointmentResponseDto>> GetAppointmentById(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var appointment = await _appointmentService.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null)
      {
        return NotFound();
      }
      return Ok(_mapper.Map<AppointmentResponseDto>(appointment));
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPost]
    public async Task<ActionResult> AddAppointment([FromBody] AppointmentCreateDto appointment)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      await _appointmentService.AddAppointmentAsync(appointment, tenantId);
      var responseDto = _mapper.Map<AppointmentResponseDto>(appointment);
      return CreatedAtAction(nameof(GetAppointmentById), new { id = responseDto.Id }, responseDto);
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAppointment(int id, [FromBody] AppointmentUpdateDto appointment)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var updatedAppointment = await _appointmentService.UpdateAppointmentAsync(id, appointment, tenantId);
      if (updatedAppointment == null) return NotFound();

      return Ok(_mapper.Map<AppointmentResponseDto>(updatedAppointment));
    }

    [Authorize(Roles = "admin,doctor,nurse,receptionist")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAppointment(int id)
    {
      if (_httpContextAccessor.HttpContext == null) return Forbid();
      var tenantId = TenantHelper.GetTenantId(_httpContextAccessor.HttpContext);
      if (tenantId == null) return Forbid();

      var appointment = await _appointmentService.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null) return NotFound();

      await _appointmentService.DeleteAppointmentAsync(id, tenantId);
      return NoContent();
    }
  }
}