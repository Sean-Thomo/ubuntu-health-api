using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Repositories
{
  public interface IPatientRepository
  {
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync(string tenantId);
    Task<PatientDto> GetPatientByIdAsync(int id, string tenantId);
    Task AddPatientAsync(Patient patient);
    Task DeletePatientAsync(int id);
    Task UpdatePatientAsync(Patient patient);
  }
}