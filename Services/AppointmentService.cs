using ubuntu_health_api.Models;
using ubuntu_health_api.Repositories;

namespace ubuntu_health_api.Services
{
  public class AppointmentService(IAppointmentRepository appointmentRepository) : IAppointmentService
  {
    private readonly IAppointmentRepository _appointmentRepository = appointmentRepository;

    public async Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string tenantId)
    {
      return await _appointmentRepository.GetAllAppointmentsAsync(tenantId);
    }

    public async Task<Appointment> GetAppointmentByIdAsync(int id, string tenantId)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null || appointment.TenantId != tenantId)
      {
        throw new KeyNotFoundException("Appointment not found.");
      }
      return appointment;
    }

    public async Task AddAppointmentAsync(Appointment appointment, string tenantId)
    {
      appointment.TenantId = tenantId;
      await _appointmentRepository.AddAppointmentAsync(appointment);
    }

    public async Task<bool> DeleteAppointmentAsync(int id, string tenantId)
    {
      var appointment = await _appointmentRepository.GetAppointmentByIdAsync(id, tenantId);
      if (appointment == null || appointment.TenantId != tenantId)
      {
        return false;
      }
      await _appointmentRepository.DeleteAppointmentAsync(id);
      return true;
    }

    public async Task<bool> UpdateAppointmentAsync(Appointment appointment, string tenantId)
    {
      var existingAppointment = await _appointmentRepository.GetAppointmentByIdAsync(appointment.AppointmentId, tenantId);
      if (existingAppointment == null || existingAppointment.TenantId != tenantId)
      {
        return false;
      }

      appointment.TenantId = tenantId;
      await _appointmentRepository.UpdateAppointmentAsync(appointment);
      return true;
    }
  }
}