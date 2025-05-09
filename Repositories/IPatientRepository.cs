using ubuntu_health_api.Models;

namespace ubuntu_health_api.Repositories
{
  public interface IPatientRepository
  {
    Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId);
    Task<Patient> GetPatientByIdAsync(int id, string tenantId);
    Task AddPatientAsync(Patient patient);
    Task DeletePatientAsync(int id);
    Task UpdatePatientAsync(Patient patient);
  }
}