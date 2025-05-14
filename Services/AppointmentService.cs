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

    public async Task<IEnumerable<AppointmentResponseDto>> GetAllAppointmentsAsync(string tenantId)
    {
      var appointments = await _appointmentRepository.GetAllAppointmentsAsync(tenantId);
      return _mapper.Map<IEnumerable<AppointmentResponseDto>>(appointments);
    }

    public async Task<AppointmentResponseDto> GetAppointmentByIdAsync(int id, string tenantId)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId)
          ?? throw new KeyNotFoundException($"Appointment with ID {id} not found for tenant {tenantId}");

      return _mapper.Map<AppointmentResponseDto>(appointment);
    }

    public async Task<AppointmentResponseDto> CreateAppointmentAsync(AppointmentCreateDto createDto, string tenantId)
    {
      var appointment = _mapper.Map<Appointment>(createDto);
      appointment.TenantId = tenantId;
      appointment.CreatedAt = DateTime.UtcNow;
      appointment.UpdatedAt = DateTime.UtcNow;

      await _appointmentRepository.AddAppointmentAsync(appointment);

      return _mapper.Map<AppointmentResponseDto>(appointment);
    }

    public async Task<AppointmentResponseDto> UpdateAppointmentAsync(AppointmentUpdateDto updateDto, string tenantId)
    {
      var existingAppointment = await _appointmentRepository.GetAppointmentByIdAsync(updateDto., tenantId)
          ?? throw new KeyNotFoundException($"Appointment with ID {updateDto.Id} not found for tenant {tenantId}");

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

    public Task AddAppointmentAsync(Appointment appointment)
    {
      throw new NotImplementedException();
    }

    Task<bool> IAppointmentService.UpdateAppointmentAsync(AppointmentUpdateDto appointment, string tenantId)
    {
      throw new NotImplementedException();
    }
  }
}