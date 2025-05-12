using ubuntu_health_api.Models;
using ubuntu_health_api.Models.DTO;

namespace ubuntu_health_api.Services
{
  public interface IPatientService
  {
    Task<IEnumerable<PatientDto>> GetAllPatientsAsync(string tenantId);
    Task<PatientDto> GetPatientByIdAsync(int id, string tenantId);
    Task AddPatientAsync(Patient patient, string tenantId);
    Task<bool> DeletePatientAsync(int id, string tenantId);
    Task<bool> UpdatePatientAsync(Patient patient, string tenantId);
  }
}