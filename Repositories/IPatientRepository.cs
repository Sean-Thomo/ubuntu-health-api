using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task<Patient> GetPatientByIdAsync(int id);
        Task AddPatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
        Task UpdatePatientAsync(Patient patient);
    }
}