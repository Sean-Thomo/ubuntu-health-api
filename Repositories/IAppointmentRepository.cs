using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IAppointmentRepository
  {
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync(string tenantId);
    Task<AppointmentDto> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment);
    Task DeleteAppointmentAsync(int id);
    Task UpdateAppointmentAsync(Appointment appointment);
  }
}