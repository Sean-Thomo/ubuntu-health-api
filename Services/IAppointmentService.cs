using ubuntu_health_api.Models;

namespace ubuntu_health_api.Services
{
  public interface IAppointmentService
  {
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string tenantId);
    Task<Appointment> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment, string tenantId);
    Task<bool> DeleteAppointmentAsync(int id, string tenantId);
    Task<bool> UpdateAppointmentAsync(Appointment appointment, string tenantId);
  }
}