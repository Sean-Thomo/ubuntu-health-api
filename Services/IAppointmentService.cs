using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IAppointmentService
  {
    Task<IEnumerable<AppointmentDto>> GetAllAppointmentsAsync(string tenantId);
    Task<AppointmentDto> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment, string tenantId);
    Task<bool> DeleteAppointmentAsync(int id, string tenantId);
    Task<bool> UpdateAppointmentAsync(Appointment appointment, string tenantId);
  }
}