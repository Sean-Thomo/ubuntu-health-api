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


    public async Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync(string tenantId)
    {
      var appointments = await _appointmentRepository.GetAllAppointmentsAsync(tenantId);
      if (appointments == null)
      {
        throw new KeyNotFoundException("No appointments found");
      }
      return _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
    }

    public async Task<AppointmentDto> GetAppointmentByIdAsync(int id, string tenantId)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null)
      {
        throw new KeyNotFoundException("Appointment not found.");
      }
      return _mapper.Map<AppointmentDto>(appointment);
    }

    public async Task AddAppointmentAsync(Appointment appointment, string tenantId)
    {
      appointment.TenantId = tenantId;
      await _appointmentRepository.AddAppointmentAsync(appointment);
    }

    public async Task<bool> DeleteAppointmentAsync(int id, string tenantId)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null)
      {
        return false;
      }
      await _appointmentRepository.DeleteAppointmentAsync(id);
      return true;
    }

    public async Task<bool> UpdateAppointmentAsync(Appointment appointment, string tenantId)
    {
      var existingAppointment = await _appointmentRepository.GetAppointmentByIdAsync(appointment.AppointmentId, tenantId);
      if (existingAppointment == null)
      {
        return false;
      }

      appointment.TenantId = tenantId;
      await _appointmentRepository.UpdateAppointmentAsync(appointment);
      return true;
    }
  }
}