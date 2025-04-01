using ubuntu_health_api.Models;

namespace ubuntu_health_api.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync(string _tenantId);
        Task<Patient> GetPatientByIdAsync(int id, string _tenantId);
        Task AddPatientAsync(Patient patient, string _tenantId);
        Task DeletePatientAsync(int id, string _tenantId);
        Task UpdatePatientAsync(Patient patient, string _tenantId);
    }
}