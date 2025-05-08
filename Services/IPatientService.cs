using ubuntu_health_api.Models;

namespace ubuntu_health_api.Services
{
  public interface IPatientService
  {
    Task<IEnumerable<Patient>> GetAllPatientsAsync(string tenantId);
    Task<Patient> GetPatientByIdAsync(int id, string tenantId);
    Task AddPatientAsync(Patient patient, string tenantId);
    Task<bool> DeletePatientAsync(int id, string _tenantId);
    Task<bool> UpdatePatientAsync(Patient patient, string _tenantId);
  }
}