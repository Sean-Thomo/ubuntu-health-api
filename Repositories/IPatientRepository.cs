using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IPatientRepository
  {
    Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId);
    Task<Patient> GetPatientByIdAsync(int id, string tenantId);
    Task AddPatientAsync(Patient patient);
    Task UpdatePatientAsync(Patient patient, string tenantId);
    Task DeletePatientAsync(int id, string tenantId);
  }
}