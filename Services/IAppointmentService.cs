using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IAppointmentService
  {
    Task<IEnumerable<AppointmentResponseDto>> GetAllAppointmentsAsync(string tenantId);
    Task<AppointmentResponseDto> GetAppointmentByIdAsync(int id, string tenantId);
    Task AddAppointmentAsync(Appointment appointment);
    Task<bool> UpdateAppointmentAsync(AppointmentUpdateDto appointment, string tenantId);
    Task<bool> DeleteAppointmentAsync(int id, string tenantId);
  }
}