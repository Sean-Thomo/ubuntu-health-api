using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;

        public AppointmentService(IPatientRepository patientRepository)
        {
            _appointmentRepository = patientRepository;
        }

        public async Task<IEnumerable<AppointmentService>> GetAllAppointmentAsync()
        {
            return await _appointmentRepository.GetAllAppointmentAsync();
        }

        public async Task<AppointmentService> GetPatientByIdAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            await _appointmentRepository.DeleteAppointmentAsync(id);
        }

        public async Task UpdatePatientAsync(AppointmentService appointment)
        {
            await _appointmentRepository.UpdateAppointmentAsync(appointment);
        }
    }
}