using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
  public interface IAppointmentRepository
  {
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string tenantId);
    Task<Appointment> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment);
    Task DeleteAppointmentAsync(int id);
    Task UpdateAppointmentAsync(Appointment appointment);
  }
}