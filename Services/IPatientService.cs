using Backend.Models;

namespace Backend.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
        Task UpdatePatientAsync(Patient patient);
    }
}