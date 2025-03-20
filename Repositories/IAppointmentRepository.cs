using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAllAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task AddAppointmentAsync(Appointment appointment);
        Task DeleteAppointmentAsync(int id);
        Task UpdateAppointmentAsync(Appointment appointment);
    }
}