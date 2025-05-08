using ubuntu_health_api.Models;

namespace ubuntu_health_api.Services
{
  public interface IAppointmentService
  {
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string tenantId);
    Task<Appointment> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment, string tenantId);
    Task DeleteAppointmentAsync(int id, string tenantId);
    Task UpdateAppointmentAsync(Appointment appointment, string tenantId);
  }
}