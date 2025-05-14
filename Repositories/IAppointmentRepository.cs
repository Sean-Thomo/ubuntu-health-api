using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IAppointmentRepository
  {
    Task<IEnumerable<Appointment>> GetAllAppointmentsAsync(string tenantId);
    Task<Appointment> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment);
    Task UpdateAppointmentAsync(Appointment appointment, string tenantId);
    Task DeleteAppointmentAsync(int id, string tenantId);
  }
}