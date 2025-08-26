using AutoMapper;
using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class AppointmentService(IAppointmentRepository appointmentRepository, IMapper mapper) : IAppointmentService
  {
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<PagedResult<Appoinment>> GetPaginatedAppointmentsAsync(int tenantId, int page, int pageSize)
    {
      var query = _context.Appoinments.Where(a => a.TenantId == tenantId);

      var totalCount = await query.CountAsync();

      var items = await query
          .Skip((page - 1) * pageSize)
          .Take(pageSize)
          .ToListAsync();

      return new PagedResult<Appointment>
      {
        Items = items,
        TotalCount = totalCount,
        Page = page,
        PageSize = pageSize
      };
    }

    public async Task<IEnumerable<AppointmentResponseDto>> GetAllAppointmentsAsync(string tenantId)
    {
      var appointments = await _appointmentRepository.GetAllAppointmentsAsync(tenantId) ??
      throw new KeyNotFoundException("No Appointments found");
      return _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointments);
    }

    public async Task<AppointmentResponseDto> GetAppointmentByIdAsync(int id, string tenantId)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId)
          ?? throw new KeyNotFoundException($"Appoinment not found");

      return _mapper.Map<AppointmentResponseDto>(appointment);
    }

    public async Task<AppointmentResponseDto> AddAppointmentAsync(AppointmentCreateDto createDto, string tenantId)
    {
      var appointment = _mapper.Map<Appointment>(createDto);
      appointment.TenantId = tenantId;
      appointment.CreatedAt = DateTime.UtcNow;
      appointment.UpdatedAt = DateTime.UtcNow;

      await _appointmentRepository.AddAppointmentAsync(appointment);

      return _mapper.Map<AppointmentResponseDto>(appointment);
    }

    public async Task<AppointmentResponseDto> UpdateAppointmentAsync(int id, AppointmentUpdateDto updateDto, string tenantId)
    {
      var existingAppointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId)
          ?? throw new KeyNotFoundException("Appointment not found");

      _mapper.Map(updateDto, existingAppointment);
      existingAppointment.UpdatedAt = DateTime.UtcNow;

      await _appointmentRepository.UpdateAppointmentAsync(existingAppointment, tenantId);
      return _mapper.Map<AppointmentResponseDto>(existingAppointment);
    }

    public async Task<bool> DeleteAppointmentAsync(int id, string tenantId)
    {
      try
      {
        await _appointmentRepository.DeleteAppointmentAsync(id, tenantId);
        return true;
      }
      catch
      {
        return false;
      }
    }
  }
}